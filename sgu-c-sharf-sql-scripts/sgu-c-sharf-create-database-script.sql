DROP DATABASE IF EXISTS `SGU_C_Sharf`;
CREATE DATABASE IF NOT EXISTS `SGU_C_Sharf`;
USE `SGU_C_Sharf`;
DROP TABLE IF EXISTS `ThanhVien`;
CREATE TABLE IF NOT EXISTS `ThanhVien` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `HoTen` NVARCHAR(255) NOT NULL,
    `NgaySinh` DATE NOT NULL,
    `Email` NVARCHAR(255) NOT NULL UNIQUE,
    `SoDienThoai` NVARCHAR(10) NOT NULL,
    `TrangThai` ENUM('HOATDONG', 'DINHCHI', 'CAM') NOT NULL,
    `Quyen` ENUM ('USER', 'ADMIN') NOT NULL,
    `MatKhau` NVARCHAR(255) NOT NULL,
    `ThoiGianDangKy` DATETIME NOT NULL DEFAULT NOW()
);
DROP TABLE IF EXISTS `CheckIn`;
CREATE TABLE IF NOT EXISTS `CheckIn` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `ThoiGianCheckIn` DATETIME NOT NULL DEFAULT NOW()
);
DROP TABLE IF EXISTS `PhieuXuPhat`;
CREATE TABLE IF NOT EXISTS `PhieuXuPhat` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TrangThai` ENUM('CHUA_XU_LY', 'DA_XU_LY') NOT NULL,
    `NgayViPham` DATETIME NOT NULL DEFAULT NOW(),
    `MoTa` NVARCHAR(255) NOT NULL,
    `ThoiHanXuPhat` INT UNSIGNED,
    `MucPhat` INT UNSIGNED,
    `IdThanhVien` INT UNSIGNED NULL,
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);
DROP TABLE IF EXISTS `LoaiThietBi`;
CREATE TABLE IF NOT EXISTS `LoaiThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TenLoaiThietBi` NVARCHAR(255) NOT NULL,
    `DaXoa` TINYINT(1) NOT NULL DEFAULT 0 -- 0: chưa xóa, 1: đã xóa
);
DROP TABLE IF EXISTS `ThietBi`;
CREATE TABLE IF NOT EXISTS `ThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TenThietBi` NVARCHAR(255) NOT NULL,
    `IdLoaiThietBi` INT UNSIGNED NOT NULL,
    `DaXoa` TINYINT(1) NOT NULL DEFAULT 0,
    -- 0: chưa xóa, 1: đã xóa
    FOREIGN KEY (`IdLoaiThietBi`) REFERENCES `LoaiThietBi`(`Id`)
);
DROP TABLE IF EXISTS `DauThietBi`;
CREATE TABLE IF NOT EXISTS `DauThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TrangThai` ENUM(
        'KHADUNG',
        'DATTRUOC',
        'DANGMUON',
        'THATLAC',
        'BAOTRI',
        'THANHLY',
        'DATHATLAC'
    ) NOT NULL,
    `ThoiGianMua` DATETIME NOT NULL,
    `IdThietBi` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`IdThietBi`) REFERENCES `ThietBi`(`Id`)
);
DROP TABLE IF EXISTS `PhieuDatCho`;
CREATE TABLE IF NOT EXISTS `PhieuDatCho` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `IdThanhVien` INT UNSIGNED NOT NULL,
    `TrangThai` ENUM('HUY', 'DANGCHO', 'DANGSUDUNG', 'DATRACHO') NOT NULL,
    `ThoiGianDat` DATETIME NOT NULL DEFAULT NOW(),
    `ThoiGianLapPhieu` DATETIME NOT NULL DEFAULT NOW(),
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);
DROP TABLE IF EXISTS `ChiTietPhieuDatCho`;
CREATE TABLE IF NOT EXISTS `ChiTietPhieuDatCho` (
    `IdPhieuDat` INT UNSIGNED NOT NULL,
    `IdDauThietBi` INT UNSIGNED NOT NULL,
    PRIMARY KEY (`IdPhieuDat`, `IdDauThietBi`),
    FOREIGN KEY (`IdPhieuDat`) REFERENCES `PhieuDatCho`(`Id`),
    FOREIGN KEY (`IdDauThietBi`) REFERENCES `DauThietBi`(`Id`)
);
DROP TABLE IF EXISTS `PhieuMuon`;
CREATE TABLE IF NOT EXISTS `PhieuMuon` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `IdThanhVien` INT UNSIGNED NOT NULL,
    `TrangThai` ENUM('HUY', 'DANGSUDUNG', 'DATRATHIETBI') NOT NULL,
    `NgayTao` DATETIME NOT NULL,
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);
DROP TABLE IF EXISTS `ChiTietPhieuMuon`;
CREATE TABLE IF NOT EXISTS `ChiTietPhieuMuon` (
    `IdPhieuMuon` INT UNSIGNED NOT NULL,
    `IdDauThietBi` INT UNSIGNED NOT NULL,
    `ThoiGianMuon` DATETIME NOT NULL,
    `ThoiGianTra` DATETIME NOT NULL,
    `TrangThai` ENUM('DANGMUON', 'DATRATHIETBI', 'DATHATLAC') NOT NULL,
    PRIMARY KEY (`IdPhieuMuon`, `IdDauThietBi`),
    FOREIGN KEY (`IdPhieuMuon`) REFERENCES `PhieuMuon`(`Id`),
    FOREIGN KEY (`IdDauThietBi`) REFERENCES `DauThietBi`(`Id`)
);
-- Thêm dữ liệu vào bảng ThanhVien
INSERT INTO ThanhVien (
        HoTen,
        NgaySinh,
        Email,
        SoDienThoai,
        TrangThai,
        MatKhau,
        ThoiGianDangKy,
        Quyen
    )
VALUES (
        'Ngô Tuấn Hưng',
        '2004-11-11',
        'hung@gmail.com',
        '0987654321',
        'HOATDONG',
        'AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==',
        NOW(),
        "ADMIN"
    ),
    (
        'Nguyễn Minh Phúc',
        '2004-11-01',
        'phuc@gmail.com',
        '0978123456',
        'HOATDONG',
        'AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==',
        NOW(),
        "USER"
    ),
    (
        'Trần Văn Khánh',
        '2004-12-05',
        'khanh@gmail.com',
        '0978567890',
        'HOATDONG',
        'AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==',
        NOW(),
        "USER"
    ),
    (
        'Đỗ Anh Đài',
        '2004-10-21',
        'dai@gmail.com',
        '0978124444',
        'DINHCHI',
        'AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==',
        NOW(),
        "USER"
    ),
    (
        'Diệp Thụy An',
        '2004-08-18',
        'an@gmail.com',
        '0967987654',
        'CAM',
        'AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==',
        NOW(),
        "USER"
    );
-- Thêm dữ liệu vào bảng CheckIn
INSERT INTO CheckIn (ThoiGianCheckIn)
VALUES ('2025-03-19 08:00:00'),
    ('2025-03-19 09:15:00'),
    ('2025-03-19 10:30:00'),
    ('2025-03-19 13:45:00'),
    ('2025-03-19 15:00:00');
-- Thêm dữ liệu vào bảng PhieuXuPhat
INSERT INTO PhieuXuPhat (
        TrangThai,
        NgayViPham,
        MoTa,
        ThoiHanXuPhat,
        MucPhat,
        IdThanhVien
    )
VALUES (
        'CHUA_XU_LY',
        '2025-03-18 14:00:00',
        'Làm hỏng thiết bị',
        7,
        500000,
        2
    ),
    (
        'DA_XU_LY',
        '2025-03-15 09:30:00',
        'Trả thiết bị trễ hạn',
        3,
        200000,
        3
    ),
    (
        'CHUA_XU_LY',
        '2025-03-17 16:00:00',
        'Mất thiết bị',
        10,
        1000000,
        4
    ),
    (
        'DA_XU_LY',
        '2025-03-10 11:00:00',
        'Vi phạm nội quy',
        5,
        300000,
        5
    ),
    (
        'CHUA_XU_LY',
        '2025-03-19 08:30:00',
        'Không check-in đúng giờ',
        2,
        100000,
        1
    );
-- Thêm dữ liệu vào bảng LoaiThietBi
INSERT INTO LoaiThietBi (TenLoaiThietBi, DaXoa)
VALUES ('Máy tính', 0),
    ('Máy chiếu', 0),
    ('Loa', 0),
    ('Máy in', 0),
    ('Cáp kết nối', 0);
-- Thêm dữ liệu vào bảng ThietBi
INSERT INTO ThietBi (TenThietBi, IdLoaiThietBi, DaXoa)
VALUES ('Laptop Dell XPS', 1, 0),
    ('Laptop HP EliteBook', 1, 0),
    ('Máy chiếu Sony', 2, 0),
    ('Máy chiếu Epson', 2, 0),
    ('Loa Bluetooth JBL', 3, 0),
    ('Loa Sony SRS', 3, 0),
    ('Máy in HP LaserJet', 4, 0),
    ('Máy in Canon Pixma', 4, 0),
    ('Cáp HDMI 2m', 5, 0),
    ('Cáp USB-C 1m', 5, 0);
-- Thêm dữ liệu vào bảng DauThietBi
INSERT INTO DauThietBi (TrangThai, ThoiGianMua, IdThietBi)
VALUES ('KHADUNG', '2024-01-15 00:00:00', 1),
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
INSERT INTO PhieuDatCho (
        IdThanhVien,
        TrangThai,
        ThoiGianDat,
        ThoiGianLapPhieu
    )
VALUES (
        1,
        'DANGCHO',
        '2025-03-20 09:00:00',
        '2025-03-19 10:00:00'
    ),
    (
        2,
        'DANGSUDUNG',
        '2025-03-19 14:00:00',
        '2025-03-19 08:00:00'
    ),
    (
        3,
        'DATRACHO',
        '2025-03-18 13:00:00',
        '2025-03-17 15:00:00'
    ),
    (
        4,
        'HUY',
        '2025-03-19 16:00:00',
        '2025-03-18 09:00:00'
    ),
    (
        5,
        'DANGCHO',
        '2025-03-21 10:00:00',
        '2025-03-19 12:00:00'
    );
-- Thêm dữ liệu vào bảng ChiTietPhieuDatCho
INSERT INTO ChiTietPhieuDatCho (IdPhieuDat, IdDauThietBi)
VALUES (1, 3),
    (2, 2),
    (3, 1),
    (4, 5),
    (5, 3);
-- Thêm dữ liệu vào bảng PhieuMuon
INSERT INTO PhieuMuon (IdThanhVien,TrangThai, NgayTao)
VALUES (1, 'DANGSUDUNG', '2025-03-19 09:00:00'),
    (2, 'DATRATHIETBI', '2025-03-18 10:00:00'),
    (3, 'HUY', '2025-03-17 14:00:00'),
    (4, 'DANGSUDUNG', '2025-03-19 11:00:00'),
    (5, 'DATRATHIETBI', '2025-03-16 08:00:00');
-- Thêm dữ liệu vào bảng ChiTietPhieuMuon
INSERT INTO ChiTietPhieuMuon (
        IdPhieuMuon,
        IdDauThietBi,
        ThoiGianMuon,
        ThoiGianTra,
        TrangThai
    )
VALUES (
        1,
        2,
        '2025-03-19 09:00:00',
        '2025-03-20 09:00:00',
        'DANGMUON'
    ),
    (
        2,
        1,
        '2025-03-18 10:00:00',
        '2025-03-19 10:00:00',
        'DATRATHIETBI'
    ),
    (
        3,
        5,
        '2025-03-17 14:00:00',
        '2025-03-18 14:00:00',
        'DATRATHIETBI'
    ),
    (
        4,
        2,
        '2025-03-19 11:00:00',
        '2025-03-20 11:00:00',
        'DANGMUON'
    ),
    (
        5,
        1,
        '2025-03-16 08:00:00',
        '2025-03-17 08:00:00',
        'DATRATHIETBI'
    );