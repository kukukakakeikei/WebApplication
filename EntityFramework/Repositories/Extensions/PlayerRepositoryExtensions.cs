using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories.Extensions
{
    //Play仓储的扩展类
    public static class PlayerRepositoryExtensions
    {
        public static IQueryable<Player> SearchByAccount(this IQueryable<Player> players,string account) 
        {
            if(string.IsNullOrWhiteSpace(account)) 
            {
                return players; 
            }

            return players.Where(o => o.Account.ToLower().Contains(account.Trim().ToLower()));
        }
    }
}
