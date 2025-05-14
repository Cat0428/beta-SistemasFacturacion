using Microsoft.Extensions.Options;
using SistemaFactura.BLL.Helpers;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SistemaFactura.BLL.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task EnviarCorreoAsync(string destino, string asunto, string cuerpo)
        {
            var mensaje = new MailMessage();
            mensaje.From = new MailAddress(_settings.Remitente, _settings.NombreRemitente);
            mensaje.To.Add(destino);
            mensaje.Subject = asunto;
            mensaje.Body = cuerpo;
            mensaje.IsBodyHtml = true;

            using var smtp = new SmtpClient(_settings.Host, _settings.Puerto)
            {
                Credentials = new NetworkCredential(_settings.Usuario, _settings.Password),
                EnableSsl = true
            };

            await smtp.SendMailAsync(mensaje);
        }
    }
}
