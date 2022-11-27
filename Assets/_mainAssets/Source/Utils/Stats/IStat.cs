using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Utils.Stats
{
    public interface IStat
    {
    }

    public interface IStat<T> : IStat
    {
        public T Value { get; }
    }

   
}
