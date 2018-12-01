using Pcf.Demos.Steeltoe.Web.Models;
using Steeltoe.CircuitBreaker.Hystrix;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public class CircuitBreakerCommand : HystrixCommand<IEnumerable<ProductViewModel>>
    {
        private readonly ICircuitBreakerProductService circuitBreakerService;

        public CircuitBreakerCommand(
            IHystrixCommandOptions hystrixCommandOptions,
            ICircuitBreakerProductService circuitBreakerService) : base(hystrixCommandOptions)
        {
            this.circuitBreakerService = circuitBreakerService;
        }

        public async Task<IEnumerable<ProductViewModel>> GetServiceDetails()
        {
            return await ExecuteAsync();
        }

        protected override async Task<IEnumerable<ProductViewModel>> RunAsync()
        {
            var result = await circuitBreakerService.GetServiceDetails();

            return result;
        }

        protected override async Task<IEnumerable<ProductViewModel>> RunFallbackAsync()
        {
            var result = await circuitBreakerService.GetServiceDetailsFallback();

            return result;
        }
    }
}