<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCrawler._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Not The Onion</h1>
        <p class="lead">Seriously, we&#39;re not</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <p>
                <asp:TextBox ID="SearchInput" runat="server" Width="1601px"></asp:TextBox>
            </p>
            <asp:RadioButtonList ID="AlgoSelection" runat="server">
                <asp:ListItem Text="KMP" Value="KMP"></asp:ListItem>
                <asp:ListItem Text="Boyer-Moore" Value="Boyer-Moore"></asp:ListItem>
                <asp:ListItem Text="Regex" Value="Regex"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="SearchButton" runat="server" Text="Search" onclick="ButtonClick" Width="120px"/>

            <div>
                <br>
                <asp:Label ID="contentHasilPencarian" runat="server"></asp:Label>
            </div>
            <span runat="server" id="changed_text" />
        </div>
    </div>

    </span>

</asp:Content>
