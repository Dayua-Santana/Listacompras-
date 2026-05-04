using ListaCompras.ConsoleApp.Compartilhado;
using ListaCompras.ConsoleApp.ModuloCategoria;

namespace ListaCompras.ConsoleApp.ModuloProduto;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioCategoria repositorioCategoria;

    public TelaProduto(RepositorioProduto repositorio, RepositorioCategoria repositorioCategoria)
        : base("Produto", repositorio)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de produtos");

        List<Produto> produtos = repositorio.SelecionarTodos();

        if (produtos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhum registro.");
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------");
            Console.Write("Digite ENTER para continuar....");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -20} | {3, -10} | {4, -10}",
            "Id", "Nome", "Categoria", "Unidade", "Preço"
        );

        foreach (Produto p in produtos)
        {
            Console.WriteLine(
                            "{0, -7} | {1, -25} | {2, -20} | {3, -10} | R$ {4, -7:F2}",
                            p.Id, p.Nome, p.Categoria?.Nome, p.Unidade, p.PrecoAproximado
                        );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("------------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Categorias disponiveis:");
        Console.WriteLine("-------------------------------------------");

        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        if (categorias.Count == 0)
        {
            Console.WriteLine("Nenhuma categoria cadastrada. Cadastre uma antes!");
            Console.ReadLine();
            return ObterDadosCadastrais();
        }

        foreach (Categoria c in categorias)
            Console.WriteLine($"{c.Id} - {c.Nome}");

        Console.WriteLine("-----------------------------");
        Console.Write("Digite o ID da categoria: ");
        string idCategoria = Console.ReadLine() ?? string.Empty;

        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(idCategoria);

        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("Selecione a unidade de medida:");
        Console.WriteLine("1 - Unidade");
        Console.WriteLine("2 - Kg");
        Console.WriteLine("3 - Litro");
        Console.WriteLine("4 - Caixa");
        Console.Write("> ");
        string opcaoUnidade = Console.ReadLine() ?? string.Empty;

        UnidadeMedida unidade = UnidadeMedida.Unidade;

        if (opcaoUnidade == "2")
            unidade = UnidadeMedida.Kg;

        else if (opcaoUnidade == "3")
            unidade = UnidadeMedida.Litro;
        else if (opcaoUnidade == "4")
            unidade = UnidadeMedida.Caixa;

        Console.Write("Digite o preço aproximado: ");
        decimal.TryParse(Console.ReadLine(), out decimal preco);

        return new Produto(nome, categoriaSelecionada!, unidade, preco);
    }

    protected override List<string> ValidarRegistroDuplicado(Produto novaEntidade, string? idIgnorado = null)
    {
        List<string> erros = new List<string>();

        foreach (Produto p in repositorio.SelecionarTodos())
        {
            bool mesmoNome = p.Nome == novaEntidade.Nome;
            bool mesmaCategoria = p.Categoria.Id == novaEntidade.Categoria.Id;
            bool naoEhEleMesmo = p.Id != idIgnorado;

            if (mesmoNome && mesmaCategoria && naoEhEleMesmo)
            {
                erros.Add($"Já existe um produto \"{novaEntidade.Nome}\" na categoria \"{novaEntidade.Categoria.Nome}\".");
            }
        }
        return erros;
    }
}