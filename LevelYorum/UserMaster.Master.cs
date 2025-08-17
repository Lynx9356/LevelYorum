using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum
{
    public partial class UserMaster : System.Web.UI.MasterPage
    { DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullanici"] != null)
            {
                pnl_girisYok.Visible = false;
                pnl_girisVar.Visible = true;
                Kullanicilar k = (Kullanicilar)Session["kullanici"];
                lbl_kullaniciadi.Text = k.KullaniciAdi + " " + "||" + " " + k.KullaniciTurStr;
            }
            else
            {
                pnl_girisYok.Visible = true;
                pnl_girisVar.Visible = false;
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {

        }

        protected void lbtn_aksiyon_Click(object sender, EventArgs e)
        {

        }

        protected void lbtn_strateji_Click(object sender, EventArgs e)
        {

        }

        protected void lbtn_simulasyon_Click(object sender, EventArgs e)
        {

        }

        protected void lbtn_rolYapma_Click(object sender, EventArgs e)
        {

        }
    }
}