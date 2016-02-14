using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ELTE.Lecture.SuperHeroManager.Models
{
    public class FileRepository : IRepository
    {
        private MemoryRepository repository;
        private readonly XmlSerializer serializer;

        public String FilePath { get; }

        public FileRepository(String filePath)
        {
            FilePath = filePath;
            repository = new MemoryRepository(Enumerable.Empty<SuperHero>());
            serializer = new XmlSerializer(typeof (SuperHero[]));
        }

        public IEnumerable<SuperHero> GetSuperHeroes()
        {
            if (!File.Exists(FilePath)) return Enumerable.Empty<SuperHero>();

            using (var file = File.OpenText(FilePath))
            {
                using (XmlReader reader = XmlReader.Create(file))
                {
                    var heroes = serializer.Deserialize(reader) as SuperHero[];
                    repository = new MemoryRepository(heroes);
                    return heroes;
                }
            }
        }

        public void AddSuperHero(SuperHero superHero)
        {
            repository.AddSuperHero(superHero);
        }

        public void RemoveSuperHero(SuperHero superHero)
        {
            repository.RemoveSuperHero(superHero);
        }

        public void SaveChanges(IEnumerable<SuperHero> superHero)
        {
            repository.SaveChanges(superHero);
            SaveChanges();
        }

        private void SaveChanges()
        {
            using (var file = File.CreateText(FilePath))
            {
                using (var writer = XmlWriter.Create(file))
                {
                    serializer.Serialize(writer, repository.GetSuperHeroes().ToArray());
                }
            }
        }
    }
}