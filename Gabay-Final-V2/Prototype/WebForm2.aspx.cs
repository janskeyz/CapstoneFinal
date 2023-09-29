﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gabay_Final_V2.Prototype
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string message = "Department added successfully.";
            string script = $@"<script>document.querySelector('.modal-body').innerHTML = '{message}';</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script);

            string openModalScript = @"<script>$('#myModal').modal('show');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenModal", openModalScript);

        }
    }
}