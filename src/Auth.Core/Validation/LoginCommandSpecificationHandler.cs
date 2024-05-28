using Auth.Domain.Commands;
using Validot;

namespace Auth.Core.Validation
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
