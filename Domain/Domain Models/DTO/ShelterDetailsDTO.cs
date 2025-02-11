using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain_Models.DTO
{
    public class ShelterDetailsDTO
    {
        public Shelter Shelter { get; set; } = null!;
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
