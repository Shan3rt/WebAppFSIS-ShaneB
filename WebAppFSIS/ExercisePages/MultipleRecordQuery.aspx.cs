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
    public partial class MultipleRecordQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BindTeamList();
            }
        }

        protected void BindTeamList()
        {
            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> info = null;
                info = sysmgr.Team_List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeamList.Text))
            {
                MessageLabel.Text = "No team selected";
            }
            else
            {
                int teamid = 0;
                if (int.TryParse(TeamList.Text, out teamid))
                {
                    if (teamid > 0)
                    {
                        TeamController sysmgr = new TeamController();
                        Team info = null;
                        info = sysmgr.Teams_FindByID(teamid);
                        if (info == null)
                        {
                            MessageLabel.Text = "Team not found.";
                            Coach.Text = "";
                            AssistantCoach.Text = "";
                            Wins.Text = "";
                            Losses.Text = "";
                        }
                        else
                        {
                            Coach.Text = info.Coach.ToString();
                            AssistantCoach.Text = info.AssistantCoach.ToString();
                            if (info.Wins == null)
                            {
                                Wins.Text = "0";
                            }
                            else
                            {
                                Wins.Text = info.Wins.ToString();
                            }
                            if (info.Losses == null)
                            {
                                Losses.Text = "0";
                            }
                            else
                            {
                                Losses.Text = info.Losses.ToString();
                            }
                        }

                        //}
                        //catch(Exception ex)
                        //{
                        //    MessageLabel.Text = ex.Message;
                        //}
                    }
                    else
                    {
                        MessageLabel.Text = "Team id must be greater than 0";
                    }

                }
                else
                {
                    MessageLabel.Text = "Team id must be a number.";
                }
            }
            if (TeamList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Please select a team";
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    List<Player> info = null;
                    info = sysmgr.Player_GetByTeam(int.Parse(TeamList.SelectedValue));
                    info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                    PlayerList.DataSource = info;
                    PlayerList.DataBind();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void PlayerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PlayerList.PageIndex = e.NewPageIndex;
            Fetch_Click(sender, new EventArgs());
        }

        protected void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = PlayerList.Rows[PlayerList.SelectedIndex];
            string teamid = (agvrow.FindControl("TeamID") as Label).Text;
            //Response.Redirect("ReceivingPage.aspx?pid=" + teamid);
        }
    }
}