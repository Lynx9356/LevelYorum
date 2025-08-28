using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class OyunKategorisiEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_oyunlar.DataTextField = "Isim";
                ddl_oyunlar.DataValueField = "ID";
                ddl_oyunlar.DataSource = dm.OyunListele();
                ddl_oyunlar.DataBind();

                ddl_turler.DataTextField = "Isim";
                ddl_turler.DataValueField = "ID";
                ddl_turler.DataSource = dm.TurListele();
                ddl_turler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_oyunlar.SelectedItem.Value) != 0)
            {
                if (Convert.ToInt32(ddl_turler.SelectedItem.Value) != 0)
                {
                    if (dm.OyunKategoriVeriKontrol("Kategoriler", "OyunID", "TurID", Convert.ToInt32(ddl_oyunlar.SelectedItem.Value), Convert.ToInt32(ddl_turler.SelectedItem.Value)))
                    {
                        Kategoriler k = new Kategoriler();
                        k.OyunID = Convert.ToInt32(ddl_oyunlar.SelectedItem.Value);
                        k.TurID = Convert.ToInt32(ddl_turler.SelectedItem.Value);
                        if (dm.OyunKategoriEkle(k))
                        {
                            pnl_basarili.Visible = true;
                            pnl_basarisiz.Visible = false;
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_basarisiz.Text = "Oyun Kategori Ekleme Başarısız Olmuştur";
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_basarisiz.Text = "Oyun Kategorisi Daha Önce Alınmıştır";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Lütfen Türünü Seçiniz";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Lütfen Oyunu Seçiniz";
            }
        }
    }
}