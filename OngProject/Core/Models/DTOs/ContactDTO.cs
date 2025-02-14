﻿using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class ContactDTO
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
