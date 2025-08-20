<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LevelYorum.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rpt_oyunlar" runat="server">
        <ItemTemplate>
            <a href="DetaySayfasi.aspx?oyunID=<%# Eval("ID") %>">
                <div class="userPage">
                    <div class="oyun">
                        <img src="../Foto/<%# Eval("Foto") %>" width="200" height="150" />
                        <h3><%# Eval("Isim") %></h3>
                    </div>
                </div>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
