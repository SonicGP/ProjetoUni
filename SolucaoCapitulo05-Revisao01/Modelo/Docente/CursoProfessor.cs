﻿using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Cadastros;

namespace Modelo.Docente
{
    public class CursoProfessor
    {
        //public long? CursoProfessorID { get; set; }
        public long? CursoID { get; set; }
        public Curso Curso { get; set; }
        public long? ProfessorID { get; set; }
        public Professor Professor { get; set; }
    }
}
