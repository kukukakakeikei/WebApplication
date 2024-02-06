using Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Mappings
{
    public class CharacterMap : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.Property(Character => Character.Nickname).HasMaxLength(20);
            builder.Property(Character => Character.Classes).HasMaxLength(20);

            builder.HasIndex(Character => Character.Nickname).IsUnique();
            builder.HasOne(Character => Character.Player)
                .WithMany(Player => Player.Characters)
                .HasForeignKey(Character => Character.PlayerId);
        }
    }
}
