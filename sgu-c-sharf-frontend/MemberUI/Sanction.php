<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <link rel="stylesheet" href="./login.css" />
    <title>Phiếu đặt chỗ</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../utils/formatOutput.js"></script>
    <style>
        .container2 {
            width: 100%;
            display: flex;
            justify-content: center;
        }

        #table-container {
            width: 60%;
            border: 1px solid black;
            border-radius: 15px;
            padding: 50px;
            top: 0;
            margin: 10px;
        }


        a {
            font-size: 16px;
        }

        p {
            font-size: 16px;
        }
    </style>
</head>

<body onload="loaddsPhieuXuPhat()">
    <?php require_once "./Header.php" ?>

    <div class="container2">

        <div style="text-align: center;">
            <h3>Thong bao xu phat</h3>
        </div>
        <div id="table-container">

        </div>

    </div>

    <?php require_once "./Footer.php" ?>
</body>


<script>
    function loaddsPhieuXuPhat() {
        const idThanhVien = sessionStorage.getItem("IdThanhVien");
        const API_URL = `http://localhost:5244/api/phieuxuphat/thanhvien/${idThanhVien}`;
        fetch(API_URL)
            .then(response => response.json())
            .then(data => {
                const container = document.getElementById("table-container");
                container.innerHTML = "";
                if (data.length === 0) {
                    container.innerHTML = "<p>Không có phiếu xử phạt nào.</p>";
                    return;
                }
                container.innerHTML += `
                
            <table class="table table-striped">

                <tbody id="dsPhieuXuPhat">
                `;
                data.forEach(phieu => {
                    const ngay = new Date(phieu.ngayViPham).toLocaleDateString("vi-VN");

                    const row = document.createElement("tr");
                    row.innerHTML = `
          <td scope="row">
            <a href="#" onclick="xemChiTietPhieu(${phieu.id})">
              Phiếu xử phạt ${ngay}
            </a>
          </td>
        `;
                    container += (row);

                });
                container += "</tbody></table>";
            })
            .catch(error => {
                console.error("Lỗi khi lấy danh sách phiếu:", error);
                document.getElementById("dsPhieuXuPhat").innerHTML = "<tr><td>Lỗi tải dữ liệu!</td></tr>";
            });

    }

    function xemChiTietPhieu(id) {
        const idThanhVien = id;
        const API_URL = `http://localhost:5244/api/phieuxuphat/thanhvien/${idThanhVien}`;

        fetch(API_URL)
            .then(response => {
                if (!response.ok) throw new Error("Không thể lấy dữ liệu phiếu xử phạt.");
                return response.json();
            })
            .then(data => {
                const container = document.getElementById("table-container");
                if (data.length === 0) {
                    container.innerHTML = "<p>Không có phiếu xử phạt nào.</p>";
                    return;
                }

                const html = data.map(p => `
            <div>
                <form>
                    <div class="form-group">
                        <p><strong>Họ tên:</strong> ${p.hoTen}</p>
                    </div>
                    <div class="form-group">
                        <p>Mã phiếu xử phạt</p>
                    </div>
                    <div class="form-group">
                        <p><strong>Ngày vi phạm:</strong> ${new Date(p.ngayViPham).toLocaleString()}</p>
                    </div>
                    <div class="form-group">
                        <p><strong>Trạng thái:</strong> ${p.trangThai}</p>
                    </div>
                    <div class="form-group">
                        <p><strong>Thời hạn xử phạt:</strong> ${p.thoiHanXuPhat} ngày</p>
                    </div>
                    <div class="form-group">
                        <p><strong>Mức phạt:</strong> ${p.mucPhat.toLocaleString()} VNĐ</p>
                    </div>
                    <div class="form-group">
                        <p><strong>Mô tả:</strong> ${p.moTa}</p>
                    </div>
                    <button type="submit" class="btn btn-primary" onclick="loaddsPhieuXuPhat()">Thoát</button>
                </form>
            </div>
        `).join("");

                container.innerHTML = html;
            })
            .catch(error => {
                console.error("Lỗi khi gọi API:", error);
            });
    }
</script>

</html>