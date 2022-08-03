namespace LB.Core
{
    public interface IProviderPickStrategy
    {
        IProvider PickNext(IReadOnlyCollection<IProvider> providers);
    }
}