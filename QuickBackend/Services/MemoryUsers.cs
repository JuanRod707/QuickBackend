using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using QuickBackend.Domain;

namespace QuickBackend.Services
{
    public class MemoryUsers : Users
    {
        public Dictionary<int, User> Users => users;
        
        Dictionary<int, User> users;
        
        public MemoryUsers()
        {
            users = new Dictionary<int, User>();
            var user1 = new User { Id = 1, Name = "jsmith", Currency = 100};
            var user2 = new User { Id = 2, Name = "agnatt", Currency = 100};
            var user3 = new User { Id = 3, Name = "kmann", Currency = 200};
            
            users.Add(user1.Id, user1);
            users.Add(user2.Id, user2);
            users.Add(user3.Id, user3);
        }

        public void SetCurrency(int userId, int value) => users[userId].Currency = value;

        public AddUserMessage Add(AddUserRequest request)
        {
            if (users.Values.Select(u => u.Name).Contains(request.Name))
                return new AddUserMessage
                {
                    Success = false,
                    Message = "User name already exists."
                };
                
            var id = users.Keys.Max() + 1;
            users.Add(id, new User {Id = id, Name = request.Name, Currency = request.Currency});
            
            return new AddUserMessage
            {
                UserId = id,
                Success = true, 
                Message = $"User created successfully with id {id}."
            };
        }

        public int Delete(int id)
        {
            if (!users.ContainsKey(id))
                return StatusCodes.Status404NotFound;
            
            users.Remove(id);
            return StatusCodes.Status200OK;
        }
    }
}