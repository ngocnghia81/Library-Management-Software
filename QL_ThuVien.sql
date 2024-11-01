-- Tạo cơ sở dữ liệu
CREATE DATABASE QL_ThuVien;
GO

USE QL_ThuVien;
GO

-- TẠO BẢNG KESACH
CREATE TABLE KESACH
(
    MaKe VARCHAR(10) PRIMARY KEY, 
    TenKe VARCHAR(50) NOT NULL
);

-- TẠO BẢNG DOCGIA
CREATE TABLE DOCGIA
(
    MaDocGia VARCHAR(10) PRIMARY KEY, 
    TenDocGia NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    SDT VARCHAR(11) NOT NULL,         
    DiaChi NVARCHAR(255) NOT NULL,
    NgayDangKy DATE NOT NULL,
    CapThanhVien NVARCHAR(50)
        DEFAULT 'Bạc'
);
GO

-- TẠO BẢNG NXB (Nhà Xuất Bản)
CREATE TABLE NXB
(
    MaNXB VARCHAR(10) PRIMARY KEY, 
    TenNXB NVARCHAR(100) NOT NULL
);

-- TẠO BẢNG TACGIA
CREATE TABLE TACGIA
(
    MaTacGia VARCHAR(10) PRIMARY KEY, 
    TenTacGia NVARCHAR(100) NOT NULL,

);
GO

-- TẠO BẢNG THELOAISACH
CREATE TABLE THELOAISACH
(
    MaLoai VARCHAR(10) PRIMARY KEY, 
    TenLoai NVARCHAR(50) NOT NULL
);

-- TẠO BẢNG SACH
CREATE TABLE SACH
(
    MaSach VARCHAR(10) PRIMARY KEY, 
    TenSach NVARCHAR(100) NOT NULL,
	HinhAnh varchar(100),
    MaNXB VARCHAR(10)
        FOREIGN KEY REFERENCES NXB (MaNXB),
    MaLoai VARCHAR(10)
        FOREIGN KEY REFERENCES THELOAISACH (MaLoai),
    MoTa NVARCHAR(Max) NOT NULL,
    SoLuongKho int,
	TongSoLuong int,
    MaKe VARCHAR(10)
        FOREIGN KEY REFERENCES KESACH (MaKe)
);
GO

-- TẠO BẢNG THAMGIA (Tác giả tham gia viết sách)
CREATE TABLE THAMGIA
(

    MaTacGia VARCHAR(10)
        FOREIGN KEY REFERENCES TACGIA (MaTacGia),
    MaSach VARCHAR(10)
        FOREIGN KEY REFERENCES SACH (MaSach),
    PRIMARY KEY (
                    MaTacGia,
                    MaSach
                )
);

-- TẠO BẢNG PHIEUMUON
CREATE TABLE PHIEUMUON
(
    MaPhieuMuon VARCHAR(10) PRIMARY KEY, 
    MaDocGia VARCHAR(10)
        FOREIGN KEY REFERENCES DOCGIA (MaDocGia),
    NgayMuon DATE NOT NULL
);
GO

-- TẠO BẢNG CHITIETPHIEUMUON
CREATE TABLE CHITIETPHIEUMUON
(
    MaCTPM VARCHAR(10) PRIMARY KEY, 
    MaPhieuMuon VARCHAR(10) NOT NULL
        FOREIGN KEY REFERENCES PHIEUMUON (MaPhieuMuon),
    MaSach VARCHAR(10) NOT NULL
        FOREIGN KEY REFERENCES SACH (MaSach)
);
GO

-- TẠO BẢNG PHIEUTRA
CREATE TABLE PHIEUTRA
(
    MaPhieuTra VARCHAR(10) PRIMARY KEY, 
    MaDocGia VARCHAR(10)
        FOREIGN KEY REFERENCES DOCGIA (MaDocGia),
    MaSach VARCHAR(10)
        FOREIGN KEY REFERENCES SACH (MaSach),
    NgayMuon DATE NOT NULL
);
GO

-- TẠO BẢNG NCC (Nhà Cung Cấp)
CREATE TABLE NCC
(
    MaNCC VARCHAR(10) PRIMARY KEY, 
    TenNCC NVARCHAR(100) NOT NULL
);

-- TẠO BẢNG NHAPSACH (Nhập sách từ NCC)
CREATE TABLE NHAPSACH
(
    MaNhap VARCHAR(10) PRIMARY KEY, 
    MaNCC VARCHAR(10)
        FOREIGN KEY REFERENCES NCC (MaNCC),
    NgayNhap DATE NOT NULL
);
GO

-- TẠO BẢNG CHITIETNHAPSACH
CREATE TABLE CHITIETNHAPSACH
(
    MaCTNS VARCHAR(10) PRIMARY KEY, 
    MaNhap VARCHAR(10)
        FOREIGN KEY REFERENCES NHAPSACH (MaNhap),
    MaSach VARCHAR(10)
        FOREIGN KEY REFERENCES SACH (MaSach),
    DonGia INT CHECK (DonGia > 0),
    SoLuong INT CHECK (SoLuong > 0)
);
GO

-- TẠO BẢNG USERS (Người dùng)
CREATE TABLE TAIKHOAN
(
    Email VARCHAR(100) PRIMARY KEY,
    HashedPassword VARCHAR(255) NOT NULL,
    MaDocGia VARCHAR(10) UNIQUE NULL 
        FOREIGN KEY REFERENCES DOCGIA (MaDocGia) ON DELETE CASCADE,
    VaiTro VARCHAR(50) DEFAULT 'user'
);
GO

CREATE FUNCTION dbo.func_LayMaDocGiaLonNhat()
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @MaxMaDocGia VARCHAR(10);

    SELECT @MaxMaDocGia = MAX(MaDocGia)
    FROM DOCGIA;

    -- Kiểm tra nếu không có độc giả nào, trả về '0'
    IF @MaxMaDocGia IS NULL
    BEGIN
        RETURN 'DG000';
    END

    RETURN @MaxMaDocGia;
END;
GO

create function dbo.func_GetTenTacGia (@MaSach nvarchar(10))
returns nvarchar(100)
as
begin

    DECLARE @TENTACGIA NVARCHAR(MAX);

    SELECT @TENTACGIA = STRING_AGG(TACGIA.TenTacGia, ', ')
    FROM THAMGIA TG join TACGIA on tg.MaTacGia = TACGIA.MaTacGia
    WHERE TG.MaSach = @MaSach;
	return @TENTACGIA;

end
go
SELECT dbo.func_GetTenTacGia('S001') AS TenTacGia;


CREATE FUNCTION dbo.func_GetChiTietSach (@MaSach NVARCHAR(50))
RETURNS @ResultTable  TABLE
(
	TenSach NVARCHAR(100),
    TenNXB NVARCHAR(100),
    TenLoai NVARCHAR(100),
    MoTa NVARCHAR(MAX),
    HinhAnh varchar(mAX), 
	SoLuongKho int,	
    TenTacGia NVARCHAR(MAX)

)
AS
Begin
	Declare @TenTacGia nvarchar(max);
	set @TenTacGia = dbo.func_GetTenTacGia(@MaSach)
	INSERT INTO @ResultTable
    SELECT 
        S.TenSach,
        NXB.TenNXB,
		L.TenLoai,
        s.MoTa,
        s.HinhAnh,
		s.SoLuongKho,
		@TenTacGia as TenTacGia
    FROM 
        Sach S join NXB on NXB.MaNXB = S.MaNXB join TheLoaiSach L on L.MaLoai = S.MaLoai
    WHERE 
        MaSach = @MaSach
	RETURN;
End
go
SELECT * FROM dbo.func_GetChiTietSach('S001');

Insert into TheLoaiSach
values
('L001',N'Thơ')
Insert into NXB
values
('NXB001',N'NXB Kim Đồng')
Insert into KeSach
values
('K001',N'Kệ thơ')
Insert into SACH
values
('S001',N'Truyện Kiều','1.jpg','NXB001','L001',N'Thơ của Nguyễn Du',2,2,'K001')
Insert into TACGIA
values
('TG001',N'Nguyễn Du'),
('TG002',N'Test tên')
go
Insert into THAMGIA
values
('TG001','S001'),
<<<<<<< HEAD
('TG002','S001');
=======
('TG002','S001');
>>>>>>> 4edf1b788a1d6a92a5ebf0181795b30619258416
