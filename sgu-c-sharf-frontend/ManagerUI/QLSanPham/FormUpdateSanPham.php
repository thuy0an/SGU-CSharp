<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../QLTaiKhoan/UserUpdate.css" />
    <link rel="stylesheet" href="../QLTaiKhoan/oneForAll.css" />
    <title>Cập nhật sản phẩm số <?php echo $_GET['maSanPham'] ?></title>
</head>
<style>
    table {
    border-collapse: separate; 
    border-spacing: 5px; /* Khoảng cách giữa các ô */
}

</style>
<body>
    <div class="StaffLayout_wrapper__CegPk">
        <?php require_once "../ManagerHeader.php" ?>


        <div class="Manager_wrapper__vOYy">
            <div style="padding-left: 3%; width: 100%; padding-right: 2rem">
                <div class="wrapper">
                    <div style="display: flex; padding-top: 1rem; align-items: center; gap: 1rem; padding-bottom: 1rem;"></div>
                    <form id="submit-form" method="post">
                        <div class="boxFeature">
                            <div>
                                <h2 style="font-size: 2.3rem">Update sản phẩm mới</h2>
                            </div>
                            <div>
                                <a style="font-family: Arial; font-size: 1.5rem; font-weight: 700; border: 1px solid rgb(140, 140, 140); background-color: white; color: rgb(80, 80, 80); padding: 1rem 2rem 1rem 2rem; border-radius: 0.6rem; cursor: pointer;" href="QLSanPham.php">Quay lại</a>
                                <button id="updateUser_save" style="margin-left: 1rem; font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; background-color: rgb(65, 64, 64); padding: 1rem 2rem 1rem 2rem; border-radius: 0.6rem; cursor: pointer;">Lưu</button>
                            </div>
                        </div>
                        <div class="boxTable">
                            <div style="display: flex; padding: 0rem 1rem 0rem 1rem; justify-content: space-around;">
                                <div style="padding-left: 1rem; margin-left: 25px;">

                                    <p class="text">Tên sản phẩm</p>
                                    <input disabled id="tenSanPham" class="input" type="text" name="tenSanPham" style="width: 40rem" />
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>


                                    <p class="text">Xuất xứ</p>
                                    <input id="xuatXu" class="input" name="xuatXu" style="width: 40rem" />
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Loại sản phẩm</p>
                                    <select name="loaiSanPham" id="loaiSanPham" class="input" style="width: 40rem; background-color: white;">
                                        <!-- Options sẽ được thêm từ JavaScript -->
                                    </select>
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Thương hiệu</p>
                                    <select id="thuongHieu" class="input" name="thuongHieu" style="width: 40rem; background-color: white;">
                                        <!-- Options sẽ được thêm từ JavaScript -->
                                    </select>
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                

                                    <p class="text">Thể tích (ml)</p>
                                    <input id="theTich" class="input" type="text" name="theTich" style="width: 40rem" />
                                    <span style="margin-left: 1rem; font-weight: 700; ">*</span>

                                    <p class="text">Nồng độ cồn (%)</p>
                                    <input id="nongDoCon" type="text" class="input" name="nongDoCon" style="width: 40rem" />
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                
                                    <p class="text">Trạng thái</p>
                                    <input disabled id="status" class="input" name="status" style="width: 40rem" readonly />

                                    <p class="text">Thời gian tạo</p>
                                    <input disabled id="createTime" class="input" name="createTime" style="width: 40rem" readonly />

                                    <p class="text">Mô tả sản phẩm</p>
                                    <textarea id="moTa" class="input" name="moTa" style="width: 40rem; height: 8rem;" rows="4" cols="50"></textarea>
                                </div>

                                <table style="margin: 0 30px; width: 40%; height: 400px; border-collapse: collapse; text-align: center; border-radius: 8px; overflow: hidden; box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);">
                                <!-- <p class="text" style="font-weight: bold; font-size: 1.2rem; margin-top: 1rem;">Tồn kho (StockLot)</p> -->
                                    
                                <thead style="background-color: #f4f4f4;">
                                        <tr>
                                            <th style="border: 1px solid #ddd; padding: 10px;">ID</th>
                                            <th style="border: 1px solid #ddd; padding: 10px;">Số lượng</th>
                                            <th style="border: 1px solid #ddd; padding: 10px;">Số lượng tối đa</th>
                                            <th style="border: 1px solid #ddd; padding: 10px;">Ngày nhập</th>
                                        </tr>
                                    </thead>
                                    <tbody id="stockLotTableBody" style="background-color: white;">
                                        <!-- Dữ liệu sẽ được thêm vào đây -->
                                    </tbody>
                                </table>





                                <div style="display: flex; flex-direction: column; justify-content: center; align-items: center;">
                                    <p class="text">Ảnh minh họa</p>
                                    <img id="xuatAnh" style="width: 350px; height: 400px;" alt="">
                                    <input id="anhMinhHoa" type="file" name="anhMinhHoa" accept="image/*">

                                    <div id="batch" style="padding-left: 1rem; margin-left: 25px;">


                                    </div>

                                </div>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>
        
    </div>
</body>


<script>
    const userRole = sessionStorage.getItem('role');

    document.addEventListener('DOMContentLoaded', () => {
        getCategories();
        getBrand();
        fetchProductDetails(<?php echo $_GET['maSanPham'] ?>);
        // const adminButton = document.getElementById('updateUser_save');
        // if (userRole != 'Manager') {
        //     adminButton.style.display = 'none';
        // } else {
        //     console.log('Phần tử adminButton không tồn tại.');
        // }
    });
    
    let image = ""; // Biến lưu đường dẫn ảnh sau khi upload thành công

    document.getElementById("anhMinhHoa").addEventListener("change", function (event) {
        uploadImage(event.target.files[0]); // Lấy file ảnh đầu tiên và upload
    });

    function uploadImage(file) {
        let formData = new FormData();
        formData.append("file", file);

        $.ajax({
            url: `${window.env.API_ROOT}/sale/media/upload`,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            // timeout: 10000, // Tăng timeout lên 60 giây
            success: function (response) {
                if (response.status === 200) {
                    image = response.data; // Gán đường dẫn ảnh vào biến image
                    console.log("Ảnh đã upload thành công:", image);

                    // Cập nhật thẻ <img> với đường dẫn ảnh mới
                    $("#xuatAnh").attr("src", `${window.env.CLOUDINARY_API}/${image}`);
                } else {
                    console.error("Lỗi khi upload ảnh:", response.message);
                }
            },
            error: function (xhr, status, error) {
                console.error("Lỗi khi kết nối API:", error);
            }
        });
    }


    document.getElementById("submit-form").addEventListener('submit', function check(event) {
        event.preventDefault(); // Ngăn chặn hành động mặc định của form

        let tenSanPham = document.getElementById("tenSanPham");
        let loaiSanPham = document.getElementById("loaiSanPham");
        let xuatXu = document.getElementById("xuatXu");
        let thuongHieu = document.getElementById("thuongHieu");
        let theTich = document.getElementById("theTich");
        let nongDoCon = document.getElementById("nongDoCon");
        let moTa = document.getElementById("moTa");


        if (parseFloat(theTich.value) <= 0 || isNaN(parseFloat(theTich.value))) {
            showErrorAlert('Lỗi!', 'Thể tích phải là số dương');
            theTich.focus();
            return;
        }

        if (parseFloat(nongDoCon.value) < 0 || parseFloat(nongDoCon.value) > 100 || isNaN(parseFloat(nongDoCon.value))) {
            showErrorAlert('Lỗi!', 'Nồng độ cồn phải là số dương và có giá trị từ 0 đến 100');
            nongDoCon.focus();
            return;
        }

        // Nếu mọi kiểm tra hợp lệ, gọi hàm updateSanPham
        updateSanPham(
            <?php echo $_GET['maSanPham'] ?>,
            xuatXu.value,
            theTich.value,
            nongDoCon.value,
            thuongHieu.value,
            loaiSanPham.value,
            moTa.value);

        
    });

    function fetchProductDetails(productId) {
        $.ajax({
            url: `${window.env.API_ROOT}/sale/products/management/${productId}`,
            type: 'GET',
            dataType: 'json',
            success: function(data) {
                // Điền dữ liệu vào form
                $('#tenSanPham').val(data.data.productName);
                $('#xuatXu').val(data.data.origin);
                $('#thuongHieu').val(data.data.brand.id); // Sử dụng ID của thương hiệu
                $('#loaiSanPham').val(data.data.category.id); // Sử dụng ID của loại sản phẩm
                $('#theTich').val(data.data.capacity);
                $('#nongDoCon').val(data.data.abv);
                $('#status').val(data.data.status ? 'Đang bán' : 'Ngừng bán'); // Trạng thái
                $('#createTime').val(data.data.createTime); // Thời gian tạo
                $('#moTa').val(data.data.description); // Mô tả

                // Cập nhật hình ảnh
                $('#xuatAnh').attr('src', window.env.CLOUDINARY_API + data.data.image);

                hienThiStockLot(data.data.stockLots);
            },
            error: function(xhr, status, error) {
                console.error('Error:', error);
            }
        });
    }

    function hienThiStockLot(stockLots) {
        let tableBody = document.querySelector("#stockLotTableBody");
        tableBody.innerHTML = ""; // Xóa nội dung cũ

        if (!stockLots || stockLots.length === 0) {
            tableBody.innerHTML = `<tr><td colspan="4">Không có dữ liệu tồn kho</td></tr>`;
            return;
        }

        stockLots.forEach(stockLot => {
            let row = document.createElement("tr");
            row.innerHTML = `
                <td>${stockLot.id}</td>
                <td>${stockLot.quantity}</td>
                <td>${stockLot.maxQuantity}</td>
                <td>${stockLot.receivingTime}</td>
            `;
            tableBody.appendChild(row);
        });
    }



    function showErrorAlert(title, message) {
        Swal.fire({
            title: title,
            text: message,
            icon: 'error',
            confirmButtonText: 'OK'
        });
    }

    function showSuccessAlert(title, message, redirectUrl) {
        Swal.fire({
            title: title,
            text: message,
            icon: 'success',
            confirmButtonText: 'OK'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = redirectUrl;
            }
        });
    }

    function updateSanPham(id,  xuatXu, theTich, nongDoCon, thuongHieu, maLoaiSanPham, moTa) {
        // Tạo đối tượng JSON để gửi lên server
        let sanPhamData = {
            id: id,
            categoryId: Number(maLoaiSanPham),
            origin: xuatXu,
            brandId: Number(thuongHieu),
            capacity: theTich,
            abv: nongDoCon,
            description: moTa,
            image: image // Nếu có ảnh thì lấy tên, nếu không thì null
        };

        $.ajax({
            url: `${window.env.API_ROOT}/sale/products/${id}`,
            type: 'PATCH',
            contentType: 'application/json', // Gửi dữ liệu dưới dạng JSON
            data: JSON.stringify(sanPhamData), // Chuyển đối tượng thành JSON
            success: function(data) {
                //Sau khi tạo xong chuyển về trang QLSanPham
                showSuccessAlert('Thành công!', 'Cập nhật sản phẩm thành công !!', 'QLSanPham.php');
            },
            error: function(xhr, status, error) {
                console.error('Error: ' + xhr.status + ' - ' + error);
            }
        });
    }

    function getCategories() {
        $.ajax({
            url: `${window.env.API_ROOT}/sale/categories/no-paging`,
            type: 'GET',
            dataType: 'json',
            success: function(data) {
                let categorySelect = $('#loaiSanPham');
                categorySelect.empty(); // Xóa các options cũ
                data.data.forEach(function(category) {
                    categorySelect.append(new Option(category.categoryName, category.id));
                });
            },
            error: function(xhr, status, error) {
                console.error('Error loading categories:', error);
            }
        });
    }

    function getBrand() {
        $.ajax({
            url: `${window.env.API_ROOT}/sale/brands/no-paging`,
            type: 'GET',
            dataType: 'json',
            success: function(data) {
                let brandSelect = $('#thuongHieu');
                brandSelect.empty(); // Xóa các options cũ
                data.data.forEach(function(brand) {
                    brandSelect.append(new Option(brand.brandName, brand.id));
                });
            },
            error: function(xhr, status, error) {
                console.error('Error loading brands:', error);
            }
        });
    }



</script>

</html>