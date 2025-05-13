<!DOCTYPE html>
<html lang="vi">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quên Mật Khẩu</title>
    <!-- Thêm jQuery từ CDN -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <!-- Thêm SweetAlert2 từ CDN -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <style>
        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
        }

        body {
            background-color: #f4f4f9;
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .container {
            width: 100%;
            max-width: 1000px;
            margin: 0 auto;
            padding: 20px;
        }

        .card {
            background-color: white;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            position: relative;
        }

        .card-header {
            padding: 20px;
            text-align: center;
        }

        .card-title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 8px;
        }

        .card-description {
            color: #666;
            font-size: 14px;
        }

        .card-content {
            padding: 20px;
        }

        .card-footer {
            padding: 20px;
            text-align: center;
        }

        .card-footer a {
            color: #007bff;
            text-decoration: none;
        }

        .card-footer a:hover {
            text-decoration: underline;
        }

        .form-group {
            margin-bottom: 20px;
            position: relative;
        }

        label {
            display: block;
            font-size: 14px;
            font-weight: 500;
            margin-bottom: 8px;
        }

        input[type="email"],
        input[type="password"],
        input[type="text"] {
            width: 100%;
            padding: 10px 40px 10px 40px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
        }

        input:focus {
            outline: none;
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.2);
        }

        .input-icon {
            position: absolute;
            left: 10px;
            top: 50%;
            transform: translateY(-50%);
            color: #666;
            width: 16px;
            height: 16px;
        }

        .toggle-password {
            position: absolute;
            right: 10px;
            top: 50%;
            transform: translateY(-50%);
            background: none;
            border: none;
            cursor: pointer;
            padding: 5px;
        }

        .toggle-password svg {
            width: 16px;
            height: 16px;
        }

        .otp-container {
            display: flex;
            justify-content: center;
            gap: 8px;
            margin-bottom: 20px;
        }

        .otp-input {
            width: 40px;
            height: 40px;
            text-align: center;
            font-size: 16px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .otp-input:focus {
            outline: none;
            border-color: #007bff;
        }

        .error-message {
            color: #e53e3e;
            font-size: 12px;
            margin-top: 4px;
            display: none;
        }

        .button {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 8px;
        }

        .button:disabled {
            background-color: #cccccc;
            cursor: not-allowed;
        }

        .button:hover:not(:disabled) {
            background-color: #0056b3;
        }

        .loader {
            width: 16px;
            height: 16px;
            border: 2px solid white;
            border-top: 2px solid transparent;
            border-radius: 50%;
            animation: spin 1s linear infinite;
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        .text-center {
            text-align: center;
        }

        .text-muted {
            color: #666;
            font-size: 14px;
        }

        .text-primary {
            color: #007bff;
        }

        .back-button {
            position: absolute;
            top: 16px;
            left: 16px;
            background: none;
            border: none;
            color: #666;
            display: flex;
            align-items: center;
            gap: 8px;
            cursor: pointer;
        }

        .back-button:hover {
            color: #007bff;
        }

        .icon {
            width: 48px;
            height: 48px;
            color: #007bff;
            margin: 0 auto 16px;
        }

        .resend-otp {
            margin-top: 16px;
            font-size: 14px;
            color: #666;
        }

        .resend-otp a {
            color: #007bff;
            text-decoration: none;
        }

        .resend-otp a:hover {
            text-decoration: underline;
        }

        .toast {
            position: fixed;
            top: 20px;
            right: 20px;
            background-color: #333;
            color: white;
            padding: 16px;
            border-radius: 4px;
            display: none;
            z-index: 1000;
            max-width: 300px;
        }

        .toast.show {
            display: block;
        }

        .toast-title {
            font-weight: bold;
            margin-bottom: 4px;
        }
    </style>
</head>

<body>
    <div class="container">
        <div class="card">
            <div class="card-header">
                <button id="back-button" class="back-button" style="display: none;">
                    <svg class="back-icon" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <path d="M15 18l-6-6 6-6" />
                    </svg>
                    Quay lại
                </button>
                <h2 id="card-title" class="card-title">Quên mật khẩu</h2>
                <p id="card-description" class="card-description">Nhập email của bạn để nhận mã OTP</p>
            </div>
            <div class="card-content">
                <!-- Email Form -->
                <form id="email-form" onsubmit="handleEmailSubmit(event)" style="display: block;">
                    <div class="form-group">
                        <label for="email-input">Email</label>
                        <div style="position: relative;">
                            <svg class="input-icon" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M22 2H2v20h20V2zM2 6l10 7 10-7" />
                            </svg>
                            <input
                                type="email"
                                id="email-input"
                                placeholder="name@example.com"
                                required />
                            <div id="email-error" class="error-message"></div>
                        </div>
                    </div>
                    <button type="submit" id="email-submit" class="button">
                        Nhận mã OTP
                    </button>
                </form>
                <form id="otp-form" onsubmit="handleOtpSubmit(event)" style="display: none;">
                    <div class="text-center">
                        <svg class="icon" width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M15 3h6v6M9 21H3v-6M21 3l-6 6M3 21l6-6" />
                        </svg>
                        <p class="text-muted mb-4">
                            Mã OTP đã được gửi đến <span id="otp-email" class="font-medium"></span>
                        </p>
                    </div>
                    <div class="form-group">
                        <div class="otp-container">
                            <input type="text" class="otp-input" maxlength="1" oninput="moveToNext(this, 1)" />
                            <input type="text" class="otp-input" maxlength="1" oninput="moveToNext(this, 2)" />
                            <input type="text" class="otp-input" maxlength="1" oninput="moveToNext(this, 3)" />
                            <input type="text" class="otp-input" maxlength="1" oninput="moveToNext(this, 4)" />
                            <input type="text" class="otp-input" maxlength="1" oninput="moveToNext(this, 5)" />
                            <input type="text" class="otp-input" maxlength="1" oninput="moveToNext(this, 6)" />
                        </div>
                        <div id="otp-error" class="error-message"></div>
                    </div>
                    <div id="resend-otp" class="resend-otp text-center">
                        <a href="#" onclick="handleResendOtp(event)">Gửi lại mã OTP</a>
                    </div>
                    <button type="submit" id="otp-submit" class="button">
                        Xác nhận
                    </button>
                </form>

                <!-- Reset Password Form -->
                <form id="reset-form" onsubmit="handleResetSubmit(event)" style="display: none;">
                    <div class="form-group">
                        <label for="password-input">Mật khẩu mới</label>
                        <div style="position: relative;">
                            <svg class="input-icon" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M18 10h-1V7a5 5 0 0 0-10 0v3H6a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2v-8a2 2 0 0 0-2-2z" />
                            </svg>
                            <input
                                type="password"
                                id="password-input"
                                placeholder="••••••••"
                                required />
                            <button type="button" id="toggle-password" class="toggle-password">
                                <svg id="password-eye" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" />
                                    <circle cx="12" cy="12" r="3" />
                                </svg>
                            </button>
                            <div id="password-error" class="error-message"></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="confirm-password-input">Xác nhận mật khẩu</label>
                        <div style="position: relative;">
                            <svg class="input-icon" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M18 10h-1V7a5 5 0 0 0-10 0v3H6a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2v-8a2 2 0 0 0-2-2z" />
                            </svg>
                            <input
                                type="password"
                                id="confirm-password-input"
                                placeholder="••••••••"
                                required />
                            <button type="button" id="toggle-confirm-password" class="toggle-password">
                                <svg id="confirm-password-eye" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" />
                                    <circle cx="12" cy="12" r="3" />
                                </svg>
                            </button>
                            <div id="confirm-password-error" class="error-message"></div>
                        </div>
                    </div>
                    <button type="submit" id="reset-submit" class="button">
                        Đặt lại mật khẩu
                    </button>
                </form>
            </div>
            <div class="card-footer">
                <div class="text-center text-muted">
                    Nhớ lại mật khẩu?
                    <a href="./LoginUI.php"> Đăng nhập</a>
                </div>
            </div>
        </div>
    </div>

    <div id="toast" class="toast">
        <div id="toast-title" class="toast-title"></div>
        <div id="toast-description"></div>
    </div>

    <script>
        let step = "email";
        let email = "";
        let id;

        const emailForm = document.getElementById("email-form");
        const otpForm = document.getElementById("otp-form");
        const resetForm = document.getElementById("reset-form");
        const cardTitle = document.getElementById("card-title");
        const cardDescription = document.getElementById("card-description");
        const backButton = document.getElementById("back-button");
        const otpEmail = document.getElementById("otp-email");

        const emailInput = document.getElementById("email-input");
        const emailError = document.getElementById("email-error");
        const emailSubmit = document.getElementById("email-submit");

        const otpInputs = document.querySelectorAll(".otp-input");
        const otpError = document.getElementById("otp-error");
        const otpSubmit = document.getElementById("otp-submit");
        const resendOtpEl = document.getElementById("resend-otp");

        const passwordInput = document.getElementById("password-input");
        const confirmPasswordInput = document.getElementById("confirm-password-input");
        const passwordError = document.getElementById("password-error");
        const confirmPasswordError = document.getElementById("confirm-password-error");
        const resetSubmit = document.getElementById("reset-submit");

        // Toast notification
        function showToast(title, description) {
            const toast = document.getElementById("toast");
            const toastTitle = document.getElementById("toast-title");
            const toastDescription = document.getElementById("toast-description");
            toastTitle.textContent = title;
            toastDescription.textContent = description;
            toast.classList.add("show");
            setTimeout(() => {
                toast.classList.remove("show");
            }, 3000);
        }

        // Validate email
        function validateEmail(email) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(email);
        }

        // Validate password
        function validatePassword(password, confirmPassword) {
            if (password.length < 8) {
                return "Mật khẩu phải có ít nhất 8 ký tự";
            }
            if (password !== confirmPassword) {
                return "Mật khẩu xác nhận không khớp";
            }
            return "";
        }

        // AJAX call to send OTP
        function sendOtpRequest(email, callback, errorCallback) {
            const formData = new FormData();
            formData.append("LoaiOTP", "RESET_PASSWORD");
            formData.append("Email", email);

            $.ajax({
                url: "http://localhost:5244/api/otp/send",
                type: "POST",
                data: formData,
                processData: false,
                contentType: false,
                success: function(data) {
                    id = data.token.idThanhVien;
                    callback(data);
                },
                error: function(xhr) {
                    let errorMessage = "Có lỗi xảy ra khi gửi yêu cầu.";
                    if (xhr.responseJSON && xhr.responseJSON.message) {
                        errorMessage = xhr.responseJSON.message;
                    }
                    errorCallback(errorMessage);
                }
            });
        }

        // AJAX call to validate OTP
        function validateOtpRequest(token, callback, errorCallback) {
            const formData = new FormData();
            formData.append("LoaiOTP", "RESET_PASSWORD");
            formData.append("token", token);

            $.ajax({
                url: "http://localhost:5244/api/otp/validate",
                type: "POST",
                data: formData,
                processData: false,
                contentType: false,
                success: function(data) {
                    callback(data);
                },
                error: function(xhr) {
                    let errorMessage = "Mã OTP không hợp lệ hoặc đã hết hạn.";
                    if (xhr.responseJSON && xhr.responseJSON.message) {
                        errorMessage = xhr.responseJSON.message;
                    }
                    errorCallback(errorMessage);
                }
            });
        }

        // Update step
        function updateStep(newStep) {
            step = newStep;
            emailForm.style.display = step === "email" ? "block" : "none";
            otpForm.style.display = step === "otp" ? "block" : "none";
            resetForm.style.display = step === "reset" ? "block" : "none";

            backButton.style.display = step === "email" ? "none" : "block";
            cardTitle.textContent = step === "email" ? "Quên mật khẩu" :
                step === "otp" ? "Xác minh OTP" : "Đặt lại mật khẩu";
            cardDescription.textContent = step === "email" ? "Nhập email của bạn để nhận mã OTP" :
                step === "otp" ? "Nhập mã OTP đã được gửi đến email của bạn" :
                "Tạo mật khẩu mới cho tài khoản của bạn";
        }

        // Handle email submit
        function handleEmailSubmit(event) {
            event.preventDefault();
            emailError.style.display = "none";
            emailSubmit.disabled = true;
            emailSubmit.innerHTML = '<div class="loader"></div> Đang xử lý';

            const emailValue = emailInput.value.trim();
            if (!validateEmail(emailValue)) {
                emailError.textContent = "Email không hợp lệ";
                emailError.style.display = "block";
                emailSubmit.disabled = false;
                emailSubmit.innerHTML = "Nhận mã OTP";
                return;
            }

            sendOtpRequest(
                emailValue,
                function(data) {
                    email = emailValue;
                    otpEmail.textContent = email;
                    showToast("Mã OTP đã được gửi", `Mã OTP đã được gửi đến địa chỉ email ${email}. Vui lòng kiểm tra hộp thư của bạn.`);
                    updateStep("otp");
                    emailSubmit.disabled = false;
                    emailSubmit.innerHTML = "Nhận mã OTP";
                },
                function(errorMessage) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: errorMessage + ' Vui lòng nhập lại email.',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        emailInput.focus();
                        emailInput.value = '';
                        emailSubmit.disabled = false;
                        emailSubmit.innerHTML = "Nhận mã OTP";
                    });
                }
            );
        }

        // Move to next OTP input
        function moveToNext(input, index) {
            if (input.value.length === 1 && index < 6) {
                otpInputs[index].focus();
            }
        }

        // Handle OTP submit
        function handleOtpSubmit(event) {
            event.preventDefault();
            otpError.style.display = "none";
            otpSubmit.disabled = true;
            otpSubmit.innerHTML = '<div class="loader"></div> Đang xử lý';

            const otp = Array.from(otpInputs).map(input => input.value).join("");
            if (otp.length !== 6) {
                otpError.textContent = "Mã OTP phải có 6 chữ số";
                otpError.style.display = "block";
                otpSubmit.disabled = false;
                otpSubmit.innerHTML = "Xác nhận";
                return;
            }

            validateOtpRequest(
                otp,
                function(data) {
                    showToast("Xác minh thành công", "Mã OTP đã được xác nhận. Vui lòng đặt lại mật khẩu mới.");
                    updateStep("reset");
                    otpSubmit.disabled = false;
                    otpSubmit.innerHTML = "Xác nhận";
                    // Xóa các ô OTP sau khi xác minh thành công
                    otpInputs.forEach(input => input.value = '');
                },
                function(errorMessage) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: errorMessage,
                        confirmButtonText: 'OK'
                    }).then(() => {
                        otpSubmit.disabled = false;
                        otpSubmit.innerHTML = "Xác nhận";
                    });
                }
            );
        }

        // Handle resend OTP
        function handleResendOtp(event) {
            event.preventDefault();
            console.log("Resending OTP to:", email);
            sendOtpRequest(
                email,
                function(data) {
                    showToast("Mã OTP đã được gửi lại", `Mã OTP mới đã được gửi đến ${email}.`);
                },
                function(errorMessage) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: errorMessage + ' Vui lòng nhập lại email.',
                        confirmButtonText: 'OK'
                    }).then(() => {
                        updateStep("email");
                        emailInput.focus();
                        emailInput.value = '';
                    });
                }
            );
        }

        // Toggle password visibility
        document.getElementById("toggle-password").addEventListener("click", () => {
            const isVisible = passwordInput.type === "text";
            passwordInput.type = isVisible ? "password" : "text";
            document.getElementById("password-eye").innerHTML = isVisible ?
                `<path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/>` :
                `<path d="M2 2l20 20M5 5a10 10 0 0 0-3 7 10 10 0 0 0 20 0 10 10 0 0 0-3-7m-7 7a3 3 0 0 1-6 0"/>`;
        });

        document.getElementById("toggle-confirm-password").addEventListener("click", () => {
            const isVisible = confirmPasswordInput.type === "text";
            confirmPasswordInput.type = isVisible ? "password" : "text";
            document.getElementById("confirm-password-eye").innerHTML = isVisible ?
                `<path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/>` :
                `<path d="M2 2l20 20M5 5a10 10 0 0 0-3 7 10 10 0 0 0 20 0 10 10 0 0 0-3-7m-7 7a3 3 0 0 1-6 0"/>`;
        });

        // Handle reset password submit
        function handleResetSubmit(event) {
            event.preventDefault();
            passwordError.style.display = "none";
            confirmPasswordError.style.display = "none";
            resetSubmit.disabled = true;
            resetSubmit.innerHTML = '<div class="loader"></div> Đang xử lý';

            const password = passwordInput.value;
            const confirmPassword = confirmPasswordInput.value;
            const error = validatePassword(password, confirmPassword);

            if (error) {
                if (error.includes("ít nhất 8 ký tự")) {
                    passwordError.textContent = error;
                    passwordError.style.display = "block";
                } else {
                    confirmPasswordError.textContent = error;
                    confirmPasswordError.style.display = "block";
                }
                resetSubmit.disabled = false;
                resetSubmit.innerHTML = "Đặt lại mật khẩu";
                return;
            }

            // Tạo FormData để gửi qua form-data
            const formData = new FormData();
            formData.append("Identifier", id); // Sử dụng idThanhVien đã lưu từ bước gửi OTP
            formData.append("MatKhauMoi", password); // Mật khẩu mới

            $.ajax({
                url: "http://localhost:5244/api/thanh-vien/forgot-password",
                type: "POST",
                data: formData,
                processData: false, // Không xử lý dữ liệu (cần cho FormData)
                contentType: false, // Không set content type (cần cho FormData)
                success: function(response) {
                    if (response.status === 200) {
                        showToast("Đặt lại mật khẩu thành công", "Mật khẩu của bạn đã được đặt lại thành công. Vui lòng đăng nhập với mật khẩu mới.");
                        setTimeout(() => {
                            window.location.href = "./LoginUI.php";
                        }, 2000);
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Lỗi',
                            text: response.message || "Đổi mật khẩu thất bại.",
                            confirmButtonText: 'OK'
                        });
                    }
                    resetSubmit.disabled = false;
                    resetSubmit.innerHTML = "Đặt lại mật khẩu";
                },
                error: function(xhr) {
                    let errorMessage = "Có lỗi xảy ra khi đặt lại mật khẩu.";
                    if (xhr.responseJSON && xhr.responseJSON.message) {
                        errorMessage = xhr.responseJSON.message;
                    }
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: errorMessage,
                        confirmButtonText: 'OK'
                    }).then(() => {
                        resetSubmit.disabled = false;
                        resetSubmit.innerHTML = "Đặt lại mật khẩu";
                    });
                }
            });
        }

        // Back button
        backButton.addEventListener("click", () => {
            if (step === "otp") {
                updateStep("email");
            } else if (step === "reset") {
                updateStep("otp");
            }
        });
    </script>
</body>

</html>