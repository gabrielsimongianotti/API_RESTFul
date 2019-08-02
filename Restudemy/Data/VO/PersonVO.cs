using System.ComponentModel.DataAnnotations.Schema;

namespace Restudemy.Data.VO
{
        public class PersonVO
        {
            [Column("Id")]
            public long? Id { get; set; }
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
