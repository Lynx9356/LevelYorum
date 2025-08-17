using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class TurDüzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["turid"]);
                    Turler t = dm.TurGetir(id);
                    if (t != null && t.Isim != null)
                    {
                        tb_isim.Text = t.Isim;
                        cb_durum.Checked = t.Durum;
                    }
                    else
                    {
                        Response.Redirect("TurleriListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("TurleriListele.aspx");
            }
        }
        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                int id = Convert.ToInt32(Request.QueryString["turid"]);
                Turler t = dm.TurGetir(id);
                t.Isim = tb_isim.Text.Trim();
                t.Durum = cb_durum.Checked;
                if (dm.TurleriGuncelle(t))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_isim.Text = "";
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Tür Ekleme Başarısız Olmuştur";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Tür İsmi Boş Bırakılamaz";
            }
        }
    }
}