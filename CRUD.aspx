<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="ReportApp.CRUD" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Management</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }
        table, th, td {
            border: 1px solid black;
        }
        th, td {
            padding: 15px;
            text-align: left;
        }
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <%--<form id="form1" runat="server">--%>
        <div>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody id="studentsTable" runat="server">
                </tbody>
            </table>
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:TextBox ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
            <asp:TextBox ID="txtAddress" runat="server" Placeholder="Address"></asp:TextBox>
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
        </div>
    <%--</form>--%>
</body>
</html>
</asp:Content>



