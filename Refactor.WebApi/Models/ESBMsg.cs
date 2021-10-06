namespace Refactor.WebApi.Models
{
    public class ESBMsg
    {
        public ESBMsgRsData RsData { get; set; }
    }

    public class ESBMsgRsData
    {
        public ESBMsgRsDataNationalIdentity NationalIdentity { get; set; }
        public Status Status { get; set; }
    }

    public class ESBMsgRsDataNationalIdentity
    {
        public Person Person { get; set; }
        public IdentityDocument IdentityDocument { get; set; }
    }

    public class IdentityDocument
    {
        public string IdentityDocumentID { get; set; }
        public string IdentityDocumentSerialNumber { get; set; }
        public string IdentityDocumentType { get; set; }

        public string IssueDate { get; set; }
        public string IssuingLocation { get; set; }

        public string IssuingAuthority { get; set; }
    }

    public class Person
    {
        public PersonPersonName PersonName { get; set; }

        public string BirthDate { get; set; }

        public string DeathDate { get; set; }

        public string BirthCityName { get; set; }

        public string GenderCode { get; set; }

        public string Nationality { get; set; }
        public string Occupation { get; set; }

        public string FaceImage { get; set; }

        public PersonIdentityDocument IdentityDocument { get; set; }
    }

    public class PersonIdentityDocument
    {
    }

    public class PersonPersonName
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class Status
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string ResponseCode { get; set; }
    }
}