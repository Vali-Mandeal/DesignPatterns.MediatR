using DesignPatterns.MediatR.Entities;

namespace DesignPatterns.MediatR.Helpers
{
    public static class InMemory
    {
        public static Product GetOneTestProduct()
        {
            return new()
            {
                Name = "testProduct",
                Image = new Image
                {
                    Name = "testImage",
                    Data = new byte[64]
                }
            };
        }
    }
}
