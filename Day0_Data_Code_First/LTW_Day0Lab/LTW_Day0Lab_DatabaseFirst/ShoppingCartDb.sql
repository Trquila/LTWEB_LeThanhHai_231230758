-- Create database
CREATE DATABASE ShoppingCartDb;
GO
USE ShoppingCartDb;
GO

-- ================================
-- Table: QUAN_TRI
-- ================================
CREATE TABLE QUAN_TRI (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    TrangThai INT
);
GO

-- ================================
-- Table: KHACH_HANG
-- ================================
CREATE TABLE KHACH_HANG (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang NVARCHAR(20) NOT NULL,
    HoTenKhachHang NVARCHAR(100),
    Email NVARCHAR(100),
    MatKhau NVARCHAR(100),
    DienThoai NVARCHAR(20),
    DiaChi NVARCHAR(200),
    NgayDangKy DATE,
    TrangThai INT
);
GO

-- ================================
-- Table: LOAI_SAN_PHAM
-- ================================
CREATE TABLE LOAI_SAN_PHAM (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaLoai NVARCHAR(20) NOT NULL,
    TenLoai NVARCHAR(100),
    TrangThai INT
);
GO

-- ================================
-- Table: SAN_PHAM
-- ================================
CREATE TABLE SAN_PHAM (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSanPham NVARCHAR(20) NOT NULL,
    TenSanPham NVARCHAR(100),
    HinhAnh NVARCHAR(255),
    SoLuong INT DEFAULT 0,
    DonGia DECIMAL(18,2),
    MaLoai INT NOT NULL,
    TrangThai INT,
    FOREIGN KEY (MaLoai) REFERENCES LOAI_SAN_PHAM(ID)
);
GO

-- ================================
-- Table: HOA_DON
-- ================================
CREATE TABLE HOA_DON (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon NVARCHAR(20) NOT NULL,
    MaKhachHang INT NOT NULL,
    NgayHoaDon DATE,
    NgayNhan DATE,
    HoTenKhachHang NVARCHAR(100),
    Email NVARCHAR(100),
    DienThoai NVARCHAR(20),
    DiaChi NVARCHAR(200),
    TongTriGia DECIMAL(18,2),
    TrangThai INT,
    FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG(ID)
);
GO

-- ================================
-- Table: CT_HOA_DON
-- ================================
CREATE TABLE CT_HOA_DON (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    HoaDonID INT NOT NULL,
    SanPhamID INT NOT NULL,
    SoLuongMua INT,
    DonGiaMua DECIMAL(18,2),
    ThanhTien AS (SoLuongMua * DonGiaMua) PERSISTED,
    TrangThai INT,
    FOREIGN KEY (HoaDonID) REFERENCES HOA_DON(ID),
    FOREIGN KEY (SanPhamID) REFERENCES SAN_PHAM(ID)
);
GO