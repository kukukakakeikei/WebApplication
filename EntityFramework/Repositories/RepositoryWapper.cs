using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class RepositoryWapper : IRepositoryWapper
    {
        private readonly WebApplicationDbContext _context;
        private IPlayerRepository _player;
        private ICharacterRepository _character;

        public IPlayerRepository Player
        {
            get { return _player ??= new PlayerRepository(_context); }
        }
        public ICharacterRepository Character
        {
            get { return _character ??= new CharacterRepository(_context); }
        }
        public RepositoryWapper(WebApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
