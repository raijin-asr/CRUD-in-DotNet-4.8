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
    <%--<form runat="server">--%>
        <asp:Label runat="server">Id:</asp:Label>
        <asp:TextBox ID="txtId" runat="server" ></asp:TextBox>

        <asp:Label runat="server"> Name:</asp:Label>
        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>

        <asp:Label  runat="server">Address:</asp:Label>
        <asp:TextBox ID="txtCollege" runat="server"></asp:TextBox>

        <button class="btn btn-primary" onclick="(() => insertData(id_Crud,name_Crud,college_Crud))" runat="server">Insert</button>
        <%--<asp:Button ID="btnInsertion" runat="server" Text="Insert" OnClick="(() => insertData(id_Crud,name_Crud,college_Crud))" />--%> 
        <%--</form>--%>
</div>

</asp:Content>
