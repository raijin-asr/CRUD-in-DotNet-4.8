<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="ReportApp.EditStudent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Student</title>
</head>
<body>
<%--    <form id="form1" runat="server">--%>
        <div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblId" runat="server" Text="ID: "></asp:Label>
            <asp:Label ID="lblStudentId" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    <%--</form>--%>
</body>
</html>
</asp:Content>
