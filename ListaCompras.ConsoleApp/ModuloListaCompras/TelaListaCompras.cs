using ListaCompras.ConsoleApp.Compartilhado;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class TelaListaCompras : TelaBase<ListaDeCompras>, ITelaOpcoes, ITelaCrud
{
    public TelaListaCompras(RepositorioListaCompras repositorio)
        : base("Lista de Compras", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Listas de Compras");

        List<ListaDeCompras> listas = repositorio.SelecionarTodos();

        if (listas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhuma lista cadastrada.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
         "{0, -7} | {1, -25} | {2, -12} | {3, -10} | {4, -7} | {5, -10}",
         "Id", "Nome", "Data", "Status", "Itens", "Total"
     );


        foreach (ListaDeCompras l in listas)
        {
            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -12:dd/MM/yyyy} | {3, -10} | {4, -7} | R$ {5, -7:F2}",
                l.Id,
                l.Nome,
                l.DataCriacao,
                l.Status,
                l.TotalItens(),
                l.TotalEstimado()
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override ListaDeCompras ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da lista: ");
        string nome = Console.ReadLine() ?? string.Empty;

        return new ListaDeCompras(nome);
    }

    protected override List<string> ValidarExclusaoRegistro(ListaDeCompras registro)
    {
        List<string> erros = new List<string>();

        if (registro.Itens.Count > 0)
            erros.Add($"Não é possível excluir a lista \"{registro.Nome}\" pois ela contém itens.");

        return erros;
    }
}