<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LevelYorum.AdminPanel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Son Eklenen Oyunlar</h3>
    <asp:Repeater ID="rpt_SonOyunlar" runat="server">
        <ItemTemplate>
            <div class="adminRepeater"><%# Eval("Isim") %></div>
        </ItemTemplate>
    </asp:Repeater>

    <h3>Son Eklenen Kullanıcılar</h3>
    <asp:Repeater ID="rpt_SonKullanicilar" runat="server">
        <ItemTemplate>
            <div class="adminRepeater"><%# Eval("KullaniciAdi") %> - <%# Eval("Isim") %> <%# Eval("Soyisim") %></div>
        </ItemTemplate>
    </asp:Repeater>

    <h3>Son Eklenen Yorumlar</h3>
    <asp:Repeater ID="rpt_SonYorumlar" runat="server">
        <ItemTemplate>
            <div class="adminRepeater">
                <b><%# Eval("KullaniciStr") %></b> (<%# Eval("OyunStr") %>): <%# Eval("Icerik") %>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
