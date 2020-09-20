using System;
using System.ComponentModel.DataAnnotations;

namespace FootballersCatalog.Models
{
    public class Footballer
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z\s,.'-]+$"), StringLength(100), Required]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z\s,.'-]+$"), StringLength(100)]
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Date of birth"), DataType(DataType.Date), Required]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Team"), RegularExpression(@"^[a-zA-Z0-9\s,.'-]+$"), StringLength(100), Required]
        public string TeamName { get; set; }
        [Required]
        public Country Country { get; set; }

        public virtual Team Team { get; set; }
    }
}
