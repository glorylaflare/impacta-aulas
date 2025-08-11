using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using StripeApiProto.Data;
using StripeApiProto.Models;

namespace StripeApiProto.Controllers;

[ApiController]
[Route("[controller]")]
public class StripeController : ControllerBase
{
    public readonly StripeModel _model;
    public readonly StripeDbContext _context;

    public StripeController(IOptions<StripeModel> model, StripeDbContext context)
    {
        _model = model.Value;
        _context = context;
    }

    [HttpGet("/hello")]
    public IActionResult GetHello()
    {
        return Ok("Hello World!");
    }

    [HttpPost("/checkout")]
    public async Task<IActionResult> Pay(int id) 
    {
        try
        {
            var res = await _context.Reservations.FindAsync(id);
            if (res == null) return BadRequest();

            StripeConfiguration.ApiKey = _model.SecretKey;

            var amountInCents = (long)(res.TotalPrice * 100);
            var customerOptions = new CustomerCreateOptions
            {
                Email = res.UserEmail
            };

            var customerService = new CustomerService();
            var customer = customerService.Create(customerOptions);
            var options = new SessionCreateOptions
            {
                Customer = customer.Id,
                Currency = "BRL",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = amountInCents,
                            Currency = "BRL",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = res.Title,
                                Description = res.Description,
                                Images = [ res.CoverImage ]
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                PaymentMethodTypes = new List<string> { "card", "boleto" },
                SuccessUrl = "https://localhost:7054/success",
                ExpiresAt = DateTime.UtcNow + new TimeSpan(2, 0,0)
            };

            var service = new SessionService();
            var session = service.Create(options);
            return Ok(new { url = session.Url });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }        
    }
}
