using RTL.Core.DataAccess;
using RTLProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTLProject.DataAccess.Abstract
{
    public interface IUpdateQueueDal : IEntityRepository<UpdateQueue>
    {
        Task DeleteUpdateQueue(long id);
    }
}
