using MauiAppMinhasCompras.Models;
using SQLite;


namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper  // classe controlar CRUD SQLite
    {
        readonly SQLiteAsyncConnection _conn; // conexão assíncrona com o bd

        public SQLiteDatabaseHelper(string Path) 
        {
            _conn = new SQLiteAsyncConnection(Path);  // criando uma conexão com o bd
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p) // inserindo um produto 
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p)  // atualizando um produto
        {
            string sql = "Update Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );  
        }
        public Task<int> Delete(int id) // deletando um produto
        {   
             return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q) // buscando um produto 
        {   
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%'";
            return _conn.QueryAsync<Produto>(sql);
        }


    }
}
