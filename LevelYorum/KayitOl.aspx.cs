using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum
{
    public partial class KayitOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_kayit_Click(object sender, EventArgs e)
        {
            if (tb_kullaniciAdi.Text != "" && tb_isim.Text != "" && tb_soyisim.Text != "" && tb_sifre.Text != "")
            {
                if (dm.VeriKontrol("Kullanicilar", "KullaniciAdi", tb_kullaniciAdi.Text))
                {
                    Kullanicilar k = new Kullanicilar();
                    k.Isim = tb_isim.Text;
                    k.Soyisim = tb_soyisim.Text;
                    k.KullaniciAdi = tb_kullaniciAdi.Text;
                    k.Sifre = tb_sifre.Text;
                    k.Durum = true;
                    k.KullaniciTurID = 3;
                    if (dm.KullaniciEkle(k))
                    {
                        Session["kullanici"] = k;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_basarisiz.Text = "Kayıt İşlemi Gerçekleşmedi";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Kullanıcı Adı Daha Önce Alınmıştır";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Lütfen Kullanıcı Adını Veya İsmini Yazınız";
            }
        }
    }
}