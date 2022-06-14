namespace Saweat.Application.Contracts.Infrastructure;

public interface IEmailService
{
    void SendEmail(string Body, string toAddress);
}