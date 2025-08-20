<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="LevelYorum.KayitOl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Assets/CSS/KayitOl.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="loginbox">
                <img src="../Foto/LevelYorum.png" alt="Alternate Text" class="loginLogo" />
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_basarisiz" runat="server"></asp:Label>
                </asp:Panel>
                <div style="margin-bottom: 10px" class="isim">
                    <label style="margin-right: 65px">İsim:</label>
                    <asp:TextBox ID="tb_isim" runat="server" />
                </div>
                <div style="margin-bottom: 10px" class="soyIsim">
                    <label style="margin-right: 34px">Soy İsim:</label>
                    <asp:TextBox ID="tb_soyisim" runat="server" />
                </div>
                <div style="margin-bottom: 10px" class="kullaniciAdi">
                    <label>Kullanıcı Adı:</label>
                    <asp:TextBox ID="tb_kullaniciAdi" runat="server" />
                </div>
                <div class="sifre">
                    <label style="margin-right: 62px">Şifre:</label>
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" />
                </div>
                <div class="girisButon">
                    <asp:LinkButton ID="lbtn_kayit" runat="server" OnClick="lbtn_kayit_Click">Kayıt Ol</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
