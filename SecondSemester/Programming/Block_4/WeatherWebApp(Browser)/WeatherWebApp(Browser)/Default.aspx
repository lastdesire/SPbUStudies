<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Async="true" CodeBehind="Default.aspx.cs" Inherits="WeatherWebApp_Browser_._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>
            <asp:Timer ID="Timer1" runat="server" Interval="300000">
            </asp:Timer>
            Weather in Saint Petersburg</h1>
        A little simplified version<br />
    <asp:Label ID="errorLabel" runat="server" Text=" "></asp:Label></div>
<h2>
    <asp:Label ID="averageTemp" runat="server" Text="AverageTemp"></asp:Label><br />
    <h3> </h3>
    <asp:Label ID="windSpeed" runat="server" Text="WindSpeed"></asp:Label><br />
    <asp:Label ID="direction" runat="server" Text="Direction"></asp:Label><br />
    <h3> </h3>
    <asp:Label ID="Label7" runat="server" Text="Last update"></asp:Label><br />
    <asp:Label ID="localtime" runat="server" Text="Localtime"></asp:Label><br />
    <h3> </h3>
    <asp:Label ID="regressionResult" runat="server" Text="RegressionResult"></asp:Label><br />
    <asp:Label ID="regression" runat="server" Text="Regression"></asp:Label>
    <h3> 
        <asp:Image ID="Image2" runat="server" />
    </h3>
    <asp:Panel ID="Panel2" runat="server" Height="287px" Width="400px">
    </asp:Panel>
    &nbsp;</h2>

<asp:Panel ID="Panel1" runat="server" Height="67px" Width="798px">
    
    <h2><asp:Label ID="weatherMain" runat="server" Text="WeatherMain"></asp:Label>
    <asp:Label ID="weatherDescription" runat="server" Text="WeatherDescription"></asp:Label><br /></h2>
</asp:Panel>

</asp:Content>
