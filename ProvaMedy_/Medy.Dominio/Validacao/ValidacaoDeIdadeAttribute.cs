using System.ComponentModel.DataAnnotations;
using Medy.Util;
using System;

namespace Medy.Dominio
{
    public class ValidacaoDeIdadeAttribute : ValidationAttribute
    {       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _RetornaIdade = new RetornaIdade();

            if (value == null)
                return ValidationResult.Success;

            int IdadeEmAnos = _RetornaIdade.Idade(Convert.ToDateTime(value));

            if (IdadeEmAnos > 120 || IdadeEmAnos < 10)
                return new ValidationResult("A data de nascimento inserida é inválida.");

            return ValidationResult.Success;
        }
    }
}