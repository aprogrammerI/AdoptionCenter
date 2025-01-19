using Domain.Domain_Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implemetation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
    }
}
