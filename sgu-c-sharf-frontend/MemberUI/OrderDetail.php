<html lang="vi">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <link rel="stylesheet" href="./login.css" />
    <link rel="stylesheet" href="MyOrderInDetail.css" />
    <link rel="stylesheet" href="CreateOrder.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../HelperUI/formatOutput.js"></script>
    <title>Chi tiết phiếu mượn</title>
    <style>
        .home-button {
            margin-top: 10px;
            font-size: 16px;
            padding: 8px 26px;
            transition: background-color 0.3s;
        }

        .home-button:hover {
            background-color: #0056b3;
        }
    </style>
</head>

<body>
    <?php require_once "./Header.php" ?>

    <section>
        <div class="center-text" style="margin-top: 20px;">
            <div class="title_section">
                <div class="bar"></div>
                <h2 class="center-text-share">Chi tiết phiếu mượn</h2>
            </div>
        </div>
    </section>

    <section style="padding: 0 5%;">
        <div id="chiTietTrangThaiContent">
            <div id="circle-container1" class="circle-container">
                <div id="ele1" class="chiTietTrangThaiElement">
                    <i id="icon1" class="fa-solid fa-clipboard-list icon"></i>
                    <p class="trangThai">Chờ duyệt</p>
                    <p id="thoiGian1" class="thoiGian"></p>
                </div>
            </div>
            <div id="line1" class="line">_____________________</div>
            <div id="circle-container2" class="circle-container">
                <div id="ele2" class="chiTietTrangThaiElement">
                    <i id="icon2" class="fa-solid fa-check-circle icon"></i>
                    <p class="trangThai">Đã duyệt</p>
                    <p id="thoiGian2" class="thoiGian"></p>
                </div>
            </div>
            <div id="line2" class="line">_____________________</div>
            <div id="circle-container3" class="circle-container">
                <div id="ele3" class="chiTietTrangThaiElement">
                    <i id="icon3" class="fa-solid fa-tools icon"></i>
                    <p class="trangThai">Đang mượn</p>
                    <p id="thoiGian3" class="thoiGian"></p>
                </div>
            </div>
            <div id="line3" class="line">_____________________</div>
            <div id="circle-container4" class="circle-container">
                <div id="ele4" class="chiTietTrangThaiElement">
                    <i id="icon4" class="fa-solid fa-undo icon"></i>
                    <p class="trangThai">Đã trả</p>
                    <p id="thoiGian4" class="thoiGian"></p>
                </div>
            </div>
            <div id="line4" class="line">_____________________</div>
            <div id="circle-container5" class="circle-container">
                <div id="ele5" class="chiTietTrangThaiElement">
                    <i id="icon5" class="fa-solid fa-ban icon"></i>
                    <p class="trangThai">Hủy</p>
                    <p id="thoiGian5" class="thoiGian"></p>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="layout__wrapper">
            <div class="checkout__wrapper containerPage" style="margin-top: 30px;">
                <div class="payment_info__wrapper">
                    <div class="payment_info">
                        <div id='checkout_form'>
                            <div class='payment__wrapper'>
                                <label>Các thiết bị mượn</label>
                                <div id="device-list"></div>
                            </div>
                            <p class='hotline'>
                                * Để được hỗ trợ trực tiếp và nhanh nhất, vui lòng liên hệ quản lý thiết bị qua số điện thoại: 0123 456 789
                            </p>
                            <div style="text-align: left; margin-left: 87%; margin-top: 50px;">
                                <button class="btn btn-primary home-button" onclick="window.location.href='MyOrder.php'">
                                    Quay Lại
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="order_info__wrapper" style="height: 500px;">
                    <div class="order_info" style="margin-top: 30px; padding: 0 20px;">
                        <p class="title" style="text-align: center;">Thông tin phiếu mượn</p>
                        <div class="wrap"></div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <?php require_once "./Footer.php" ?>

    <script>
        // Hàm định dạng ngày giờ
        function formatDateTime(dateString) {
            const date = new Date(dateString);
            return date.toLocaleString('vi-VN', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit'
            });
        }

        // Hàm chuyển đổi trạng thái từ số sang chuỗi
        function convertTrangThai(code) {
            switch (code) {
                case 0:
                    return "ChoDuyet"; // Đang chờ duyệt
                case 1:
                    return "DaDuyet"; // Đang chờ lấy thiết bị
                case 2:
                    return "DangMuon"; // Đang mượn
                case 3:
                    return "DaTra"; // Đã hoàn tất
                case 4:
                    return "Huy"; // Hủy
                default:
                    return "KhongXacDinh";
            }
        }

        // Hàm cập nhật màu sắc và thời gian cho trạng thái
        function setColorAndTime(trangThaiValue, thoiGianValue) {
            console.log("setColorAndTime called with:", trangThaiValue);
            // let trangThaiValue = "DaTra"

            const $line1 = $('#line1');
            const $line2 = $('#line2');
            const $line3 = $('#line3');
            const $line4 = $('#line4');

            const $thoiGian1 = $('#thoiGian1');
            const $thoiGian2 = $('#thoiGian2');
            const $thoiGian3 = $('#thoiGian3');
            const $thoiGian4 = $('#thoiGian4');
            const $thoiGian5 = $('#thoiGian5');

            const $icon1 = $('#icon1');
            const $icon2 = $('#icon2');
            const $icon3 = $('#icon3');
            const $icon4 = $('#icon4');
            const $icon5 = $('#icon5');

            const $circleContainer1 = $('#circle-container1');
            const $circleContainer2 = $('#circle-container2');
            const $circleContainer3 = $('#circle-container3');
            const $circleContainer4 = $('#circle-container4');
            const $circleContainer5 = $('#circle-container5');

            // Reset tất cả các màu về trạng thái mặc định trước khi áp dụng màu mới
            $icon1.css("color", "gray");
            $icon2.css("color", "gray");
            $icon3.css("color", "gray");
            $icon4.css("color", "gray");
            $icon5.css("color", "gray");

            $line1.css("color", "gray");
            $line2.css("color", "gray");
            $line3.css("color", "gray");
            $line4.css("color", "gray");

            $circleContainer1.css("border-color", "gray");
            $circleContainer2.css("border-color", "gray");
            $circleContainer3.css("border-color", "gray");
            $circleContainer4.css("border-color", "gray");
            $circleContainer5.css("border-color", "gray");

            $thoiGian1.html("");
            $thoiGian2.html("");
            $thoiGian3.html("");
            $thoiGian4.html("");
            $thoiGian5.html("");

            // Áp dụng màu sắc dựa trên trạng thái hiện tại
            switch (trangThaiValue) {
                case 'ChoDuyet':
                    $icon1.css("color", "green");
                    $circleContainer1.css("border-color", "green");
                    $thoiGian1.html(formatDateTime(thoiGianValue));
                    break;
                case 'DaDuyet':
                    $icon1.css("color", "green");
                    $circleContainer1.css("border-color", "green");
                    $thoiGian1.html(formatDateTime(thoiGianValue));

                    $icon2.css("color", "green");
                    $line1.css("color", "green");
                    $circleContainer2.css("border-color", "green");
                    $thoiGian2.html(formatDateTime(thoiGianValue));
                    break;
                case 'DangMuon':
                    $icon1.css("color", "green");
                    $circleContainer1.css("border-color", "green");
                    $thoiGian1.html(formatDateTime(thoiGianValue));

                    $icon2.css("color", "green");
                    $line1.css("color", "green");
                    $circleContainer2.css("border-color", "green");
                    $thoiGian2.html(formatDateTime(thoiGianValue));

                    $icon3.css("color", "green");
                    $line2.css("color", "green");
                    $circleContainer3.css("border-color", "green");
                    $thoiGian3.html(formatDateTime(thoiGianValue));
                    break;
                case 'DaTra':
                    $icon1.css("color", "green");
                    $circleContainer1.css("border-color", "green");
                    // $thoiGian1.html(formatDateTime(thoiGianValue));

                    $icon2.css("color", "green");
                    $line1.css("color", "green");
                    $circleContainer2.css("border-color", "green");
                    // $thoiGian2.html(formatDateTime(thoiGianValue));

                    $icon3.css("color", "green");
                    $line2.css("color", "green");
                    $circleContainer3.css("border-color", "green");
                    // $thoiGian3.html(formatDateTime(thoiGianValue));

                    $icon4.css("color", "green");
                    $line3.css("color", "green");
                    $circleContainer4.css("border-color", "green");
                    // $thoiGian4.html(formatDateTime(thoiGianValue));
                    break;
                case 'Huy':
                    $icon1.css("color", "rgb(146, 26, 26)");
                    $circleContainer1.css("border-color", "rgb(146, 26, 26)");
                    $thoiGian1.html(formatDateTime(thoiGianValue));

                    $icon2.css("color", "rgb(146, 26, 26)");
                    $line1.css("color", "rgb(146, 26, 26)");
                    $circleContainer2.css("border-color", "rgb(146, 26, 26)");

                    $icon3.css("color", "rgb(146, 26, 26)");
                    $line2.css("color", "rgb(146, 26, 26)");
                    $circleContainer3.css("border-color", "rgb(146, 26, 26)");

                    $icon4.css("color", "rgb(146, 26, 26)");
                    $line3.css("color", "rgb(146, 26, 26)");
                    $circleContainer4.css("border-color", "rgb(146, 26, 26)");

                    $icon5.css("color", "rgb(146, 26, 26)");
                    $line4.css("color", "rgb(146, 26, 26)");
                    $circleContainer5.css("border-color", "rgb(146, 26, 26)");
                    $thoiGian5.html(formatDateTime(thoiGianValue));
                    break;
                default:
                    console.log("Unknown status:", trangThaiValue);
                    break;
            }
        }
        // Dữ liệu tĩnh cho các phần không có trong API
        const staticData = {
            ghiChu: "Mượn thiết bị cho dự án thực tập",
            thoiGianTraDuKien: "2025-05-10T17:00:00",
            chiTietThietBi: [{
                    deviceId: "TB001",
                    deviceName: "Máy chiếu",
                    quantity: 1,
                    image: "may_chieu.jpg"
                },
                {
                    deviceId: "TB002",
                    deviceName: "Loa Bluetooth",
                    quantity: 2,
                    image: "loa_bluetooth.jpg"
                }
            ]
        };

        // Hàm hiển thị dữ liệu phiếu mượn
        function loadPhieuMuonData(maPhieuMuon) {
            Swal.fire({
                title: 'Đang tải chi tiết phiếu mượn...',
                text: 'Vui lòng chờ giây lát.',
                allowOutsideClick: false,
                didOpen: () => {
                    Swal.showLoading();
                }
            });

            $.ajax({
                url: `http://localhost:5244/api/phieu-muon/${maPhieuMuon}`,
                method: 'GET',
                dataType: 'json',
                success: function(response) {
                    Swal.close();
                    if (response && response.status === 200) {
                        const phieuMuonData = response.data;

                        const phieuMuon = {
                            id: phieuMuonData.id,
                            thoiGianTao: phieuMuonData.ngayTao,
                            nguoiMuon: phieuMuonData.tenThanhVien,
                            trangThai: convertTrangThai(phieuMuonData.trangThai),
                            ghiChu: staticData.ghiChu,
                            thoiGianTraDuKien: staticData.thoiGianTraDuKien,
                            chiTietThietBi: staticData.chiTietThietBi
                        };
                        console.log(phieuMuon);
                        let deviceListHtml = '';
                        let html = '';

                        // Xử lý danh sách thiết bị mượn
                        phieuMuon.chiTietThietBi.forEach(function(device) {
                            deviceListHtml += `
                                <div class='radio__wrapper'>
                                    <div>
                                        <div class='cartItem' id='${device.deviceId}'>
                                            <a href='#' class='img'><img class='img' src='https://res.cloudinary.com/djhoea2bo/image/upload/v1711511636/${device.image}' /></a>
                                            <div class='inforCart'>
                                                <div class='nameAndPrice'>
                                                    <a href='#' class='nameCart'>${device.deviceName}</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            `;
                        });

                        // Thông tin phiếu mượn
                        html = `
                            <div class="container mt-4">
                                <div class="info__wrapper order_info2">
                                    <p><span class="span1">Mã phiếu mượn:</span><span class="span2" id="id">${phieuMuon.id}</span></p>
                                    <p><span class="span1">Thời gian tạo:</span><span class="span2" id="thoiGianTao">${formatDateTime(phieuMuon.thoiGianTao)}</span></p>
                                    <p><span class="span1">Người mượn:</span><span class="span2" id="nguoiMuon">${phieuMuon.nguoiMuon}</span></p>
                                    <p><span class="span1">Thời gian trả dự kiến:</span><span class="span2" id="thoiGianTraDuKien">${formatDateTime(phieuMuon.thoiGianTraDuKien)}</span></p>
                                </div>
                            </div>
                        `;

                        // Chèn nội dung vào HTML
                        $('#device-list').html(deviceListHtml);
                        $('.wrap').html(html);

                        // Hiển thị trạng thái hiện tại
                        setColorAndTime(phieuMuon.trangThai, phieuMuon.thoiGianTao);
                    } else {
                        Swal.fire('Lỗi', 'Không tìm thấy phiếu mượn.', 'error');
                    }
                },
                error: function() {
                    Swal.close();
                    Swal.fire('Lỗi', 'Không thể tải dữ liệu từ server.', 'error');
                    $('#device-list').html("<h1> Lỗi khi tải dữ liệu từ server </h1>");
                }
            });
        }

        $(document).ready(function() {
            const urlParams = new URLSearchParams(window.location.search);
            const maPhieuMuon = urlParams.get('id');

            if (maPhieuMuon) {
                loadPhieuMuonData(maPhieuMuon);
            } else {
                Swal.fire('Lỗi', 'Không tìm thấy mã phiếu mượn trong URL.', 'error');
            }
        });
    </script>
</body>

</html>