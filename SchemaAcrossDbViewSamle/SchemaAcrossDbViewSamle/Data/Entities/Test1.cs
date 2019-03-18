using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchemaAcrossDbViewSamle.Data.Entities
{
    public class Test1
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string QueryTest2Id { get; set; }
    }
}
