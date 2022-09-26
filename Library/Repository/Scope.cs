using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class Scope : ITransient, IScoped, ISingleton
    {
        int number;
        public Scope()
        {
            number = 0;
        }
        public int GetData()
        {
            return number++;
        }
    }
}
