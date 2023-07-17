# AgendaTarefas

Projeto Desenvolvido em ASP.NET Core Web App (Model-View-Controller) .NET 5.0 e C#

## Durante a instalação do Visual Studio - instale os itens abaixo:

#### 1.1 Cargas de trabalho: (ASP.NET e desenvolvimento Web, Desenvolvimento para desktop com .NET, Processamento e armazenamento de dados)

#### 1.2 Componentes individuais: (Runtime do .NET 5.0 (Sem suporte))

------------------------------------------------------------------------------

# Como rodar o projeto:

#### 1 - Faça download dos arquivos e em abrir projeto ou uma solução no Visual Studio abra o arquivo AgendaTarefas.sln

#### 2 - Nos arquivos do projeto (Gerenciador de Soluções) Abra o arquivo appsettings.json 
   Edite a "DataBase": para a string de conexão do seu SQLServer 

#### 3 - No Visual Studio va em Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador de Pacotes
    Rode o seguinte comando:

    Update-Database -Context BancoContext

#### 4 - Rode o projeto apertando no IIS Express
