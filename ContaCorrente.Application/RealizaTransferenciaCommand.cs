namespace ContaCorrente.Application;

public record RealizaTransferenciaCommand(string Pagador, string Recebedor, decimal valor);
