using FluentValidation;
using miliostore.Model;

namespace miliostore.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .MaximumLength(100);
            
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(p => p.Console)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.DataLancamento)
                .NotEmpty();

            RuleFor(p => p.Foto)
                .NotEmpty()
                .MaximumLength(2000);

        }
    }
}
