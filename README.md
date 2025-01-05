# Problema de Encontrar Elemento Repetido 
## (Find Repeated Element)

<p align="justify"> Este é um dos problemas fundamentais em ciência da computação, sendo relevante em uma ampla gama de contextos e aplicações. 
  Em termos simples, trata-se de identificar elementos duplicados dentro de um conjunto de dados, o que pode envolver arrays, listas, registros em bancos de dados, ou até mesmo eventos em sistemas distribuídos. 
  O objetivo aqui é encontrar e, muitas vezes, remover ou lidar com esses elementos repetidos de maneira eficiente, sem comprometer o desempenho do sistema.</p>

## Descrição de Aplicabilidade Prática do Problema

<p align="justify"> Quando registros são inseridos em um Banco de Dados, como um sistema de cadastro de usuários, por exemplo, é importante garantir que os dados essenciais (como CPF, e-mail, telefone) 
não sejam duplicados. O problema de encontrar elementos repetidos pode ser utilizado para verificação de unicidade ao cadastrar um novo usuário, o sistema verifica se o CPF já está presente no banco de dados. 
Se houver duplicidade, o registro não será inserido e pode ser utilizado também na *normalização de dados*, pois durante a migração de dados de uma base para outra, é importante remover ou combinar 
registros duplicados para manter a base limpa e evitar redundâncias. </p>

<p align="justify"> Nos sistemas de monitoramento de servidores, a detecção de duplicatas nos logs pode ser usada para identificar falhas de sistema ou comportamentos anormais. 
  O problema de encontrar elementos repetidos pode ajudar na prevenção de falhas, pois os logs de servidores podem gerar múltiplas entradas para o mesmo erro devido a falhas repetidas ou 
  múltiplas tentativas de resolver o problema. E também na detecção e consolidação de entradas que pode ajudar a entender o verdadeiro impacto de uma falha, ou seja, 
  é feito uma análise de comportamento nos eventos duplicados nos logs para identificar comportamentos repetidos e obter padrões em falhas ou usos anômalos.</p>

## Algoritmos Implementados

1. **Força Bruta**: consiste em verificar todos os pares de elementos para ver se algum deles é igual. Essa abordagem tem complexidade de tempo 
O(n²)

2. **Algoritmo Guloso**: reduz o espaço de busca ao tentar tomar a decisão mais "localmente ótima" a cada passo. Essa abordagem envolve o uso de um conjunto para verificar se um elemento já foi encontrado enquanto percorre o array, a complexidade de tempo é O(n)
   
3. **Divisão e Conquista**: O algoritmo divide o problema em subproblemas menores, resolve-os individualmente e depois combina os resultados. Com complexidade O(n log n)
   
4. **Programação Dinâmica**: A solução é construída a partir de soluções parciais armazenadas, evitando recomputações e tornando a resolução mais eficiente. Complexidade: O(n)

[Comparação de Desempenho.pdf](https://github.com/user-attachments/files/18310442/TD1.-.Pagina1.pdf)

## Como Rodar
1. Clone este repositório.
2. Compile e execute o programa utilizando o Visual Studio ou outra IDE compatível com C#.
