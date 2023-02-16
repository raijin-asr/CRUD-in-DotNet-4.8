<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReportApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--table--%>
    <asp:Table class="table mt-5" ID="Table1" runat="server" Height="123px" Width="100%" >  
        <asp:TableHeaderRow class="thead-dark">
            <asp:TableHeaderCell ID="id" >ID</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="name">Name</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="college">College</asp:TableHeaderCell>
        </asp:TableHeaderRow>

</asp:Table>

<br />
<br />
<div class="form" runat="server">
    <%--<form id="form_Insert" runat="server">--%>
        <asp:Label runat="server">Id:</asp:Label>
        <asp:TextBox ID="txtId" runat="server" ></asp:TextBox>

        <asp:Label runat="server"> Name:</asp:Label>
        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>

        <asp:Label  runat="server">Address:</asp:Label>
        <asp:TextBox ID="txtCollege" runat="server"></asp:TextBox>

        <%--<button id="Button1" class="btn btn-primary" onclick="(() => insertData(id_Crud,name_Crud,college_Crud))" runat="server">Insert</button>--%>
        <%--<button id="Button1" class="btn btn-primary" onclick="Button1_Click" runat="server">Insert</button>--%>
        <%--<asp:Button ID="btnInsertion" runat="server" Text="Insert" OnClick="(() => insertData(id_Crud,name_Crud,college_Crud))" />--%> 
        <asp:Button ID="Insert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="Insert_Click"/>
        <%--</form>--%>
        <br/><asp:Label id="Label1" runat="server"></asp:Label>

</div>

</asp:Content>
