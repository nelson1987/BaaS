namespace ContaCorrente.Domain;

public class Movimentacao
{
    public Movimentacao(Conta pagador, Conta recebedor, decimal valor)
    {
        Pagador = pagador;
        Recebedor = recebedor;
        Valor = valor;
    }

    public Conta Pagador { get; private set; }
    public Conta Recebedor { get; private set; }
    public decimal Valor { get; private set; }
}
