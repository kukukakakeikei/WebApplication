using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Dtos
{
    public class PlayerWithCharacterDto : PlayerDto
    {
        public IEnumerable<CharacterDto> Characters { get; set; }
    }
}
