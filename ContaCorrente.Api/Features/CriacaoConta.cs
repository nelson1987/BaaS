using FluentValidation;

namespace ContaCorrente.Api.Features;

//Conta
//Movimentacao
//Cartao
//Cheque
//Emprestimo
//Financiamento Imovel
//Financiamento Casa


public class CriacaoContaCommand : ICommand
{
    public required string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public required string Documento { get; set; }

    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}
public class CriacaoContaValidator : AbstractValidator<CriacaoContaCommand>
{
    public CriacaoContaValidator()
    {
        RuleFor(x => x.Nascimento)
            .NotEmpty()
            .WithName("DataDeNascimento")
            .WithMessage("Data de nascimento é obrigatória.");
    }
}

public class CriacaoContaHandler
{
    private readonly IContaRepository? _contaRepository;
    private readonly IEmailService? _emailService;
    private readonly IEventDispatcher _eventDispatcher;

    public CriacaoContaHandler(IContaRepository? contaRepository, IEmailService? emailService, IEventDispatcher eventDispatcher)
    {
        _contaRepository = contaRepository;
        _emailService = emailService;
        _eventDispatcher = eventDispatcher;
    }

    public void Handle()
    {
        //Cadastrar na base
        _contaRepository.Insert();
        //Enviar Email
        _emailService.Send();
        //Criar Evento para área de Cartões
        _eventDispatcher.Publish(new ImprimeCartaoEvent());
    }
}
public interface IContaRepository
{
    void Insert();
}
public interface IEmailService
{
    void Send();
}
public interface IEventDispatcher
{
    void Publish(IEvent @event);
}
public class ImprimeCartaoEvent : IEvent
{
    public void Send()
    {
        throw new NotImplementedException();
    }
}

public class CadastroContaEvent : IEvent
{
    public void Send()
    {
        throw new NotImplementedException();
    }
}
public interface ICommand
{
    bool IsValid();
}
public interface IEvent
{
    void Send();
}
public static class EventExtensions
{
    public static void Dispatcher(this IList<IEvent> events)
    {
        foreach (var item in events)
        {
            item.Send();
        }
    }
}