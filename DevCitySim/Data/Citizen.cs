
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCitySim.Data
{
    internal class Citizen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Job {  get; set; }
        public ICollection<CitizenBuilding> CitizenBuildings { get; set; }
    }
}
