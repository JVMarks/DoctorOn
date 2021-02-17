using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorOn.Models
{
    public class PacienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Usuário")]
        public string Nome_completo { get; set; }

        [Required(ErrorMessage = "CPF obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "CPF do Usuário")]
        [StringLength(12)]
        public int Cpf { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required]
        public DateTime Datadenacimento { get; set; }

        [Required]
        [Display(Name = "Endereco completo")]
        public string Endereco { get; set; }

        [Required]
        [StringLength(17)]
        [Display(Name = "Digite o numero do seu telefone +55(11)99999-9999")]
        public string Telefone { get; set; }

        [Required]
        public Nome_do_convenio Nome_do_convenio { get; set; }

        [Required]
        public string Matricula_do_convenio { get; set; }


    }
}