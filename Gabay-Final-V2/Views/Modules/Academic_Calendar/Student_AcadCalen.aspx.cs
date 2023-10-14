﻿using Gabay_Final_V2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Gabay_Final_V2.Models.AcadCalen_model;

namespace Gabay_Final_V2.Views.Modules.Academic_Calendar
{
    public partial class Student_AcadCalen : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Gabaydb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindFilesToDropDownList();
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            if (ViewState["SelectedFileId"] != null)
            {
                int fileId = (int)ViewState["SelectedFileId"];

                byte[] fileData = FetchFileDataFromDatabase(fileId);
                string fileName = FetchFileNameFromDatabase(fileId);

                if (fileData != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", $"inline; filename={fileName}");
                    Response.BinaryWrite(fileData);
                    Response.End();
                }
                else
                {
                    DownloadErrorLabel.Text = "File not found.";
                }

                string script = "window.open('" + Request.Url.AbsoluteUri + "', '_blank');";
                ClientScript.RegisterStartupScript(this.GetType(), "openNewTab", script, true);
            }
            else
            {
                DownloadErrorLabel.Text = "Please select a file to preview.";
            }
        }

        private byte[] FetchFileDataFromDatabase(int fileId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT FileData FROM UploadedFiles WHERE FileId = @FileId";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@FileId", fileId);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return (byte[])result;
                    }
                }
            }

            return null;
        }

        private string FetchFileNameFromDatabase(int fileId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT FileName FROM UploadedFiles WHERE Fileid = @Fileid";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Fileid", fileId);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
            }

            return null;
        }


        private void BindFilesToDropDownList()
        {
            AcadCalen_model conn = new AcadCalen_model();
            List<AcadCalen_model.AcademicFile> filesList = conn.FetchFilesDataFromDatabase();
            ddlFiles.Items.Clear(); // Clear existing items

            foreach (AcadCalen_model.AcademicFile file in filesList)
            {
                ListItem item = new ListItem(file.FileName, file.FileId.ToString());
                ddlFiles.Items.Add(item);
            }

            // Set the selected item based on ViewState
            if (ViewState["SelectedFileId"] != null)
            {
                int selectedFileId = (int)ViewState["SelectedFileId"];
                ddlFiles.SelectedValue = selectedFileId.ToString();
            }
        }

        protected void ddlFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcadCalen_model conn = new AcadCalen_model();
            int selectedFileId = int.Parse(ddlFiles.SelectedValue);
            ViewState["SelectedFileId"] = selectedFileId;

            // Debugging statement to display selectedFileId
            DownloadErrorLabel.Text = "Selected File ID: " + selectedFileId;

            // Fetch the selected file's data and update labels or perform other actions
            byte[] selectedFileData = conn.FetchFileDataFromDatabase(selectedFileId);
            if (selectedFileData != null)
            {
                // Update labels or perform other actions
                DownloadErrorLabel.Text = "";
            }
            else
            {
                DownloadErrorLabel.Text = "Selected file data not found.";
            }
        }
    }
}