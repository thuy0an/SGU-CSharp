<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="taoPhieuNhapKho.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"
        integrity="sha512-9usAa10IRO0HhonpyAIVpjrylPvoDwiPUiKdWk5t3PyolY1cOd4DSE0Ga+ri4AuTroPR5aQvXU9xC6qOPnzFeg=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
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

                                    <button id="addsp"
                                        style="margin-left: 1rem; font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; background-color: rgb(65, 64, 64); padding: 1rem; border-radius: 0.6rem; cursor: pointer;"
                                        onclick="setShowModal(true)">
                                        Thêm Sản Phẩm
                                    </button>
                                </div>
                            </div>
                            <div class="boxFeature d-flex flex-wrap" style="gap: 2rem;" id="boxFeature">
                                <?php if (!isset($_GET['MaPhieu'])) echo '
    <button style="margin-left: 1rem; font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; background-color: rgb(65, 64, 64); padding: 1rem; border-radius: 0.6rem; cursor: pointer;" onclick="handleSubmit()">
        Tạo phiếu xuất
    </button>'; ?>
                            </div>



                            <div class="boxTable">
                                <div style="background-color: rgb(236, 233, 233); width: 75%;">
                                    <table
                                        style="border-collapse: collapse; width: 100%; margin-top: 1rem; border-radius: 1rem;">
                                        <thead>
                                            <tr style="background-color: rgb(40, 40, 40); color: white;">
                                                <th style="padding: 0.5rem;">Mã Sản Phẩm</th>
                                                <th style="padding: 0.5rem;width: 477px;">Tên Sản Phẩm</th>
                                                <th style="padding: 0.5rem;">Đơn giá</th>
                                                <th style="padding: 0.5rem;">Số lượng</th>
                                                <th style="padding: 0.5rem;">Thao tác</th>

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
                                            value="" />
                                        <p id="customerNameError" style="color: red; margin-top: 0.25rem;"></p>
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Số điện thoại khách
                                            hàng</p>
                                        <input id="customerPhone"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                            value="" />
                                        <p id="customerPhoneError" style="color: red; margin-top: 0.25rem;"></p>
                                    </label>

                                    <label style="display: block; margin-bottom: 1rem;">
                                        <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Email khách
                                            hàng</p>
                                        <input id="customerEmail"
                                            style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                                border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                            value="" />
                                        <p id="customerEmailError" style="color: red; margin-top: 0.25rem;"></p>
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

    <div class="modal_overlay" style="<?php
                                        if (isset($_GET['MaPhieu'])) {
                                            echo 'display:none';
                                        };
                                        ?>">
        <div class="modal_content">
            <!-- Đầu modal_content -->
            <span class="close_btn">
                <h3>Chọn Sản Phẩm</h3>
                <i onclick="setShowModal(false)">X</i>
            </span>
            <div style="margin-top: 1rem;">
                <div style="position: relative;">
                    <i class="fa fa-search"></i>
                    <input class="input" placeholder="Tìm kiếm sản phẩm" id="timkiemsp"
                        onkeyup="handleSearchChange(event)" />
                </div>
                <div class="table_wrapper">
                    <table class="product_table">
                        <thead>
                            <tr style="background-color: rgb(40, 40, 40); color: white;">
                                <th style="padding: 0.5rem;">Mã Sản Phẩm</th>
                                <th style="padding: 0.5rem;width: 477px;">Tên Sản Phẩm</th>
                                <th style="padding: 0.5rem;">Đơn giá</th>
                                <th style="padding: 0.5rem;">Thao Tác</th>
                            </tr>
                        </thead>
                        <tbody id="tableBody1">
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="pagination" id="pagination"></div>
        </div>
    </div>

</body>



<script>
    function isNewProduct(productId) {
        return productId && productId.startsWith('new-');
    }

    // Hàm để lưu trạng thái của sản phẩm (đã chọn/chưa chọn)
    function saveProductState(productId, isSelected) {
        let productStates = JSON.parse(localStorage.getItem('productStates')) || {};
        productStates[productId] = isSelected;
        localStorage.setItem('productStates', JSON.stringify(productStates));
    }

    // Hàm để lấy trạng thái của sản phẩm
    function getProductState(productId) {
        let productStates = JSON.parse(localStorage.getItem('productStates')) || {};
        return productStates[productId] || false; // Trả về false nếu không tìm thấy
    }

    $(document).on('change', '.product_checkbox', function() {
        let productId = $(this).attr('id');
        let isChecked = $(this).prop('checked');

        // Lưu trạng thái của sản phẩm
        saveProductState(productId, isChecked);

        saveSelectedProducts(); // Lưu trạng thái của các sản phẩm đã chọn

        // Xóa nội dung hiện tại của bảng
        $('#tableBody').empty();

        let selectedProducts = JSON.parse(localStorage.getItem('selectedProducts')) || [];

        selectedProducts.forEach(function(product, index) {
            var selectedProductHTML = `
        <tr style="text-align: center;" data-product-id="${product.id}">
            <td style="padding: 0.5rem;" name="MaSanPham[]">${!isNewProduct(product.id) ? product.id : ''}</td>
            <td style="padding: 0.5rem;">${product.name}</td>
            <td style="padding: 0.5rem;">
                <input type="text" name="donGia[]" id="donGia${product.id}" value="${product.donGiaFormatted}" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;" disabled>
                <input type="hidden" name="donGiaHidden[]" value="${product.donGia}">
            </td>
            <td style="padding: 0.5rem;">
                <input type="text" name="soLuong[]" id="soLuong${product.id}" value="${product.soLuong}" onblur="validateSoLuong(this)" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;">
            </td>
            <td style="padding: 0.5rem;">
                <button class="delete-btn" data-index="${index}" style="color: red; font-weight: 700; background: none; border: none; cursor: pointer;">X</button>
            </td>
        </tr>`;
            $('#tableBody').append(selectedProductHTML);
        });

        // Gọi ngay tính tổng sau khi thêm sản phẩm vào bảng
        calculateTotalPrice(); // Tính toán lại tổng giá trị ngay sau khi thêm sản phẩm
    });

    function handleSubmit() {
        // Validate form data
        if (!validateForm()) {
            return false;
        }

        // Lấy dữ liệu từ localStorage
        const selectedProducts = JSON.parse(localStorage.getItem('selectedProducts')) || [];
        const token = sessionStorage.getItem("token");

        // Lấy thông tin khách hàng từ form
        const customerName = document.getElementById('customerName').value.trim();
        const customerPhone = document.getElementById('customerPhone').value.trim();
        const customerEmail = document.getElementById('customerEmail').value.trim();

        // Kiểm tra xem có sản phẩm nào được chọn không
        if (selectedProducts.length === 0) {
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: 'Vui lòng chọn ít nhất một sản phẩm.',
            });
            return false;
        }

        // Tạo mảng details để chứa thông tin sản phẩm theo yêu cầu của API
        const details = selectedProducts.map(product => ({
            stockLotId: product.id, // Sử dụng product.id làm stockLotId
            quantity: parseInt(product.soLuong, 10) // Lấy số lượng từ product.soLuong và ép kiểu về số nguyên
        }));

        // Tạo đối tượng dữ liệu để gửi lên API
        const requestData = {
            customerName: customerName,
            customerPhone: customerPhone,
            customerEmail: customerEmail,
            details: details
        };

        // Gửi yêu cầu AJAX
        $.ajax({
            type: 'POST',
            url: `${window.env.API_ROOT}/inventory-export-reports`,
            contentType: 'application/json', // Important: Set Content-Type to JSON
            data: JSON.stringify(requestData), // Convert data to JSON string
            headers: {
                'Authorization': 'Bearer ' + token,
            },
            success: function(response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Thành công',
                    text: 'Tạo phiếu Xuất kho thành công',
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = 'QLPhieuXuatKho.php';
                    }
                });
            },
            error: function(xhr, status, error) {
                console.error('Đã xảy ra lỗi khi gửi yêu cầu.', xhr.responseText); // Log đầy đủ response để debug
                try {
                    const errorResponse = JSON.parse(xhr.responseText);
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: errorResponse.message || 'Đã xảy ra lỗi. Vui lòng kiểm tra lại.', // Hiển thị thông báo lỗi từ API nếu có
                    });
                } catch (e) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: 'Đã xảy ra lỗi không xác định. Vui lòng kiểm tra console.',
                    });
                }

            }
        });

        return false; // Prevent default form submission (if applicable)

    }

    function validateForm() {
        let isValid = true;

        // Validate Customer Name
        const customerName = document.getElementById('customerName').value.trim();
        if (customerName === '') {
            document.getElementById('customerNameError').textContent = 'Vui lòng nhập tên khách hàng.';
            isValid = false;
        } else {
            document.getElementById('customerNameError').textContent = '';
        }

        // Validate Customer Phone
        const customerPhone = document.getElementById('customerPhone').value.trim();
        if (customerPhone === '') {
            document.getElementById('customerPhoneError').textContent = 'Vui lòng nhập số điện thoại khách hàng.';
            isValid = false;
        } else if (!validatePhoneNumber(customerPhone)) {
            isValid = false; // validatePhoneNumber hiển thị lỗi rồi
        } else {
            document.getElementById('customerPhoneError').textContent = '';
        }

        // Validate Customer Email
        const customerEmail = document.getElementById('customerEmail').value.trim();
        if (customerEmail === '') {
            document.getElementById('customerEmailError').textContent = 'Vui lòng nhập email khách hàng.';
            isValid = false;
        } else if (!validateEmail(customerEmail)) {
            document.getElementById('customerEmailError').textContent = 'Email không hợp lệ.';
            isValid = false;
        } else {
            document.getElementById('customerEmailError').textContent = '';
        }

        return isValid;
    }

    function validateEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(email);
    }

    function saveSelectedProducts() {
        let selectedProducts = JSON.parse(localStorage.getItem('selectedProducts')) || [];

        let selectedMap = new Map(selectedProducts.map(product => [product.id, product]));

        $('input[type="checkbox"]').each(function() {
            let productId = $(this).attr('id');
            let productName = $(this).closest('tr').find('td:eq(1)').text().trim();

            // Lấy đơn giá từ thuộc tính data của checkbox
            let donGia = $(this).data('price');

            // Định dạng đơn giá
            let donGiaFormatted = formatCurrency1(donGia);

            let soLuongElement = document.getElementById(`soLuong${productId}`);
            let soLuong = soLuongElement ? soLuongElement.value : "1";

            if ($(this).prop('checked')) {
                if (selectedMap.has(productId)) {
                    let product = selectedMap.get(productId);
                    product.soLuong = soLuong;
                } else {
                    selectedMap.set(productId, {
                        id: productId,
                        name: productName,
                        donGia: donGia,
                        donGiaFormatted: donGiaFormatted,
                        soLuong: soLuong,
                    });
                }
            } else {
                // Xóa sản phẩm khỏi selectedMap nếu checkbox không được chọn
                selectedMap.delete(productId);
            }
        });

        localStorage.setItem('selectedProducts', JSON.stringify([...selectedMap.values()]));
        calculateTotalPrice();
    }


    $(document).on('input', 'input[name="soLuong[]"]', function() {
        calculateTotalPrice();
        saveSelectedProducts();
    });


    function loadSelectedProducts() {
        let selectedProducts = JSON.parse(localStorage.getItem('selectedProducts')) || [];
        let selectedIds = new Set(selectedProducts.map(product => product.id));

        $('.product_checkbox').each(function() {
            // Kiểm tra trạng thái từ localStorage
            let productId = $(this).attr('id');
            let isSelected = getProductState(productId); // Lấy trạng thái từ localStorage

            $(this).prop('checked', isSelected);
            $(this).prop('checked', selectedIds.has($(this).attr('id')));
        });
    }




    $(document).on('click', '.delete-btn', function() {
        let index = $(this).data('index');

        let selectedProducts = JSON.parse(localStorage.getItem('selectedProducts')) || [];

        // Lấy productId của sản phẩm bị xóa
        let productIdToDelete = selectedProducts[index].id;

        // Xóa sản phẩm theo chỉ số (index) khỏi danh sách
        selectedProducts.splice(index, 1);

        // Cập nhật lại localStorage với danh sách đã được cập nhật
        localStorage.setItem('selectedProducts', JSON.stringify(selectedProducts));

        // Xóa trạng thái đã lưu của sản phẩm
        saveProductState(productIdToDelete, false);

        // Làm mới bảng hiển thị
        $('#tableBody').empty();
        loadSelectedProducts();
        // Hiển thị lại sản phẩm còn lại
        selectedProducts.forEach(function(product, index) {
            var selectedProductHTML = `
        <tr style="text-align: center;" data-product-id="${product.id}">
            <td style="padding: 0.5rem;" name="MaSanPham[]">${product.id}</td>
            <td style="padding: 0.5rem;">${product.name}</td>
            <td style="padding: 0.5rem;">
                <input type="text" name="donGia[]" id="donGia${product.id}" value="${product.donGiaFormatted}" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;" disabled>
                <input type="hidden" name="donGiaHidden[]" value="${product.donGia}">
            </td>
            <td style="padding: 0.5rem;">
                <input type="text" name="soLuong[]" id="soLuong${product.id}" value="${product.soLuong}" onblur="validateSoLuong(this)" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;">
            </td>
            <td style="padding: 0.5rem;">
                <button class="delete-btn" data-index="${index}" style="color: red; font-weight: 700; background: none; border: none; cursor: pointer;">X</button>
            </td>
        </tr>`;
            $('#tableBody').append(selectedProductHTML);
        });
        calculateTotalPrice();
    });

    function validateSoLuong(input) {
        var soLuong = parseInt(input.value);
        if (soLuong < 1 || isNaN(soLuong)) {
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: "Số lượng phải là một số nguyên lớn hơn hoặc bằng 1",
            });
            input.value = "1";
        }
    }
    let currentSearch = ''; // Biến toàn cục để lưu trữ giá trị tìm kiếm hiện tại
    function handleSearchChange(event) {
        // Lưu giá trị tìm kiếm và gọi hàm load dữ liệu cho trang đầu tiên
        currentSearch = event.target.value.trim();
        loaddatasp(1, currentSearch);
    }

    function loaddatasp(page, search) {
        const token = sessionStorage.getItem("token");
        $('#tableBody1').empty();
        let ajaxData = {
            pageNumber: page
        };
        if (search) {
            ajaxData.search = search;
        }
        $.ajax({
            url: 'http://localhost:8080/api/products/management',
            type: 'GET',
            dataType: "json",
            data: ajaxData,
            headers: {
                'Authorization': 'Bearer ' + token
            },
            success: function(response) {
                var data = response.data.content;
                var tableBody = document.getElementById("tableBody1");
                var tableContent = "";
                data.forEach(function(record) {
                    var productId = record['id'];
                    var isChecked = getProductState(productId);
                    let donGiaFormatted = formatCurrency1(record['price']);
                    var trContent = `
                <tr style="text-align: center;">
                    <td style="padding: 0.5rem;">${record['id']}</td>
                    <td style="padding: 0.5rem;width: 477px;">${record['productName']}</td>
                     <td style="padding: 0.5rem;">${donGiaFormatted}</td>
                    <td style="padding: 0.5rem;">
                        <input type="checkbox" class="product_checkbox" id="${record['id']}" data-price="${record['price']}" ${isChecked ? 'checked' : ''}/>
                    </td>
                </tr>`;
                    tableContent += trContent;
                });
                tableBody.innerHTML = tableContent;
                loadSelectedProducts();
                createPagination(page, response.data.totalPages);
            },
            error: function(xhr, status, error) {
                console.error('Lỗi khi gọi API: ', error);
            }
        });
    }

    function createPagination(currentPage, totalPages) {
        var paginationContainer = document.getElementById("pagination");
        paginationContainer.innerHTML = '';
        if (totalPages > 1) {
            var paginationHTML = '';
            for (var i = 1; i <= totalPages; i++) {
                paginationHTML += '<button class="pageButton">' + i + '</button>';
            }
            paginationContainer.innerHTML = paginationHTML;
            paginationContainer.querySelectorAll('.pageButton').forEach(function(button, index) {
                button.addEventListener('click', function() {
                    loaddatasp(index + 1, currentSearch);
                });
            });
            paginationContainer.querySelector('.pageButton:nth-child(' + currentPage + ')').classList.add('active');
        }
    }
    $(document).ready(function() {
        localStorage.removeItem('selectedProducts');
        if (!checkMaPhieuInUrl()) {
            loadSelectedProducts();
            loaddatasp(1, '');
        }
    });

    function loadDataAllWhenUrlHaveId(maPhieu) {
        const token = sessionStorage.getItem("token");
        $.ajax({
            url: 'http://localhost:8080/InventoryReport/' + maPhieu,
            type: 'GET',
            dataType: "json",
            headers: {
                'Authorization': 'Bearer ' + token
            },
            success: function(response) {
                var maPNK = document.getElementById("maPNK");
                maPNK.value = response.id;
                var totalValue = document.getElementById('totalvalue');
                totalValue.value = formatCurrency1(response.totalPrice);
                var productData = response.inventoryReportDetails;
                var selectedProducts = [];
                var selectedProducts = productData.map(function(product) {
                    return {
                        id: product.productId.toString(),
                        name: product.productName,
                        donGia: product.unitPrice,
                        donGiaFormatted: formatCurrency1(product.unitPrice),
                        soLuong: product.quantity
                    };
                });
                localStorage.setItem('selectedProducts', JSON.stringify(selectedProducts));
                var tableBody = document.getElementById("tableBody");
                tableBody.innerHTML = ""; // Xóa nội dung cũ của bảng
                productData.forEach(function(product) {
                    var selectedProductHTML = `
                     <tr style="text-align: center;" data-product-id="${product.productId}">
                        <td style="padding: 0.5rem;" name="MaSanPham[]">${product.productId}</td>
                        <td style="padding: 0.5rem;">${product.productName}</td>
                        <td style="padding: 0.5rem;">
                            <input type="text" name="donGia[]" id="donGia${product.productId}" value="${formatCurrency1(product.unitPrice)}" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;" disabled>
                            <input type="hidden" name="donGiaHidden[]" value="${product.unitPrice}">
                        </td>
                        <td style="padding: 0.5rem;">
                            <input type="text" name="soLuong[]" id="soLuong${product.productId}" value="${product.quantity}" onblur="validateSoLuong(this)" style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; margin-top: 0.5rem;text-align: right;">
                        </td>
                        <td style="padding: 0.5rem;">
                            <button class="delete-btn" data-index="${index}" style="color: red; font-weight: 700; background: none; border: none; cursor: pointer;">X</button>
                        </td>
                    </tr>`;
                    tableBody.insertAdjacentHTML('beforeend', selectedProductHTML);
                });

                loaddatasp(1, '');
                loadSelectedProducts();
                document.querySelectorAll('input[name="donGia[]"], input[name="soLuong[]"]').forEach(function(input) {
                    input.disabled = true;
                });
                document.getElementById('addsp').style.display = 'none';
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

    function clearCurrencyFormat(currencyString) {
        return currencyString.replace(/[^\d]/g, '');
    }

    function formatCurrency(input) {
        let value = input.value;
        value = value.replace(/[^\d]/g, '');
        input.value = Number(value).toLocaleString('en-US');
    }

    function formatCurrency1(input) {
        let value = parseFloat(input);
        if (!isNaN(value)) {
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
        value = value.replace(/[,]/g, '');
        input.value = value;
    }

    function validatePhoneNumber(phoneNumber) {
        phoneNumber = phoneNumber.replace(/\D/g, '');
        if (!/^0\d{9,10}$/.test(phoneNumber)) {
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: 'Số điện thoại phải bắt đầu bằng số 0 và có từ 10 đến 11 chữ số.',
            });
            return false;
        }
        return true;
    }

    function validateEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(email);
    }

    function setShowModal(show) {
        var modalOverlay = document.querySelector('.modal_overlay');
        modalOverlay.style.display = show ? '' : 'none';
    }

    function clearSelectedProducts() {
        localStorage.removeItem('selectedProducts');
    }

    function calculateTotalPrice() {
        var totalPrice = 0;
        var tableRows = document.querySelectorAll('#tableBody tr');
        tableRows.forEach(function(row) {
            var quantityCell = row.querySelector('input[name="soLuong[]"]');
            var priceCell = row.querySelector('input[name="donGiaHidden[]"]');
            if (quantityCell && priceCell) {
                var quantity = parseInt(quantityCell.value) || 0;
                var price = parseFloat(priceCell.value) || 0;
                totalPrice += quantity * price;
            }
        });
        var formattedTongGiaTri = totalPrice.toLocaleString('vi-VN', {
            style: 'currency',
            currency: 'VND'
        });
        var totalPriceElement = document.getElementById('totalAmount');
        if (totalPriceElement) {
            totalPriceElement.value = formattedTongGiaTri;
        }
    }
    window.onload = checkMaPhieuInUrl;
</script>

</html>