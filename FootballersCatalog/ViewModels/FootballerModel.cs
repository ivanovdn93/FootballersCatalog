using System.Collections.Generic;
using FootballersCatalog.Models;

namespace FootballersCatalog.ViewModels
{
    public class FootballerModel
    {
        public Footballer Footballer { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
