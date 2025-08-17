using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class KullaniciListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kullanici.DataSource = dm.KullaniciListele();
            lv_kullanici.DataBind();
        }

        protected void lv_kullanici_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Degis")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.KullaniciDurumDegis(id);
            }
            lv_kullanici.DataSource = dm.KullaniciListele();
            lv_kullanici.DataBind();
        }
    }
}