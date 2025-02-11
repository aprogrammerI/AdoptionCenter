using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain_Models.DTO
{
    public class AdoptionDTO
    {

        public Adoption_Application ?AdoptionApplication { get; set; }
        public List<Pet> ?AvailablePets { get; set; }
    }
}
