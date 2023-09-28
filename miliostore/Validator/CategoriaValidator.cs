using FluentValidation;
using miliostore.Model;

namespace miliostore.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(t => t.Tipo)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
