using generic_list_task_5;
using hometask_practice_2;

public static class Program
{
    public static void Main(string[] args)
    {
        Shop shop = new Shop();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Sell Product");
            Console.WriteLine("3. Show Products");
            Console.WriteLine("4. Show Total Income");
            Console.WriteLine("0. Exit");

            string option = Console.ReadLine();
            int enumOption;

            bool isTrueOptionFormat = int.TryParse(option, out enumOption);

            switch (enumOption)
            {
                case (int) Options.AddProduct:
                    Console.WriteLine();
                    Console.WriteLine("Choose product type: ");
                    Console.WriteLine("1. Tea");
                    Console.WriteLine("2. Coffee");
                    string type = Console.ReadLine();
                    int typeFormat;
                    bool isTrueTypeFormat = int.TryParse(type, out typeFormat);

                    Console.WriteLine("Enter product name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter product price: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter product count: ");
                    int count = Convert.ToInt32(Console.ReadLine());

                    while (true)
                    {
                        switch (typeFormat)
                        {
                            case (int)Types.Tea:
                                shop.AddProduct(new Tea(name, count, price, "Tea"));
                                break;
                            case (int)Types.Coffee:
                                shop.AddProduct(new Coffee(name, count, price, "Coffee"));
                                break;
                            default:
                                Console.WriteLine("Choose correct type");
                                break;
                        }
                        break;
                    }

                    break;
                case (int) Options.SellProduct:
                    Console.WriteLine();
                    Console.WriteLine("Enter product name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter product count: ");
                    count = Convert.ToInt32(Console.ReadLine());

                    shop.SellProduct(name, count);
                    break;
                case (int) Options.ShowProduct:
                    Console.WriteLine();
                    shop.DisplayAvailableProducts();
                    break;
                case (int) Options.ShowTotalIncome:
                    Console.WriteLine();
                    shop.ShowIncome();
                    break;
                case (int) Options.Exit:
                    return;
                default:
                    Console.WriteLine("Choose right option");
                    break;
            }
        }

    }
}