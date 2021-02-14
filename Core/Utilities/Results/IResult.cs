using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    //temel voiidler için başlangıç
    public interface IResult
    {
        
        //get sadece okunabilir, set yazmak için kullanılır.
        bool  Success { get; }
        string Message { get;  }
    }
}
