<%@ Page Title="Inspector Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableSessionState="ReadOnly" CodeBehind="Inspector.aspx.cs" Inherits="cldvPoeFinal.crudInspector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div id="InspectorForm" class="row g-3">
            <div class="col-md-6">
                <h3>EDIT INSPECTOR DETAILS</h3>
                <asp:Label ID="lblInspectorNo2" class="col-sm-3 col-form-label" runat="server" Text="Car No: "></asp:Label>
                <asp:Label ID="lblInspectorID2" runat="server" Text=""></asp:Label><br /><br />
            
                <asp:Label ID="lblInspectorName2" class="col-sm-3 col-form-label" runat="server" Text="Inspector Name: "></asp:Label>
                <asp:TextBox ID="txtInspectorName2" runat="server"></asp:TextBox><br /><br />
            
                <asp:Label ID="lblInspectorEmail2" class="col-sm-3 col-form-label" runat="server" Text="Inspector Email: "></asp:Label>
                <asp:TextBox ID="txtInspectorEmail2" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblInspectorMobile2" class="col-sm-3 col-form-label" runat="server" Text="Inspector  Mobile: "></asp:Label>
                <asp:TextBox ID="txtInspectorMobile2" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="btnUpdateInspector" runat="server" Text="UPDATE" OnClick="btnUpdateInspector_Click"/>
                <asp:Button ID="btnDeleteInspector" runat="server" Text="DELETE" OnClick="btnDeleteInspector_Click"/>
                <br /><br /><asp:Label ID="lblInspectorMessage2" runat="server" Text=""></asp:Label>
            </div>

            <div class="col-md-6">
                <h3>ADD INSPECTOR DETAILS</h3>
                <asp:Label ID="lblInspectorNo" class="col-sm-3 col-form-label" runat="server" Text="Inspector No: "></asp:Label>
                <asp:TextBox ID="txtInspectorNo" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblInspectorName" class="col-sm-3 col-form-label" runat="server" Text="Inspector Name: "></asp:Label>
                <asp:TextBox ID="txtInspectorName" runat="server"></asp:TextBox><br /><br />
            
                <asp:Label ID="lblInspectorEmail" class="col-sm-3 col-form-label" runat="server" Text="Inspector Email: "></asp:Label>
                <asp:TextBox ID="txtInspectorEmail" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="lblInspectorMobile" class="col-sm-3 col-form-label" runat="server" Text="Inspector  Mobile: "></asp:Label>
                <asp:TextBox ID="txtInspectorMobile" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="btnAddInspector" runat="server" Text="ADD DETAILS" OnClick="btnAddInspector_Click"/>
                <br /><br /><asp:Label ID="lblInspectorMessage" runat="server" Text=""></asp:Label><br /><br />
            </div>

            <div class="container body-content">
                <h3>All INSPECTOR INFORMATION:</h3>
                <asp:GridView ID="dgvItem" runat="server" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridAction" runat="server" Text="Select Row" CommandArgument='<%# Eval("inspectorNo") %>' OnClick="btnGridAction_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
