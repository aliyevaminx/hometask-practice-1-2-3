namespace generic_list_task_5
{
    internal class Shop
    {
        List<Product> products = new List<Product>();

        private double totalIncome;

        public void AddProduct(Product product)
        {
            if (!products.Any(p => p.Name == product.Name))
            {
                products.Add(product);
                Console.WriteLine("Product added successfully");
            }
            else
                Console.WriteLine($"{product.Name} already exists");
        }

        public void SellProduct(string name, int sellCount)
        {
            var product = products.FirstOrDefault(p => p.Name == name);

            if (product != null)
            {
                if (product.Count >= sellCount)
                {
                    product.Count -= sellCount;
                    totalIncome += sellCount * product.Price;

                    if (product.Count == 0)
                    {
                        products.Remove(product);
                    }
                }
                else
                    Console.WriteLine($"There is not enough {product.Name} in stock");
            }
            else
                Console.WriteLine($"{name} doesn't exist");
        }

        public void DisplayAvailableProducts()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} Price: {products[i].Price} Count: {products[i].Count} Type: {products[i].Type}");
            }
        }
        public void ShowIncome()
        {
            Console.WriteLine($"Total Income: {totalIncome}");
        }
    }
}
