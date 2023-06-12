# Registro de Testes de Usabilidade

Os dados coletados foram agrupados em uma tabela onde foi registrado o resultado de cada artefato testado pelos usuários e relacionados ao requisito funcional abordado no plano de testes (Telas de criação, visualização e eclusãllo de produtos. Abaixo seguem as etapas de consolidação do teste:

## Tabela de consolidação dos dados na tela de produtos
 Tabela com os dados coletados durante o teste para documentação e análise: 

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t1-pmv-ads-2023-1-e2-proj-int-t1-CEV/assets/106809153/c761e511-615b-4222-a945-06e2550f981b)


Na figura acima temos o modelo dimensional dos dados obtidos na execução do teste conforme planejamentto. Como representação, este modelo contém o desempenho de uma parte do grupo de usuários selecionados (dados de cinco testadores). São desempenhos individuais relacionados a cada artefato testado.

## Registro de teste geral

No teste aplicado os usuários foram orientados a percorrer todas as telas da aplicação (Usuários, Produtos, Vendas, Relatórios de Vendas e Estoques), executando comandos em cada uma delas conforme o vídeo demonstrativo a seguir:

https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t1-pmv-ads-2023-1-e2-proj-int-t1-CEV/assets/106809153/e2c897e5-3133-466a-a82d-48a7d4e32aae


#### Atendimento da aplicação concernente aos requisitos e personas registrados

Conforme demonstrado nos testes de usabilidade registrados, as necessidades indicadas pelas personas registradas nesse documento foram atendidas através das telas desenvolvidas seguindo a relação dos requisitos elicitados anteriormente.

|`PERSONA`| `PRECISO (DORES)` |`FUNCIONALIDADE CRIADA` | REQUISITO ATENDIDO |
|--------------------|------------------------------------|----------------------------------------|-------------|
|Andrea Gomes|Controlar acesso de funcionários aos relatórios de estoque e vendas da empresa|Tela Usuários|RF-02 |
|Andrea Gomes|Gerenciar produtos oferecidos pela loja (cadastrar, remover, incluir e visualizar dados)|Tela Produtos |RF-03 |
|Vitor Pereira|Emitir relatórios de estoque|Tela Estoque|RF-01 / RF-04 |
|Vitor Pereira|Emitir relatórios de vendas|Telas Relatório de Vendas|RF-01/ RF-05 |
|Camila Torres |Registrar as mercadorias que chegam para o estoque|Tela Estoque|RF-03 |
|Vendedor|Registrar venda dos produtos|Tela Produtos |RF-06 / RF07 |
|Carlos Augusto|Gerenciar funcionários do estabelecimento|Tela Usuários |RF-02 |


## Comentários e Conclusão

- Os testes foram feitos remotamente, conforme evidenciado no vídeo acima.
- O desing simples e botões bem alocados e evidenciados por difenciação de cores na aplicação ajudou a obter um bom tempo médio na execução das tarefas além de ocorrerem poucos cliques incorretos.
- Todos os testadores conseguiram executar as tarefas propostas satisfatoriamente (alta taxa de usabilidade)                                                                                   
- Alguns erros levantados durante a fase preliminar de teste foram corrigidos antes de publicação da solução:                                                                                 
           - Problemas na apresentação do gráfico que exibe o relatório de vendas quando estipulado um período;                                                                               
           - Datas no formato estrangeiro (mês/dia/ano) apresentadas no relatório de vendas deixou alguns usuários confusos foi alterada para o padrão brasileiro;                                        - Usuários não conseguiam excluir produtos cadastrado;                                                                                                                             
           - O sistema não estava permitindo eddição de usuários cadastrados;                                                                                                                 
           - Melhoria no tamanho do texto, destacando cores, diferenciando ícones dos estilos em CSS para evitar que o usuário demore a encontrar o caminho para alcançar o objetivo desejado.
