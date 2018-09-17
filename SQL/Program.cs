using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMainMenu();
            
        }

        private static void ShowMainMenu()
        {
            MyDBWorker.GetAllProducts();
            bool isActive = true;
            do
            {
                Console.WriteLine("\nМеню: \n1) Показать товары \n2) Показать список поставщиков \n3) Показать список категорий \n4) Купить товар \n5) Показать информацию о заказе \n6) Выход из приложения");
                Console.Write("\nВыберите номер действия: ");
                switch (GetEnteredNum())
                {
                    case 1: {
                            MyDBWorker.GetAllProducts(); break;
                        }
                    case 2: {                                
                                ShowSupplierMenu();
                                break;
                        }
                    case 3: {                            
                            ShowTagMenu();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("\nВведите номер товара: ");
                            MyDBWorker.Buy(GetEnteredNum()); break;
                        }
                    case 5: {
                            Console.Write("\nВведите номер заказа: ");
                            MyDBWorker.GetOrder(GetEnteredNum()); break;
                        }
                    case 6:
                        {
                            isActive = false;
                            break;
                        }
                    default:
                        break;
                }
            } while (isActive);
        }

        private static void ShowSupplierMenu()
        {
            MyDBWorker.GetSuppliers();
            Console.WriteLine("\nМеню \n1) Показать товары поставщика \nДля того, чтобы вернуться в главное меню введите любое число");
            Console.WriteLine("\nВыберите действие:");
            switch (GetEnteredNum())
            {
                case 1: {
                        Console.Write("\nВведите номер поставщика: ");
                        MyDBWorker.GetProductsBySupplier(GetEnteredNum());
                        ShowProductsMenu();
                        break;
                    }
                default:
                    break;
            }
        }

        private static void ShowTagMenu()
        {
            MyDBWorker.GetTags();
            Console.WriteLine("\nМеню \n1) Показать товары в категории \nДля того, чтобы вернуться в главное меню введите любое число");
            Console.WriteLine("\nВыберите действие:");
            switch (GetEnteredNum())
            {
                case 1:
                    {
                        Console.Write("\nВведите номер категории: ");
                        MyDBWorker.GetProductsByTag(GetEnteredNum());
                        ShowProductsMenu();
                        break;
                    }
                default:
                    break;
            }
        }

        private static void ShowProductsMenu()
        {
            Console.WriteLine("Меню: \n1)Купить товар \nДля того, чтобы вернуться в главное меню введите любое число");
            switch (GetEnteredNum())
            {
                case 1:
                    {
                        Console.Write("\nВведите номер товара: ");
                        MyDBWorker.Buy(GetEnteredNum());
                        break;
                    }
                default:
                    break;
            }
        }

        private static int GetEnteredNum()
        {
            int value;
            bool result = int.TryParse(Console.ReadLine(), out value);
            while (!result || value <= 0)
            {
                Console.Write("\nВведено некорректное значение. Введите целое число: ");
                result = int.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }
    }
}
