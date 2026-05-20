using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public interface IManager<T>
    {
        List<T> GetAll();
        void Add(T item);
    }
}