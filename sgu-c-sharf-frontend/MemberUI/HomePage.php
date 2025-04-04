<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <!-- <link rel="stylesheet" href="./login.css" /> -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../HelperUI/formatOutput.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha384-k6RqeWeci5ZR/Lv4MR0sA0FfDOMlI4F/x3Rgx31ZobM4uZ5dI6cuJg6RZ/aXjmD" crossorigin="anonymous">

    <title>Kinh doanh rượu</title>
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
        /* Nghiêng tem nhãn */
        z-index: 10;
        border-radius: 3px;
    }
</style>

<body>

    <?php require_once "./Header.php"; ?>

    <!-- <section id="poster" style="width: 100%; height: auto; padding: 0 5%;">
        <img src="img/poster.jpg" style="max-width: 100%;">
    </section>


    <section>
        <div class="center-text">
            <div class="title_section">
                <div class="bar"></div>
                <h2 class="center-text-share">SẢN PHẨM NỔI BẬT</h2>
            </div>
        </div>
    </section> -->


    <!-- <section id="product">
        <div class="container">
            <div class="row products">
                Hiển thị vài sản phẩm nổi bật
            </div>
        </div>
    </section> -->
    <!-- <div class="text-center my-4">
        <button id="btn-load-more" class="btn btn-primary">Xem thêm các sản phẩm</button>
    </div> -->

    <!-- Dịch vụ -->
    <section class="Home-titleSection">
        <div class="Home-lineSection-2"></div>
        <h2 class="Home-txtTitle">DỊCH VỤ</h2>
        <div class="Home-lineSection-2"></div>
    </section>

    <section class="Home-service container py-5" style="height: fit-content;">
        <div class="row" style="width:100%;height:fit-content;">
            <!-- Service 1 -->
            <div class="Home-service-child col-12 col-md-6 text-center mb-4">
                <div>
                    <a href="./ReservationForm.php"><img class="Home-service-img img-fluid" src="img/service-1.jpg" alt="" /></a>
                </div>
                <h2 class="home-heading-service">Đặt chỗ</h2>
            </div>

            <!-- Service 2 -->
            <div class="Home-service-child col-12 col-md-6 text-center mb-4">
                <div>
                    <a href="./Sanction.php"><img class="Home-service-img img-fluid" src="img/service2.jpg" alt="" /></a>
                    
                </div>
                <h2 class="home-heading-service">Thông báo phạt</h2>
            </div>

            <!-- Service 3 -->
            <!-- <div class="Home-service-child col-12 col-md-4 text-center mb-4">
                <div>
                    <img class="Home-service-img img-fluid" src="img/service3.jpg" alt="" />
                </div>
                <h2 class="home-heading-service">Xem phiếu mượn</h2>
            </div> -->
        </div>
    </section>


    <?php require_once "./Footer.php" ?>
</body>

<script src="application-properties.js"></script>
<script>
    
</script>

</html>