using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentMe.Models
{
    public class RenterBusinessLayer
    {
        public IEnumerable<Renter> Rentals
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Renter> rentals = new List<Renter>();
                using (SqlConnection con = new SqlConnection(connectionString))

                {  
                    SqlCommand cmd = new SqlCommand("spGetAllRentals", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Renter renter = new Renter();

                        renter.BuildNo = rdr["BuildNo"].ToString();
                        renter.FlatNo = rdr["FlatNo"].ToString();
                        renter.FlatType = rdr["FlatType"].ToString();
                        renter.Name = rdr["OwnerName"].ToString();
                        renter.MobileNo = (rdr["MobileNo"].ToString());
                        renter.Email = rdr["Email"].ToString();
                        renter.Rent = Convert.ToInt32(rdr["Rent"]);


                        rentals.Add(renter);

                    }

                }



                return rentals;

            }
        }

        public void AddRentPropertyInfo(Renter rentalinfo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddRentPost", con);
                cmd.CommandType = CommandType.StoredProcedure;

                

                SqlParameter paramBuildNo = new SqlParameter();
                paramBuildNo.ParameterName = "@BulidNo";
                paramBuildNo.Value = rentalinfo.BuildNo;
                cmd.Parameters.Add(paramBuildNo);

                SqlParameter paramFlatNo = new SqlParameter();
                paramFlatNo.ParameterName = "@FlatNo";
                paramFlatNo.Value = rentalinfo.FlatNo;
                cmd.Parameters.Add(paramFlatNo);

                SqlParameter paramFlatType = new SqlParameter();
                paramFlatType.ParameterName = "@FlatType";
                paramFlatType.Value = rentalinfo.FlatType;
                cmd.Parameters.Add(paramFlatType);

                SqlParameter paramRent = new SqlParameter();
                paramRent.ParameterName = "@Rent";
                paramRent.Value = rentalinfo.Rent;
                cmd.Parameters.Add(paramRent);

                SqlParameter paramOwnName = new SqlParameter();
                paramOwnName.ParameterName = "@OwnName";
                paramOwnName.Value = rentalinfo.Name;
                cmd.Parameters.Add(paramOwnName);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = rentalinfo.Email;
                if (rentalinfo.Email == null)
                { paramEmail.Value = " ";}
                
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramMobileNo = new SqlParameter();
                paramMobileNo.ParameterName = "@MobileNo";
                paramMobileNo.Value = rentalinfo.MobileNo;
                cmd.Parameters.Add(paramMobileNo);

                con.Open();
                cmd.ExecuteNonQuery();



            }
        }

        public List<Renter> GetRentPropertyInfo(Tenent t)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Renter> rentals = new List<Renter>();
            using (SqlConnection con = new SqlConnection(connectionString))

            { 
                SqlCommand cmd = new SqlCommand("spGetAllRentals", con);

                cmd.CommandType = CommandType.StoredProcedure;
                
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();





                while (rdr.Read())
                {
                    Renter renter = new Renter();

                    renter.BuildNo = rdr["BuildNo"].ToString();
                    renter.FlatNo = rdr["FlatNo"].ToString();
                    renter.FlatType = rdr["FlatType"].ToString();
                    renter.Name = rdr["OwnerName"].ToString();
                    renter.MobileNo = (rdr["MobileNo"].ToString());
                    renter.Email = rdr["Email"].ToString();
                    renter.Rent = Convert.ToInt32(rdr["Rent"]);
                    //when no search criteria
                    //both search criteria selected
                    //only flat type is selected
                    //only rent is selected


                    //both search criteria selected

                    
                   
                    if (t.Rent !=null && t.PropertyType != null )
                    {
                        if (renter.Rent < Convert.ToInt32(t.Rent) && renter.FlatType == t.PropertyType)
                            rentals.Add(renter);
                    }
                    else
                        if (t.PropertyType   != null)
                         {
                           if (renter.FlatType == t.PropertyType)
                           rentals.Add(renter);
                         }
                       else
                          if (t.Rent != null)
                           {
                            if (renter.Rent < Convert.ToInt32(t.Rent))
                            rentals.Add(renter);
                           }
                         else
                           {
                             rentals.Add(renter);
                           };



                }

                return (rentals);

            }
        }
    }
}