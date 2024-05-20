<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ReportApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contact</h3>
    <address>
        Ameer S. Rai<br />
        Kathmandu, Nepal<br />
        <abbr title="Phone">Mobile:</abbr>
        9860245***
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@ameer.com</a><br/>
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@ameer.com</a>
    </address>
</asp:Content>
