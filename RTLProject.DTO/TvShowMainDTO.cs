using System;
using System.Collections.Generic;
using System.Text;

namespace RTLProject.DTO
{
    public class TvShowMainDTO
    {
        public TvShowMainDTO()
        {
            Casts = new List<CastMainDTO>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public long Updated { get; set; }

        public IEnumerable<CastMainDTO> Casts { get; set; }
    }
}
