# Bomtrato-ProcessManager-App

git clone https://github.com/FelipeDwD/Bomtrato-ProcessManager-App.git

A aplicação está composta por 3 projetos:

1. Bomtrato.ProcessManager.App.WebAPI;
2. chat-app;
3. process-manager-app.

## Executando API (Bomtrato.ProcessManager.App.WebAPI):

Para rodar o projeto é necessário ter instalado em sua máquina o SDK 3.1.4 do .NET Core, a api está toda desenvolvida em 3.1

Antes de buildar o projeto, alterar o arquivo **appsettings.json**  que fica na pasta Bomtrato-ProcessManager-App/Bomtrato.ProcessManager.App.WebAPI/Bomtrato.ProcessManager.App.WebAPI.Application/appsettings.json.

Deverá ser trocado a string de conexão, string atual: "Server=localhost\\SQLExpress;Database=Bomtrato;User Id=sa;Password=123;"

Alterar para: "Server=localhost\\SQLExpress;Database=Bomtrato;User Id=yourNameUser;Password=yourPassword;"

**yourNameUser**: Nome de usuário no seu banco de dados, que está instalado em sua máquina;


**yourPassword**: Senha do usuário referente ao banco de dados.


Após os parâmetros na string de conexão devemos rodar um **Update-Database**, para executar:

No visual studio:

1. Clique em *Tools* (Ferramentas);

2. Selecione *NuGet Package Manager* (Gerenciador de pacotes do NuGet);

3. Clique em *Package Manager Console* (Pacote de gerenciamento de console);

4. Após abrir o console, você deverá selecionar a camada **Bomtrato.ProcessManager.App.WebAPI.Data**;

5. Após selecionada a camada **Bomtrato.ProcessManager.App.WebAPI.Data**, rodar o comando **Update-Database**;

6. Esse comando deverá ler nossa migration *CreateTables*  que está em Bomtrato.ProcessManager.App.WebAPI.Data/Migrations/;

7. Após executado validar se foi criado a base e as tabelas, no seu banco de dados na aba *databases*, procure por Bomtrato -> botão direito do mouse, *new query*:

Rodar essas querys:

SELECT * FROM [dbo].[Approver]

SELECT * FROM [dbo].[Office]

SELECT * FROM [dbo].[Process]

Se retornar as tabelas, a migração do EF Core foi realizada com sucesso.

Opcional: Foi criado um script de insert na pasta **scripts**, se você quiser rodar ele quando você subir a aplicação você já terá alguns usuários e escritórios cadastrados;

Após isso, você poderá subir a API, para subir selecione Dev no lançador de aplicações do visual studio. Selecionando Dev a api irá abrir seu navegador com o swagger, sendo assim a api já vai estar rodando.

## Executando Chat (chat-app):

1. Você deverá abrir a pasta em que ele está localizado (Bomtrato-ProcessManager-App/chat-app/);

2. Dentro dessa pasta abrir o cmd e executar **npm start**;

3. Após executar o comando você pode verificar se ele subiu através do navegador, na porta 3000, Url: http://localhost:3000/;

4. Após verificar você pode fechar essa aba se quiser, pois nós vamos ter acesso a ela, através do outro projeto (process-manager-app);

## Executando aplicação angular (process-manager-app):

Esse projeto foi desenvolvido com angular 11.

1. Você deverá abrir a pasta em que ele esta localizado (Bomtrato-ProcessManager-App/process-manager-app/);

2. Dentro dessa pasta abrir o cmd;

3. Após o cmd aberto dentro desse diretório, rodar o comando **ng serve**;

4. Essa aplicação irá subir na porta 4200; 

5. Ou seja, para validar, abra seu navegador e acesse a url: http://localhost:4200;

5. Se aparecer a página de login, significa que subiu com sucesso.


### OBS: Para aproveitar melhor o chat, abra duas abas diferentes na url: http://localhost:4200 , e faça login com dois usuários diferentes, após isso acesse o chat, selecione a sala processos e entre na sala. Sendo assim já vai ser possível um usuário falar com outro.







