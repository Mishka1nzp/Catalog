using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class MyDBWorker
    {
        static string connectionString = @"Data Source=DESKTOP-1R4Q7TE;Initial Catalog=Catalog;Integrated Security=True";        

        private static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public static void GetAllProducts()
        {
            string sqlExpression = "GetAllProducts";
            Drawer.DrawProducts(GetTable(sqlExpression).Rows);
        }

        public static void GetProductsBySupplier(int supplier_ID)
        {
            string sqlExpression = "GetProductsBySupplier";

            SqlParameter param = new SqlParameter
            {
                ParameterName = "@ID_Supplier",
                Value = supplier_ID
            };
            Drawer.DrawProducts(GetTable(sqlExpression, param).Rows);
        }

        public static void GetProductsByTag(int tag_ID)
        {
            string sqlExpression = "GetProductsByTag";

            SqlParameter param = new SqlParameter
            {
                ParameterName = "@ID_Tag",
                Value = tag_ID
            };
            Drawer.DrawProducts(GetTable(sqlExpression, param).Rows);            
        }

        public static void GetSuppliers()
        {
            string sqlExpression = "GetSuppliers";
            Drawer.DrawSuppliers(GetTable(sqlExpression).Rows);
        }

        public static void GetTags()
        {
            string sqlExpression = "GetTags";
            Drawer.DrawTags(GetTable(sqlExpression).Rows);
        }

        public static void Buy(int product_ID)
        {
            string sqlExpression = "Buy";
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@ID_Product",
                Value = product_ID
            };

            Drawer.ShowOrder(GetTable(sqlExpression, param).Rows);
        }

        public static void GetOrder(int order_ID)
        {
            string sqlExpression = "GetOrder";
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@ID_Order",
                Value = order_ID
            };

            Drawer.DrawOrder(GetTable(sqlExpression, param).Rows);
        }

        private static DataTable GetTable(string sqlExpression, params SqlParameter[] sqlParams)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = Connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (SqlParameter sqlParam in sqlParams)
                {
                    command.Parameters.Add(sqlParam);
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }

            return dt;

        }
    }
}
