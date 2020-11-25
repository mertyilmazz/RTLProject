using RTL.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTLProject.Entities.Concrete
{
    public class Cast : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }

        [ForeignKey("TvShow")]
        public long TvShowId { get; set; }
    }
}
