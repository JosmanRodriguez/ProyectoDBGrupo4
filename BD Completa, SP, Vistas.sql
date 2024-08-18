CREATE TABLE TIENDA (
    id INT PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    ubicaciones VARCHAR(40) NOT NULL,
    horario VARCHAR(20) NOT NULL
) COMMENT 'Tabla que almacena la información de las tiendas';

CREATE TABLE bitacora (
    id INT AUTO_INCREMENT PRIMARY KEY,
    accion VARCHAR(15) NOT NULL CHECK (accion IN ('CREAR', 'MODIFICAR', 'ELIMINAR')),
    tabla VARCHAR(30) NOT NULL,
    fecha DATETIME NOT NULL
) COMMENT 'Tabla para almacenar las acciones realizadas en la base de datos';

CREATE TABLE PRODUCTO (
    UPC CHAR(12) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    tamaño VARCHAR(30) NOT NULL,
    embalaje VARCHAR(30) NOT NULL,
    marca VARCHAR(50) NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL CHECK (precio >= 0),
    cantidad INT NOT NULL CHECK (cantidad >= 0),
    reorden INT NOT NULL CHECK (reorden >= 0)
) COMMENT 'Tabla que almacena la información de los productos';

CREATE TABLE VENDEDOR (
    id INT PRIMARY KEY,
    nombre1 VARCHAR(20) NOT NULL,
    nombre2 VARCHAR(20),
    apellido1 VARCHAR(20) NOT NULL,
    apellido2 VARCHAR(20)
) COMMENT 'Tabla que almacena la información de los vendedores';

CREATE TABLE CLIENTE (
    id INT PRIMARY KEY,
    nombre1 VARCHAR(20) NOT NULL,
    nombre2 VARCHAR(20),
    apellido1 VARCHAR(20) NOT NULL,
    apellido2 VARCHAR(20),
    correoElectronico VARCHAR(50) NOT NULL CHECK (correoElectronico LIKE '%@%')
) COMMENT 'Tabla que almacena la información de los clientes';

CREATE TABLE FACTURA (
    numero INT PRIMARY KEY,
    fecha DATE NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL CHECK (subtotal >= 0),
    ISV DECIMAL(10, 2) NOT NULL CHECK (ISV >= 0),
    TOTAL DECIMAL(10, 2) NOT NULL CHECK (TOTAL >= 0),
    cliente_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES CLIENTE(id)
) COMMENT 'Tabla que almacena la información de las facturas';

CREATE TABLE DETALLE_FACTURA (
    id INT PRIMARY KEY AUTO_INCREMENT,
    factura_numero INT NOT NULL,
    producto_UPC CHAR(12) NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    FOREIGN KEY (factura_numero) REFERENCES FACTURA(numero),
    FOREIGN KEY (producto_UPC) REFERENCES PRODUCTO(UPC)
) COMMENT 'Tabla que almacena los detalles de las facturas';

CREATE TABLE TIENDA_PRODUCTO (
    tienda_id INT NOT NULL,
    producto_UPC CHAR(12) NOT NULL,
    PRIMARY KEY (tienda_id, producto_UPC),
    FOREIGN KEY (tienda_id) REFERENCES TIENDA(id),
    FOREIGN KEY (producto_UPC) REFERENCES PRODUCTO(UPC)
) COMMENT 'Tabla intermedia para la relación entre tiendas y productos';

CREATE TABLE PRODUCTO_VENDEDOR (
    producto_UPC CHAR(12) NOT NULL,
    vendedor_id INT NOT NULL,
    PRIMARY KEY (producto_UPC, vendedor_id),
    FOREIGN KEY (producto_UPC) REFERENCES PRODUCTO(UPC),
    FOREIGN KEY (vendedor_id) REFERENCES VENDEDOR(id)
) COMMENT 'Tabla intermedia para la relación entre productos y vendedores';

DELIMITER $$

-- Procedimiento para crear una tienda
CREATE PROCEDURE crear_tienda(
    IN p_id INT,
    IN p_nombre VARCHAR(50),
    IN p_ubicaciones VARCHAR(80),
    IN p_horario VARCHAR(50)
)
BEGIN
    INSERT INTO TIENDA (id, nombre, ubicaciones, horario) 
    VALUES (p_id, p_nombre, p_ubicaciones, p_horario);
END$$

-- Procedimiento para crear un producto
CREATE PROCEDURE crear_producto(
    IN p_UPC CHAR(12),
    IN p_nombre VARCHAR(50),
    IN p_tamaño VARCHAR(30),
    IN p_embalaje VARCHAR(30),
    IN p_marca VARCHAR(50),
    IN p_tipo VARCHAR(50),
    IN p_precio DECIMAL(10, 2),
    IN p_cantidad INT,
    IN p_reorden INT
)
BEGIN
    INSERT INTO PRODUCTO (UPC, nombre, tamaño, embalaje, marca, tipo, precio, cantidad, reorden) 
    VALUES (p_UPC, p_nombre, p_tamaño, p_embalaje, p_marca, p_tipo, p_precio, p_cantidad, p_reorden);
END$$

-- Procedimiento para crear un vendedor
CREATE PROCEDURE crear_vendedor(
    IN p_id INT,
    IN p_nombre1 VARCHAR(20),
    IN p_nombre2 VARCHAR(20),
    IN p_apellido1 VARCHAR(20),
    IN p_apellido2 VARCHAR(20)
)
BEGIN
    INSERT INTO VENDEDOR (id, nombre1, nombre2, apellido1, apellido2) 
    VALUES (p_id, p_nombre1, p_nombre2, p_apellido1, p_apellido2);
END$$

DELIMITER ;

DELIMITER $$

-- Procedimiento para modificar una tienda
CREATE PROCEDURE modificar_tienda(
    IN p_id INT,
    IN p_nombre VARCHAR(50),
    IN p_ubicaciones VARCHAR(80),
    IN p_horario VARCHAR(50)
)
BEGIN
    UPDATE TIENDA 
    SET nombre = p_nombre, ubicaciones = p_ubicaciones, horario = p_horario 
    WHERE id = p_id;
END$$

-- Procedimiento para modificar un producto
CREATE PROCEDURE modificar_producto(
    IN p_UPC CHAR(12),
    IN p_nombre VARCHAR(50),
    IN p_tamaño VARCHAR(30),
    IN p_embalaje VARCHAR(30),
    IN p_marca VARCHAR(50),
    IN p_tipo VARCHAR(50),
    IN p_precio DECIMAL(10, 2),
    IN p_cantidad INT,
    IN p_reorden INT
)
BEGIN
    UPDATE PRODUCTO 
    SET nombre = p_nombre, tamaño = p_tamaño, embalaje = p_embalaje, marca = p_marca, tipo = p_tipo, precio = p_precio, cantidad = p_cantidad, reorden = p_reorden 
    WHERE UPC = p_UPC;
END$$

-- Procedimiento para modificar un vendedor
CREATE PROCEDURE modificar_vendedor(
    IN p_id INT,
    IN p_nombre1 VARCHAR(20),
    IN p_nombre2 VARCHAR(20),
    IN p_apellido1 VARCHAR(20),
    IN p_apellido2 VARCHAR(20)
)
BEGIN
    UPDATE VENDEDOR 
    SET nombre1 = p_nombre1, nombre2 = p_nombre2, apellido1 = p_apellido1, apellido2 = p_apellido2 
    WHERE id = p_id;
END$$

DELIMITER ;

DELIMITER $$

-- Procedimiento para eliminar una tienda
CREATE PROCEDURE eliminar_tienda(IN p_id INT)
BEGIN
    DELETE FROM TIENDA WHERE id = p_id;
END$$

-- Procedimiento para eliminar un producto
CREATE PROCEDURE eliminar_producto(IN p_UPC CHAR(12))
BEGIN
    DELETE FROM PRODUCTO WHERE UPC = p_UPC;
END$$

-- Procedimiento para eliminar un vendedor
CREATE PROCEDURE eliminar_vendedor(IN p_id INT)
BEGIN
    DELETE FROM VENDEDOR WHERE id = p_id;
END$$

DELIMITER ;

CREATE VIEW inventario_productos AS
SELECT UPC, nombre, cantidad, precio, reorden
FROM PRODUCTO;

CREATE VIEW compras_por_cliente AS
SELECT 
    c.id, c.nombre1, c.nombre2, c.apellido1, c.apellido2, 
    f.numero, f.fecha, 
    df.producto_UPC, df.cantidad, 
    (df.cantidad * p.precio) AS total
FROM CLIENTE c
JOIN FACTURA f ON c.id = f.cliente_id
JOIN DETALLE_FACTURA df ON f.numero = df.factura_numero
JOIN PRODUCTO p ON df.producto_UPC = p.UPC;

CREATE VIEW historial_ventas_tienda AS
SELECT 
    t.id, t.nombre, 
    f.numero, f.fecha, 
    df.producto_UPC, df.cantidad, 
    (df.cantidad * p.precio) AS total
FROM TIENDA t
JOIN TIENDA_PRODUCTO tp ON t.id = tp.tienda_id
JOIN PRODUCTO p ON tp.producto_UPC = p.UPC
JOIN DETALLE_FACTURA df ON p.UPC = df.producto_UPC
JOIN FACTURA f ON df.factura_numero = f.numero;

CREATE VIEW top_20_productos_tienda AS
SELECT 
    t.id AS tienda_id, 
    t.nombre AS tienda_nombre, 
    p.UPC, 
    p.nombre AS producto_nombre, 
    SUM(df.cantidad) AS total_vendido
FROM 
    TIENDA t
JOIN 
    TIENDA_PRODUCTO tp ON t.id = tp.tienda_id
JOIN 
    PRODUCTO p ON tp.producto_UPC = p.UPC
JOIN 
    DETALLE_FACTURA df ON p.UPC = df.producto_UPC
GROUP BY 
    t.id, t.nombre, p.UPC, p.nombre
ORDER BY 
    total_vendido DESC
LIMIT 20;

CREATE VIEW top_20_productos_pais AS
SELECT 
    t.ubicaciones AS pais, 
    p.UPC, 
    p.nombre AS producto_nombre, 
    SUM(df.cantidad) AS total_vendido
FROM 
    TIENDA t
JOIN 
    TIENDA_PRODUCTO tp ON t.id = tp.tienda_id
JOIN 
    PRODUCTO p ON tp.producto_UPC = p.UPC
JOIN 
    DETALLE_FACTURA df ON p.UPC = df.producto_UPC
GROUP BY 
    t.ubicaciones, p.UPC, p.nombre
ORDER BY 
    total_vendido DESC
LIMIT 20;

CREATE VIEW top_5_tiendas_ventas_anio AS
SELECT 
    t.id AS tienda_id, 
    t.nombre AS tienda_nombre, 
    SUM(df.cantidad * p.precio) AS total_ventas
FROM 
    TIENDA t
JOIN 
    TIENDA_PRODUCTO tp ON t.id = tp.tienda_id
JOIN 
    PRODUCTO p ON tp.producto_UPC = p.UPC
JOIN 
    DETALLE_FACTURA df ON p.UPC = df.producto_UPC
JOIN 
    FACTURA f ON df.factura_numero = f.numero
WHERE 
    YEAR(f.fecha) = YEAR(CURDATE())
GROUP BY 
    t.id, t.nombre
ORDER BY 
    total_ventas DESC
LIMIT 5;

CREATE VIEW tiendas_coca_mas_que_pepsi AS
SELECT 
    t.id AS tienda_id, 
    t.nombre AS tienda_nombre, 
    SUM(CASE WHEN p.nombre = 'Coca-Cola' THEN df.cantidad ELSE 0 END) AS coca_cantidad,
    SUM(CASE WHEN p.nombre = 'Pepsi' THEN df.cantidad ELSE 0 END) AS pepsi_cantidad
FROM 
    TIENDA t
JOIN 
    TIENDA_PRODUCTO tp ON t.id = tp.tienda_id
JOIN 
    PRODUCTO p ON tp.producto_UPC = p.UPC
JOIN 
    DETALLE_FACTURA df ON p.UPC = df.producto_UPC
GROUP BY 
    t.id, t.nombre
HAVING 
    coca_cantidad > pepsi_cantidad;
    
CREATE VIEW top_3_productos_con_leche AS
SELECT 
    df.producto_UPC, 
    p.nombre AS producto_nombre, 
    SUM(df.cantidad) AS total_vendido
FROM 
    DETALLE_FACTURA df
JOIN 
    PRODUCTO p ON df.producto_UPC = p.UPC
WHERE 
    df.factura_numero IN (
        SELECT df2.factura_numero
        FROM DETALLE_FACTURA df2
        JOIN PRODUCTO p2 ON df2.producto_UPC = p2.UPC
        WHERE p2.nombre = 'Leche'
    )
AND 
    p.nombre != 'Leche'
GROUP BY 
    df.producto_UPC, p.nombre
ORDER BY 
    total_vendido DESC
LIMIT 3;

INSERT INTO TIENDA (id, nombre, ubicaciones, horario) VALUES
(1, 'Tienda Central', 'Ciudad A', '08:00-20:00'),
(2, 'Supermercado Norte', 'Ciudad B', '09:00-21:00'),
(3, 'MiniMarket', 'Ciudad C', '07:00-23:00'),
(4, 'Mercado Sur', 'Ciudad D', '08:00-18:00'),
(5, 'Super Center', 'Ciudad E', '10:00-22:00'),
(6, 'Tienda Express', 'Ciudad F', '06:00-00:00'),
(7, 'Supertienda Este', 'Ciudad G', '08:00-20:00'),
(8, 'Mercado Oeste', 'Ciudad H', '09:00-19:00'),
(9, 'Centro Comercial', 'Ciudad I', '10:00-22:00'),
(10, 'Mercadito', 'Ciudad J', '06:00-22:00');

INSERT INTO PRODUCTO (UPC, nombre, tamaño, embalaje, marca, tipo, precio, cantidad, reorden) VALUES
('123456789012', 'Coca-Cola', '500ml', 'Botella', 'Coca-Cola', 'Bebida', 1.50, 200, 50),
('234567890123', 'Pepsi', '500ml', 'Botella', 'Pepsi', 'Bebida', 1.40, 150, 30),
('345678901234', 'Leche Entera', '1L', 'Cartón', 'Lala', 'Lácteos', 0.99, 100, 20),
('456789012345', 'Pan Integral', '500g', 'Bolsa', 'Bimbo', 'Panadería', 1.20, 80, 15),
('567890123456', 'Arroz', '1kg', 'Bolsa', 'SOS', 'Granos', 0.75, 300, 60),
('678901234567', 'Atún en Lata', '170g', 'Lata', 'Marinela', 'Enlatados', 1.10, 200, 40),
('789012345678', 'Pasta', '500g', 'Bolsa', 'Barilla', 'Granos', 1.30, 250, 50),
('890123456789', 'Cereal', '300g', 'Caja', 'Kellogg\'s', 'Cereales', 2.50, 150, 30),
('901234567890', 'Jugo de Naranja', '1L', 'Botella', 'Tropicana', 'Bebida', 1.75, 100, 20),
('012345678901', 'Aceite de Oliva', '500ml', 'Botella', 'Carbonell', 'Aceites', 3.50, 70, 15);

INSERT INTO VENDEDOR (id, nombre1, nombre2, apellido1, apellido2) VALUES
(1, 'Carlos', 'Eduardo', 'Pérez', 'López'),
(2, 'María', 'Josefa', 'Rodríguez', 'Gómez'),
(3, 'José', 'Antonio', 'Hernández', 'Martínez'),
(4, 'Laura', 'Isabel', 'Sánchez', 'Ramírez'),
(5, 'Juan', 'Manuel', 'Díaz', 'Fernández'),
(6, 'Ana', 'Luisa', 'García', 'González'),
(7, 'Luis', 'Miguel', 'Torres', 'Jiménez'),
(8, 'Elena', 'Patricia', 'Ruiz', 'Morales'),
(9, 'Fernando', 'Alberto', 'Vargas', 'Ortiz'),
(10, 'Sofía', 'Carolina', 'Castillo', 'Flores');

INSERT INTO CLIENTE (id, nombre1, nombre2, apellido1, apellido2, correoElectronico) VALUES
(1, 'Miguel', 'Ángel', 'Rivas', 'Paredes', 'miguel.rivas@ejemplo.com'),
(2, 'Valentina', 'Sofía', 'Lara', 'Álvarez', 'valentina.lara@ejemplo.com'),
(3, 'David', 'Enrique', 'Mendoza', 'Carrillo', 'david.mendoza@ejemplo.com'),
(4, 'Andrea', 'Paola', 'Vega', 'Cruz', 'andrea.vega@ejemplo.com'),
(5, 'Diego', 'Armando', 'Ramírez', 'Campos', 'diego.ramirez@ejemplo.com'),
(6, 'Camila', 'Isabel', 'Castro', 'López', 'camila.castro@ejemplo.com'),
(7, 'Daniel', 'Esteban', 'Salazar', 'Jiménez', 'daniel.salazar@ejemplo.com'),
(8, 'Isabella', 'Alejandra', 'Ortega', 'Duarte', 'isabella.ortega@ejemplo.com'),
(9, 'Emiliano', 'Gabriel', 'Hernández', 'Santos', 'emiliano.hernandez@ejemplo.com'),
(10, 'Lucía', 'Fernanda', 'Mejía', 'Ortiz', 'lucia.mejia@ejemplo.com');

INSERT INTO FACTURA (numero, fecha, subtotal, ISV, TOTAL, cliente_id) VALUES
(1, '2024-08-01', 100.00, 15.00, 115.00, 1),
(2, '2024-08-02', 200.00, 30.00, 230.00, 2),
(3, '2024-08-03', 150.00, 22.50, 172.50, 3),
(4, '2024-08-04', 300.00, 45.00, 345.00, 4),
(5, '2024-08-05', 250.00, 37.50, 287.50, 5),
(6, '2024-08-06', 180.00, 27.00, 207.00, 6),
(7, '2024-08-07', 220.00, 33.00, 253.00, 7),
(8, '2024-08-08', 190.00, 28.50, 218.50, 8),
(9, '2024-08-09', 140.00, 21.00, 161.00, 9),
(10, '2024-08-10', 170.00, 25.50, 195.50, 10);

INSERT INTO DETALLE_FACTURA (factura_numero, producto_UPC, cantidad) VALUES
(1, '123456789012', 5),
(1, '345678901234', 2),
(2, '234567890123', 3),
(2, '456789012345', 1),
(3, '567890123456', 4),
(3, '678901234567', 2),
(4, '789012345678', 6),
(4, '890123456789', 3),
(5, '901234567890', 2),
(5, '012345678901', 1),
(6, '123456789012', 8),
(7, '234567890123', 10),
(8, '345678901234', 7),
(9, '456789012345', 5),
(10, '567890123456', 3);

INSERT INTO TIENDA_PRODUCTO (tienda_id, producto_UPC) VALUES
(1, '123456789012'),
(1, '234567890123'),
(2, '345678901234'),
(2, '456789012345'),
(3, '567890123456'),
(3, '678901234567'),
(4, '789012345678'),
(4, '890123456789'),
(5, '901234567890'),
(5, '012345678901'),
(6, '123456789012'),
(6, '234567890123'),
(7, '345678901234'),
(7, '456789012345'),
(8, '567890123456'),
(8, '678901234567'),
(9, '789012345678'),
(9, '890123456789'),
(10, '901234567890'),
(10, '012345678901');



