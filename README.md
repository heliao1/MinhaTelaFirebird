# MinhaTelaFirebird

Aplicação Windows Forms em C# para consulta e pesquisa de dados em um banco de dados Firebird.

## Funcionalidades

- Carrega e exibe dados da tabela `EMPRESAS` em um grid
- Pesquisa integrada de empresas por nome e CNPJ, com join em `HISTORICOS` e `FUNCIONARIOS`
- Abertura de tela secundária (Form2) em aba integrada

## Requisitos

- .NET Framework 4.7.2
- [Firebird Server](https://firebirdsql.org/) rodando localmente
- Arquivo de banco `.fdb` acessível na máquina

## Dependências NuGet

| Pacote | Versão |
|--------|--------|
| FirebirdSql.Data.FirebirdClient | 10.3.4 |
| System.Reflection.Emit | 4.7.0 |
| System.Runtime.CompilerServices.Unsafe | 6.1.0 |
| System.Threading.Tasks.Extensions | 4.6.0 |

## Configuração

Antes de executar, edite `Form1.cs` e ajuste a variável `caminhoBanco` com o caminho real do seu arquivo `.fdb`:

```csharp
string caminhoBanco = @"C:\SeuCaminho\seubanco.fdb";
```

As credenciais padrão usadas são `SYSDBA` / `masterkey`. Altere conforme o seu ambiente.

## Como executar

Abra `MinhaTelaFirebird.slnx` no Visual Studio, compile e execute (F5).
