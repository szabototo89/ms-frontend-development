using System.Collections.Generic;

namespace ELTE.Lecture.SuperHeroManager.Models
{
    public interface IRepository
    {
        IEnumerable<SuperHero> GetSuperHeroes();
        void AddSuperHero(SuperHero superHero);
        void RemoveSuperHero(SuperHero superHero);
        void SaveChanges(IEnumerable<SuperHero> changedSuperHeroes);
    }
}