# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>


| **Caso de Teste** 	| **CT-01 – Cadastrar venda** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-06 - O sistema deve permitir registrar as vendas realizadas. <br> RF-07 - O sistema deve permitir cadastrar, visualizar e remover vendas.|
| Objetivo do Teste 	| Verificar se consegue cadastrar uma venda. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app                                                                                       <br> - Clicar no menu "Vendas"  <br> - Clicar em "Cadastrar venda" <br> - Preencher os campos obrigatórios (vendedor, produto), clicar em adicionar depois em finalizar venda. |
|Critério de Êxito | - Venda cadastrada com sucesso. |
|  	|  	| 
| **Caso de Teste** 	| **CT-02 – Cadastrar produto** 	|
|	Requisito Associado 	| RF-03 - O sistema deve permitir cadastrar, visualizar e remover os produtos da loja. |
| Objetivo do Teste 	| Verificar se consegue cadastrar um produto. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app                                                                                       <br> - Clicar no menu "Produtos"  <br> - Clicar em "Cadastrar Produto" <br> - Preencher os campos obrigatórios (nome do produto, preço, estoque inicial, salvar) |
|Critério de Êxito | - Produto criado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Editar produto** 	|
|	Requisito Associado 	| RF-03 - O sistema deve permitir cadastrar, visualizar e remover os produtos da loja. |
| Objetivo do Teste 	| Verificar se consegue editar um produto. |
| Passos 	| - Acessar o navegador <br>- https://puc-front.vercel.app <br> - Clicar no menu "Produtos" <br> - Clicar em "Editar" <br> - Preencher os campos obrigatórios (nome do produto, preço, salvar) |
|Critério de Êxito | - Produto editado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Remover produto** 	|
|	Requisito Associado 	| RF-03 - O sistema deve permitir cadastrar, visualizar e remover os produtos da loja. |
| Objetivo do Teste 	| Verificar se consegue remover um produto. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app <br> - Clicar no menu "Produtos" <br> - Clicar em "Remover" <br> |
|Critério de Êxito | - Produto removido com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Cadastrar vendedor (usuário)** 	|
|	Requisito Associado 	| RF-02 - O sistema deve permitir cadastrar, editar e remover vendedores (usuários). |
| Objetivo do Teste 	| Verificar se consegue cadastrar um vendedor (usuário). |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app                                                                                       <br> - Clicar no menu "vendedor" (usuário)  <br> - Clicar em "Cadastrar vendedor (usuário)" <br> - Preencher os campos obrigatórios (nome do vendedor (usuário), salvar) |
|Critério de Êxito | - Vendedor criado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Editar vendedor (usuário)** 	|
|	Requisito Associado 	| RF-02 - O sistema deve permitir cadastrar, editar e remover vendedores (usuários). |
| Objetivo do Teste 	| Verificar se consegue editar um vendedor (usuário). |
| Passos 	| - Acessar o navegador <br>- https://puc-front.vercel.app <br> - Clicar no menu "vendedor" (usuário) <br> - Clicar em "Editar" <br> - Preencher os campos obrigatórios (nome do vendedor (usuário), salvar) |
|Critério de Êxito | - Vendedor editado com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Remover vendedor (usuário)** 	|
|	Requisito Associado 	| RF-02 - O sistema deve permitir cadastrar, editar e remover vendedores (usuários). |
| Objetivo do Teste 	| Verificar se consegue remover um vendedor (usuário). |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app <br> - Clicar no menu "vendedor" (usuário) <br> - Clicar em "Remover" <br> |
|Critério de Êxito | - Vendedor removido com sucesso. |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Filtrar relatórios** 	|
|	Requisito Associado 	| RF-01 - O sistema deve permitir emitir relatórios. <br> RF-05 - O sistema deve permitir emitir relatório de vendas da empresa. |
| Objetivo do Teste 	| Verificar se consegue filtrar os relatórios de vendas. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app <br> - Clicar no menu "Relatório de vendas" <br> - Preencher as datas iniciais e finais, em seguida clicar em "Filtrar". <br> |
|Critério de Êxito | - O gráfico irá atualizar. |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Cadastrar entrada de estoque** 	|
|	Requisito Associado 	| RF-04 - O sistema deve permitir cadastrar entrada no estoque da empresa. |
| Objetivo do Teste 	| Verificar se consegue cadastrar a entrada de um produto. |
| Passos 	| - Acessar o navegador <br> - https://puc-front.vercel.app <br> - Clicar em "cadastrar entrada" <br> - Preencher os campos obrigatórios (produto, quantidade), clicar em adicionar, depois em Cadastrar Entradas)|
|Critério de Êxito | - Entradas de estoque feitas com sucesso. |

