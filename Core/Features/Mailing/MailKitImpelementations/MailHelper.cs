using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Core.Features.Mailing.MailKitImpelementations
{
    public class MailHelper
    {
        string senderName, fromMail, mailPassword, host;
        int port;
        bool useSsl;

        public MailHelper(string senderName, string fromMail, string mailPassword, string host, int port, bool useSsl)
        {
            this.senderName = senderName;
            this.fromMail = fromMail;
            this.mailPassword = mailPassword;
            this.host = host;
            this.port = port;
            this.useSsl = useSsl;
        }

        public async Task<bool> PublishAsync(SendMailIntegrationEvent @event)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(senderName, fromMail));


            foreach (var toMail in @event?.ToMails)
            {
                email.To.Add(new MailboxAddress(toMail, toMail));
            }

            if (@event?.CCMails is not null)
            {
                foreach (var ccMail in @event?.CCMails)
                {
                    email.Cc.Add(new MailboxAddress(ccMail, ccMail));
                }
            }

            if (@event?.BCCMails is not null)
            {
                foreach (var bccMail in @event?.BCCMails)
                {
                    email.Bcc.Add(new MailboxAddress(bccMail, bccMail));
                }
            }

            email.Subject = @event.Subject;


            email.Body = new TextPart(@event.IsHtmlBody ? TextFormat.Html : TextFormat.Plain)
            {
                Text = @event.Body
            };

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(host, port, useSsl);

            await smtp.AuthenticateAsync(fromMail, mailPassword);

            var result = await smtp.SendAsync(email);

            return !result.ToLower().Contains("fail");
        }

        public class SendMailIntegrationEvent
        {
            public SendMailIntegrationEvent() { }

            public SendMailIntegrationEvent(List<string> toMails, List<string>? cCMails, List<string>? bCCMails, string subject, string body, bool isHtmlBody)
            {
                ToMails = toMails;
                CCMails = cCMails;
                BCCMails = bCCMails;
                Subject = subject;
                Body = body;
                IsHtmlBody = isHtmlBody;
            }

            public SendMailIntegrationEvent(List<string> toMails, string subject, string body, bool isHtmlBody) : this(toMails, null, null, subject, body, isHtmlBody)
            {

            }

            public SendMailIntegrationEvent(string toMail, string subject, string body, bool isHtmlBody) : this(new List<string> { toMail }, null, null, subject, body, isHtmlBody)
            {

            }

            public SendMailIntegrationEvent(string toMail, string subject, string body) : this(new List<string> { toMail }, null, null, subject, body, false)
            {

            }

            public List<string> ToMails { get; set; }

            public List<string>? CCMails { get; set; }

            public List<string>? BCCMails { get; set; }

            public string Subject { get; set; }

            public string Body { get; set; }

            public bool IsHtmlBody { get; set; }

            public override string ToString()
            {
                return $"ToMail: {String.Join(", ", ToMails)}, CCMails: {String.Join(", ", CCMails ?? new List<string>())}, BCCMails: {String.Join(", ", BCCMails ?? new List<string>())}, Subject: {Subject}, Body: {Body}";
            }
        }
    }
}
