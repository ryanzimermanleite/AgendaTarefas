# AgendaTarefas

AGENDA DE TAREFAS  

Projeto Desenvolvido em ASP.NET Core Web App (Model-View-Controller) .NET 5.0 e C#

OBS: 
1.1 Ao instalar o Visual Studio - instale os itens abaixo:

1.2 Cargas de trabalho: (ASP.NET e desenvolvimento Web, Desenvolvimento para desktop com .NET, Processamento e armazenamento de dados)

1.3 Componentes individuais: (Runtime do .NET 5.0 (Sem suporte)*)

######################################

1 - Abrir a Solution AgendaTarefas.sln no Visual Studio

2 - Abra o arquivo appsettings.json 
   Troque a ConnectionStrings para a string de conexão do seu SQLServer 

3 - No Visual Studio va em Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador de Pacotes
    Rode o seguinte comando:

    Update-Database -Context BancoContext

5 - Rode o projeto apertando no IIS Express
