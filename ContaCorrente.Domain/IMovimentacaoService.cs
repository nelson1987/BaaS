namespace ContaCorrente.Domain;

public interface IMovimentacaoService
{
    void Transferir(Conta pagador, Conta recebedor, decimal valor);
    void Depositar(Conta depositante, decimal valor);
    void Sacar(Conta sacador, decimal valor);
}
