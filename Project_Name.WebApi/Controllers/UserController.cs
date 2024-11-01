﻿using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_Name.Contracts.RequestModels.ManageUsers;
using Project_Name.Contracts.ResponseModels.ManageUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_Name.WebApi.Controllers
{
    /// <summary>
    /// Web API controller for handling user-related data transaction.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for UserController.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET api/<UserApiController>/5
        /// <summary>
        /// Get user detail by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDetailResponse>> Get(string id)
        {
            var response = await _mediator.Send(new GetUserDetailRequest
            {
                Id = id
            });

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        // POST api/<UserApiController>
        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="validator"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpPost]
        public async Task<ActionResult<string>> Post(
            [FromBody] CreateUserRequest model,
            [FromServices] IValidator<CreateUserRequest> validator,
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(model, cancellationToken) ??
                throw new InvalidOperationException("Failed to validate data");

            if (validationResult.IsValid == false)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(model, cancellationToken);
            return response;
        }

        /// <summary>
        /// Update user model class.
        /// </summary>
        public class UpdateUserApiModel
        {
            /// <summary>
            /// Gets or sets the user's given name.
            /// </summary>
            public string GivenName { set; get; } = "";

            /// <summary>
            /// Gets or sets the user's family name.
            /// </summary>
            public string FamilyName { set; get; } = "";

            /// <summary>
            /// Gets or sets the user's email address.
            /// </summary>
            public string Email { set; get; } = "";

            /// <summary>
            /// Gets or sets the user's enabled status.
            /// </summary>
            public bool IsEnabled { set; get; }

            /// <summary>
            /// Gets or sets the user's password.
            /// </summary>
            public string Password { set; get; } = "";
        }

        /// <summary>
        /// AutoMapper for UpdateUserApiModel.
        /// </summary>
        public class UpdateUserApiModelAutoMapper : Profile
        {
            /// <summary>
            /// Constructor for UpdateUserApiModelAutoMapper.
            /// </summary>
            public UpdateUserApiModelAutoMapper()
            {
                CreateMap<UpdateUserApiModel, UpdateUserRequest>();
            }
        }

        // POST api/<UserApiController>/5
        /// <summary>
        /// Update user data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Post(
            string id,
            [FromBody] UpdateUserApiModel model,
            [FromServices] IValidator<UpdateUserRequest> validator)
        {
            var exist = await _mediator.Send(new GetUserDetailRequest
            {
                Id = id
            });

            if (exist == null)
            {
                return NotFound();
            }

            var request = _mapper.Map<UpdateUserRequest>(model);
            request.Id = id;

            var validationResult = await validator.ValidateAsync(request) ??
                throw new InvalidOperationException("Failed to validate data");

            if (validationResult.IsValid == false)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            await _mediator.Send(request);
            return true;
        }
    }
}