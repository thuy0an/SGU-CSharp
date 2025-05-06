DROP DATABASE IF EXISTS `SGU_C_Sharf`;
CREATE DATABASE IF NOT EXISTS `SGU_C_Sharf`;
USE `SGU_C_Sharf`;

-- Table: ThanhVien
DROP TABLE IF EXISTS `ThanhVien`;
CREATE TABLE IF NOT EXISTS `ThanhVien` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `HoTen` VARCHAR(255) NOT NULL,
    `NgaySinh` DATE NOT NULL,
    `Email` VARCHAR(255) NOT NULL UNIQUE,
    `SoDienThoai` VARCHAR(10) NOT NULL,
    `TrangThai` ENUM("HOATDONG", "DINHCHI", "CAM") NOT NULL,
    `Quyen` ENUM("USER", "ADMIN") NOT NULL,
    `MatKhau` VARCHAR(255) NOT NULL,
    `ThoiGianDangKy` DATETIME NOT NULL DEFAULT NOW()
);

-- Table: CheckIn
DROP TABLE IF EXISTS `CheckIn`;
CREATE TABLE IF NOT EXISTS `CheckIn` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `ThoiGianCheckIn` DATETIME NOT NULL DEFAULT NOW(),
    `IdThanhVien` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);

-- Table: OTP
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

-- Table: LoaiThietBi
DROP TABLE IF EXISTS `LoaiThietBi`;
CREATE TABLE IF NOT EXISTS `LoaiThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TenLoaiThietBi` VARCHAR(255) NOT NULL,
    `DaXoa` TINYINT(1) NOT NULL DEFAULT 0
);

-- Table: ThietBi
DROP TABLE IF EXISTS `ThietBi`;
CREATE TABLE IF NOT EXISTS `ThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TenThietBi` VARCHAR(255) NOT NULL,
    `IdLoaiThietBi` INT UNSIGNED NOT NULL,
    `DaXoa` TINYINT(1) NOT NULL DEFAULT 0,
    `AnhMinhHoa` VARCHAR(255),
    FOREIGN KEY (`IdLoaiThietBi`) REFERENCES `LoaiThietBi`(`Id`)
);

-- Table: DauThietBi
DROP TABLE IF EXISTS `DauThietBi`;
CREATE TABLE IF NOT EXISTS `DauThietBi` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TrangThai` ENUM("KHADUNG", "DATTRUOC", "DANGMUON", "THATLAC", "BAOTRI") NOT NULL,
    `ThoiGianMua` DATETIME NOT NULL,
    `IdThietBi` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`IdThietBi`) REFERENCES `ThietBi`(`Id`)
);

-- Table: PhieuMuon
DROP TABLE IF EXISTS `PhieuMuon`;
CREATE TABLE IF NOT EXISTS `PhieuMuon` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `IdThanhVien` INT UNSIGNED NOT NULL,
    `NgayTao` DATETIME NOT NULL DEFAULT NOW(),
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);

-- Table: ChiTietPhieuMuon
DROP TABLE IF EXISTS `ChiTietPhieuMuon`;
CREATE TABLE IF NOT EXISTS `ChiTietPhieuMuon` (
    `IdPhieuMuon` INT UNSIGNED NOT NULL,
    `IdDauThietBi` INT UNSIGNED NOT NULL,
    `ThoiGianMuon` DATETIME NOT NULL,
    `ThoiGianTra` DATETIME,
    `TrangThai` ENUM("CHODUYET", "DANGMUON", "DATRATHIETBI", "DATHATLAC") NOT NULL,
    PRIMARY KEY (`IdPhieuMuon`, `IdDauThietBi`),
    FOREIGN KEY (`IdPhieuMuon`) REFERENCES `PhieuMuon`(`Id`),
    FOREIGN KEY (`IdDauThietBi`) REFERENCES `DauThietBi`(`Id`)
);

-- Table: TrangThaiPhieuMuon
DROP TABLE IF EXISTS `TrangThaiPhieuMuon`;
CREATE TABLE IF NOT EXISTS `TrangThaiPhieuMuon` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `IdPhieuMuon` INT UNSIGNED NOT NULL,
    `TrangThai` ENUM("CHODUYET", "DATCHO", "DANGSUDUNG", "DATRATHIETBI", "HUY") NOT NULL,
    `ThoiGianCapNhat` DATETIME NOT NULL DEFAULT NOW(),
    FOREIGN KEY (`IdPhieuMuon`) REFERENCES `PhieuMuon`(`Id`)
);

-- Table: PhieuXuPhat
DROP TABLE IF EXISTS `PhieuXuPhat`;
CREATE TABLE IF NOT EXISTS `PhieuXuPhat` (
    `Id` INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    `TrangThai` ENUM("DAXOA", "DAXULY", "CHUAXULY") NOT NULL,
    `NgayViPham` DATETIME NOT NULL DEFAULT NOW(),
    `MoTa` NVARCHAR(255) NOT NULL,
    `ThoiHanXuPhat` INT UNSIGNED,
    `MucPhat` INT UNSIGNED,
    `IdThanhVien` INT UNSIGNED NOT NULL,
    FOREIGN KEY (`IdThanhVien`) REFERENCES `ThanhVien`(`Id`)
);

-- Insert: ThanhVien
INSERT INTO `ThanhVien` (`HoTen`, `NgaySinh`, `Email`, `SoDienThoai`, `TrangThai`, `MatKhau`, `ThoiGianDangKy`, `Quyen`)
VALUES 
    ("Ngô Tuấn Hưng", "2004-11-11", "hung@gmail.com", "0987654321", "HOATDONG", "AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==", NOW(), "ADMIN"),
    ("Nguyễn Minh Phúc", "2004-11-01", "phuc@gmail.com", "0978123456", "HOATDONG", "AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==", NOW(), "USER"),
    ("Trần Văn Khánh", "2004-12-05", "khanh@gmail.com", "0978567890", "HOATDONG", "AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==", NOW(), "USER"),
    ("Đỗ Anh Đài", "2004-10-21", "dai@gmail.com", "0978124444", "DINHCHI", "AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==", NOW(), "USER"),
    ("Diệp Thụy An", "2004-08-18", "an@gmail.com", "0967987654", "CAM", "AQAAAAIAAYagAAAAEDSlGSabwVBLvb7tRgS9SULXUGDS9VN3Nlw7l5kcN61KOsJdsLs6aPz+wCN0lBFDHA==", NOW(), "USER");

-- Insert: CheckIn
INSERT INTO `CheckIn` (`ThoiGianCheckIn`, `IdThanhVien`)
VALUES 
    ("2025-03-19 08:00:00", 1),
    ("2025-03-19 09:15:00", 2),
    ("2025-03-19 10:30:00", 3),
    ("2025-03-19 13:45:00", 4),
    ("2025-03-19 15:00:00", 5);

-- Insert: OTP
INSERT INTO `OTP` (`token`, `ngayTao`, `ngayHetHan`, `loaiOTP`, `IdThanhVien`)
VALUES 
    ("123456", NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), "VERIFY_EMAIL", 1),
    ("654321", NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), "RESET_PASSWORD", 2),
    ("789012", NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), "VERIFY_EMAIL", 3),
    ("456789", NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), "RESET_PASSWORD", 4),
    ("987654", NOW(), DATE_ADD(NOW(), INTERVAL 15 MINUTE), "VERIFY_EMAIL", 5);

-- Insert: PhieuXuPhat
INSERT INTO `PhieuXuPhat` (`TrangThai`, `NgayViPham`, `MoTa`, `ThoiHanXuPhat`, `MucPhat`, `IdThanhVien`)
VALUES 
    ("CHUAXULY", "2025-03-18 14:00:00", "Làm hỏng thiết bị", 7, 500000, 2),
    ("DAXULY", "2025-03-15 09:30:00", "Trả thiết bị trễ hạn", 3, 200000, 3),
    ("CHUAXULY", "2025-03-17 16:00:00", "Mất thiết bị", 10, 1000000, 4),
    ("DAXULY", "2025-03-10 11:00:00", "Vi phạm nội quy", 5, 300000, 5),
    ("DAXOA", "2025-03-19 08:30:00", "Không check-in đúng giờ", 2, 100000, 1);


-- Thêm dữ liệu vào bảng LoaiThietBi
INSERT INTO `LoaiThietBi` (`TenLoaiThietBi`, `DaXoa`)
VALUES 
    ("Laptop", 0),
    ("Máy chiếu", 0),
    ("Micro", 0),
    ("Camera", 0);

-- Thêm dữ liệu vào bảng ThietBi
INSERT INTO `ThietBi` (`TenThietBi`, `IdLoaiThietBi`, `DaXoa`, `AnhMinhHoa`)
VALUES 
    ("Laptop Dell XPS 13", 1, 0, "dell_xps_13.jpg"),
    ("Máy chiếu Epson", 2, 0, "epson_projector.jpg"),
    ("Micro không dây Sony", 3, 0, "sony_micro.jpg"),
    ("Camera Canon EOS", 4, 0, "canon_eos.jpg");

-- Thêm dữ liệu vào bảng DauThietBi
INSERT INTO `DauThietBi` (`TrangThai`, `ThoiGianMua`, `IdThietBi`)
VALUES 
    ("KHADUNG", "2023-01-10 10:00:00", 1),
    ("DATTRUOC", "2023-02-12 11:00:00", 2),
    ("DANGMUON", "2023-03-15 12:00:00", 3),
    ("BAOTRI", "2023-04-18 13:00:00", 4);

-- Thêm dữ liệu vào bảng PhieuMuon
INSERT INTO `PhieuMuon` (`IdThanhVien`, `NgayTao`)
VALUES 
    (1, "2025-03-20 09:00:00"),
    (2, "2025-03-21 10:00:00");

-- Thêm dữ liệu vào bảng ChiTietPhieuMuon
INSERT INTO `ChiTietPhieuMuon` (`IdPhieuMuon`, `IdDauThietBi`, `ThoiGianMuon`, `ThoiGianTra`, `TrangThai`)
VALUES 
    (1, 1, "2025-03-20 09:15:00", NULL, "DANGMUON"),
    (1, 2, "2025-03-20 09:20:00", "2025-03-22 09:20:00", "DATRATHIETBI"),
    (2, 3, "2025-03-21 10:30:00", NULL, "DANGMUON");

-- Thêm dữ liệu vào bảng TrangThaiPhieuMuon
INSERT INTO `TrangThaiPhieuMuon` (`IdPhieuMuon`, `TrangThai`, `ThoiGianCapNhat`)
VALUES 
    (1, "DANGSUDUNG", "2025-03-20 09:30:00"),
    (1, "DATRATHIETBI", "2025-03-22 09:30:00"),
    (2, "DANGSUDUNG", "2025-03-21 10:45:00");
