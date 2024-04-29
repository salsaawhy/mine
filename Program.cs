using System;

namespace protopkuis1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dummy data initialization
            ProductService productService = new ProductService();

            // Adding 10 products
            productService.AddProduct(new Product("Kebab Large", 15.0, 50));
            productService.AddProduct(new Product("Kebab Small", 10.0, 40));
            productService.AddProduct(new Product("Kebab Special", 20.0, 30));
            productService.AddProduct(new Product("Hotdog Large", 12.0, 45));
            productService.AddProduct(new Product("Hotdog Small", 8.0, 35));
            productService.AddProduct(new Product("Hotdog Special", 15.0, 25));
            productService.AddProduct(new Product("Burger Large", 18.0, 55));
            productService.AddProduct(new Product("Burger Small", 14.0, 60));
            productService.AddProduct(new Product("Burger Special", 25.0, 30));
            productService.AddProduct(new Product("Soft Drink", 5.0, 100));

            Console.WriteLine("Welcome to Kebab Mas Aviz!");
            Console.WriteLine("Please login to continue.");

            // User authentication
            User admin = new User("admin", "1234");
            bool authenticated = false;
            do
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                authenticated = admin.Authenticate(username, password);

                if (!authenticated)
                    Console.WriteLine("Invalid username or password. Please try again.");
            } while (!authenticated);

            Console.WriteLine("Login successful!");

            // Main menu
            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Search product by name");
                Console.WriteLine("2. Search product by price");
                Console.WriteLine("3. Sort products by stock");
                Console.WriteLine("4. add new product");
                Console.WriteLine("5. Remove product");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter your choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("keyword: ");
                        string keyword = Console.ReadLine();
                        var productsByName = productService.SearchByName(keyword);
                        DisplayProducts(productsByName);
                        break;
                    case "2":
                        Console.Write("minimum price: ");
                        double minPrice = Convert.ToDouble(Console.ReadLine());
                        Console.Write("maximum price: ");
                        double maxPrice = Convert.ToDouble(Console.ReadLine());
                        var productsByPriceRange = productService.SearchByPriceRange(minPrice, maxPrice);
                        DisplayProducts(productsByPriceRange);
                        break;
                    case "3":
                        var productsByStock = productService.SortByStock();
                        DisplayProducts(productsByStock);
                        break;
                    case "4":
                        Console.Write("product name: ");
                        string productName = Console.ReadLine();
                        Console.Write("product price: ");
                        double productPrice = Convert.ToDouble(Console.ReadLine());
                        Console.Write("product stock: ");
                        int productStock = Convert.ToInt32(Console.ReadLine());
                        productService.AddProduct(new Product(productName, productPrice, productStock));
                        Console.WriteLine("Product added successfully!");
                        break;
                    case "5":
                        Console.Write("remove: ");
                        string productToRemove = Console.ReadLine();
                        var product = productService.SearchByName(productToRemove).FirstOrDefault();
                        if (product != null)
                        {
                            productService.RemoveProduct(product);
                            Console.WriteLine("Product removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Product not found!");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

        static void DisplayProducts(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}
