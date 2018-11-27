using Pcf.Demos.Steeltoe.Web.Models;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public class CircuitBreakerCommand : HystrixCommand<ServiceDetailsModel>
    {
        private readonly ICircuitBreakerService circuitBreakerService;

        public CircuitBreakerCommand(
            IHystrixCommandOptions hystrixCommandOptions,
            ICircuitBreakerService circuitBreakerService) : base(hystrixCommandOptions)
        {
            this.circuitBreakerService = circuitBreakerService;
        }

        public async Task<ServiceDetailsModel> GetServiceDetails()
        {
            return await ExecuteAsync();
        }

        protected override async Task<ServiceDetailsModel> RunAsync()
        {
            var result = await circuitBreakerService.GetServiceDetails();

            return result;
        }

        protected override async Task<ServiceDetailsModel> RunFallbackAsync()
        {
            var result = await circuitBreakerService.GetServiceDetailsFallback();

            return result;
        }
    }
}