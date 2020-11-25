using RTL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTLProject.Entities.Concrete
{
    public class TvShow : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }

        public long TimeStamp { get; set; }
        public virtual IEnumerable<Cast> Cast { get; set; }


    }
}
