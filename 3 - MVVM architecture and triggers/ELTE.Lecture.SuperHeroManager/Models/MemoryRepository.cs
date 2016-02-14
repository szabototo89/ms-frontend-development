using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELTE.Lecture.SuperHeroManager.Models
{
    public class MemoryRepository : IRepository
    {
        private readonly List<SuperHero> superHeroes;

        public MemoryRepository(IEnumerable<SuperHero> superHeroes)
        {
            if (superHeroes == null) throw new ArgumentNullException(nameof(superHeroes));
            this.superHeroes = new List<SuperHero>(superHeroes);
        }

        public IEnumerable<SuperHero> GetSuperHeroes()
        {
            return superHeroes;
        }

        public void SaveChanges(IEnumerable<SuperHero> changedSuperHeroes)
        {
            superHeroes.RemoveAll(hero => changedSuperHeroes.Any(changedHero => changedHero.Id == hero.Id));
            superHeroes.AddRange(changedSuperHeroes);
        }

        public void AddSuperHero(SuperHero superHero)
        {
            if (superHero == null) throw new ArgumentNullException(nameof(superHero));
            superHeroes.Add(superHero);
        }

        public void RemoveSuperHero(SuperHero superHero)
        {
            if (superHero == null) throw new ArgumentNullException(nameof(superHero));
            superHeroes.Remove(superHero);
        }
    }
}