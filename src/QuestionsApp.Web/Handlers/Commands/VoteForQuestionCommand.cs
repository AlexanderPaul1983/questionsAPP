using Microsoft.EntityFrameworkCore;
using QuestionsApp.Web.DB;

namespace QuestionsApp.Web.Handlers.Commands;
using MediatR;

public class VoteForQuestionRequest : IRequest<IResult>
{
    public int QuestionId { get; set; }
}

public class VoteForQuestionCommand : IRequestHandler<VoteForQuestionRequest, IResult>
{
    public async Task<IResult> Handle(VoteForQuestionRequest request, CancellationToken cancellationToken)
    {
        if (!await _context.Questions.AnyAsync(q => q.Id == request.QuestionId, cancellationToken))
            return Results.BadRequest("Invalid Question Id");

        _context.Votes.Add(new VoteDb { QuestionId = request.QuestionId });
        await _context.SaveChangesAsync(cancellationToken);
        return Results.Ok();
    }
    
    private readonly QuestionsContext _context;
    public VoteForQuestionCommand(QuestionsContext context)
    {
        _context = context;
    }
}
