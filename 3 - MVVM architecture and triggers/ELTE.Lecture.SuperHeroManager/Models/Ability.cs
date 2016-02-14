using System;

namespace ELTE.Lecture.SuperHeroManager.Models
{
    [Serializable]
    public class Ability : IEquatable<Ability>
    {
        public String Name { get; set; }

        public Int32 Value { get; set; }

        #region Equality members

        public bool Equals(Ability other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ability) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Value;
            }
        }

        #endregion

    }
}