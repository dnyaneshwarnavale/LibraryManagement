using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IInterface
    {
        string Type { get; }
        void Add();
    }
    public class FirstInstance: IInterface
    {
        public string Type { get { return "First"; } }
        public void Add()
        {

        }
    }

    public class SecondInstance : IInterface
    {
        public string Type { get { return "second"; } }
        public void Add()
        {

        }
    }
}
