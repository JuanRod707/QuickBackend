using System.Collections.Generic;
using QuickBackend.Domain;

namespace QuickBackend.Services
{
    public interface Users
    {
        Dictionary<int, User> Users { get; }
        void SetCurrency(int userId, int value);
        AddUserMessage Add(AddUserRequest request);
        int Delete(int id);
    }
}