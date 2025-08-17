<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OyunEkle.aspx.cs" Inherits="LevelYorum.AdminPanel.OyunEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3 style="margin: 30px 270px 0 0">Oyun Ekle</h3>
        <div>
            <div>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                    Oyun Ekleme Başarılı
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_basarisiz" runat="server"></asp:Label>
                </asp:Panel>
            </div>
            <div style="float: left; width: 50%">
                <div class="row" style="margin: 10px 0 0 115px">
                    <label>İsim</label>
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="inputBox"></asp:TextBox>
                    <div style="margin: 30px 0 0 0">
                        <label>Detay</label>
                        <asp:TextBox ID="tb_detay" runat="server" CssClass="inputBox" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 50%">
                <label>Özet</label>
                <asp:TextBox ID="tb_özet" runat="server" CssClass="inputBox" TextMode="MultiLine"></asp:TextBox>
                <div style="margin: 30px 0 0 0">
                    <label>Resim</label>
                    <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
            </div>
            <br />
            <br />
            <div style="text-align: center; width: 50%; margin: 100px 0 0 165px">
                <asp:LinkButton ID="lbtn_ekle" Text="Oyun Ekle" runat="server" CssClass="ekleButon" OnClick="lbtn_ekle_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
