using Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IShelterService
    {
        List<Shelter> GetShelters();
        Shelter GetShelterById(Guid? id);
        Shelter CreateNewShelter(Shelter shelter);
        Shelter UpdateShelter(Shelter shelter);
        Shelter DeleteShelter(Guid id);
        List<Shelter> GetAvailableShelters();
    }
}
