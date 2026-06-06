# Corrección — FaustinoTrivelli

> **Aviso importante:** Las soluciones se evalúan exclusivamente con los conceptos vistos en clase. Si se utilizan conceptos que no fueron parte del programa (frameworks externos, técnicas avanzadas no vistas, etc.), esas partes no serán tenidas en cuenta en la corrección.

## Nota general
**Aprobado** — Puntaje: 82/100

| Área | Obtenido | Máximo |
|---|---|---|
| Punto 1 — Jerarquía de Figuritas | 17 | 20 |
| Punto 2 — Album | 23 | 25 |
| Punto 3 — GestorDeCanjeService | 25 | 25 |
| Punto 4 — Validaciones | 12 | 15 |
| Punto 5 — Tests NUnit | 10 | 10 |
| Estructura de proyecto | 5 | 5 |
| **Total** | **82** | **100** |

## Correcciones de evaluación

### Estructura del proyecto (5/5)
- Archivo `SolucionAlbumMundial.sln` presente en la raíz. ✓
- Proyecto de tests `AlbumMundialTest` presente y referenciado en la solución. ✓
- Estructura de carpetas ordenada y coherente. ✓

### Punto 1 — Jerarquía de Figuritas (17/20)

**Lo que está bien:**
- `Figurita` es una clase abstracta. ✓
- Propiedades `Numero` (int) y `Pais` (string) presentes con visibilidad pública. ✓
- Constructor de `Figurita` con los parámetros correctos. ✓
- `FiguritaComun` hereda de `Figurita` y tiene la propiedad `Rareza` (int). ✓
- `FiguritaBrillante` hereda de `Figurita` y tiene la propiedad `EsEdicionLimitada` (bool). ✓
- El retorno de `FiguritaComun.ConsultarCategoria()` es `"Común (Rareza: X)"` — formato correcto. ✓
- El retorno de `FiguritaBrillante.ConsultarCategoria()` es `"Brillante (Edición Limitada)"` o `"Brillante"` según corresponda. ✓
- El método abstracto se llama `ConsultarCategoria()` en lugar de `ObtenerCategoria()`, pero la lógica es correcta y ambas subclases lo sobreescriben con `override` correctamente. ✓

**Problemas encontrados:**

1. **(-3 pts) La propiedad se llama `Nombre` en lugar de `NombreJugador`.** El enunciado pide explícitamente `NombreJugador` como nombre de la propiedad. Usar `Nombre` no es equivalente; cualquier código externo que dependa del contrato del enunciado fallaría.

### Punto 2 — Album (23/25)

**Lo que está bien:**
- La lista interna está declarada como `protected`. ✓
- Sobrecargas de `AgregarFigurita`: una firma `(Figurita)` y otra `(Figurita, int cantidad)` — mismo nombre, distinta firma. ✓
- Sobrecargas de `TieneRepetida`: una firma `(Figurita)` y otra `(int numeroDeFigurita)` — mismo nombre, distinta firma. ✓
- `TieneRepetida(Figurita)` delega en `TieneRepetida(int)` — buena práctica de reutilización. ✓
- `ObtenerRepetidas()` devuelve una lista sin duplicar de figuritas con más de una copia. ✓
- Validación de `cantidad <= 0` en `AgregarFigurita(Figurita, int)`. ✓
- La lista `Figuritas` se inicializa de forma inline en la declaración — ambas formas (inline o en constructor) son válidas. ✓

**Problemas encontrados:**

1. **(-2 pts) La propiedad del álbum se llama `Nombre` en lugar de `NombreColeccionista`.** El enunciado especifica `NombreColeccionista` como nombre de la propiedad. Es un error de nomenclatura que no respeta el contrato pedido.

### Punto 3 — GestorDeCanjeService (25/25)

**Lo que está bien:**
- La lista interna `Albums` está declarada como `protected`. ✓
- `RegistrarAlbum(Album)` presente y funcional. ✓
- Sobrecargas de `Canjear`: una firma `(Album, Album, int numeroDeFigurita)` y otra `(Album, Album, Figurita)` — mismo nombre, distinta firma. ✓
- `Canjear(Album, Album, Figurita)` remueve una copia del origen y la agrega al destino. ✓
- `ObtenerAlbumConMasRepetidas()` retorna `null` si no hay álbumes registrados. ✓
- La lógica de `ObtenerAlbumConMasRepetidas()` usa `CantidadRepetidasTotales()` para comparar correctamente. ✓
- La lista `Albums` se inicializa de forma inline en la declaración — ambas formas (inline o en constructor) son válidas. ✓

### Punto 4 — Validaciones (12/15)

**Lo que está bien:**
- `Numero <= 0` → `ArgumentException`. ✓
- `NombreJugador` vacío/espacios → `string.IsNullOrWhiteSpace` → `ArgumentException`. ✓
- `Rareza < 1 || rareza > 5` → `ArgumentException`. ✓
- `cantidad <= 0` en `AgregarFigurita(Figurita, int)` → `ArgumentException`. ✓
- Canje con origen sin repetida → `ArgumentException`. ✓
- Canje con destino ya poseyendo la figurita → `ArgumentException`. ✓

**Problemas encontrados:**

1. **(-3 pts) No se valida que `Pais` no sea nulo ni vacío.** El enunciado implica que las propiedades de `Figurita` deben ser válidas; la validación de `Nombre`/`NombreJugador` está correctamente implementada con `IsNullOrWhiteSpace`, pero `Pais` no tiene ninguna validación equivalente, quedando incompleta la cobertura de validaciones para las propiedades de la clase base.

### Punto 5 — Tests NUnit (10/10)

**Lo que está bien:**
- Clase de tests con `[TestFixture]`. ✓
- Todos los métodos de test con `[Test]`. ✓
- Framework NUnit correctamente referenciado (NUnit 3.14.0). ✓
- Los 5 tests requeridos están presentes:
  1. `AgregarFiguritaConCantidad_RegistroTresCopias_YApareceEnRepetidas` — agrega 3 copias, verifica que `TieneRepetida` y `ObtenerRepetidas` funcionan. ✓
  2. `TieneRepetida_DevuelveTrueOSegunCantidad` — verifica false con 1 copia y true con 2 copias. ✓
  3. `Canjear_Valido_OrigenPierdeCopia_DestinoRecibe` — canje válido, origen pierde copia, destino la recibe. ✓
  4. `Canjear_LanzaExcepcion_SiDestinoYaPoseeFigurita` — excepción cuando destino ya tiene la figurita. ✓
  5. `Canjear_LanzaExcepcion_SiOrigenNoTieneRepetida` — excepción cuando origen solo tiene una copia. ✓
- Los asserts usan la sintaxis de restricciones de NUnit (`Assert.That` con `Is.True`, `Is.False`, `Is.EqualTo`, `Throws.TypeOf<>`). ✓

## Observaciones importantes

- **Nomenclatura:** Los nombres `Nombre` (en `Figurita` y en `Album`) difieren de los especificados en el enunciado (`NombreJugador`, `NombreColeccionista`). En un examen o proyecto real, respetar los nombres del contrato es fundamental para la interoperabilidad entre componentes.
- **Tests excelentes:** La cobertura de los 5 tests es sólida, los nombres son descriptivos, y el uso de la API de NUnit es correcto. Muy buen trabajo en esta sección.
- **Lógica general:** La lógica de negocio (canje, repetidas, categorías) está correctamente implementada. El uso de LINQ es apropiado y el diseño es limpio.
