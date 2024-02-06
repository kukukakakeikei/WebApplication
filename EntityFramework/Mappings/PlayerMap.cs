using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entites;

namespace EntityFramework.Mappings
{
    public class PlayerMap:IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(Player => Player.Account).HasMaxLength(50);
            builder.Property(Player => Player.AccountType).HasMaxLength(10);
            builder.HasIndex(Player => Player.Account).IsUnique();
        }
    }
}
