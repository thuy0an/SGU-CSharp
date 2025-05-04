<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="./Profile.css">
    <title>Thông tin cá nhân</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <!-- <link rel="stylesheet" href="./login.css" /> -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../utils/formatOutput.js"></script>
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"
        integrity="sha384-k6RqeWeci5ZR/Lv4MR0sA0FfDOMlI4F/x3Rgx31ZobM4uZ5dI6cuJg6RZ/aXjmD"
        crossorigin="anonymous">
</head>
<body>
    <?php require_once "./Header.php" ?>
    <div class="col-12">
        <div class="my-2 d-flex justify-content-center">
            <h3 style="z-index: 1; font-size: 32px; color: #7b181a; position: relative; background-color: white; padding: 0 20px; margin: 30px 0; font-family: Roboto; font-weight: bold !important;">Thông tin cá nhân</h3>
            <hr>
        </div>
        <div class="row mb-5 gx-5 d-flex justify-content-center" id="contentprofile" style="height: fit-content; margin: 0px;">
            <!-- Content will be populated here via JavaScript -->
            <div class="col-xxl-8 mb-5 mb-xxl-0">
                <form name="profileForm" action="Profile.php" method="POST" onsubmit="return validateForm()">
                    <div class="bg-secondary-soft px-4 py-5 rounded">
                        <div class="row g-3" style="text-align:left;">
                            <!-- Hidden ID -->
                            <input type="hidden" name="id" id="userId">

                            <div class="col-md-6">
                                <label class="form-label">Họ tên *</label>
                                <input type="text" class="form-control" name="hoten" id="fullname" required>
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">Số điện thoại *</label>
                                <input type="text" class="form-control" name="sodienthoai" id="phone" required>
                            </div>


                            <div class="col-md-6">
                                <label for="birthday">Ngày sinh</label>
                                <input type="date" class="form-control" id="birthday" name="ngaysinh">
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">Email *</label>
                                <input type="email" class="form-control readonly-highlight" id="inputEmail4" name="email" readonly>
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">Thời gian đăng ký</label>
                                <input type="text" class="form-control readonly-highlight" id="thoiGianDangKy" name="thoiGianDangKy" readonly>
                            </div>


                            <div class="col-12 mt-3">
                                <button class="btn btn-primary" type="submit" style="background-color: rgb(146, 26, 26);">Thay đổi thông tin</button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>



            <div class="col-xxl-8 mb-5 mb-xxl-0">

                <hr class="my-4">

                <div class="my-2 d-flex justify-content-center">
                    <h3 style="z-index: 1; font-size: 32px; color: #7b181a; position: relative; background-color: white; padding: 0 20px; margin: 30px 0; font-family: Roboto; font-weight: bold !important;">Đổi mật khẩu</h3>
                    <hr>
                </div>                
                <div class="row g-3">
                    <div class="col-md-6">
                        <label class="form-label">Mật khẩu cũ *</label>
                        <input type="password" class="form-control" id="oldPassword">
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">Mật khẩu mới *</label>
                        <input type="password" class="form-control" id="newPassword">
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">Xác nhận mật khẩu mới *</label>
                        <input type="password" class="form-control" id="confirmNewPassword">
                    </div>
                    <div class="col-md-12">
                        <button class="btn btn-primary mt-2" style="background-color: rgb(146, 26, 26);" type="button" onclick="changePassword()">Đổi mật khẩu</button>
                    </div>
                </div>
            </div>


            
        </div>



    </div>
    <?php require_once "./Footer.php" ?>

    <script>

        document.addEventListener("DOMContentLoaded", function() {

            loadUserInfoFromSessionStorage()

            const form = document.getElementById("profileForm");
            if (form) {
                form.addEventListener("submit", function(event) {
                    event.preventDefault(); // Ngăn hành vi gửi form mặc định
                    validateForm();
                });
            }
        });


        function loadUserInfoFromSessionStorage() {
            $.ajax({
                url: `http://localhost:5244/api/thanh-vien/${id}`,
                method: "GET",
                dataType: "json",
                success: function(response) {
                    if (response && response.data) {
                        const user = response.data;

                        document.getElementById("fullname").value = user.hoTen || '';
                        document.getElementById("phone").value = user.soDienThoai || '';
                        document.getElementById("birthday").value = user.ngaySinh ? user.ngaySinh.split('T')[0] : '';
                        document.getElementById("inputEmail4").value = user.email || '';
                        document.getElementById("thoiGianDangKy").value = convertDateTimeFormat(user.thoiGianDangKy)

                    } else {
                        console.error("Không có dữ liệu người dùng trong phản hồi");
                    }
                },
                error: function(xhr, status, error) {
                    console.error("Lỗi khi gọi API:", error);
                }
            });
        }


        function validateForm() {
            const form = document.forms["profileForm"];
            const fullname = form['hoten'].value.trim();
            const phone = form['sodienthoai'].value.trim();
            const birthday = form['ngaysinh'].value.trim();

            if (!fullname || !phone || !birthday) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Vui lòng điền đầy đủ thông tin!'
                });
                return false;
            }


            const updateData = {
                HoTen: fullname,
                SoDienThoai: phone,
                NgaySinh: birthday,
            };

            $.ajax({
                url: `http://localhost:5244/api/thanh-vien/${id}`,
                method: "PUT", // Hoặc PATCH tùy theo backend
                data: JSON.stringify(updateData),
                contentType: "application/json",
                success: function(response) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Thành công',
                        text: 'Cập nhật thông tin thành công!'
                    }).then(() => {
                        location.reload();
                    });
                },
                error: function(error) {
                    console.error('Lỗi cập nhật:', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: 'Có lỗi xảy ra khi cập nhật thông tin!'
                    });
                }
            });

            return false;
        }


        function changePassword() {
            const oldPasswordInput = document.getElementById("oldPassword");
            const newPasswordInput = document.getElementById("newPassword");
            const confirmNewPasswordInput = document.getElementById("confirmNewPassword");

            const oldPassword = oldPasswordInput.value.trim();
            const newPassword = newPasswordInput.value.trim();
            const confirmNewPassword = confirmNewPasswordInput.value.trim();
      

            // Reset lại viền lỗi nếu có trước đó
            [oldPasswordInput, newPasswordInput, confirmNewPasswordInput].forEach(input => {
                input.classList.remove("border-danger");
            });

            let hasError = false;

            if (!oldPassword) {
                oldPasswordInput.classList.add("border-danger");
                hasError = true;
            }
            if (!newPassword) {
                newPasswordInput.classList.add("border-danger");
                hasError = true;
            }
            if (!confirmNewPassword) {
                confirmNewPasswordInput.classList.add("border-danger");
                hasError = true;
            }

            if (hasError) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Vui lòng điền đầy đủ các trường mật khẩu!'
                });
                return;
            }

            if (newPassword !== confirmNewPassword) {
                newPasswordInput.classList.add("border-danger");
                confirmNewPasswordInput.classList.add("border-danger");
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Mật khẩu mới và xác nhận mật khẩu không khớp!'
                });
                return;
            }

    
            const data = {
                identifier: id,
                matKhauCu: oldPassword,
                matKhauMoi: newPassword
            };

            $.ajax({
                url: "http://localhost:5244/api/thanh-vien/change-password",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                success: function(response) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Thành công',
                        text: 'Đổi mật khẩu thành công!'
                    }).then(() => {
                        oldPasswordInput.value = '';
                        newPasswordInput.value = '';
                        confirmNewPasswordInput.value = '';
                    });
                },
                error: function(xhr) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: xhr.responseJSON.message || 'Đổi mật khẩu thất bại!'
                    });
                }
            });
        }


    </script>



</body>

</html>
