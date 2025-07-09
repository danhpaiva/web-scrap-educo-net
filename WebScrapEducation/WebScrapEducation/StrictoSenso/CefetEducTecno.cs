using HtmlAgilityPack;
using System.Globalization;

namespace WebScrapEducation.StrictoSenso;

public class CefetEducTecno
{
    public static async Task GetEducacaoTecnologicaAsync(string url)
    {
        Console.WriteLine($"\nIniciando web scraping em:\n {url}");

        HttpClient client = new();

        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");

        var html = await client.GetStringAsync(url);

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Encontra todos os grupos de edital
        var rows = doc.DocumentNode.SelectNodes("//table[contains(@class,'listagem')]/tbody/tr");

        if (rows == null)
        {
            Console.WriteLine("Nenhuma linha encontrada.");
            return;
        }

        DateTime hoje = DateTime.Today;
        bool encontrou = false;

        for (int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];

            // Verifica se é uma linha de curso específico
            if ((row.SelectSingleNode(".//td[contains(text(),'MESTRADO EM EDUCAÇÃO TECNOLÓGICA')]") != null) || (row.SelectSingleNode(".//td[contains(text(),'MESTRADO EM EDUCA&#199;&#195;O TECNOL&#211;GICA')]") != null))
            {
                // A linha seguinte contém as informações de período
                var dataTd = row.SelectSingleNode("./td[contains(@class,'colData')]");

                if (dataTd != null)
                {
                    var textoPeriodo = dataTd.InnerText.Trim();
                    var datas = textoPeriodo.Split(new string[] { "a" }, StringSplitOptions.RemoveEmptyEntries);

                    if (datas.Length == 2)
                    {
                        DateTime inicio = DateTime.ParseExact(datas[0].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime fim = DateTime.ParseExact(datas[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        if (hoje >= inicio && hoje <= fim)
                        {
                            Console.WriteLine("\nCEFET\nEdital encontrado com inscrições abertas!");
                            Console.WriteLine("Curso: Mestrado em Educação Tecnológica");
                            Console.WriteLine($"Período de inscrição: {inicio:dd/MM/yyyy} a {fim:dd/MM/yyyy}");
                            encontrou = true;
                        }
                    }
                }
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("❌ Nenhum edital aberto para Mestrado em Educação Tecnológica no momento.");
        }
    }
}
