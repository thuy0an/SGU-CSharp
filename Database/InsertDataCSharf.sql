-- Thêm dữ liệu vào bảng ThanhVien
INSERT INTO ThanhVien (HoTen, NgaySinh, Email, SoDienThoai, TrangThai, MatKhau, ThoiGianDangKy) VALUES
('Ngô Tuấn Hưng', '2004-11-11', 'hung@gmail.com', '0987654321', 'HOATDONG', '123456', NOW()),
('Nguyễn Minh Phúc', '2004-11-01', 'phuc@gmail.com', '0978123456', 'HOATDONG', '123456', NOW()),
('Trần Văn Khánh', '2004-12-05', 'khanh@gmail.com', '0978567890', 'HOATDONG', '123456', NOW()),
('Đỗ Anh Đài', '2004-10-21', 'dai@gmail.com', '0978124444', 'HOATDONG', '123456', NOW()),
('Diệp Thụy An', '2004-08-18', 'an@gmail.com', '0967987654', 'HOATDONG', '123456', NOW());

-- Thêm dữ liệu vào bảng CheckIn
INSERT INTO CheckIn (ThoiGianCheckIn) VALUES
('2025-03-19 08:00:00'),
('2025-03-19 09:15:00'),
('2025-03-19 10:30:00'),
('2025-03-19 13:45:00'),
('2025-03-19 15:00:00');

-- Thêm dữ liệu vào bảng PhieuXuPhat
INSERT INTO PhieuXuPhat (TrangThai, NgayViPham, MoTa, ThoiHanXuPhat, MucPhat) VALUES
('CHUA_XU_LY', '2025-03-18 14:00:00', 'Làm hỏng thiết bị', 7, 500000),
('DA_XU_LY', '2025-03-15 09:30:00', 'Trả thiết bị trễ hạn', 3, 200000),
('CHUA_XU_LY', '2025-03-17 16:00:00', 'Mất thiết bị', 10, 1000000),
('DA_XU_LY', '2025-03-10 11:00:00', 'Vi phạm nội quy', 5, 300000),
('CHUA_XU_LY', '2025-03-19 08:30:00', 'Không check-in đúng giờ', 2, 100000);

-- Thêm dữ liệu vào bảng LoaiThietBi
INSERT INTO LoaiThietBi (TenLoaiThietBi) VALUES
('Máy tính'),
('Máy chiếu'),
('Loa'),
('Máy in'),
('Cáp kết nối');

-- Thêm dữ liệu vào bảng ThietBi
INSERT INTO ThietBi (TenThietBi, IdLoaiThietBi) VALUES
('Laptop Dell XPS', 1),
('Laptop HP EliteBook', 1),
('Máy chiếu Sony', 2),
('Máy chiếu Epson', 2),
('Loa Bluetooth JBL', 3),
('Loa Sony SRS', 3),
('Máy in HP LaserJet', 4),
('Máy in Canon Pixma', 4),
('Cáp HDMI 2m', 5),
('Cáp USB-C 1m', 5);

-- Thêm dữ liệu vào bảng DauThietBi
INSERT INTO DauThietBi (TrangThai, ThoiGianMua, IdThietBi) VALUES
('KHADUNG', '2024-01-15 00:00:00', 1),
('DANGMUON', '2024-02-20 00:00:00', 2),
('DATTRUOC', '2024-03-10 00:00:00', 3),
('BAOTRI', '2024-04-05 00:00:00', 4),
('KHADUNG', '2024-05-01 00:00:00', 5),
('DANGMUON', '2024-06-15 00:00:00', 6),
('THATLAC', '2024-07-20 00:00:00', 7),
('KHADUNG', '2024-08-10 00:00:00', 8),
('DATTRUOC', '2024-09-05 00:00:00', 9),
('BAOTRI', '2024-10-01 00:00:00', 10);

-- Thêm dữ liệu vào bảng PhieuDatCho
INSERT INTO PhieuDatCho (IdThanhVien, TrangThai, ThoiGianDat, ThoiGianLapPhieu) VALUES
(1, 'DANGCHO', '2025-03-20 09:00:00', '2025-03-19 10:00:00'),
(2, 'DANGSUDUNG', '2025-03-19 14:00:00', '2025-03-19 08:00:00'),
(3, 'DATRACHO', '2025-03-18 13:00:00', '2025-03-17 15:00:00'),
(4, 'HUY', '2025-03-19 16:00:00', '2025-03-18 09:00:00'),
(5, 'DANGCHO', '2025-03-21 10:00:00', '2025-03-19 12:00:00');

-- Thêm dữ liệu vào bảng ChiTietPhieuDatCho
INSERT INTO ChiTietPhieuDatCho (IdPhieuDat, IdDauThietBi) VALUES
(1, 3),
(2, 2),
(3, 1),
(4, 5),
(5, 3);

-- Thêm dữ liệu vào bảng PhieuMuon
INSERT INTO PhieuMuon (TrangThai, NgayTao) VALUES
('DANGSUDUNG', '2025-03-19 09:00:00'),
('DATRATHIETBI', '2025-03-18 10:00:00'),
('HUY', '2025-03-17 14:00:00'),
('DANGSUDUNG', '2025-03-19 11:00:00'),
('DATRATHIETBI', '2025-03-16 08:00:00');

-- Thêm dữ liệu vào bảng ChiTietPhieuMuon
INSERT INTO ChiTietPhieuMuon (IdPhieuMuon, IdDauThietBi, ThoiGianMuon, ThoiGianTra, TrangThai) VALUES
(1, 2, '2025-03-19 09:00:00', '2025-03-20 09:00:00', 'DANGMUON'),
(2, 1, '2025-03-18 10:00:00', '2025-03-19 10:00:00', 'DATRATHIETBI'),
(3, 5, '2025-03-17 14:00:00', '2025-03-18 14:00:00', 'DATRATHIETBI'),
(4, 2, '2025-03-19 11:00:00', '2025-03-20 11:00:00', 'DANGMUON'),
(5, 1, '2025-03-16 08:00:00', '2025-03-17 08:00:00', 'DATRATHIETBI');
