using System.Text.RegularExpressions;
using ListaCompras.ConsoleApp.Compartilhado;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class RepositorioListaCompras : RepositorioBase<ListaCompras>
{
    public List<ListaCompras> SelecionarAbertas()
    {
        return registros
                .Where(lista => lista.Status == StatusLista.Aberta)
                .ToList();
    }
    public List<ListaCompras> SelecionarConcluidas()
    {
        return registros
            .Where(lista => lista.Status == StatusLista.Concluida)
            .ToList();
    }
}
