<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppFSIS.ExercisePages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 style="color: #2D8AD6">Exercises</h1>
        <div class="alert alert-info">
        </div>
    <asp:Label ID="MessageLabel" runat="server" ></asp:Label><br />
    <asp:Button ID="Back" runat="server" Text="Back"/>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Exercise 7 - Multiple Record Query</h2>
            <p>
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/ExercisePages/MultipleRecordQuery">View Ex7 &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Exercise 8 - Multiple Record Query using ODS</h2>
            <p>
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/ExercisePages/MultipleRecordQueryODS">View Ex8 &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Exercise 9/10 - Entity Query DML</h2>
            <p>
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/ExercisePages/EntityQueryDML">View Ex9/10 &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
