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
    public class HomeController : Controller
    {
        public static string ConString = WebConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();

        // GET: Home
        [AuthorizeConfig]
        public ActionResult Index()
        {
            HomeModel Model = new HomeModel();
            PreCore core = new PreCore();
            musteri Musteri = core.CariVer();
            Model.AktifHataTalebiSayisi = AktifHataTalebiSayisi(Musteri);
            Model.AktifYeniIstekSayisi = AktifYeniIstekSayisi(Musteri);
            Model.BekleyenTalepSayisi = BekleyenTalepSayisi(Musteri);
            Model.CevaplananAcikTalepSayisi = CevaplananAcikTalepSayisi(Musteri);
            return View(Model);
        }

        int AktifHataTalebiSayisi(musteri Model)
        {
            int toplam = 0;
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) 'TOPLAM' FROM talepmaster where FırmaID = @FırmaID  and Tipi = 2 and Durum = 'A'", con))
                {
                    cmd.Parameters.AddWithValue("@FırmaID", Model.Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                toplam = dr.GetInt32(0);
                            }
                        }
                    }
                }
                con.Close();
            }
            return toplam;
        }
        int AktifYeniIstekSayisi(musteri Model)
        {
            int toplam = 0;
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) as TOPLAM FROM talepmaster where FırmaID = @FırmaID and Tipi = 1 and Durum = 'A'", con))
                {
                    cmd.Parameters.AddWithValue("@FırmaID", Model.Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                toplam = dr.GetInt32(0);
                            }
                    }
                }
                con.Close();
            }
            return toplam;
        }
        int BekleyenTalepSayisi(musteri Model)
        {
            int toplam = 0;
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) as TOPLAM FROM talepmaster where FırmaID = @FırmaID and Tipi = 1 and Durum = 'A'", con))
                {
                    cmd.Parameters.AddWithValue("@FırmaID", Model.Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                toplam = dr.GetInt32(0);
                            }
                    }
                }
                con.Close();
            }
            return toplam;
        }
        int CevaplananAcikTalepSayisi(musteri Model)
        {
            int toplam = 0;
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) as TOPLAM FROM talepmaster where FırmaID = @FırmaID and Tipi = 1 and Durum = 'A' and Onay = 'E'", con))
                {
                    cmd.Parameters.AddWithValue("@FırmaID", Model.Id);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                toplam = dr.GetInt32(0);
                            }
                    }
                }
                con.Close();
            }
            return toplam;
        }
    }
}