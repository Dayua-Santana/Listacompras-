using ListaCompras.ConsoleApp.Compartilhado;
using System.Linq;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class ListaDeCompras : EntidadeBase
{
    public string Nome { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public StatusLista Status { get; set; } = StatusLista.Aberta;

    public List<Item> Itens { get; set; } = new List<Item>();

    public ListaDeCompras(string nome)
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
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");
        return erros;
    }



    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaDeCompras lista = (ListaDeCompras)entidadeAtualizada;
        Nome = lista.Nome;
        Status = lista.Status;
        Itens = lista.Itens;
    }
}