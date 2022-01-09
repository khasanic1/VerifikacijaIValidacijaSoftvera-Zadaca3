using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;

namespace TestProject1
{
    [TestClass]
    public class NaruciProizvodePokrivenostLinija
    {

        static Tržnica t;
        static DateTime datumOtvaranja;
        static Proizvod banana;
        static Proizvod jabuka;
        static Štand stand;
        List<Proizvod> listaPr;

        [TestInitialize]
        public void InicijalizacijaTržnice()
        {
            t = new Tržnica();
            datumOtvaranja = new DateTime(2021, 11, 11);
            banana = new Proizvod(Namirnica.Voće, "banana", 15, new DateTime(2022, 1, 1), 1.5, true);
            jabuka = new Proizvod(Namirnica.Voće, "jabuka", 15, new DateTime(2022, 1, 2), 13, true);
            listaPr = new List<Proizvod> { banana, jabuka };
            stand = new Štand(new Prodavač("keno", "nekašifra", new DateTime(2021, 11, 12), 100), new DateTime(2021, 1, 30), listaPr);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokrivenostIzuzetka1()
        {
            List<Proizvod> lista = new List<Proizvod>();
            lista.Add(new Proizvod(Namirnica.Povrće, "cvekla", 30, new DateTime(2022, 1, 7),5, true));
            lista.Add(new Proizvod(Namirnica.Povrće, "paprika", 20, new DateTime(2022, 1, 8), 2.4, true));

            t.NaručiProizvode(stand, lista, new List<int> { 2, 3 }, new List<DateTime> { new DateTime(2022, 1, 22) }, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokrivenostIzuzetka2()
        {
            List<Proizvod> lista = new List<Proizvod>();
            lista.Add(new Proizvod(Namirnica.Povrće, "cvekla", 30, new DateTime(2022, 1, 7), 5, true));
            lista.Add(new Proizvod(Namirnica.Povrće, "paprika", 20, new DateTime(2022, 1, 8), 2.4, true));

            t.NaručiProizvode(stand, lista, new List<int> { 2 }, new List<DateTime> { new DateTime(2022, 1, 22), new DateTime(2022, 1, 27) }, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokrivenostIzuzetka3()
        {
            List<Proizvod> lista = new List<Proizvod>();
            lista.Add(new Proizvod(Namirnica.Povrće, "cvekla", 30, new DateTime(2022, 1, 7), 5, true));
            lista.Add(new Proizvod(Namirnica.Povrće, "paprika", 20, new DateTime(2022, 1, 8), 2.4, true));
            try
            {
                t.NaručiProizvode(stand, lista, new List<int> { 2, 3 }, new List<DateTime> { new DateTime(2022, 1, 22), new DateTime(2022, 1, 27) }, false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

        }
    }
}
