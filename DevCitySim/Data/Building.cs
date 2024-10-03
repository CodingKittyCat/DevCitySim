using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCitySim.Data
{
    internal class Building
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}
