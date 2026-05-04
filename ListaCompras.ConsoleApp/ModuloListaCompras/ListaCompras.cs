using ListaCompras.ConsoleApp.Compartilhado;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class ListaCompras : EntidadeBase
{
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public List<Item> Itens { get; set; } = new();


    public ListaCompras(string nome)
    {
        Nome = nome;
    }

    public int TotalItens() => Itens.Count;

    public decimal TotalEstimado() => Itens.Sum(i => i.PrecoTotal);

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("Nome é obrigatório.");

        return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaCompras lista = (ListaCompras)entidadeAtualizada;
        Nome = lista.Nome;
    }
}
