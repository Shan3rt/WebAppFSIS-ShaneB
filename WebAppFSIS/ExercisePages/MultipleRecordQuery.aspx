<%@ Page Title="Code Behind" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultipleRecordQuery.aspx.cs" Inherits="WebAppFSIS.ExercisePages.MultipleRecordQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1 style="color: #2D8AD6">Multiple Record Query - Code Behind</h1>
    </div>
    <div class="row col-md-12">
        <div class="alert alert-info">
            <blockquote style="font-size: small">
                <strong>About: </strong>This page will demonstrate a multiple record query display to a GridView using code behind without using ObjectDataSource controls. The page will demonstrate customization of the GridView covering templates, column selection, column headers, caption (with Bootstrap formatting), dataset member referencing (Eval("")) and paging. The page will demonstrate the implementation of the paging event PageIndexChanging().
            </blockquote>
        </div>
        <div class="row">
            <p style="padding-left: 195px;">
                <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>&nbsp;
        <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>&nbsp;
        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Fetch_Click" BorderStyle="None" Font-Bold="False" Font-Size="Medium" ForeColor="#2E89D4" />
                <br />
                <br />
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
            </p>
            <br />
            <div class="col-md-6">
                <p style="padding-left: 179px;">
                    <br />
                    <asp:Label runat="server" Text="Coach: " Style="margin-left: 61px"></asp:Label>
                    <asp:Label ID="Coach" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Assistant Coach: " Style="margin-left: 0.5px"></asp:Label>
                    <asp:Label ID="AssistantCoach" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Wins: " Style="margin-left: 70.25px"></asp:Label>
                    <asp:Label ID="Wins" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="Losses: " Style="margin-left: 57.35px"></asp:Label>
                    <asp:Label ID="Losses" runat="server"></asp:Label>
                    <br />
                </p>
            </div>
        </div>

        <div class="row">
            <h2 style="background-color: #E9FFFF; font-size: x-large; text-align: center;">Team Roster</h2>
            <asp:GridView ID="PlayerList" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-striped" GridLines="Horizontal"
                BorderStyle="None" AllowPaging="True"
                OnPageIndexChanging="PlayerList_PageIndexChanging" PageSize="5"
                OnSelectedIndexChanged="PlayerList_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="FullName" runat="server"
                                Text='<%# Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Age">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="Age" runat="server"
                                Text='<%# Eval("Age") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="Gender" runat="server"
                                Text='<%# Eval("Gender").ToString() == "M" ? "Male" : "Female" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Med Alert">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label ID="MedicalAlertDetails" runat="server"
                                Text='<%# Eval("MedicalAlertDetails") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data available at this time.
                </EmptyDataTemplate>
                <PagerSettings Mode="NumericFirstLast" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
