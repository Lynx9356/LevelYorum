using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class KullaniciDüzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_kulTur.DataTextField = "Isim";
                    ddl_kulTur.DataValueField = "ID";
                    ddl_kulTur.DataSource = dm.KullanıcıTurListele();
                    ddl_kulTur.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["kullaniciid"]);
                    Kullanicilar k = dm.KullaniciGetir(id);
                    tb_isim.Text = k.Isim;
                    tb_soyisim.Text = k.Soyisim;
                    tb_kullaniciAdi.Text = k.KullaniciAdi;
                    tb_sifre.Text = k.Sifre;
                    ddl_kulTur.SelectedValue = k.KullaniciTurID.ToString();
                }
            }
            else
            {
                Response.Redirect("KullaniciListele.aspx");
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kullaniciid"]);
            Kullanicilar k = dm.KullaniciGetir(id);
            k.Isim = tb_isim.Text;
            k.Soyisim = tb_soyisim.Text;
            k.KullaniciAdi = tb_kullaniciAdi.Text;
            k.Sifre = tb_sifre.Text;
            k.KullaniciTurID = Convert.ToInt32(ddl_kulTur.SelectedItem.Value);
            if (dm.KullaniciGuncelle(k))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
                tb_isim.Text = "";
                tb_soyisim.Text = "";
                tb_kullaniciAdi.Text = "";
                tb_sifre.Text = "";
                ddl_kulTur.SelectedValue = "0";
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Kullanıcı Ekleme Başarısız Olmuştur";
            }
        }
    }
}