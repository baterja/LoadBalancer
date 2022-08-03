namespace LB.Core
{
    public class RoundRobinProviderPicker : IProviderPickStrategy
    {
        private int counter = 0;

        /// <summary>
        /// Returns providers in round-robin fashion. It may return repeated providers (or skip some of them in the first round)
        /// if the collection of <paramref name="providers"/> is changed between subsequent <see cref="PickNext(IReadOnlyCollection{IProvider})"/> calls.
        /// </summary>
        public IProvider PickNext(IReadOnlyCollection<IProvider> providers)
        {
            var currentPosition = Interlocked.Increment(ref this.counter) % providers.Count;
            return providers.ElementAt(currentPosition); // TODO check minus
        }
    }
}