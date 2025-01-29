using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain_Models
{
    public class Dog : Pet
    {
        public string? Size { get; set; } 
        public bool IsTrained { get; set; }
    }
}
