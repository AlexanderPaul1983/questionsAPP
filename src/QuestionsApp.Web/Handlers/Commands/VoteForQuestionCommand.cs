namespace QuestionsApp.Web.Handlers.Commands;

using MediatR;
public class VoteForQuestionCommand : IRequestHandler<VoteForQuestionRequest, IResult>
{
    public Task<IResult> Handle(VoteForQuestionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}