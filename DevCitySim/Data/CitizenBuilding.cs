using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCitySim.Data
{
    class CitizenBuilding
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
