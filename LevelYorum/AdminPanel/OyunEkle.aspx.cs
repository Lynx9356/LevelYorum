using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelYorum.AdminPanel
{
    public partial class OyunEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (tb_isim.Text != "")
            {
                if (dm.VeriKontrol("Oyunlar", "Isim", tb_isim.Text))
                {
                    Oyunlar o = new Oyunlar();
                    o.Isim = tb_isim.Text;
                    o.Ozet = tb_özet.Text;
                    o.Detay = tb_detay.Text;
                    o.Durum = false;
                    if (fu_resim.HasFile)
                    {
                        FileInfo fi = new FileInfo(fu_resim.FileName);
                        if (fi.Extension == ".jpeg" || fi.Extension == ".png" || fi.Extension == ".jpg")
                        {
                            string uzantı = fi.Extension;
                            string isim = Guid.NewGuid().ToString();
                            o.Foto = isim + uzantı;
                            fu_resim.SaveAs(Server.MapPath("~/Foto/" + isim + uzantı));
                            if (dm.OyunEkle(o))
                            {
                                pnl_basarili.Visible = true;
                                pnl_basarisiz.Visible = false;
                                tb_isim.Text = "";
                                tb_özet.Text = "";
                                tb_detay.Text = "";
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_basarisiz.Text = "Oyun Ekleme Başarısız Olmuştur";
                            }
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_basarisiz.Text = "Resim Uzantısı .jpeg veya .png veya .jpg Olmalıdır";
                        }
                    }
                    else
                    {
                        o.Foto = "none.png";
                        if (dm.OyunEkle(o))
                        {
                            pnl_basarili.Visible = true;
                            pnl_basarisiz.Visible = false;
                            tb_isim.Text = "";
                            tb_özet.Text = "";
                            tb_detay.Text = "";
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_basarisiz.Text = "Oyun Ekleme Başarısız Olmuştur";
                        }
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Oyun Daha Önce Eklenmiştir";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "İsim Boş Bırakılamaz";
            }
        }
    }
}