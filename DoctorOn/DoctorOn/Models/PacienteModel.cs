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
        public string Nome_completo { get; set; }

        [Required(ErrorMessage = "CPF obrigatório", AllowEmptyStrings = false)]
        [StringLength(12)]
        public string Cpf { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Required]
        public DateTime Datadenacimento { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        [StringLength(17)]
        public string Telefone { get; set; }

        [Required]
        public Nome_do_convenio Nome_do_convenio { get; set; }

        [Required]
        public string Matricula_do_convenio { get; set; }

        [Required]
        public int Usuario_Id { get; set; }


    }
}