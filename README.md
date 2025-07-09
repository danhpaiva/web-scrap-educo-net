# 📚 Web Scraping - Pós-Graduação EAD

Este projeto tem como objetivo realizar **web scraping** de instituições de ensino brasileiras para verificar se há **editais de cursos de pós-graduação com inscrições abertas**, especialmente em **Educação Tecnológica, Inteligência Artificial** e **Engenharia de Software**.

> Desenvolvido em **C# com .NET 8.0** utilizando a biblioteca **HtmlAgilityPack**.

---

## 🔗 Repositório

https://github.com/danhpaiva/web-scrap-educo-net

---

## 🚀 Tecnologias Utilizadas

- [.NET 8.0](https://dotnet.microsoft.com/en-us/download)
- [HtmlAgilityPack](https://www.nuget.org/packages/HtmlAgilityPack)
- C#
- Visual Studio 2022+

---

## 🏫 Fontes Monitoradas

O projeto consulta os seguintes sites de instituições:

- [IFSULDEMINAS - Pós-Graduação EAD](https://portal.ifsuldeminas.edu.br/index.php/pos-graduacao-ead2/pos-graduacao-abertos-ead)
- [CEFET-MG - Mestrado em Educação Tecnológica](https://sig.cefetmg.br/sigaa/public/processo_seletivo/lista.jsf?nivel=S&aba=p-stricto)
- [UTFPR - Pós em Inteligência Artificial](https://pos-graduacao-ead.cp.utfpr.edu.br/inteligencia-artificial/)
- [UTFPR - Pós em Engenharia de Software](https://pos-graduacao-ead.cp.utfpr.edu.br/engenharia-de-software/)

---

## ⚙️ Estrutura do Projeto

```text
WebScrapEducation/
├── LatoSensu/
│   └── IfesSulMinas.cs
├── StrictoSenso/
│   └── CefetEducTecno.cs
│   └── Utfpr.cs
├── Program.cs
└── WebScrapEducation.csproj
