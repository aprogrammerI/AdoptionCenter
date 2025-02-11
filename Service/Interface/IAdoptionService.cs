using Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAdoptionService
    {
        Adoption_Application CreateAdoptionApplication(Adoption_Application application);
        Adoption_Application GetAdoptionApplicationById(Guid? id);
        List<Adoption_Application> GetAdoptionApplications();
        Adoption_Application UpdateAdoptionApplication(Adoption_Application application);
        Adoption_Application DeleteAdoptionApplication(Guid id);
        bool AdoptionApplicationExists(Guid id);
    }
}
