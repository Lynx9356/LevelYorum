<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="YorumListele.aspx.cs" Inherits="LevelYorum.AdminPanel.YorumListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Yorum Listesi</h3>
    <div class="yorumbuton">
        <asp:LinkButton ID="lbtn_tumYorumlar" runat="server" CommandName="tumYorumlar" OnClick="lbtn_tumYorumlar_Click">Tüm Yorumlar</asp:LinkButton>
        <asp:LinkButton ID="lbtn_aktifYorumlar" runat="server" CommandName="aktifYorumlar" OnClick="lbtn_aktifYorumlar_Click">Aktif Yorumlar</asp:LinkButton>
        <asp:LinkButton ID="lbtn_pasifYorumlar" runat="server" CommandName="pasifYorumlar" OnClick="lbtn_pasifYorumlar_Click">Pasif Yorumlar</asp:LinkButton>
    </div>
    <div>
        <asp:ListView ID="lv_yorum" runat="server" Visible="true" OnItemCommand="lv_yorum_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0" border="1">
                    <thead>
                        <tr>
                            <th>Yorum No</th>
                            <th>Kullanıcı Adı</th>
                            <th>Yer Adı</th>
                            <th>İçerik</th>
                            <th>Durum</th>
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
                    <td><%# Eval("KullaniciStr")%></td>
                    <td><%# Eval("YerStr")%></td>
                    <td><%# Eval("Icerik")%></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumDegis" runat="server" CommandName="Degis" CommandArgument='<%# Eval("ID")%>' CssClass="yorumButon"><%# Eval("DurumStr")%></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div>
        <asp:ListView ID="lv_aktifYorum" runat="server" Visible="false" OnItemCommand="lv_yorum_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0" border="1">
                    <thead>
                        <tr>
                            <th>Yorum No</th>
                            <th>Kullanıcı Adı</th>
                            <th>Yer Adı</th>
                            <th>İçerik</th>
                            <th>Durum</th>
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
                    <td><%# Eval("KullaniciStr")%></td>
                    <td><%# Eval("YerStr")%></td>
                    <td><%# Eval("Icerik")%></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumDegis" runat="server" CommandName="Degis" CommandArgument='<%# Eval("ID")%>' CssClass="yorumButon"><%# Eval("DurumStr")%></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div>
        <asp:ListView ID="lv_pasifYorum" runat="server" Visible="false" OnItemCommand="lv_yorum_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0" border="1">
                    <thead>
                        <tr>
                            <th>Yorum No</th>
                            <th>Kullanıcı Adı</th>
                            <th>Yer Adı</th>
                            <th>İçerik</th>
                            <th>Durum</th>
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
                    <td><%# Eval("KullaniciStr")%></td>
                    <td><%# Eval("YerStr")%></td>
                    <td><%# Eval("Icerik")%></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumDegis" runat="server" CommandName="Degis" CommandArgument='<%# Eval("ID")%>' CssClass="yorumButon"><%# Eval("DurumStr")%></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
