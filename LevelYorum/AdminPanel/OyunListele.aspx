<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OyunListele.aspx.cs" Inherits="LevelYorum.AdminPanel.OyunListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Oyun Listesi</h3>
    <div>
        <asp:ListView ID="lv_oyunlar" runat="server" OnItemCommand="lv_oyunlar_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0" border="1">
                    <thead>
                        <tr>
                            <th>Oyun Resmi</th>
                            <th>Oyun No</th>
                            <th>Oyun İsmi</th>
                            <th>Oyun Özeti</th>
                            <th>Oyun Kategorileri</th>
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
                    <td>
                        <img src="../Foto/<%# Eval("Foto")%>" alt="Alternate Text" width="50" />
                    </td>
                    <td><%# Eval("ID")%></td>
                    <td><%# Eval("Isim")%></td>
                    <td style="width:200px"><%# Eval("Ozet")%></td>
                    <td><%# Eval("KategoriStr")%></td>
                    <td><%# Eval("DurumStr")%></td>
                    <td style="padding: 10px">
                        <asp:LinkButton ID="lbtn_durumDegis" runat="server" CommandName="Degis" CommandArgument='<%# Eval("ID")%>' CssClass="DegisButon">Durum Değiştir</asp:LinkButton>
                        <a href='OyunDüzenle.aspx?oyunid=<%# Eval("ID")%>'>Düzenle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
