using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelInspiration.API.Shared.Domain.Entities;

public abstract class AuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? LastModifiedOn { get; set; }
    public DateTime? LastModifiedOnUtc { get; set; }
    public string? LastModifiedBy { get; set; }

}
