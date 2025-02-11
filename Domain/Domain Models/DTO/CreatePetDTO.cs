using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain_Models.DTO
{
    public class CreatePetDTO
    {
        
        public Pet Pet { get; set; } = null!;
        public List<Shelter>? Shelters { get; set; }
    }
}
