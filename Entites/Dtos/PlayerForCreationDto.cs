using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Dtos
{
    internal class PlayerForCreationDto
    {
        [Required(ErrorMessage ="账号不能为空")]
        [StringLength(20, ErrorMessage ="账号长度不能大于50")]
        public string Account { get; set; }

        [Required(ErrorMessage = "账号类型不能为空")]
        [StringLength(20, ErrorMessage = "账号类型长度不能大于50")]
        public string AccountType { get; set; }
    }
}
