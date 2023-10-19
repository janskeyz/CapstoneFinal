﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Gabay_Final_V2.Views.Modules.Appointment
{
    public partial class Student_Appointment : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["Gabaydb"].ConnectionString;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user_ID"] != null)
                {
                    int userID = Convert.ToInt32(Session["user_ID"]);

                    retrieveStudentInfo(userID);
                }
            }
           
        }

        //Populate textboxes
        public void retrieveStudentInfo(int userID)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.name, s.email, s.contactNumber, s.studentID, s.course_year, d.dept_name
                                 FROM student s
                                 INNER JOIN department d ON s.department_ID = d.ID_dept
                                 WHERE s.user_ID = @userID ";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userID); 
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            FullName.Text = reader["name"].ToString();
                            Email.Text = reader["email"].ToString();
                            ContactN.Text = reader["contactNumber"].ToString();
                            IdNumber.Text = reader["studentID"].ToString();
                            Year.Text = reader["course_year"].ToString();
                            DepartmentDropDown.Text = reader["dept_name"].ToString();
                        }
                    }
                }
            }
        }


        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string fullname = FullName.Text;
            string email = Email.Text;
            string ConNum = ContactN.Text;
            string StudIdNum = IdNumber.Text;
            string CourseYear = Year.Text;
            string DepartmentName = DepartmentDropDown.Text;

            string SchedDate = selectedDateHidden.Text;
            string SchedTime = time.Text;
            string Concern = Message.Text;

            SaveAppointmentDetails(fullname, email, ConNum, StudIdNum, CourseYear, DepartmentName, SchedDate, SchedTime, Concern);
        }

        public void SaveAppointmentDetails(string fullname, string email, string ConNum, 
            string StudIdNum, string CourseYear, string DepartmentName, string SchedDate, 
            string SchedTime, string Concern)
        {
            string statusSched = "pending";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO appointment (deptName, full_name, email, student_ID, course_year,
                                                          contactNumber, appointment_date, appointment_time,
                                                          concern, appointment_status)
                                 VALUES (@DepartmentName, @fullname, @email, @StudIdNum, @CourseYear, @ConNum,
                                         @SchedDate, @SchedTime, @Concern, @statusSched)";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@StudIdNum", StudIdNum);
                    cmd.Parameters.AddWithValue("@CourseYear", CourseYear);
                    cmd.Parameters.AddWithValue("@ConNum", ConNum);

                    cmd.Parameters.AddWithValue("@SchedDate", SchedDate);
                    cmd.Parameters.AddWithValue("@SchedTime", SchedTime);
                    cmd.Parameters.AddWithValue("@Concern", Concern);
                    cmd.Parameters.AddWithValue("@statusSched", statusSched);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}