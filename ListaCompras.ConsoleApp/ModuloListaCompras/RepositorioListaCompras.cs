using System.Text.RegularExpressions;
using ListaCompras.ConsoleApp.Compartilhado;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class RepositorioListaCompras : RepositorioBase<ListaDeCompras>
{
    public List<ListaDeCompras> SelecionarAbertas()
    {
        return registros
                .Where(lista => lista.Status == StatusLista.Aberta)
                .ToList();
    }
    public List<ListaDeCompras> SelecionarConcluidas()
    {
        return registros
            .Where(lista => lista.Status == StatusLista.Concluida)
            .ToList();
    }
}
