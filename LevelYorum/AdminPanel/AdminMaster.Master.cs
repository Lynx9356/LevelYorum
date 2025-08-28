using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullanici"] != null)
            {
                Kullanicilar k = (Kullanicilar)Session["kullanici"];
                lbl_kullaniciadi.Text = k.KullaniciAdi + " " + "||" + " " + k.KullaniciTurStr;
                if (k.KullaniciTurID == 1)
                {
                    pnl_adminicin.Visible = true;
                }
            }
            else
            {
                Response.Redirect("AdminPanelLogin.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["kullanici"] = null;
            Response.Redirect("../Default.aspx");
        }
    }
}