using Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain_Models
{
    public class Adoption_Application:BaseEntity
    {
       
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
       
        public string? Phone { get; set; }
        
        public string? Email { get; set; }
        
        public string? City { get; set; }
        
        public string ?Country { get; set; }
       

        public Guid? PetId { get; set; }
        public Pet? Pet { get; set; }

       
    }
}
