using QuestionsApp.Web.DB;

namespace QuestionsApp.Web.Handlers.Commands;
using MediatR;

public class AskQuestionRequest :IRequest<IResult>
{
    public string Content { get; set; } = "";
}

public class AskQuestionCommand : IRequestHandler<AskQuestionRequest, IResult>
{
	public async Task<IResult> Handle(AskQuestionRequest request, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(request.Content))
			return Results.BadRequest("The Question Content can not be empty");

		_context.Questions.Add(new QuestionDb { Content = request.Content });
		await _context.SaveChangesAsync(cancellationToken);
		return Results.Ok();
	}
	
	private readonly QuestionsContext _context;
	public AskQuestionCommand(QuestionsContext context)
	{
		_context = context;
	}
}