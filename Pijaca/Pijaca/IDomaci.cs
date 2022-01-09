using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Radio - Kenan
namespace Pijaca
{
    public interface IDomaci
    {
        public void daLiJeDomaci(string šifraProizvoda, int brojač);
    }

    public class Domaci : IDomaci
    {
        public void daLiJeDomaci(string šifraProizvoda, int brojač)
        {
            šifraProizvoda = "387" + brojač;
        }
    }

    public class Strani : IDomaci
    {
        public void daLiJeDomaci(string šifraProizvoda, int brojač)
        {
            šifraProizvoda = "111" + brojač;
        }
    }
}
