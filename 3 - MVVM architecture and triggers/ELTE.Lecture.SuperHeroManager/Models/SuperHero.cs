using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ELTE.Lecture.SuperHeroManager.Models
{
    [XmlRoot("SuperHero")]
    public class SuperHero
    {
        [XmlElement("Id", typeof(String))]
        public String Id { get; set; }

        [XmlElement("RealName", typeof(String))]
        public String RealName { get; set; }

        [XmlElement("SuperHeroName", typeof(String))]
        public String SuperHeroName { get; set; }

        [XmlArray("Abilities")]
        public Ability[] Abilities { get; set; }

        [XmlArray("CustomAbilities")]
        public CustomAbility[] CustomAbilities { get; set; }

        public SuperHero()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}