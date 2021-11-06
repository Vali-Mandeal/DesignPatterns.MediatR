using System;
using DesignPatterns.MediatR.Entities;

namespace DesignPatterns.MediatR.ProductMediatR.Services
{
    // Concrete components don't talk to each other. They have only
    // one communication channel, which is sending notifications to
    // the mediator.
    public class ProductService : ServiceBase
    {
        public void CreateProduct(Product product)
        {
            Console.WriteLine("Product Service: creating product.");

            _mediator.Notify(this, product.Image, EventType.ArchiveImage);
            _mediator.Notify(this, product.Image, EventType.SaveInColdStorage);
            _mediator.Notify(this, product.Image, EventType.SaveInHotStorage);

            Console.WriteLine("\nProduct Service: saving product in database.");
        }
    }
}
