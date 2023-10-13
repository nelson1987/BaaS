using ContaCorrente.Application;
using Moq;

namespace ContaCorrente.Domain.Tests;

public class RealizaTransferenciaHandlerTests
{
    private readonly Mock<IContaRepository> _contaRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IMovimentacaoService> _movimentacaoService;

    public RealizaTransferenciaHandlerTests()
    {
        _contaRepository = new Mock<IContaRepository>();
        _unitOfWork = new Mock<IUnitOfWork>();
        _movimentacaoService = new Mock<IMovimentacaoService>();
    }

    [Fact]
    public void RealizaTransferencia()
    {
        _contaRepository
            .Setup(x => x.GetByNumero("1234"))
            .Returns(new Conta() { Numero = "1234" });
        _contaRepository
            .Setup(x => x.GetByNumero("5678"))
            .Returns(new Conta() { Numero = "5678" });
        _unitOfWork
            .SetupGet(x => x.Conta)
            .Returns(_contaRepository.Object);
        RealizaTransferenciaCommand comando = new RealizaTransferenciaCommand("1234", "5678", 10.00M);
        RealizaTransferenciaHandler handler = new RealizaTransferenciaHandler(_unitOfWork.Object, _movimentacaoService.Object);
        handler.Handle(comando);
        _unitOfWork.Verify(library => library.Conta.GetByNumero("1234"), Times.AtMostOnce());
        _unitOfWork.Verify(library => library.Conta.GetByNumero("5678"), Times.AtMostOnce());
        _unitOfWork.Verify(library => library.Conta.GetByNumero("5678"), Times.AtMostOnce());
    }
}