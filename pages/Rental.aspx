<%@ Page Title="Rental Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableSessionState="ReadOnly" CodeBehind="Rental.aspx.cs" Inherits="cldvPoeFinal.crRental" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div id="RentalForm" class="row g-3">
            <div class="col-md-6">
                <h3>ADD RENTAL DETAILS</h3>
                <asp:Label ID="lblCarNo" class="col-sm-3 col-form-label" runat="server" Text="Car No: "></asp:Label>
                <asp:DropDownList ID="cmbCarNo" runat="server"></asp:DropDownList><br /><br />

                <asp:Label ID="lblInspectorName" class="col-sm-3 col-form-label" runat="server" Text="Inspector Name: "></asp:Label>
                <asp:DropDownList ID="cmbInspectorName" runat="server"></asp:DropDownList><br /><br />

                <asp:Label ID="lblDriverName" class="col-sm-3 col-form-label" runat="server" Text="Driver Name: "></asp:Label>
                <asp:DropDownList ID="cmbDriverName" runat="server"></asp:DropDownList><br /><br />

                <asp:Label ID="lblRentalFee" class="col-sm-3 col-form-label" runat="server" Text="Rental Fee: "></asp:Label>
                <asp:TextBox ID="txtRentalFee" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblStartDate" class="col-sm-3 col-form-label" runat="server" Text="Start Date: "></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" placeholder="yyyy-dd-mm"></asp:TextBox><br /><br />

                <asp:Label ID="lblEndDate" class="col-sm-3 col-form-label" runat="server" Text="End Date: "></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server" placeholder="yyyy-dd-mm"></asp:TextBox><br /><br />

                <asp:Button ID="btnAddRental" runat="server" Text="SUBMIT" OnClick="btnAddRental_Click"/>
                <br /><br /><asp:Label ID="lblRentalMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div class="container body-content">
            <h3>NEWLY ADDED RENTALS:</h3>
            <asp:GridView ID="dgvItem" runat="server" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
</asp:Content>
