<!-- CSS -->
<style>
    #Home-img {
        width: 110px;
        height: 80px;
    }

    .input__wrapper {
        display: flex;
        align-items: center;
        position: relative;
        gap: 10px;
        justify-content: center;
    }

    .header-option {
        cursor: pointer;
        font-size: 24px;
        display: flex;
        align-items: center;
        justify-content: center;
        width: auto;
        height: 40px;
        background-color: white;
        color: rgb(146, 26, 26);
        padding: 10px 25px;
        border: none;
        border-radius: 5px;
    }

    .header-option:hover {
        background-color: rgb(241, 221, 221);
    }

    @media (max-width: 768px) {
        #Home-img {
            width: 100px;
            height: auto;
        }
        .header-option {
            padding: 5px;
        }
    }

    @media (max-width: 576px) {
        .col-md-2 {
            text-align: center;
        }

        .input__wrapper {
            flex-direction: column;
            align-items: stretch;
            gap: 5px;
        }

        .col-md-4 {
            flex-direction: column;
            align-items: center;
            gap: 10px;
        }
    }
</style>

<!-- HTML -->
<header class="container-fluid bg-danger" style="background-color: rgb(146, 26, 26) !important;">
    <div class="row align-items-center justify-content-center">
        <!-- Logo -->
        <div class="col-12 col-md-2 text-center mb-2 mb-md-0">
            <img id="Home-img" src="./img/logoWine.jpg" alt="Logo" class="img-fluid mx-auto" />
        </div>

        <!-- Icon Buttons -->
        <div class="col-12 col-md-8 d-flex justify-content-end align-items-center gap-3 flex-wrap" style="height: fit-content;">
            <div class="header-option header-option-login" onclick="toDeviceBooking()" title="Đặt thiết bị">
                <i class="fa-solid fa-calendar-check"></i>
            </div>
            <div class="header-option header-option-login" onclick="toProfile()" title="Thông tin cá nhân">
                <i class="fa-solid fa-user"></i>
            </div>
        
            <div class="header-option header-option-login" onclick="toUserHistory()" title="Lịch sử người dùng">
                <i class="fa-solid fa-clock-rotate-left"></i>
            </div>
            <div class="header-option header-option-login" onclick="logout()" title="Đăng xuất">
                <i class="fa-solid fa-right-from-bracket"></i>
            </div>

            <div id="Home-login" class="text-center">
                <button class="btn btn-light text-danger" style="font-weight:bold;">Login</button>
            </div>
        </div>
    </div>
</header>

<!-- SCRIPT -->
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
<script>
    // const role = sessionStorage.getItem('role'); 
    const role = "user";

    const loginBtn = document.getElementById("Home-login");
    const loginOptions = document.querySelectorAll(".header-option-login");

    // Ẩn hoặc hiển thị các nút dựa trên trạng thái đăng nhập
    if (role) {
        loginBtn.style.display = 'none';
    } else {
        loginOptions.forEach(el => el.style.display = 'none');
    }

    // Click vào nút Login
    loginBtn.addEventListener("click", () => {
        window.location.href = './Login/LoginUI.php';
    });

    // Click vào logo về trang chủ
    document.getElementById("Home-img").addEventListener("click", () => {
        window.location.href = "./HomePage.php";
    });

    function toProfile() {
        redirectWithUserId("Profile.php");
    }

    function toDeviceBooking() {
        redirectWithUserId("DeviceBooking.php");
    }

    function toUserHistory() {
        redirectWithUserId("UserHistory.php");
    }

    function redirectWithUserId(destination) {
        const userId = JSON.parse(sessionStorage.getItem("id"));
        if (userId) {
            window.location.href = `${destination}?maTaiKhoan=${userId}`;
        } else {
            Swal.fire("Lỗi", "Không tìm thấy người dùng!", "error");
        }
    }

    function logout() {
        Swal.fire({
            title: 'Xác nhận đăng xuất',
            text: 'Bạn có chắc chắn muốn đăng xuất?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                sessionStorage.removeItem("id");
                sessionStorage.removeItem("email");
                sessionStorage.removeItem("role");
                window.location.href = "./HomePage.php";
            }
        });
    }
</script>
