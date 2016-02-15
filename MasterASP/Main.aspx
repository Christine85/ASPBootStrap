<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="MasterASP.WebForm3" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script>
        $('#myTable').on('click', '.clickable-row', function (event) {
            $(this).addClass('active').siblings().removeClass('active');
        });
    </script>
    <div>
        <asp:Literal ID="LiteralMain" runat="server"></asp:Literal>
    </div>
    <br />
    <asp:ListBox ID="lBoxContacts" runat="server" Height="325px" Width="197px" OnSelectedIndexChanged="lBoxContacts_SelectedIndexChanged"></asp:ListBox>
</asp:Content>



