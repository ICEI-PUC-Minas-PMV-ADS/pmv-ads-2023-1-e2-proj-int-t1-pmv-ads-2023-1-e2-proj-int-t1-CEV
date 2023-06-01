# Programação de Funcionalidades

Nesta seção são apresentadas as telas desenvolvidas para cada uma das funcionalidades do sistema.

Paara acessá-lo abra o navegador de Internet e informe a seguinte URL: https://cev-api.azurewebsites.net

## Gestão de Vendedores (RF-02)
A tela relacionada aos vendedores no sistema contém o rol de vendedores registrados. Nessa tela, estarão disponíveis as opções para cadastrar novo vendedor e editar ou remover os cadastros realizados. 

![Cadastro vendedores](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t1-pmv-ads-2023-1-e2-proj-int-t1-CEV/assets/106809153/2cbfa142-2484-4099-8c04-00f4c714ae2b)
![Vendedores 1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t1-pmv-ads-2023-1-e2-proj-int-t1-CEV/assets/106809153/7ca70e12-3efe-40e1-82ee-bf92d6c592aa)

Artefatos desenvolvidos para atender ao requisito:

|Requisito    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-02|O sistema deve permitir cadastrar, visualizar e remover vendedores | Domain\Interfaces\IVendedorApplication.cs | 


## Gestão de produtos (RF-03)
A tela de Cadastro de Produtos no sistema exibe uma lista com os últimos produtos inseridos (cada ítem listado contém ícones que permitirão a sua edição ou exclusão). Ao clicar no botão 'Cadastrar Produto' um formulário é aberto com campos para inserir o nome, preço e estoque inicial do produto. Depois de concluído o cadastro, clicando no botão 'Salvar' essas informações são enviadas ao SGBD MySQL Server e registradas.O mesmo acontece ao clicar nos ícones 'Editar e Remover'.
![image](https://user-images.githubusercontent.com/106809153/236704751-626b0fbb-25fe-4699-acdf-39ec17eb2719.png)

![image](https://user-images.githubusercontent.com/106809153/236705453-9f8c8299-08f0-4dfd-80ed-f36a8a9b8ede.png)


Artefatos desenvolvidos para atender ao requisito:

|Requisito    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-03|O sistema deve permitir cadastrar, visualizar e remover os produtos da loja | Domain\Interfaces\IProdutoApplication.cs | 


## Gestão de Vendas (RF-06 / RF-07)
Na tela de Vendas constará uma lista de produtos com seus respectivos preços e a lista de funcionários registrados. O funcionário selecionará seu nome e o produto a ser vendido para conseguir finalizar a venda. 

![Venda](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t1-pmv-ads-2023-1-e2-proj-int-t1-CEV/assets/106809153/d5d45ef0-f884-4c3a-8b71-8b189fc7bf9e)

Artefatos desenvolvidos para atender ao requisito:

|Requisito    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-06|O sistema deve permitir registrar as vendas realizadas | Domain\Interfaces\IVendaApplication.cs | 
|RF-07|O sistema deve permitir cadastrar, visualizar e remover vendas | Domain\Interfaces\IVendaApplication.cs | 


- O softtware foi desenvolvido utilizando a o Framework ASP.Net MVC, BD MySQL server e APIs no backend. Para o frontend, as ferramentas utilizadas foram HTML, CSS, JavaScript utilizando a plataforma do Vercel.	



# Instruções de acesso

Não deixe de informar o link onde a aplicação estiver disponível para acesso (por exemplo: https://adota-pet.herokuapp.com/src/index.html).

Se houver usuário de teste, o login e a senha também deverão ser informados aqui (por exemplo: usuário - admin / senha - admin).

O link e o usuário/senha descritos acima são apenas exemplos de como tais informações deverão ser apresentadas.

> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
