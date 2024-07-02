<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webapp01._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h2 class="text-center">Student Registration Form </h2>

        <br />
        <hr />
        <br />

        <div>Test 01  </div>
        <div class="row form-group">
            <div class="col-lg-2">
                <label for="regno">Enter Reg No</label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="regno" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
            </div>
        </div>




        <br />
        <hr />
        <br />

        <div class="row form-group">
            <div class="col-lg-2">
                <label for="regno">Reg No</label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="regno1" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-lg-2">
                <label for="name">Name</label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="name" runat="server" CssClass="form-control" Placeholder="Enter your name"></asp:TextBox>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-lg-2">
                <label for="age">Age</label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="age" runat="server" CssClass="form-control" Placeholder="Enter your age"></asp:TextBox>
            </div>
        </div>

        <div class="row form-group">
            <div class="col-lg-2">
                <label for="address">Address</label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="address" runat="server" CssClass="form-control" Placeholder="Enter your Address"></asp:TextBox>
            </div>
        </div>


        <div class="row form-group">
            <div class="col-lg-2">
            </div>
            <div class="col-lg-2">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" />
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" />
            </div>
        </div>





    </div>

</asp:Content>
