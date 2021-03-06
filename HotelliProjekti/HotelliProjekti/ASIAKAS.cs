﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HotelliProjekti
{
    /* Luodaa luokka ASIAKAS asiakkaiden lisäämiseksi
     *                                   poistamiseksi
     *                                   muokkaamiseksi
     */
    class ASIAKAS
    {

        YHDISTA yht = new YHDISTA();


        // funktio uuden asiakkaan luomiseksi
        public bool lisaaAsiakas(String enimi, String snimi, String osoite, int pnumero, String ptpaikka, String ktunnus, String ssana)
        {
            MySqlCommand komento = new MySqlCommand();
            String lisaaKysely = "INSERT INTO `asiakkaat`" +
            "(Ktunnus, Etunimi, Sukunimi, Lahiosoite, Postinumero, Postitoimipaikka, Salasana)" +
            "VALUES(@ktu, @enm, @snm, @oso, @pno, @ptp, @ssa); ";
            komento.CommandText = lisaaKysely;
            komento.Connection = yht.OtaYhteytta();
            //komento.Parameters.Add("");

            //@ktu, @enm, @snm, @oso, @pno, @ptp, @ssa)
            komento.Parameters.Add("@ktu", MySqlDbType.Int32).Value = ktunnus;
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@oso", MySqlDbType.VarChar).Value = osoite;
            komento.Parameters.Add("@pno", MySqlDbType.VarChar).Value = pnumero;
            komento.Parameters.Add("@ptp", MySqlDbType.VarChar).Value = ptpaikka;
            komento.Parameters.Add("@ssa", MySqlDbType.VarChar).Value = ssana;

            yht.AvaaYhteys();
            // Avataan ja suljetaan yhteys
            if (komento.ExecuteNonQuery() == 1)
            {
                yht.SuljeYhteys();
                return true;

            }
            else
            {
                yht.SuljeYhteys();
                return false;
            }




        }

        // Tässä luodaan funktio, joka hakee asiakaslistan
        public DataTable HaeAsiakkaat();
        {
         MySqlCommand komento = new MySqlCommand("SELECT * FROM `asiakkaat`", yht.OtaYhteytta());
         MySqlDataAdapter adapteri = new MySqlDataAdapter();
         DataTable taulu = new DataTable();

         adapteri.SelectCommand = komento; 
         adapteri.Fill(taulu);
         return taulu;
        }

    // Tässä luodaan funktio asiakkaan muokkaamiseksi
    public bool muokkaaAsiakasta(String enimi, String snimi, String osoite, int pnumero, String ptpaikka, String ktunnus, String ssana)
    {
        MySqlCommand komento = new MySqlCommand();
        String lisaaKysely = "INSERT INTO `asiakkaat`" + 
            "(Ktunnus, Etunimi, Sukunimi, Lahiosoite, Postinumero, Postitoimipaikka, Salasana)" +
            "VALUES(@ktu, @enm, @snm, @oso, @pno, @ptp, @ssa); " + "WHERE Ktunnus =@ktu";
        komento.CommandText = lisaaKysely;
        komento.Connection = yht.OtaYhteytta();
        komento.Parameters.Add("")

            //@ktu, @enm, @snm, @oso, @pno, @ptp, @ssa)
        komento.Parameters.Add("@ktu", MySqlDbType.VarChar).Value = ktunnus;
        komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
        komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
        komento.Parameters.Add("@oso", MySqlDbType.VarChar).Value = osoite;
        komento.Parameters.Add("@pno", MySqlDbType.VarChar).Value = pnumero;
        komento.Parameters.Add("@ptp", MySqlDbType.VarChar).Value = ptpaikka;
        komento.Parameters.Add("@ssa", MySqlDbType.VarChar).Value = ssana;

        yht.AvaaYhteys();

        if (komento.ExecuteNonQuery() == 1)
        {
            yht.SuljeYhteys();
            return true;

        }
        else
        {
            yht.SuljeYhteys();
            return false;
        }
    }
    }



}
