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

## Docker

O `Dockerfile` na raiz do repositório builda a solução e roda a suíte de testes da `Calculator` dentro do container.

Build da imagem:

```
docker build -t dotnet-cicd-demo .
```

Rodar o container (executa os testes e mostra o resultado):

```
docker run --rm dotnet-cicd-demo
```


