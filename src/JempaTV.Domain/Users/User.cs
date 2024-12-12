using JempaTV.Califications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Uow;

namespace JempaTV.Users
{
    public class User : AggregateRoot<int>
    {
        public Guid Id { get; set; }
        public String? UserName { get; set; }
        public String? Name { get; set; }
        public String? Surname { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }

    }
};
