namespace Application.Features.Messages.Dtos;

public class GetAllMessageByUserIdDto
{
    public string Id { get; set; }
    public string ReceiverUserId { get; set; }
    public string SenderUserId { get; set; }
    public string Message { get; set; }
}