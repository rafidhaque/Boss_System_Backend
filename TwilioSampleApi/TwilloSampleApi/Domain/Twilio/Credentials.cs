using Microsoft.Extensions.Configuration;
using System.Configuration;
using TwilloSampleApi.Helper;

namespace TwilloSampleApi.Domain.Twilio
{
    public interface ICredentials
    {
        string AccountSID { get; }
        string AuthToken { get; }
        string TwiMLApplicationSID { get; }
        string PhoneNumber { get; }
    }

    public class Credentials : ICredentials
    {
        IConfiguration Configuration;

        public Credentials(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string AccountSID
        {
            
            get
            {
                return Configuration.GetSection("AppSettings").Get<AppSettings>().TwilioAccountSid;
                //return WebConfigurationManager.AppSettings["TwilioAccountSid"];
            }
        }
        public string AuthToken
        {
            get
            {
                return Configuration.GetSection("AppSettings").Get<AppSettings>().TwilioAuthToken;
                //return WebConfigurationManager.AppSettings["TwilioAuthToken"];
            }
        }

        public string TwiMLApplicationSID {
            get
            {
                return Configuration.GetSection("AppSettings").Get<AppSettings>().TwiMLApplicationSid;
                //return WebConfigurationManager.AppSettings["TwiMLApplicationSid"];
            }
        }

        public string PhoneNumber {
            get
            {
                return Configuration.GetSection("AppSettings").Get<AppSettings>().TwilioPhoneNumber;
                //return WebConfigurationManager.AppSettings["TwilioPhoneNumber"];
            }
        }
    }
    public class Credentials2 : ICredentials
    {
        public string AccountSID => "test1";

        public string AuthToken => "test2";

        public string TwiMLApplicationSID => "TEst2";

        public string PhoneNumber => "TEst2";
    }
}