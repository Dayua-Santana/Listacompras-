using ListaCompras.ConsoleApp.ModuloProduto;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class Item
{
    public Produto NomeProduto { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    public decimal PrecoTotal => PrecoUnitario * Quantidade;

    public Item(Produto nomeProduto, decimal precoUnitario, int quantidade)
    {
        NomeProduto = nomeProduto;
        PrecoUnitario = precoUnitario;
        Quantidade = quantidade;
    }
}