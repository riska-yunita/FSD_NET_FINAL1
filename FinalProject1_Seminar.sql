CREATE DATABASE db_seminar;

USE db_seminar;
DROP DATABASE db_seminar;

CREATE TABLE tbl_seminar(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR (100) NOT NULL,
	benefit VARCHAR(100) NOT NULL,
	pembicara VARCHAR (25) NOT NULL,
	tgl_acara DATE NOT NULL,
	jam_mulai TIME(0) NOT NULL,
	jam_akhir TIME(0) NOT NULL,
	harga INT NOT NULL,
	ispromo BIT NOT NULL
);

CREATE TABLE tbl_peserta(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR (25) NOT NULL,
	email VARCHAR (50) NOT NULL,
	phone_number VARCHAR (20) NOT NULL,
	id_seminar INT,

	FOREIGN KEY (id_seminar) REFERENCES tbl_seminar
);

CREATE TABLE tbl_transaksi(
	id INT IDENTITY PRIMARY KEY,
	total_harga INT NOT NULL,
	tgl_transaksi date NOT NULL,
	id_peserta INT NOT NULL,
	id_seminar INT NOT NULL,

	FOREIGN KEY(id_peserta) REFERENCES tbl_peserta(id),
	FOREIGN KEY (id_seminar) REFERENCES tbl_seminar(id)
);



INSERT INTO tbl_seminar VALUES
('Build Greet Future With UI/UX','Knowledge, E-sertifikat, Relation', 'Devian Anggana Putra','2023-03-21', '16:00', '18:00', 25000, 1 );

INSERT INTO tbl_peserta VALUES 
('Riska Yunita', 'riskayunita@gmail.com', '08123456789', 1);

INSERT INTO tbl_transaksi VALUES
(25000, '2023-04-03', 1, 1);

Select * from tbl_peserta;
select * from tbl_seminar;
select * from tbl_transaksi;

