using ApiViaCep;
using System.Text.Json;

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
}
catch (Exception e)
{
    Console.WriteLine("\n Ocorreu um erro!");
    Console.WriteLine("\n Erro: {0}", e.Message);
}


