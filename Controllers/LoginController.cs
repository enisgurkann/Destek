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
    public class LoginController : Controller
    {
        public static string ConString = WebConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        bool MusteriKontrolEt(loginmodel Model)
        {
            bool status = false;
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM musteri where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre", con))
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
        musteri MusteriBilgiGetir(loginmodel Model)
        {
            musteri Musteri = new musteri();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM musteri where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre", con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", Model.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", Model.Sifre);
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(loginmodel model)
        {
            if (ModelState.IsValid)
            {
                if (MusteriKontrolEt(model))
                {
                    musteri musteri = MusteriBilgiGetir(model);
                    FormsAuthentication.SetAuthCookie(musteri.Kodu, true);
                   
                    Session.Add("musteri", musteri);
                    return RedirectToAction("Index", "Home");                  
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
            Session.Remove("musteri");
            return RedirectToAction("Index", "Login");
        }
    }
}