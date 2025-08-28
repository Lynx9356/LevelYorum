using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }
        #region Tür İşlemleri
        public List<Turler> TurListele()
        {
            try
            {
                List<Turler> turler = new List<Turler>();
                cmd.CommandText = "SELECT * FROM Turler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Turler t = new Turler();
                    t.ID = reader.GetInt32(0);
                    t.Isim = reader.GetString(1);
                    t.Durum = reader.GetBoolean(2);
                    t.DurumStr = reader.GetBoolean(2) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    turler.Add(t);
                }
                return turler;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public string TurStr(int oyunid)
        {
            try
            {

                cmd.CommandText = "SELECT T.Isim FROM Kategoriler AS K JOIN Turler AS T ON K.TurID=T.ID WHERE K.OyunID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", oyunid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string turler = string.Empty;
                while (reader.Read())
                {
                    turler += reader.GetString(0) + ",";
                }
                turler = turler.Substring(0, turler.Length - 1);
                return turler;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool TurEkle(Turler t)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Turler(Isim,Durum) VALUES(@isim,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", t.Isim);
                cmd.Parameters.AddWithValue("@durum", t.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Turler TurGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Turler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Turler t = new Turler();
                while (reader.Read())
                {
                    t.ID = reader.GetInt32(0);
                    t.Isim = reader.GetString(1);
                    t.Durum = reader.GetBoolean(2);
                    t.DurumStr = reader.GetBoolean(2) ? "<label style='color=green'>Aktif</label>" : "<label style='color=red'>Pasif</label>";
                }
                return t;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool TurleriGuncelle(Turler t)
        {
            try
            {
                cmd.CommandText = "UPDATE Turler SET Isim = @isim,Durum = @durum WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", t.Isim);
                cmd.Parameters.AddWithValue("@durum", t.Durum);
                cmd.Parameters.AddWithValue("@id", t.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool TurDurumDegis(int id)
        {
            try
            {
                Turler t = TurGetir(id);
                if (t.Durum)
                {
                    cmd.CommandText = "UPDATE Turler SET Durum=0 WHERE ID=@id";
                }
                else
                {
                    cmd.CommandText = "UPDATE Turler SET Durum=1 WHERE ID=@id";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Oyun İşlemleri
        public List<Oyunlar> OyunListele()
        {
            try
            {
                List<Oyunlar> oyunlar = new List<Oyunlar>();
                cmd.CommandText = "SELECT * FROM Oyunlar";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Oyunlar o = new Oyunlar();
                    o.ID = reader.GetInt32(0);
                    o.Isim = reader.GetString(1);
                    o.Ozet = reader.GetString(2);
                    o.Detay = reader.GetString(3);
                    o.Foto = reader.GetString(4);
                    o.Durum = reader.GetBoolean(5);
                    o.DurumStr = reader.GetBoolean(5) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    oyunlar.Add(o);
                }
                con.Close();
                foreach (Oyunlar item in oyunlar)
                {
                    item.KategoriStr = TurStr(item.ID);
                }

                return oyunlar;

            }
            catch
            {

                return null;
            }

        }
        public List<Oyunlar> SonOyunlar()
        {
            try
            {
                List<Oyunlar> oyunlar = new List<Oyunlar>();
                cmd.CommandText = "SELECT * FROM Oyunlar WHERE ID > (SELECT MAX(ID) - 5 FROM Oyunlar) ORDER BY ID DESC";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Oyunlar o = new Oyunlar();
                    o.ID = reader.GetInt32(0);
                    o.Isim = reader.GetString(1);
                    o.Ozet = reader.GetString(2);
                    o.Detay = reader.GetString(3);
                    o.Foto = reader.GetString(4);
                    o.Durum = reader.GetBoolean(5);
                    o.DurumStr = reader.GetBoolean(5) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    oyunlar.Add(o);
                }
                con.Close();
                foreach (Oyunlar item in oyunlar)
                {
                    item.KategoriStr = TurStr(item.ID);
                }

                return oyunlar;

            }
            catch
            {

                return null;
            }

        }
        public List<Oyunlar> OyunListele(bool durum)
        {
            try
            {
                List<Oyunlar> oyunlar = new List<Oyunlar>();
                cmd.CommandText = "SELECT * FROM Oyunlar WHERE Durum=@durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", durum);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Oyunlar o = new Oyunlar();
                    o.ID = reader.GetInt32(0);
                    o.Isim = reader.GetString(1);
                    o.Ozet = reader.GetString(2);
                    o.Detay = reader.GetString(3);
                    o.Foto = reader.GetString(4);
                    o.Durum = reader.GetBoolean(5);
                    o.DurumStr = reader.GetBoolean(5) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    oyunlar.Add(o);
                }
                con.Close();
                foreach (Oyunlar item in oyunlar)
                {
                    item.KategoriStr = TurStr(item.ID);
                }

                return oyunlar;

            }
            catch
            {

                return null;
            }

        }
        public List<Oyunlar> OyunListele(int turID)
        {
            try
            {
                List<Oyunlar> oyunlar = new List<Oyunlar>();
                cmd.CommandText = "SELECT o.ID,o.Isim,o.Ozet,o.Detay,o.Foto,o.Durum FROM Oyunlar AS o JOIN Kategoriler AS k ON o.ID=k.OyunID JOIN Turler AS t ON t.ID=k.TurID WHERE k.TurID=@turID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@turID", turID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Oyunlar o = new Oyunlar();
                    o.ID = reader.GetInt32(0);
                    o.Isim = reader.GetString(1);
                    o.Ozet = reader.GetString(2);
                    o.Detay = reader.GetString(3);
                    o.Foto = reader.GetString(4);
                    o.Durum = reader.GetBoolean(5);
                    o.DurumStr = reader.GetBoolean(5) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    oyunlar.Add(o);
                }
                con.Close();
                foreach (Oyunlar item in oyunlar)
                {
                    item.KategoriStr = TurStr(item.ID);
                }

                return oyunlar;

            }
            catch
            {

                return null;
            }

        }
        public bool OyunDurumDegis(int id)
        {
            try
            {
                Oyunlar o = OyunGetir(id);
                if (o.Durum)
                {
                    cmd.CommandText = "UPDATE Oyunlar SET Durum=0 WHERE ID=@id";
                }
                else
                {
                    cmd.CommandText = "UPDATE Oyunlar SET Durum=1 WHERE ID=@id";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Oyunlar OyunGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT o.ID,o.Isim,o.Ozet,o.Detay,o.Foto,o.Durum FROM Oyunlar AS o WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Oyunlar o = new Oyunlar();
                while (reader.Read())
                {
                    o.ID = reader.GetInt32(0);
                    o.Isim = reader.GetString(1);
                    o.Ozet = reader.GetString(2);
                    o.Detay = reader.GetString(3);
                    o.Foto = reader.GetString(4);
                    o.Durum = reader.GetBoolean(5);
                    o.DurumStr = reader.GetBoolean(5) ? "<label style='color=green'>Aktif</label>" : "<label style='color=red'>Pasif</label>";
                }
                return o;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OyunEkle(Oyunlar o)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Oyunlar(Isim,Ozet,Detay,Foto,Durum) VALUES(@isim,@ozet,@detay,@foto,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", o.Isim);
                cmd.Parameters.AddWithValue("@ozet", o.Ozet);
                cmd.Parameters.AddWithValue("@detay", o.Detay);
                cmd.Parameters.AddWithValue("@foto", o.Foto);
                cmd.Parameters.AddWithValue("@durum", o.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OyunKategoriEkle(Kategoriler k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(OyunID,TurID) VALUES(@oyunid,@turid)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oyunid", k.OyunID);
                cmd.Parameters.AddWithValue("@turid", k.TurID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OyunKategoriSilme(Kategoriler k)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE OyunID = @oyunid AND TurID = @turid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oyunid", k.OyunID);
                cmd.Parameters.AddWithValue("@turid", k.TurID);
                con.Open();
                int silinen = cmd.ExecuteNonQuery();
                if (silinen == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public bool OyunGuncelle(Oyunlar o)
        {
            try
            {
                cmd.CommandText = "UPDATE Oyunlar SET Isim = @isim,Ozet = @ozet,Detay = @detay,Foto = @foto,Durum = @durum WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", o.Isim);
                cmd.Parameters.AddWithValue("@ozet", o.Ozet);
                cmd.Parameters.AddWithValue("@detay", o.Detay);
                cmd.Parameters.AddWithValue("@foto", o.Foto);
                cmd.Parameters.AddWithValue("@durum", o.Durum);
                cmd.Parameters.AddWithValue("@id", o.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Kullanıcı Tür İşlemleri
        public List<KullaniciTur> KullanıcıTurListele()
        {
            try
            {
                List<KullaniciTur> kullanıcıTur = new List<KullaniciTur>();
                cmd.CommandText = "SELECT * FROM KullaniciTur";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KullaniciTur k = new KullaniciTur();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kullanıcıTur.Add(k);
                }
                return kullanıcıTur;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public string KullaniciStr(int id)
        {
            try
            {
                cmd.CommandText = "SELECT kt.Isim FROM Kullanicilar AS k JOIN KullaniciTur AS kt ON k.KullaniciTurID=kt.ID WHERE k.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string kullaniciTur = string.Empty;
                while (reader.Read())
                {
                    kullaniciTur = reader.GetString(0);
                }
                return kullaniciTur;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Kullanıcı İşlemleri
        public List<Kullanicilar> KullaniciListele()
        {
            try
            {
                List<Kullanicilar> kullanıcılar = new List<Kullanicilar>();
                cmd.CommandText = "SELECT k.ID,k.Isim,k.Soyisim,k.KullaniciAdi,k.Sifre,k.KullaniciTurID,kt.Isim,k.Durum FROM Kullanicilar AS k JOIN KullaniciTur AS kt ON kt.ID = k.KullaniciTurID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kullanicilar k = new Kullanicilar();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Soyisim = reader.GetString(2);
                    k.KullaniciAdi = reader.GetString(3);
                    k.Sifre = reader.GetString(4);
                    k.KullaniciTurID = reader.GetInt32(5);
                    k.KullaniciTurStr = reader.GetString(6);
                    k.Durum = reader.GetBoolean(7);
                    k.DurumStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    kullanıcılar.Add(k);
                }
                return kullanıcılar;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Kullanicilar> SonKullanicilar()
        {
            try
            {
                List<Kullanicilar> kullanıcılar = new List<Kullanicilar>();
                cmd.CommandText = "SELECT k.ID,k.Isim,k.Soyisim,k.KullaniciAdi,k.Sifre,k.KullaniciTurID,kt.Isim,k.Durum FROM Kullanicilar AS k JOIN KullaniciTur AS kt ON kt.ID = k.KullaniciTurID WHERE k.ID > (SELECT MAX(ID) - 5 FROM Kullanicilar) ORDER BY k.ID DESC";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kullanicilar k = new Kullanicilar();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Soyisim = reader.GetString(2);
                    k.KullaniciAdi = reader.GetString(3);
                    k.Sifre = reader.GetString(4);
                    k.KullaniciTurID = reader.GetInt32(5);
                    k.KullaniciTurStr = reader.GetString(6);
                    k.Durum = reader.GetBoolean(7);
                    k.DurumStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    kullanıcılar.Add(k);
                }
                return kullanıcılar;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Kullanicilar KullaniciGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT k.ID,k.Isim,k.Soyisim,k.KullaniciAdi,k.Sifre,k.KullaniciTurID,kt.Isim,k.Durum FROM Kullanicilar AS k JOIN KullaniciTur AS kt ON kt.ID = k.KullaniciTurID WHERE k.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kullanicilar k = new Kullanicilar();
                while (reader.Read())
                {

                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Soyisim = reader.GetString(2);
                    k.KullaniciAdi = reader.GetString(3);
                    k.Sifre = reader.GetString(4);
                    k.KullaniciTurID = reader.GetInt32(5);
                    k.KullaniciTurStr = reader.GetString(6);
                    k.Durum = reader.GetBoolean(7);
                    k.DurumStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                }
                return k;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool KullaniciDurumDegis(int id)
        {
            try
            {
                Kullanicilar k = KullaniciGetir(id);
                if (k.Durum)
                {
                    cmd.CommandText = "UPDATE Kullanicilar SET Durum=0 WHERE ID=@id";
                }
                else
                {
                    cmd.CommandText = "UPDATE Kullanicilar SET Durum=1 WHERE ID=@id";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool KullaniciEkle(Kullanicilar k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kullanicilar(Isim,Soyisim,KullaniciAdi,Sifre,KullaniciTurID,Durum) VALUES(@isim,@soyisim,@kuladi,@sifre,@kulTurId,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", k.Isim);
                cmd.Parameters.AddWithValue("@soyisim", k.Soyisim);
                cmd.Parameters.AddWithValue("@kuladi", k.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", k.Sifre);
                cmd.Parameters.AddWithValue("@kulTurId", k.KullaniciTurID);
                cmd.Parameters.AddWithValue("@durum", k.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool KullaniciGuncelle(Kullanicilar k)
        {
            try
            {
                cmd.CommandText = "UPDATE Kullanicilar SET Isim = @isim,Soyisim = @soyisim,KullaniciAdi = @kuladi,Sifre = @sifre,KullaniciTurID = @kulturid,Durum = @durum WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", k.Isim);
                cmd.Parameters.AddWithValue("@soyisim", k.Soyisim);
                cmd.Parameters.AddWithValue("@kuladi", k.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", k.Sifre);
                cmd.Parameters.AddWithValue("@kulturid", k.KullaniciTurID);
                cmd.Parameters.AddWithValue("@durum", k.Durum);
                cmd.Parameters.AddWithValue("@id", k.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Yorum İşlemleri
        public List<Yorumlar> YorumListele()
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT y.ID,k.ID,k.KullaniciAdi,o.ID,o.Isim,y.Icerik,y.Durum FROM Yorumlar AS y JOIN Kullanicilar AS k ON k.ID = y.KullaniciID JOIN Oyunlar AS o ON o.ID = y.OyunID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.KullaniciID = reader.GetInt32(1);
                    y.KullaniciStr = reader.GetString(2);
                    y.OyunID = reader.GetInt32(3);
                    y.OyunStr = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Durum = reader.GetBoolean(6);
                    y.DurumStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> AktifYorumListele(bool durum)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT y.ID,k.ID,k.KullaniciAdi,o.ID,o.Isim,y.Icerik,y.Durum FROM Yorumlar AS y JOIN Kullanicilar AS k ON k.ID = y.KullaniciID JOIN Oyunlar AS o ON o.ID = y.OyunID WHERE y.Durum = @durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", durum);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.KullaniciID = reader.GetInt32(1);
                    y.KullaniciStr = reader.GetString(2);
                    y.OyunID = reader.GetInt32(3);
                    y.OyunStr = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Durum = reader.GetBoolean(6);
                    y.DurumStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> SonYorumlar()
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT y.ID,k.ID,k.KullaniciAdi,o.ID,o.Isim,y.Icerik,y.Durum FROM Yorumlar AS y JOIN Kullanicilar AS k ON k.ID = y.KullaniciID JOIN Oyunlar AS o ON o.ID = y.OyunID WHERE y.ID > (SELECT MAX(ID) - 5 FROM Yorumlar) ORDER BY y.ID DESC";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.KullaniciID = reader.GetInt32(1);
                    y.KullaniciStr = reader.GetString(2);
                    y.OyunID = reader.GetInt32(3);
                    y.OyunStr = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Durum = reader.GetBoolean(6);
                    y.DurumStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> YorumListele(bool yorum)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT y.ID,k.ID,k.KullaniciAdi,o.ID,o.Isim,y.Icerik,y.Durum FROM Yorumlar AS y JOIN Kullanicilar AS k ON k.ID = y.KullaniciID JOIN Oyunlar AS o ON o.ID = y.OyunID WHERE y.Durum=@durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", yorum);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.KullaniciID = reader.GetInt32(1);
                    y.KullaniciStr = reader.GetString(2);
                    y.OyunID = reader.GetInt32(3);
                    y.OyunStr = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Durum = reader.GetBoolean(6);
                    y.DurumStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> YorumListele(bool yorum, int id)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT y.ID,k.ID,k.KullaniciAdi,o.ID,o.Isim,y.Icerik,y.Durum FROM Yorumlar AS y JOIN Kullanicilar AS k ON k.ID = y.KullaniciID JOIN Oyunlar AS o ON o.ID = y.OyunID WHERE y.Durum=@durum AND o.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", yorum);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.ID = reader.GetInt32(0);
                    y.KullaniciID = reader.GetInt32(1);
                    y.KullaniciStr = reader.GetString(2);
                    y.OyunID = reader.GetInt32(3);
                    y.OyunStr = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Durum = reader.GetBoolean(6);
                    y.DurumStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    yorumlar.Add(y);
                }
                con.Close();
                foreach (Yorumlar item in yorumlar)
                {
                    item.KullaniciTurStr = KullaniciStr(item.KullaniciID);
                }
                return yorumlar;
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Yorumlar YorumGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT y.ID,k.ID,k.KullaniciAdi,o.ID,o.Isim,y.Icerik,y.Durum FROM Yorumlar AS y JOIN Kullanicilar AS k ON k.ID = y.KullaniciID JOIN Oyunlar AS o ON o.ID = y.OyunID WHERE y.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Yorumlar y = new Yorumlar();
                while (reader.Read())
                {
                    y.ID = reader.GetInt32(0);
                    y.KullaniciID = reader.GetInt32(1);
                    y.KullaniciStr = reader.GetString(2);
                    y.OyunID = reader.GetInt32(3);
                    y.OyunStr = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Durum = reader.GetBoolean(6);
                    y.DurumStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                }
                return y;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YorumDurumDegis(int id)
        {
            try
            {
                Yorumlar y = YorumGetir(id);
                if (y.Durum)
                {
                    cmd.CommandText = "UPDATE Yorumlar SET Durum=0 WHERE ID=@id";
                }
                else
                {
                    cmd.CommandText = "UPDATE Yorumlar SET Durum=1 WHERE ID=@id";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YorumEkle(Yorumlar y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar (KullaniciID,OyunID,Icerik,Durum) VALUES (@kullanıcıid,@oyunid,@icerik,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kullanıcıid", y.KullaniciID);
                cmd.Parameters.AddWithValue("@oyunid", y.OyunID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@durum", y.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Giriş İşlemleri
        public Kullanicilar AdminGetir(string kullaniciadi, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@kullanıcıAdı AND Sifre=@şifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kullanıcıAdı", kullaniciadi);
                cmd.Parameters.AddWithValue("@şifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT k.ID,k.Isim,k.Soyisim,k.KullaniciAdi,k.Sifre,k.KullaniciTurID,kt.Isim,k.Durum FROM Kullanicilar AS k JOIN KullaniciTur AS kt ON kt.ID = k.KullaniciTurID WHERE k.KullaniciAdi=@kullaniciAdi AND k.Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciadi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    //con.Open(); SAKIN TEKRARDAN AÇMA!!!!!!
                    SqlDataReader reader = cmd.ExecuteReader();
                    Kullanicilar k = new Kullanicilar();
                    while (reader.Read())
                    {

                        k.ID = reader.GetInt32(0);
                        k.Isim = reader.GetString(1);
                        k.Soyisim = reader.GetString(2);
                        k.KullaniciAdi = reader.GetString(3);
                        k.Sifre = reader.GetString(4);
                        k.KullaniciTurID = reader.GetInt32(5);
                        k.KullaniciTurStr = reader.GetString(6);
                        k.Durum = reader.GetBoolean(7);
                        k.DurumStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    }
                    if (k.KullaniciTurID == 1)
                    {
                        return k;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Kullanicilar KullaniciGetir(string kullaniciadi, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@kullanıcıAdı AND Sifre=@şifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kullanıcıAdı", kullaniciadi);
                cmd.Parameters.AddWithValue("@şifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT k.ID,k.Isim,k.Soyisim,k.KullaniciAdi,k.Sifre,k.KullaniciTurID,kt.Isim,k.Durum FROM Kullanicilar AS k JOIN KullaniciTur AS kt ON kt.ID = k.KullaniciTurID WHERE k.KullaniciAdi=@kullaniciAdi AND k.Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciadi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    //con.Open(); SAKIN TEKRARDAN AÇMA!!!!!!
                    SqlDataReader reader = cmd.ExecuteReader();
                    Kullanicilar k = new Kullanicilar();
                    while (reader.Read())
                    {

                        k.ID = reader.GetInt32(0);
                        k.Isim = reader.GetString(1);
                        k.Soyisim = reader.GetString(2);
                        k.KullaniciAdi = reader.GetString(3);
                        k.Sifre = reader.GetString(4);
                        k.KullaniciTurID = reader.GetInt32(5);
                        k.KullaniciTurStr = reader.GetString(6);
                        k.Durum = reader.GetBoolean(7);
                        k.DurumStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    }
                    return k;
                }
                else
                {
                    return null;
                }
            }
            catch
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Yardımcı İşlemler
        public bool VeriKontrol(string tablo, string kolon, string veri)
        {
            try
            {
                cmd.CommandText = $"SELECT COUNT(*) FROM {tablo} WHERE {kolon} = @isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", veri);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public bool OyunKategoriVeriKontrol(string tablo, string oyunID,string turID, int oyunveriID, int turveriID)
        {
            try
            {
                cmd.CommandText = $"SELECT COUNT(*) FROM {tablo} WHERE {oyunID} = @oyunid AND {turID} = @turid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oyunid", oyunveriID);
                cmd.Parameters.AddWithValue("@turid", turveriID);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
