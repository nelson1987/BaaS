namespace ContaCorrente.Domain.Tests;

public class MovimentacaoServiceTests
{
    [Fact]
    public void Transferir()
    {
        Conta pagador = new Conta();
        Conta recebedor = new Conta();
        decimal valor = 10.00M;
        MovimentacaoService servico = new MovimentacaoService();
        servico.Transferir(pagador, recebedor, valor);
    }
    [Fact]
    public void Depositar()
    {
        Conta depositante = new Conta();
        decimal valor = 10.00M;
        MovimentacaoService servico = new MovimentacaoService();
        servico.Depositar(depositante, valor);
    }
    [Fact]
    public void Sacar()
    {
        Conta sacador = new Conta();
        decimal valor = 10.00M;
        MovimentacaoService servico = new MovimentacaoService();
        servico.Sacar(sacador, valor);
    }
}
