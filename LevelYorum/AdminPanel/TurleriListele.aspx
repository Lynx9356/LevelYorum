<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TurleriListele.aspx.cs" Inherits="LevelYorum.AdminPanel.TurleriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Tür Listesi</h3>
    <div>
        <asp:ListView ID="lv_tur" runat="server" OnItemCommand="lv_tur_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0" border="1">
                    <thead>
                        <tr>
                            <th>Tür No</th>
                            <th>Tür Adı</th>
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
                    <td><%# Eval("DurumStr")%></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumDegis" runat="server" CommandName="Degis" CommandArgument='<%# Eval("ID")%>' CssClass="DegisButon">Durum Değiştir</asp:LinkButton>
                        <a href='TurDüzenle.aspx?turid=<%# Eval("ID")%>'>Düzenle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
