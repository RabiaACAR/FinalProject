using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //where T :class generic constraint 
    //IEntityRepository sadece referens tip alsın
    //IEntity :Ientity veya onu implemente edenler olabilir.
    //new() lenebilir olmalı.
    public interface IEntityRepository<T> where T :class, IEntity,new()
    {
        //Generic Repostory Design Pattern
        //Gelen tür ne ise ona göre işlem yapacak. Bunu yapmanın amacı her entity için ayrı bir dal oluşturmamak içindir.
       
        
            //İçiçne yazılan bilgiye göre getiri. Örneğin; kategori id'si 2 olanları getir
            List<T> GetAll(Expression<Func<T, bool>> filter = null);
            T Get(Expression<Func<T, bool>> filter = null);
            void Add(T entity);
            void Update(T entity);
            void Delete(T entity);
            List<T> GetAllByCategory(int categoryId);
        
    }
}
