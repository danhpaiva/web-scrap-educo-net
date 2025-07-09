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
│   ├── CefetEducTecno.cs
│   └── Utfpr.cs
├── Program.cs
└── WebScrapEducation.csproj
```

---

## 🧠 Funcionalidades

- Realiza requisições HTTP com `HttpClient`.
- Analisa documentos HTML com `HtmlAgilityPack`.
- Filtra e extrai informações de **períodos de inscrição**.
- Verifica automaticamente se os editais estão **abertos** com base na data atual.
- Exibe os dados no console de forma organizada e clara.

---

## ▶️ Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/danhpaiva/web-scrap-educo-net.git
```

2. Navegue até o diretório do projeto:

```bash
cd web-scrap-educo-net/WebScrapEducation
```

3. Execute o projeto com o .NET CLI:

```bash
dotnet run
```

---

## 📥 Dependências

Instaladas via NuGet:

```bash
dotnet add package HtmlAgilityPack --version 1.12.1
```

---

## 📌 Observações

- O projeto tem fins educacionais e pode ser utilizado como base para automações mais complexas de monitoramento de vagas e oportunidades educacionais.
- Caso os sites mudem a estrutura do HTML, o scraping pode deixar de funcionar e será necessário ajustar os seletores XPath.

---

## 👨‍💻 Autor

**Daniel Paiva**  
[![LinkedIn](https://img.shields.io/badge/LinkedIn-%230077B5?style=flat&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/danhpaiva/)

---

## 📄 Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---
