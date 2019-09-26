using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WiFiValidatorTest
{
    public class DAL
    {
        public bool VerifyTableInDataBase()
        {
            SqlConnection connection = new SqlConnection(new Config().Adress());
            SqlCommand command = new SqlCommand(connection.ToString());
            command.CommandText = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES;";

            command.Connection = connection;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Dispose();
            }

            return true;
        }
        public bool InsertIP()
        {
            string ex = null;
            SqlConnection connection = new SqlConnection(new Config().Adress());
            SqlCommand command = new SqlCommand(connection.ToString());
            command.CommandText = @"INSERT INTO IPS(IP_NUMBER) VALUES (@VALUE)";
            command.Parameters.AddWithValue("@VALUE", new Config().GetWifiIp());

            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                if (exc.Message.Contains("UNIQUE"))
                {
                    ex = exc.ToString();
                }
            }
            finally
            {
                connection.Dispose();
            }

            if (!string.IsNullOrWhiteSpace(ex))
            {
                return false;
            }
            return true;
            
        }
        public List<string> GetIPs()
        {
            string error = null;
            SqlConnection connection = new SqlConnection(new Config().Adress());
            SqlCommand command = new SqlCommand(connection.ToString());
            command.CommandText = @"SELECT * FROM IPS";

            command.Connection = connection;
            List<string> ips = new List<string>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ip = (string)reader["IP_NUMBER"];
                    ips.Add(ip);
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }
            finally
            {
                connection.Dispose();
            }

            return ips;
        }
    }
}
