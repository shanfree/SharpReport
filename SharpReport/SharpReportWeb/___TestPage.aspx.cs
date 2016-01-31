using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIRC.Framework.Utility;

namespace SharpReportWeb
{
    public partial class ___TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIDCheck_Click(object sender, EventArgs e)
        {
            try
            {
                //string id = "350102197310310363";
                //string id = "350627197712313019";
                //string msg = "";
                //IdCardCheck.CheckCard(id, out msg);
                //Response.Write(msg);

                string permissionCode = "1000";
                string roleCode = "01001";
                int perCodeNum = int.Parse(permissionCode);
                int roleCodeNum = int.Parse(roleCode);
                if ((perCodeNum & roleCodeNum) == perCodeNum)
                {
                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }


            }
            catch (Exception ex)
            {
                LogEntry.Log.Write(ex.ToString(),"");
                throw ex;
            }
        }
    }
}
