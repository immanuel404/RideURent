<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="cldvPoeFinal.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="jumbotron">
        <h1>RIDE-YOU-RENT WEBSITE</h1>
        <p class="lead">The car rental application was developed with ASP.NET, and has full CRUD functionality and authentication features.</p>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Car Information</h2>
            <p>
                <a class="btn btn-default" href="/Cars">Car Info &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Driver Information</h2>
            <p>
                <a class="btn btn-default" href="/Driver">Driver Info &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Inspector Information</h2>
            <p>
                <a class="btn btn-default" href="/Inspector">Inspector Info &raquo;</a>
            </p>
        </div>
         <div class="col-md-4">
            <h2>Rental Information</h2>
            <p>
                <a class="btn btn-default" href="/Rental">Rental Info &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Returns Information</h2>
            <p>
                <a class="btn btn-default" href="/Returns">Returns Info &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
