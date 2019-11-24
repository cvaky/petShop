using Eshop.Domain.Service;
using Eshop.Domain.Domain;
using Eshop.Entity.Entity;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Eshop.Domain.Validators
{
    public class OrderValidator : AbstractValidator<OrderViewModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public OrderValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleFor(x => x.TotalPrice).GreaterThan(0);
            RuleFor(x => x.ProductCount).GreaterThan(0);
            RuleFor(x => x)
                .Custom(async (order, context) =>
                {
                    var product = await getProduct(order.ProductId);
                    if (order.TotalPrice != order.ProductCount * product.Price)
                    {
                        context.AddFailure("Wrong total price");
                    }
                });
        }

        private async Task<ProductViewModel> getProduct(int id)
        {
            var stateRepository = _serviceProvider.GetRequiredService<ProductService<ProductViewModel,Product>>();
            return await stateRepository.GetSingle(id);
        }
    }
}
