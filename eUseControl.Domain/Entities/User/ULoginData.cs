using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Enums;
namespace eUseControl.Domain.Entities.User
{
    public class ULoginData
    {
        public int Id { get; set; }
        public string Credential { get; set; }
        public string Password { get; set; }
        public URole Role { get; set; }
        public DateTime LoginDateTime { get; set; }

    }
}
