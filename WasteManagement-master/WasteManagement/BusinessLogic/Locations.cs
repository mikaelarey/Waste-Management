using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WasteManagement.BusinessLogic
{
    public class Locations
    {
        WasteManagement.Database.Locations _data;

        public Locations()
        {
            _data = new Database.Locations();
        }

        public List<WasteManagement.Models.Locations> GetAllLocations()
        {
            DataTable dt = _data.GetAllLocations();
            List<Models.Locations> locations = new List<Models.Locations>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Models.Locations l = new Models.Locations()
                    {
                        LocationId = Convert.ToInt32(item["LocationId"]),
                        LocationName = item["LocationName"].ToString()
                    };

                    locations.Add(l);
                }
            }

            return locations;
        }
    }
}