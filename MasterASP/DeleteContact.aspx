<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="DeleteContact.aspx.cs" Inherits="MasterASP.WebForm8" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
     <asp:ListBox ID="lBoxContacts" runat="server" Height="202px" Width="169px" AutoPostBack="True"></asp:ListBox>
    <br />
    <br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
</asp:Content>
