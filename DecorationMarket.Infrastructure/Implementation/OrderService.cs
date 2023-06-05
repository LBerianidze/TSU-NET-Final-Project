using DecorationMarket.Domain.DBModel;
using DecorationMarket.Domain.DTO;
using DecorationMarket.Domain.RequestModel;
using DecorationMarket.Core.Interface;
using DecorationMarket.Persistence.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Core.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }
        public async Task<DirectBuyDto> DirectBuyAsync(ClaimsPrincipal userPrincipal, ProductBuyRequestModel model)
        {
            var userId = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new Exception("Not authorized");
            }

            var product = await unitOfWork.ProductRepository.GetByIdAsync(model.ProductId);
            if (product is null)
            {
                throw new Exception("Bad product");
            }
            if (model.Quantity < 1 || model.Quantity > 10)
            {
                throw new Exception("Quantity should be between 1 and 10");
            }
            if (product.Quantity < model.Quantity)
            {
                throw new Exception("Not enough items left in stock");
            }
            Order order = new Order()
            {
                User = user,
                OrderStatus = Domain.Enum.OrderStatus.Success,
                TotalPrice = product.Price * model.Quantity,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        ProductId = product.Id,Quantity = model.Quantity,TotalPrice = product.Price  * model.Quantity
                    }
                }
            };
            await unitOfWork.OrderRepository.InsertOrder(order);
            await unitOfWork.ProductRepository.DecreaseQuantity(product.Id, -model.Quantity);
            await unitOfWork.SaveAsync();
            return new DirectBuyDto()
            {
                QuantityReserved = model.Quantity
            };
        }
        public async Task<List<Order>> GetByUserAsync(ClaimsPrincipal userPrincipal)
        {
            var userId = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new Exception("Not authorized");
            }
            return await unitOfWork.OrderRepository.GetByUserId(user.Id);
        }

    }
}
