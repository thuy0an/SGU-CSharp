<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./QLNhaCungCap.css" />

    <title>Quản lý Nhà Cung Cấp</title>
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
                        <h2>Nhà Cung Cấp</h2>
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
                            <a href="./FromCreateNhaCungCap.php"> Thêm Nhà Cung Cấp</a>
                        </button>
                    </div>
                    <br>
                    <div class="boxFeature">
                        <div style="position: relative">
                            <input style="border: 2px solid #333; height: 30px; padding: 0.5rem;" class="Admin_input__LtEE-" placeholder="Tìm kiếm Nhà Cung Cấp" />
                            <button id="filter-button" style="cursor: pointer;"><i class="fa fa-search"></i></button>
                        </div>
                        <div style="margin-left: auto"></div>
                    </div>
                    <br>
                    <table class="Table_table__BWPy">
                        <thead class="Table_head__FTUog">
                            <tr>
                                <th style="width: 25%" class="Table_th__hCkcg" scope="col">Mã Nhà Cung Cấp</th>
                                <th class="Table_th__hCkcg" scope="col">Nhà Cung Cấp</th>
                                <th class="Table_th__hCkcg" scope="col">Số điện thoại</th>
                                <th style="width: 15%" class="Table_th__hCkcg" scope="col">Action</th>
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
    const userRole = sessionStorage.getItem('role');
    const url = window.env.API_ROOT;

    // url = "http://localhost:8082/api";

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

    function getAllNhaCungCap(page, search) {
        // Lấy userRole từ sessionStorage
        const userRole = sessionStorage.getItem('role');

        $.ajax({
            // url: `${window.env.API_ROOT}/suppliers`,
            url: `${url}/suppliers`,
            type: "GET",
            dataType: "json",
            data: {
                pageNumber: page,
                pageSize: pageSizeGlobal,
                search: search
            },
            success: function(response) {
                var data = response.data.content;
                var tableBody = document.getElementById("tableBody");
                var tableContent = "";

                // Duyệt qua mảng dữ liệu và tạo các hàng mới cho tbody
                if (data.length > 0) {
                    data.forEach(function(record, index) {
                        var trClass = (index % 2 !== 0) ? "Table_data_quyen_1" : "Table_data_quyen_2"; // Xác định class của hàng
                   
                        var trContent = `
                        <form id="updateForm" method="post" action="FormUpdateNhaCungCap.php">
                            <tr style="height: 20%; max-height: 20%;">
                                <td class="${trClass}">${record.id}</td>
                                <td class="${trClass}">${record.name}</td>
                                <td class="${trClass}">${record.phone}</td>
                                <td class="${trClass}">`;

                        // Logic hiển thị nút dựa vào userRole
                        if (record.id == 1) {
                            trContent += `Mặc định`;
                        } else {
                            // if (userRole === "Manager") {
                                trContent += `
                                <button class="edit" onclick="updateNhaCungCap(${record.id}, '${record.name}', '${record.phone}')">Sửa</button>
                                <button class="delete" onclick="deleteNhaCungCap(${record.id}, '${record.name}')">Xoá</button>`;
                            // } else if (userRole === "Employee") {
                            //     trContent += `
                            //     <button class="edit" onclick="updateNhaCungCap(${record.id}, '${record.categoryName}')">Xem chi tiết</button>`;
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
                                </tr>
                            `;
                            }
                        }

                        tableContent += trContent;
                    });
                } else {
                    tableContent = `<tr><td style="text-align: center;" colspan="7">Không có loại sản phẩm nào thỏa yêu cầu</td></tr>`;
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
        getAllNhaCungCap(page, search);
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

    document.getElementById('filter-button').addEventListener('click', function() {
        var search = document.querySelector('.Admin_input__LtEE-').value;
        fetchDataAndUpdateTable(currentPage, search);
    });

    document.querySelector('.Admin_input__LtEE-').addEventListener('keypress', function(event) {
        if (event.key === 'Enter') {
            event.preventDefault();
            search = this.value;
            fetchDataAndUpdateTable(currentPage, search);
        }
    });

    function deleteNhaCungCap(id, categoryName) {
        Swal.fire({
            title: `Bạn có muốn xóa ${categoryName} không?`,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `${url}/suppliers/${id}`,
                    type: 'DELETE',

                    success: function(response) {
                        Swal.fire('Thành công!', 'Xóa Nhà Cung Cấp thành công !!',
                            'success');
                        fetchDataAndUpdateTable(currentPage, search); // Refresh table after delete
                    },
                    error: function(xhr, status, error) {
                        Swal.fire('Lỗi!', 'Không thể xóa Nhà Cung Cấp. Vui lòng thử lại sau.', 'error');
                        console.error('Delete Error: ', error);
                    }
                });
            }
        });
    }

    const updateNhaCungCap = (id, categoryName, phone) => {
        window.location.href = `FormUpdateNhaCungCap.php?id=${id}&categoryName=${categoryName}&phone=${phone}`;
    }

    // Initial data fetch
    fetchDataAndUpdateTable(currentPage, search);
</script>