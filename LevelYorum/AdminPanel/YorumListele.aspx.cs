using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class YorumListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListeDoldur();
        }
        public void ListeDoldur()
        {
            lv_yorum.DataSource = dm.YorumListele();
            lv_yorum.DataBind();

            lv_aktifYorum.DataSource = dm.YorumListele(true);
            lv_aktifYorum.DataBind();

            lv_pasifYorum.DataSource = dm.YorumListele(false);
            lv_pasifYorum.DataBind();
        }

        protected void lbtn_tumYorumlar_Click(object sender, EventArgs e)
        {
            lv_yorum.Visible = true;
            lv_aktifYorum.Visible = false;
            lv_pasifYorum.Visible = false;
        }

        protected void lbtn_aktifYorumlar_Click(object sender, EventArgs e)
        {
            lv_yorum.Visible = false;
            lv_aktifYorum.Visible = true;
            lv_pasifYorum.Visible = false;
        }

        protected void lbtn_pasifYorumlar_Click(object sender, EventArgs e)
        {
            lv_yorum.Visible = false;
            lv_aktifYorum.Visible = false;
            lv_pasifYorum.Visible = true;
        }

        protected void lv_yorum_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Degis")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.YorumDurumDegis(id);
            }
            ListeDoldur();
        }
    }
}