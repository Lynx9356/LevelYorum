<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="LevelYorum.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Assets/CSS/LoginPage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="loginbox">
                <img src="../Foto/LevelYorum.png" alt="Alternate Text" class="loginLogo" />
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_basarisiz" runat="server"></asp:Label>
                </asp:Panel>
                <div style="margin-bottom: 10px" class="kullaniciAdi">
                    <label>Kullanıcı Adı:</label>
                    <asp:TextBox ID="tb_kullaniciAdi" runat="server" />
                </div>
                <div class="sifre">
                    <label style="margin-right: 62px">Şifre:</label>
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" />
                </div>
                <div class="girisButon">
                    <asp:LinkButton ID="lbtn_giris" runat="server" OnClick="lbtn_giris_Click">Giriş Yap</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
