using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_School_API.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string DataNasc { get; set; }

        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }
    }
}
