﻿using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public string? PhotoUrl { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public byte[]? PasswordHash { get; set; }
    public bool Status { get; set; }
    public string FeelText { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
        RefreshTokens = new HashSet<RefreshToken>();
    }

    public User(string id, string firstName, string lastName, string email, byte[]? passwordSalt, byte[]? passwordHash,
        bool status, AuthenticatorType authenticatorType, string username, string? photoUrl, string feelText)
    {
        FeelText = feelText;
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
        AuthenticatorType = authenticatorType;
        Username=username;
        PhotoUrl=photoUrl;
    }
}