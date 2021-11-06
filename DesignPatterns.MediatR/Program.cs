using System;
using DesignPatterns.MediatR.ProductMediatR;
using DesignPatterns.MediatR.ProductMediatR.Services;
using DesignPatterns.MediatR.Helpers;

namespace DesignPatterns.MediatR
{
    class Program
    {
        private static ArchiveService _archiveService;
        private static ColdStorageService _coldStorageService;
        private static HotStorageService _hotStorageService;
        private static ProductService _productService;

        static void Main()
        {
            InitServices();

            var product = InMemory.GetOneTestProduct();

            Console.WriteLine("Client calls CreateProduct() in Product Service.");
            _productService.CreateProduct(product);
        }

        private static void InitServices()
        {
            _archiveService = new ArchiveService();
            _coldStorageService = new ColdStorageService();
            _hotStorageService = new HotStorageService();
            _productService = new ProductService();

            new ConcreteMediatR(_archiveService, _coldStorageService, _hotStorageService, _productService);
        }
    }
}
