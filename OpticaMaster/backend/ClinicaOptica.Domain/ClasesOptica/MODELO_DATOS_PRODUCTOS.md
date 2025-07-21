# 📦 Modelo de Datos de Productos y Armazones

## 🎯 Objetivo
Definir la estructura profesional y escalable para la gestión de productos y atributos de armazones en la óptica, facilitando la integración con IA y la gestión de inventario.

---

## 🗂️ Estructura de Tablas

### Tabla Producto
```sql
CREATE TABLE Producto (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Tipo VARCHAR(30) NOT NULL, -- armazon, lente, liquido, accesorio, etc.
    Descripcion TEXT,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Activo BOOLEAN DEFAULT TRUE
);
```

### Tabla ArmazonAtributos
```sql
CREATE TABLE ArmazonAtributos (
    ProductoId INT PRIMARY KEY REFERENCES Producto(Id),
    Forma VARCHAR(30),
    Color VARCHAR(30),
    Material VARCHAR(30),
    TamañoAncho INT,
    TamañoAlto INT,
    TamañoPuente INT,
    Genero VARCHAR(20),
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    FotoUrl TEXT
);
```

---

## 🔄 Ejemplo de Consulta para IA

```sql
SELECT p.*, a.*
FROM Producto p
JOIN ArmazonAtributos a ON p.Id = a.ProductoId
WHERE p.Tipo = 'armazon'
  AND p.Stock > 0
  AND a.Forma = 'rectangular'
  AND a.Color = 'negro';
```

---

## 🏆 Buenas Prácticas
- Registrar todos los atributos relevantes al dar de alta un armazón.
- Mantener actualizado el stock y el campo Activo.
- Solo los productos tipo 'armazon' deben tener registro en ArmazonAtributos.
- Validar que no existan armazones sin atributos o atributos sin producto.
- Usar claves foráneas y restricciones para mantener la integridad referencial.

---

## 📈 Escalabilidad y Flexibilidad
- Si en el futuro necesitas más atributos, solo agrega columnas a ArmazonAtributos.
- Si agregas nuevos tipos de productos, no afecta la estructura de armazones.
- Puedes agregar tablas relacionadas para fotos adicionales, colecciones, etc.

---

## 📚 Referencia
- Este archivo complementa la documentación de entidades en `README.md`.
- Para lógica de IA y recomendaciones, ver el README del microservicio de IA. 