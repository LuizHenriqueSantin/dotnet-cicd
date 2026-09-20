# dotnet-cicd

Projeto simples em .NET 10 usado para praticar um fluxo completo de CI/CD com GitHub Actions.

## Estrutura

- `src/Calculator`: biblioteca de classes com as operações da calculadora.
- `tests/Calculator.Tests`: testes xUnit da biblioteca.

## Operações disponíveis

- Add
- Subtract
- Multiply
- Divide (lança `DivideByZeroException` quando o divisor é zero)

## Rodando localmente

```
dotnet test
```

## CI

O workflow em `.github/workflows/ci.yml` builda e roda os testes a cada push e pull request para `main`.

## Qualidade de código

O workflow em `.github/workflows/code-quality.yml` verifica a formatação do código com `dotnet format --verify-no-changes` a cada push e pull request para `main`.

## CD

O workflow em `.github/workflows/cd.yml` empacota a biblioteca `Calculator` em um pacote NuGet:

- Em pull requests, apenas builda e empacota o projeto como validação (artefato disponível para download na execução do workflow).
- Em pushes para `main`, além de empacotar, publica o pacote no GitHub Packages.

## Alertas

O workflow em `.github/workflows/notify.yml` envia um alerta para o Discord sempre que o workflow de CI termina (sucesso ou falha) em um commit ou merge na branch `main`. A mensagem inclui o status, o autor, o commit e o link para a execução.

Para habilitar, crie um webhook no canal do Discord desejado (Configurações do canal → Integrações → Webhooks → Novo Webhook) e cadastre a URL como secret do repositório:

1. No GitHub, vá em `Settings` → `Secrets and variables` → `Actions` → `New repository secret`.
2. Nome: `DISCORD_WEBHOOK_URL`.
3. Valor: a URL do webhook do Discord.

## Docker

O `Dockerfile` na raiz do repositório builda a `Calculator.Api` (Web API mínima que expõe a biblioteca `Calculator`) e a executa dentro de um container.

Build da imagem:

```
docker build -t dotnet-cicd-demo .
```

Rodar o container:

```
docker run -d -p 8080:8080 --name calculator-api dotnet-cicd-demo
```

Verificar que está rodando:

```
docker ps
```

Testar os endpoints:

```
curl http://localhost:8080/health
curl "http://localhost:8080/calculator/add?a=2&b=3"
```


