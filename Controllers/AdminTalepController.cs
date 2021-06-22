using Destek.App_Start;
using Destek.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Destek.Controllers
{
    public class AdminTalepController : Controller
    {
        public static string ConString = WebConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();
        PreCore Core = new PreCore();
        private List<talepmaster> Liste()
        {
            List<talepmaster> TalepListesi = new List<talepmaster>();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM talepmaster order by Id desc", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            talepmaster talep = new talepmaster();
                            talep.Id = (int)dr["Id"];
                            talep.AtananKisi = (int)dr["AtananKisi"];
                            talep.BaslangicTarihi = (DateTime)dr["BaslangicTarihi"];
                            talep.Baslik = dr["Baslik"].ToString();
                            talep.BitisTarihi = (DateTime)dr["BitisTarihi"];
                            talep.FırmaId = (int)dr["FırmaId"];
                            talep.GMT = (DateTime)dr["GMT"];
                            talep.Onay = dr["Onay"].ToString();
                            talep.Tipi = (int)dr["Tipi"];
                            talep.Icerik = dr["Icerik"].ToString();
                            talep.Cevap = dr["Cevap"].ToString();
                            talep.AciliyetDurumu = (int)dr["AciliyetDurumu"];
                            talep.Durum = (string)dr["Durum"];
                            TalepListesi.Add(talep);
                        }
                    }
                }
                con.Close();
            }
            return TalepListesi;
        }
        private talepmaster Getir(int Id)
        {
            talepmaster talep = new talepmaster();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM talepmaster where Id = @Id limit 0,1", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            talep.Id = (int)dr["Id"];
                            talep.AtananKisi = (int)dr["AtananKisi"];
                            talep.BaslangicTarihi = (DateTime)dr["BaslangicTarihi"];
                            talep.Baslik = dr["Baslik"].ToString();
                            talep.BitisTarihi = (DateTime)dr["BitisTarihi"];
                            talep.FırmaId = (int)dr["FırmaId"];
                            talep.GMT = (DateTime)dr["GMT"];
                            talep.Onay = dr["Onay"].ToString();
                            talep.Tipi = (int)dr["Tipi"];
                            talep.Icerik = dr["Icerik"].ToString();
                            talep.Cevap = dr["Cevap"].ToString();
                            talep.AciliyetDurumu = (int)dr["AciliyetDurumu"];
                            talep.Durum = (string)dr["Durum"];
                        }
                    }
                }
                con.Close();
            }
            return talep;
        }
        private bool Guncelle(talepmaster model)
        {
            bool status = false;
            talepmaster talep = new talepmaster();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE talepmaster SET Baslik = @Baslik,Icerik = @Icerik,Tipi = @Tipi,Onay = @Onay,BaslangicTarihi = @BaslangicTarihi,BitisTarihi = @BitisTarihi,AtananKisi = @AtananKisi,GMT = @GMT,FırmaID = @FırmaID,AciliyetDurumu = @AciliyetDurumu,Cevap = @Cevap  WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", (model.BaslangicTarihi == null) ? DBNull.Value : (object)model.BaslangicTarihi);
                    cmd.Parameters.AddWithValue("@BitisTarihi", (model.BitisTarihi == null) ? DBNull.Value : (object)model.BitisTarihi);

                    cmd.Parameters.AddWithValue("@Baslik", model.Baslik);
                    cmd.Parameters.AddWithValue("@Cevap", model.Cevap);
                    cmd.Parameters.AddWithValue("@FırmaId", model.FırmaId);
                    cmd.Parameters.AddWithValue("@GMT", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Onay", (model.Onay == null) ? "H" : (object)model.Onay);
                    cmd.Parameters.AddWithValue("@Tipi", model.Tipi);
                    cmd.Parameters.AddWithValue("@AciliyetDurumu", model.AciliyetDurumu);
                    cmd.Parameters.AddWithValue("@Icerik", model.Icerik);
                    cmd.Parameters.AddWithValue("@AtananKisi", (model.AtananKisi == null) ? DBNull.Value : (object)model.AtananKisi);
                    status = (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                con.Close();
            }
            return status;
        }
        private bool Sil(talepmaster model)
        {
            bool status = false;
            talepmaster talep = new talepmaster();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM talepmaster WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", model.Id);

                    status = (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                con.Close();
            }
            return status;
        }
        musteri MusteriBilgiGetir(int Id)
        {
            musteri Musteri = new musteri();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM musteri where Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Musteri.Id = (int)dr.GetValue(0);
                            Musteri.Kodu = (string)dr.GetValue(1);
                            Musteri.Unvan = (string)dr.GetValue(2);
                            Musteri.Tel = (string)dr.GetValue(3);
                            Musteri.Email = (string)dr.GetValue(4);
                            Musteri.KullaniciAdi = (string)dr.GetValue(5);
                            Musteri.Sifre = (string)dr.GetValue(6);
                            Musteri.Durum = (string)dr.GetValue(7);
                            //Musteri.LogoUrl = (string)dr.GetValue(8);

                        }
                    }
                }
                con.Close();
            }
            return Musteri;
        }
        [HttpPost]
        [AdminAuth]
        public ActionResult Kaydet(talepmaster model)
        {
            if (ModelState.IsValid)
            {
                model.Onay = "E";
                Guncelle(model);

                try
                {
                    MailHelper mailhelp = new MailHelper();
                    MailHelper.Mesaj mesaj = new MailHelper.Mesaj();
                    mesaj.IsHtml = true;
                    mesaj.toBody = MailHtmlOlustur(model);
                    mesaj.toSubject = String.Format("Açtığınız destek talebinizi cevapladık.");
                    mesaj.toMail = MusteriBilgiGetir(model.FırmaId).Email;

                    mailhelp.MailGonder(mesaj);

                }
                catch 
                {
                    
                }
                return View("Index", Liste());
            }
            else
            {
                return View("Detay", model);
            }

        }
        public string MailHtmlOlustur(talepmaster bilgiler)
        {
            PreCore core = new PreCore();
            string TalepBody = String.Format("<H3>Talebiniz Cevaplando.</H3>");
            TalepBody += String.Format("<br/><a alt='Destek talep linki' href='{0}'>Talebe git</a>", "http://localhost/Talep/Detay/" + bilgiler.Id);

            return TalepBody;
        }
        [AdminAuth]
        // GET: AdminTalep
        public ActionResult Index()
        {

            return View(Liste());
        }
        [AdminAuth]
        public ActionResult Detay(int Id)
        {

            return View(Getir(Id));
        }

        [AdminAuth]
        public ActionResult Sil(int Id)
        {
            Sil(new talepmaster() { Id = Id});
            return View("Index",Liste());
        }
    }
}