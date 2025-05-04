<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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
    <title>Thư quán</title>
</head>

<style>
    .sale-label {
        position: absolute;
        top: 10px;
        left: 10px;
        background-color: rgb(146, 26, 26);
        color: white;
        padding: 5px 10px;
        font-weight: bold;
        font-size: 14px;
        z-index: 10;
        border-radius: 3px;
    }
</style>

<body>
    <?php require_once "./Header.php"; ?>


        <!-- Giới thiệu -->
        <section class="container text-center py-5">
        <h2 class="mb-4" style="color: #821919;">CHÀO MỪNG BẠN ĐẾN VỚI THƯ QUÁN</h2>
        <p class="lead">Nơi bạn có thể mượn thiết bị, đặt chỗ, và theo dõi lịch sử sử dụng một cách dễ dàng. Chúng tôi luôn hỗ trợ bạn tận tâm và nhanh chóng.</p>
    </section>

<!-- Section giới thiệu chính với background màu đỏ -->
<section class="container-fluid d-flex align-items-center justify-content-center" style="min-height: 90vh; background-color: rgb(146, 26, 26); color: white;">
    <div class="container text-center">
        <div class="row">
            <!-- Trở thành thành viên -->
            <div class="col-md-6 mb-4 mb-md-0 d-flex flex-column justify-content-center text-md-start" style="background-color: rgba(255, 255, 255, 0.1); padding: 30px; border-radius: 10px;">
                <h2 class="fw-bold display-4">Trở thành thành viên Thư Quán</h2>
                <p class="lead">
                    Khi bạn trở thành thành viên của Thư Quán, bạn sẽ được hưởng các quyền lợi đặc biệt, bao gồm:
                </p>
                <ul class="list-unstyled">
                    <li><i class="fas fa-check-circle text-success"></i> Đặt chỗ ngồi ưu tiên, đảm bảo không gian yên tĩnh</li>
                    <li><i class="fas fa-check-circle text-success"></i> Mượn thiết bị dễ dàng và nhanh chóng</li>
                    <li><i class="fas fa-check-circle text-success"></i> Nhận thông báo về các sự kiện và ưu đãi đặc biệt</li>
                </ul>
                <a href="./Login.php" class="btn btn-light mt-3 w-50">Đăng ký / Đăng nhập</a>
            </div>

            <!-- Đặt mượn thiết bị -->
            <div class="col-md-6 d-flex flex-column justify-content-center text-md-start" style="background-color: rgba(255, 255, 255, 0.1); padding: 30px; border-radius: 10px;">
                <h2 class="fw-bold display-4">Đặt mượn thiết bị nhanh chóng</h2>
                <p class="lead">
                    Mượn thiết bị tại Thư Quán chưa bao giờ dễ dàng đến vậy! Bạn có thể mượn các thiết bị hiện đại và tiện ích như:
                </p>
                <ul class="list-unstyled">
                    <li><i class="fas fa-laptop text-primary"></i> Máy tính laptop</li>
                    <li><i class="fas fa-headphones text-info"></i> Tai nghe, thiết bị âm thanh</li>
                    <li><i class="fas fa-projector text-warning"></i> Máy chiếu và các thiết bị trình chiếu</li>
                </ul>
                <a href="./BorrowDevices.php" class="btn btn-light mt-3 w-50">Xem thiết bị</a>
            </div>
        </div>
    </div>
</section>





    <section class="Home-titleSection text-center py-4">
    <div class="Home-lineSection-2 mb-2"></div>
    <h2 class="Home-txtTitle">DỊCH VỤ</h2>
    <div class="Home-lineSection-2 mt-2"></div>
</section>

<section class="Home-service container py-5">
    <div class="row text-center">
        <!-- Đặt chỗ -->
        <div class="col-12 col-md-3 mb-4">
            <a href="./ReservationForm.php" class="text-decoration-none text-dark">
                <div class="p-4 border rounded shadow-sm h-100">
                    <i class="fas fa-chair fa-3x mb-3 text-primary"></i>
                    <h5 class="fw-bold">Đặt chỗ</h5>
                    <p class="small">Đặt trước các thiết bị máy tính, tai nghe, thiết bị trình chiếu.</p>
                </div>
            </a>
        </div>

        <!-- Mượn thiết bị -->
        <div class="col-12 col-md-3 mb-4">
            <a href="./BorrowDevices.php" class="text-decoration-none text-dark">
                <div class="p-4 border rounded shadow-sm h-100">
                    <i class="fas fa-laptop fa-3x mb-3 text-success"></i>
                    <h5 class="fw-bold">Danh sách thiết bị</h5>
                    <p class="small">Máy tính, tai nghe, thiết bị trình chiếu sẵn sàng cho bạn mượn.</p>
                </div>
            </a>
        </div>

        <!-- Lịch sử -->
        <div class="col-12 col-md-3 mb-4">
            <a href="./History.php" class="text-decoration-none text-dark">
                <div class="p-4 border rounded shadow-sm h-100">
                    <i class="fas fa-history fa-3x mb-3 text-warning"></i>
                    <h5 class="fw-bold">Lịch sử</h5>
                    <p class="small">Theo dõi hoạt động đặt chỗ, mượn thiết bị và check-in của bạn.</p>
                </div>
            </a>
        </div>

        <!-- Xử phạt -->
        <div class="col-12 col-md-3 mb-4">
            <a href="./Sanction.php" class="text-decoration-none text-dark">
                <div class="p-4 border rounded shadow-sm h-100">
                    <i class="fas fa-gavel fa-3x mb-3 text-danger"></i>
                    <h5 class="fw-bold">Xử phạt</h5>
                    <p class="small">Tra cứu các vi phạm và hình thức xử lý áp dụng với bạn.</p>
                </div>
            </a>
        </div>
    </div>
</section>


    <?php require_once "./Footer.php"; ?>
</body>

<!-- <script src="application-properties.js"></script> -->
<script>
    
</script>
</html>
