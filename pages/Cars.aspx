<%@ Page Title="Cars Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="cldvPoeFinal.crudCars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div id="carForm" class="row g-3">
            <div class="col-md-6">
                <h3>EDIT CAR DETAILS</h3>
                <asp:Label ID="lblCarNo2" class="col-sm-4 col-form-label" runat="server" Text="Car No: "></asp:Label>
                <asp:Label ID="lblCarID2" class="col-sm-4 col-form-label" runat="server" Text=""></asp:Label><br /><br />

                <asp:Label ID="lblCarMake2" class="col-sm-4 col-form-label" runat="server" Text="Car Make: "></asp:Label>
                <asp:DropDownList ID="cmbCarMake2" runat="server"></asp:DropDownList><br /><br />

                <asp:Label ID="lblCarModel2" class="col-sm-4 col-form-label" runat="server" Text="Car Model: "></asp:Label>
                <asp:TextBox ID="txtCarModel2" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblCarBodyType2" class="col-sm-4 col-form-label" runat="server" Text="Car Body-Type: "></asp:Label>
                <asp:DropDownList ID="cmbCarBodyType2" runat="server"></asp:DropDownList><br /><br />

                <asp:Label ID="lblkiloTravelled2" class="col-sm-4 col-form-label" runat="server" Text="Kilometers Travelled: "></asp:Label>
                <asp:TextBox ID="txtKiloTravelled2" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblServicekilo2" class="col-sm-4 col-form-label" runat="server" Text="Service Kilometers: "></asp:Label>
                <asp:TextBox ID="txtServiceKilo2" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblAvailable2" class="col-sm-4 col-form-label" runat="server" Text="Available: "></asp:Label>
                <asp:TextBox ID="txtAvailable2" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="btnUpdateCar" runat="server" Text="UPDATE" OnClick="btnUpdateCar_Click"/>
                <asp:Button ID="btnDeleteCar" runat="server" Text="DELETE" OnClick="btnDeleteCar_Click"/>
                <br /><br /><asp:Label ID="lblCarMessage2" runat="server" Text=""></asp:Label>
             </div>

            <div class="col-md-6">
                <h3>ADD CAR DETAILS</h3>
                <asp:Label ID="lblCarNo" class="col-sm-3 col-form-label" runat="server" Text="Car No: "></asp:Label>
                <asp:TextBox ID="txtCarNo" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblCarMake" class="col-sm-3 col-form-label" runat="server" Text="Car Make: "></asp:Label>
                <asp:DropDownList ID="cmbCarMake" runat="server"></asp:DropDownList><br /><br />

                <asp:Label ID="lblCarModel" class="col-sm-3 col-form-label" runat="server" Text="Car Model: "></asp:Label>
                <asp:TextBox ID="txtCarModel" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblCarBodyType" class="col-sm-3 col-form-label" runat="server" Text="Car Body-Type: "></asp:Label>
                <asp:DropDownList ID="cmbCarBodyType" runat="server"></asp:DropDownList><br /><br />

                <asp:Label ID="lblKiloTravelled" class="col-sm-3 col-form-label" runat="server" Text="Kilometers Travelled: "></asp:Label>
                <asp:TextBox ID="txtKiloTravelled" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblServiceKilo" class="col-sm-3 col-form-label" runat="server" Text="Service Kilometers: "></asp:Label>
                <asp:TextBox ID="txtServiceKilo" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblAvailable" class="col-sm-3 col-form-label" runat="server" Text="Available: "></asp:Label>
                <asp:TextBox ID="txtAvailable" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="btnAddCar" runat="server" Text="ADD DETAILS" OnClick="btnAddCar_Click"/>
                <br /><br /><asp:Label ID="lblCarMessage" runat="server" Text=""></asp:Label><br /><br />
            </div>
        </div>

        <div class="container body-content">
            <h3>ALL CARS INFORMATION:</h3>
            <asp:GridView ID="dgvItem" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnGridAction" runat="server" Text="Select Row" CommandArgument='<%# Eval("carNo") %>' OnClick="btnGridAction_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
