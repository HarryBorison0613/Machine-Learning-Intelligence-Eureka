using MediatR;

namespace FinanceProcessor.Application.Commands.Customer.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}