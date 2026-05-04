using ListaCompras.ConsoleApp.Compartilhado;
namespace ListaCompras.ConsoleApp.ModuloCategoria;

public class Categoria : EntidadeBase
{
    public string Nome { get; private set; }
    public CorCategoria Cor { get; private set; }

    public Categoria(string nome, CorCategoria cor)
    {
        Nome = nome;
        Cor = cor;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (Nome.Length < 2 || Nome.Length > 50)
            erros.Add("O campo \"nome\" deve conter entre 2 e 50 caracteres.");

        if (!Enum.IsDefined(typeof(CorCategoria), Cor))
            erros.Add("O cmapo \"Cor\" deve conter uma seleção válida.");

        return erros;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Categoria c = (Categoria)entidadeAtualizada;
        Nome = c.Nome;
        Cor = c.Cor;
    }
}