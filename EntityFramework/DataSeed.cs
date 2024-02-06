using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;

namespace EntityFramework
{
    public static class DataSeed
    {
        private static readonly Guid[] _guids =
        {
            Guid.NewGuid(),
            Guid.NewGuid()
        };

        public static Player[] Players { get; } =
        {
            new Player
            {
                Id = _guids[0],
                Account = "mw2021",
                AccountType = "Free",
                DataCreated = DateTime.Now,
            },
            new Player
            {
                Id = _guids[1],
                Account = "dc2021",
                AccountType = "Free",
                DataCreated = DateTime.Now,
            }
        };
        public static Character[] Characters { get; } =
        {
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Code Man",
                Classes = "Mage",
                Level = 99,
                PlayerId = _guids[0],
                DataCreated = DateTime.Now,
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Iron Man",
                Classes = "Warrior",
                Level = 90,
                PlayerId = _guids[0],
                DataCreated = DateTime.Now,
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "Spider Man",
                Classes = "Druid",
                Level = 80,
                PlayerId = _guids[0],
                DataCreated = DateTime.Now,
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "BatMan",
                Classes = "Death knight",
                Level = 90,
                PlayerId = _guids[1],
                DataCreated = DateTime.Now,
            },
            new Character
            {
                Id = Guid.NewGuid(),
                Nickname = "SuperMan",
                Classes = "Paladin",
                Level = 99,
                PlayerId = _guids[1],
                DataCreated = DateTime.Now,
            },
        };
    }
}
