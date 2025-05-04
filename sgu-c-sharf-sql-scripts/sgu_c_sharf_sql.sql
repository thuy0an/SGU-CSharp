DROP DATABASE IF EXISTS `SGU_C_Sharf`;
CREATE DATABASE IF NOT EXISTS `SGU_C_Sharf`;
USE `SGU_C_Sharf`;

-- ThanhVien table
DROP TABLE IF EXISTS `ThanhVien`;
CREATE TABLE IF NOT EXISTS `ThanhVien` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `HoTen` VARCHAR(255) NOT NULL,
    `NgaySinh` DATE NOT NULL,
    `Email` VARCHAR(255) NOT NULL UNIQUE,
    `SoDienThoai` VARCHAR(10) NOT NULL,
    `TrangThai` ENUM('HOATDONG', 'DINHCHI', 'CAM') NOT NULL,
    `Quyen` ENUM ('USER', 'ADMIN') NOT NULL,
    `MatKhau` VARCHAR(255) NOT NULL,
    `ThoiGianDangKy` DATETIME NOT NULL DEFAULT NOW()
);

-- CheckIn table
DROP TABLE IF EXISTS `CheckIn`;
CREATE TABLE IF NOT EXISTS `CheckIn` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `ThoiGianCheckIn` DATETIME NOT NULL DEFAULT NOW(),
    `IdThanhVien` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);

-- OTP table
DROP TABLE IF EXISTS `OTP`;
CREATE TABLE IF NOT EXISTS `OTP` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `token` VARCHAR(255) NOT NULL,
    `ngayTao` DATETIME NOT NULL DEFAULT NOW(),
    `ngayHetHan` DATETIME NOT NULL,
    `loaiOTP` VARCHAR(50) NOT NULL,
    `IdThanhVien` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);

-- LoaiThietBi table
DROP TABLE IF EXISTS `LoaiThietBi`;
CREATE TABLE IF NOT EXISTS `LoaiThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TenLoaiThietBi` VARCHAR(255) NOT NULL,
    `DaXoa` TINYINT(1) NOT NULL DEFAULT 0 -- 0: chưa xóa, 1: đã xóa
);

-- ThietBi table
DROP TABLE IF EXISTS `ThietBi`;
CREATE TABLE IF NOT EXISTS `ThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TenThietBi` VARCHAR(255) NOT NULL,
    `IdLoaiThietBi` INT UNSIGNED NOT NULL,
    `DaXoa` TINYINT(1) NOT NULL DEFAULT 0, -- 0: chưa xóa, 1: đã xóa
    `AnhMinhHoa` VARCHAR(255) NULL,
    FOREIGN KEY (`IdLoaiThietBi`) REFERENCES `LoaiThietBi`(`Id`)
);

-- DauThietBi table
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

-- PhieuMuon table
DROP TABLE IF EXISTS `PhieuMuon`;
CREATE TABLE IF NOT EXISTS `PhieuMuon` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `IdThanhVien` INT UNSIGNED NOT NULL,
    `NgayTao` DATETIME NOT NULL DEFAULT NOW(),
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);

-- ChiTietPhieuMuon table
DROP TABLE IF EXISTS `ChiTietPhieuMuon`;
CREATE TABLE IF NOT EXISTS `ChiTietPhieuMuon` (
    `IdPhieuMuon` INT UNSIGNED NOT NULL,
    `IdDauThietBi` INT UNSIGNED NOT NULL,
    `ThoiGianMuon` DATETIME NOT NULL,
    `ThoiGianTra` DATETIME,
    `TrangThai` ENUM('DANGMUON', 'DATRATHIETBI', 'DATHATLAC') NOT NULL,
    PRIMARY KEY (`IdPhieuMuon`, `IdDauThietBi`),
    FOREIGN KEY (`IdPhieuMuon`) REFERENCES `PhieuMuon`(`Id`),
    FOREIGN KEY (`IdDauThietBi`) REFERENCES `DauThietBi`(`Id`)
);

-- TrangThaiPhieuMuon table - Updated status values
DROP TABLE IF EXISTS `TrangThaiPhieuMuon`;
CREATE TABLE IF NOT EXISTS `TrangThaiPhieuMuon` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `IdPhieuMuon` INT UNSIGNED NOT NULL,
    `TrangThai` ENUM('HUY', 'DATCHO', 'DANGSUDUNG', 'DATRATHIETBI') NOT NULL,
    `ThoiGianCapNhat` DATETIME NOT NULL DEFAULT NOW(),
    FOREIGN KEY (`IdPhieuMuon`) REFERENCES `PhieuMuon`(`Id`)
);

-- PhieuXuPhat table - Updated status values
DROP TABLE IF EXISTS `PhieuXuPhat`;
CREATE TABLE IF NOT EXISTS `PhieuXuPhat` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TrangThai` ENUM('DAXOA', 'DAXULY', 'CHUAXULY') NOT NULL,
    `NgayViPham` DATETIME NOT NULL DEFAULT NOW(),
    `MoTa` NVARCHAR(255) NOT NULL,
    `ThoiHanXuPhat` INT UNSIGNED,
    `MucPhat` INT UNSIGNED,
    `IdThanhVien` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
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
INSERT INTO CheckIn (ThoiGianCheckIn, IdThanhVien)
VALUES ('2025-03-19 08:00:00', 1),
       ('2025-03-19 09:15:00', 2),
       ('2025-03-19 10:30:00', 3),
       ('2025-03-19 13:45:00', 4),
       ('2025-03-19 15:00:00', 5);

-- Thêm dữ liệu vào bảng OTP
INSERT INTO OTP (token, ngayTao, ngayHetHan, loaiOTP, IdThanhVien)
VALUES ('123456', NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), 'VERIFY_EMAIL', 1),
       ('654321', NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), 'RESET_PASSWORD', 2),
       ('789012', NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), 'VERIFY_EMAIL', 3),
       ('456789', NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), 'RESET_PASSWORD', 4),
       ('987654', NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), 'VERIFY_EMAIL', 5);

-- Thêm dữ liệu vào bảng PhieuXuPhat - Updated status values
INSERT INTO PhieuXuPhat (
        TrangThai,
        NgayViPham,
        MoTa,
        ThoiHanXuPhat,
        MucPhat,
        IdThanhVien
    )
VALUES (
        'CHUAXULY',
        '2025-03-18 14:00:00',
        'Làm hỏng thiết bị',
        7,
        500000,
        2
    ),
    (
        'DAXULY',
        '2025-03-15 09:30:00',
        'Trả thiết bị trễ hạn',
        3,
        200000,
        3
    ),
    (
        'CHUAXULY',
        '2025-03-17 16:00:00',
        'Mất thiết bị',
        10,
        1000000,
        4
    ),
    (
        'DAXULY',
        '2025-03-10 11:00:00',
        'Vi phạm nội quy',
        5,
        300000,
        5
    ),
    (
        'DAXOA',
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
INSERT INTO ThietBi (TenThietBi, IdLoaiThietBi, DaXoa, AnhMinhHoa)
VALUES ('Laptop Dell XPS', 1, 0, 'dell_xps.jpg'),
       ('Laptop HP EliteBook', 1, 0, 'hp_elitebook.jpg'),
       ('Máy chiếu Sony', 2, 0, 'sony_projector.jpg'),
       ('Máy chiếu Epson', 2, 0, 'epson_projector.jpg'),
       ('Loa Bluetooth JBL', 3, 0, 'jbl_speaker.jpg'),
       ('Loa Sony SRS', 3, 0, 'sony_speaker.jpg'),
       ('Máy in HP LaserJet', 4, 0, 'hp_laserjet.jpg'),
       ('Máy in Canon Pixma', 4, 0, 'canon_pixma.jpg'),
       ('Cáp HDMI 2m', 5, 0, 'hdmi_cable.jpg'),
       ('Cáp USB-C 1m', 5, 0, 'usbc_cable.jpg');

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

-- Thêm dữ liệu vào bảng PhieuMuon
INSERT INTO PhieuMuon (IdThanhVien, NgayTao)
VALUES (1, '2025-03-19 09:00:00'),
       (2, '2025-03-18 10:00:00'),
       (3, '2025-03-17 14:00:00'),
       (4, '2025-03-19 11:00:00'),
       (5, '2025-03-16 08:00:00');

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

-- Thêm dữ liệu vào bảng TrangThaiPhieuMuon - Updated status values
INSERT INTO TrangThaiPhieuMuon (IdPhieuMuon, TrangThai, ThoiGianCapNhat)
VALUES (1, 'DANGSUDUNG', '2025-03-19 09:00:00'),
       (2, 'DATRATHIETBI', '2025-03-19 10:00:00'),
       (3, 'HUY', '2025-03-17 15:00:00'),
       (4, 'XACNHAN', '2025-03-19 11:00:00'),
       (5, 'DATRATHIETBI', '2025-03-17 08:00:00');