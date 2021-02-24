using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorOn.Entidades
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome_completo { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        [StringLength(18)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(10)]
        public string CRM { get; set; }

        [Required]
        public Especialidade Especialidade { get; set; }

        public int Usuario_Id { get; set; }

    }
}