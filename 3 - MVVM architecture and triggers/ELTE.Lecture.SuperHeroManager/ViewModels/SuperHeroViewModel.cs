using System;
using ELTE.Lecture.SuperHeroManager.Models;

namespace ELTE.Lecture.SuperHeroManager.ViewModels
{
    public class SuperHeroViewModel : ViewModelBase
    {
        private Boolean hasChanged;
        public SuperHero SuperHero { get; private set; }

        public Boolean HasChanged
        {
            get { return hasChanged; }
            set
            {
                hasChanged = value; 
                OnPropertyChanged(() => HasChanged);
            }
        }

        public SuperHeroViewModel(SuperHero superHero)
        {
            if (superHero == null) throw new ArgumentNullException(nameof(superHero));
            SuperHero = superHero;

            RealName = SuperHero.RealName;
            SuperHeroName = SuperHero.SuperHeroName;
            HasChanged = false;
        }

        private void ValueHasChanged()
        {
            HasChanged = true;
        }

        public String RealName
        {
            get { return SuperHero.RealName; }
            set
            {
                SuperHero.RealName = value;
                ValueHasChanged();
                OnPropertyChanged(() => RealName);
            }
        }

        public String SuperHeroName
        {
            get { return SuperHero.SuperHeroName; }
            set
            {
                SuperHero.SuperHeroName = value;
                ValueHasChanged();
                OnPropertyChanged(() => SuperHeroName);
            }
        }
    }
}