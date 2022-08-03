namespace LB.Core
{
    public class Provider : IProvider
    {
        private readonly string _identifier = Guid.NewGuid().ToString("D");

        public string Get() => this._identifier;
    }
}
