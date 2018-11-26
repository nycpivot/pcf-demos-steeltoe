using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public class CircuitBreakerCommand : HystrixCommand<CloudFoundryApplicationOptions>
    {
        private readonly ICircuitBreakerService circuitBreakerService;

        public CircuitBreakerCommand(
            IHystrixCommandOptions hystrixCommandOptions,
            ICircuitBreakerService circuitBreakerService) : base(hystrixCommandOptions)
        {
            this.circuitBreakerService = circuitBreakerService;
        }
    }
}