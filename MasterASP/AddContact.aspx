<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="AddContact.aspx.cs" Inherits="MasterASP.WebForm6" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="max-width: 300px">
    <asp:Literal ID="LiteralInfo" runat="server"></asp:Literal>
        </div>
    <p>Firstname</p>
    <asp:TextBox ID="txtBoxFirstName" runat="server" CssClass="form-control" style="width: 300px"></asp:TextBox>
    <p>Lastname</p>
    <asp:TextBox ID="txtBoxLastName" runat="server" CssClass="form-control" style="width: 300px"></asp:TextBox>
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-default" OnClick="btnAdd_Click" />
</asp:Content>
