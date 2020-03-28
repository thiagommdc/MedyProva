using System.ComponentModel.DataAnnotations;

namespace Medy.Dominio
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var PrimeiraLetra = value.ToString()[0].ToString();
            if (!BoolSePrimeiraLetraMaiuscula(value))
                return new ValidationResult("A primeira letra do contato deve ser maiúcula.");

            return ValidationResult.Success;
        }

        public bool BoolSePrimeiraLetraMaiuscula(object value)
        {
            var PrimeiraLetra = value.ToString()[0].ToString();
            if (PrimeiraLetra != PrimeiraLetra.ToUpper())
                return false;

            return true;
        }
    }
}