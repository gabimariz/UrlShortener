using System.ComponentModel.DataAnnotations;

namespace UrlShortener.ViewModels
{
    public class GetLinkViewModel
    {
        [Required(ErrorMessage = "Url is required!")]
        [StringLength(255, ErrorMessage = "Max 255 characteres")]
        public string? Link { get; set; }
    }
}
