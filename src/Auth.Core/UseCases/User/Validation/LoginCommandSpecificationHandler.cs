using Auth.Domain.UseCases.User.Commands;
using Validot;

namespace Auth.Core.UseCases.User.Validation
{
    internal sealed class LoginCommandSpecificationHandler : ISpecificationHolder<LoginCommand>
    {
        public Specification<LoginCommand> Specification { get; }

        public LoginCommandSpecificationHandler()
        {
            Specification<LoginCommand> loginCommandSpecification = s => s
                .Member(m => m.Username, m => m
                    .NotEmpty()
                    .NotWhiteSpace())
                .Member(m => m.Password, m => m
                    .NotEmpty()
                    .NotWhiteSpace());

            Specification = loginCommandSpecification;
        }
    }
}
