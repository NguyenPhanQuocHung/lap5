using Microsoft.AspNetCore.Mvc;
using lap5.Events;
using lap5.Publishing;

namespace lap5.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly Publisher _publisher;

        public OrderController(Publisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderPlacedEvent orderEvent)
        {
            orderEvent.OrderId = Guid.NewGuid();

            _publisher.Publish(
       "ecommerce.topic",
       "order.created",
       orderEvent
               );

            return Ok("Order created and message sent");
        }
    }
    }
