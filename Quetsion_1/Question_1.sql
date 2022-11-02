CREATE DATABASE carter;

USE carter;



CREATE TABLE tbl_customer_info(
	cust_id int not null primary key IDENTITY(1,1),
	first_name varchar(50) not null,
	last_name varchar(50) not null,
	email text not null,
	phone_number char(15) not null
);


CREATE TABLE tbl_car_info(
	car_id int not null primary key identity(1,1),
	car_name varchar(50) not null,
	car_model varchar(50) not null,
	car_image image null,
	year_released int not null,
	no_of_liters decimal(3,2) not null,
	transmission varchar(20) not null,
	price decimal(10,2) not null,
	monthly_installment decimal(10,2) not null,
	insurance int null,
	warrenty int not null,
	good_features text not null,
	bad_features text not null
);

CREATE TABLE tbl_purchases(
	purchase_id int not null primary key identity(1,1),
	cust_id int not null,
	car_id int not null
);





INSERT INTO tbl_customer_info
VALUES ('Allison', 'Masemola', 'allison.masemola@gmail.com', '012 123 1234'),
		('John', 'Doe', 'john@gmail.com', '021 123 1234');




INSERT INTO tbl_car_info
VALUES ('Cadillac', 'Corvette', '', 1995, 0.9, 'Manual', 356895.00, 2250.00, 1, 2, 'Automatic emergency braking', 'Forward collision warning'),
		('Ford', 'Focus', '', 2002, 2.9, 'Auto', 12351.00, 1500.00, 1, 3, 'Automatic emergency braking', 'Forward collision warning'),
		('Renault', 'Kwid', '', 2015, 0.9, 'Manual', 177999.00, 2799.00, 1, 5, 'AUX/USB/Bluetooth', 'Drive Smooth'),
		('Galf', 'GTI-5', '', 2005, 2.9, 'Manual', 524658.00, 5500.00, 2, 4, 'Automatic emergency braking', 'Forward collision warning'),
		('4Runner', 'Acadia', '', 2012, 2.0, 'Manual', 123545.00, 2500.00, 2, 4, 'Blind-spot monitoring', 'Apple CarPlay / Android Auto'),
		('Cordoba', 'Laser', '', 1999, 2.6, 'Auto', 252454.00, 5500.00, 2, 4, 'Evasive steering', 'Forward collision warning'),
		('Grand ', 'Aztek', '', 1978, 2.4, 'Manual', 225232.00, 1120.00, 2, 4, 'Automatic emergency braking', 'Head-up display'),
		('Voyager', 'Berlinetta', '', 2001, 2.1, 'Manual', 100525.00, 3500.00, 2, 4, 'Pre-safe nudging', 'Keyless entry'),
		('Airstream', 'Bronco', '', 2001, 2.0, 'Auto', 200525.00, 6000.00, 2, 4, 'Lane-keeping assist', 'Fast USB charging outlets'),
		('Countach', 'Escort', '', 1995, 2.5, 'Auto', 300545.00, 956.00, 2, 4, 'Automatic high beams', 'WiFi Hotspot'),
		('Spark', 'Midget', '', 1996, 2.1, 'Manual', 123020.00, 2399.00, 2, 4, 'Rear cross-traffic warning', 'Rear entertainment systems'),
		('Spirit', 'Mirai', '', 2003, 0.9, 'Auto', 111252.00, 1299.00, 2, 4, '360-degree camera system', 'Auto-dimming mirrors'),
		('Paceman', 'Caravan', '', 2005, 1.9, 'Manual', 524658.00, 4599.00, 2, 4, 'Sunroof', 'Multizone climate system'),
		('Hobio', 'Fuego', '', 2005, 2.9, 'Manual', 758545.00, 2000.00, 2, 4, 'Leather Seats', 'Bluetooth'),
		('Corsica', 'Sigma', '', 2008, 5.9, 'Auto', 656021.00, 2999.00, 2, 4, 'Heated Seats', 'Pre-safe nudging'),
		('Horizon', 'Murano', '', 2065, 2.9, 'Auto', 201999.00, 1999.00, 2, 4, 'Lumbar support', 'Remote Start'),
		('Odyssey', 'Galaxy', '', 2005, 2.9, 'Auto', 524658.00, 3999.00, 2, 4, 'Heated steering wheel', 'Forward collision warning'),
		('Sonic', 'Scorpio', '', 2002, 3.9, 'Manual', 333999.00, 2999.00, 2, 4, 'Parking Cameras', 'Sunroof'),
		('Panamera', 'Meadowbrook', '', 2010,1.9, 'Auto', 787546.00, 1999.00, 2, 4, 'Remote Start', 'Leather Seats'),
		('Laviolette', 'Metro', '', 2003, 3.9, 'Manual', 125232.00, 1999.00, 2, 4, 'Navigation systems', 'Parking Cameras');


