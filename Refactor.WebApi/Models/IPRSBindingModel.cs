using System.ComponentModel.DataAnnotations;

namespace Refactor.WebApi.Models
{
    public class IPRSBindingModel
    {
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public string DocumentType { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        public string SerialNumber { get; set; }
        public string BankCode { get; set; }
    }
}