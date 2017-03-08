using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class Startup
    {
        public async Task<object> Invoke(dynamic config)
        {
            string connetionString = (string)config.conn;
            int orderId = (int)config.orderId;

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {

                if (orderId == 0)
                {
                    return GetOrders(cnn);
                }
                else
                {
                    return GetOrderDetails(cnn, orderId);
                }
            }
            
        }

        public static List<OrderDT> GetOrders(SqlConnection cnn)
        {
            List<OrderDT> result = new List<OrderDT>();
            cnn.Open();
            var sql = "select top 10 * from Sales.Orders";
            var command = new SqlCommand(sql, cnn);
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                OrderDT dt = new OrderDT();
                dt.OrderId = dataReader.GetInt32(0);
                dt.Date = dataReader.GetDateTime(6);
                dt.ExpectedDeliveryDate = dataReader.GetDateTime(7);
                dt.CustomerId = dataReader.GetInt32(1);

                result.Add(dt);
            }
            return result;
        }

        public static List<OrderDetailsDT> GetOrderDetails(SqlConnection cnn, int orderId)
        {
            List<OrderDetailsDT> result = new List<OrderDetailsDT>();
            cnn.Open();
            var sql = "select top 10 * from Sales.OrderLines where OrderId = @ID";
            var command = new SqlCommand(sql, cnn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = orderId;

            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                OrderDetailsDT dt = new OrderDetailsDT();
                dt.StockItemId = dataReader.GetInt32(2);
                dt.Description = dataReader.GetString(3);
                dt.Quantity = dataReader.GetInt32(5);

                result.Add(dt);
            }
            return result;
        }
        
    }
}
