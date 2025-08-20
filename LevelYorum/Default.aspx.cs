using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["turID"] != null)
                {
                    int turID = Convert.ToInt32(Request.QueryString["turID"]);
                    rpt_oyunlar.DataSource = dm.OyunListele(turID);
                }
                else
                {
                    rpt_oyunlar.DataSource = dm.OyunListele(true);
                }
                rpt_oyunlar.DataBind();
            }
        }
    }
}