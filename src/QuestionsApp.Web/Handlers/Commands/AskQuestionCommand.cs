namespace QuestionsApp.Web.Handlers.Commands;
using MediatR;

public class AskQuestionCommand : IRequestHandler<AskQuestionRequest, IResult>
{
    public Task<IResult> Handle(AskQuestionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}