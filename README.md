# 🩸 Banco de Sangue API

## 🚀 Sobre o Projeto
Este projeto é uma Web API desenvolvida para gerenciar um banco de sangue. A API oferece diversas funcionalidades essenciais para o controle de doadores e doações, implementando operações básicas e seguindo o padrão API RESTful. Além disso, a aplicação foi estruturada com Arquitetura Limpa para garantir melhor organização e manutenção do código.

## 🛠️ Funcionalidades
- 🩸 Cadastro e consulta de doadores
- 💉 Cadastro e consulta de doações
- 📦 Geração automática de estoques com base nas doações
- 📊 Criação e exibição de relatórios de doadores e estoques

## 🧰 Tecnologias Utilizadas
- ⚙️ ASP.NET Core 8.0 — Framework para desenvolvimento da API
- 📈 Fast Reports — Para criação de relatórios
- 📜 Swagger — Ferramenta de documentação interativa

## 🚧 Melhorias Futuras
- 📝 Padrão CQRS
- 🗂️ Padrão Repository
- ✅ Validação com Fluent Validation

## 🔧 Instalação

1 - Clone o repositório:

`git clone https://github.com/SgCafe/Donate-Blood.git`

2 - Navegue até o diretório do projeto:

`cd Donate-Blood`

3 - Restaure os pacotes NuGet:

`dotnet restore`

4 - Compile o projeto:

`dotnet build`

5 - Inicie a aplicação:

`dotnet run`

## 🔍 Como Usar
- Após rodar a aplicação, você pode acessar a documentação interativa gerada pelo Swagger através do seguinte link:

`http://localhost:5000/swagger`

- Utilize a interface do Swagger para testar os endpoints da API e interagir com as funcionalidades disponíveis.
