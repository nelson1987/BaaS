namespace ContaCorrente.Domain;

public interface IContaRepository
{
    Conta GetByNumero(string numeroConta);
    void Update(Conta pagador);
}
public class ContaRepository : IContaRepository
{
    public Conta GetByNumero(string numeroConta)
    {
        throw new NotImplementedException();
    }

    public void Update(Conta pagador)
    {
        throw new NotImplementedException();
    }
}
