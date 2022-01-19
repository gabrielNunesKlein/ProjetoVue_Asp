using Microsoft.EntityFrameworkCore;
using Project_School_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_School_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                .HasData(new List<Professor>()
                {
                    new Professor()
                    {
                        Id = 1,
                        Nome = "Viniccius"
                    },
                    new Professor()
                    {
                        Id = 2,
                        Nome = "Pedro"
                    },
                    new Professor()
                    {
                        Id = 3,
                        Nome = "Julianna"
                    }
                });
            
            builder.Entity<Aluno>()
                .HasData(new List<Aluno>()
                {
                    new Aluno()
                    {
                        Id = 1,
                        Nome = "Gabriel",
                        SobreNome = "Henrique",
                        DataNasc = "12/08/1987",
                        ProfessorId = 1
                    },
                    new Aluno()
                    {
                        Id = 2,
                        Nome = "Pedro",
                        SobreNome = "Oliveira",
                        DataNasc = "25/09/1996",
                        ProfessorId = 2
                    },
                    new Aluno()
                    {
                        Id = 3,
                        Nome = "Julianna",
                        SobreNome = "Caetano",
                        DataNasc = "15/08/1998",
                        ProfessorId = 3
                    }
                });
        }*/
    }
}
