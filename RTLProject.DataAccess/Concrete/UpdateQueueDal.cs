using RTL.Core.DataAccess;
using RTL.DataAccess.Concrete.EntityFramework.Context;
using RTLProject.DataAccess.Abstract;
using RTLProject.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace RTLProject.DataAccess.Concrete
{
    public class UpdateQueueDal : EfEntityRepositoryBase<UpdateQueue, RTLDbContext>, IUpdateQueueDal
    {
        public async Task DeleteUpdateQueue(long id)
        {
            using (var context = new RTLDbContext())
            {
                var data = context.UpdateQueue.Where(f => f.Id == id);
                context.UpdateQueue.RemoveRange(data);
                await context.SaveChangesAsync();
            }
        }
    }
}
