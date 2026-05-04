namespace ListaCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<T> where T : EntidadeBase
{
    protected List<T> registros = new List<T>();

    public void Cadastrar(T entidade) => registros.Add(entidade);


    public bool Excluir(T registro) => registros.Remove(registro);

    public T? SelecionarPorId(string id)
    {
        foreach (T r in registros)
            if (r.Id == id) return r;
        return null;
    }
    public bool Editar(string idSelecionado, T entidadeAtualizada)
    {
        T? registro = SelecionarPorId(idSelecionado);
        if (registro == null)
            return false;

        registro.AtualizarDados(entidadeAtualizada);
        return true;
    }

    public List<T> SelecionarTodos()
    {
        return registros;
    }

}