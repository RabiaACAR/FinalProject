using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Interface metotları default publictir. Ama interface değildir.
    //Product'a özel operasyonlar için kullanılır.Ürün detay gibi,ürün ve kategoriye join atmak gibi
    public interface IProductDal : IEntityRepository<Product>//Productla ilgili yapılacak işlemler buraya yazılır.
    {
    }
}
