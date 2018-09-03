Create Database BookStore_QueenMin
Go

Use BookStore_QueenMin
go

CREATE TABLE TKNhanVien
(
	MaNV int Primary key identity,
	TenTK varchar(30) NOT NULL UNIQUE,
	MatKhau nvarchar(100) NOT NULL,
	ChucVu nvarchar(50) NOT NULL
)

INSERT INTO TKNhanVien(TenTK, MatKhau, ChucVu) 
	VALUES('TuanNV37', 'e10adc3949ba59abbe56e057f20f883e', 'Admin'), ('Quynh', 'e10adc3949ba59abbe56e057f20f883e', 'Admin')

Create table NhanVien
(
	MaNV int Primary key,
	TenNV nvarchar(100) NOT NULL,
	GioiTinh nvarchar(5),
	DiaChi nvarchar(100) NOT NULL,
	Sdt varchar(11),
	NgaySinh date NOT NULL,
	NgayDen date NOT NULL,
	TinhTrang nvarchar(20)NOT NULL
)
ALTER TABLE NhanVien ADD CONSTRAINT pk_nv_tk FOREIGN KEY (MaNV) REFERENCES TKNhanVien(MaNV)
INSERT INTO NhanVien(MaNV, TenNV, GioiTinh, DiaChi, Sdt, NgaySinh, NgayDen, TinhTrang)
			VALUES(1, N'Nguyễn Văn Tuấn', N'Nam', N'Thanh Hóa', '01635363536', '1995-1-1', '2018-9-2', N'Đang làm'),
				  (2, N'Quỳnh', N'Nữ', N'Thái Bình', '01635363344', '1996-1-1', '2018-9-2', N'Đang làm')

CREATE TABLE Vip
(
	MaVip int Primary key identity,
	TenVip varchar(10) NOT NULL UNIQUE,
	Moc money NOT NULL,
	UuDai int NOT NULL --giam hoa don
)

Create table TKKhachHang
(
	MaKH int Primary key Identity,
	TenTK varchar(30) Not Null Unique,
	MatKhau nvarchar(100) Not null
)

INSERT INTO TKKhachHang(TenTK, MatKhau) 
	VALUES('TuanNV37', 'e10adc3949ba59abbe56e057f20f883e'), ('Quynh', 'e10adc3949ba59abbe56e057f20f883e')

Create table KhachHang
(
	MaKH int Primary key,
	TenKh nvarchar(50) NOT NULL,
	GioiTinh nvarchar(5),
	NgaySinh date,
	Sdt varchar(11) NOT NULL Unique,
	Email varchar(100) NOT NULL Unique,
	DiaChi nvarchar(300) NOT Null,
	MaVip int Not null,
	TinhTrang nvarchar(20)  NOT NULL
)
ALTER TABLE KhachHang ADD CONSTRAINT pk_kh_tk FOREIGN KEY (MaKH) REFERENCES TKKhachHang(MaKH)
ALTER TABLE KhachHang ADD CONSTRAINT pk_kh_vip FOREIGN KEY (MaVip) REFERENCES Vip(MaVip)

Create table DanhMuc
(
	MaDM int primary key identity,
	TenDM nvarchar(100) NOT NULL Unique,
	NgayTao date NOT NULL,
	TinhTrang nvarchar(20) NOT NULL
)

Create Table DoTuoi
(
	MaDT int primary key Identity,
	BatDau int NOT NULL Unique,
	KetThuc int NOT NULL unique
)

Create table TacGia
(
	MaTG int Primary key Identity,
	TenTG nvarchar(50) NOT NULL,
	GioiTinh nvarchar(5),
	NgaySinh date,
	DiaChi nvarchar(100)
)

Create table NhaXuatBan
(
	MaNXB int Primary key identity,
	TenNXB nvarchar(100) NOT NULL Unique,
	DiaChi nvarchar(300),
	Sdt varchar(11)
)
CREATE Table Sach
(
	MaS int Primary key identity,
	MaTG int NOT NULL,
	MaDM int NOT NULL,
	MaDT int NOT NULL,
	MaNXB int NOT NULL
)
ALTER TABLE Sach ADD CONSTRAINT pk_s_tg FOREIGN KEY (MaTG) REFERENCES TacGia(MaTG)
ALTER TABLE Sach ADD CONSTRAINT pk_s_dm FOREIGN KEY (MaDM) REFERENCES DanhMuc(MaDM)
ALTER TABLE Sach ADD CONSTRAINT pk_s_dt FOREIGN KEY (MaDT) REFERENCES DoTuoi(MaDT)
ALTER TABLE Sach ADD CONSTRAINT pk_s_nxb FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB)


Create table CTSach
(
	MaS int Primary key,
	TenS nvarchar(100) Not null,
	LoaiBia nvarchar(10) not null,
	NgayXuatBan date not null,
	Kho varchar(10) not null,
	SoTrang int Not null,
	LoaiGiay nvarchar(30) not null,
	Gia money Not null
)
ALTER TABLE CTSach ADD CONSTRAINT pk_cts_s FOREIGN KEY (MaS) REFERENCES Sach(MaS)

create table AnhSach
(
	MaS int Primary key,
	Anh1 varchar(300),
	Anh2 varchar(300),
	Anh3 varchar(300),
	Anh4 varchar(300),
	Anh5 varchar(300)
)
ALTER TABLE AnhSach ADD CONSTRAINT pk_as_s FOREIGN KEY (MaS) REFERENCES Sach(MaS)

create table DanhGiaSach
(
	MaS int Primary key,
	Sao float not null
)
ALTER TABLE DanhGiaSach ADD CONSTRAINT pk_dgs_s FOREIGN KEY (MaS) REFERENCES Sach(MaS)


Create table Kho
(
	MaS int Not null,
	SoLuong int Not null,
	NgayNhap date Not null
)
ALTER TABLE Kho ADD CONSTRAINT pk_k_s FOREIGN KEY (MaS) REFERENCES Sach(MaS)

Create table NhaCungCap
(
	MaNCC int Primary key Identity,
	TenNCC nvarchar(100) NOT NULL UniQue,
	Sdt varchar(11) NOT NULL Unique,
	DiaChi nvarchar(300) NOT NULL Unique
)

Create table HoaDonNhap
(
	MaHDN int primary key Identity,
	MaNCC int NOT NULL,
	MaNV int NOT NULL,
	NgayLap date not null,
	NgayGiaoHang date not null,
	TinhTrang nvarchar(20)not null
)
ALTER TABLE HoaDonNhap ADD CONSTRAINT pk_hdn_ncc FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
ALTER TABLE HoaDonNhap ADD CONSTRAINT pk_hdn_nv FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)

Create table  CTHoaDonNhap
(
	MaHDN int NOT NULL,
	MaS int NOT NULL,
	SoLuong int Not Null,
	GiamGia int not null default 0
)
ALTER TABLE CTHoaDonNhap ADD CONSTRAINT fk_cthdn PRIMARY KEY(MaHDN, MaS)
ALTER TABLE CTHoaDonNhap ADD CONSTRAINT pk_cthdn_s FOREIGN KEY (MaS) REFERENCES Sach(MaS)
ALTER TABLE CTHoaDonNhap ADD CONSTRAINT pk_cthdn_hdn FOREIGN KEY (MaHDN) REFERENCES HoaDonNhap(MaHDN)


Create table KhuVuc
(
	MaKV int Primary key Identity,
	TenKV nvarchar(100) NOT NULL UNIQUE,
	PhiShip money NOT NULL
)
Create table HoaDonXuat
(
	MaHDX int Primary key Identity,
	MaKH int,
	MaNV int NOT NULL,
	MaKV int Not null,
	NgayLap date not null,
	NgayGiaoHang date not null,
	TinhTrang nvarchar(20)not null
)
ALTER TABLE HoaDonXuat ADD CONSTRAINT pk_hdx_kh FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
ALTER TABLE HoaDonXuat ADD CONSTRAINT pk_hdx_nv FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
ALTER TABLE HoaDonXuat ADD CONSTRAINT pk_hdx_kv FOREIGN KEY (MaKV) REFERENCES KhuVuc(MaKV)


Create table  CTHoaDonXuat
(
	MaHDX int NOT NULL,
	MaS int NOT NULL,
	SoLuong int Not Null,
	GiamGia int not null default 0
)
ALTER TABLE CTHoaDonXuat ADD CONSTRAINT fk_cthdx PRIMARY KEY(MaHDX, MaS)
ALTER TABLE CTHoaDonXuat ADD CONSTRAINT pk_cthdx_s FOREIGN KEY (MaS) REFERENCES Sach(MaS)
ALTER TABLE CTHoaDonXuat ADD CONSTRAINT pk_cthdx_hdx FOREIGN KEY (MaHDX) REFERENCES HoaDonXuat(MaHDX)


