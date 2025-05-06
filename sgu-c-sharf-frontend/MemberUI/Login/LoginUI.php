<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css" />
    <link rel="stylesheet" href="LoginUI.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <title>Login</title>
</head>

<body>
    <div class="container" id="container">
        <div class="form-container sign-up">
            <form>
                <h1>Create Account</h1>
                <input type="email" placeholder="Email" id="email" name="Email" />
                <input type="text" placeholder="Họ tên" id="hoTen" name="Hoten" />
                <input type="date" placeholder="Ngày sinh" id="ngaySinh" name="NgaySinh" />
                <input type="tel" placeholder="Số điện thoại" id="soDienThoai" name="SoDienThoai" />
                <input type="password" placeholder="Mật khẩu" id="matKhau" name="MatKhau" />
                <input type="password" placeholder="Xác thực mật khẩu" id="xacNhanMatKhau" name="XacThucMatKhau" />
                <button type="button" class="btn btn-danger" id="signUpButton">Đăng ký</button>
            </form>
        </div>

        <div class="form-container sign-in">
            <form>
                <h1>Sign In</h1>
                <input type="email" placeholder="Email" id="tenDangNhapLogin" />
                <input type="password" placeholder="Mật khẩu" id="passwordLogin" />
                <button type="button" class="btn btn-danger" id="signInButton">Đăng nhập</button>
                <button type="button" class="btn btn-link" id="forgotPasswordButton">Quên mật khẩu?</button>

            </form>
        </div>

        <div class="toggle-container">
            <div class="toggle">
                <div class="toggle-panel toggle-left">
                    <h1>Bạn đã có tài khoản ?</h1>
                    <p>Hãy đăng nhập tại đây để bắt đầu trải nghiệm.</p>
                    <button type="button" class="btn btn-light" id="login">Đăng nhập</button>
                </div>
                <div class="toggle-panel toggle-right">
                    <h1>Xin chào, bạn là người mới ?</h1>
                    <p>Hãy đăng ký tài khoản tại đây để có thể trải nghiệm các tính năng mới.</p>
                    <button type="button" class="btn btn-light" id="register">Đăng ký</button>
                </div>
            </div>
        </div>
    </div>


</body>




<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>



<script>
    //Script xử lý Registation
    const container = document.getElementById("container");
    const registerBtn = document.getElementById("register");
    const loginBtn = document.getElementById("login");
    const forgotPasswordBtn = document.getElementById("forgotPasswordButton");
    const sendEmailButton = document.getElementById("sendEmailButton");

    registerBtn.addEventListener("click", () => {
        container.classList.add("active");
    });

    loginBtn.addEventListener("click", () => {
        container.classList.remove("active");
    });
    forgotPasswordBtn.addEventListener("click", (event) => {
        event.preventDefault(); // Ngăn chặn sự chuyển đổi
        window.location.href = "./ResetPasswordUI.php";
    });


    const signUpButton = document.getElementById("signUpButton");

    signUpButton.addEventListener('click', async function check(event) {
        event.preventDefault();

        var email = $('#email').val().trim();
        var hoTen = $('#hoTen').val().trim();
        var ngaySinh = $('#ngaySinh').val() + "T00:00:00";
        var soDienThoai = $('#soDienThoai').val().trim();
        var matKhau = $('#matKhau').val().trim();
        var xacNhanMatKhau = $('#xacNhanMatKhau').val().trim();

        if (!email) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Email không được để trống',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            $('#email').focus();
            return;
        }

        if (!isValidEmail(email)) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Email không hợp lệ',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            $('#email').focus();
            return;
        }

        if (!hoTen) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Họ tên không được để trống',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            $('#hoTen').focus();
            return;
        }

        if (!ngaySinh) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Ngày sinh không được để trống',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            $('#ngaySinh').focus();
            return;
        }

        // Chuyển thành Date
        const birthDate = new Date(ngaySinh);
        const today = new Date();

        // Tính tuổi
        let age = today.getFullYear() - birthDate.getFullYear();
        const m = today.getMonth() - birthDate.getMonth();

        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--; // Nếu chưa đến sinh nhật trong năm hiện tại thì trừ 1
        }

        if (!matKhau) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Mật khẩu không được để trống',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            $('#matKhau').focus();
            return;
        }

        // if (matKhau.length < 8) {
        //     Swal.fire({
        //         title: 'Lỗi!',
        //         text: 'Mật khẩu phải dài từ 8 ký tự',
        //         icon: 'error',
        //         confirmButtonText: 'OK'
        //     });
        //     $('#matKhau').focus();
        //     return;
        // }

        if (!xacNhanMatKhau) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Mật khẩu xác nhận không được để trống',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            $('#xacNhanMatKhau').focus();
            return;
        }

        if (matKhau !== xacNhanMatKhau) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Mật khẩu xác nhận và mật khẩu phải giống nhau',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            $('#xacNhanMatKhau').focus();
            return;
        }

        try {
            const isEmailExists = await checkEmail(email);
            console.log(isEmailExists);
            if (isEmailExists.data) {
                Swal.fire({
                    title: 'Lỗi!',
                    text: 'Email tồn tại',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
                $('#email').focus();
                return;
            }
        } catch (error) {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Đã xảy ra lỗi khi kiểm tra tài khoản!',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            console.log(error);
            return;
        }

        const data = {
            Email: email,
            HoTen: hoTen,
            NgaySinh: ngaySinh,
            SoDienThoai: soDienThoai,
            MatKhau: matKhau
        };

        $.ajax({
            url: 'http://localhost:5244/api/thanh-vien/register',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function(response) {
                if (response.status == 200) {
                    Swal.fire({
                        title: "Thành công",
                        text: "Tạo tài khoản thành công",
                        icon: "success"
                    });
                    container.classList.remove("active");
                } else {
                    Swal.fire({
                        title: 'Lỗi!',
                        text: 'Đã xảy ra lỗi khi tạo tài khoản!',
                        icon: 'error',
                        confirmButtonText: 'OK'
                    });
                }


            },
            error: function(xhr) {
                Swal.fire({
                    title: 'Lỗi!',
                    text: 'Đăng ký thất bại',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
                console.log(xhr.responseJSON?.message);
            }
        });
    });


    function isValidEmail(email) {
        return /[^\s@]+@[^\s@]+\.[^\s@]+/.test(email);
    }

    async function checkEmail(email) {
        try {
            const response = await $.ajax({
                url: `http://localhost:5244/api/thanh-vien/check-email`,
                type: 'GET',
                dataType: 'json',
                data: {
                    email: email
                }
            });
            return response;
        } catch (error) {
            console.error("Thất bại:", error);
            return false;
        }
    }
</script>


<script>
    const loginButton = document.getElementById("signInButton");

    loginButton.addEventListener("click", (event) => {
        event.preventDefault();

        const tenDangNhap = document.getElementById("tenDangNhapLogin").value.trim();
        const matKhau = document.getElementById("passwordLogin").value.trim();

        // Kiểm tra tên đăng nhập
        if (tenDangNhap === "") {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Bạn không được để trống tên đăng nhập !!',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            document.getElementById("tenDangNhapLogin").focus();
            return;
        }

        // Kiểm tra mật khẩu
        if (matKhau === "") {
            Swal.fire({
                title: 'Lỗi!',
                text: 'Bạn không được để trống mật khẩu !!',
                icon: 'error',
                confirmButtonText: 'OK'
            });
            document.getElementById("passwordLogin").focus();
            return;
        }

        // Gọi hàm login với tên đăng nhập và mật khẩu đã nhập
        login(tenDangNhap, matKhau);
    });



    function login(email, password) {
        const data = {
            Identifier: email,
            MatKhau: password
        };

        $.ajax({
            url: 'http://localhost:5244/api/thanh-vien/login',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function(response) {
                if (response.status == 200) {
                    sessionStorage.setItem('id', response.data);

                    Swal.fire({
                        title: 'Đăng nhập thành công!',
                        text: 'Chào mừng bạn quay trở lại!',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        // Chuyển trang sau khi đăng nhập thành công (nếu muốn)
                        window.location.href = '../HomePage.php'; // đổi URL theo ý bạn
                    });
                }

            },
            error: function(xhr) {
                Swal.fire({
                    title: 'Đăng nhập thất bại!',
                    text: xhr.message ?? 'Email hoặc mật khẩu không đúng.',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            }
        });
    }
</script>


</html>