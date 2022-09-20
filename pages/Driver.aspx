<%@ Page Title="Driver Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableSessionState="ReadOnly" CodeBehind="Driver.aspx.cs" Inherits="cldvPoeFinal.crudDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div id="DriverForm" class="row g-3">
            <div class="col-md-6">
                <h3>EDIT DRIVER DETAILS</h3>
                <asp:Label ID="lblDriverNo2" class="col-sm-3 col-form-label" runat="server" Text="Driver No: "></asp:Label>
                <asp:Label ID="lblDriverID2" runat="server" Text=""></asp:Label><br /><br />
            
                <asp:Label ID="lblDriverName2" class="col-sm-3 col-form-label" runat="server" Text="Driver Name: "></asp:Label>
                <asp:TextBox ID="txtDriverName2" runat="server"></asp:TextBox><br /><br />
            
                <asp:Label ID="lblDriverEmail2" class="col-sm-3 col-form-label" runat="server" Text="Driver Email: "></asp:Label>
                <asp:TextBox ID="txtDriverEmail2" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblDriverMobile2" class="col-sm-3 col-form-label" runat="server" Text="Driver  Mobile: "></asp:Label>
                <asp:TextBox ID="txtDriverMobile2" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblDriverAddress2" class="col-sm-3 col-form-label" runat="server" Text="Driver  Address: "></asp:Label>
                <asp:TextBox ID="txtDriverAddress2" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="btnUpdateDriver" runat="server" Text="UPDATE" OnClick="btnUpdateDriver_Click"/>
                <asp:Button ID="btnDeleteDriver" runat="server" Text="DELETE" OnClick="btnDeleteDriver_Click"/>
                <br /><br /><asp:Label ID="lblDriverMessage2" runat="server" Text=""></asp:Label>
            </div>

            <div class="col-md-6">
                <h3>ADD DRIVERS DETAILS</h3>
                <asp:Label ID="lblDriverNo" class="col-sm-3 col-form-label" runat="server" Text="Driver No: "></asp:Label>
                <asp:TextBox ID="txtDriverNo" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblDriverName" class="col-sm-3 col-form-label" runat="server" Text="Driver Name: "></asp:Label>
                <asp:TextBox ID="txtDriverName" runat="server"></asp:TextBox><br /><br />
            
                <asp:Label ID="lblDriverEmail" class="col-sm-3 col-form-label" runat="server" Text="Driver Email: "></asp:Label>
                <asp:TextBox ID="txtDriverEmail" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblDriverMobile" class="col-sm-3 col-form-label" runat="server" Text="Driver  Mobile: "></asp:Label>
                <asp:TextBox ID="txtDriverMobile" runat="server"></asp:TextBox><br /><br />
            
                <asp:Label ID="lblDriverAddress" class="col-sm-3 col-form-label" runat="server" Text="Driver  Address: "></asp:Label>
                <asp:TextBox ID="txtDriverAddress" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="btnAddDriver" runat="server" Text="ADD DETAILS" OnClick="btnAddDriver_Click"/>
                <br /><br /><asp:Label ID="lblDriverMessage" runat="server" Text=""></asp:Label><br /><br />
            </div>

            <div class="container body-content">
                <h3>ALL DRIVERS INFORMATION:</h3>
                <asp:GridView ID="dgvItem" runat="server" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridAction" runat="server" Text="Select Row" CommandArgument='<%# Eval("driverNo") %>' OnClick="btnGridAction_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
