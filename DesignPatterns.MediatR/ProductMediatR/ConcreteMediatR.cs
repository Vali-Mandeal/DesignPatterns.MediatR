using System;
using DesignPatterns.MediatR.Entities;
using DesignPatterns.MediatR.ProductMediatR.Services;

namespace DesignPatterns.MediatR.ProductMediatR
{
    // The concrete mediator class. The intertwined web of
    // connections between individual components has been untangled
    // and moved into the mediator.
    public class ConcreteMediatR : IMediatR
    {
        private ArchiveService _archiveService;
        private ColdStorageService _coldStorageService;
        private HotStorageService _hotStorageService;
        private ProductService _productService;

        public ConcreteMediatR(
            ArchiveService archiveService, 
            ColdStorageService coldStorageService, 
            HotStorageService hotStorageService, 
            ProductService productService)
        {
            // Creates all component objects and pass the current
            // mediator into their constructors to establish links.
            _archiveService = archiveService;
            _archiveService.SetMediator(this);

            _coldStorageService = coldStorageService;
            _coldStorageService.SetMediator(this);

            _hotStorageService = hotStorageService;
            _hotStorageService.SetMediator(this);

            _productService = productService;
            _productService.SetMediator(this);
        }

        // When something happens with a component, it notifies the
        // mediator. Upon receiving a notification, the mediator may
        // do something on its own or pass the request to another
        // component.
        public void Notify(object sender, object data, EventType eventType)
        {
            var stringEventType = eventType.ToString();

            // There are various ways to get rid of "the ugly switch"
            // However, this is beyond the scope of this exercise
            switch (eventType)
            {
                case EventType.CreateProduct:
                {
                    LogStatus(stringEventType, nameof(_productService));
                    _productService.CreateProduct(data as Product);
                    break;
                }
                case EventType.ArchiveImage:
                {
                    LogStatus(stringEventType, nameof(_archiveService));
                    _archiveService.ProcessImage(data as Image);
                    break;
                }
                case EventType.SaveInColdStorage:
                {
                    LogStatus(stringEventType, nameof(_coldStorageService));
                    _coldStorageService.Save(data as Image);
                    break;
                }

                case EventType.SaveInHotStorage:
                {
                    LogStatus(stringEventType, nameof(_hotStorageService));
                    _hotStorageService.Save(data as Image);
                    break;
                }
            }
        }

        // Logging each step for demonstration
        private static void LogStatus(string eventType, string service)
        {
            Console.WriteLine($"\n- MediatR reacts on {eventType} by calling {service}:");
        }
    }
}
