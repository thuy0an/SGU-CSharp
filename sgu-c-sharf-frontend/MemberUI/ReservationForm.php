<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <link rel="stylesheet" href="./login.css" />
    <link rel="stylesheet" href="MyOrder.css" />

    <title>Phiếu đặt chỗ</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../HelperUI/formatOutput.js"></script>
    <style>
        .container2 {
            width: 100%;
            display: flex;
            justify-content: center;
        }

        .formdatcho {
            width: 40%;
            border: 1px solid black;
            border-radius: 15px;
            padding: 50px;
            top: 0;
            margin: 10px;
        }

        .form-group {
            margin: 15px 5px;
        }

        #formdatcho2 {
            display: none;
        }
    </style>
</head>

<body>
    <?php require_once "./Header.php" ?>

    <div class="container2">

        <form id="formdatcho1" class="formdatcho">
            <div style="text-align: center;">
                <h3>Phiếu đặt chỗ</h3>
            </div>
            <div class="form-group">
                <label for="ngaydatcho">Ngày đặt chỗ:</label>
                <input type="datetime-local" class="form-control" id="ngaydatcho">
            </div>
            <button type="button" class="btn btn-primary" id="next">Tiếp tục</button>
        </form>
        <form id="formdatcho2" class="formdatcho">
            <div style="text-align: center;">
                <h3>Danh sách thiết bị</h3>
            </div>
            <div class="form-group">
                <label for="loaithietbi">Chọn loại thiết bị:</label>
                <select class="form-control" id="loaithietbi" onchange="loadDsThietBi()">
                    <option>Default select</option>
                </select>
            </div>
            <div class="form-group">
                <table class="table table-striped" id="danhsachthietbi">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Thiết bị</th>
                            <th scope="col" style="width: 100px;">Số lượng</th>
                            <th scope="col" style="width: 100px;"></th>
                        </tr>
                    </thead>
                    <tbody id="bddsthietbi">
                        <tr>
                            <th scope="row">1</th>
                            <td></td>
                            <td></td>
                            <td>
                                <button type="button" class="btn btn-primary" id="datcho" onclick="them(this)">Thêm</button>
                            </td>
                        </tr>
                    </tbody>
                </table>


                <div style="text-align: center;">
                    <h3>Danh sách đặt chỗ</h3>
                </div>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Thiết bị</th>
                            <th scope="col" style="width: 100px;">Số lượng</th>
                            <th scope="col" style="width: 100px;"></th>
                        </tr>
                    </thead>
                    <tbody id="danhsachdatcho">
                        <tr>
                            <th scope="row">1</th>
                            <td></td>
                            <td>
                                <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)" style="width: 80px;">
                            </td>
                            <td>
                                <button type="button" class="btn btn-primary" id="datcho" onclick="xoa()">Xóa</button>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>
            <button type="button" class="btn btn-primary" id="previous">Quay lại</button>
            <button type="button" class="btn btn-primary" id="datcho">Đặt chỗ</button>
        </form>

    </div>

    <?php require_once "./Footer.php" ?>
</body>


<script>
    document.getElementById("next").addEventListener("click", function() {
        document.getElementById("formdatcho1").style.display = "none";
        document.getElementById("formdatcho2").style.display = "block";
        console.log("next");
    });

    document.getElementById("previous").addEventListener("click", function() {
        document.getElementById("formdatcho1").style.display = "block";
        document.getElementById("formdatcho2").style.display = "none";
        console.log("previous");
    });

    function loadLoaiThietBi() {
        const API_LOAI_TB = "http://localhost:5000/api/loaithietbi"; // Đổi URL nếu khác

        fetch(API_LOAI_TB)
            .then(res => res.json())
            .then(data => {
                const select = document.getElementById("loaithietbi");
                select.innerHTML = ""; // Xoá mặc định

                // Thêm option mặc định
                const defaultOption = document.createElement("option");
                defaultOption.value = "";
                defaultOption.text = "-- Chọn loại thiết bị --";
                select.appendChild(defaultOption);

                // Thêm từng loại thiết bị
                data.forEach(loai => {
                    const option = document.createElement("option");
                    option.value = loai.id;
                    option.text = loai.tenLoai;
                    select.appendChild(option);
                });
            })
            .catch(err => {
                console.error("Lỗi khi tải loại thiết bị:", err);
            });

    }

    function loadDsThietBi() {
        const loaiId = document.getElementById("loaiThietBiSelect").value;
        if (!loaiId) {
            document.getElementById("bddsthietbi").innerHTML = "<tr><td colspan='4'>Vui lòng chọn loại thiết bị</td></tr>";
            return;
        }

        const API_THIETBI = `http://localhost:5000/api/thietbi/loai/${loaiId}`;

        fetch(API_THIETBI)
            .then(res => res.json())
            .then(data => {
                const tbody = document.getElementById("bddsthietbi");
                tbody.innerHTML = "";

                if (data.length === 0) {
                    tbody.innerHTML = "<tr><td colspan='4'>Không có thiết bị nào</td></tr>";
                    return;
                }

                data.forEach((tb, index) => {
                    const row = document.createElement("tr");
                    row.innerHTML = `
          <th scope="row">${index + 1}</th>
          <td>${tb.ten}</td>
          <td>${tb.soLuong}</td>
          <td>
            <button type="button" class="btn btn-primary" onclick="them(this)" data-id="${tb.id}" data-ten="${tb.ten}">
              Thêm
            </button>
          </td>
        `;
                    tbody.appendChild(row);
                });
            })
            .catch(err => {
                console.error("Lỗi khi tải danh sách thiết bị:", err);
            });
    }


    let danhSachDaChon = [];

    function them(btn) {
        const id = btn.getAttribute("data-id");
        const ten = btn.getAttribute("data-ten");
        const soLuong = btn.closest("tr").children[2].innerText;

        // Kiểm tra trùng
        if (danhSachDaChon.find(tb => tb.id === id)) {
            alert("Thiết bị đã được chọn!");
            return;
        }

        danhSachDaChon.push({
            id,
            ten
        });

        const tbody = document.getElementById("danhsachdatcho");
        const index = danhSachDaChon.length;

        const row = document.createElement("tr");
        row.setAttribute("data-id", id); // dùng để xóa sau này

        row.innerHTML = `
        <th scope="row">${index}</th>
        <td>${ten}</td>
        <td>
            <input type="number" class="form-control" min="1" max="${soLuong}" style="width: 80px;" value="1">
        </td>
        <td>
            <button type="button" class="btn btn-danger" onclick="xoa(this)">Xóa</button>
        </td>
    `;

        tbody.appendChild(row);
    }

    function xoa(button) {
        var row = button.closset('tr');
        row.remove();
    }

    function datCho() {
        const danhSach = [];
        const rows = document.querySelectorAll("#danhsachdatcho tr");

        if (rows.length === 0) {
            alert("Chưa chọn thiết bị nào!");
            return;
        }

        rows.forEach(row => {
            const id = row.getAttribute("data-id");
            const input = row.querySelector("input");
            const soLuong = parseInt(input.value);

            if (isNaN(soLuong) || soLuong <= 0) {
                alert("Số lượng không hợp lệ!");
                return;
            }

            danhSach.push({
                thietBiId: id,
                soLuong: soLuong
            });
        });

        // Gửi dữ liệu lên API
        fetch("http://localhost:5000/api/datcho", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(danhSach)
            })
            .then(res => {
                if (!res.ok) throw new Error("Lỗi đặt chỗ");
                return res.json();
            })
            .then(data => {
                alert("✅ Đặt chỗ thành công!");
                // Reset nếu cần
                document.getElementById("danhsachdatcho").innerHTML = "";
                danhSachDaChon = [];
            })
            .catch(err => {
                console.error(err);
                alert("❌ Lỗi khi đặt chỗ!");
            });
    }
</script>

</html>