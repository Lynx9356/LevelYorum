<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OyunKategorisiEkle.aspx.cs" Inherits="LevelYorum.AdminPanel.OyunKategorisiEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 style="margin: 30px 270px 0 0">Oyun Kategori Ekle</h3>
        <div>
            <div>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                    Oyun Kategori Ekleme Başarılı
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_basarisiz" runat="server"></asp:Label>
                </asp:Panel>
            </div>
            <div style="float: left; margin: 50px 0 0 250px">
                <label>Oyunlar</label>
                <asp:DropDownList ID="ddl_oyunlar" runat="server" CssClass="inputBox" AppendDataBoundItems="true">
                    <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <div style="float: right; margin: 0 0 0 200px">
                    <label>Türler</label>
                    <asp:DropDownList ID="ddl_turler" runat="server" CssClass="inputBox" AppendDataBoundItems="true">
                        <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="text-align: center; width: 50%; margin: 50px 0 0 120px">
                    <asp:LinkButton ID="lbtn_ekle" Text="Oyun Kategori Ekle" runat="server" CssClass="ekleButon" OnClick="lbtn_ekle_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
