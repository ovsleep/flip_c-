using ImgConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        //public void FixEfProviderServicesProblem()
        //{
        //    //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
        //    //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
        //    //Make sure the provider assembly is available to the running application. 
        //    //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

        //    var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        //}

        static void Main(string[] args)
        {
            //var c = new Startup();

            //var t = c.Invoke(@"E:\Proyectos\Personal\flip\server\uploads\2921ec6e80501103499e17a6ac9380c41487221069639_f.jpeg");

            //t.Wait();
            //Console.WriteLine(t.Result.ToString());

            var d = new DBAccess.Startup();

            dynamic data = new { conn = @"Data Source=DESKTOP-8JUJ5KI\SQLEXPRESS01;Initial Catalog=WideWorldImporters;Integrated Security=True;MultipleActiveResultSets=True;", orderId = 2 };
            var t = d.Invoke(data);
            t.Wait();

            dynamic result = t.Result;
            foreach (var item in result)
            {
                Console.WriteLine(item.OrderId);
            }

            Console.ReadKey();
        }
    }
}
