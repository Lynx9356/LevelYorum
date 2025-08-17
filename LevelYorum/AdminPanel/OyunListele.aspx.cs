using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class OyunListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_oyunlar.DataSource = dm.OyunListele();
            lv_oyunlar.DataBind();
        }

        protected void lv_oyunlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Degis")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.OyunDurumDegis(id);
            }
            lv_oyunlar.DataSource = dm.OyunListele();
            lv_oyunlar.DataBind();
        }
    }
}