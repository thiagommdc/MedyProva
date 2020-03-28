using System;
using System.ComponentModel.DataAnnotations;

namespace Medy.Dominio
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        [PrimeiraLetraMaiuscula]
        public string Nome { get; set; }    
        [Required]
        [ValidacaoDeIdade]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }

        

    }
}