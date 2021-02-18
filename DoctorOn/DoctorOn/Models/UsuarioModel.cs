using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorOn.Models
{
    public class UsuarioModel
    {
        
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        //comparação para verificação de senha
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }

    }
}