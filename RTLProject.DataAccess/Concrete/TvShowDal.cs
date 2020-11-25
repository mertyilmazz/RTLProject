using Newtonsoft.Json;
using RTLProject.DataAccess.Abstract;
using RTLProject.Entities.Concrete;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RTLProject.DTO;
using RTL.DataAccess.Concrete.EntityFramework.Context;
using RTL.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RTL.Core.Utilities.Results;

namespace RTL.DataAccess.Concrete
{
    public class TvShowDal : EfEntityRepositoryBase<TvShow, RTLDbContext>, ITvShowDal
    {

        public List<TvMazeDTO> GetShow()
        {
            using (var context = new RTLDbContext())
            {
                var data = context.TvShow.Select(t => new TvMazeDTO
                {
                    Id = t.Id,
                    Updated = t.TimeStamp
                }).ToList();
                return data;
            }
        }

        public List<TvShowMainDTO> GetTvShowWithCast(int page, int pageSize)
        {
            using (var context = new RTLDbContext())
            {
                var shows = context.TvShow
                    .Include(t => t.Cast)
                    .Select(t => new TvShowMainDTO()
                    {
                        Id = t.Id,
                        Language = t.Language,
                        Name = t.Name,
                        Status = t.Status,
                        Updated = t.TimeStamp,
                        Casts = t.Cast.Select(c => new CastMainDTO()
                        {
                            Birthday = c.Birthday,
                            Id = c.Id,
                            Name = c.Name
                        }).OrderByDescending(ca => ca.Birthday)
                    }).Skip((page - 1)* pageSize);

                return shows.ToList();
            }
        }

    }
}
