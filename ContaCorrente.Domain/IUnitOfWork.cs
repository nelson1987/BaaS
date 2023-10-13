namespace ContaCorrente.Domain;

public interface IUnitOfWork
{
    void Begin();
    void Commit();
    void Rollback();
    IContaRepository Conta { get; }
}
