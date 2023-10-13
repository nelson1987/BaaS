namespace ContaCorrente.Domain;

public static class DecimalExtensions
{
    public static decimal Negativar(this decimal value)
    {
        return value * -1;
    }
}
