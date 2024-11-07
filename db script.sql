CREATE TABLE partner_type(
	id INT PRIMARY KEY AUTO_INCREMENT,
    name NVARCHAR(255)
);

CREATE TABLE partner(
	id INT PRIMARY KEY AUTO_INCREMENT,
    name NVARCHAR(255),
    partner_type_id INT,
    FOREIGN KEY (partner_type_id) REFERENCES partner_type(id),
    legal_address NVARCHAR(255),
    individual_taxpayer_number NVARCHAR(12),
    contact_number NVARCHAR(30),
    email NVARCHAR(30),
    logo_image_link NVARCHAR(255),
    rating INT
);

CREATE TABLE director(
	id INT PRIMARY KEY AUTO_INCREMENT,
	last_name NVARCHAR(255),
	first_name NVARCHAR(255),
	middle_name NVARCHAR(255)
);

CREATE TABLE supplier(
	id INT PRIMARY KEY AUTO_INCREMENT,
    name NVARCHAR(255),
    individual_taxpayer_number NVARCHAR(12)
);

CREATE TABLE material_type(
	id INT PRIMARY KEY AUTO_INCREMENT,
    name NVARCHAR(255),
    reject_rate DECIMAL(3, 2)
);

CREATE TABLE material(
	id INT PRIMARY KEY AUTO_INCREMENT,
	name NVARCHAR(255),
    supplier_id INT,
	FOREIGN KEY (supplier_id) REFERENCES supplier(id),
	material_type_id INT,
	FOREIGN KEY (material_type_id) REFERENCES material_type(id),
    package_quantity INT,
	unit_name VARCHAR(20),
    description TEXT,
    image_link NVARCHAR(255),
    cost DECIMAL(20, 2),
    quantity_in_stock INT,
    min_required_quantity INT
);

CREATE TABLE product_type(
	id INT PRIMARY KEY AUTO_INCREMENT,
    name NVARCHAR(255),
    product_type_ratio DECIMAL(3, 2)
);

CREATE TABLE product(
	article INT PRIMARY KEY,
	name NVARCHAR(255),
    product_type_id INT,
	FOREIGN KEY (product_type_id) REFERENCES product_type(id),
	description TEXT,
	image_link NVARCHAR(255),
    min_cost DECIMAL(10, 2),
    width DECIMAL(10, 2),
    height DECIMAL(10, 2),
    length DECIMAL(10, 2),
    netto DECIMAL(10, 2),
    brutto DECIMAL(10, 2),
    certificate_image_link NVARCHAR(255),
    standart_number NVARCHAR(255),
    production_time NVARCHAR(255),
    cost_price DECIMAL(10, 2)
);

CREATE TABLE partner_products(
	id INT PRIMARY KEY AUTO_INCREMENT,
    product_article INT,
	FOREIGN KEY (product_article) REFERENCES product(article),
    partner_id INT,
	FOREIGN KEY (partner_id) REFERENCES partner(id),
    quantity INT,
    sale_date DATE
)