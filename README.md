# Activity Diagram for API-Stok-1

```mermaid
flowchart TD
    A[Start] --> B[AppUser]
    B --> C[Stock]
    C --> D[CreateStockRequestDto]
    C --> E[Comment]
    E --> F[CreateComment]
    F --> G[GetComments]
    G --> H[UpdateComment]
    H --> I[DeleteComment]
    I --> J[End]

    C --> K[GetStocks]
    K --> L[GetStock]
    L --> M[CreateStock]
    M --> N[UpdateStock]
    N --> O[DeleteStock]
    O --> J
