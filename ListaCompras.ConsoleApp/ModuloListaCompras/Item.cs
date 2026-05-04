namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class Item
{
    public string NomeProduto { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    public decimal PrecoTotal => PrecoUnitario * Quantidade;

    public Item(string nomeProduto, decimal precoUnitario, int quantidade)
    {
        NomeProduto = nomeProduto;
        PrecoUnitario = precoUnitario;
        Quantidade = quantidade;
    }
}