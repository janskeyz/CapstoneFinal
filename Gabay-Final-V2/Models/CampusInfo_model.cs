﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Gabay_Final_V2.Models
{
    public class CampusInfo_model
    {
        private string connStr = ConfigurationManager.ConnectionStrings["Gabaydb"].ConnectionString;

        public DataTable GetCampusInformation()
        {
            string query = "SELECT id, Title, Content FROM Campus_Information";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                return dt;
            }
        }

        public bool SaveCampusInformation(string title, string content)
        {
            string query = "INSERT INTO Campus_Information (Title, Content) VALUES (@Title, @Content)";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Content", content);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception)
                {
                    // Handle the exception or log it
                    return false;
                }
            }
        }

        public bool UpdateCampusInformation(int id, string title, string content)
        {
            string query = "UPDATE Campus_Information SET Title = @Title, Content = @Content WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Content", content);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception)
                {
                    // Handle the exception or log it
                    return false;
                }
            }
        }

        public bool DeleteCampusInformation(int id)
        {
            string query = "DELETE FROM Campus_Information WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception)
                {
                    // Handle the exception or log it
                    return false;
                }
            }
        }
    }
}