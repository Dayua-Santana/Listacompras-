using System.ComponentModel;
using ListaCompras.ConsoleApp.Compartilhado;
using ListaCompras.ConsoleApp.ModuloCategoria;

namespace ListaCompras.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }
    public UnidadeMedida Unidade { get; private set; }
    public decimal PrecoAproximado { get; private set; }
    UnidadeMedida teste = UnidadeMedida.Kg;

    public Produto(string nome, Categoria categoria, UnidadeMedida unidade, decimal precoAproximado)
    {
        Nome = nome;
        Categoria = categoria;
        Unidade = unidade;
        PrecoAproximado = precoAproximado;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" é obrigatório.");

        if (!Enum.IsDefined<UnidadeMedida>(Unidade))
            erros.Add("O campo \"Unidade de Medida\" deve ser uma seleção válida.");

        if (PrecoAproximado < 0)
            erros.Add("O campo \"Preço Aproximado\" deve ser maior que zero.");

        return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        Unidade = produtoAtualizado.Unidade;
        PrecoAproximado = produtoAtualizado.PrecoAproximado;
    }
}