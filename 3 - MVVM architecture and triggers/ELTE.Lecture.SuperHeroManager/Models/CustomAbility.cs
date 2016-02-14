using System;

namespace ELTE.Lecture.SuperHeroManager.Models
{
    [Serializable]
    public class CustomAbility : IEquatable<CustomAbility>
    {
        public String Name { get; set; }

        public String Description { get; set; }

        #region Equality members

        public bool Equals(CustomAbility other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CustomAbility) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ (Description != null ? Description.GetHashCode() : 0);
            }
        }

        #endregion

    }
}