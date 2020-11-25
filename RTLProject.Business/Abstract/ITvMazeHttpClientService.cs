using RTL.Core.Utilities.Results;
using RTLProject.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTLProject.Business.Abstract
{
    public interface ITvMazeHttpClientService
    {
        Task<IDataResult<TvMazeDTO>> UpdateTvShows();

        Task<IResult> ShowTimeStampUpdateAndInsert();
    }
}
