namespace LB.Core
{
    public interface IProviderRegistration
    {

    }

    public class LoadBalancer : IProvider
    {
        private readonly List<IProvider> providers = new();
        private readonly Func<IReadOnlyCollection<IProvider>, IProvider> providerPickFunc;

        public uint MaxProvidersCount { get; }

        public IReadOnlyCollection<IProvider> Providers => this.providers;

        public LoadBalancer(
            uint maxProvidersCount,
            Func<IReadOnlyCollection<IProvider>, IProvider> providerPickFunc,
            params IProvider[] providers)
        {
            this.MaxProvidersCount = maxProvidersCount;
            this.providerPickFunc = providerPickFunc;
            this.RegisterProviders(providers);
        }

        public string Get()
        {
            if (this.Providers.Count == 0)
            {
                throw new LoadBalancerException($"There are no {nameof(IProvider)}s registered in the {nameof(LoadBalancer)}!");
            }

            return this.providerPickFunc(this.Providers).Get();
        }

        private void RegisterProviders(params IProvider[] providers)
        {
            if (!this.CanAddProviders(providers.Length))
            {
                var errorMessage = $"{nameof(LoadBalancer)} accepts up to {this.MaxProvidersCount} providers but" +
                    $" {providers.Length} more providers were passed and {this.Providers.Count} were already registered.";
                throw new LoadBalancerException(errorMessage);
            }

            this.providers.AddRange(providers);
        }

        private bool CanAddProviders(int count)
        {
            return this.Providers.Count + count <= this.MaxProvidersCount;
        }
    }
}