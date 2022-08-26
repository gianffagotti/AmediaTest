namespace AmediaTestCrud.Domain.Entities;

public partial class Role
{
    public int Id { get; set; }
    public string Description { get; private set; }
    public int Active { get; private set; }

    public virtual ICollection<User> Users { get; set; }

    public Role() { }

    public Role(string description, int active)
    {
        Description = description;
        Active = active;
    }
}