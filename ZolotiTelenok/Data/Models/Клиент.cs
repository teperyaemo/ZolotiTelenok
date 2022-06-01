using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ZolotiTelenok
{
    public partial class Клиент
    {
        [BindNever]
        public int ИдКлиента { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string Фамилия { get; set; } = null!;

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string Имя { get; set; } = null!;

        [Display(Name = "Время")]
        [Required(ErrorMessage = "Выберите время")]
        public DateTime Время { get; set; }

        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Телефон { get; set; } = null!;
    }
}
