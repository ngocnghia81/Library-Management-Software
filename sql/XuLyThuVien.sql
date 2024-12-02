CREATE FUNCTION DANHSACHMUONTRA
(
	@MaDG varchar(10)
)
returns @Result Table
(
	MaDG varchar(10),
	TenDG nvarchar(max),
	TenSach nvarchar(max),
	MaPhieuMuon varchar(10),
	NgayMuon varchar(10),
	TinhTrang bit
)
as
begin
	Insert into @Result
	Select dg.MaDocGia as N'Mã độc giả', dg.TenDocGia as N'Tên độc giả', s.TenSach AS N'Sách', PM.MaPhieuMuon as N'Mã phiếu mượn', pm.NgayMuon as N'Ngày mượn', CASE 
        WHEN PT.MaPhieuTra IS NULL THEN 0 
        ELSE 1
    END AS N'Tình trạng' 
	from CHITIETPHIEUMUON CTPM
		join PHIEUMUON  PM on CTPM.MaPhieuMuon = PM.MaPhieuMuon
		join Sach S on S.MaSach = CTPM.MaSach
		join DOCGIA DG on DG.MaDocGia = pm.MaDocGia
		left join PhieuTra PT on pt.MaCTPM = CTPM.MaCTPM
	where dg.MaDocGia = @MaDG
	Return
end
go
select * from dbo.DANHSACHMUONTRA('dg001');