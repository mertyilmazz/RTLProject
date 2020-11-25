using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RTLProject.DTO
{
    public class TvMazeDTO
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }      
        public long Updated { get; set; }

        [JsonProperty("_embedded")]
        public Embed Embedded { get; set; }

        public partial class Embed
        {
            public List<Cast> Cast { get; set; }
        }

        public partial class Cast
        {
            public Person Person { get; set; }
        }
        public partial class Person
        {
            public long Id { get; set; }          
            public string Name { get; set; }
            public DateTimeOffset? Birthday { get; set; }          

        }
    }



}
