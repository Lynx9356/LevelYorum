<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="KullaniciDüzenle.aspx.cs" Inherits="LevelYorum.AdminPanel.KullaniciDüzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 style="margin: 30px 270px 0 0">Kullanıcı Düzenleme</h3>
        <div>
            <div>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                    Kullanıcı Düzenleme Başarılı
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_basarisiz" runat="server"></asp:Label>
                </asp:Panel>
            </div>
            <div style="float: left; width: 50%">
                <div class="row" style="margin: 10px 0 0 115px">
                    <label>İsim</label>
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
                <div class="row" style="margin: 10px 0 0 115px">
                    <label>Soy İsim</label>
                    <asp:TextBox ID="tb_soyisim" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
                <div class="row" style="margin: 10px 0 0 115px">
                    <label>Kullanıcı Adı</label>
                    <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
            </div>
            <div style="float: left; width: 50%">
                <label>Şifre</label>
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <br />
            <div style="margin: 30px 0 0 115px">
                <label>Kullanıcı Türü</label>
                <asp:DropDownList ID="ddl_kulTur" runat="server" CssClass="inputBox" AppendDataBoundItems="true">
                    <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div style="text-align: center; width: 50%; margin: 15px 0 0 165px">
                <asp:LinkButton ID="lbtn_ekle" Text="Kullanıcı Düzenle" runat="server" CssClass="ekleButon" OnClick="lbtn_ekle_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
