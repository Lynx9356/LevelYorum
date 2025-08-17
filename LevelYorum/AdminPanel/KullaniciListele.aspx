<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="KullaniciListele.aspx.cs" Inherits="LevelYorum.AdminPanel.KullaniciListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Kullanıcı Listesi</h3>
    <div>
        <asp:ListView ID="lv_kullanici" runat="server" OnItemCommand="lv_kullanici_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0" border="1">
                    <thead>
                        <tr>
                            <th>Kullanıcı No</th>
                            <th>Kullanıcı Adı</th>
                            <th>Kullanıcı Soyadı</th>
                            <th>Kullanıcı NickName</th>
                            <th>Kullanıcı Şifre</th>
                            <th>Kullanıcı Türü</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID")%></td>
                    <td><%# Eval("Isim")%></td>
                    <td><%# Eval("Soyisim")%></td>
                    <td><%# Eval("KullaniciAdi")%></td>
                    <td><%# Eval("Sifre")%></td>
                    <td><%# Eval("KullaniciTurStr")%></td>
                    <td><%# Eval("DurumStr")%></td>
                    <td style="padding: 10px">
                        <asp:LinkButton ID="lbtn_durumDegis" runat="server" CommandName="Degis" CommandArgument='<%# Eval("ID")%>' CssClass="DegisButon">Durum Değiştir</asp:LinkButton>
                        <a href='KullaniciDüzenle.aspx?kullaniciid=<%# Eval("ID")%>'>Düzenle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
