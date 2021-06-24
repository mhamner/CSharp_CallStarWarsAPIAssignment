using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_CallStarWarsAPIAssignment.Models
{
    public class StarWarsCharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Allegiance { get; set; }
        public bool IsJedi { get; set; }
        public string IntroducedInTrilogy { get; set; }
    }

}
