using WeatherForecast.Common;

namespace WeatherForecast.Accessor.Interface
{
    public interface IUserAccessor
    {
        UserModel GetUser(UserModel userModel);
    }
}