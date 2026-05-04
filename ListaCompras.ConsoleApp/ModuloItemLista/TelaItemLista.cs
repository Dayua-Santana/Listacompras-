using System.Runtime.InteropServices;
using ListaCompras.ConsoleApp.Compartilhado;
using ListaCompras.ConsoleApp.ModuloListaCompras;
using ListaCompras.ConsoleApp.ModuloProduto;
using ListaCompras.ConsoleApp.Utilidades;

namespace ListaCompras.ConsoleApp.ModuloItemLista;

public class TelaItemLista : ITelaOpcoes
{
    private readonly RepositorioListaCompras repositorioLista;
    private readonly RepositorioProduto repositorioProduto;

    public TelaItemLista(RepositorioListaCompras repositorioLista, RepositorioProduto repositorioProduto)
    {
        this.repositorioLista = repositorioLista;
        this.repositorioProduto = repositorioProduto;
    }

    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Itens da Lista");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Adicionar item em uma lista");
        Console.WriteLine("2 - Remover item de uma lista");
        Console.WriteLine("3 - Visualizar itens de uma lista");
        Console.WriteLine("4 - Concluir uma lista");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcao = Console.ReadLine()?.ToUpper();

        if (opcao == "1") AdicionarItem();
        // else if (opcao == "2") RemoverItem();
        // else if (opcao == "3") VisualizarItens();
        // else if (opcao == "4") ConcluirLista();


        return opcao;
    }

    public void AdicionarItem()
    {
        ListaDeCompras? lista = SelecionarLista("Adicionar Item");
        if (lista == null)
            return;

        Produto? produto = SelecionarProduto();
        if (produto == null)
            return;

        foreach (Item item in lista.Itens)
        {
            if (item.NomeProduto.Id == produto.Id)
            {
                Notificador.ExibirMensagem($"O produto \"{produto.Nome}\" já está nessa Lista");
                return;
            }
        }

        Console.WriteLine($"Categoria do produto: {produto.Categoria.Nome}");

        Console.Write("Digite a quantidade: ");
        bool conseguiuConverter = int.TryParse(Console.ReadLine(), out int quantidade);

        if (!conseguiuConverter || quantidade < 0)
        {
            Notificador.ExibirMensagem("A quantidade deve ser um número positivo.");
            return;
        }

        Item novoItem = new Item(produto, produto.PrecoAproximado, quantidade);

        lista.Itens.Add(novoItem);

        Notificador.ExibirMensagem("Item adicionado com sucesso!");
    }
    private ListaDeCompras? SelecionarLista(string titulo)
    {
        // Implementar a lógica de listagem e seleção de listas do repositório
        return null; // Temporário para não dar erro de compilação
    }

    private Produto? SelecionarProduto()
    {
        // Implementar a lógica de listagem e seleção de produtos do repositório
        return null; // Temporário para não dar erro de compilação
    }
}


