using System.Net;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly DatabaseContext DBContext;

    public UserController(DatabaseContext DBContext)
    {
        this.DBContext = DBContext;
    }


    [HttpPost("InsertUser")]
    public async Task<HttpStatusCode> InsertUser(UserDTO User)
    {
        var entity = new User()
        {
            Id = User.Id,
            FirstName = User.FirstName,
            LastName = User.LastName,
            UserName = User.UserName,
            Password = User.Password,
            CreatedAt = User.CreatedAt
        };

        DBContext.Users.Add(entity);
        await DBContext.SaveChangesAsync();

        return HttpStatusCode.Created;
    }
}