namespace Application.Features.Users.Dtos;

public class GetUserByIdDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhotoUrl { get; set; }
}