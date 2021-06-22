using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Destek
{
    public class SelectCore
    {
        public static string ConString = WebConfigurationManager.ConnectionStrings["MysqlConnection"].ToString();

        public static IEnumerable<SelectListItem> TalepTipiListesi()
        {
            List<SelectListItem> TipiListe = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM taleptipi;", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TipiListe.Add(new SelectListItem { Text = dr["Detay"].ToString(), Value = dr["Id"].ToString() });
                        }
                    }
                }
                con.Close();
            }

            return TipiListe;
        }

        public static IEnumerable<SelectListItem> AciliyetListesi()
        {
            List<SelectListItem> AciliyetListe = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM talepaciliyet", con))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            AciliyetListe.Add(new SelectListItem { Text = dr["Detay"].ToString(), Value = dr["Id"].ToString() });
                        }
                    }
                }
                con.Close();
            }

            return AciliyetListe;
        }
     
    }
}