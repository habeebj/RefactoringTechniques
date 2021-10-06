namespace Refactor.WebApi.Models
{
    public class IPRSBindingResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public string Occupation { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string SerialNumber { get; set; }
        public string IdentityDocumentType { get; set; }
        public string IssueDate { get; set; }
        public string IssuingLocation { get; set; }
        public string IssuingAuthority { get; set; }

        public static IPRSBindingResponseModel Create(Person person, IdentityDocument identityDocument)
        {
            return new IPRSBindingResponseModel
            {
                FirstName = person.PersonName.FirstName,
                LastName = person.PersonName.LastName,
                SerialNumber = identityDocument.IdentityDocumentSerialNumber,
                // ....
            };
        }
    }
}