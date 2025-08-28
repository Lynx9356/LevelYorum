<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="TurEkle.aspx.cs" Inherits="LevelYorum.AdminPanel.TurEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 style="margin: 30px 270px 0 0">Tür Ekle</h3>
        <div>
            <div>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                    Tür Ekleme Başarılı
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
            </div>
            <div style="margin: 30px 0 0 115px">
                <label>Durum</label>
                <asp:CheckBox ID="cb_durum" Text="Aktif" runat="server" />
            </div>
            <div style="text-align: center; width: 50%; margin: 15px 0 0 165px">
                <asp:LinkButton ID="lbtn_ekle" Text="Tür Ekle" runat="server" CssClass="ekleButon" OnClick="lbtn_ekle_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
