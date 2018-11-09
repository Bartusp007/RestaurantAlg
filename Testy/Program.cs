using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Testy
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> expr = num => num < 5;
            Console.WriteLine(expr.Parameters[0]);
        }
    }
}
