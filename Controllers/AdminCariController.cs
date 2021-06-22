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
    public class AdminCariController : Controller
    {
        public static string ConString = WebConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();
        public bool Ekle(musteri musteri)
        {
            bool status = false;
            musteri talep = new musteri();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO musteri(Durum,Email,Kodu,KullaniciAdi,Sifre,Tel,Unvan) VALUES(@Durum,@Email,@Kodu,@KullaniciAdi,@Sifre,@Tel,@Unvan)", con))
                {
                    cmd.Parameters.AddWithValue("@Durum", musteri.Durum);
                    cmd.Parameters.AddWithValue("@Email", musteri.Email);
                    cmd.Parameters.AddWithValue("@Kodu", musteri.Kodu);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", musteri.KullaniciAdi);
                    //cmd.Parameters.AddWithValue("@LogoUrl", musteri.LogoUrl);
                    cmd.Parameters.AddWithValue("@Sifre", musteri.Sifre);
                    cmd.Parameters.AddWithValue("@Tel", musteri.Tel);
                    cmd.Parameters.AddWithValue("@Unvan", musteri.Unvan);
                    status = (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                con.Close();
            }
            return status;
        }
        public bool Guncelle(musteri musteri)
        {
            bool status = false;
            musteri talep = new musteri();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE musteri SET Durum = @Durum,Email = @Email,Kodu = @Kodu,KullaniciAdi = @KullaniciAdi,Sifre = @Sifre,Tel = @Tel,Unvan = @Unvan WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", musteri.Id);
                    cmd.Parameters.AddWithValue("@Durum", musteri.Durum);
                    cmd.Parameters.AddWithValue("@Email", musteri.Email);
                    cmd.Parameters.AddWithValue("@Kodu", musteri.Kodu);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", musteri.KullaniciAdi);
                    //cmd.Parameters.AddWithValue("@LogoUrl", musteri.LogoUrl);
                    cmd.Parameters.AddWithValue("@Sifre", musteri.Sifre);
                    cmd.Parameters.AddWithValue("@Tel", musteri.Tel);
                    cmd.Parameters.AddWithValue("@Unvan", musteri.Unvan);
                    status = (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                con.Close();
            }
            return status;
        }
        public bool MusteriSil(int Id)
        {
            bool status = false;
            talepmaster talep = new talepmaster();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM musteri WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    status = (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                con.Close();
            }
            return status;
        }



        public List<musteri> MusteriListe()
        {
            List<musteri> MusteriListe = new List<musteri>();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM musteri", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            musteri Musteri = new musteri();
                            Musteri.Id = (int)dr.GetValue(0);
                            Musteri.Kodu = (string)dr.GetValue(1);
                            Musteri.Unvan = (string)dr.GetValue(2);
                            Musteri.Tel = (string)dr.GetValue(3);
                            Musteri.Email = (string)dr.GetValue(4);
                            Musteri.KullaniciAdi = (string)dr.GetValue(5);
                            Musteri.Sifre = (string)dr.GetValue(6);
                            Musteri.Durum = (string)dr.GetValue(7);
                            //Musteri.LogoUrl = (string)dr.GetValue(8);
                            MusteriListe.Add(Musteri);
                        }
                    }
                }
                con.Close();
            }
            return MusteriListe;
        }
        public musteri MusteriBilgiGetir(int Id)
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
        // GET: AdminCari
        [AdminAuth]
        public ActionResult Index()
        {
            return View(MusteriListe());
        }
        [AdminAuth]
        public ActionResult Detay(int Id = -1)
        {
            if (Id != -1)
                return View(MusteriBilgiGetir(Id));
            else
                return View(new musteri());
                
        }
           [AdminAuth]
        public ActionResult Sil(int Id)
        {
            MusteriSil(Id);
            return View("Index",MusteriListe());
        }
        [HttpPost]
        [AdminAuth]
        public ActionResult Kaydet(musteri model)
        {
            if (model.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    Guncelle(model);
                   return View("Index",MusteriListe());
                }
                else return View("Detay", model);

            }
            else
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    Ekle(model);
                    return View("Index", MusteriListe());
                }
                else return View("Detay", model);
            }
        }
    }
}