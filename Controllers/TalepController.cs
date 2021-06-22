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
    public class TalepController : Controller
    {
        public static string ConString = WebConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();
        PreCore Core = new PreCore();
        private List<talepmaster> Liste(musteri musteri)
        {
            List<talepmaster> TalepListesi = new List<talepmaster>();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM talepmaster where FırmaId = @FırmaId order by Id desc", con))
                {
                    cmd.Parameters.AddWithValue("@FırmaId", musteri.Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            talepmaster talep = new talepmaster();
                            talep.Id = (int)dr["Id"];
                            talep.AtananKisi = (int)dr["AtananKisi"];
                            talep.BaslangicTarihi =(DateTime)dr["BaslangicTarihi"];
                            talep.Baslik = dr["Baslik"].ToString();
                            talep.BitisTarihi =(DateTime)dr["BitisTarihi"];
                            talep.FırmaId =(int)dr["FırmaId"];
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
        private talepmaster Getir(int Id, musteri musteri)
        {
            talepmaster talep = new talepmaster();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM talepmaster where Id = @Id and FırmaId=@FırmaId limit 0,1", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@FırmaId", musteri.Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {                          
                            talep.Id = (int)dr["Id"];
                            talep.AtananKisi = (int)dr["AtananKisi"];
                            talep.BaslangicTarihi = (DateTime)dr["BaslangicTarihi"];
                            talep.Baslik = dr["Baslik"].ToString();
                            talep.BitisTarihi = (DateTime)dr["BitisTarihi"];
                            talep.FırmaId = musteri.Id;
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
        private bool Ekle(talepmaster model,musteri musteri)
        {
            bool status = false;
            talepmaster talep = new talepmaster();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO talepmaster(Baslik,Icerik,Tipi,Onay,BaslangicTarihi,BitisTarihi,AtananKisi,GMT,FırmaID,AciliyetDurumu) VALUES(@Baslik,@Icerik,@Tipi,@Onay,@BaslangicTarihi,@BitisTarihi,@AtananKisi,@GMT,@FırmaID,@AciliyetDurumu)", con))
                {
                    cmd.Parameters.AddWithValue("@Icerik", model.Icerik);
                    cmd.Parameters.AddWithValue("@AtananKisi", model.AtananKisi);
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", (model.BaslangicTarihi == null) ? DBNull.Value : (object)model.BaslangicTarihi);
                    cmd.Parameters.AddWithValue("@Baslik", model.Baslik);
                    cmd.Parameters.AddWithValue("@BitisTarihi", (model.BitisTarihi == null) ? DBNull.Value : (object)model.BitisTarihi);
                    cmd.Parameters.AddWithValue("@FırmaId", musteri.Id);
                    cmd.Parameters.AddWithValue("@GMT", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Onay", (model.Onay == null) ? "H" : (object)model.Onay);
                    cmd.Parameters.AddWithValue("@Tipi", model.Tipi);
                    cmd.Parameters.AddWithValue("@AciliyetDurumu", model.AciliyetDurumu);

                    status = (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                con.Close();
            }
            return status;
        }
        private bool Guncelle(talepmaster model, musteri musteri)
        {
            bool status = false;
            talepmaster talep = new talepmaster();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE talepmaster SET Baslik = @Baslik,Icerik = @Icerik,Tipi = @Tipi,Onay = @Onay,BaslangicTarihi = @BaslangicTarihi,BitisTarihi = @BitisTarihi,AtananKisi = @AtananKisi,GMT = @GMT,FırmaID = @FırmaID,AciliyetDurumu = @AciliyetDurumu WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", (model.BaslangicTarihi == null) ? DBNull.Value : (object)model.BaslangicTarihi);
                    cmd.Parameters.AddWithValue("@Baslik", model.Baslik);
                    cmd.Parameters.AddWithValue("@BitisTarihi", (model.BitisTarihi == null) ? DBNull.Value : (object)model.BitisTarihi);
                    cmd.Parameters.AddWithValue("@FırmaId", musteri.Id);
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
        private bool Sil(talepmaster model, musteri musteri)
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




        // GET: Talep
        [AuthorizeConfig]
        public ActionResult Index()
        {
            return View(Liste(Core.CariVer()));
        }
         [AuthorizeConfig]
        public ActionResult Detay(int Id = -1)
        {
            //
            return View(Getir(Id, Core.CariVer()));
        }
        [HttpPost]
        [AuthorizeConfig]
        public ActionResult Kaydet(talepmaster model)
        {
             PreCore core = new PreCore();
            if (model.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    Guncelle(model, Core.CariVer());
                    return View("Index", Liste(Core.CariVer()));
                }
                else return View("Detay", model);

            }
            else
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                     
                    if (Ekle(model, Core.CariVer()))
                    {
                        MailHelper mailhelp = new MailHelper();
                        MailHelper.Mesaj mesaj = new MailHelper.Mesaj();
                        mesaj.IsHtml = true;
                        mesaj.toBody =  MailHtmlOlustur(model);
                        mesaj.toSubject = String.Format("{0} firmasından Destek Talebi Geldi", core.CariUnvaniVer());
                        mesaj.toMail = "destek@egeyazilim.net";

                        mailhelp.MailGonder(mesaj);
                    }
                    return View("Index", Liste(Core.CariVer()));
                }
                else return View("Detay", model);
            }
        }



        public string MailHtmlOlustur(talepmaster bilgiler)
        {
            PreCore core = new PreCore();
            string TalepBody = String.Format("<H3>{0} Firmasının destek talebi.</H3>", core.CariUnvaniVer());
            TalepBody += "<table border='0' cellspacing='3' cellpadding='0'>";
            TalepBody += String.Format("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Firma Kodu", core.CariKoduVer());
            TalepBody += String.Format("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Firma Unvani", core.CariUnvaniVer());
            TalepBody += String.Format("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Talep No", bilgiler.Id);
            TalepBody += String.Format("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Açılış Tarihi", bilgiler.GMT);
            TalepBody += String.Format("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Baslik", bilgiler.Baslik);
            TalepBody += String.Format("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "DBS Hesabi", bilgiler.Icerik);
            TalepBody += "</table>";
            TalepBody += String.Format("<br/><a alt='Destek talep linki' href='{0}'>Talebe git</a>", "http://localhost/AdminTalep/Detay/" + bilgiler.Id);

            return TalepBody;
        }
    }
}