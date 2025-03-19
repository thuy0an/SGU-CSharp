<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Quản lý tài khoản</title>
    <link rel="stylesheet" href="./oneForAll.css" />
    <link rel="stylesheet" href="./Admin.css" />

    <style>
        .paginationjs {
            display: flex;
            justify-content: center;
            padding: 20px 0;
        }
    </style>
</head>

<body>

    <div class="StaffLayout_wrapper__CegPk">
        <?php require_once "../ManagerHeader.php" ?>

        <div class="Manager_wrapper__vOYy">
            <?php require_once "../ManagerMenu.php" ?>

            <div style="padding-left: 16%; width: 100%; padding-right: 2rem">
                <div class="wrapper">
                    <div style="
                                            display: flex;
                                            padding-top: 1rem;
                                            padding-bottom: 1rem;
                                            ">
                        <h2>Quản lý tài khoản</h2>
                        <!-- <a href="FormCreateTaiKhoan.php" id="createAccountButton">Tạo Tài Khoản</a> -->
                    </div>
                    <div class="Admin_boxFeature__ECXnm">
                        <div style="position: relative;">
                            <input class="Admin_input__LtEE-" placeholder="Tìm kiếm tài khoản">
                        </div>
                        <select id="selectQuyen" style="height: 3rem; padding: 0.3rem;">
                            <option value="">Trạng thái: tất cả</option>
                            <option value="ACTIVE">Hoạt động</option>
                            <option value="INACTIVE">Khóa</option>
                        </select>

                        <select id="selectRole" style="height: 3rem; padding: 0.3rem;">
                            <option value="">Tất cả quyền</option>
                            <option value="HR">HR</option>
                            <option value="ADMIN">ADMIN</option>
                            <option value="INVENTORY_MANAGER">Inventory manager</option>
                            <option value="BUSINESS_MANAGER">Business manager</option>
                        </select>
                        <button id="searchButton" style="">Tìm kiếm</button>
                    </div>
                    <div class="Admin_boxTable__hLXRJ">
                        <table class="Table_table__BWPy">
                            <thead class="Table_head__FTUog">
                                <tr>
                                    <th class="Table_th__hCkcg" style="width:5%">ID</th>
                                    <th class="Table_th__hCkcg" style="width:30%">Email</th>
                                    <th class="Table_th__hCkcg" style="width:20%">Ngày tạo</th>
                                    <th class="Table_th__hCkcg" style="width:5%">Trạng thái</th>
                                    <th class="Table_th__hCkcg" style="width:10%">Quyền</th>
                                    <th class="Table_th__hCkcg" style="width:10%">Thao tác</th>
                                </tr>
                            </thead>
                            <tbody id="tableBody1">

                            </tbody>
                        </table>
                        <div id="pagination-container" style="background-color: white;"></div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</body>


<script>
    // Khởi tạo trang hiện tại
    const userRole = sessionStorage.getItem('role');

    var currentPage = 1;
    var pageSizeGlobal = 5;
    var search = "";
    var status = "";
    var role = "";
    var url = `${window.env.API_ROOT}`;
    // var url = `http://localhost:8083/api`;


    // Lắng nghe sự kiện click trên nút logout
    document.addEventListener('DOMContentLoaded', function() {
        fetchDataAndUpdateTable(currentPage, '', '');
    });

    function clearTable() {
        var tableBody = document.querySelector('.Table_table__BWPy tbody');
        tableBody.innerHTML = ''; // Xóa nội dung trong tbody
    }

    function getAllTaiKhoan(page) {
        $.ajax({
            url: `${url}/accounts`,
            type: 'GET',
            dataType: "json",
            data: {
                pageNumber: page,
                pageSize: pageSizeGlobal,
                search: search,
                status: status,
                role: role // Thêm role vào dữ liệu gửi lên server
            },
            success: function(response) {
                var data = response.data.content;
                var tableBody = document.getElementById("tableBody1"); // Lấy thẻ tbody của bảng
                var tableContent = ""; // Chuỗi chứa nội dung mới của tbody

                // Lấy role của user hiện tại từ sessionStorage
                const userRole = sessionStorage.getItem('role');

                if (data.length > 0) {
                    data.forEach(function(record, index) {
                        var trClass = (index % 2 !== 0) ? "Table_data_quyen_1" : "Table_data_quyen_2"; // Xác định class của hàng

                        // Xác định trạng thái và văn bản của nút dựa trên trạng thái của tài khoản
                        var buttonText = (record.status === "INACTIVE") ? "Mở khóa" : "Khóa";
                        var buttonClass = (record.status === "INACTIVE") ? "unlock" : "block";
                        var buttonData = (record.status === "INACTIVE") ? "unlock" : "block";
                        var trContent = `
                        <tr style="height: 20%;">
                            <td class="${trClass}" style="width: 130px;">${record.id}</td>
                            <td class="${trClass}">${record.email}</td>
                            <td class="${trClass}">${convertDateTimeFormat(record.createdAt)}</td>
                            <td class="${trClass}">${record.status === "INACTIVE" ? "Khóa" : "Hoạt động"}</td>`;

                        if (record.role === "ADMIN") {
                            // Hiển thị quyền cho tài khoản là Admin
                            trContent += `<td class="${trClass}">${record.role}</td>`;
                            trContent += `<td class="${trClass}"></td>`;
                        } else {
                            // Hiển thị thẻ select cho tài khoản không phải User hoặc Admin
                            trContent += `<td class="${trClass}">
                                            <select class="role-select" id="roleSelect${record.id}" 
                                                onchange="confirmRoleChange('${record.id}', this.value)" 
                                                style="font-size: 14px; padding: 4px 8px; height: auto; min-height: 36px;">
                                                <option value="HR" ${record.role === "HR" ? "selected" : ""}>HR</option>
                                                <option value="INVENTORY_MANAGER" ${record.role === "INVENTORY_MANAGER" ? "selected" : ""}>Inventory Manager</option>
                                                <option value="BUSINESS_MANAGER" ${record.role === "BUSINESS_MANAGER" ? "selected" : ""}>Business Manager</option>
                                            </select>
                                        </td>
                                        `;

                                trContent += `<td class="${trClass}">
                                                <button id="adminButton" class="${buttonClass}" data-action="${buttonData}" 
                                                    onClick="handleLockUnlock('${record.id}', '${record.status}')">${buttonText}</button>
                                            </td>`;
                        
                        }

                        trContent += `</tr>`;
                        tableContent += trContent; // Thêm nội dung của hàng vào chuỗi tableContent
                        setupPagination(response.data.totalElements, page);
                    });
                } else {
                    tableContent = `<tr><td style="text-align: center;" colspan="7">Không có tài khoản nào thỏa yêu cầu</td></tr>`;
                }

                // Thiết lập lại nội dung của tbody bằng chuỗi tableContent
                tableBody.innerHTML = tableContent;

                // Tạo phân trang
                setupPagination(response.data.totalElements, page);
            },
            error: function(xhr, status, error) {
                if (xhr.status === 401) {
                    alert('Phiên đăng nhập của bạn đã hết hạn. Vui lòng đăng nhập lại.');
                    window.location.href = '/login';
                } else {
                    console.error('Lỗi khi gọi API: ', error);
                }
            }
        });
    }


    function confirmRoleChange(accountId, newRole) {
        console.log(accountId, newRole);
        Swal.fire({
            title: `Bạn có chắc chắn muốn thay đổi quyền thành ${newRole} không?`,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                // Gửi yêu cầu cập nhật quyền mới lên server
                $.ajax({
                    url: `${url}/accounts/${accountId}/role`,
                    type: 'PATCH',
                    data: JSON.stringify({
                        role: newRole
                    }),
                    headers: {
                        'Content-Type': 'application/json' // Gửi dữ liệu dưới dạng JSON
                    },
                    success: function(response) {
                        Swal.fire('Thành công!', 'Cập nhật quyền thành công!', 'success');
                    },
                    error: function(xhr, status, error) {
                        Swal.fire('Lỗi!', 'Có lỗi xảy ra trong quá trình cập nhật quyền.', 'error');
                        console.error('Lỗi khi gọi API: ', error);
                    }
                });
            } else {
                // Nếu người dùng không đồng ý, reset giá trị select về giá trị cũ
                const selectElement = document.getElementById("roleSelect" + accountId);
                selectElement.value = oldRole; // Khôi phục giá trị cũ
            }
        });
    }



    function fetchDataAndUpdateTable(page) {
        clearTable();
        getAllTaiKhoan(page);
    }


    function setupPagination(totalElements, currentPage) {
        console.log(totalElements, currentPage );

        //Kiểm tra xem nếu totalPage ít hơn 1 thì ẩn luôn =))
        const totalPage = Math.ceil(totalElements / pageSizeGlobal);
        totalPage <= 1 ? $('#pagination-container').hide() : $('#pagination-container').show();

        $('#pagination-container').pagination({
            dataSource: Array.from({
                length: totalElements
            }, (_, i) => i + 1),

            pageSize: pageSizeGlobal,
            showPrevious: true,
            showNext: true,
            pageNumber: currentPage,

            callback: function(data, pagination) {
                if (pagination.pageNumber !== currentPage) {
                    currentPage = pagination.pageNumber; // Update current page
                    getAllTaiKhoan(currentPage);
                }
            }
        });
    }


    // Hàm xử lý sự kiện khi select Quyen thay đổi
    document.querySelector('#selectQuyen').addEventListener('change', function() {
        status = this.value;
        fetchDataAndUpdateTable(currentPage);
    });

    // Hàm xử lý sự kiện khi nút tìm kiếm được click
    document.getElementById('searchButton').addEventListener('click', function() {
        search = document.querySelector('.Admin_input__LtEE-').value;
        fetchDataAndUpdateTable(currentPage);
    });

    // Hàm xử lý sự kiện khi select Role thay đổi
    document.querySelector('#selectRole').addEventListener('change', function() {
        role = this.value;
        fetchDataAndUpdateTable(currentPage);
    });

    // Bắt sự kiện khi người dùng ấn phím Enter trong ô tìm kiếm
    document.querySelector('.Admin_input__LtEE-').addEventListener('keypress', function(event) {
        // Kiểm tra xem phím được ấn có phải là Enter không (mã phím 13)
        if (event.key === 'Enter') {

            event.preventDefault();
            // Lấy giá trị của ô tìm kiếm và của select quyền
            search = document.querySelector('.Admin_input__LtEE-').value;
            fetchDataAndUpdateTable(currentPage); // Gọi hàm với 4 tham số
        }
    });


    // Hàm xử lý sự kiện cho nút khóa / mở khóa
    function handleLockUnlock(maTaiKhoan, trangThai) {
        // Xác định trạng thái mới dựa trên trạng thái hiện tại
        var newTrangThai = trangThai === "INACTIVE" ? "ACTIVE" : "INACTIVE";

        Swal.fire({
            title: `Bạn có muốn ${newTrangThai === 0 ? 'khóa' : 'mở khóa'} tài khoản ${maTaiKhoan} không?`,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {

                $.ajax({
                    url: `${url}/accounts/${maTaiKhoan}/status`,
                    type: 'PATCH',
                    data: JSON.stringify({
                        status: newTrangThai
                    }),
                    headers: {
                        'Content-Type': 'application/json' // Gửi dữ liệu dưới dạng JSON
                    },
                    success: function(response) {
                        if (response.status === 200) {
                            var alertContent = newTrangThai === 0 ? "khóa" : "mở khóa";
                            Swal.fire('Thành công!', `Bạn đã ${alertContent} thành công !!`, 'success');
                            fetchDataAndUpdateTable(currentPage, "", null);
                        } else {
                            Swal.fire('Lỗi!', 'Đã xảy ra lỗi khi cập nhật trạng thái.', 'error');
                        }
                    },
                    error: function(xhr, status, error) {
                        console.error('Lỗi khi gọi API: ', error);
                    }
                });
            }
        });
    }
</script>

</html>