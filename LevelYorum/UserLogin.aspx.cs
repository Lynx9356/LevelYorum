using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum
{
    public partial class UserLogin : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Kullanicilar k = dm.KullaniciGetir(tb_kullaniciAdi.Text, tb_sifre.Text);
                if (k != null)
                {
                    if (k.Durum)
                    {
                        Session["kullanici"] = k;
                        if (Session["link"] == null)
                        {
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            Response.Redirect(Session["link"].ToString());
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_basarisiz.Text = "Hesabınız Aktif Değildir";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Kullanıcı Bulunamamıştır";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Bilgiler Boş Bırakılamaz";
            }
        }
    }
}