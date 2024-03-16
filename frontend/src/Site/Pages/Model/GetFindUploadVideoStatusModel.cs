using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Site.Pages.Model
{
    public record GetFindUploadVideoStatusModel
    {
        [Required(AllowEmptyStrings = false)]
        [FromRoute(Name = "process-id")]
        public Guid ProcessVideoRequestId { get; init; }
    }
}
