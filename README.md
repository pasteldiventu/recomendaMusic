# 🎶 Music Recommendation Engine - API (C# ASP.NET Core)

## 📖 Visão Geral

Este projeto é um **Motor de Recomendação de Músicas** desenvolvido em **C# com ASP.NET Core**. O principal objetivo é praticar **Design Patterns** aplicados em um contexto real, com foco em:

* **Gerenciamento de Playlists**
* **Recomendações de Músicas Personalizadas**

Estruturado seguindo o padrão **Clean Architecture**, o projeto promove separação clara de responsabilidades entre API, Domínio e Infraestrutura.

---

## 📂 Estrutura Atual do Projeto

```
recomendaMusic/
│
├── src/
│   ├── api/ (Camada de Apresentação)
│   │   ├── controllers/RecommendationController.cs
│   │   ├── DTOs/ (PlaylistDto.cs, TrackDto.cs)
│   │   └── Program.cs
│   │
│   ├── domain/ (Regra de Negócio)
│   │   ├── Entities/ (IMediaItem.cs, Track.cs, Playlist.cs)
│   │   ├── Interfaces/ (IRecommendationEngine.cs, IRecommendationStrategy.cs, IPlaylistRepository.cs)
│   │   └── Patterns/Strategy/
│   │       ├── GenreRecommendationStrategy.cs
│   │       ├── PopularTracksRecommendationStrategy.cs
│   │       └── RecentTracksRecommendationStrategy.cs
│   │
│   └── infrastructure/ (Infraestrutura, Repositórios)
│       └── Repositories/InMemoryPlaylistRepository.cs
```

---

## 📝 O que foi implementado até agora

* **Entities:**

  * `IMediaItem`, `Track`, `Playlist`
* **Interfaces:**

  * `IRecommendationEngine`, `IRecommendationStrategy`,`IPlaylistRepository`
* **Services:**

  * `RecommendationEngine` com injeção de estratégia de recomendação
* **Design Pattern (Strategy):**

  * `GenreRecommendationStrategy` como implementação inicial de recomendação
* **Controller:**

  * `RecommendationController` expõe o endpoint `/api/recommendation/recommend` para receber playlists e retornar recomendações
* **Dependency Injection:**

  * Configurado no `Program.cs` para injetar Engine e Strategy dinamicamente

---

## 🔮 Próximos Passos

### 📌 Curto Prazo

* [X] Criar **DTOs** para separar domínio e apresentação
* [] Implementar mais estratégias de recomendação:

  * `RecentTracksRecommendationStrategy`
  * `PopularTracksRecommendationStrategy`
* [] Implementar **IPlaylistRepository** com `InMemoryPlaylistRepository` para simulação

### 📌 Médio Prazo

* [ ] Adicionar camada **Infrastructure** com persistência usando Entity Framework + SQLite
* [ ] Criar projeto de **Testes Unitários** para `Domain.Tests` e `API.Tests`
* [ ] Implementar o **Factory Pattern** para seleção dinâmica de estratégias via API.

### 📌 Longo Prazo

* [ ] Aplicar **Observer Pattern** para eventos (notificação em atualizações)
* [ ] Aplicar **Singleton Pattern** para cache ou log global
---

## 🎁 Produto Final Esperado

* Uma API robusta capaz de:

  * Criar e gerenciar playlists
  * Retornar recomendações de músicas baseadas em diferentes estratégias
  * Persistir dados em banco de dados
  * Ser testável com cobertura unitária
* **Código limpo, modular, seguindo princípios de SOLID e Design Patterns.**
* Um projeto que simula uma recomendação de música como faria um sistema real, porém idealizado para prática de arquitetura e padrões.

---

## 🚀 Tecnologias Utilizadas

* ASP.NET Core (Web API)
* C# 12
* Dependency Injection nativa
* Clean Architecture(simplificada)
* Design Patterns: Strategy (com 3 implementações), Repository (com simulação em memória), Factory, Observer, Singleton (planejados).
* Testes: xUnit (planejado)
* Entity Framework Core (planejado)

---

## ✅ Status Atual

>✅ API funcional com 3 estratégias de recomendação intercambiáveis.
>✅ Repositório em memória implementado para simulação de dados.
>✅ Estrutura pronta para evoluir com persistência real e testes.
