using Microsoft.AspNetCore.SignalR;
using Northwind.Chat.Models;

namespace Northwind.SingalR.Service.Hubs;

public class ChatHub : Hub
{
    private static Dictionary<string, UserModel> Users = new();
    public async Task Register(UserModel newUser)
    {
        UserModel user;
        string action = "registered as a new user";
        if (Users.ContainsKey(newUser.Name))
        {
            user = Users[newUser.Name];
            if (user.Groups is not null)
            {
            }
        }
    }
}
