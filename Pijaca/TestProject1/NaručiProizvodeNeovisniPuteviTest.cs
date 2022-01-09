using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class NaručiProizvodeNeovisniPuteviTest
    {
        static Tržnica t;
        static DateTime datumOtvaranja, rok;
        static List<DateTime> datumiRokova;
        static Prodavač prodavač;
        static Proizvod janjetina;

        [TestInitialize]
        public void InicijalizacijaTržnice()
        {
            t = new Tržnica();
            datumOtvaranja = new DateTime(2021, 11, 11);
            rok = new DateTime(2021, 1, 30);
            prodavač = new Prodavač("Mujo", "šifratralala", datumOtvaranja, 25);
            janjetina = new Proizvod(Namirnica.Meso, "Janjetina", 1, new DateTime(2021, 11, 11), 23, true);
            datumiRokova = new List<DateTime>()
            {
                new DateTime(2022, 1, 22),
                new DateTime(2022, 1, 27),
                new DateTime(2022, 1, 30)
            };
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Put1()
        {
            List<Proizvod> proizvodi = new List<Proizvod>()
            {
                janjetina,
                new Proizvod(Namirnica.Voće, "Kruška", 4, new DateTime(2021, 12, 25), 10, true),
                new Proizvod(Namirnica.Povrće, "Brokula", 8, new DateTime(2021, 12, 26), 10, true)
            };

            Štand štand = new Štand(prodavač, rok, proizvodi);



            List<Proizvod> proslijeđeniProizvodi = new List<Proizvod>()
            {
                janjetina,
                new Proizvod(Namirnica.Meso, "Piletina", 2, new DateTime(2021, 12, 27), 10, false),
                new Proizvod(Namirnica.Meso, "Junetina", 6, new DateTime(2012, 12, 28), 10, false),
                new Proizvod(Namirnica.Žitarica, "Pšenica", 7, new DateTime(2012, 12, 29), 10, true)
            };

            List<int> kolicine = new List<int>()
            {
                3,
                7
            };

            t.NaručiProizvode(štand, proslijeđeniProizvodi, kolicine, datumiRokova, true);
        }


        [TestMethod]
        public void Put2()
        {

            List<Proizvod> proizvodi = new List<Proizvod>()
            {
                janjetina,
                new Proizvod(Namirnica.Voće, "Pomorandža", 4, new DateTime(2022, 1, 2), 15, false),
                new Proizvod(Namirnica.Povrće, "Luk", 6, new DateTime(2022, 1, 5), 15, true)
            };

            Štand štand = new Štand(prodavač, rok, proizvodi);


            List<int> kolicine = new List<int>()
            {
                5,
                9,
                6
            };

            t.NaručiProizvode(štand, proizvodi, kolicine, datumiRokova, false);
            Assert.AreEqual(5, štand.Proizvodi[0].OčekivanaKoličina);
            Assert.AreEqual(9, štand.Proizvodi[1].OčekivanaKoličina);
            Assert.AreEqual(6, štand.Proizvodi[2].OčekivanaKoličina);
        }
    }
}