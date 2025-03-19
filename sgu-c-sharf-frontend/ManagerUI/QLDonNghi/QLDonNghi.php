<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./QLDonNghi.css" />
    <title>Quản lý phiếu nhập kho</title>
</head>
<style>
        .paginationjs {
            display: flex;
            justify-content: center;
            padding: 20px 0;
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
                        <h2>Đơn xin nghỉ</h2>
                   
                    </div>
                    <div class="boxFeature">
                      
                        <div>
                            <label>
                                <span style="font-size: 1.3rem; font-weight: 700">Tìm kiếm :</span>
                                <input id="inputSearch" class="input datesearch" name="search" style="width: 20rem" type="text" />
                            </label>
                        </div>
                        <div>
                            <label>
                                <span style="font-size: 1.3rem; font-weight: 700">Trạng thái :</span>
                                <select id="statusFilter" name="status" 
                                    style="
                                        width: 20rem; 
                                        padding: 0.5rem; 
                                        font-size: 1.5rem; 
                                        border: 2px solid #ccc; 
                                        border-radius: 8px; 
                                        background-color: #fff; 
                                        color: #333; 
                                        outline: none; 
                                        cursor: pointer;
                                        transition: border-color 0.3s ease-in-out;">
                                    <option value="">Tất cả</option>
                                    <option value="APPROVED">Đã duyệt</option>
                                    <option value="PENDING">Chờ duyệt</option>
                                    <option value="REJECTED">Từ chối</option>
                                </select>
                            </label>
                        </div>
                    </div>
                    <div class="Admin_boxTable__hLXRJ">
                        <table class="Table_table__BWPy">
                            <thead class="Table_head__FTUog">
                                <tr>
                                    <th class="Table_th__hCkcg">Mã Phiếu</th>
                                    <th class="Table_th__hCkcg">Ngày lập phiếu</th>
                                    <th class="Table_th__hCkcg">Tên người lập</th>
                                    <th class="Table_th__hCkcg">Trạng thái</th>
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
    var status = "";
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

    document.getElementById("statusFilter").addEventListener("change", function() {
        status = this.value;
        
        // Gọi hàm lọc dữ liệu (bạn có thể thay thế bằng AJAX hoặc cập nhật giao diện)
        fetchDataAndUpdateTable(currentPage); // Gọi hàm với 4 tham số
    });


    function getAllphieunhapkho(page) {
        $.ajax({
            url: `${url}/leave-applications`,
            type: 'GET',
            dataType: "json",
            data: {
                pageNumber: page,
                pageSize: pageSizeGlobal,
                search: search,
                status: status
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
                                <td class="Table_data">${record['applicantFullname']}</td>
                                <td class="Table_data">${record['status']}</td>
                                <td class="Table_data">
                                    <form id="updateForm_${record['id']}" method="post" action="chi-tiet-don-xin-nghi.php?MaPhieu=${record['id']}">
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
