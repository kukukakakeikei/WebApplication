using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace EntityFramework.Repositories
{
    public class CharacterRepository:BaseRepository<Character>,ICharacterRepository
    {
        public CharacterRepository(WebApplicationDbContext repositoryContext):base (repositoryContext) 
        {

        }
    }
}
