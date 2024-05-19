<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReportApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table class="table mt-5" ID="Table1" runat="server" Height="123px" Width="100%" style="border:1px solid">  
        <asp:TableHeaderRow class="thead">
            <asp:TableHeaderCell ID="id" >ID</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="name">Name</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="college">College</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="action" ColumnSpan="2" style="text-align:center">Action</asp:TableHeaderCell>
        </asp:TableHeaderRow>
</asp:Table>

   <asp:Placeholder id="forEdit" runat="server"/>

   <asp:Button ID="ads" runat="server" Text="Edit" CssClass="btn btn-primary" data-toggle="modal" data-target="#id_Crud"/>

             <%--   <!-- Modal -->
                <div class="modal fade" id="id_Crud" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Edit Data</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="form form_Edit">
                                    <label for="name">Name</label>
                                    <input id="name_Crud" type="text"  runat="server" placeholder='<%# Eval("name").ToString() %>' /> <br />
                                    <label for="name">College</label>
                                    <input type="text"  id="college_Crud" runat="server" placeholder="col"/> <br />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <a id="closemodal" class="btn" data-dismiss="modal">
                                <asp:Button ID="btn_Update" runat="server" Text="Update" type="button" class="btn btn-primary" /></a>
                            </div>
                        </div>
                    </div>
                </div>--%>
    
<br />

<div class="form form_Insert" runat="server">
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
    <script type="text/javascript" language="javascript"> 
        function myFunction(val) {
            alert("The new value is: " + val);
            textName.Value = val1;
            document.getElementById("id_name"+id).innerHTML = val;
            return val;
        }
        function myFunction1(val2) {
            alert("The new value is: " + val2);
            textCollege.Value = val1;
            document.getElementById("id_college"+id).innerHTML = val2;
            return val2;
        }
    </script>
</asp:Content>
