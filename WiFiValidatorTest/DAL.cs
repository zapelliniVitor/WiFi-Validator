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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\WiFiValidator.mdf;Integrated Security=True;Connect Timeout=30");
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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\WiFiValidator.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand(connection.ToString());
            command.CommandText = @"INSERT";

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


    }
}
