using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballersCatalog.Models
{
    public class Team
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z\s,.'-]+$"), StringLength(100), Required]
        public string Name { get; set; }

        public virtual ICollection<Footballer> Footballers { get; set; }
    }
}
