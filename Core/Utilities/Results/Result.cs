using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //get read- only'dir. Read-only constructor içinde set edilebilir.
        //Constructor dışında set edilmeyeceği için get kullanıldı.
        //set konulmamasının sebebi sınırlandırmak istenmesindendir.
        //result.success yazılması böylelikle engellenmiştir.
       public Result(bool success, string message):this(success)
            //this sınıfın kendisini temsil eder. :this(success)= Result'ın tek parametreli constructor'ına success'i yollar.
        {
            Message = message;
        }
        //overloading
        public Result(bool success)
        {
            Success = success;
           
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
