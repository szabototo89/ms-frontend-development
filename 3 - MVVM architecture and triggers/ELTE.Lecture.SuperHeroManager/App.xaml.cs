using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using ELTE.Lecture.SuperHeroManager.Models;
using ELTE.Lecture.SuperHeroManager.ViewModels;

namespace ELTE.Lecture.SuperHeroManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IEnumerable<SuperHero> superheroes = new[]
            {
                new SuperHero()
                {
                    RealName = "Tony Stark", SuperHeroName = "Iron-Man", //Abilities = new[]
                    //{
                    //    new Ability {Name = "Genius", Value = 10}
                    //}
                },
                new SuperHero()
                {
                    RealName = "Peter Parker", SuperHeroName = "Spider-Man", //CustomAbilities = new[]
                    //{
                    //    new CustomAbility {Name = "Spider Sense", Description = "Mystical Spider sense"}
                    //}
                }
            };

            // IRepository repository = new MemoryRepository(superheroes);
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "superheroes.xml");
            IRepository repository = new FileRepository(filePath);
            ApplicationViewModel viewModel = new ApplicationViewModel(repository);
            MainWindow window = new MainWindow(viewModel);

            window.Show();
        }
    }
}