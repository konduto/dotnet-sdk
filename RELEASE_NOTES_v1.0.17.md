# KdtSdk v1.0.17

## 🐛 Correções

- **Fix crítico: campo `purchase_at` renomeado para `purchased_at`** — a tabela da documentação oficial da Konduto contém um typo (`purchase_at`), mas o exemplo JSON oficial e a API usam `purchased_at`. A API sempre rejeitou o nome antigo com HTTP 400 (`unknown field: purchase_at`), portanto quem usava a propriedade `PurchaseAt` recebia erro — agora o campo é enviado corretamente.
- Removidos campos que não existem na documentação oficial da Konduto (revisão contra os schemas oficiais):
  - `payment`: `currency`, `installments` (existem apenas na raiz do pedido)
  - `boleto`: `barcode`
  - `transfer`: `bank_code`, `bank_branch`, `bank_account`
  - `pix`: `key_type`, `key_value`, `end_to_end_id`, `qr_code`, `expiration_date`, `status`
  - `balance`: `user_id`
  - `passenger`: `frequent_flyer`, `loyalty_program` (docs usam `loyalty{program,category}`)
  - `travel`: `itinerary`
  - `travel_information`: `flight_number`

## ✨ Melhorias

- Mapeamento do payload de pedidos alinhado com a documentação oficial da Konduto
- Metadados NuGet adicionados ao pacote (authors, description, repository, tags, README)
- Versão sincronizada em todos os pontos (csproj, `AssemblyInfo`, constante `VERSION` do User-Agent, que estava desatualizada em 1.0.12)

## ✅ Qualidade

- 57/57 testes aprovados, incluindo testes de integração contra a API real da Konduto

## 📦 Instalação

```
dotnet add package KdtSdk --version 1.0.17
```

**Full Changelog**: https://github.com/konduto/dotnet-sdk/compare/v1.0.16...v1.0.17

