using ListaCompras.ConsoleApp.Compartilhado;
using System.Linq;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class ListaCompras : EntidadeBase
{
    public string Nome { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public StatusLista Status { get; set; } = StatusLista.Aberta;

    public List<Item> Itens { get; set; } = new List<Item>();

    public ListaCompras(string nome)
    {
        Nome = nome;
    }

    public int TotalItens()
    {
        return Itens?.Count ?? 0;
    }

    public decimal TotalEstimado()
    {
        return Itens.Sum(item => item.PrecoTotal);
    }

    public override List<string> Validar()
    {
        return new List<string>();
    }



    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaCompras lista = (ListaCompras)entidadeAtualizada;
        Nome = lista.Nome;
        Status = lista.Status;
        Itens = lista.Itens;
    }
}