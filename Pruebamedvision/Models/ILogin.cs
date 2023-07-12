﻿using System.ComponentModel.DataAnnotations;
namespace Pruebamedvision.Models
{
    public class ILogin
    {
        
            [Required(ErrorMessage = "User Name is required")]
            public string? Username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string? Password { get; set; }
        
    }
}

