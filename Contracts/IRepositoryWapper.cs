using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWapper
    {
        IPlayerRepository Player { get; }
        ICharacterRepository Character { get; }
        Task<int> Save();
    }
}
