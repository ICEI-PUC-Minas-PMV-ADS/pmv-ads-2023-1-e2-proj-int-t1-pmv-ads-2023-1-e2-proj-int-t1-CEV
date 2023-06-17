# Arquitetura da Solução

## Diagrama de Classes

O diagrama foi estruturado considerando a necessidade do cliente em otimizar seu sistema interno relacionado ao controle de estoque e venda de produtos (condições para gerir os processos logísticos e financeiros da empresa com agilidade e eficácia). Abaixo são explicitadas as relações entre as classes para execução do sistema:

 - **Usuário**: será responsável por gerenciar o processo de criação, inclusão e exclusão de produtos na aplicação. Além de ter acesso à geração de relatórios, registrará a entrada de produtos, bem como sua quantidade afim de auxiliar nas vendas, evitando oferta de produto sem estoque. 

 - **Vendas**: responsável apenas pela venda dos produtos, poderá acessar o estoque para verificar se o produto ofertado se encontra em quantidade disponível para o cliente.

 - **Relatório**: será possível gerar relatório de vendas e produtos, e outros que se fizerem necessários para acompanhar o desenvolvimento do negócio (quais produtos mais vendem e quais não tem saída satisfatória, por exemplo). Essa funcionalidade terá acesso controlado por senha.

![image](https://user-images.githubusercontent.com/106809153/235804576-b82cf41a-7ff9-4429-8be7-da0881c15f1e.png)


## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
 
Para mais informações, consulte o microfundamento "Modelagem de Dados".

## Tecnologias Utilizadas

- **linguagens** 
  - HTML (Hypertext Markup Language): responsável pela estrutura do conteúdo do site.
  - CSS: usado para definir o estilo de apresentação da página desenvolvida.
  - C#: linguagem de programação utilizada na aplicação

- **Serviços web e Ferramentas:**
  - Trello:  utilizado para gerenciar e monitorar o fluxo de atividades do projeto.
  - Azure: responsável por hospedar a aplicação (renderização de conteúdo).
  - Vercel: plataforma usada para fazer o deploy do site.
  - Visual Studio: editor escolhido para desenvolver o código-fonte do projeto.
  - ASP.NET: framework que oferece suporte para criar aplicações e utilizar serviços (como APIs, por exemplo).
  - JSON: formato utilizado na representação de dados.
  - SQL Server: gerenciador de banco de dados relacional.

Arquitetura da aplicação
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t1-pmv-ads-2023-1-e2-proj-int-t1-CEV/assets/106809153/8e4cf7a0-fe80-48bb-b59e-a84f8d01a189)

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
