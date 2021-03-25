using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwilloSampleApi.Helper
{
    public class AppSettings
    {
        public string TwilioAccountSid { get; set; }
        public string TwilioAuthToken { get; set; }
        public string TwiMLApplicationSid { get; set; }
        public string TwilioPhoneNumber { get; set; }
    }
}
