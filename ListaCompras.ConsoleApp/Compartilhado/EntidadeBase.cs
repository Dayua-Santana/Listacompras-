using System.Security.Cryptography;

namespace ListaCompras.ConsoleApp.Compartilhado;

public abstract class EntidadeBase
{
    public string Id { get; private set; } = string.Empty;

    public EntidadeBase()
    {
        Id = Convert
                    .ToHexString(RandomNumberGenerator.GetBytes(4))
                    .ToLower()
                    .Substring(0, 7);
    }

    //Dependente do tipo da Entidade(Força as classes filhas Implementarem a sua lógica)
    public abstract List<string> Validar();

    //Dependente do tipo da Entidade(Força as classes filhas Implementarem a sua lógica)
    public abstract void AtualizarDados(EntidadeBase entidadeAtualizada);
}

