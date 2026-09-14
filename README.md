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
