using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WasteManagement.Database
{
    public class Locations
    {
        GeneralFunctions _general;

        public Locations()
        {
            _general = new GeneralFunctions();
        }

        public DataTable GetAllLocations()
        {
            try
            {
                var dtData = new DataTable();

                using (var Connection = new SqlConnection())
                {
                    Connection.ConnectionString = _general.ConnectionString;
                    Connection.Open();

                    using (var Command = new SqlCommand())
                    {
                        Command.Connection = Connection;
                        Command.CommandText = "GetAllLocations";
                        Command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(Command))
                        {
                            adapter.Fill(dtData);
                        }
                    }
                }

                return dtData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}