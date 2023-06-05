﻿using System.ComponentModel.DataAnnotations;

namespace WebbApi.Controllers
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}