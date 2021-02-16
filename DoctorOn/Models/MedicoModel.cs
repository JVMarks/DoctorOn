using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DoctorOn.Entidades;
namespace DoctorOn.Models
{
    public class MedicoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Usuário")]
        public string Nome_completo { get; set; }

        [Required]
        [Display(Name = "Endereco completo")]
        public string Endereco { get; set; }

        [Required]
        [StringLength(17)]
        [Display(Name = "Digite o numero do seu telefone +55(11)99999-9999")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(10)]
        public int CRM { get; set; }

        [Required]
        public Especialidade Especialidade { get; set; }

    }
}