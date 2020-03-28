using System;

namespace Medy.Util
{
    public class RetornaIdade : IRetornaIdade
    {
        public int Idade(DateTime DataNascimento)
        {
            int IdadeEmAnos = DateTime.Now.Year - DataNascimento.Year;
            if (DataNascimento.Month > DateTime.Now.Month | DataNascimento.Month == DateTime.Now.Month & DataNascimento.Day > DateTime.Now.Day)
            {
                IdadeEmAnos = IdadeEmAnos - 1;
            }

            return IdadeEmAnos;
            
        }
    }
}