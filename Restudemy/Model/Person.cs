using Restudemy.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Model
{
   
        [Table("persons")]
        public class Person :BaseEntity
        {

            [Column("FirstName")]
            public string FirstName { get; set; }

            [Column("LastName")]
            public string LastName { get; set; }

            [Column("Address")]
            public string Address { get; set; }

            [Column("Gender")]
            public string Gender { get; set; }
        }
    
}
