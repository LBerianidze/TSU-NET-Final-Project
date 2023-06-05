using DecorationMarket.Domain.DBModel;
using DecorationMarket.Domain.RequestModel;
using DecorationMarket.Domain.ViewModels;
using DecorationMarket.Core.Interface;
using DecorationMarket.Models;
using DecorationMarket.Persistence.Interface.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace DecorationMarket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        /// <summary>
        /// წესით cart-ი უნდა იყოს დამატებული რომ ერთ შეკვეთაში ბევრი განსხვავებული ნივთის ჩამატება შეგვეძლოს, მაგრამ სადემონსტრაციოდ წავა :))
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DirectBuy([FromBody] ProductBuyRequestModel model)
        {
            return Ok(await orderService.DirectBuyAsync(User, model));
        }

    }
}