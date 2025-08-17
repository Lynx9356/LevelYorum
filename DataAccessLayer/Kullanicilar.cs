using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Kullanicilar
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public int KullaniciTurID { get; set; }
        public string KullaniciTurStr { get; set; }
        public bool Durum { get; set; }
        public string DurumStr { get; set; }
    }
}
