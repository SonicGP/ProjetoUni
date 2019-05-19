using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Discente
{
    public class Academico
    {
        public string FotoMimeType { get; set; }
        public byte[] foto { get; set; }

        [NotMapped]
        public IFormFile formFile { get; set; }

        [DisplayName("Id")]
        public long? AcademicoID { get; set; }

        [StringLength(10,MinimumLength =10)]
        [RegularExpression("([0-9]{10})")]
        [Required]
        [DisplayName("RA")]
        public string RegistroAcademico { get; set; }

        [Required]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-mm-yyyyy}")]
        [Required]
        public DateTime? Nascimento { get; set; }
    }
}
