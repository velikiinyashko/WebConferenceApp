using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace speaklis_fullend.Areas.Cabinet.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Не указано имя пользователя")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Длина имени должа быть от 3 до 25 символов")]
        public string Login { get; set; }

        [Required (ErrorMessage = "Не указан пароль пользователя")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Длина пароля должна быть от 5 до 25 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
