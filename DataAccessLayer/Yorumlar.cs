using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorumlar
    {
        public int ID { get; set; }
        public int KullaniciID { get; set; }
        public string KullaniciStr { get; set; }
        public string KullaniciTurStr { get; set; }
        public int OyunID { get; set; }
        public string OyunStr { get; set; }
        public string Icerik { get; set; }
        public bool Durum { get; set; }
        public string DurumStr { get; set; }
    }
}
