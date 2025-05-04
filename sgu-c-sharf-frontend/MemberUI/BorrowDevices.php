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
        <div class="row row-cols-4 g-4">
            <!--  -->
            <div class="col">
                <div class="card">
                    <img src="../img/hp_elitebook.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title">Ten thiet bi</h5>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Loai thiet bi:${thietBi.tenLoaiThietBi}</li>
                        <li class="list-group-item">co luong kha dung</li>
                    </ul>
                    <div class="card-body">
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#staticBackdrop" data-id="1">Them</button>
                    </div>
                </div>
            </div>
            <!--  -->
            <div class="col">
                <div class="card">
                    <img src="../img/hp_elitebook.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title">Ten thiet bi</h5>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Loai thiet bi:${thietBi.tenLoaiThietBi}</li>
                        <li class="list-group-item">co luong kha dung</li>
                    </ul>
                    <div class="card-body">
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#staticBackdrop" data-id="1">Them</button>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <img src="../img/hp_elitebook.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title">Ten thiet bi</h5>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Loai thiet bi:${thietBi.tenLoaiThietBi}</li>
                        <li class="list-group-item">co luong kha dung</li>
                    </ul>
                    <div class="card-body">
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#staticBackdrop" data-id="1">Them</button>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <img src="../img/hp_elitebook.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title">Ten thiet bi</h5>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Loai thiet bi:$thietBi.tenLoaiThietB</li>
                        <li class="list-group-item">co luong kha dung</li>
                    </ul>
                    <div class="card-body">
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#staticBackdrop" data-id="1">Them</button>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <img src="../img/hp_elitebook.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title">Ten thiet bi</h5>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Loai thiet bi:${thietBi.tenLoaiThietBi}</li>
                        <li class="list-group-item">co luong kha dung</li>
                    </ul>
                    <div class="card-body">
                        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#staticBackdrop" data-id="1">Them</button>
                    </div>
                </div>
            </div>
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
                        <img src="../img/hp_elitebook.jpg" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title" id="">Ten thiet bi</h5>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item" id="">Loai thiet bi</li>
                            <li class="list-group-item" id="">co luong kha dung</li>
                            <li class="list-group-item">
                                <div class="input-group" style="width: 50%;">
                                    <button class="btn btn-outline-secondary" type="button"><i class="bi bi-dash-lg"></i></button>
                                    <input type="text" class="form-control" id="" placeholder="So luong">
                                    <button class="btn btn-outline-secondary" type="button"><i class="bi bi-plus-lg"></i></button>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Dong</button>
                    <button type="button" class="btn btn-danger" id="">Them</button>
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
        var modalProductId = staticBackdrop.querySelector('#modalProductId');
        modalProductId.textContent = id;
    });

    var danhSachThietBi;
    var danhSachHinhAnh = [];
    // Hàm gọi API, trả về Promise
    async function getDanhSachThietBi() {
        try {
            const response = await $.ajax({
                url: "http://localhost:5244/api/thiet-bi/kha-dung",
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
                url: "http://localhost:5244/api/thiet-bi/hinh-anh/" + thietBiId,
                type: "GET"
            });
            return response;
        } catch (error) {
            throw error;
        }
    }

    // Hàm gọi API cho tất cả thiết bị và lưu vào danh sách hình ảnh
    async function getDanhSachHinhAnh() {
        for (let thietBi of danhThietBi) {
            try {
                const response = await getAnhThietBi(thietBi.id);
                if (response.success) {
                    // Lưu hình ảnh vào danhSachHinhAnh
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
    }
    // Hàm xử lý dữ liệu, gọi hàm get
    async function loadDanhSachThietBi() {
        try {
            danhSachThietBi = await getDanhSachThietBi();
            danhSachHinhAnh = await getDanhSachHinhAnh();
            if (danhSachThietBi) {
                let thietBiHtml = '';
                $.each(response.data, function(index, thietBi) {
                    thietBiHtml += `
                    <div class="thietBi">
                        <h3>${thietBi.tenThietBi}</h3>
                        <p>Loại: ${thietBi.tenLoaiThietBi}</p>
                        <p>Số lượng khả dụng: ${thietBi.soLuongKhaDung}</p>
                        <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#quickViewModal" data-id="${thietBi.id}">
                            Xem nhanh
                        </button>
                    </div>
                    <div class="col">
                        <div class="card">
                            <img src="../img/${z}" class="card-img-top" alt="${z}">
                            <div class="card-body">
                                <h5 class="card-title">${thietBi.tenThietBi}</h5>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">Loai thiet bi:${thietBi.tenLoaiThietBi}</li>
                                <li class="list-group-item">So luong kha dung:${thietBi.soLuongKhaDung}</li>
                            </ul>
                            <div class="card-body">
                                <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#staticBackdrop" data-id="1">Them</button>
                            </div>
                        </div>
                    </div>
                `;
                });
                $('#thietBiList').html(thietBiHtml);
            } else {
                alert(response.message);
            }
        } catch (error) {
            alert("Có lỗi khi tải dữ liệu: " + error);
        }
    }




    $(document).ready(function() {

    });
</script>

</html>