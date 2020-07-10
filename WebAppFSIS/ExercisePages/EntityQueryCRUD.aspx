<%@ Page Title="CRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntityQueryCRUD.aspx.cs" Inherits="WebAppFSIS.ExercisePages.EntityQueryCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1 style="color: #2D8AD6">Entity - CRUD</h1>
    </div>
    <div class="row col-md-12">
        <div class="alert alert-info">
            <blockquote style="font-size: small">
                <strong>About: </strong>This page will demonstrate an Entity - CRUD.
            </blockquote>
        </div>
    </div>
    
    <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server" Display="None"
        ErrorMessage="First Name is required" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="FirstName"> </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredLastName" runat="server" Display="None"
        ErrorMessage="Last Name is required" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="LastName"> </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredAge" runat="server" Display="None"
        ErrorMessage="Age is required" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="Age"> </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredAlbertaHealthCareNumber" runat="server" Display="None"
        ErrorMessage="Alberta Health Care Number is required" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="AlbertaHealthCareNumber"> </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator id="RegularExpressionValidator" runat="server" Display="None"
        ErrorMessage="Alberta Health Care Number first digit must start with 1-9" SetFocusOnError="true" ForeColor="Firebrick"
        ValidationExpression="^[1-9][0-9]{9}$" 
        ControlToValidate="AlbertaHealthCareNumber" />
    <asp:RangeValidator ID="RangeAge" runat="server" Display="None"
        ErrorMessage="Age must be between 6 and 14" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="Age"  MaximumValue="14" MinimumValue="6" Type="Integer"> </asp:RangeValidator>

         <div class="col-md-12">
             <asp:Label ID="Label5" runat="server" Text="Select a Player"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="PlayerList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
             <asp:LinkButton ID="Search" runat="server" Font-Size="X-Large" 
                 OnClick="Search_Click" CausesValidation="false" >Search</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="Clear" runat="server" Font-Size="X-Large" 
                 OnClick="Clear_Click"  CausesValidation="false">Clear</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="AddPlayer" runat="server" Font-Size="X-Large" 
                 OnClick="AddPlayer_Click" >Add</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="UpdatePlayer" runat="server" Font-Size="X-Large" 
                 OnClick="UpdatePlayer_Click" >Update</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="RemovePlayer" runat="server" Font-Size="X-Large" 
                 OnClick="RemovePlayer_Click"  CausesValidation="false"
                  OnClientClick="return confirm('Are you sure you want to remove the player?')">Remove</asp:LinkButton>&nbsp;&nbsp;

             <asp:DataList ID="Message" runat="server">
                <ItemTemplate>
                    <%# Container.DataItem %>
                </ItemTemplate>
             </asp:DataList>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
         HeaderText="Address the following concerns about your entered data." ForeColor="Firebrick"/>
        </div>

        <div class ="col-md-12">
            <fieldset class="form-horizontal">
                <legend>Player Information</legend>

                <asp:Label ID="Label1" runat="server" Text="Player ID"
                     AssociatedControlID="PlayerID"></asp:Label>
                <asp:Label ID="PlayerID" runat="server" ></asp:Label><br />

                    <asp:Label ID="Label6" runat="server" Text="Guardian"
                     AssociatedControlID="GuardianList"></asp:Label>
                <asp:DropDownList ID="GuardianList" runat="server"  Width="350px"></asp:DropDownList><br />
                  
                  <asp:Label ID="Label3" runat="server" Text="Team"
                     AssociatedControlID="TeamList"></asp:Label>
                <asp:DropDownList ID="TeamList" runat="server"  Width="350px"></asp:DropDownList><br />
                  
                  <asp:Label ID="Label2" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" ></asp:TextBox><br />
                
                  <asp:Label ID="Label12" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
                <asp:TextBox ID="LastName" runat="server" ></asp:TextBox><br />
               
                    <asp:Label ID="Label7" runat="server" Text="Age"
                     AssociatedControlID="Age"></asp:Label>
                <asp:TextBox ID="Age" runat="server" ></asp:TextBox><br />

                    <asp:Label ID="Label9" runat="server" Text="Gender"
                     AssociatedControlID="Gender"></asp:Label>
                    <asp:RadioButtonList ID="Gender" runat="server">
            <asp:ListItem Value="M">Male</asp:ListItem>
            <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
                <br />
             
                <asp:Label ID="Label8" runat="server" Text="Alberta Health Care Number"
                     AssociatedControlID="AlbertaHealthCareNumber"></asp:Label>
                <asp:TextBox ID="AlbertaHealthCareNumber" runat="server" ></asp:TextBox><br />

                    <asp:Label ID="Label10" runat="server" Text="Medical Alert Details"
                     AssociatedControlID="MedicalAlertDetails"></asp:Label>
                <asp:TextBox ID="MedicalAlertDetails" runat="server" ></asp:TextBox><br />
            </fieldset>
        </div>
</asp:Content>
