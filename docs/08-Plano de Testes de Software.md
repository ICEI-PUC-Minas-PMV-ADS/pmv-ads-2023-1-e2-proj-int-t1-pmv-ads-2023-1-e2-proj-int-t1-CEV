# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

 
| **Caso de Teste** 	| **CT-01 – Cadastrar produto** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-03 - O sistema deve permitir cadastrar, visualizar e remover os produtos da loja. |
| Objetivo do Teste 	| Verificar se consegue cadastrar um produto. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app/                                                                                       <br> - Clicar no menu "Produtos"  <br> - Clicar em "Cadastrar Produto" <br> - Preencher os campos obrigatórios (nome do produto, preço, estoque inicial, salvar) |
|Critério de Êxito | - Produto criado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Editar produto** 	|
|	Requisito Associado 	| RF-03 - O sistema deve permitir cadastrar, visualizar e remover os produtos da loja. |
| Objetivo do Teste 	| Verificar se consegue editar um produto. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app/products<br> - Clicar em "Editar" <br> - Preencher os campos obrigatórios (nome do produto, preço, salvar) |
|Critério de Êxito | - Produto editado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Remover produto** 	|
|	Requisito Associado 	| RF-03 - O sistema deve permitir cadastrar, visualizar e remover os produtos da loja. |
| Objetivo do Teste 	| Verificar se consegue remover um produto. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app/products<br> - Clicar em "Remover" <br> |
|Critério de Êxito | - Produto removido com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Cadastrar entrada** 	|
|	Requisito Associado 	| RF-00A - A aplicação deve apresentar a funcionalidade de cadastrar entrada dos produtos. |
| Objetivo do Teste 	| Verificar se consegue cadastrar a entrada de um produto. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app/products<br> - Clicar em "cadastrar entrada" <br> - Preencher os campos obrigatórios (produto - selecione, quantidade - adicionar, ações - remover, Cadastrar Entradas)|
|Critério de Êxito | - Entradas de estoque feitas com sucesso. |
