using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WasteManagement.Models
{
    public class Locations
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        
    }

    public class LocationsIndexViewModel
    {
        public List<Locations> Locations { get; set; }
        public Locations Location { get; set; }
    }
}