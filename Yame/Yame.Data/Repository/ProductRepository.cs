using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Yame.Core;
using Yame.Models.Domain;
using System.Data;

namespace Yame.Data.Repository
{
    public class ProductRepository : IProductRepository
    {

        public IList<Product> GetAll()
        {
            String sql = @"SELECT Id,Name,Category,Discontinued FROM Product";
            IDbConnection db = DbManager.Default;
            //IDbConnection db = DbManager.For(DBNames.YameTest); //使用非默认数据
            return db.Query<Product>(sql, null).ToList();
        }

        public Product GetById(Guid id)
        {
            String sql = @"SELECT Id,Name,Category,Discontinued FROM Product WHERE Id=@Id";
            return DbManager.Default
                            .Query<Product>(sql, new { Id = id })
                            .FirstOrDefault();
        }

        public void Update(Product product)
        {
            String sql = @"UPDATE Product
                        SET Id = @Id
                        ,Name = @Name
                        ,Category = @Category
                        ,Discontinued = @Discontinued WHERE Id = @Id";
            DbManager.Default.Execute(sql, product);
        }

        public void Add(Product product)
        {
            String sql = @"INSERT INTO [Product]
                           ([Id]
                           ,[Name]
                           ,[Category]
                           ,[Discontinued])
                         VALUES
                           (@Id
                           ,@Name
                           ,@Category
                           ,@Discontinued)";
            DbManager.Default.Execute(sql, product);
        }

        public void Delete(Guid id)
        {
            String sql = @"DELETE FROM Product WHERE Id = @Id";
            DbManager.Default.Execute(sql, new { Id = id });
        }

    }


}
