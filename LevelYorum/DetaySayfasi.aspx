<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="DetaySayfasi.aspx.cs" Inherits="LevelYorum.DetaySayfasi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detay-container">
        <div class="detay-header">
            <asp:Image ID="imgKapak" runat="server" CssClass="detay-foto" />
            <div>
                <div class="detay-title">
                    <asp:Label ID="lblBaslik" runat="server" />
                </div>
                <span class="detay-kategori">
                    <asp:Label ID="lblKategori" runat="server" />
                </span>
                <div class="detay-ozet">
                    <asp:Label ID="lblOzet" runat="server" />
                </div>
            </div>
        </div>
        <div class="detay-body">
            <h3>Detaylar</h3>
            <p>
                <asp:Label ID="lblDetay" runat="server" />
            </p>
        </div>
        <div class="detay-yorumlar">
            <h3>Yorumlar</h3>
            <asp:Repeater ID="rptYorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorum">
                        <span class="yorum-kullanici"><%# Eval("KullaniciStr") %> (<%# Eval("KullaniciTurStr") %>) </span>: <span><%# Eval("Icerik") %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="yorum-ekle-alan">
                <asp:TextBox ID="tbYorum" runat="server" CssClass="yorum-ekle" TextMode="MultiLine" placeholder="Yorumunuzu yazın..." />
                <asp:Button ID="btnYorumEkle" runat="server" Text="Yorum Ekle" CssClass="yorum-ekle-btn" OnClick="btnYorumEkle_Click" Visible="false" />
                <asp:Button ID="btnGirisYap" runat="server" CssClass="yorum-ekle-btn" Text="Yorum yapmak için giriş yapın" OnClick="btnGirisYap_Click" Visible="true" />
            </div>
        </div>
    </div>
</asp:Content>
