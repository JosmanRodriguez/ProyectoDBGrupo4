DELIMITER $$

-- Trigger para registrar la creación de una tienda
CREATE TRIGGER after_tienda_insert
AFTER INSERT ON TIENDA
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('CREAR', 'TIENDA', NOW());
END$$

-- Trigger para registrar la creación de un producto
CREATE TRIGGER after_producto_insert
AFTER INSERT ON PRODUCTO
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('CREAR', 'PRODUCTO', NOW());
END$$

-- Trigger para registrar la creación de un vendedor
CREATE TRIGGER after_vendedor_insert
AFTER INSERT ON VENDEDOR
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('CREAR', 'VENDEDOR', NOW());
END$$

DELIMITER ;

3.2 Modificar
DELIMITER $$

-- Trigger para registrar la modificación de una tienda
CREATE TRIGGER after_tienda_update
AFTER UPDATE ON TIENDA
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('MODIFICAR', 'TIENDA', NOW());
END$$

-- Trigger para registrar la modificación de un producto
CREATE TRIGGER after_producto_update
AFTER UPDATE ON PRODUCTO
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('MODIFICAR', 'PRODUCTO', NOW());
END$$

-- Trigger para registrar la modificación de un vendedor
CREATE TRIGGER after_vendedor_update
AFTER UPDATE ON VENDEDOR
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('MODIFICAR', 'VENDEDOR', NOW());
END$$

DELIMITER ;

3.3 Eliminar
DELIMITER $$

-- Trigger para registrar la eliminación de una tienda
CREATE TRIGGER after_tienda_delete
AFTER DELETE ON TIENDA
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('ELIMINAR', 'TIENDA', NOW());
END$$

-- Trigger para registrar la eliminación de un producto
CREATE TRIGGER after_producto_delete
AFTER DELETE ON PRODUCTO
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('ELIMINAR', 'PRODUCTO', NOW());
END$$

-- Trigger para registrar la eliminación de un vendedor
CREATE TRIGGER after_vendedor_delete
AFTER DELETE ON VENDEDOR
FOR EACH ROW
BEGIN
    INSERT INTO bitacora (accion, tabla, fecha) VALUES ('ELIMINAR', 'VENDEDOR', NOW());
END$$

DELIMITER ;