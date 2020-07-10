<%@ Page Title="ODS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultipleRecordQueryODS.aspx.cs" Inherits="WebAppFSIS.ExercisePages.MultipleRecordQueryODS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1 style="color: #2D8AD6">Players: Age/Gender</h1>
    </div>

    <div class="row col-md-12" style="margin-left: 165px; width: 1020px;">
        <div class="alert alert-info">
            <blockquote style="font-size: small">
                <strong>About: </strong>Multiple record query using ODS.
            </blockquote>
        </div>
    </div>
    &nbsp;&nbsp;
    <div class="row" style="margin-left: 185px">
        <asp:Literal ID="Literal1" runat="server" Text="Enter Age: "></asp:Literal>
        &nbsp;&nbsp;
        <asp:TextBox ID="AgeArg" runat="server" placeholder="Enter an age"></asp:TextBox>
        <asp:RadioButtonList ID="GenderArg" runat="server">
            <asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
            <asp:ListItem Value="F">Female</asp:ListItem>
        </asp:RadioButtonList>
        &nbsp;&nbsp;
        <asp:Button ID="FetchPlayer" runat="server" Text="Search" OnClick="Fetch_Click" BorderStyle="None" Font-Bold="False" Font-Size="Medium" ForeColor="#2E89D4" />
        <br />
        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        <asp:RangeValidator ID="RequiredAgeAmount" runat="server"
         ErrorMessage="Age must be between 6-14" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="AgeArg"  MaximumValue="14" MinimumValue="6" Type="Integer"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredAge" runat="server" ErrorMessage="Age is required" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="AgeArg"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredGender" runat="server" ErrorMessage="Gender is required" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="GenderArg"></asp:RequiredFieldValidator>
        <br />
        <br />
    </div>
    <div class="row" style="margin-left: 185px">
        <asp:GridView ID="Player_GetByAgeGenderGV" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-striped" GridLines="Horizontal"
            BorderStyle="None" AllowPaging="True" PageSize="5" DataSourceID="Player_GetByAgeGenderODS">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="PlayerID" runat="server"
                            Text='<%# Eval("PlayerID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="FullName" runat="server"
                            Text='<%# Eval("FullName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Team Name">
                    <ItemTemplate>
                        <asp:DropDownList ID="TeamListGV" runat="server"
                            DataSourceID="TeamListODS"
                            DataTextField="TeamName"
                            DataValueField="TeamID"
                            AppendDataBoundItems="true"
                            Enabled="false"
                            SelectedValue='<%# Eval("TeamID") %>'>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No data available at this time.
            </EmptyDataTemplate>
            <PagerSettings Mode="NumericFirstLast" />
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Message" runat="server"></asp:Label>
    </div>
    <asp:ObjectDataSource ID="TeamListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Team_List"
        TypeName="FSISSystem.SBraz.BLL.TeamController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="Player_GetByAgeGenderODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Player_GetByAgeGender"
        TypeName="FSISSystem.SBraz.BLL.PlayerController">

        <SelectParameters>
            <asp:ControlParameter ControlID="AgeArg" PropertyName="Text" DefaultValue="0" Name="age" Type="Int32"></asp:ControlParameter>
            <asp:ControlParameter ControlID="GenderArg" PropertyName="SelectedValue" DefaultValue="M" Name="gender" Type="String"></asp:ControlParameter>

        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
