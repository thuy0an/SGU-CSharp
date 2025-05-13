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
    <!-- <script src="../HelperUI/formatOutput.js"></script> -->
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

        function resetColorAndTime(){
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

        }
        // Hàm cập nhật màu sắc và thời gian cho trạng thái
        function setColorAndTime(trangThaiValue, thoiGianValue) {
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


            // Áp dụng màu sắc dựa trên trạng thái hiện tại
            switch (trangThaiValue) {
                case 0:
                    $icon1.css("color", "green");
                    $circleContainer1.css("border-color", "green");
                    $thoiGian1.html(formatDateTime(thoiGianValue));
                    break;
                case 1:

                    $icon2.css("color", "green");
                    $line1.css("color", "green");
                    $circleContainer2.css("border-color", "green");
                    $thoiGian2.html(formatDateTime(thoiGianValue));
                    break;
                case 2:
      
                    $icon3.css("color", "green");
                    $line2.css("color", "green");
                    $circleContainer3.css("border-color", "green");
                    $thoiGian3.html(formatDateTime(thoiGianValue));
                    break;
                case 3:

                    $icon4.css("color", "green");
                    $line3.css("color", "green");
                    $circleContainer4.css("border-color", "green");
                    $thoiGian4.html(formatDateTime(thoiGianValue));
                    console.log("Hoàn trả thành công");

                    break;
                case 4:

                    $icon1.css("color", "rgb(146, 26, 26)");
                    $circleContainer1.css("border-color", "rgb(146, 26, 26)");

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
                    break;
            }
        }

        // Hàm lấy thông tin thiết bị từ idDauThietBi
        function getDeviceInfo(idDauThietBi) {
            return $.ajax({
                url: `http://localhost:5244/api/DauThietBi/${idDauThietBi}`,
                method: 'GET',
                dataType: 'json'
            });
        }

        // Hàm lấy hình ảnh từ idThietBi
        function getDeviceImage(idThietBi) {
            return $.ajax({
                url: `http://localhost:5244/api/ThietBi/hinh-anh/${idThietBi}`,
                method: 'GET',
                dataType: 'json'
            });
        }

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
                url: `http://localhost:5244/api/phieu-muon/chi-tiet/${maPhieuMuon}`,
                method: 'GET',
                dataType: 'json',
                success: function(response) {
                    Swal.close();
                    if (response && response.status === 200) {
                        const phieuMuonData = response.data.phieuMuonDetailDTO;
                        const phieuMuon = {
                            id: phieuMuonData.id,
                            thoiGianTao: phieuMuonData.ngayTao,
                            nguoiMuon: phieuMuonData.tenThanhVien,
                            trangThai: convertTrangThai(phieuMuonData.trangThai),
                            ghiChu: phieuMuonData.ghiChu || "Mượn thiết bị cho dự án thực tập",
                            thoiGianTraDuKien: phieuMuonData.thoiGianTra || "2025-05-10T17:00:00"
                        };

                        // Lấy danh sách idDauThietBi từ API phiếu mượn
                        const idDauThietBis = response.data.chiTietPhieuMuonDetailDTOs.map(item => item.idDauThietBi);

                        // Tích lũy dữ liệu thiết bị
                        let devices = [];
                        let promises = [];

                        idDauThietBis.forEach(idDauThietBi => {
                            const promise = getDeviceInfo(idDauThietBi).then(deviceInfo => {
                                const idThietBi = deviceInfo.data.idThietBi;
                                const tenThietBi = deviceInfo.data.tenThietBi;

                                return getDeviceImage(idThietBi).then(imageResponse => {
                                    const hinhAnh = imageResponse.data.anhMinhHoa || `dell-xps.jpg`; // Giá trị mặc định nếu không có hình
                                    devices.push({
                                        maDauThietBi: idDauThietBi,
                                        tenThietBi: tenThietBi,
                                        hinhAnh: hinhAnh
                                    });
                                });
                            });
                            promises.push(promise);
                        });

                        // Chờ tất cả các cuộc gọi API hoàn thành
                        Promise.all(promises).then(() => {
                            let deviceListHtml = '';
                            devices.forEach(device => {
                                deviceListHtml += `
                                    <div class='radio__wrapper'>
                                        <div>
                                            <div class='cartItem' id='device-${device.maDauThietBi}'>
                                                <a href='#' class='img'><img class='img' src='../img/${device.hinhAnh}' /></a>
                                                <div class='inforCart'>
                                                    <div class='nameAndPrice'>
                                                        <a href='#' class='nameCart'>${device.tenThietBi}</a>
                                                        <p class='price'>Mã đầu thiết bị: ${device.maDauThietBi}</p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                `;
                            });

                            let html = `
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


                            fetchTrangThaiPhieuMuon(phieuMuon.id);

                     
                        }).catch(error => {
                            console.error("Error fetching device data:", error);
                            Swal.fire('Lỗi', 'Không thể tải thông tin thiết bị.', 'error');
                        });
                    } else {
                        Swal.fire('Lỗi', 'Không tìm thấy phiếu mượn.', 'error');
                    }
                },
                error: function(xhr, status, error) {
                    Swal.close();
                    Swal.fire('Lỗi', 'Không thể tải dữ liệu từ server.', 'error');
                    $('#device-list').html("<h1> Lỗi khi tải dữ liệu từ server </h1>");
                    console.error("AJAX error:", status, error);
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

        function fetchTrangThaiPhieuMuon(id) {
            $.ajax({
                url: `http://localhost:5244/api/trang-thai-phieu-muon/phieu-muon/${id}`,
                method: 'GET',
                success: function (response) {
                if (response.status === 200 && Array.isArray(response.data)) {
                    response.data.forEach(function (item) {
                        setColorAndTime(item.trangThai, item.thoiGianCapNhat);
                    });
                } else {
                    console.error("Dữ liệu không đúng định dạng:", response);
                }
                },
                error: function (xhr, status, error) {
                console.error("Lỗi khi gọi API:", error);
                }
            });
            }
    </script>
</body>

</html>