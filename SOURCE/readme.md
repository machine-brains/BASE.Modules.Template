# BASE.Modules.Template — Developer Briefing

> The **canonical reference module**. Copy from here when starting a
> new logical module. The shape of this module *is* the convention.

## Purpose

Template is intentionally empty of domain content but architecturally
complete: it shows the right folder layout, the right project graph
(`Application` / `Domain` / `Infrastructure` / `Shared` /
`Interfaces.*`), the right DTO / repository / service / controller
pattern, the right migration history table, and the right convention-
based registration wiring. When the canon shifts, it shifts here
first.

## Place in the Stack

- **Sits beside:** no real peers — it is a stencil, not a domain.
- **Depends on:** Sys.Substrate only.
- **Is consumed by:** developers, not code. Production builds should
  not need to reference Template.
- **Is NOT consumed by:** any runtime module. References to Template
  from production code are a smell.

## Key Concepts

- **CRUST pattern** — Create / Read / Update / State-transition /
  Transition-registry layout in the application service.
- **DTO triple** — `XReadDto`, `XWriteDto` (Create), `XWriteDto`
  (Update), per repo conventions.
- **Repository base class usage** — `CrustStateRepositoryBase<TEntity>`
  rather than hand-rolled access.
- **Controller base class usage** — `CrudStateControllerBase<>` with
  zero magic strings.
- **Schema fluent style** — all EF mapping via the schema extension
  methods, never raw fluent primitives.

## Value

Without a single canonical exemplar, modules drift apart and every
new module reinvents the wiring. Template is the moat for *speed of
new module creation*. Resources is mirrored from Template; future
modules should be too.

## Common Sliding-Off / Anti-Patterns

- **Diverging silently** in folder layout, namespace structure, or
  controller wiring. If Template needs to change, change Template
  first and propagate.
- **Adding domain content** to Template. It stays domain-neutral.
- **Referencing Template** from production code.
- **Cherry-picking** parts of Template; the value is the *whole*
  stencil, not a buffet.

## Canonical References

- `DOCUMENTATION/04.Architecture/ARCHITECTURE-API-ACCESS-PATTERN.md`
- `DOCUMENTATION/06.Development/MODULE-SOURCE-README-TEMPLATE.md`
