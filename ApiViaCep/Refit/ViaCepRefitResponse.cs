using Newtonsoft.Json;

namespace ApiViaCep.Refit
{
    public class ViaCepRefitResponse
    {
        //[JsonProperty("cep")]
        public string? Cep { get; set; }

        //[JsonProperty("cep")]
        public string? Logradouro { get; set; }

        //[JsonProperty("complemento")]
        public string? Complemento { get; set; }

        //[JsonProperty("bairro")]
        public string? Bairro { get; set; }

        //[JsonProperty("localidade")]
        public string? Localidade { get; set; }
        
        //[JsonProperty("uf")]
        public string? Uf { get; set; }

        //[JsonProperty("ibge")]
        public string? Ibge { get; set; }

        //[JsonProperty("gia")]
        public string? Gia { get; set; }

        //[JsonProperty("ddd")]
        public string? ddd { get; set; }

        //[JsonProperty("siafi")]
        public string? Siafi { get; set; }
    }
}
