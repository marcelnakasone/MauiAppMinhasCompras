using MauiAppMinhasCompras.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get     // verifica se o bd foi criado, se não ele cria
            { 
                if (_db == null)
                { string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                   

                    _db = new SQLiteDatabaseHelper(path);   // conexão sqlite e criação da tabela Produto
                }

                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListaProduto());

        }
    }
}