using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace AuthProcessInRest.Security
{
    public class BasicHandler : AuthenticationHandler<BasicOption>
    {
        public BasicHandler(IOptionsMonitor<BasicOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            /*
             * 1. Gelen istek, header içerisinde Authorization barındırıyor mu?
             * 2. Authorization değeri, parse edilebiliyor mu?
             * 3. Auth. şema bilgisi "BASIC" mi
             * 4. Gelen şemanın değerini Decode et.
             * 5. (:) işaretine göre split et. 
             *    İlki kullanıcı adı 
             *    İkincisi şifredir
             */
        }
    }
}
