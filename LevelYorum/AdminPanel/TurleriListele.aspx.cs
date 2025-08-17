using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class TurleriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_tur.DataSource = dm.TurListele();
            lv_tur.DataBind();
        }

        protected void lv_tur_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Degis")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.TurDurumDegis(id);
            }
            lv_tur.DataSource = dm.TurListele();
            lv_tur.DataBind();
        }
    }
}