// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DecorationMarket.Domain.DBModel;
using DecorationMarket.Core.Interface;
using DecorationMarket.Persistence.Interface.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace DecorationMarket.Areas.Identity.Pages.Account.Manage
{
    public class OrdersModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IOrderService orderService;

        public OrdersModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            IOrderService orderService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            this.orderService = orderService;
        }
        public List<Order> Orders { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await orderService.GetByUserAsync(User);

            return Page();
        }

    }
}
