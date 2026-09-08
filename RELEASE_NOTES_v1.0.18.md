# KdtSdk v1.0.18

## ✨ Melhorias

- **Campo `visitor` agora é opcional** — o SDK exigia o `visitor` na validação do pedido (`Required.Always`), impedindo o envio de pedidos sem o identificador do JavaScript (ex.: integrações server-side, POS, Safe Banking). Agora o campo é opcional: quando não informado, é simplesmente omitido do JSON enviado à API.

## 📝 Outras mudanças

- Teste `KondutoOrderTest.IsValidTest` atualizado para cobrir pedidos válidos sem `visitor`
- README atualizado: `visitor` marcado como `(optional)` na tabela de parâmetros do pedido

## ✅ Qualidade

- 57/57 testes aprovados, incluindo testes de integração contra a API real da Konduto

## 📦 Instalação

```
dotnet add package KdtSdk --version 1.0.18
```

**Full Changelog**: https://github.com/konduto/dotnet-sdk/compare/v1.0.17...v1.0.18

