<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="UpdateContact.aspx.cs" Inherits="MasterASP.WebForm7" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
      <asp:ListBox ID="lBoxContacts" runat="server" Height="199px" Width="128px" AutoPostBack="True" OnSelectedIndexChanged="lBoxContacts_SelectedIndexChanged"></asp:ListBox>
    <br />
    <br />
    <p>Firstname</p>
    <asp:TextBox ID="txtBoxFirstName" runat="server"></asp:TextBox>
    <p>Lastname</p>
    <asp:TextBox ID="txtBoxLastName" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>
