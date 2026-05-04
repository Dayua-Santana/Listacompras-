using System.Text.RegularExpressions;
using ListaCompras.ConsoleApp.Compartilhado;

namespace ListaCompras.ConsoleApp.ModuloListaCompras;

public class RepositorioListaCompras : RepositorioBase<ListaCompras>
{
    public List<ListaCompras> SelecionarAbertas()
    {
        List<ListaCompras> abertas = new List<ListaCompras>();
        foreach (ListaCompras lista in registros)
        {
            if (lista.Status == StatusLista.Aberta)
                abertas.Add(lista);
        }

        return abertas;
    }
    public List<ListaCompras> SelecionarConcluidas()
    {
        List<ListaCompras> concluidas = new List<ListaCompras>();

        foreach (ListaCompras lista in registros)
        {
            if (lista.status == StatusLista.Concluida)
                concluidas.Add(lista);
        }

        return concluidas;
    }
}