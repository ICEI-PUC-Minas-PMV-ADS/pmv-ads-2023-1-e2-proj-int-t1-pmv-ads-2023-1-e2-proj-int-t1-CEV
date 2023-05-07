# Programação de Funcionalidades

Nesta seção são apresentadas as telas desenvolvidas para cada uma das funcionalidades do sistema.

Abra um navegador de Internet e informe a seguinte URL: https://cev-api.azurewebsites.net

## Gestão de produtos (RNF-04, RF-03)
A tela de Cadastro de Produtos no sistema exibe uma lista com os últimos produtos inseridos (cada ítem listado contém ícones que permitirão a sua edição ou exclusão). Ao clicar no botão 'Cadastrar Produto' um formulário é aberto com campos para inserir o nome, preço e estoque inicial do produto. Depois de concluído o cadastro, clicando no botão 'Salvar' essas informações são enviadas ao SGBD MySQL Server e registradas.O mesmo acontece ao clicar nos ícones 'Editar e Remover'.
![image](https://user-images.githubusercontent.com/106809153/236704751-626b0fbb-25fe-4699-acdf-39ec17eb2719.png)

![image](https://user-images.githubusercontent.com/106809153/236705453-9f8c8299-08f0-4dfd-80ed-f36a8a9b8ede.png)







<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

Implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos com os artefatos criados (código fonte), deverão apresentadas as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

Por exemplo: a tabela a seguir deverá ser preenchida considerando os artefatos desenvolvidos.

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário cadastre tarefas | tarefas.shtml / tarefas.cs / controllertarefas.cs | 
|RF-002| Emitir um relatório de tarefas no mês   | relatorio.shtml |

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
