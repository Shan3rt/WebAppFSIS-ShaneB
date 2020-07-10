using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region Additional Namespaces
using FSISSystem.BLL;
using FSISSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace WebAppFSIS.ExercisePages
{
    public partial class EntityQueryCRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                BindPlayerList();
                BindGuardianList();
                BindTeamList();
            }
        }

        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }



        #region BIND LISTS
        protected void BindPlayerList()
        {
            try
            {
                PlayerController sysmgr = new PlayerController();
                List<Player> info = null;
                info = sysmgr.Player_List();
                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                PlayerList.DataSource = info;
                PlayerList.DataTextField = nameof(Player.FullName);
                PlayerList.DataValueField = nameof(Player.PlayerID);
                PlayerList.DataBind();
                PlayerList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void BindGuardianList()
        {
            try
            {
                GuardianController sysmgr = new GuardianController();
                List<Guardian> info = null;
                info = sysmgr.Guardian_List();
                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = nameof(Guardian.FullName);
                GuardianList.DataValueField = nameof(Guardian.GuardianID);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "none");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
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
                TeamList.Items.Insert(0, "none");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        #endregion



        protected void Clear_Click(object sender, EventArgs e)
        {
            PlayerID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            Gender.SelectedValue = "M";
            AlbertaHealthCareNumber.Text = "";
            MedicalAlertDetails.Text = "";
            PlayerList.ClearSelection();
            GuardianList.ClearSelection();
            TeamList.ClearSelection();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a player to view details");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    Player info = null;
                    info = sysmgr.Player_Find(int.Parse(PlayerList.SelectedValue));
                    if (info == null)
                    {
                        errormsgs.Add("Player no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        //Clear_Click(sender, e);
                        BindPlayerList();
                    }
                    else
                    {
                        PlayerID.Text = info.PlayerID.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        Age.Text = info.Age.ToString();
                        Gender.SelectedValue = info.Gender.ToString();
                        AlbertaHealthCareNumber.Text = info.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text = info.MedicalAlertDetails == null ? "" : info.MedicalAlertDetails;
                        GuardianList.SelectedValue = info.GuardianID.ToString();
                        TeamList.SelectedValue = info.TeamID.ToString();
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }



        #region Add Player
        protected void AddPlayer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        PlayerController sysmgr = new PlayerController();
                        Player item = new Player();
                        item.GuardianID = int.Parse(GuardianList.SelectedValue);
                        item.TeamID = int.Parse(TeamList.SelectedValue);
                        item.FirstName = FirstName.Text.Trim();
                        item.LastName = LastName.Text.Trim();
                        item.Age = int.Parse(Age.Text);
                        item.Gender = Gender.SelectedValue;
                        item.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text.Trim();
                        item.MedicalAlertDetails = string.IsNullOrEmpty(MedicalAlertDetails.Text) ? null : MedicalAlertDetails.Text;
                        int newPlayerID = sysmgr.Player_Add(item);
                        PlayerID.Text = newPlayerID.ToString();
                        errormsgs.Add("Player has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindPlayerList();
                        PlayerList.SelectedValue = PlayerID.Text;
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }
        #endregion


        #region Update Player
        protected void UpdatePlayer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (TeamList.SelectedIndex == 0)
                {
                    errormsgs.Add("Team is required");
                }

                int playerid = 0;
                if (string.IsNullOrEmpty(PlayerID.Text))
                {
                    errormsgs.Add("Search for a player to update");
                }
                else if (!int.TryParse(PlayerID.Text, out playerid))
                {
                    errormsgs.Add("Player id is invalid");
                }
                else if (playerid < 1)
                {
                    errormsgs.Add("Player id is invalid");
                }

                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        PlayerController sysmgr = new PlayerController();
                        Player item = new Player();
                        item.GuardianID = int.Parse(GuardianList.SelectedValue);
                        item.TeamID = int.Parse(TeamList.SelectedValue);
                        item.FirstName = FirstName.Text.Trim();
                        item.LastName = LastName.Text.Trim();
                        item.Age = int.Parse(Age.Text);
                        item.Gender = Gender.SelectedValue;
                        item.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text.Trim();
                        item.MedicalAlertDetails = string.IsNullOrEmpty(MedicalAlertDetails.Text) ? null : MedicalAlertDetails.Text;
                        int newPlayerID = sysmgr.Player_Add(item);
                        PlayerID.Text = newPlayerID.ToString();
                        errormsgs.Add("Player has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindPlayerList();
                        PlayerList.SelectedValue = PlayerID.Text;

                        int rowsaffected = sysmgr.Player_Update(item);
                        if (rowsaffected > 0)
                        {

                            errormsgs.Add("Player has been updated");
                            LoadMessageDisplay(errormsgs, "alert alert-success");
                            PlayerList.SelectedValue = PlayerID.Text;
                        }
                        else
                        {
                            errormsgs.Add("Player has not been updated. Player was not found");
                            LoadMessageDisplay(errormsgs, "alert alert-info");
                            BindPlayerList();
                        }

                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }
        #endregion


        #region Remove Player

        protected void RemovePlayer_Click(object sender, EventArgs e)
        {
            int playerid = 0;
            if (string.IsNullOrEmpty(PlayerID.Text))
            {
                errormsgs.Add("Search for a player to update");
            }
            else if (!int.TryParse(PlayerID.Text, out playerid))
            {
                errormsgs.Add("Player id is invalid");
            }
            else if (playerid < 1)
            {
                errormsgs.Add("Player id is invalid");
            }

            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    int rowsaffected = sysmgr.Player_Delete(playerid);
                    if (rowsaffected > 0)
                    {

                        errormsgs.Add("Player has been removed");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindPlayerList();
                        PlayerList.SelectedValue = PlayerID.Text;
                    }
                    else
                    {
                        errormsgs.Add("Player has not been removed. Player was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindPlayerList();
                    }

                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        #endregion


        #region Other Code (Left Behind)
        //        item.PlayerID = playerid;
        //                        item.FirstName = FirstName.Text.Trim();
        //                        item.LastName = LastName.Text.Trim();
        //                        //age
        //                        if (GuardianList.SelectedIndex == 0)
        //                        {
        //                            item.GuardianID = 0;
        //                        }
        //                        else
        //                        {
        //                            item.GuardianID = int.Parse(GuardianList.SelectedValue);
        //}
        //                        if (TeamList.SelectedIndex == 0)
        //                        {
        //                            item.TeamID = 0;
        //                        }
        //                        else
        //                        {
        //                            item.TeamID = int.Parse(TeamList.SelectedValue);
        //                        }
        //                        item.Gender =
        //                            string.IsNullOrEmpty(Gender.Text) ? null : Gender.Text;
        //                        item.AlbertaHealthCareNumber =
        //                            string.IsNullOrEmpty(AlbertaHealthCareNumber.Text) ? null : AlbertaHealthCareNumber.Text;
        //                        item.MedicalAlertDetails =
        //                            string.IsNullOrEmpty(MedicalAlertDetails.Text) ? null : MedicalAlertDetails.Text;
        #endregion


    }
}