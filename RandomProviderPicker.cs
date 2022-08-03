namespace LB.Core
{
    public class RandomProviderPicker : IProviderPickStrategy
    {
        private readonly Random rand = new();

        public IProvider PickNext(IReadOnlyCollection<IProvider> providers)
        {
            return providers
                .OrderBy(_ => this.rand.Next())
                .First();
        }
    }
}