## Fazer

- OK Criar controller de Usuario
- OK Criar controller da Equipe

-> Ajustar CRUD de cada uma delas de acordo com as regras de negocio - OK Tarefas - Usuario - Equipe
-> Ajustar metodo "Alterar" do Usuario para alterar/incluir tarefas
-> Ajustar metodo cadastrar do Usuario para fazer o relacionamento com a Tarefa

-> Ajustar metodos da Equipe

## 04/08 - conexão com o banco de dados

-> Entity framework - oficial da microsoft - ORM: mapeia objetos para um banco de dados relacional - entende e converte codigo para scripts sql - faz a intermediação entre a aplicação e o banco - precisa criar uma classe para representar o entity framework - AppDataContext - classe que vai fazer toda a interface entre a aplicação e o banco de dados - contexto = referencia do banco de dados dentro da aplicacao

# Passos

-> Criar a solução(projeto inteiro) - dotnet new sln --output nomeSolucao

-> Criar uma aplicação Web API - apenas API - dotnet new webapi --name nomeProjeto -f net6.0 - dentro do projeto API adicionar as libs necessarias (sqlite e design)

# Rodar proximos comandos dentro do projeto API

-> https://www.nuget.org/ - gerenciador de pacotes do .NET - pesquisar pelo nome da lib - dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.21 - dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.21  
 - para conseguir fazer as interações na estrutura do banco

-> Instalar a ferramenta de gerenciamento do Entity Framework (nao precisa ser dentro do projeto)
-> dotnet tool install --global dotnet-ef --version 6.0.21 - instala de forma global na maquina entao so precisa rodar uma vez - faz a migração: gera um "snapshot" do estado atual para o proximo estado - usada para lidar com operações de banco de dados e migrações em um projeto

## Banco de dados - SQLite

# migração

    - utilizar para qualquer alteração que precisa fazer no banco

-> dotnet ef migrations add NomeMigracao - adicionando uma migração: cria o banco de dados - apos rodar esse comando ele gera um arquivo e mostra um "snapshot" de tudo o que será feito no banco - gera uma previa da estrutura que será criada no banco - se quiser recomeçar apaga o arquivo do banco e a pasta Migrations

    -> dotnet ef database update
        - executa o que foi predefino na migração
        - executa tudo na base | faz tudo que foi mapeado na migração

    -> a estrutura do banco so vai aparecer se gerar a migração e depois mandar rodar

-> nunca mexer em nada direto no banco, pois estamos utilizando o modelo "code first" - alterações sempre no codigo

-> Pra alterar a estrutura das tabelas atraves de migrations
-> Alterar os dados = dentro da controller

# Duvida

- O front end tambem estará na mesma solução da API?

-> Mostrar tabela pro Diogo e perguntar porque possuo a chave primeira de equipe e usuario na minha tabela de tarefa - tarefa nao tem campos que se referenciam a equipe e usuario, e sim o contrario - perguntar sobre a necessidade de ter uma tabela separa que faz apenas a associação de Usuario e Tarefa

## Desenvolvimento - Explicação

# Contexto na Controller

-> Porque preciso passar o contexto como parametro do construtor da controller?
-> Ao receber o contexto como parâmetro no construtor, você está seguindo um padrão chamado "Constructor Injection" (Injeção pelo Construtor). Isso é uma forma de garantir que a TarefaController tenha acesso ao contexto do banco de dados assim que for criada, permitindo que ela realize operações de leitura e escrita no banco de dados. - ajuda a criar um código mais organizado, testável e flexível ao permitir que você forneça dependências necessárias aos seus componentes

# IActionResult

    -> IActionResult como tipo de retorno em métodos que interagem com o banco de dados ajuda a criar APIs mais flexíveis, eficazes, bem organizadas e fáceis de testar, seguindo as melhores práticas de design e padrões da ASP.NET Core.

# FirstOrDefault

    -> é um método de extensão em C# que faz parte do LINQ (Language Integrated Query), um recurso que permite realizar consultas em coleções e outros tipos de dados de forma fácil e consistente. O FirstOrDefault é usado para retornar o primeiro elemento de uma sequência ou coleção, ou um valor padrão se a sequência estiver vazia.
    -> permitindo filtrar a busca pelo primeiro elemento que atenda a uma condição específica
    -> só retorna um objeto

# OnModelCreating() - no contexto do banco

- é um método virtual que é chamado pelo Entity Framework Core quando ele está criando o modelo de dados. Você pode usar esse método para personalizar o modelo de dados.
- Cria uma chave primária composta para a tabela EquipeUsuarioTarefa. Essa chave primária é composta pelas chaves primárias das entidades Equipe, Usuario e Tarefa.

# Relacionamentos
-> Porque eu preciso ter uma chave estrangeira de Tarefa e Usuario na minha tabela Equipe se o relacionamento entre elas já está sendo feito na minha tabela EquipeUsuarioTarefa?
    - Você precisa ter uma chave estrangeira de Tarefa e Usuario na sua tabela Equipe porque o relacionamento entre elas é um relacionamento muitos para muitos.
    - A tabela EquipeUsuarioTarefa não é a única tabela que precisa representar o relacionamento muitos para muitos. A entidade Equipe também precisa representá-lo.

-> Referencia forte:
    - referencia a uma tabela em outra(id)
        - ex: referencia forte de modelo(id) em carro

# Aula 25/09 - relacionamento

-> Quando for um para muitos a chave estrangeira vai no muitos - ex: categoria vai em produtos

# Aula 02/10

-> Debug: - colocar breakpoint e cliclar no besouro+play do lado esquerdo

-> Sempre que for um pra muitos - pego minha entidade que é UM(Equipe) e coloco na entidade MUITOS(Usuario e Tarefa)

## Regras de negocios

-> Usuario: - varias tarefas - UsuarioId na Tarefa

-> Tarefa - varios usuarios - pode ser criada com usuario nulo

-> Equipe - varios usuarios - varias tarefas -

TerafaUsuario:
muitos pra muitos: - lista em cada uma das entidades - criar outra classe(entidade - tabela de associação fraca) - id, tarefa, usuario
