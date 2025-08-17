using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class TurEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (dm.VeriKontrol("Turler", "Isim", tb_isim.Text.Trim()))
                {
                    Turler t = new Turler();
                    t.Isim = tb_isim.Text.Trim();
                    t.Durum = cb_durum.Checked;
                    if (dm.TurEkle(t))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                        tb_isim.Text = "";
                        cb_durum.Checked = true;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_basarisiz.Text = "Kategori Ekleme Başarısız Olmuştur";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Kategori Daha Önce Eklenmiştir";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Kategori İsmi Boş Bırakılamaz";
            }
        }
    }
}