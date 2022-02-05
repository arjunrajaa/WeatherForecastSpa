using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherForecast.Accessor.Interface;
using WeatherForecast.Common;

namespace WeatherForecast.Accessor
{
    public class InMemoryUserAccessor : IUserAccessor
    {
        private List<UserModel> _users;
        public InMemoryUserAccessor()
        {
            _users = new List<UserModel>()
            {
                new UserModel()
                {
                    Username =  "arjun",
                    Password = "arjun",
                    EmailAddress = "arjunrajaa@gmail.com"
                },
                new UserModel()
                {
                    Username =  "test123",
                    Password = "test123",
                    EmailAddress = "test123@testdomain.com"
                }
            };
        }

        public UserModel GetUser(UserModel userModel)
        {
            var foundUser = _users.SingleOrDefault(u => u.Username.Equals(userModel.Username) && u.Password.Equals(userModel.Password));
            return foundUser;
        }

    }
}
