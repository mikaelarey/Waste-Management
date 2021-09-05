using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WasteManagement.BusinessLogic
{
    public class Personnels
    {
        WasteManagement.Database.Personnels _data;

        public Personnels()
        {
            _data = new Database.Personnels();
        }

        public bool InsertPersonnel(WasteManagement.Models.Personnels p)
        {
            return _data.InsertPersonnel(p);
        }

        public bool DeletePersonnel(WasteManagement.Models.Personnels p)
        {
            return _data.DeletePersonnel(p);
        }

        public bool UpdatePersonnel(WasteManagement.Models.Personnels p)
        {
            return _data.UpdatePersonnel(p);
        }

        public List<Models.Personnels> GetAllPersonnels()
        {
            DataTable dt = _data.GetAllPersonnels();
            List<Models.Personnels> personnels = new List<Models.Personnels>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Models.Personnels p = new Models.Personnels()
                    {
                        PersonnelID = Convert.ToInt32(item["PersonnelID"]),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        ContactNumber = item["ContactNumber"].ToString()
                    };

                    personnels.Add(p);
                }
            }

            return personnels;
        }
    }
}