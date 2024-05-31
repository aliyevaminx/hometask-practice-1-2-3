namespace generic_list_task_5
{
    internal class Product
    {
        private string name;
        private int count;
        private double price;
        private string type;

        public string Name { get; }
        public int Count { get; set; }
        public double Price { get; }
        public string Type { get; }

        public Product(string name, int count, double price, string type)
        {
            Name = name;
            Count = count;
            Price = price;
            Type = type;
        }


    }
}
