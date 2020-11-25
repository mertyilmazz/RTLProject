using RTLProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RTLProject.DTO;
using RTL.Core.DataAccess;
using RTL.Core.Utilities.Results;
using System.Linq;

namespace RTLProject.DataAccess.Abstract
{
    public interface ITvShowDal : IEntityRepository<TvShow>
    {
        List<TvMazeDTO> GetShow();

        List<TvShowMainDTO> GetTvShowWithCast(int page, int pageSize);
    }
}
