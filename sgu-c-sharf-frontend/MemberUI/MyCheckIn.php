<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="./MyOrder.css" />
    <link rel="stylesheet" href="./HomePage.css" />

    <title>Lịch sử người dùng</title>
</head>
<style>
    .user-history-nav {
        margin: 30px 0;
        margin-top: 100px;
        padding: 20px;
        background-color: #fff3e0; /* vàng nhạt */
        border-right: 3px solid #7b181a; /* đỏ viền */
        min-height: 100%;
    }

    .nav-tabs {
        list-style: none;
        padding: 0;
        margin: 0;
        display: flex;
        flex-direction: column;
        gap: 10px;
    }

    .nav-tabs li a {
        text-decoration: none;
        padding: 12px 20px;
        display: block;
        color: #7b181a;
        background-color: #fff3e0;
        border-left: 5px solid transparent;
        font-weight: 600;
        border-radius: 4px;
        transition: all 0.3s ease;
    }

    .nav-tabs li a:hover {
        background-color: #ffe0b2;
        color: #b71c1c;
        border-left: 5px solid #f57c00; /* cam đậm khi hover */
    }

    .nav-tabs li a.active {
        background-color: #7b181a;
        color: white;
        border-left: 5px solid #fbc02d; /* vàng nổi bật */
    }





    .order-table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .order-table th, .order-table td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: center;
    }

    .order-table th {
        background-color: #7b181a;
        color: white;
    }

    .order-table tr:nth-child(even) {
        background-color: #fff8e1;
    }

    .order-table tr:hover {
        background-color: #ffe0b2;
    }

    .detail-button {
        background-color: #7b181a;
        color: white;
        border: none;
        padding: 5px 10px;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.2s ease;
    }

    .detail-button:hover {
        background-color: #b71c1c;
    }



    .cancel-button {
        background-color: #f44336;
        color: white;
        border: none;
        padding: 5px 10px;
        margin-left: 5px;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.2s ease;
    }

    .cancel-button:hover {
        background-color: #c62828;
    }


</style>


<body>
    <?php require_once "./Header.php" ?>

    <content style="display: flex;">
        <section class="user-history-nav" style="width: 20vw; padding: 20px;">
            <ul class="nav-tabs">
                <li><a href="MyOrder.php" class="active">Lịch sử phiếu mượn</a></li>
                <li><a href="MyXuPhat.php">Lịch sử xử phạt</a></li>
                <li><a href="MyCheckIn.php">Lịch sử check in</a></li>
            </ul>
        </section>

        <section style="width: 80vw; padding: 20px;">
            <div class="center-text" style="margin-top: 20px; ">
                <div class="title_section">
                    <div class="bar"></div>
                    <h2 class="center-text-share">Lịch sử check in của bạn</h2>
                </div>
            </div>

                <!-- Phần hiển thị Đơn mượn -->
            <div class="orderManagement_order_history">
                <p id="emptyCartMessage" class="empty_cart" style="text-align: center;">Bạn chưa có đơn hàng nào!</p>
                <table class="order-table" id="checkInHistoryTable">
                    <thead>
                        <tr>
                            <th>Mã Check-in</th>
                            <th>Thời gian Check-in</th>
                        </tr>
                    </thead>
                    <tbody id="checkInHistoryBody"></tbody>
                </table>



            </div>
        </section>
    </content>
  


</body>


<?php require_once "./Footer.php" ?>
<script>
    function loadLichSuCheckIn() {
        const idThanhVien = sessionStorage.getItem("id");

        if (!idThanhVien) {
            Swal.fire('Lỗi', 'Không tìm thấy ID thành viên!', 'error');
            return;
        }

        Swal.fire({
            title: 'Đang tải lịch sử check in...',
            allowOutsideClick: false,
            didOpen: () => Swal.showLoading()
        });

        $.ajax({
            url: `http://localhost:5244/api/check-in/${idThanhVien}`,
            method: 'GET',
            success: function (response) {
                Swal.close();
                if (response && response.status === 200 && Array.isArray(response.data)) {
                    const data = response.data;
                    if (data.length === 0) {
                        $('#emptyCartMessage').text("Bạn chưa có lượt check in nào!").show();
                    } else {
                        $('#emptyCartMessage').hide();
                        displayCheckInHistory(data);
                    }
                } else {
                    Swal.fire('Lỗi', 'Dữ liệu lịch sử không hợp lệ.', 'error');
                }
            },
            error: function (xhr, status, error) {
                Swal.close();
                Swal.fire('Lỗi', 'Không thể tải dữ liệu check in.', 'error');
                console.error(error);
            }
        });
    }

    function displayCheckInHistory(data) {
        const tbody = document.getElementById("checkInHistoryBody");
        tbody.innerHTML = "";

        data.forEach(entry => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${entry.id}</td>
                <td>${formatDate(entry.thoiGianCheckIn)}</td>
            `;
            tbody.appendChild(row);
        });
    }

    function formatDate(dateTimeStr) {
        const date = new Date(dateTimeStr);
        const day = String(date.getDate()).padStart(2, '0');
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const year = date.getFullYear();
        const hours = String(date.getHours()).padStart(2, '0');
        const minutes = String(date.getMinutes()).padStart(2, '0');
        const seconds = String(date.getSeconds()).padStart(2, '0');
        return `${hours}:${minutes}:${seconds} ${day}/${month}/${year}`;
    }

    $(document).ready(function () {
        loadLichSuCheckIn();
    });
</script>


</html>
