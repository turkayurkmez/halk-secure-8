<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" ValidateRequest="True" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <asp:TextBox TextMode="MultiLine" ID="TextBoxComment" runat="server" Height="160px" Width="393px"></asp:TextBox><br />
    <asp:Button ID="ButtonAdd" runat="server" Text="Yorum Ekle" OnClick="ButtonAdd_Click" /><br />
    <asp:Label ID="LabelComments" runat="server" Text="..."></asp:Label>
</asp:Content>
