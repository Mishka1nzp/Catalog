using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class Drawer
    {
        public static void DrawProducts(System.Data.DataRowCollection rows)
        {
            var formatString = string.Format("{{0, -5}}|{{1, -20}}|{{2, -20}}|{{3, -20}}|{{4, -10}}");
            Console.WriteLine(formatString, "ID", "Название", "Цена", "Поставщик", "Категория");
            foreach (DataRow row in rows)
            {
                Console.WriteLine(formatString, 
                    row["ID"],
                    row["Name"],
                    row["Price"],
                    row["Supplier"],
                    row["Tag"]);
            }            
        }

        public static void DrawSuppliers(System.Data.DataRowCollection rows)
        {
            var formatString = string.Format("{{0, -5}}|{{1, -20}}");
            Console.WriteLine(formatString, "ID", "Поставщик");
            foreach (DataRow row in rows)
            {
                Console.WriteLine(formatString,
                    row["ID"],
                    row["Name"]);
            }
        }

        public static void DrawTags(System.Data.DataRowCollection rows)
        {
            var formatString = string.Format("{{0, -5}}|{{1, -20}}");
            Console.WriteLine(formatString, "ID", "Категория");
            foreach (DataRow row in rows)
            {
                Console.WriteLine(formatString,
                    row["ID"],
                    row["Name"]);
            }
        }

        public static void DrawOrder(System.Data.DataRowCollection rows)
        {
            var formatString = string.Format("{{0, -20}}|{{1, -20}}|{{2, -20}}|{{3, -20}}|{{4, -20}}");
            Console.WriteLine(formatString, "Название товара", "Поставщик", "Категория", "Цена", "Дата" );
            foreach (DataRow row in rows)
            {
                Console.WriteLine(formatString,
                    row["Name"],
                    row["Supplier"],
                    row["Tag"],
                    row["Price"],
                    row["Date"]);
            }
        }

        public static void ShowOrder(System.Data.DataRowCollection rows)
        {
            if (rows[0]["Response"].ToString() == "True")
            {
                Console.WriteLine($"Номер вашего заказа: {rows[0]["Order_ID"]}");
            }
            else
            {
                Console.WriteLine("Сожалеем, но товар распродан");
            }
        }
    }
}
