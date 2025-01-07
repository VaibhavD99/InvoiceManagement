﻿using System.ComponentModel.DataAnnotations;

namespace InvoiceManagement.Models
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
