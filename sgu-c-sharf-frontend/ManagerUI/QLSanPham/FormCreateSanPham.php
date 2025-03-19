<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../QLTaiKhoan/UserUpdate.css" />
    <link rel="stylesheet" href="../QLTaiKhoan/oneForAll.css" />
    <title>Tạo sản phẩm</title>
</head>

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
                                <h2 style="font-size: 2.3rem">Tạo sản phẩm mới</h2>
                            </div>
                            <div>
                                <a style="font-family: Arial; font-size: 1.5rem; font-weight: 700; border: 1px solid rgb(140, 140, 140); background-color: white; color: rgb(80, 80, 80); padding: 1rem 2rem 1rem 2rem; border-radius: 0.6rem; cursor: pointer;" href="QLSanPham.php">Hủy</a>
                                <button id="updateUser_save" style="margin-left: 1rem; font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; background-color: rgb(65, 64, 64); padding: 1rem 2rem 1rem 2rem; border-radius: 0.6rem; cursor: pointer;">Lưu</button>
                            </div>
                        </div>
                        <div class="boxTable">
                            <div style="display: flex; padding: 0rem 1rem 0rem 1rem; justify-content: space-around;">
                                <div style="padding-left: 1rem; margin-left: 25px;">
                                    <p class="text">Tên sản phẩm</p>
                                    <input id="tenSanPham" class="input" type="text" name="tenSanPham" style="width: 40rem;" />
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Loại sản phẩm</p>
                                    <select name="loaiSanPham" id="loaiSanPham" class="input" style="width: 40rem; background-color: white;"></select>
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Xuất xứ</p>
                                    <input id="xuatXu" class="input" name="xuatXu" style="width: 40rem" />
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Thương hiệu</p>
                                    <select id="thuongHieu" class="input" name="thuongHieu" style="width: 40rem; background-color: white;"></select>
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Thể tích</p>
                                    <input id="theTich" class="input" type="text" name="theTich" style="width: 40rem" />
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Nồng độ cồn</p>
                                    <input id="nongDoCon" type="text" class="input" name="nongDoCon" style="width: 40rem" />
                                    <span style="margin-left: 1rem; font-weight: 700;">*</span>

                                    <p class="text">Mô Tả</p>
                                    <textarea id="moTa" class="input" name="moTa" style="width: 40rem; height: 8rem;" rows="4" cols="50"></textarea>
                                </div>
                                <div style="display: flex; flex-direction: column; justify-content: center; align-items: center;">
                                    <p class="text">Ảnh minh họa</p>
                                    <img id="xuatAnh" style="width: 350px; height: 400px;" src="../../public/img/anhMinhHoa.webp" alt="">
                                    <input id="anhMinhHoa" type="file" name="anhMinhHoa" accept="image/*">
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
    getCategories();
    getBrand();
 
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



    document.getElementById("updateUser_save").addEventListener('click', function (event) {
    event.preventDefault(); // Ngăn chặn hành động mặc định của form

    let tenSanPham = document.getElementById("tenSanPham");
    let loaiSanPham = document.getElementById("loaiSanPham");
    let xuatXu = document.getElementById("xuatXu");
    let thuongHieu = document.getElementById("thuongHieu");
    let theTich = document.getElementById("theTich");
    let nongDoCon = document.getElementById("nongDoCon");
    let anhMinhHoa = document.getElementById("anhMinhHoa");
    let moTa = document.getElementById("moTa");

    // Danh sách các trường bắt buộc không được để trống
    let fields = [
        { element: tenSanPham, message: "Tên sản phẩm không được để trống" },
        { element: loaiSanPham, message: "Vui lòng chọn loại sản phẩm", isSelect: true },
        { element: xuatXu, message: "Xuất xứ không được để trống" },
        { element: thuongHieu, message: "Thương hiệu không được để trống" },
        { element: theTich, message: "Thể tích không được để trống" },
        { element: nongDoCon, message: "Nồng độ cồn không được để trống" },
        { element: moTa, message: "Mô tả không được để trống" },
    ];

    for (let field of fields) {
        if (field.isSelect ? field.element.value === "" : !field.element.value.trim()) {
            showErrorAlert('Lỗi!', field.message);
            field.element.focus();
            return;
        }
    }

    // Kiểm tra thể tích là số dương
    let theTichValue = parseFloat(theTich.value);
    if (isNaN(theTichValue) || theTichValue <= 0) {
        showErrorAlert('Lỗi!', 'Thể tích phải là số dương');
        theTich.focus();
        return;
    }

    // Kiểm tra nồng độ cồn (0 - 100)
    let nongDoConValue = parseFloat(nongDoCon.value);
    if (isNaN(nongDoConValue) || nongDoConValue < 0 || nongDoConValue > 100) {
        showErrorAlert('Lỗi!', 'Nồng độ cồn phải là số dương và có giá trị từ 0 đến 100');
        nongDoCon.focus();
        return;
    }

    // Kiểm tra file ảnh đã được chọn chưa
    if (image === "") {
        showErrorAlert('Lỗi!', 'Vui lòng chọn ảnh minh họa');
        anhMinhHoa.focus();
        return;
    }

    // Nếu tất cả kiểm tra hợp lệ, tiến hành tạo sản phẩm
    createSanPham(
        tenSanPham.value,
        loaiSanPham.value,
        xuatXu.value,
        thuongHieu.value,
        theTichValue,
        nongDoConValue,
        image,
        moTa.value
    );

    
});





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

    function createSanPham(tenSanPham, maLoaiSanPham, xuatXu, thuongHieu, theTich, nongDoCon, anhMinhHoa, moTa) {
        // Tạo đối tượng JSON để gửi lên server
        let sanPhamData = {
            productName: tenSanPham,
            categoryId: maLoaiSanPham,
            origin: xuatXu,
            brandId: Number(thuongHieu),
            capacity: theTich,
            abv: nongDoCon,
            description: moTa,
            image: anhMinhHoa// Nếu có ảnh thì lấy tên, nếu không thì null
        };

        $.ajax({
            url: `${window.env.API_ROOT}/sale/products`,
            type: 'POST',
            contentType: 'application/json', // Gửi dữ liệu dưới dạng JSON
            data: JSON.stringify(sanPhamData), // Chuyển đối tượng thành JSON
            success: function(data) {
                // Sau khi tạo xong, chuyển về trang QLSanPham
                showSuccessAlert('Thành công!', 'Tạo sản phẩm mới thành công !!', 'QLSanPham.php');
            },
            error: function(xhr, status, error) {
                console.error('Error: ' + xhr.status + ' - ' + error);
                console.log(xhr.responseText); // Kiểm tra phản hồi lỗi từ máy chủ
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