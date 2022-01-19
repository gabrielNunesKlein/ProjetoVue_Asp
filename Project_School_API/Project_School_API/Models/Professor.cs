using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_School_API.Models
{
    [Table("Professores")]
    public class Professor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
