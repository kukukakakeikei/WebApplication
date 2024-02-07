using Entites.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class PlayerParameter : QueryStringParameters
    {
        public PlayerParameter() 
        {
            OrderBy = "Account";
        }
        public DateTime MinDataCreated { get; set; }
        public DateTime MaxDataCreated { get; set; } = DateTime.Now;

        public bool ValidDataCreatedRange => MaxDataCreated > MinDataCreated;

        public string? Account { get; set; }
    }
}
