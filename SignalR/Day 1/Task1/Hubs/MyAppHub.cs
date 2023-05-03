using app.Data;
using app.Models;
using Microsoft.AspNetCore.SignalR;

namespace app.Hubs
{
    public class MyAppHub :Hub
    {
        private readonly appContext _context;
        public MyAppHub(appContext context)
        {
            _context = context;
        }
        //Comments
        public async Task PostComment(int prodId, string comment)
        {
            _context.Comment.Add(new Comment() { ProductId=prodId,Text=comment});
            _context.SaveChanges();
            await Console.Out.WriteLineAsync(comment);
            await Clients.All.SendAsync("ReciveComment", prodId, comment);
        }
        //Products
        public async Task BuyProd(int prodId)
        {
            _context.Product.Find(prodId).Quantity -= 1;
            _context.SaveChanges();

            await Clients.All.SendAsync("UpdateQuantity", prodId, _context.Product.Find(prodId)?.Quantity??0);
        }
        
    }
}
