namespace TheNuggetList.Domain.Services
{
    public interface IServiceLocator
    {
        T Get<T>();
    }
}