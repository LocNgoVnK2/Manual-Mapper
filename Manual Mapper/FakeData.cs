using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_Mapper
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    public class UserEntity
    {
        public string FullUserName { get; set; }
        public int Age { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
