using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Oyunlar
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Ozet { get; set; }
        public string Detay { get; set; }
        public string KategoriStr { get; set; }
        public string Foto { get; set; }
        public bool Durum { get; set; }
        public string DurumStr { get; set; }
    }
}
