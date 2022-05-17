using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PptNemocnice.Shared;
public class UkonModel
{
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public Guid VybaveniId { get; set; }
        public Guid? PracovniciId { get; set; }
        public string? PracovniciName { get; set; }
        public DateTime? DateTime { get; set; }
        public double PriceCzk { get; set; }
        public bool OutPutGood { get; set; }
    }

