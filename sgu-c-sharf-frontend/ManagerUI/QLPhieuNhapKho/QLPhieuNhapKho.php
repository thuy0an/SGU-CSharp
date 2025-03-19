<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./QLPhieuNhapKho.css" />
    <title>Quản lý phiếu nhập kho</title>
</head>
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
</style>

<body>
    <div class="StaffLayout_wrapper__CegPk">
        <?php require_once "../ManagerHeader.php" ?>
        <div class="Manager_wrapper__vOYy">
            <?php require_once "../ManagerMenu.php" ?>
            <div style="padding-left: 16%; width: 100%; padding-right: 2rem">
                <div class="wrapper">
                    <div style="display: flex; padding-top: 1rem; padding-bottom: 1rem;">
                        <h2>Phiếu Nhập Kho</h2>
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
                            <a href="taoPhieuNhapKho.php">Tạo Phiếu Nhập</a>
                        </button>
                    </div>
                    <div class="boxFeature">
                        <!-- <div>
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
                        </div> -->
                        <!-- <div>
                            <label>
                                <span style="font-size: 1.3rem; font-weight: 700">Tìm kiếm :</span>
                                <input id="inputSearch" class="input datesearch" name="search" style="width: 20rem" type="text" />
                            </label>
                        </div> -->
                    </div>
                    <div class="Admin_boxTable__hLXRJ">
                        <table class="Table_table__BWPy">
                            <thead class="Table_head__FTUog">
                                <tr>
                                    <th class="Table_th__hCkcg">Mã Phiếu</th>
                                    <th class="Table_th__hCkcg">Ngày Nhập Kho</th>
                                    <th class="Table_th__hCkcg">Tên Nhà Cung Cấp</th>
                                    <th class="Table_th__hCkcg">Số điện thoại Nhà Cung cấp</th>
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
    var url = `${window.env.API_ROOT}`;
    fetchDataAndUpdateTable(currentPage);

    function clearTable() {
        document.querySelector('#tableBody').innerHTML = '';
    }

    // Bắt sự kiện khi người dùng ấn phím Enter trong ô tìm kiếm
    document.querySelector('#inputSearch').addEventListener('keypress', function(event) {
        // Kiểm tra xem phím được ấn có phải là Enter không (mã phím 13)
        if (event.key === 'Enter') {
            event.preventDefault();
            // Lấy giá trị của ô tìm kiếm và của select quyền
            search = document.querySelector('#inputSearch').value;
            console.log("Search: " + search);

            fetchDataAndUpdateTable(currentPage); // Gọi hàm với 4 tham số
        }
    });

    function getAllphieunhapkho(page) {
        $.ajax({
            url: `${url}/inventory-report`,
            type: 'GET',
            dataType: "json",
            headers: "",
            data: {
                pageNumber: page,
                pageSize: pageSizeGlobal
            },
            headers: {
                'Authorization': 'Bearer ' + token
            },
            success: function(response) {
                var data = response.data.content;
                var tableBody = document.getElementById("tableBody");
                var tableContent = "";

                if (data.length > 0) {
                    data.forEach(function(record, index) {
                        var formattedTongGiaTri = formatCurrency(record['totalAmount']);
                        var trClass = (index % 2 === 0) ? "Table_data_quyen_1" : "Table_data_quyen_2"; // Xác định class xen kẽ

                        var trContent = `
                            <tr class="${trClass}">
                                <td class="Table_data" style="width: 130px;">${record['id']}</td>
                                <td class="Table_data">${convertDateTimeFormat(record['createTime'])}</td>
                                <td class="Table_data">${record['supplier']['name']}</td>
                                <td class="Table_data">${record['supplier']['phone']}</td>
                                <td class="Table_data">${formattedTongGiaTri}</td>
                                <td class="Table_data">
                                    <form id="updateForm_${record['id']}" method="post" action="chi-tiet-phieu-nhap-kho.php?MaPhieu=${record['id']}">
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
                    tableContent = `<tr><td style="text-align: center;" colspan="6">Không có phiếu nhập kho nào</td></tr>`;
                }

                tableBody.innerHTML = tableContent;
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


    function fetchDataAndUpdateTable(page) {
        clearTable();
        getAllphieunhapkho(page);
    }

    function update(MaPhieu) {
        document.querySelector(`#updateForm_${MaPhieu}`).submit();
    }

    function setupPagination(totalElements, currentPage) {
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
                    getAllphieunhapkho(currentPage);
                }
            }
        });
    }
</script>