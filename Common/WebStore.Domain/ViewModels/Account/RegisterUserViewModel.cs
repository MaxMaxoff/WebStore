﻿using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.ViewModels.Account
{
    public class RegisterUserViewModel
    {
        [Required, Display(Name = "Имя пользователя"), MaxLength(256)]
        public string UserName { get; set; }

        [Required, Display(Name = "Пароль"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Display(Name = "Повторите ввод пароля"), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
