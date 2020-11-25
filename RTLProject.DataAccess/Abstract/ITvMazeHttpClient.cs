using RTLProject.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTLProject.DataAccess.Abstract
{
    public interface ITvMazeHttpClient
    {
        Task<TvMazeDTO> GetShowByIdAsync(long showId);
        Task<Dictionary<string, long>> GetShowTimeStampAsync();
    }
}
