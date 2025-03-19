<style>
    .Sidebar_sideBar__CC4MK {
        position: fixed;
        height: 100dvh;
        width: 15%;
        background-color: rgba(50, 49, 49, 0.918);
    }

    .MenuItemSidebar_menuItem__56b1m.MenuItemSidebar_active__RPq {
        background-color: #333;
        color: #fff;
    }

    .MenuItemSidebar_menuItem__56b1m {
        display: flex;
        align-items: center;
        padding: 1rem;
        font-size: 1.8rem;
        font-weight: 700;
        color: #fff;
        cursor: pointer;
    }

    .active {
        background-color: white;
        color: black;
    }

    .menu-group {
        margin-bottom: 10px;
    }

    .menu-group-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 1rem;
        font-size: 1.8rem;
        font-weight: 700;
        color: #fff;
        cursor: pointer;
        background-color: rgba(70, 70, 70, 0.9);
    }

    .menu-group-content {
        display: none;
        background-color: rgba(50, 49, 49, 0.9);
    }

    .menu-group-content a {
        display: block;
        padding: 0.8rem;
        font-size: 2.2rem;
        color: #fff;
        text-decoration: none;
        transition: background 0.3s;
    }

    .menu-group-content a:hover {
        background-color: rgba(100, 100, 100, 0.9);
    }

    .menu-group-header .arrow {
        font-size: 1.4rem;
        transition: transform 0.3s;
    }

    .menu-group-header.open .arrow {
        transform: rotate(180deg);
    }
</style>
<link rel="stylesheet" href="../fontStyle.css" />

<div class="Sidebar_sideBar__CC4MK">

    <!-- Mục mới: Hồ sơ cá nhân -->
    <div class="menu-group">
        <div class="MenuItemSidebar_menuItem__56b1m menu-group-header" onclick="toggleMenu('profileMenu')">
            <span class="MenuItemSidebar_title__LLBtx arial-bold">📂 Hồ sơ cá nhân</span>
            <span class="arrow">▼</span>
        </div>
        <div class="menu-group-content" id="profileMenu">
            <a class="MenuItemSidebar_submenu__item" href="../Profile/ThongTinCaNhan.php">👤 Thông tin cá nhân</a>
            <a class="MenuItemSidebar_submenu__item" href="../Profile/NghiPhep.php">📅 Nghỉ phép</a>
            <a class="MenuItemSidebar_submenu__item" href="../Profile/LuongCaNhan.php">💰 Lương cá nhân</a>
        </div>
    </div>

    <!-- Menu Group: Kinh doanh -->
    <div class="menu-group">
        <div class="MenuItemSidebar_menuItem__56b1m menu-group-header" onclick="toggleMenu('kinhDoanhMenu')">
            <span class="MenuItemSidebar_title__LLBtx arial-bold">🛒 Kinh Doanh</span>
            <span class="arrow">▼</span>
        </div>
        <div class="menu-group-content" id="kinhDoanhMenu">
            <a class="MenuItemSidebar_submenu__item" id="QLLoaiSanPham" href="../QLLoaiSanPham/QLLoaiSanPham.php">Loại Sản Phẩm</a>
            <a class="MenuItemSidebar_submenu__item" id="QLSanPham" href="../QLSanPham/QLSanPham.php">Sản Phẩm</a>
            <a class="MenuItemSidebar_submenu__item" id="QLThuongHieu" href="../QLThuongHieu/QLThuongHieu.php">Thương Hiệu</a>
            <a class="MenuItemSidebar_submenu__item" id="QLDonHang" href="../QLDonHang/QLDonHang.php">Đơn Hàng</a>
            <a class="MenuItemSidebar_submenu__item" id="ThongKeBanChay" href="../ThongKe/ThongKeDoanhThuChiTieu.php">Thống Kê Bán Chạy</a>
            <a class="MenuItemSidebar_submenu__item" id="ThongKeDonHang" href="../ThongKe/ThongKeDonHang.php">Thống Kê Đơn Hàng</a>
            <!-- Thêm thống kê xuất kho -->
            <a class="MenuItemSidebar_submenu__item" id="ThongKeXuatKho" href="../ThongKe/ThongKeXuatKho.php">Thống Kê Xuất Kho</a>
        </div>
    </div>

    <!-- Menu Group: Vận hành -->
    <div class="menu-group">
        <div class="MenuItemSidebar_menuItem__56b1m menu-group-header" onclick="toggleMenu('vanHanhMenu')">
            <span class="MenuItemSidebar_title__LLBtx arial-bold">⚙️ Vận Hành</span>
            <span class="arrow">▼</span>
        </div>
        <div class="menu-group-content" id="vanHanhMenu">
            <a class="MenuItemSidebar_submenu__item" id="QLTaiKhoan" href="../QLTaiKhoan/QLTaiKhoan.php">Tài Khoản</a>
            <a class="MenuItemSidebar_submenu__item" id="QLNhaCungCap" href="../QLNhaCungCap/QLNhaCungCap.php">Nhà Cung Cấp</a>
            <a class="MenuItemSidebar_submenu__item" id="QLDonNghi" href="../QLDonNghi/QLDonNghi.php">Quản Lý Đơn Nghỉ</a>
            <a class="MenuItemSidebar_submenu__item" id="QLPhieuNhapKho" href="../QLPhieuNhapKho/QLPhieuNhapKho.php">Quản Lý Phiếu Nhập Kho</a>
            <a class="MenuItemSidebar_submenu__item" id="QLPhieuXuatKho" href="../QLPhieuXuatKho/QLPhieuXuatKho.php">Quản Lý Phiếu Xuất Kho</a>
            <a class="MenuItemSidebar_submenu__item" id="QLNhanSu" href="../QLNhanSu/QLNhanSu.php">Quản Lý Nhân Sự</a>
            <a class="MenuItemSidebar_submenu__item" id="QLLuongThuong" href="../QLLuongThuong/QLLuongThuong.php">Quản Lý Lương Thưởng</a>
            <a class="MenuItemSidebar_submenu__item" id="LuongCaNhan" href="../LuongCaNhan/LuongCaNhan.php">Lương Cá Nhân</a>
        </div>
    </div>
</div>

<script>
    const userRole1 = sessionStorage.getItem('role');

    document.addEventListener('DOMContentLoaded', () => {
        const menuItems = {
            QLTaiKhoan: document.getElementById('QLTaiKhoan'),
            QLLoaiSanPham: document.getElementById('QLLoaiSanPham'),
            QLSanPham: document.getElementById('QLSanPham'),
            QLThuongHieu: document.getElementById('QLThuongHieu'),
            QLNhaCungCap: document.getElementById('QLNhaCungCap'),
            QLDonHang: document.getElementById('QLDonHang'),
            ThongKeBanChay: document.getElementById('ThongKeBanChay'),
            ThongKeDonHang: document.getElementById('ThongKeDonHang'),
            QLDonNghi: document.getElementById('QLDonNghi'),
            QLPhieuNhapKho: document.getElementById('QLPhieuNhapKho'),
            QLNhanSu: document.getElementById('QLNhanSu'),
            QLLuongThuong: document.getElementById('QLLuongThuong'),
            LuongCaNhan: document.getElementById('LuongCaNhan'),
            ThongKeXuatKho: document.getElementById('ThongKeXuatKho') // Thêm vào đây
        };

        // if (userRole1 === 'Employee') {
        //     menuItems.QLTaiKhoan.style.display = 'none';
        //     menuItems.ThongKeBanChay.style.display = 'none';
        //     menuItems.ThongKeDonHang.style.display = 'none';
        //     menuItems.ThongKeXuatKho.style.display = 'none';
        // } else if (userRole1 === 'Admin') {
        //     Object.keys(menuItems).forEach(key => {
        //         if (!['QLTaiKhoan', 'QLNhanSu', 'QLLuongThuong', 'LuongCaNhan'].includes(key)) {
        //             menuItems[key].style.display = 'none';
        //         }
        //     });
        // } else {
        //     menuItems.QLTaiKhoan.style.display = 'none';
        // }
    });

    function toggleMenu(menuId) {
        const menu = document.getElementById(menuId);
        const header = menu.previousElementSibling;

        if (menu.style.display === "block") {
            menu.style.display = "none";
            header.classList.remove("open");
        } else {
            menu.style.display = "block";
            header.classList.add("open");
        }
    }

    // const currentPath = window.location.pathname.replace("/SGU-Enterprise-Information-System-EIS/eis-frontend/ManagerUI/", "");
    // const menuLinks = document.querySelectorAll('.MenuItemSidebar_menuItem__56b1m');
    // menuLinks.forEach(item => {
    //     const hrefPath = item.getAttribute('href').replace("../", "");
    //     if (hrefPath === currentPath) {
    //         item.classList.add('active');
    //     }
    // });
</script>