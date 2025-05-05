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
    <style>
    </style>
</head>

<body>
    <?php require_once "./Header.php" ?>
    <div class="container">
        <div>
            <div class="d-flex flex-row mb-3 g-4">
                <div class="p-2">
                    <select class="form-select" id="selectLoai">
                        <option value="" selected>Chọn loại thiết bị</option>
                    </select>
                </div>
                <div class="p-2">
                    <input type="text" class="form-control" placeholder="Tên thiết bị" name="" id="txtSearch">
                </div>
                <div class="p-2">
                    <button type="button" class="btn btn-danger" id="reset">Đặt lại</button>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row row-cols-4 g-4" id="thietBiList">

        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Them thiet bi</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="card">
                        <img src="" class="card-img-top" id="imgSrc" alt="...">
                        <div class="card-body">
                            <h5 class="card-title" id="tenThietBi"></h5>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item" id="loaiThietBi"></li>
                            <li class="list-group-item" id="soLuongKhaDung"></li>
                            <li class="list-group-item">
                                <div class="input-group" style="width: 50%;">
                                    <button class="btn btn-outline-secondary" type="button" id="btnMinus"><i class="bi bi-dash-lg"></i></button>
                                    <input type="text" class="form-control" id="txtSoLuong" placeholder="So luong">
                                    <button class="btn btn-outline-secondary" type="button" id="btnPlus"><i class="bi bi-plus-lg"></i></button>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Đóng</button>
                    <button type="button" class="btn btn-danger" id="btnThem" data-id="">Thêm</button>
                </div>
            </div>
        </div>
    </div>
    <?php require_once "./Footer.php" ?>
</body>
<script src="../utils/formatOutput.js"></script>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

<script>
    var staticBackdrop = document.getElementById('staticBackdrop')
    staticBackdrop.addEventListener('show.bs.modal', function(event) {
        var button = event.relatedTarget;
        var id = button.getAttribute('data-id');

        const thietBi = danhSachThietBi.data.find(tb => tb.id == id);
        const anh = danhSachHinhAnh.find(img => img.id == id);

        staticBackdrop.querySelector('#tenThietBi').textContent = `${thietBi.tenThietBi}`;
        staticBackdrop.querySelector('#loaiThietBi').textContent = `Loại thiết bị: ${thietBi.tenLoaiThietBi}`;
        staticBackdrop.querySelector('#soLuongKhaDung').textContent = `Số lượng khả dụng: ${thietBi.soLuongKhaDung}`;
        staticBackdrop.querySelector('#imgSrc').src = `../img/${anh.anhMinhHoa}`;
        staticBackdrop.querySelector('#txtSoLuong').value = '1';
        staticBackdrop.querySelector('#btnThem').setAttribute('data-id', id);
        staticBackdrop.querySelector('#btnThem').setAttribute('data-max', thietBi.soLuongKhaDung);
    });

    var danhSachThietBi;
    var danhSachHinhAnh = [];
    var danhSachLoaiThietBi;

    // Hàm gọi API
    async function getDanhSachThietBi() {
        try {
            const response = await $.ajax({
                url: "http://localhost:5244/api/ThietBi/kha-dung",
                type: "GET"
            });
            return response;
        } catch (error) {
            throw error;
        }
    }

    async function getDanhSachLoaiThietBi() {
        try {
            const response = await $.ajax({
                url: "http://localhost:5244/api/loai-thiet-bi/no-paging",
                type: "GET"
            });
            return response;
        } catch (error) {
            throw error;
        }
    }

    async function getAnhThietBi(thietBiId) {
        try {
            const response = await $.ajax({
                url: "http://localhost:5244/api/ThietBi/hinh-anh/" + thietBiId,
                type: "GET"
            });
            return response;
        } catch (error) {
            throw error;
        }
    }

    // Hàm gọi API cho tất cả thiết bị và trả về danh sách hình ảnh
    async function getDanhSachHinhAnh(thietBiList) {
        const danhSachHinhAnh = [];
        for (let thietBi of thietBiList) {
            try {
                const response = await getAnhThietBi(thietBi.id);
                if (response.status == 200) {
                    danhSachHinhAnh.push({
                        id: thietBi.id,
                        anhMinhHoa: response.data.anhMinhHoa
                    });
                } else {
                    console.log("Không có ảnh cho thiết bị " + thietBi.tenThietBi);
                }
            } catch (error) {
                console.log("Có lỗi khi tải ảnh cho thiết bị " + thietBi.tenThietBi);
            }
        }
        return danhSachHinhAnh;
    }

    // Hàm hiển thị thiết bị
    function displayDanhSachThietBi(tenLoai = "", tuKhoa = "") {
        if (danhSachThietBi.status == 200) {
            let thietBiHtml = '';

            const danhSachLoc = danhSachThietBi.data.filter(thietBi => {
                const matchLoai = tenLoai == "" || thietBi.tenLoaiThietBi == tenLoai;
                const matchTen = thietBi.tenThietBi.toLowerCase().includes(tuKhoa.toLowerCase());
                return matchLoai && matchTen;
            });

            danhSachLoc.forEach(thietBi => {
                const anh = danhSachHinhAnh.find(a => a.id == thietBi.id);
                const imgSrc = anh ? `../img/${anh.anhMinhHoa}` : '../img/default.png';

                thietBiHtml += `
                <div class="col">
                    <div class="card">
                        <img src="${imgSrc}" class="card-img-top" alt="${thietBi.tenThietBi}">
                        <div class="card-body">
                            <h5 class="card-title">${thietBi.tenThietBi}</h5>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">Loại thiết bị: ${thietBi.tenLoaiThietBi}</li>
                            <li class="list-group-item">Số lượng khả dụng: ${thietBi.soLuongKhaDung}</li>
                        </ul>
                        <div class="card-body">
                            <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#staticBackdrop" data-id="${thietBi.id}">Thêm</button>
                        </div>
                    </div>
                </div>
            `;
            });

            $('#thietBiList').html(thietBiHtml);
        } else {
            alert(danhSachThietBi.message || "Không lấy được danh sách thiết bị.");
        }
    }


    function displayLoaiThietBi() {
        var select = document.getElementById("selectLoai");

        select.innerHTML = '<option value="" selected>Chọn loại thiết bị</option>';

        danhSachLoaiThietBi.data.forEach(function(loai) {
            var option = document.createElement("option");
            option.value = loai.tenLoaiThietBi;
            option.textContent = loai.tenLoaiThietBi;
            select.appendChild(option);
        });
    }

    document.addEventListener("DOMContentLoaded", function() {
        readyLoad();
        var selectLoai = document.getElementById("selectLoai");
        var txtSearch = document.getElementById("txtSearch");
        var btnReset = document.getElementById("reset");
        var btnMinus = document.getElementById("btnMinus");
        var btnPlus = document.getElementById("btnPlus");
        var txtSoLuong = document.getElementById("txtSoLuong");
        var btnThem = document.getElementById("btnThem");


        selectLoai.addEventListener("change", function() {
            var searchValue = txtSearch.value;
            var selectedValue = selectLoai.value;
            displayDanhSachThietBi(selectedValue, searchValue);
        });

        txtSearch.addEventListener("input", function() {
            var searchValue = txtSearch.value;
            var selectedValue = selectLoai.value;
            displayDanhSachThietBi(selectedValue, searchValue);
        });

        btnReset.addEventListener("click", function() {
            readyLoad();
        });

        btnMinus.addEventListener("click", function() {
            var soLuongInput = document.getElementById("txtSoLuong");
            var currentValue = parseInt(soLuongInput.value) || 0;
            if (currentValue > 1) {
                soLuongInput.value = currentValue - 1;
            } else {
                Swal.fire({
                    title: 'Số lượng không được nhỏ hơn 1!',
                    icon: 'error',
                    confirmButtonText: 'OK'
                })
            }
        });

        btnPlus.addEventListener("click", function() {
            var soLuongInput = document.getElementById("txtSoLuong");
            var maxSoLuong = parseInt(document.getElementById("soLuongKhaDung").textContent) || 0;
            var currentValue = parseInt(soLuongInput.value) || 0;

            if (currentValue < maxSoLuong) {
                soLuongInput.value = currentValue + 1;
            } else {
                Swal.fire({
                    title: 'Số lượng không được lớn hơn số lượng khả dụng!',
                    icon: 'error',
                    confirmButtonText: 'OK'
                })
            }
        });

        txtSoLuong.addEventListener("input", function() {
            var soLuongInput = document.getElementById("txtSoLuong");
            var maxSoLuong = parseInt(document.getElementById("soLuongKhaDung").textContent) || 0;
            var currentValue = parseInt(soLuongInput.value) || 0;

            if (currentValue < 1) {
                soLuongInput.value = 1;
                Swal.fire({
                    title: 'Số lượng không được nhỏ hơn 1!',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            } else if (currentValue > maxSoLuong) {
                soLuongInput.value = maxSoLuong;
                Swal.fire({
                    title: 'Số lượng không được lớn hơn số lượng khả dụng!',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            }
        });

        btnThem.addEventListener("click", function() {
            const idThietBi = this.getAttribute("data-id");
            const maxSoLuong = this.getAttribute("data-max");
            const soLuongMuon = parseInt(document.getElementById("txtSoLuong").value);

            let datCho = JSON.parse(localStorage.getItem("datCho")) || [];

            const index = datCho.findIndex(item => item.id == idThietBi);
            let tongSoLuong = soLuongMuon;

            if (index !== -1) {
                tongSoLuong += datCho[index].soLuong;
            }

            if (tongSoLuong > maxSoLuong) {
                Swal.fire({
                    title: `Số lượng đặt (${tongSoLuong}) vượt quá số lượng khả dụng (${maxSoLuong})!`,
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
                return;
            }

            if (index !== -1) {
                datCho[index].soLuong = tongSoLuong;
            } else {
                datCho.push({
                    id: idThietBi,
                    soLuong: soLuongMuon
                });
            }

            localStorage.setItem("datCho", JSON.stringify(datCho));

            Swal.fire({
                title: 'Đã thêm vào danh sách muốn đặt chỗ!',
                icon: 'success',
                confirmButtonText: 'OK'
            }).then(() => {
                const modalInstance = bootstrap.Modal.getInstance(staticBackdrop);
                modalInstance.hide();
            });
        });
    });

    // Hàm load dữ liệu tổng
    async function readyLoad() {
        try {
            danhSachThietBi = await getDanhSachThietBi();
            danhSachHinhAnh = await getDanhSachHinhAnh(danhSachThietBi.data);
            danhSachLoaiThietBi = await getDanhSachLoaiThietBi();
            console.log(danhSachThietBi);
            console.log(danhSachHinhAnh);
            displayDanhSachThietBi();
            displayLoaiThietBi();
        } catch (error) {
            console.log("Lỗi khi load dữ liệu: ", error);
        }
    }
</script>

</html>