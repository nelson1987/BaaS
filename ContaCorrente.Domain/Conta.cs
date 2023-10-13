namespace ContaCorrente.Domain;

public class Conta
{
    public Conta()
    {
        Movimentacoes = new List<Movimentacao>();
    }
    public string Numero { get; set; }
    public decimal Saldo => Movimentacoes.Sum(x => x.Valor);
    public List<Movimentacao> Movimentacoes { get; private set; }
    public void Transferir(Conta recebedor, decimal valor)
    {
        Movimentacoes.Add(new Movimentacao(this, recebedor, valor));
    }
    public void Depositar(decimal valor)
    {
        Movimentacoes.Add(new Movimentacao(this, this, valor));
    }
    public void Sacar(decimal valor)
    {
        Movimentacoes.Add(new Movimentacao(this, this, valor.Negativar()));
    }
    public bool ValidarSaldo(decimal valor)
    {
        return Saldo >= valor;
    }
}
