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
                .MinimumLength(5)
                .MaximumLength(100);
            
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(1000);

            RuleFor(p => p.Console)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(p => p.DataLancamento)
                .NotEmpty();

            RuleFor(p => p.Foto)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(2000);

        }
    }
}
