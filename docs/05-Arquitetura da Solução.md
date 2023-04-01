# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

O diagrama foi estruturado considerando a necessidade do cliente em otimizar seu sistema interno relacionado ao controle de estoque e venda de produtos (condições para gerir os processos logísticos e financeiros da empresa com agilidade e eficácia). Abaixo são explicitadas as relações entre as classes para execução do sistema:

 - **Gestão**: será responsável por gerenciar o processo de criação, inclusão e exclusão de funcionários e produtos na aplicação. Além de ter acesso à geração de relatórios, também terá o controle de liberar o acesso desses documentos ao funcionário que julgar pertinente. 

 - **Funcionário**: abrigará as informações básicas dos funcionários da empresa. Todos eles estarão subordinados apenas a um gestor que será responsável por manter o registro atualizado desses funcionários no sistema.

 - **Estoque**: departamento responsável por registrar a chegada de produtos, bem como sua quantidade afim de auxiliar o departamento de vendas, evitando oferta de produto sem estoque. Também auxilia a gestão ao gerar relatórios de estoque.

 - **Vendas**: responsável apenas pela venda dos produtos, poderá acessar o estoque para verificar se o produto ofertado se encontra em quantidade disponível para o cliente.

 - **Relatório**: será possível gerar relatório de vendas e produtos, e outros que se fizerem necessários para acompanhar o desenvolvimento do negócio (quais produtos mais vendem e quais não tem saída satisfatória, por exemplo). Essa funcionalidade terá acesso controlado por senha.

![CEV - Diagrama Classes](https://user-images.githubusercontent.com/106809153/228092951-5630823f-059c-4476-beca-f64513645e85.png)

## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

Sugestão de ferramentas para geração deste artefato: LucidChart e Draw.io.

A referência abaixo irá auxiliá-lo na geração do artefato “Modelo ER”.

> - [Como fazer um diagrama entidade relacionamento | Lucidchart](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
 
Para mais informações, consulte o microfundamento "Modelagem de Dados".

## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
