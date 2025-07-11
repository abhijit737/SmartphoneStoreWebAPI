﻿using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
