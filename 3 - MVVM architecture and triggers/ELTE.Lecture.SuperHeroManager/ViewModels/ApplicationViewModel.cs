using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELTE.Lecture.SuperHeroManager.Models;

namespace ELTE.Lecture.SuperHeroManager.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private SuperHeroViewModel selectedSuperHero;
        public IRepository Repository { get; private set; }

        public ApplicationViewModel(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Repository = repository;

            InitializeSuperHeroes(Repository);
            selectedSuperHero = null;

            CreateSuperHeroCommand = new ActionCommand(CreateSuperHero);
            RemoveSuperHeroCommand = new ActionCommand(RemoveSuperHero, () => SelectedSuperHero != null);
            SaveChangesCommand = new ActionCommand(SaveChanges);
        }

        private void SaveChanges()
        {
            var changedSuperHeroes = SuperHeroes.Where(hero => hero.HasChanged);
            Repository.SaveChanges(changedSuperHeroes.Select(context => context.SuperHero));

            foreach (var superHeroViewModel in changedSuperHeroes)
            {
                superHeroViewModel.HasChanged = false;
            }
        }

        private void RemoveSuperHero()
        {
            Repository.RemoveSuperHero(SelectedSuperHero.SuperHero);
            SuperHeroes.Remove(SelectedSuperHero);
        }

        private void CreateSuperHero()
        {
            var superHero = new SuperHero();
            var superHeroViewModel = new SuperHeroViewModel(superHero)
            {
                HasChanged = true,
                SuperHeroName = "[new superhero]",
            };

            SuperHeroes.Add(superHeroViewModel);
        }

        private void InitializeSuperHeroes(IRepository repository)
        {
            var superHeroes = repository.GetSuperHeroes();
            SuperHeroes = new ObservableCollection<SuperHeroViewModel>(superHeroes.Select(CreateSuperHeroViewModel));
        }

        private SuperHeroViewModel CreateSuperHeroViewModel(SuperHero superHero)
        {
            return new SuperHeroViewModel(superHero);
        }

        public SuperHeroViewModel SelectedSuperHero
        {
            get { return selectedSuperHero; }
            set
            {
                selectedSuperHero = value;
                // ezt is csinalhatnank:
                // OnPropertyChanged("SelectedSuperHero");
                // C# 6.0: OnPropertyChanged(nameof(SelectedSuperHero));
                OnPropertyChanged(() => SelectedSuperHero);
                RemoveSuperHeroCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<SuperHeroViewModel> SuperHeroes { get; private set; }

        public ActionCommand CreateSuperHeroCommand { get; private set; }

        public ActionCommand RemoveSuperHeroCommand { get; private set; }

        public ActionCommand SaveChangesCommand { get; private set; }
    }
}