<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./taoPhieuNhapKho.css" />
    <title>Chi tiết phiếu nhập kho</title>
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
                                <h2>Phiếu Nhập Kho</h2>
                                <div style="margin-left: auto;">
                                    <button style="font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; color: rgb(65, 64, 64); border: 1px solid rgb(65, 64, 64); background-color: white; padding: 1rem; border-radius: 0.6rem; cursor: pointer;" onclick="clearSelectedProducts()">
                                        <a href="QLPhieuNhapKho.php">
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
                                    <table style="border-collapse: collapse; width: 100%; margin-top: 1rem; border-radius: 1rem;">
                                        <thead>
                                            <tr style="background-color: rgb(40, 40, 40); color: white;">
                                                <th style="padding: 0.5rem;">Mã Sản Phẩm</th>
                                                <th style="padding: 0.5rem;">Tên Sản Phẩm</th>
                                                <th style="padding: 0.5rem;">Ảnh</th>
                                                <th style="padding: 0.5rem;">Đơn giá</th>
                                                <th style="padding: 0.5rem;">Số lượng</th>
                                                <th style="padding: 0.5rem;">Lợi nhuận</th>
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
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Tên nhà cung cấp</p>
                                        <input id="supplierName"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #FF9800; border-radius: 0.5rem; text-align: center;"
                                            value=""
                                            disabled />
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Số điện thoại</p>
                                        <input id="supplierPhone"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                            value=""
                                            disabled />
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Nguời quản lý</p>
                                        <input id="managerName"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid rgb(34, 49, 184); border-radius: 0.5rem; text-align: center;"
                                            value=""
                                            disabled />
                                    </label>

                                    <label style="display: block;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Tổng giá trị</p>
                                        <input id="totalAmount"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #F44336; border-radius: 0.5rem; text-align: center;"
                                            value=""
                                            disabled />
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



<script>
    $(document).ready(function() {
        checkMaPhieuInUrl()
    });

    function loadDataAllWhenUrlHaveId(maPhieu) {
        const token = sessionStorage.getItem("token");

        $.ajax({
            url: `${window.env.API_ROOT}/inventory-report/${maPhieu}`, // Cập nhật URL nếu cần
            type: 'GET',
            dataType: "json",
            headers: {
                'Authorization': 'Bearer ' + token
            },
            success: function(response) {
                let inventoryReport = response.data;
                $("#id").val(inventoryReport.id);
                $("#supplierName").val(inventoryReport.supplier.name);
                $("#supplierPhone").val(inventoryReport.supplier.phone);
                $("#managerName").val(inventoryReport.profile.fullname);

                // Định dạng số tiền với dấu phân cách hàng nghìn
                $("#totalAmount").val(formatCurrency(inventoryReport.totalAmount));

                var productData = inventoryReport.inventoryReportDetails;
                console.log(productData)
                var selectedProducts = [];
                var selectedProducts = productData.map(function(product) {
                    return {
                        id: product.productId.toString(),
                        name: product.productName,
                        donGia: product.quantity,
                        soLuong: product.unitPrice,
                        loiNhuan: product.profit

                    };
                });
                localStorage.setItem('selectedProducts', JSON.stringify(selectedProducts));

                // Cập nhật bảng sản phẩm
                var tableBody = document.getElementById("tableBody");
                tableBody.innerHTML = ""; // Xóa nội dung cũ của bảng

                productData.forEach(function(product) {
                    var selectedProductHTML = `
                <tr style="text-align: center;">
                    <td style="padding: 0.5rem;" name="MaSanPham[]">${product.productId}</td>
                    <td style="padding: 0.5rem;">${product.productName}</td>
                       <td style="text-align: center; vertical-align: middle;">
                                <img style="max-width: 100px; height: auto; border-radius: 8px; object-fit: cover;" 
                                    src="${window.env.CLOUDINARY_API}/${product.productImage}" 
                                    alt="Product Image">
                            </td>
                    <td style="padding: 0.5rem;">
                        <input type="text" name="donGia[]" id="donGia${product.productId}" onblur="formatCurrency(this)" onfocus="clearFormat(this)" value="${formatCurrency1(product.unitPrice)}" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;">
                    </td>
                    <td style="padding: 0.5rem;">
                        <input type="text" name="soLuong[]" id="soLuong${product.productId}" value="${product.quantity}" onblur="validateSoLuong(this)" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;">
                    </td>
                      <td style="padding: 0.5rem;">
                        <input type="text" name="loiNhuan[]" id="loiNhuan${product.productId}" value="${product.profit}" onblur="validateSoLuong(this)" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;">
                    </td>
                </tr>`;
                    tableBody.insertAdjacentHTML('beforeend', selectedProductHTML);
                });



                document.querySelectorAll('input[name="donGia[]"], input[name="soLuong[]"],input[name="loiNhuan[]"]').forEach(function(input) {
                    input.disabled = true;
                });
                document.getElementById('manhacungcap').disabled = true;
                document.getElementById('sodienthoainhacungcap').disabled = true;

            },
            error: function(xhr, status, error) {
                console.error('Lỗi khi gọi API: ', error);
            }
        });
    }


    function checkMaPhieuInUrl() {
        // Lấy các tham số từ URL
        const urlParams = new URLSearchParams(window.location.search);
        const maPhieu = urlParams.get('MaPhieu');

        // Nếu MaPhieu tồn tại trong URL
        if (maPhieu) {
            loadDataAllWhenUrlHaveId(maPhieu);
        }
    }

    function clearCurrencyFormat(currencyString) {
        return currencyString.replace(/[^\d]/g, '');
    }


    function formatCurrency1(input) {
        let value = parseFloat(input); // Chuyển đổi đầu vào thành số
        if (!isNaN(value)) {
            // Định dạng tiền tệ Việt Nam
            return value.toLocaleString('vi-VN', {
                style: 'currency',
                currency: 'VND'
            });
        } else {
            console.error('Input must be a number.');
            return '';
        }
    }

    function clearFormat(input) {
        let value = input.value;
        value = value.replace(/[,]/g, ''); // Loại bỏ dấu phân cách hàng nghìn
        input.value = value;
    }



    function calculateTotalPrice() {
        var totalPrice = 0; // Biến lưu tổng giá trị
        var tableRows = document.querySelectorAll('#tableBody tr'); // Lấy tất cả các dòng trong bảng

        // Duyệt qua từng dòng để tính tổng
        tableRows.forEach(function(row) {
            var quantityCell = row.querySelector('input[name="soLuong[]"]'); // Ô số lượng
            var priceCell = row.querySelector('input[name="donGia[]"]'); // Ô đơn giá

            // Kiểm tra nếu các ô tồn tại và có giá trị hợp lệ
            if (quantityCell && priceCell) {
                var quantity = parseInt(quantityCell.value) || 0; // Chuyển đổi số lượng thành số, nếu không hợp lệ thì mặc định là 0
                var price = parseFloat(priceCell.value.replace(/,/g, '')) || 0; // Chuyển đổi giá thành số, loại bỏ dấu phẩy nếu có, nếu không hợp lệ thì mặc định là 0

                // Tính giá trị cho dòng này và cộng vào tổng
                totalPrice += quantity * price;
            }
        });

        // Định dạng lại tổng giá trị thành chuỗi tiền tệ
        var formattedTongGiaTri = totalPrice.toLocaleString('vi-VN', {
            style: 'currency',
            currency: 'VND'
        });

        // Cập nhật vào ô hiển thị tổng giá trị
        var totalPriceElement = document.getElementById('totalvalue');
        if (totalPriceElement) {
            totalPriceElement.value = formattedTongGiaTri; // Gán giá trị đã định dạng vào ô tổng giá trị
        }
    }

    // Gọi hàm khi trang được tải
    window.onload = checkMaPhieuInUrl;
</script>