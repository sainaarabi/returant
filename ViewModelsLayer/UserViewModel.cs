using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelsLayer
{
    public class UserViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool Role { get; set; }
    }
}
