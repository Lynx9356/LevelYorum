using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum
{
    public partial class DetaySayfasi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["oyunid"]);
                Oyunlar o = dm.OyunGetir(id);
                rptYorumlar.DataSource = dm.YorumListele(true,id);
                rptYorumlar.DataBind();
                lblBaslik.Text = o.Isim;
                imgKapak.ImageUrl = "~/Foto/" + o.Foto;
                lblKategori.Text = dm.TurStr(o.ID);
                lblOzet.Text = o.Ozet;
                lblDetay.Text = o.Detay;
                if (Session["kullanici"] != null)
                {
                    btnYorumEkle.Visible = true;
                    btnGirisYap.Visible = false;
                }
                else
                {
                    btnGirisYap.Visible = true;
                    btnYorumEkle.Visible = false;
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnYorumEkle_Click(object sender, EventArgs e)
        {
            Yorumlar yorum = new Yorumlar();
            Kullanicilar kullanici = (Kullanicilar)Session["kullanici"];
            yorum.KullaniciID = kullanici.ID;
            yorum.OyunID = Convert.ToInt32(Request.QueryString["oyunid"]);
            yorum.Icerik = tbYorum.Text;
            yorum.Durum = true;
            if (dm.YorumEkle(yorum))
            {
                rptYorumlar.DataSource = dm.YorumListele(true, yorum.OyunID);
                rptYorumlar.DataBind();
                tbYorum.Text = "";
            }
        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            Session["link"] = "DetaySayfasi.aspx?oyunID=" + Request.QueryString["oyunid"];
            Response.Redirect("UserLogin.aspx");
        }
    }
}