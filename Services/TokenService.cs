using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditMaster.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> GetTokenAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("");
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
