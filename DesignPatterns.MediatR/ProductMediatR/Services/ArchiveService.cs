using System;
using DesignPatterns.MediatR.Entities;

namespace DesignPatterns.MediatR.ProductMediatR.Services
{
    // Concrete components don't talk to each other. They have only
    // one communication channel, which is sending notifications to
    // the mediator.
    public class ArchiveService : ServiceBase
    {
        public void ProcessImage(Image image)
        {
            Console.WriteLine("Archive Service: processing image");
        }
    }
}
