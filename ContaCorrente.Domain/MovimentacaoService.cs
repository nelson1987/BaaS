namespace ContaCorrente.Domain;

public class MovimentacaoService : IMovimentacaoService
{
    public void Transferir(Conta pagador, Conta recebedor, decimal valor)
    {
        pagador.ValidarSaldo(valor);
        pagador.Transferir(recebedor, valor.Negativar());
        recebedor.Transferir(pagador, valor);
    }
    public void Depositar(Conta depositante, decimal valor)
    {
        depositante.Depositar(valor);
    }
    public void Sacar(Conta sacador, decimal valor)
    {
        sacador.ValidarSaldo(valor);
        sacador.Sacar(valor);
    }
}
