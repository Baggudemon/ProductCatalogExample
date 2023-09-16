# BasketCatalog - Simple Guide
## Огляд

У цьому проекті ми створюємо просту систему каталогу продуктів. Ця система дозволяє нам додавати, редагувати та видаляти продукти та типи продуктів. Проект має дві основні складові:

1. `ProductCatalog.DB`: Бібліотека класів, яка є представленням бази даних, використовує фреймворк Entity Framework Core.
2. `ProductCatalog ASP.NET Core App`: Основний веб-додаток, створений на основі ASP.NET Core та Blazor, який надає користувацький інтерфейс і підключається до `ProductCatalog.DB`.

---

## Покрокове пояснення

### Частина 1: Налаштування бібліотеки класів `ProductCatalog.DB`

#### 1. Створення бібліотеки класів
Спочатку було розроблено нову бібліотеку класів під назвою `ProductCatalog.DB`.

#### 2. Додавання Entity Framework Core
Додано пакети NuGet Entity Framework Core для керування базою даних.

#### 3. Створення сутностей
У папці, що називається `Entities`, створено два класи :
- `Product`
- `ProductType`

Саме вони будуть представленням таблиць в базі даних.

#### 4. Створення `DbContext`
Створено новий клас під назвою `ProductCatalogDbContext`, який розширює клас `DbContext`.

```csharp
public class ProductCatalogDbContext : DbContext
{
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductType> ProductTypes { get; set; }
    
    public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфігурація бази даних тут...
    }
}
```

---

### Частина 2: Створення додатка `ProductCatalog ASP.NET Core`

#### 1. Створення веб-додатка ASP.NET Core
Створено новий веб-додаток ASP.NET Core зі стандартними налаштуваннями.

#### 2. Додавання ProductRepository
У цьому додатку ми створено клас `ProductRepository`. Цей клас містить методи для додавання, редагування та видалення `Product` та `ProductType`.

#### 3. Створення сторінок Blazor
Додано дві нові сторінки Blazor:
- `ProductEdit.razor`
- `ProductTypeEdit.razor`

#### 4. Використання бази даних
Налаштовано додаток для використання бази даних Microsoft SQL Server.

---

### Частина 3: Розуміння `ProductTypeEdit.razor`

Це одна зі сторінок Blazor, де ми можемо редагувати типи продуктів. Вона складається з таблиці, яка показує всі типи продуктів, та кнопки для редагування, збереження або видалення їх.

Наприклад, ця частина коду обробляє кнопки дій коли ми хочемо оновити інформацію в якомусь з уже доданих рядків:

```html
<td>
    @if (IsEditing(productType.Id))
    {
        <button class="btn btn-link" @onclick="() => SaveChanges(productType)">Зберегти</button>
        <button class="btn btn-link" @onclick="CancelEdit">Скасувати</button>
        <button class="btn btn-link" @onclick="() => DeleteProductType(productType)">Видалити</button>
    }
    else
    {
        <button class="btn btn-link" @onclick="() => EditProductType(productType.Id)">Редагувати</button>
    }
</td>
```

---

Ось основна інформація про проект каталогу продуктів! З його допомогою ви можете легко додавати, редагувати та керувати продуктами та їх типами. Успіхів у навчанні!