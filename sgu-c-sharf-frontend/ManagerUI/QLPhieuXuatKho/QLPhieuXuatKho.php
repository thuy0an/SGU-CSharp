<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./QLPhieuNhapKho.css" />
    <title>Quản lý phiếu xuất kho</title>

    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <!-- Pagination.js CSS and JS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/paginationjs/2.1.4/pagination.css" integrity="sha512-Gzxkjch35VNydCwNw4e6MDjSfzz9J0zxjeGm2eI49fg4Xoat2LAVcI0zOCYn3sU4v/S8Dy3QtV5ktUjZJm1Jkg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/paginationjs/2.1.4/pagination.min.js" integrity="sha512-GPSYwnjJ9uzvfgvBqA3TIjK0E6BkKz+AwV4q0jOHJlk65nRmKqO0vO5A3YjFwTkm7qO3tm7v9tUCaGtEerWAWg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>

    <style>
        .paginationjs {
            display: flex;
            justify-content: center;
            padding: 20px 0;
        }

        .Table_data_quyen_1 {
            text-align: center;
            font-family: Arial;
            background-color: rgb(255, 255, 255);
            padding: 14px 0px;
        }

        .Table_data_quyen_2 {
            text-align: center;
            font-family: Arial;
            background-color: rgb(225, 227, 229);
            padding: 14px 0;
        }

        .boxFeature {
            display: flex;
            gap: 1rem;
            align-items: center;
        }

        .boxFeature label {
            font-size: 1.3rem;
            font-weight: 700;
        }

        .boxFeature input {
            height: 3rem;
            padding: 0.3rem;
        }

        .datesearch {
            width: 20rem;
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
                    <div style="display: flex; padding-top: 1rem; padding-bottom: 1rem;">
                        <h2>Phiếu Xuất Kho</h2>
                        <button style="
                            margin-left: auto;
                            font-family: Arial;
                            font-size: 1.5rem;
                            font-weight: 700;
                            color: white;
                            background-color: rgb(65, 64, 64);
                            padding: 1rem;
                            border-radius: 0.6rem;
                            cursor: pointer;">
                            <a href="taoPhieuXuatKho.php">Tạo Phiếu Xuất</a>
                        </button>
                    </div>
                    <div class="boxFeature">
                        <div>
                            <label>
                                <span style="font-size: 1.3rem; font-weight: 700">Từ Ngày :</span>
                                <input class="input datesearch" id="fromDate" name="fromDate" style="width: 20rem" type="date" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <span style="font-size: 1.3rem; font-weight: 700">Đến Ngày :</span>
                                <input class="input datesearch" id="toDate" name="toDate" style="width: 20rem" type="date" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <span style="font-size: 1.3rem; font-weight: 700">Tìm kiếm :</span>
                                <input id="inputSearch" class="input datesearch" name="search" style="width: 20rem" type="text" />
                            </label>
                        </div>
                        <button id="searchButton" style="
                            font-family: Arial;
                            font-size: 1.3rem;
                            font-weight: 700;
                            color: white;
                            background-color: rgb(65, 64, 64);
                            padding: 0.5rem 1rem;
                            border-radius: 0.6rem;
                            cursor: pointer;">
                            Tìm kiếm
                        </button>
                        <button id="resetButton" style="
                            font-family: Arial;
                            font-size: 1.3rem;
                            font-weight: 700;
                            color: white;
                            background-color: rgb(65, 64, 64);
                            padding: 0.5rem 1rem;
                            border-radius: 0.6rem;
                            cursor: pointer;">
                            Reset
                        </button>
                    </div>
                    <div class="Admin_boxTable__hLXRJ">
                        <table class="Table_table__BWPy">
                            <thead class="Table_head__FTUog">
                                <tr>
                                    <th class="Table_th__hCkcg">Mã Phiếu</th>
                                    <th class="Table_th__hCkcg">Ngày Xuất Kho</th>
                                    <th class="Table_th__hCkcg">Tên khách hàng</th>
                                    <th class="Table_th__hCkcg">Số điện thoại </th>
                                    <th class="Table_th__hCkcg">Email</th>
                                    <th class="Table_th__hCkcg">Tổng Giá Trị</th>
                                    <th class="Table_th__hCkcg">Thao Tác</th>
                                </tr>
                            </thead>
                            <tbody id="tableBody">
                            </tbody>
                        </table>
                        <div id="pagination-container" style="background-color: white;"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>

</html>
<script>
    const token = sessionStorage.getItem("token");
    var currentPage = 1;
    var pageSizeGlobal = 5;
    var search = "";
    var fromDate = "";
    var toDate = "";

    var url = `${window.env.API_ROOT}`;

    // Initial data fetch
    fetchDataAndUpdateTable(currentPage, search, fromDate, toDate);

    function clearTable() {
        document.querySelector('#tableBody').innerHTML = '';
    }

    function formatDateTime(dateTimeString) {
        const date = new Date(dateTimeString);

        const hours = date.getHours().toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        const seconds = date.getSeconds().toString().padStart(2, '0');

        const day = date.getDate().toString().padStart(2, '0');
        const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Tháng trong JavaScript Date đếm từ 0
        const year = date.getFullYear();

        return `${hours}:${minutes}:${seconds} ${day}/${month}/${year}`;
    }

    function getAllphieunhapkho(page, search, fromDate, toDate) {
        $.ajax({
            url: `${url}/inventory-export-reports`,
            type: 'GET',
            dataType: "json",
            headers: {
                'Authorization': 'Bearer ' + token
            },
            data: {
                pageNumber: page,
                pageSize: pageSizeGlobal,
                search: search,
                from: fromDate,
                to: toDate
            },
            success: function(response) {
                var data = response.data.content;
                var tableBody = document.getElementById("tableBody");
                var tableContent = "";

                if (data.length > 0) {
                    data.forEach(function(record, index) {
                        var formattedTongGiaTri = formatCurrency(record['totalAmount']);
                        var trClass = (index % 2 === 0) ? "Table_data_quyen_1" : "Table_data_quyen_2"; // Xác định class xen kẽ
                        console.log(record)
                        var trContent = `
                            <tr class="${trClass}">
                                <td class="Table_data" style="width: 130px;">${record['id']}</td>
                                <td class="Table_data">${formatDateTime(record['createdAt'])}</td>
                                <td class="Table_data">${record['customerName']}</td>
                                <td class="Table_data">${record['customerEmail']}</td>
                                <td class="Table_data">${record['customerPhone']}</td>
                                <td class="Table_data">${formattedTongGiaTri}</td>
                                <td class="Table_data">
                                    <form id="updateForm_${record['id']}" method="post" action="QLPhieuXuatKhoDetail.php?MaPhieu=${record['id']}">
                                        <button class="edit" type="submit">Xem chi tiết</button>
                                    </form>
                                </td>
                            </tr>`;

                        tableContent += trContent;
                    });

                    // Nếu danh sách có ít hơn 5 dòng, thêm các dòng trống vào
                    if (data.length < 5) {
                        for (var i = data.length; i < 5; i++) {
                            var emptyTrClass = (i % 2 === 0) ? "Table_data_quyen_1" : "Table_data_quyen_2";
                            tableContent += `
                                <tr class="${emptyTrClass}">
                                    <td class="Table_data" style="width: 130px;"></td>
                                    <td class="Table_data"></td>
                                    <td class="Table_data"></td>
                                    <td class="Table_data"></td>
                                    <td class="Table_data"></td>
                                    <td class="Table_data"></td>
                                </tr>`;
                        }
                    }
                } else {
                    // Hiển thị thông báo nếu không có dữ liệu
                    tableContent = `<tr><td style="text-align: center;" colspan="6">Không có phiếu xuất kho nào</td></tr>`;
                }

                tableBody.innerHTML = tableContent;
                setupPagination(response.data.totalElements, page, search, fromDate, toDate);
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


    function fetchDataAndUpdateTable(page, search, fromDate, toDate) {
        clearTable();
        getAllphieunhapkho(page, search, fromDate, toDate);
    }

    function update(MaPhieu) {
        document.querySelector(`#updateForm_${MaPhieu}`).submit();
    }

    function setupPagination(totalElements, currentPage, search, fromDate, toDate) {
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
                    getAllphieunhapkho(currentPage, search, fromDate, toDate);
                }
            }
        });
    }

    // Event listeners for search and reset
    document.querySelector('#searchButton').addEventListener('click', function() {
        search = document.querySelector('#inputSearch').value;
        fromDate = document.querySelector('#fromDate').value;
        toDate = document.querySelector('#toDate').value;
        currentPage = 1; // Reset to first page when searching
        fetchDataAndUpdateTable(currentPage, search, fromDate, toDate);
    });

    document.querySelector('#resetButton').addEventListener('click', function() {
        document.querySelector('#inputSearch').value = "";
        document.querySelector('#fromDate').value = "";
        document.querySelector('#toDate').value = "";
        search = "";
        fromDate = "";
        toDate = "";
        currentPage = 1; // Reset to first page when resetting
        fetchDataAndUpdateTable(currentPage, search, fromDate, toDate);
    });
</script>