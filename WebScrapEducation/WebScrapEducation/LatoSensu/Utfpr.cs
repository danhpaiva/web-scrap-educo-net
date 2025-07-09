using HtmlAgilityPack;

namespace WebScrapEducation.LatoSensu;

public class Utfpr
{
    public static async Task GetInteligenciaArtificial(string url)
    {
        Console.WriteLine($"\nUTFPR - Iniciando web scraping em:\n {url}");

        HttpClient client = new();

        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");
        var html = await client.GetStringAsync(url);

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var inscricoesNode = doc.DocumentNode.SelectSingleNode("//*[@id='link-menu-5']/div/div[16]/ul/li[1]");
        var mensalidadeNode = doc.DocumentNode.SelectSingleNode("//*[@id='link-menu-5']/div/div[19]/ul/li[3]");

        if (inscricoesNode != null)
        {
            var inscricoesTexto = inscricoesNode.InnerText.Trim();
            Console.WriteLine($"Inscrições: {inscricoesTexto}");

            // Exemplo simples de verificação se inscrições estão abertas
            if (inscricoesTexto.ToLower().Contains("inscrições abertas") || inscricoesTexto.ToLower().Contains("período de inscrição aberto"))
            {
                Console.WriteLine("Período de inscrição está aberto.");
            }
            else
            {
                Console.WriteLine("Período de inscrição não está aberto.");
            }
        }
        else
        {
            Console.WriteLine("Não foi possível localizar o elemento de inscrições.");
        }

        if (mensalidadeNode != null)
        {
            var mensalidadeTexto = mensalidadeNode.InnerText.Trim();
            Console.WriteLine($"Mensalidade: {mensalidadeTexto}");
        }
        else
        {
            Console.WriteLine("Não foi possível localizar o elemento de mensalidade.");
        }

    }

    public static async Task GetEngenhariaSoftware(string url)
    {
        try
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");

            Console.WriteLine($"\nUTFPR - Eng. Software - Iniciando web scraping em:\n {url}");
            var html = await httpClient.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var inscricaoNode = doc.DocumentNode.SelectSingleNode("//section[@id='link-menu-5']//ul[contains(@class, 'texto-ul-lista')]/li[contains(text(),'Inscrição')]");

            string inscricaoTexto = inscricaoNode?.InnerText.Trim() ?? "Não encontrado";

            bool inscricoesAbertas = false;
            if (inscricaoTexto != "Não encontrado")
            {
                var dataIniStr = "";
                var dataFimStr = "";

                var dataRangePart = inscricaoTexto.Split(new string[] { "de", "a" }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var idxDe = inscricaoTexto.IndexOf("de");
                    var idxA = inscricaoTexto.IndexOf("a");
                    var idxNo = inscricaoTexto.IndexOf("no");

                    dataIniStr = inscricaoTexto.Substring(idxDe + 3, 10).Trim();
                    dataFimStr = inscricaoTexto.Substring(idxA + 2, 10).Trim();

                    DateTime dataInicio = DateTime.ParseExact(dataIniStr, "dd/MM/yyyy", null);
                    DateTime dataFim = DateTime.ParseExact(dataFimStr, "dd/MM/yyyy", null);
                    DateTime hoje = DateTime.Today;

                    inscricoesAbertas = (hoje >= dataInicio && hoje <= dataFim);
                }
                catch
                {
                    inscricoesAbertas = false;
                }
            }

            var pMensalidadeNode = doc.DocumentNode.SelectSingleNode("//section[@id='link-menu-5']//p[contains(text(),'Mensalidades')]");

            string mensalidadeTexto = pMensalidadeNode?.InnerText.Trim() ?? "Não encontrado";

            Console.WriteLine("Status das inscrições:");
            Console.WriteLine(inscricaoTexto);
            Console.WriteLine("Inscrições abertas hoje? " + (inscricoesAbertas ? "Sim" : "Não"));

            Console.WriteLine();
            Console.WriteLine("Valor da mensalidade:");
            Console.WriteLine(mensalidadeTexto);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao realizar scraping: " + ex.Message);
        }
    }
}
