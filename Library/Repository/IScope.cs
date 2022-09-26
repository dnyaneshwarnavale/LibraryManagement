using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface ISingleton
    {
        int GetData();
    }
    public interface ITransient
    {
        int GetData();
    }
    public interface IScoped
    {
        int GetData();
    }
}
