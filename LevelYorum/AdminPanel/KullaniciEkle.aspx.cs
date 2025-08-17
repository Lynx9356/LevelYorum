using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class KullaniciEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kulTur.DataTextField = "Isim";
                ddl_kulTur.DataValueField = "ID";
                ddl_kulTur.DataSource = dm.KullanıcıTurListele();
                ddl_kulTur.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_kulTur.SelectedItem.Value) != 0)
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
                        k.KullaniciTurID = Convert.ToInt32(ddl_kulTur.SelectedItem.Value);
                        if (dm.KullaniciEkle(k))
                        {
                            pnl_basarili.Visible = true;
                            pnl_basarisiz.Visible = false;
                            tb_isim.Text = "";
                            tb_soyisim.Text = "";
                            tb_kullaniciAdi.Text = "";
                            tb_sifre.Text = "";
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_basarisiz.Text = "Kullanıcı Ekleme Başarısız Olmuştur";
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_basarisiz.Text = "Kullanıcı Adı Daha Önce Alınmıştır";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Lütfen Kullanıcı Adını Veya İsmini Yazınız";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Lütfen Kullanıcı Türüni Seçiniz";
            }
        }
    }
}