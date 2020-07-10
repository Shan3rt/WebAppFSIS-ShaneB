using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region Additional Namespaces
using FSISSystem.BLL;
using FSISSystem.ENTITIES;
#endregion

namespace WebAppFSIS.ExercisePages
{
    public partial class MultipleRecordQueryODS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void Player_GetByAgeGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string msg = "";
            //GridViewRow agvrow = Player_GetByAgeGender.Rows[Player_GetByAgeGender.SelectedIndex];
            //msg = "ID is:" + (agvrow.FindControl("PlayerID") as Label).Text;
            //msg += "Name is:" + (agvrow.FindControl("Name") as Label).Text;
            //msg += "Team is:" + (agvrow.FindControl("Team") as DropDownList).SelectedValue;
            //Message.Text = msg;
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {

        }
    }
}