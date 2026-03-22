namespace C_.Net_Assignment_4
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public string Category;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Product>()
            {
                new Product{Id=1,Name="Laptop",Price=50000,Category="Electronics"},
                new Product{Id=2,Name="Phone",Price=20000,Category="Electronics"},
                new Product{Id=3,Name="Shoes",Price=1500,Category="Fashion"}
            };

            list.ForEach(x => Console.WriteLine(x.Name));

            list.Where(x => x.Price > 1000).ToList()
                .ForEach(x => Console.WriteLine(x.Name));

            list.OrderBy(x => x.Price).ToList()
                .ForEach(x => Console.WriteLine(x.Price));

            list.OrderByDescending(x => x.Price).ToList()
                .ForEach(x => Console.WriteLine(x.Price));

            list.RemoveAll(x => x.Id == 3);

            list.Where(x => x.Category == "Electronics").ToList()
                .ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
