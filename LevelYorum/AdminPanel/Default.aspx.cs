using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Son 5 oyun
                var oyunlar = dm.OyunListele()?.OrderByDescending(x => x.ID).Take(5).ToList();
                rpt_SonOyunlar.DataSource = oyunlar;
                rpt_SonOyunlar.DataBind();

                // Son 5 kullanıcı
                var kullanicilar = dm.KullaniciListele()?.OrderByDescending(x => x.ID).Take(5).ToList();
                rpt_SonKullanicilar.DataSource = kullanicilar;
                rpt_SonKullanicilar.DataBind();

                // Son 5 yorum
                var yorumlar = dm.YorumListele()?.OrderByDescending(x => x.ID).Take(5).ToList();
                rpt_SonYorumlar.DataSource = yorumlar;
                rpt_SonYorumlar.DataBind();
            }
        }
    }
}