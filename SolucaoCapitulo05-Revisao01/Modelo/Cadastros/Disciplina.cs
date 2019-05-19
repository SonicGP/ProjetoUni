using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.Cadastros
{
    public class Disciplina
    {
        [DisplayName("Id")]
        public long? DisciplinaID { get; set; } 

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
    }
}
