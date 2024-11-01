﻿using System.ComponentModel.DataAnnotations;
using Project_Name.Entities.EntityDescriptors;

namespace Project_Name.Entities
{
    public class Blob : IHaveCreateOnlyAudit
    {
        public Blob()
        {
            Id = Ulid.NewUlid().ToString();
        }

        [StringLength(26)]
        public string Id { get; set; }

        [StringLength(255)]
        public string FileName { get; set; } = "";

        [StringLength(255)]
        public string FilePath { get; set; } = "";

        [StringLength(255)]
        public string ContentType { get; set; } = "";

        [StringLength(128)]
        public string? ReferencedByTable { get; set; }

        [StringLength(128)]
        public string? ReferencedByColumn { get; set; }

        [StringLength(450)]
        public string? ReferencedByRowId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [StringLength(256)]
        public string? CreatedBy { get; set; }
    }
}
