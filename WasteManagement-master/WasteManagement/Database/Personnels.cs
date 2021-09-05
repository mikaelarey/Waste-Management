using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WasteManagement.Database
{
    public class Personnels
    {
        GeneralFunctions _general;

        public Personnels()
        {
            _general = new GeneralFunctions();
        }

        public bool InsertPersonnel(WasteManagement.Models.Personnels p)
        {
            try
            {
                int IsSuccessful;

                using (var Connection = new SqlConnection())
                {
                    Connection.ConnectionString = _general.ConnectionString;
                    Connection.Open();

                    using (var Command = new SqlCommand())
                    {
                        Command.Connection = Connection;
                        Command.CommandText = "InsertPersonnel";
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@FirstName", p.FirstName);
                        Command.Parameters.AddWithValue("@LastName", p.LastName);
                        Command.Parameters.AddWithValue("@ContactNumber", p.ContactNumber);
                        IsSuccessful = Command.ExecuteNonQuery();
                    }
                }

                return IsSuccessful > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdatePersonnel(WasteManagement.Models.Personnels p)
        {
            try
            {
                int IsSuccessful;

                using (var Connection = new SqlConnection())
                {
                    Connection.ConnectionString = _general.ConnectionString;
                    Connection.Open();

                    using (var Command = new SqlCommand())
                    {
                        Command.Connection = Connection;
                        Command.CommandText = "UpdatePersonnel";
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PersonnelId", p.PersonnelID);
                        Command.Parameters.AddWithValue("@FirstName", p.FirstName);
                        Command.Parameters.AddWithValue("@LastName", p.LastName);
                        Command.Parameters.AddWithValue("@ContactNumber", p.ContactNumber);
                        IsSuccessful = Command.ExecuteNonQuery();
                    }
                }

                return IsSuccessful > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePersonnel(WasteManagement.Models.Personnels p)
        {
            try
            {
                int IsSuccessful;

                using (var Connection = new SqlConnection())
                {
                    Connection.ConnectionString = _general.ConnectionString;
                    Connection.Open();

                    using (var Command = new SqlCommand())
                    {
                        Command.Connection = Connection;
                        Command.CommandText = "DeletePersonnel";
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PersonnelId", p.PersonnelID);
                        IsSuccessful = Command.ExecuteNonQuery();
                    }
                }

                return IsSuccessful > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetAllPersonnels()
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
                        Command.CommandText = "GetAllPersonnels";
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