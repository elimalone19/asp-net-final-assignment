using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using asp_net_fifth_assignment.Infrastructure;
namespace asp_net_fifth_assignment.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart Cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            Cart.Session = session;
            return Cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Bowlers book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Bowlers book)
        {
            base.RemoveLine(book);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
