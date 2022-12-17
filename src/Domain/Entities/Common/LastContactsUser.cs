using Domain.Enums;

namespace Domain.Entities.Common;

public class LastContactsUser
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhotoUrl { get; set; }
    public string Username { get; set; }
    public string FeelText { get; set; }
    public bool Status { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }
    
    
}