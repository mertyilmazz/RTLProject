using RTL.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTLProject.Entities.Concrete
{
    public class UpdateQueue : IEntity
    {
        public long Id { get; set; }

        public long TimeStamp { get; set; }
    }
}
