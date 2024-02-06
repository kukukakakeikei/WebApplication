using AutoMapper;
using Entites;
using Entites.Dtos;

namespace WebApplication1
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Player, PlayerDto>(); //映射关系
            CreateMap<Player, PlayerWithCharacterDto>();
            CreateMap<Character, CharacterDto>();
        }
    }
}
