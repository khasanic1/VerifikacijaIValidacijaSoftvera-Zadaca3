using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pijaca
{
	public interface IOpcije
	{
		void izvrsiIzmjenu(List<Prodavač> prodavači, Prodavač p, Prodavač postojeći);
	}
	class Dodavanje : IOpcije
	{
		public void izvrsiIzmjenu(List<Prodavač> prodavači, Prodavač p, Prodavač postojeći)
		{
			if (postojeći == null || prodavači.FindAll(prod => prod.Ime == p.Ime).Count == 0)
				throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");

			prodavači.Add(p);
		}
	}

	class Izmjena : IOpcije
	{
		public void izvrsiIzmjenu(List<Prodavač> prodavači, Prodavač p, Prodavač postojeći)
		{
			if (postojeći == null || prodavači.FindAll(prod => prod.Ime == p.Ime).Count == 0)
				throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");

			prodavači.Remove(postojeći);
			prodavači.Add(p);
		}
	}

	class Brisanje : IOpcije
	{
		public void izvrsiIzmjenu(List<Prodavač> prodavači, Prodavač p, Prodavač postojeći)
		{
			if (postojeći == null || prodavači.FindAll(prod => prod.Ime == p.Ime).Count == 0)
				throw new InvalidOperationException("Nemoguće dodati prodavača kad već postoji registrovan!");

			prodavači.Remove(postojeći);
		}
	}
}
