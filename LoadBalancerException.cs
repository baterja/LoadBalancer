using System.Runtime.Serialization;

namespace LB.Core
{
    [Serializable]
    public class LoadBalancerException : Exception
    {
        public LoadBalancerException()
        {
        }

        public LoadBalancerException(string? message) : base(message)
        {
        }

        public LoadBalancerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LoadBalancerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}