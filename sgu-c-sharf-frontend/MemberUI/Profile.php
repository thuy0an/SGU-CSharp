<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css">
    <link rel="stylesheet" href="Profile.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <title>Thông tin cá nhân</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../HelperUI/formatOutput.js"></script>
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
                            <div class="col-md-6">
                                <label class="form-label">Họ tên *</label>
                                <input type="text" class="form-control" name="hoten" id="fullname">
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Số điện thoại *</label>
                                <input type="text" class="form-control" name="sodienthoai" id="phone">
                            </div>
                            <div class="col-md-6">
                                <label for="gioitinh">Giới tính</label>
                                <div class="form-check form-check-inline">
                                    <input class="form-check-input" type="radio" name="gioitinh" id="male" value="Male">
                                    <label class="form-check-label" for="male">Nam</label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <input class="form-check-input" type="radio" name="gioitinh" id="female" value="Female">
                                    <label class="form-check-label" for="female">Nữ</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="birthday">Ngày sinh</label>
                                <input type="date" class="form-control" id="birthday" name="ngaysinh">
                            </div>
                            <div class="col-md-6">
                                <label for="inputEmail4" class="form-label">Email *</label>
                                <input type="email" class="form-control" id="inputEmail4" name="email" readonly>
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Địa chỉ *</label>
                                <input type="text" class="form-control" name="diachi" id="address">
                            </div>
                            <button class="btn btn-primary" type="submit" style="background-color: rgb(146, 26, 26);">Thay đổi thông tin</button>
                        </div>
                    </div>
                </form>
            </div>


            <div class="col-xxl-8 mb-5 mb-xxl-0">

                <hr class="my-4">

                <h5 style="color: #7b181a; font-weight: bold;">Đổi mật khẩu</h5>
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
                        <button class="btn btn-warning mt-2" type="button" onclick="changePassword()">Đổi mật khẩu</button>
                    </div>
                </div>
            </div>


            
        </div>



    </div>
    <?php require_once "./Footer.php" ?>

    <script>
        var email = '';

        function loadUserInfoFromsessionStorage() {
            // Lấy dữ liệu từ sessionStorage
            var userData = sessionStorage.getItem("id");

            // Kiểm tra xem userData có tồn tại không
            if (!userData) {
                console.error("No user data found in sessionStorage");
                return;
            }

            $.ajax({
                url: '../../Controllers/UserInformationController.php',
                method: "GET",
                dataType: "json",
                data: {
                    Id: userData
                },
                success: function(response) {
                    // Kiểm tra nếu phản hồi chứa dữ liệu
                    if (response && response.data) {
                        var userInfo = response.data; // Lấy thông tin người dùng đầu tiên từ mảng dữ liệu
                        
                        // Cập nhật các phần tử HTML với dữ liệu từ API
                        document.getElementById("fullname").value = userInfo.Fullname || '';
                        document.getElementById("phone").value = userInfo.PhoneNumber || '';
                        document.getElementById("birthday").value = userInfo.Birthday || '';
                        document.getElementById("inputEmail4").value = userInfo.Email || '';
                        document.getElementById("address").value = userInfo.Address || '';

                        // Cập nhật giới tính
                        if (userInfo.Gender === 'Male') {
                            document.getElementById("male").checked = true;
                        } else if (userInfo.Gender === 'Female') {
                            document.getElementById("female").checked = true;
                        }
                    } else {
                        console.error("No user data found in response");
                    }
                },
                error: function(xhr, status, error) {
                    console.error("Error:", error);
                }
            });
        }

        window.onload = loadUserInfoFromsessionStorage;

        function validateForm() {
            // Lấy các giá trị từ form
            var form = document.forms["profileForm"];
            var fullname = form['hoten'].value.trim();
            var phone = form['sodienthoai'].value.trim();
            var birthday = form['ngaysinh'].value.trim();
            var gender = form['gioitinh'].value;
            var address = form['diachi'].value.trim();

            // Kiểm tra các trường bắt buộc
            if (!fullname || !phone || !birthday || !address) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Vui lòng điền đầy đủ thông tin!'
                });
                return false; // Ngăn chặn form gửi theo cách truyền thống
            }

            // Lấy accountId từ URL
            var accountId = new URLSearchParams(window.location.search).get('maTaiKhoan');
            if (!accountId) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Không tìm thấy mã tài khoản!'
                });
                return false;
            }

            // Chuẩn bị dữ liệu gửi đi
            var formData = {
                accountId: accountId,
                fullname: fullname,
                phone: phone,
                birthday: birthday,
                gender: gender,
                address: address
            };

            $.ajax({
                url: "../../Controllers/UserInformationController.php",
                method: "PATCH",
                data: JSON.stringify(formData), // Dữ liệu ở dạng JSON
                contentType: "application/json",
                success: function(response) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Thành công',
                        text: 'Cập nhật thông tin thành công!'
                    }).then(() => {
                        location.reload(); // Reload lại trang sau khi cập nhật thành công
                    });

                },
                error: function(error) {
                    console.error('Error:', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: 'Có lỗi xảy ra khi gửi yêu cầu!'
                    });
                }
            });

            return false; // Ngăn chặn form gửi theo cách truyền thống
        }


        function changePassword() {
            const oldPasswordInput = document.getElementById("oldPassword");
            const newPasswordInput = document.getElementById("newPassword");
            const confirmNewPasswordInput = document.getElementById("confirmNewPassword");

            const oldPassword = oldPasswordInput.value.trim();
            const newPassword = newPasswordInput.value.trim();
            const confirmNewPassword = confirmNewPasswordInput.value.trim();
            const accountId = new URLSearchParams(window.location.search).get('maTaiKhoan');

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

            if (!accountId) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Không tìm thấy mã tài khoản!'
                });
                return;
            }

            const data = {
                accountId: accountId,
                oldPassword: oldPassword,
                newPassword: newPassword
            };

            $.ajax({
                url: "../../Controllers/UserInformationController.php?action=changePassword",
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
                        text: xhr.responseText || 'Đổi mật khẩu thất bại!'
                    });
                }
            });
        }


    </script>



</body>

</html>
