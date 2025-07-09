using HtmlAgilityPack;

namespace WebScrapEducation.LatoSensu;

public class IfesSulMinas
{
    public static async Task GetPosEad(string url)
    {
        int anoAtual = DateTime.Now.Year;

        int anoDesejado = anoAtual;

        Console.WriteLine($"\nIniciando web scraping em:\n {url}");
        Console.WriteLine($"Buscando links para o ano: {anoDesejado}");

        try
        {
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string htmlContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Conteúdo HTML obtido com sucesso. Analisando...");

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                var editalLinks = doc.DocumentNode.SelectNodes("//h2[@class='tileHeadline']/a");

                string foundLink = null;
                string foundTitle = null;

                if (editalLinks != null)
                {
                    foreach (var linkNode in editalLinks)
                    {
                        string title = linkNode.InnerText.Trim();
                        string href = linkNode.GetAttributeValue("href", string.Empty);

                        if (Uri.TryCreate(new Uri(url), href, out Uri fullUri))
                        {
                            href = fullUri.AbsoluteUri;
                        }

                        if (title.Contains(anoDesejado.ToString()) || href.Contains(anoDesejado.ToString()))
                        {
                            foundLink = href;
                            foundTitle = title;
                            break;
                        }
                    }

                    if (foundLink != null)
                    {
                        Console.WriteLine($"\n--- Link do Edital para {anoDesejado} Encontrado ---");
                        Console.WriteLine($"Título: {foundTitle}");
                        Console.WriteLine($"Link: {foundLink}");
                        Console.WriteLine("---------------------------------------------------\n");
                    }
                    else
                    {
                        Console.WriteLine($"Nenhum link de edital para o ano {anoDesejado} foi encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum link de edital foi encontrado com o seletor especificado.");
                }
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro na requisição HTTP: {e.Message}");
            Console.WriteLine($"Verifique se a URL está correta e se você tem acesso ao site.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");
        }
    }
}
