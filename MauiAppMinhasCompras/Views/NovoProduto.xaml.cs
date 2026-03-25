using MauiAppMinhasCompras.Models;
using System.Linq.Expressions;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try // Tenta criar um novo produto e inserir no banco de dados, se der erro exibe a mensagem
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text),
                Categoria = txt_categoria.Text
            };

            await App.Db.Insert(p);
            await DisplayAlertAsync("Sucesso!", "Registo Inserido", "Ok");
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}