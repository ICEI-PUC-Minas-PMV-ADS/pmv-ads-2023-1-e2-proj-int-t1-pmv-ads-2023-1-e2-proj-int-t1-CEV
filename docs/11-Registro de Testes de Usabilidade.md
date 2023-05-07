# Registro de Testes de Usabilidade

Os dados coletados foram agrupados em uma tabela onde foi registrado o resultado de cada artefato testado pelos usuários e relacionados ao requisito funcional abordado no plano de testes (Telas de criação, visualização e eclusãllo de produtos. Abaixo seguem as etapas de consolidação do teste:

## Tabela de consolidação dos dados na tela de produtos
 Tabela com os dados coletados durante o teste para documentação e análise: 
![image](https://user-images.githubusercontent.com/106809153/236703256-fed4c60b-9555-43a3-9468-717c8e378050.png)


Na figura acima temos o modelo dimensional dos dados obtidos na execução do teste conforme planejamentto. Como representação, este modelo contém o desempenho de uma parte do grupo de usuários selecionados (dados de seis testadores). São desempenhos individuais relacionados a cada artefato testado.

## Registro de teste geral

O teste Foi divido em duas tarefas (Cadastrar produto e Excluir produto do sistema).

#### Teste geral da tarefa Cadastrar produto:
![image](https://user-images.githubusercontent.com/106809153/236694996-5a6e7577-0c80-467b-b7b3-5de3aad0b3d1.png)

- Nessa primeira etapa tivemos a participação de 13 testadores.
- Apesar de obter um tempo médio bom, taxa de cliques errados resultou altíssima, direcionando os desenvolvedores a focar no desing como um todo (cores, posicionamento, tamanhos de ícones/textos, etc);
- Vários usuários abandonaram a aplicação antes de finalizar a tarefa. De acordo com o feedback dado pelos próprios testadores, houve dificuldade em compreender como funciona a ferramenta de teste (Maze), o que denota deficiência na orientação pré-teste por parte dos aplicadores do teste.

#### Teste geral da tarefa Excluir produto:
![image](https://user-images.githubusercontent.com/106809153/236695924-542c0fc2-396d-4693-b50b-eca7014597de.png)

- Nessa segunda etapa, dos 13 participantes apenas 9 continuaram o teste.
- Aqui percebe-se métrica de taxa de cliques errados, abandono do teste e tempo de execução muito altos evidenciando os mesmos problemas com desing e orientação quanto a execução do teste.


## Execução das tarefas durante aplicação do teste

### Cadastrar produto no sistema: teste do artefato acesso à tela de produtos (Cadasramento Produtos);
![image](https://user-images.githubusercontent.com/106809153/236699614-3a1d272f-0129-44aa-a014-9e672b24a947.png)
![image](https://user-images.githubusercontent.com/106809153/236699701-a632356c-73fb-42f5-979c-4fa386307f76.png)

- Apesar da alta taxa de testadores qoe tiveram sucesso em passar para a próxima tela, houveram uma qquantidade muito alta de cliques incorretos (60%) demonstrando a dificuldade dos usuários em relação ao fluxo necessário para a criação do produto;

### Cadastrar produto no sistema: teste do artefato cadastro de produtos (Botão Salvar);
![image](https://user-images.githubusercontent.com/106809153/236700884-eeebd991-d391-46d7-ab0d-6d3e8e2962a3.png)
![image](https://user-images.githubusercontent.com/106809153/236700654-bee2a1c0-19d3-44fb-b4eb-af89dc2dddef.png)

- Artefato alcançou alta taxa de usabilidade: taxa de erro nos cliques e tempo médio baixos, e com apenas 1 testador não conseguindo realizar a tarefa. Esse resultado pode direcionar a equipe no mmomento de analisar as demais telas que não obtiveram um desempenho aceitável.

#### Excluir produto no sistema: teste do artefato cadastro de produtos (Botão Remover)
![image](https://user-images.githubusercontent.com/106809153/236701282-a175407b-bb22-415a-8cab-0b9aff9fd565.png)
![image](https://user-images.githubusercontent.com/106809153/236701393-ca7443dd-c757-4269-9a7f-c8db4bfad1af.png)

- Mais uma vez, os resultados mostrados nesse artefato evidencia que será necessário além de ajustis no desing da aplicação, uma condução mais eficaz e elaborada do teste em si;
- Importante ressaltar também a quantidade de cliques fora da área clicável da aplicação e levar esse fato em consideração ao realizar a análise dos dados registrados.

## Comentários e Conclusão
Após a efetiva realização dos testes referente aos artefatos mais críticos no que se refere ao cadastro de produtos na aplicação foi possível visualizar claramente que  melhorias serão necessárias, assim como encontrar novas formas de condução e apresentação dos testes a fim de evitar erros decorrentes de orientação deficiente.

> Com base na análise do teste foram levantadas as seguintes melhorias de design:
- Criação eficiente de tarefas em futuros testes para rever as funcionalidades onde houve indício de erros decorrentes de usuários que se perderam durante a execução das atividades;
- Melhoria no tamanho do texto, destacando cores, diferenciando ícones dos estilos em CSS para evitar que o usuário demore a encontrar o caminho para alcançar o objetivo desejado;
