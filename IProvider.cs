namespace LB.Core
{
    public interface IProvider
    {
        /// <summary>
        /// Retrieves an unique identifier of the <see cref="IProvider"/> instance.
        /// </summary>
        /// <returns></returns>
        string Get();
    }
}
