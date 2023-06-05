using DecorationMarket.Domain.DBModel;
using DecorationMarket.Domain.DTO;
using DecorationMarket.Domain.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Core.Interface
{
    public interface IOrderService
    {
        Task<DirectBuyDto> DirectBuyAsync(ClaimsPrincipal user, ProductBuyRequestModel model);
        Task<List<Order>> GetByUserAsync(ClaimsPrincipal user);
    }
}
