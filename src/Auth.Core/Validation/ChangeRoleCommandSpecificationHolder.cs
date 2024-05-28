using Auth.Domain.Commands;
using Validot;

namespace Auth.Core.Validation
{
    internal sealed class ChangeRoleCommandSpecificationHolder : ISpecificationHolder<ChangeRoleCommand>
    {
        public Specification<ChangeRoleCommand> Specification { get; }

        public ChangeRoleCommandSpecificationHolder()
        {
            Specification<ChangeRoleCommand> changeRoleCommandSpecification = s => s
                .Member(m => m.RoleName, m => m
                    .NotEmpty()
                    .NotWhiteSpace())
                .Member(m=>m.UserName, m=> m
                    .NotEmpty()
                    .NotWhiteSpace());

            Specification = changeRoleCommandSpecification;
        }
    }
}
