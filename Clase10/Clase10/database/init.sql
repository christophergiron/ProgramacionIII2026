CREATE TABLE IF NOT EXISTS products
(
    id VARCHAR(50) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price NUMERIC(10,2) NOT NULL,
    stock INTEGER NOT NULL DEFAULT 0
);

INSERT INTO products (id, name, description, price, stock)
VALUES
('1', 'Laptop', 'Computadora portátil', 5000, 10),
('2', 'Mouse', 'Mouse inalámbrico', 200, 30)
ON CONFLICT (id) DO NOTHING;
