<div align="center">
  <h1>Product Scraping</h1>
</div>

<br />
<p align="center">
  <a href="#foram-usadas-as-seguintes-tecnologias">Tecnologias</a> •
  <a href="#instalação">Instalação</a> •
  <a href="#processo-de-desenvolvimento-do-projeto">Processo de desenvolvimento</a>
</p>
<br />

<p>This is a challenge by <a href="https://co,odesh.com/">Coodesh</a></p>
<p>Este projeto realiza o scraping da página <a href="https://world.openfoodfacts.org">openfoodfacts</a> e retorna os dados de cada produto.</p>

<h3><a href="https://www.loom.com/share/045783eaec034150ac8798604bd303f5">Apresentação do projeto [video]</a></h3>

<hr />
<h3>Foram usadas as seguintes tecnologias:</h3>
<ul>
  <li>C#</li>
  <li>.NET Core</li>
  <li>Entity Framework Core</li>
  <li>MySql</li>
  <li>Hangfire</li>
  <li>HtmlAgilityPack</li>
</ul>

<hr />
<h3>Instalação:</h3>
<p>Clone o repositório</p>

```bash
 git clone https://github.com/Jpereira29/Product-Scraping.git
```
<p>Altere a string de conexão para as configurções do seu banco de dados no arquivo appsettings.json</p>
<p>A hora de automação do serviço está definida no arquivo Program.cs e serviço de scraping no Scraping.cs.</p>
<p>O harario de agendamento pode ser alterado em "RecurringJob.AddOrUpdate(() => scraping.GetScrapingResult(), Cron.Daily(hora:int, minuto:int));".</p>

<p>Rode a aplicação</p>

```bash
 cd '.\Product-Scraping\Product Scraping\'
```

```bash
 dotnet run dev
```

<hr />
<h3>Interface do Swagger</h3>
<a href="https://localhost:7094/swagger/index.html">https://localhost:7094/swagger/index.html</a>

<h3>Serviço de automação com <a href="https://www.hangfire.io">Hangfire</a>.</h3>
<a href="https://localhost:7094/hangfire/">https://localhost:7094/hangfire/</a>

<br />
<h3>A aplicação possui os seguintes endpoints:</h3>
<ul>
  <li>GET /: Retornar um Status: 200 e uma Mensagem "Fullstack Challenge 20201026".</li>
  <li>GET /products/:code: Obter a informação somente de um produto.</li>
  <li>GET /products: Listar todos os produtos da base de dados, utilizar o sistema de paginação para não sobrecarregar a REQUEST.</li>
</ul>
<br />
<hr />
<h2>Processo de desenvolvimento do projeto</h2>
<p>Primeiro foi estudado uma ferramenta que possibilitasse o melhor scraping da página, tanto para o desenvolvimento, tanto para futuras manutenções.</p>
<p>A ferramenta usada foi a <a href="https://html-agility-pack.net">HtmlAgilityPack.</a></p>
<p>O banco de dados escolhido foi o MySql e as integrações foram feitas usando o Entity Framework Core.</p>
<p>Para o processo de automação, foi ultilizada a ferramenta <a href="https://html-agility-pack.net">Hangfire</a>, pois facilitou o processo de desenvolvimento.</p>
<p>O horário de agendamento escolhido para o scraping foi às 01h:00 todos os dias, e no final do processo o banco de dados será, novamente populado com os dados atualizados.</p>
