<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <link rel="stylesheet" href="./login.css" />

    <title>Phiếu đặt chỗ</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../utils/formatOutput.js"></script>
    <style>
        .input-group {
            width: 50%;
        }
    </style>
</head>

<body>
    <?php require_once "./Header.php" ?>
    <div class="container mt-4">
        <div class="row">
            <div class="col-md-8">
                <div id="datChoList" class="d-flex flex-column gap-3">
                    <!-- Các card sẽ được thêm vào đây -->
                </div>
            </div>
            <div class="col-md-4">
                <div>
                    <label for="txtNgayMuon">Ngày mượn</label>
                    <input type="date" class="form-control mb-2" id="txtNgayMuon">
                    <button id="btnTaoPhieu" class="btn btn-danger w-100">Đặt chỗ</button>
                </div>
            </div>
        </div>
    </div>
    <?php require_once "./Footer.php" ?>
</body>

<script>
    document.addEventListener("DOMContentLoaded", function() {
        loadDatCho();
    });

    const TrangThaiPhieuMuonEnum = {
        CHODUYET: 0,
        DATCHO: 1,
        DANGSUDUNG: 2,
        DATRATHIETBI: 3,
        HUY: 4
    };

    const TrangThaiChiTietPhieuMuonEnum = {
        CHODUYET: 0,
        DANGMUON: 1,
        DATRATHIETBI: 2,
        DATHATLAC: 3
    };

    const TrangThaiDauThietBiEnum = {
        KHADUNG: 0,
        DATTRUOC: 1,
        DANGMUON: 2,
        THATLAC: 3,
        BAOTRI: 4
    };

    function loadDatCho() {
        const datCho = JSON.parse(localStorage.getItem("datCho")) || [];
        const datChoList = document.getElementById("datChoList");

        if (datCho.length === 0) {
            datChoList.innerHTML = `<tr>
                                        <td colspan="4" class="text-center">
                                            Không có thiết bị nào trong danh sách đặt chỗ.
                                            <br>
                                            <a href="borrowdevices.php" class="btn btn-danger mt-2">Đặt thiết bị ngay</a>
                                        </td>
                                    </tr>`;
        } else {
            let html = "";
            datCho.forEach((item, index) => {
                html += `
                    <div class="card">
                        <div class="row g-0">
                            <div class="col-auto">
                                <img src="" class="img-fluid rounded-start anh-thiet-bi" data-id="${item.id}" alt="Ảnh thiết bị" style="width: 120px; height: 120px; object-fit: cover;">
                            </div>
                            <div class="col">
                                <div class="card-body d-flex flex-column">
                                    <h5 class="card-title ten-thiet-bi" data-id="${item.id}">Đang tải...</h5>
                                    <div class="input-group input-group-sm mb-2">
                                        <button type="button" class="btn btn-outline-secondary btnMinus" data-id="${item.id}">
                                            <i class="bi bi-dash-lg"></i>
                                        </button>
                                        <input type="text" class="form-control text-center txtSoLuong" value="${item.soLuong}" data-id="${item.id}" style="max-width: 60px;">
                                        <button type="button" class="btn btn-outline-secondary btnPlus" data-id="${item.id}">
                                            <i class="bi bi-plus-lg"></i>
                                        </button>
                                    </div>
                                    <button class="btn btn-danger btn-sm btnXoa mt-auto align-self-start" data-id="${item.id}">Xóa</button>
                                </div>
                            </div>
                        </div>
                    </div>`;
            });
            datChoList.innerHTML = html;

            // tên thiết bị
            document.querySelectorAll(".ten-thiet-bi").forEach(cell => {
                const id = cell.getAttribute("data-id");
                $.ajax({
                    url: `http://localhost:5244/api/ThietBi/${id}`,
                    method: 'GET',
                    dataType: 'json',
                    success: function(data) {
                        if (data.status === 200) {
                            cell.textContent = data.data.tenThietBi;
                        } else {
                            cell.textContent = "Không tìm thấy";
                        }
                    },
                    error: function() {
                        cell.textContent = "Lỗi tải tên thiết bị";
                    }
                });
            });

            //load Anh
            document.querySelectorAll(".anh-thiet-bi").forEach(cell => {
                const id = cell.getAttribute("data-id");
                $.ajax({
                    url: `http://localhost:5244/api/ThietBi/hinh-anh/${id}`,
                    method: 'GET',
                    dataType: 'json',
                    success: function(data) {
                        if (data.status === 200) {
                            const imgSrc = `../img/${data.data.anhMinhHoa}`;
                            cell.src = imgSrc;
                        } else {
                            cell.textContent = "Không có ảnh";
                        }
                    },
                    error: function() {
                        cell.textContent = "Lỗi ảnh";
                    }
                });
            });

            //Thêm số lượng
            document.querySelectorAll(".btnPlus").forEach(btn => {
                btn.addEventListener("click", function() {
                    const id = this.getAttribute("data-id");
                    const input = document.querySelector(`.txtSoLuong[data-id='${id}']`);
                    let currentValue = parseInt(input.value) || 1;

                    $.ajax({
                        url: `http://localhost:5244/api/ThietBi/kha-dung/${id}`,
                        method: 'GET',
                        dataType: 'json',
                        success: function(data) {
                            if (data.status === 200) {
                                const maxSoLuong = data.data.soLuongKhaDung;
                                if (currentValue < maxSoLuong) {
                                    input.value = currentValue + 1;
                                    capNhatLocalStorage(id, input.value);
                                } else {
                                    Swal.fire("Không thể vượt quá số lượng khả dụng!", "", "warning");
                                }
                            } else {
                                Swal.fire("Không lấy được số lượng khả dụng!", "", "error");
                            }
                        },
                        error: function() {
                            Swal.fire("Lỗi kết nối đến server!", "", "error");
                        }
                    });
                });
            });

            //Thay đổi số lượng
            document.querySelectorAll(".txtSoLuong").forEach(input => {
                input.addEventListener("input", function() {
                    const id = this.getAttribute("data-id");
                    let value = parseInt(this.value) || 1;

                    $.ajax({
                        url: `http://localhost:5244/api/ThietBi/kha-dung/${id}`,
                        method: 'GET',
                        dataType: 'json',
                        success: function(data) {
                            if (data.status === 200) {
                                const maxSoLuong = data.data.soLuongKhaDung;
                                if (value < 1) {
                                    value = 1;
                                    Swal.fire("Số lượng tối thiểu là 1!", "", "warning");
                                }
                                if (value > maxSoLuong) {
                                    value = maxSoLuong;
                                    Swal.fire("Số lượng không thể lớn hơn khả dụng!", "", "warning");
                                }
                                input.value = value;
                                capNhatLocalStorage(id, value);
                            } else {
                                Swal.fire("Không lấy được số lượng khả dụng!", "", "error");
                            }
                        },
                        error: function() {
                            Swal.fire("Lỗi kết nối đến server!", "", "error");
                        }
                    });
                });
            });

            //Giảm số lượng
            document.querySelectorAll(".btnMinus").forEach(btn => {
                btn.addEventListener("click", function() {
                    const id = this.getAttribute("data-id");
                    const input = document.querySelector(`.txtSoLuong[data-id='${id}']`);
                    let currentValue = parseInt(input.value) || 1;

                    if (currentValue > 1) {
                        input.value = currentValue - 1;
                        capNhatLocalStorage(id, input.value);
                    } else {
                        Swal.fire({
                            title: "Số lượng đang là 1. Bạn có muốn xóa thiết bị này không?",
                            icon: "question",
                            showCancelButton: true,
                            confirmButtonText: "Có, xóa",
                            cancelButtonText: "Không"
                        }).then((result) => {
                            if (result.isConfirmed) {
                                let datCho = JSON.parse(localStorage.getItem("datCho")) || [];
                                datCho = datCho.filter(item => item.id != id);
                                localStorage.setItem("datCho", JSON.stringify(datCho));
                                location.reload();
                            }
                        });
                    }
                });
            });

            // Xử lý nút Xóa
            document.querySelectorAll(".btnXoa").forEach(btn => {
                btn.addEventListener("click", function() {
                    const id = this.getAttribute("data-id");
                    Swal.fire({
                        title: "Bạn có muốn xóa thiết bị này không?",
                        icon: "question",
                        showCancelButton: true,
                        confirmButtonText: "Có, xóa",
                        cancelButtonText: "Không"
                    }).then((result) => {
                        if (result.isConfirmed) {
                            let datCho = JSON.parse(localStorage.getItem("datCho")) || [];
                            datCho = datCho.filter(item => item.id != id);
                            localStorage.setItem("datCho", JSON.stringify(datCho));
                            location.reload();
                        }
                    });
                });
            });
        }

        //Đặt chỗ
        document.getElementById("btnTaoPhieu").addEventListener("click", async function() {
            const IdThanhVien = sessionStorage.getItem("id");
            if (!IdThanhVien) {
                Swal.fire({
                    title: "Bạn chưa đăng nhập!",
                    text: "Vui lòng đăng nhập để tiếp tục.",
                    icon: "warning",
                    confirmButtonText: "OK"
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = "./Login/LoginUI.php";
                    }
                });
                return;
            }

            try {
                let response = await $.ajax({
                    url: `http://localhost:5244/api/phieu-xu-phat/user/${IdThanhVien}`,
                    method: "GET",
                });
                console.log(response);
                if (response && response.status == 200 && response.data) {
                    const ngayViPhamStr = response.data.ngayViPham;
                    const thoiHanXuPhat = response.data.thoiHanXuPhat;

                    // Chuyển chuỗi ngày thành đối tượng Date
                    const ngayViPham = new Date(ngayViPhamStr);
                    console.log("Ngày vi phạm:", ngayViPham);
                    console.log("Thời hạn xử phạt:", thoiHanXuPhat);

                    // Kiểm tra tính hợp lệ
                    if (isNaN(ngayViPham.getTime()) || thoiHanXuPhat == null) {
                        Swal.fire("Dữ liệu không hợp lệ!", "", "warning");
                        return;
                    }

                    // Tính ngày hết vi phạm
                    const ngayHetViPham = new Date(ngayViPham);
                    ngayHetViPham.setDate(ngayHetViPham.getDate() + thoiHanXuPhat);

                    const ngayHienTai = new Date();
                    if (ngayHienTai <= ngayHetViPham) {
                        Swal.fire({
                            title: "Chưa hết xử phạt!",
                            text: "Bạn vẫn còn trong thời gian xử phạt, vui lòng quay lại sau!",
                            icon: "warning",
                        });
                        return;
                    }
                }
            } catch (e) {
                Swal.fire("Không thể kiểm tra ngày vi phạm!", "", "error");
                return;
            }

            if (datCho.length === 0) {
                Swal.fire("Không có thiết bị nào để tạo phiếu!", "", "warning");
                return;
            }

            let devicesToBorrow = [];
            let isValid = true;

            for (let item of datCho) {
                try {
                    let response = await $.ajax({
                        url: `http://localhost:5244/api/ThietBi/kha-dung/${item.id}`,
                        method: "GET"
                    });

                    if (response.status == 200) {
                        const availableQuantity = response.data.soLuongKhaDung;
                        if (item.soLuong > availableQuantity) {
                            isValid = false;
                            Swal.fire(`Số lượng thiết bị ${item.tenThietBi} không đủ khả dụng!`, "", "warning");
                            break;
                        } else {
                            devicesToBorrow.push({
                                idThietBi: item.id,
                                soLuong: item.soLuong
                            });
                        }
                    } else {
                        isValid = false;
                        Swal.fire("Không lấy được số lượng khả dụng!", "", "error");
                        break;
                    }
                } catch (error) {
                    isValid = false;
                    Swal.fire("Lỗi kết nối đến server!", "", "error");
                    break;
                }
            }

            if (!isValid) return;
            let ngayMuon = $('#txtNgayMuon').val();
            let ngayMuonISO = null;

            if (!ngayMuon) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Chưa chọn ngày mượn',
                    text: 'Vui lòng chọn ngày mượn trước khi tiếp tục!'
                });
                return;

            } else {
                let ngayMuonDate = new Date(ngayMuon);
                let today = new Date();

                // Xóa giờ phút giây để so sánh chính xác theo ngày
                ngayMuonDate.setHours(0, 0, 0, 0);
                today.setHours(0, 0, 0, 0);

                if (ngayMuonDate < today) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Ngày mượn không hợp lệ',
                        text: 'Ngày mượn không được ở quá khứ!'
                    });
                    return;
                }

                ngayMuonISO = ngayMuonDate.toISOString();
                console.log("ngayMuonISO:", ngayMuonISO);
            }

            try {
                // Tạo phiếu mượn


                let createPhieuMuonResponse = await $.ajax({
                    url: "http://localhost:5244/api/phieu-muon",
                    method: "POST",
                    contentType: "application/json",
                    data: JSON.stringify({
                        IdThanhVien: IdThanhVien,
                        NgayTao: new Date().toISOString()
                    })
                });

                const IdPhieuMuon = createPhieuMuonResponse.data;
                console.log("IdPhieuMuon:", IdPhieuMuon);

                // Tạo trạng thái phiếu mượn
                let createTrangThaiResponse = await $.ajax({
                    url: "http://localhost:5244/api/trang-thai-phieu-muon",
                    method: "POST",
                    contentType: "application/json",
                    data: JSON.stringify({
                        IdPhieuMuon: IdPhieuMuon,
                        TrangThai: TrangThaiPhieuMuonEnum.CHODUYET,
                        ThoiGianCapNhat: new Date().toISOString()
                    })
                });

                // Lấy danh sách đầu thiết bị
                let dauThietBiPromises = devicesToBorrow.map(device =>
                    $.ajax({
                        url: `http://localhost:5244/api/DauThietBi/${device.idThietBi}/${device.soLuong}`,
                        method: "GET"
                    })
                    .then(res => {
                        if (res.status === 200) { // Nếu backend có trả res.status
                            return res.data;
                        } else {
                            throw new Error(res.message || "Lỗi lấy đầu thiết bị");
                        }
                    })
                );

                let allDataArrays = await Promise.all(dauThietBiPromises);
                let allDauThietBi = allDataArrays.flat();

                console.log(allDauThietBi);

                let chiTietPhieuMuonList = allDauThietBi.map(dtb => ({
                    IdPhieuMuon: IdPhieuMuon,
                    IdDauThietBi: dtb.id,
                    ThoiGianMuon: ngayMuonISO,
                    TrangThai: TrangThaiChiTietPhieuMuonEnum.CHODUYET
                }));

                console.log(chiTietPhieuMuonList);

                // Tạo chi tiết phiếu mượn
                let resChiTiet = await $.ajax({
                    url: "http://localhost:5244/api/chi-tiet-phieu-muon",
                    method: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(chiTietPhieuMuonList)
                });

                if (resChiTiet.status !== 200) {
                    throw new Error(resChiTiet.message || "Tạo chi tiết phiếu mượn thất bại!");
                }

                // Cập nhật trạng thái đầu thiết bị
                allDauThietBi.forEach(device => {
                    device.trangThai = TrangThaiDauThietBiEnum.DATTRUOC;
                });

                let resUpdate = await $.ajax({
                    url: `http://localhost:5244/api/DauThietBi/update-danhsach`,
                    method: "PUT",
                    contentType: "application/json",
                    data: JSON.stringify(allDauThietBi)
                });

                if (resUpdate.status !== 200) {
                    console.error(`Cập nhật trạng thái đầu thiết bị thất bại: ${resUpdate.message}`);
                    throw new Error(resUpdate.message || "Cập nhật trạng thái đầu thiết bị thất bại!");
                }

                console.log("Cập nhật trạng thái đầu thiết bị thành công.");

                // Chỉ hiện thông báo thành công khi tất cả bước đều thành công
                Swal.fire("Tạo phiếu thành công!", "", "success").then(() => {
                    localStorage.removeItem("datCho");
                    location.reload();
                });

            } catch (error) {
                console.error("Lỗi tổng:", error);
                Swal.fire("Lỗi khi tạo phiếu mượn!", error.message || "Unknown error", "error");
            }
        });
    }

    function capNhatLocalStorage(id, soLuong) {
        const datCho = JSON.parse(localStorage.getItem("datCho")) || [];
        const index = datCho.findIndex(item => item.id == id);
        if (index !== -1) {
            datCho[index].soLuong = parseInt(soLuong);
            localStorage.setItem("datCho", JSON.stringify(datCho));
        }
    }
</script>

</html>