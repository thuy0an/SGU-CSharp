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
    <script src="../HelperUI/formatOutput.js"></script>
</head>

<body>
    <?php require_once "./Header.php" ?>

    <?php require_once "./Footer.php" ?>
</body>
<script>
    async function loadDanhSachThietBi() {
        $.ajax({
            url: "http://localhost:5000/api/thietbi/kha-dung", // URL của API
            type: "GET", // Phương thức GET
            success: function(response) {
                if (response.success) {
                    var thietBiHtml = ''; // Biến để lưu HTML
                    $.each(response.data, function(index, thietBi) {
                        // Tạo HTML cho mỗi thiết bị
                        thietBiHtml += `
                        <div class="thietBi">
                            <h3>${thietBi.tenThietBi}</h3>
                            <p>Loại: ${thietBi.tenLoaiThietBi}</p>
                            <p>Số lượng khả dụng: ${thietBi.soLuongKhaDung}</p>
                        </div>
                    `;
                    });
                    // Hiển thị danh sách thiết bị
                    $('#thietBiList').html(thietBiHtml);
                } else {
                    // Nếu có lỗi, hiển thị thông báo
                    alert(response.message);
                }
            },
            error: function(xhr, status, error) {
                // Nếu có lỗi khi gọi API
                alert("Có lỗi khi tải dữ liệu: " + error);
            }
        });
    }

    async function loadAnhThietBi() {
        $.ajax({
            url: "http://localhost:5000/api/thietbi/hinh-anh/" + thietBiId, // URL của API
            type: "GET", // Phương thức GET
            success: function(response) {
                if (response.success) {
                    // Gán hình ảnh vào thẻ img
                    $('#thietBiImage').attr('src', response.data.anhMinhHoa);
                } else {
                    alert(response.message);
                }
            },
            error: function(xhr, status, error) {
                alert("Có lỗi khi tải hình ảnh: " + error);
            }
        });
    }

    $(document).ready(function() {
        // Gọi API để lấy danh sách thiết bị



    });
</script>

</html>