using Destek.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace Destek.Controllers
{
    public class AdminLoginController : Controller
    {
        public static string ConString = WebConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();
      
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        bool kullaniciKontrolEt(kullanici Model)
        {
            bool status = false;
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanici where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre", con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", Model.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", Model.Sifre);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }
                con.Close();
            }
            return status;
        }
        musteri kullaniciBilgiGetir(int Id)
        {
            musteri Musteri = new musteri();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanici where Id = @Id", con))
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
                            Musteri.LogoUrl = (string)dr.GetValue(8);
                            Musteri.Yonetici = (string)dr.GetValue(9);
                        }
                    }
                }
                con.Close();
            }
            return Musteri;
        }
        kullanici kullaniciBilgiGetir(kullanici Model)
        {
            kullanici Musteri = new kullanici();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanici where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre", con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", Model.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", Model.Sifre);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Musteri.Id = (int)dr.GetValue(0);
                            Musteri.KullaniciAdi = (string)dr.GetValue(1);
                            Musteri.Sifre = (string)dr.GetValue(2);
                            Musteri.Status = (string)dr.GetValue(3);
                        }
                    }
                }
                con.Close();
            }
            return Musteri;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(kullanici model)
        {
            if (ModelState.IsValid)
            {
                if (kullaniciKontrolEt(model))
                {
                    kullanici musteri = kullaniciBilgiGetir(model);
                    FormsAuthentication.SetAuthCookie(musteri.KullaniciAdi, true);

                    Session.Add("kullanici", musteri);
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    ModelState.AddModelError("500", "MüşteriKodu veya şifre hatalı!");
                }
            }
            return View("Index", model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("kullanici");
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}