using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Models
{
    public class AuthCredentials
    {
        [Required]
        public string Username { get; set; }

        [Required, HiddenInput(DisplayValue =false )]
        public string Password { get; set; }
    }
}