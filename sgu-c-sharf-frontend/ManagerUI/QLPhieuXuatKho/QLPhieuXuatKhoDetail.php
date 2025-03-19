<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./taoPhieuNhapKho.css" />
    <title>Chi tiết phiếu xuất kho</title>
</head>

<body>
    <div id="root">
        <div class="App">
            <div class="StaffLayout_wrapper__CegPk">
                <?php require_once "../ManagerHeader.php" ?>

                <div class="Manager_wrapper__vOYy">
                    <?php require_once "../ManagerMenu.php" ?>

                    <div style="padding-left: 16%; width: 100%; padding-right: 2rem">
                        <div class="wrapper">
                            <div style="display: flex; padding-top: 1rem; padding-bottom: 1rem;">
                                <h2>Phiếu Xuất Kho</h2>
                                <div style="margin-left: auto;">
                                    <button
                                        style="font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; color: rgb(65, 64, 64); border: 1px solid rgb(65, 64, 64); background-color: white; padding: 1rem; border-radius: 0.6rem; cursor: pointer;"
                                        onclick="clearSelectedProducts()">
                                        <a href="QLPhieuXuatKho.php">
                                            <?php
                                            if (!isset($_GET['MaPhieu'])) echo 'Hủy';
                                            else echo 'Quay lại';
                                            ?>
                                        </a>
                                    </button>
                                </div>
                            </div>

                            <div class="boxTable">
                                <div style="background-color: rgb(236, 233, 233); width: 75%;">
                                    <table
                                        style="border-collapse: collapse; width: 100%; margin-top: 1rem; border-radius: 1rem;">
                                        <thead>
                                            <tr style="background-color: rgb(40, 40, 40); color: white;">
                                                <th style="padding: 0.5rem;">Mã Sản Phẩm</th>
                                                <th style="padding: 0.5rem;">Tên Sản Phẩm</th>
                                                <th style="padding: 0.5rem;">Ảnh</th>
                                                <th style="padding: 0.5rem;">Đơn giá</th>
                                                <th style="padding: 0.5rem;">Số lượng</th>
                                                <th style="padding: 0.5rem;">Tổng</th>
                                                <!-- <th style="padding: 0.5rem;">Lý do xuất</th> -->
                                            </tr>
                                        </thead>
                                        <tbody id="tableBody">
                                        </tbody>
                                    </table>
                                </div>
                                <div style="
                                    width: 25%; 
                                    background-color: rgb(236, 233, 233); 
                                    padding: 1.5rem; 
                                    border-radius: 1rem; 
                                    box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
                                    font-family: Arial, sans-serif;">

                                    <h2 style="
                                        text-align: center; 
                                        font-size: 1.5rem; 
                                        font-weight: 700; 
                                        margin-bottom: 1rem; 
                                        color: white; 
                                        background-color: black; 
                                        padding: 0.75rem; 
                                        border-radius: 0.5rem;">
                                        Thông tin phiếu
                                    </h2>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Mã phiếu</p>
                                        <input id="id"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #4CAF50; border-radius: 0.5rem; text-align: center;"
                                            value="<?php if (isset($_GET['MaPhieu'])) echo $_GET['MaPhieu']; ?>"
                                            disabled />
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Tên khách hàng</p>
                                        <input id="customerName"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #FF9800; border-radius: 0.5rem; text-align: center;"
                                            value="" disabled />
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Số điện thoại khách
                                            hàng</p>
                                        <input id="customerPhone"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                            value="" disabled />
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Email khách
                                            hàng</p>
                                        <input id="customerEmail"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                            value="" disabled />
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày tạo</p>
                                        <input id="createTime"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid rgb(34, 49, 184); border-radius: 0.5rem; text-align: center;"
                                            value="" disabled />
                                    </label>

                                    <label style="display: block;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Tổng giá trị</p>
                                        <input id="totalAmount"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #F44336; border-radius: 0.5rem; text-align: center;"
                                            value="" disabled />
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>

<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
<script>
    $(document).ready(function() {
        checkMaPhieuInUrl()
    });

    function loadDataAllWhenUrlHaveId(maPhieu) {
        const token = sessionStorage.getItem("token");

        $.ajax({
            url: `${window.env.API_ROOT}/inventory-export-reports/${maPhieu}`,
            type: 'GET',
            dataType: "json",
            headers: {
                'Authorization': 'Bearer ' + token
            },
            success: function(response) {
                if (response.status === 200) {
                    const exportReport = response.data;
                    $("#id").val(exportReport.id);
                    $("#customerName").val(exportReport.customerName);
                    $("#customerPhone").val(exportReport.customerPhone);
                    $("#customerEmail").val(exportReport.customerEmail);
                    $("#createTime").val(formatDateTime(exportReport.createdAt));

                    $("#totalAmount").val(formatCurrency(exportReport.totalAmount));

                    const productData = exportReport.details;

                    const tableBody = document.getElementById("tableBody");
                    tableBody.innerHTML = "";

                    productData.forEach(function(product) {
                        let selectedProductHTML = `
                            <tr style="text-align: center;">
                                <td style="padding: 0.5rem;" name="MaSanPham[]">${product.productId}</td>
                                <td style="padding: 0.5rem;">${product.productName}</td>
                                <td style="text-align: center; vertical-align: middle;">
                                    <img style="max-width: 100px; height: auto; border-radius: 8px; object-fit: cover;" 
                                         src="${window.env.CLOUDINARY_API}/${product.productImage}" 
                                         alt="Product Image">
                                </td>
                                <td style="padding: 0.5rem;">${formatCurrency(product.price)}</td>
                                <td style="padding: 0.5rem;">${product.quantity}</td>
                                <td style="padding: 0.5rem;">${formatCurrency(product.total)}</td>
                            </tr>`;
                        tableBody.insertAdjacentHTML('beforeend', selectedProductHTML);
                    });
                } else {
                    console.error("API returned an error:", response.message);
                }
            },
            error: function(xhr, status, error) {
                console.error('Lỗi khi gọi API: ', error);
            }
        });
    }

    function checkMaPhieuInUrl() {
        const urlParams = new URLSearchParams(window.location.search);
        const maPhieu = urlParams.get('MaPhieu');

        if (maPhieu) {
            loadDataAllWhenUrlHaveId(maPhieu);
        }
    }

    function formatCurrency(number) {
        return number.toLocaleString('vi-VN', {
            style: 'currency',
            currency: 'VND'
        });
    }

    function formatDateTime(dateTimeString) {
        if (!dateTimeString) return "";
        const date = new Date(dateTimeString);
        const hours = date.getHours().toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        const seconds = date.getSeconds().toString().padStart(2, '0');
        const day = date.getDate().toString().padStart(2, '0');
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const year = date.getFullYear();
        return `${hours}:${minutes}:${seconds} ${day}/${month}/${year}`;
    }
</script>

</html>