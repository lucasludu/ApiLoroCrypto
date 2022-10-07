namespace ApiLoroCrypto.Repository.Interfaces
{
    public interface IUnitofWork: IDisposable
    {
        IUserRepository UserRepository { get; }
        Task SaveChangesAsync();

    }
}
