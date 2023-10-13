namespace ContaCorrente.Domain.Tests;

public class MovimentacaoTests
{
    [Fact]
    public void Transferir()
    {
        Conta pagador = new Conta();
        Conta recebedor = new Conta();
        decimal valor = 10.00M;
        Assert.Equal(0, pagador.Saldo);
        pagador.Transferir(recebedor, valor);
        Assert.Equal(10, pagador.Saldo);
    }
    [Fact]
    public void Depositar()
    {
        Conta pagador = new Conta();
        Assert.Equal(0, pagador.Saldo);
        decimal valor = 10.00M;
        pagador.Depositar(valor);
        Assert.Equal(10, pagador.Saldo);
    }
    [Fact]
    public void Sacar()
    {
        Conta pagador = new Conta();
        decimal valor = 10.00M;
        pagador.Sacar(valor);
        Assert.Equal(-10, pagador.Saldo);
    }
    [Fact]
    public void ValidarSaldo_Unsuccefully()
    {
        Conta pagador = new Conta();
        decimal valor = 10.00M;
        Assert.False(pagador.ValidarSaldo(valor));
    }
    [Fact]
    public void ValidarSaldo_Succefully()
    {
        Conta pagador = new Conta();
        decimal valor = 10.00M;
        pagador.Depositar(valor);
        Assert.Equal(10, pagador.Saldo);
        Assert.True(pagador.ValidarSaldo(valor));
    }
}
