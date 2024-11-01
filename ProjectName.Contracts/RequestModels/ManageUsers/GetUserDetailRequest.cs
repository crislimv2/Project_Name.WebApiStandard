using MediatR;
using Project_Name.Contracts.ResponseModels.ManageUsers;

namespace Project_Name.Contracts.RequestModels.ManageUsers
{
    public class GetUserDetailRequest : IRequest<GetUserDetailResponse?>
    {
        public string Id { set; get; } = "";
    }
}
