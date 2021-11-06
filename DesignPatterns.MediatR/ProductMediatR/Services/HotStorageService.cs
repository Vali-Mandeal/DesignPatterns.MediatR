using System;
using DesignPatterns.MediatR.Entities;

namespace DesignPatterns.MediatR.ProductMediatR.Services
{
    // Concrete components don't talk to each other. They have only
    // one communication channel, which is sending notifications to
    // the mediator.
    public class HotStorageService : ServiceBase
    {
        public void Save(Image image)
        {
            Console.WriteLine("HotStorageService: saving image...");
        }
    }
}
