using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Mia.Admin.Account
{
    public class MiaUser : FullAuditedAggregateRoot<Guid>
    {
        public string UserName { get; protected internal set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; protected internal set; }

        public MiaUser(string userName, string name, string surname, string email)
        {
            UserName = userName;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
