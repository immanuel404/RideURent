<%@ Page Title="Returns Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableSessionState="ReadOnly" CodeBehind="Returns.aspx.cs" Inherits="cldvPoeFinal.crReturns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <div id="ReturnsForm" class="row g-3">
        <div class="col-md-6">
            <h3>ADD RETURNS</h3>
            <asp:Label ID="lblCarNo" class="col-sm-3 col-form-label" runat="server" Text="Car No: "></asp:Label>
            <asp:DropDownList ID="cmbCarNo" runat="server"></asp:DropDownList><br /><br />

            <asp:Label ID="lblInspectorName" class="col-sm-3 col-form-label" runat="server" Text="Inspector Name: "></asp:Label>
            <asp:DropDownList ID="cmbInspectorName" runat="server"></asp:DropDownList><br /><br />

            <asp:Label ID="lblDriverName" class="col-sm-3 col-form-label" runat="server" Text="Driver Name: "></asp:Label>
            <asp:DropDownList ID="cmbDriverName" runat="server"></asp:DropDownList><br /><br />

            <asp:Label ID="lblReturnDate" class="col-sm-3 col-form-label" runat="server" Text="Return Date: "></asp:Label>
            <asp:TextBox ID="txtReturnDate" runat="server" placeholder="yyyy-dd-mm"></asp:TextBox><br /><br />

            <asp:Label ID="lblElapsedDate" class="col-sm-3 col-form-label" runat="server" Text="Elapsed Date: "></asp:Label>
            <asp:TextBox ID="txtElapsedDate" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnAddReturns" runat="server" Text="SUBMIT" OnClick="btnAddReturns_Click"/>
            <br /><br /><asp:Label ID="lblReturnsMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="container body-content">
        <h3>ALL RETURNS:</h3>
        <asp:GridView ID="dgvItem" runat="server" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:Button ID="btnCalculateFee" runat="server" Text="CALCULATE PENALTY FEES" OnClick="btnCalculateFee_Click"/>
    </div>
</asp:Content>