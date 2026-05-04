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
        else if (opcao == "3") VisualizarItens();
        else if (opcao == "2") RemoverItem();
        // else if (opcao == "4") ConcluirLista();


        return opcao;
    }

    private void VisualizarItens()
    {
        ListaDeCompras? lista = SelecionarLista("Visualizar Itens");
        if (lista == null)
            return;

        if (lista.Itens.Count == 0)
        {
            Notificador.ExibirMensagem("Esta lista não possui itens.");
            return;
        }

        Console.Clear();
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine($"Itens da lista: {lista.Nome}");
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine("{0, -10} | {1, -20} | {2, -10} | {3, -12} | {4, -10}", "ID Prod", "Produto", "Qtde", "Preço Un.", "Subtotal");
        Console.WriteLine("---------------------------------------------------------------------------");

        foreach (var item in lista.Itens)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -10} | R$ {3, -9:F2} | R$ {4, -7:F2}",
            item.NomeProduto.Id,
            item.NomeProduto.Nome,
            item.Quantidade,
            item.PrecoUnitario,
            item.PrecoTotal);

        }
        Console.WriteLine("---------------------------------------------------------------------------");
        // Aqui usamos os métodos que já existem na sua classe ListaDeCompras
        Console.WriteLine($"Total de Registros: {lista.TotalItens()}");
        Console.WriteLine($"Total Estimado da Lista: R$ {lista.TotalEstimado():F2}");
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    private void ConcluirLista()
    {
        ListaDeCompras? lista = SelecionarLista("Concluir Lista");
        if (lista == null)
            return;
        lista.Status = StatusLista.Concluida;
        Notificador.ExibirMensagem($"Lista \"{lista.Nome}\" concluida com sucesso!");
    }

    private ListaDeCompras? SelecionarLista(string titulo)
    {
        var listas = repositorioLista.SelecionarTodos();
        if (listas.Count == 0)
        {
            Notificador.ExibirMensagem("Nenhuma lista cadastrada.");
            return null;
        }

        Console.WriteLine($"\n--- {titulo} ---");
        foreach (var l in listas)
            Console.WriteLine($"ID: {l.Id} | Nome: {l.Nome} | Status: {l.Status}");

        Console.Write("\nDigite o ID da lista: ");
        string id = Console.ReadLine() ?? "";

        return (ListaDeCompras)repositorioLista.SelecionarPorId(id);
    }

    private Produto? SelecionarProduto()
    {
        var produtos = repositorioProduto.SelecionarTodos();
        if (produtos.Count == 0)
        {
            Notificador.ExibirMensagem("Nenhum produto cadastrado.");
            return null;
        }

        Console.WriteLine("\n--- Seleciona o Produto ----");
        foreach (var p in produtos)
            Console.WriteLine($"ID: {p.Id} | Nome {p.Nome} | Preço: R$ {p.PrecoAproximado:F2}");
        Console.Write("\nDigite o ID do produto: ");
        string id = Console.ReadLine() ?? "";

        return (Produto)repositorioProduto.SelecionarPorId(id);
    }

    private void RemoverItem()
    {
        ListaDeCompras? lista = SelecionarLista("Remover Item");
        if (lista == null)
            return;
        if (lista.Itens.Count == 0)
        {
            Notificador.ExibirMensagem("Esta lista não possui itens para remover.");
        }

        foreach (var i in lista.Itens)
            Console.WriteLine($"ID: {i.NomeProduto.Id} | Nome: {i.NomeProduto.Nome} ");

        Console.Write("\nDigite o ID do produto que deseja remover: ");
        string idDigitado = Console.ReadLine() ?? "";

        var itemRemover = lista.Itens.Find(x => x.NomeProduto.Id == idDigitado);

        if (itemRemover == null)
        {
            Notificador.ExibirMensagem("Item não encontrado nesta lista.");
            return;
        }

        lista.Itens.Remove(itemRemover);
        Notificador.ExibirMensagem($"O Produto \"{itemRemover.NomeProduto.Nome}\" removido com sucesso!");
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

}


