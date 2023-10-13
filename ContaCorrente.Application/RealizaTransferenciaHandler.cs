using ContaCorrente.Domain;

namespace ContaCorrente.Application;

public class RealizaTransferenciaHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMovimentacaoService _movimentacaoService;

    public RealizaTransferenciaHandler(IUnitOfWork unitOfWork, IMovimentacaoService movimentacaoService)
    {
        _unitOfWork = unitOfWork;
        _movimentacaoService = movimentacaoService;
    }

    public void Handle(RealizaTransferenciaCommand command)
    {
        try
        {
            Conta pagador = _unitOfWork.Conta.GetByNumero(command.Pagador);
            Conta recebedor = _unitOfWork.Conta.GetByNumero(command.Recebedor);
            _movimentacaoService.Transferir(pagador, recebedor, command.valor);
            _unitOfWork.Begin();
            _unitOfWork.Conta.Update(pagador);
            _unitOfWork.Conta.Update(recebedor);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}
