using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linear_List;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearList<int> LL = new LinearList<int>();
            LL.AddFront(1);
            LL.AddFront(2);
            LL.AddFront(3);
            LL.AddFront(4);
            LL.AddFront(5);
            LL.Add(33, 6);
            LL.AddBack(0);
            LL.Delete(7);
            LinearList<int> FF = LL.SearchValueToLinearList(4);

            //Console.WriteLine(LL.SearchValue(4));
            //Console.WriteLine(LL.Print());
            Console.ReadLine();
        }
    }
}
