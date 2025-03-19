<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./QLNhaCungCap.css" />
    <title>Thêm nhà cung cấp</title>
</head>

<body>
    <div class="StaffLayout_wrapper__CegPk">
        <?php require_once "../ManagerHeader.php" ?>
        <div class="Manager_wrapper__vOYy">
            <div style="padding-left: 3%; width: 100%; padding-right: 2rem">
                <div class="wrapper">
                    <form id="submit-form" method="POST">
                        <input type="hidden" name="action" value="createNhaCungCap">
                        <div class="boxFeature">
                            <h2 style="font-size: 1.5rem;">Thêm nhà cung cấp</h2>
                            <div>
                                <a style="
                                    font-family: Arial;
                                    font-size: 1rem; /* Giảm kích thước font */
                                    font-weight: 600; /* Giảm độ đậm */
                                    border: 1px solid rgb(140, 140, 140);
                                    background-color: white;
                                    color: rgb(80, 80, 80);
                                    padding: 0.5rem 1rem; /* Giảm phần padding */
                                    border-radius: 0.4rem; /* Giảm độ bo tròn */
                                    cursor: pointer;
                                    " href="./QLNhaCungCap.php">
                                    Hủy
                                </a>
                                <button id="updateNhaCungCap_save"
                                    style="
                                    margin-left: 0.5rem; /* Giảm khoảng cách bên trái */
                                    font-family: Arial;
                                    font-size: 1rem; /* Giảm kích thước font */
                                    font-weight: 600; /* Giảm độ đậm */
                                    color: white;
                                    background-color: rgb(65, 64, 64);
                                    padding: 0.5rem 1rem; /* Giảm phần padding */
                                    border-radius: 0.4rem; /* Giảm độ bo tròn */
                                    cursor: pointer;">
                                    Lưu
                                </button>
                            </div>
                        </div>
                        <div class="boxTable">
                            <div style=" display: flex; padding: 0rem 1rem 0rem 1rem; justify-content: space-between;">
                                <div style="padding-left: 1rem">
                                    <p class="text">Tên nhà cung cấp</p>
                                    <input id="categoryName" class="input" type="text"
                                        name="categoryName"/>

                                    <span style="
                                        margin-left: 1rem;
                                        font-weight: 700;
                                        color: rgb(150, 150, 150);
                                        ">*</span>
                                </div>

                                <div style="padding-left: 1rem">
                                    <p class="text">Số điện thoại</p>
                                    <input id="phone" class="input" type="text"
                                        name="phone"/>

                                    <span style="
                                        margin-left: 1rem;
                                        font-weight: 700;
                                        color: rgb(150, 150, 150);
                                        ">*</span>
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


    document.getElementById("submit-form").addEventListener('submit', function check(event) {
        event.preventDefault(); // Ngăn chặn hành động mặc định của form


        let categoryName = document.getElementById("categoryName");
        let phone = document.getElementById("phone");


        if (!categoryName.value.trim()) {

            Swal.fire({
                icon: 'error',
                title: 'Lỗi!',
                text: 'Tên nhà cung cấp không được để trống',
            });
            categoryName.focus();
            event.preventDefault();
            return;
        }

        //Tạo thông tin nhà cung cấp
        let isCreateNhaCungCapComplete = createNhaCungCap(
            categoryName.value,
            phone.value
        );


    });

    function createNhaCungCap(CategoryName, phone) {
        console.log(CategoryName, phone);
        $.ajax({
            url: `${window.env.API_ROOT}/suppliers`,
            type: 'POST', // POST để tạo mới
            dataType: "json",
            headers: {
                'Content-Type': 'application/json' // Gửi dữ liệu dưới dạng JSON
            },
            data: JSON.stringify({
                name: CategoryName,
                phone: phone // Chuẩn bị dữ liệu JSON
            }),
            success: function(data) {
                Swal.fire({
                    icon: 'success',
                    title: 'Thành công!',
                    text: 'Thêm nhà cung cấp thành công!',
                }).then(function() {
                    window.location.href = 'QLNhaCungCap.php';
                });
            },
            error: function(xhr) {
                console.log(xhr);
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi!',
                    text: 'Đã xảy ra lỗi khi thêm nhà cung cấp: ' + xhr.responseJSON.message,
                });
                    
            }
        });
    }
</script>