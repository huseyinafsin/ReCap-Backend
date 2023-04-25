using Core.Entities;
using System;


namespace Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        public Guid LanguageId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }


    }


}
