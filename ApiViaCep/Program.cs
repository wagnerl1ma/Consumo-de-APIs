using ApiViaCep;
using ApiViaCep.Refit;
using Refit;
using System.Text.Json;

var resultGetCepRefit = await GetEnderecoRefit("03977450");
Console.WriteLine(resultGetCepRefit.Logradouro);

#region Get com HttpClient
Console.WriteLine("Digite o seu CEP:");
var cep = Console.ReadLine();

var address = $@"http://viacep.com.br/ws/{cep}/json/";
Console.WriteLine($"Executando a chamada para: {address}");

// Configurando o Json para aceitar letras maiuscula ou minuscula no objeto para deserializar. Na configuracao padrao só aceita letras minuscula no objeto.
var myJsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

var cliente = new HttpClient();
try
{
    //HttpResponseMessage: Representa uma mensagem de resposta HTTP incluindo o código de status e os dados.
    HttpResponseMessage? response = await cliente.GetAsync(address);
    response.EnsureSuccessStatusCode(); // valida se o status code é sucesso, se for false vai cair no catch

    string responseBody = await response.Content.ReadAsStringAsync(); //ler o contéudo como string

    Console.WriteLine(responseBody);

    var responseObj = JsonSerializer.Deserialize<ViaCepResponse>(responseBody, myJsonOptions); //deserilizar obj

    // capturar somente o nome da rua
    string nomeRua = responseObj.Logradouro;
}
catch (Exception e)
{
    Console.WriteLine("\n Ocorreu um erro!");
    Console.WriteLine("\n Erro: {0}", e.Message);
}

#endregion


#region Get com Refit
static async Task<ViaCepRefitResponse> GetEnderecoRefit(string cep)
{
    try
    {
        var viaCepClient = RestService.For<ICepApiService>("http://viacep.com.br");

        var endereco = await viaCepClient.GetViaCepRefit(cep);

        return endereco;
    }
    catch (Exception ex)
    {
        Console.WriteLine("\n Erro: {0}", ex.Message);
        return null;
    }
}

#endregion


#region teste GetFileExtension

static string GetFileExtension(byte[] fileData)
{
    string extension = "";
    using (MemoryStream ms = new MemoryStream(fileData))
    {
        using (BinaryReader reader = new BinaryReader(ms))
        {
            // Read the first two bytes of the file
            byte[] buffer = reader.ReadBytes(2);

            // Check for common file types
            if (buffer[0] == 0xFF && buffer[1] == 0xD8)
                extension = ".jpg";
            else if (buffer[0] == 0x89 && buffer[1] == 0x50)
                extension = ".png";
            else if (buffer[0] == 0x47 && buffer[1] == 0x49)
                extension = ".gif";
            else if (buffer[0] == 0x42 && buffer[1] == 0x4D)
                extension = ".bmp";
            else if (buffer[0] == 0x25 && buffer[1] == 0x50)
                extension = ".pdf";
            else if (buffer[0] == 0xD0 && buffer[1] == 0xCF)
                extension = ".doc";
            else if (buffer[0] == 0x50 && buffer[1] == 0x4B)
                extension = ".zip";
        }
    }
    return extension;
}
#endregion
