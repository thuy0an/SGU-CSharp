<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./QLNhanSu.css" />

    <title>Quản lý nhân sự</title>
</head>
<style>
    .paginationjs {
        display: flex;
        justify-content: center;
        margin: 20px 0;
    }
</style>

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
                        <h2>Nhân sự</h2>
                        <button style="
                            margin-left: auto;
                            font-family: Arial;
                            font-size: 1.5rem;
                            font-weight: 700;
                            color: white;
                            background-color: rgb(65, 64, 64);
                            padding: 1rem;
                            border-radius: 0.6rem;
                            cursor: pointer;
                        " id="btnAddcategory">
                            <a href="./FromCreateNhaCungCap.php"> Thêm nhân sự</a>
                        </button>
                    </div>
                    <br>
                    <div class="boxFeature">
                        <div style="position: relative">
                            <input style="border: 2px solid #333; height: 30px; padding: 0.5rem;" class="Admin_input__LtEE-" placeholder="Tìm kiếm nhân sự" />
                            <button id="filter-button" style="cursor: pointer;"><i class="fa fa-search"></i></button>
                        </div>
                        <select id="position-filter" style="display: none; border: 2px solid #333; height: 30px; padding: 0.3rem; margin-left: 10px;">
                            <option value="">Tất cả vị trí</option>
                            <option value="BUSINESS_MANAGER">Business Manager</option>
                            <option value="INVENTORY_MANAGER">Inventory Manager</option>
                            <option value="HR">HR</option>
                        </select>
                        <select id="status-filter" style="border: 2px solid #333; height: 30px; padding: 0.3rem; margin-left: 10px;">
                            <option value="">Tất cả trạng thái</option>
                            <option value="ACTIVE">Active</option>
                            <option value="INACTIVE">Inactive</option>
                            <option value="SUSPENDED">Suspended</option>
                            <option value="TERMINATED">Terminated</option>
                            <option value="ON_LEAVE">On Leave</option>
                        </select>
                    </div>
                    <br>
                    <table class="Table_table__BWPy">
                        <thead class="Table_head__FTUog">
                            <tr>
                                <th style="width: 10%" class="Table_th__hCkcg" scope="col">Mã nhân viên</th>
                                <th class="Table_th__hCkcg" scope="col">Tên nhân viên</th>
                                <th class="Table_th__hCkcg" scope="col">Số điện thoại</th>
                                <th class="Table_th__hCkcg" scope="col">Email</th>
                                <th class="Table_th__hCkcg" scope="col">Trạng thái</th>
                                <th class="Table_th__hCkcg" scope="col">Vị trí</th>
                                <th style="width: 15%" class="Table_th__hCkcg" scope="col">Hành động</th>
                            </tr>
                        </thead>
                        <tbody id="tableBody">
                        </tbody>
                    </table>
                    <div id="pagination-container"></div>
                </div>
            </div>
        </div>
    </div>
</body>

</html>

<script>
    
    var currentPage = 1;
    var pageSizeGlobal = 5;
    var search = "";
    var position = "";
    var status = "";
    const userRole = sessionStorage.getItem('role');
    const url = window.env.API_ROOT;

    document.addEventListener('DOMContentLoaded', () => {

        // Khởi tạo trang hiện tại
        fetchDataAndUpdateTable(currentPage, '');

        // const adminButton = document.getElementById('btnAddcategory');
        // if (userRole != 'Manager') {
        //     adminButton.style.display = 'none';
        // } else {
        //     console.log('Phần tử adminButton không tồn tại.');
        // }
    });

    function clearTable() {
        var tableBody = document.querySelector('.Table_table__BWPy tbody');
        if (tableBody) {
            tableBody.innerHTML = ''; // Xóa nội dung trong tbody
        } else {
            console.error("Table body not found.");
        }
    }

    function getData(page, search) {
        // Lấy userRole từ sessionStorage
        const userRole = sessionStorage.getItem('role');

        $.ajax({
            // url: `${window.env.API_ROOT}/inventory/suppliers`,
            url: `${url}/user/profiles`,
            type: "GET",
            dataType: "json",
            data: {
                pageNumber: page,
                pageSize: pageSizeGlobal,
                search: search,
                position: position,
                status: status
            },
            success: function(response) {
                var data = response.data.content;
                var tableBody = document.getElementById("tableBody");
                var tableContent = "";

                // Duyệt qua mảng dữ liệu và tạo các hàng mới cho tbody
                if (data.length > 0) {
                    data.forEach(function(record, index) {
                        var trClass = (index % 2 !== 0) ? "Table_data_quyen_1" : "Table_data_quyen_2"; // Xác định class của hàng
                        let positionName = record.position ? record.position.name : "Admin";

                        var trContent = `
                        <form id="updateForm" method="post" action="FormUpdateNhaCungCap.php">
                            <tr style="height: 20%; max-height: 20%;">
                                <td class="${trClass}">${record.id}</td>
                                <td class="${trClass}">${record.fullname}</td>
                                <td class="${trClass}">${record.phone}</td>
                                <td class="${trClass}">${record.email}</td>
                                <td class="${trClass}">${record.status}</td>
                                <td class="${trClass}">${positionName}</td>



                                <td class="${trClass}">`;

                        // Logic hiển thị nút dựa vào userRole
                        if (record.id == "P001") {
                            trContent += `Mặc định`;
                        } else {
                            // if (userRole === "Manager") {
                                trContent += `
                                <button class="edit" onclick="updateObject('${record.id}', '${record.name}', '${record.phone}')">Sửa</button>
                                <button class="delete" onclick="deleteObject('${record.id}', '${record.fullname}')">Xoá</button>`;
                            // } else if (userRole === "Employee") {
                            //     trContent += `
                            //     <button class="edit" onclick="updateObject(${record.id}, '${record.categoryName}')">Xem chi tiết</button>`;
                            // }
                        }

                        trContent += `</td></tr></form>`;

                        // Nếu chỉ có ít hơn 5 phần tử và đã duyệt đến phần tử cuối cùng, thêm các hàng trống vào
                        if (data.length < 5 && index === data.length - 1) {
                            for (var i = data.length; i < 5; i++) {
                                var emptyTrClass = (i % 2 !== 0) ? "Table_data_quyen_1" : "Table_data_quyen_2";
                                trContent += `
                                <tr style="height: 20%; max-height: 20%;">
                                    <td class="${emptyTrClass}" style="width: 130px;"></td>
                                    <td class="${emptyTrClass}"></td>
                                    <td class="${emptyTrClass}"></td>
                                    <td class="${emptyTrClass}"></td>
                                    <td class="${emptyTrClass}"></td>
                                    <td class="${emptyTrClass}"></td>
                                    <td class="${emptyTrClass}"></td>
                                </tr>
                            `;
                            }
                        }

                        tableContent += trContent;
                    });
                } else {
                    tableContent = `<tr><td style="text-align: center;" colspan="7">Không có nhân sự nào thỏa yêu cầu</td></tr>`;
                }

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


    function fetchDataAndUpdateTable(page, search) {
        clearTable();
        getData(page, search);
    }

    function setupPagination(totalElements, currentPage) {
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
                    currentPage = pagination.pageNumber;
                    fetchDataAndUpdateTable(currentPage, search);
                }
            }
        });
    }

    document.querySelector('.Admin_input__LtEE-').addEventListener('keypress', function(event) {
        if (event.key === 'Enter') {
            event.preventDefault();
            search = this.value;
            position = document.getElementById('position-filter').value;
            status = document.getElementById('status-filter').value;
            fetchDataAndUpdateTable(currentPage, search);
        }
    });



    document.getElementById('position-filter').addEventListener('change', function() {
        search = document.querySelector('.Admin_input__LtEE-').value;
        position = this.value;
        status = document.getElementById('status-filter').value;
        fetchDataAndUpdateTable(currentPage, search);
    });

    document.getElementById('status-filter').addEventListener('change', function() {
        search = document.querySelector('.Admin_input__LtEE-').value;
        position = document.getElementById('position-filter').value;
        status = this.value;
        fetchDataAndUpdateTable(currentPage, search);
    });

    function deleteObject(id, name) {
        Swal.fire({
            title: `Bạn có muốn xóa ${name} không?`,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `${url}/user/profiles/${id}`,
                    type: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + localStorage.getItem('token') // Nếu có token
                    },
                    success: function(response) {
                        Swal.fire('Thành công!', 'Xóa nhân sự thành công!', 'success');
                        fetchDataAndUpdateTable(currentPage, search);
                    },
                    error: function(xhr, status, error) {
                        Swal.fire('Lỗi!', 'Không thể xóa nhân sự. Vui lòng thử lại sau.', 'error');
                        console.error('Delete Error: ', xhr.responseText); // In log đầy đủ
                    }
                });

            }
        });
    }

    const updateObject = (id) => {
        window.location.href = `FormUpdateNhanSu.php?id=${id}`;
    }

    // Initial data fetch
    fetchDataAndUpdateTable(currentPage, search);
</script>