using WebScrapEducation.LatoSensu;
using WebScrapEducation.StrictoSenso;

await IfesSulMinas.GetPosEad("https://portal.ifsuldeminas.edu.br/index.php/pos-graduacao-ead2/pos-graduacao-abertos-ead");
await CefetEducTecno.GetEducacaoTecnologicaAsync("https://sig.cefetmg.br/sigaa/public/processo_seletivo/lista.jsf?nivel=S&aba=p-stricto");
await Utfpr.GetInteligenciaArtificial("https://pos-graduacao-ead.cp.utfpr.edu.br/inteligencia-artificial/");
await Utfpr.GetEngenhariaSoftware("https://pos-graduacao-ead.cp.utfpr.edu.br/engenharia-de-software/");