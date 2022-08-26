﻿namespace AmediaTestCrud.Domain.Entities;

public partial class User
{
    public int Id { get; set; }
    public string UserName { get; private set;}
    public string Password { get; private set;}
    public string FirstName { get; private set;}
    public string LastName { get; private set;}
    public string Document { get; private set;}
    public int RoleId { get; private set;}
    public int Active { get; private set;}

    public virtual Role Role { get; private set;}

    public User() { }
    public User(string userName,
                string password,
                string firstName,
                string lastName,
                string document,
                int roleId,
                int active)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        RoleId = roleId;
        Active = active;
    }

    public bool IsValidPassword(string password)
        => this.Password == password;

    public bool IsActive()
        => this.Active == 1;
}