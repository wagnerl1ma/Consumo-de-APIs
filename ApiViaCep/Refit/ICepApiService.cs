using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiViaCep.Refit
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<ViaCepRefitResponse> GetViaCepRefit(string cep);
    }
}
