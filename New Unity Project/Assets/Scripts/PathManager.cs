using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Managers
{
    public static class PathManager
    {
        const string Entities = "Entities/";
        public const string Rocks = Entities + "Rocks/";
        public const string Characters = Entities + "Characters/";

        const string World = "World/";
        public const string Maps = World + "Maps/";
        public const string Planes = World + "Planes/";

        const string Skins = "Skins/";
        public const string RockSkins = Skins+"Rocks/";
        public const string CharacterSkins = Skins+"Characters/";

        public const string Skills = "Skills/";
    }
}
