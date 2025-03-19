<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale: 1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="ThongKeDonHang.css" />
    <link rel="stylesheet" href="ThongKeTaiChinh.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <!-- Datepicker CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"
        integrity="sha512-aOG0c6nPNzGk+5zjwyJlgW6ykbmaIVk3fvo9P/oGSKG+drHma/dgRra6LuqrkOfxqXCG9Rr+YcLhWo7T/bfqcA=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <!-- jQuery UI -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"
        integrity="sha512-uto9mlQz9hkdialJULIuO4YZY6v3oLipiK4Wp4XNmOOlLuknW3RVo7ztCZmCMAjGZG0/mmrsNzyrWLNWpNJvg=="
        crossorigin="anonymous" referrerpolicy="no-referrer"></script>


    <title>Thống kê sản phẩm bán chạy</title>
    <style>
        /* Style cho container chứa các lựa chọn thống kê */
        .filter-options {
            display: flex;
            gap: 1rem;
            align-items: center;
        }

        /* Style cho các label */
        .filter-options label {
            font-size: 1.3rem;
            color: rgb(100, 100, 100);
            font-weight: 700;
        }

        /* Style cho các input và select */
        .filter-options input[type="text"],
        .filter-options select {
            height: 3rem;
            padding: 0.3rem;
        }

        #ui-datepicker-div {
            z-index: 1000 !important;
        }

        #quarterSelect,
        #monthSelect,
        #yearSelect {
            display: none;
        }
    </style>
</head>

<body>
    <div id="root">
        <div>
            <div class="App">
                <div class="StaffLayout_wrapper__CegPk">
                    <?php require_once "../ManagerHeader.php" ?>

                    <div>
                        <div>
                            <div class="Manager_wrapper__vOYy">
                                <?php require_once "../ManagerMenu.php" ?>

                                <div style="padding-left: 16%; width: 100%; padding-right: 2rem">
                                    <div class="wrapper">
                                        <div style="display: flex; padding-top: 1rem; padding-bottom: 1rem;">
                                            <h2>Thống kê sản phẩm bán chạy</h2>
                                        </div>
                                        <div class="boxFeature filter-options">
                                            <label for="period">Thống kê theo:</label>
                                            <select id="period">
                                                <option value="year">Năm</option>
                                                <option value="quarter">Quý</option>
                                                <option value="month">Tháng</option>
                                            </select>

                                            <label for="yearSelect">Năm:</label>
                                            <select id="yearSelect"></select>

                                            <label for="quarterSelect">Quý:</label>
                                            <select id="quarterSelect"></select>

                                            <label for="monthSelect">Tháng:</label>
                                            <select id="monthSelect"></select>

                                            <label for="topProductsSelect">Top sản phẩm:</label>
                                            <select id="topProductsSelect" style="height: 100%">
                                                <option value="10">Top 10</option>
                                                <option value="20">Top 20</option>
                                                <option value="50">Top 50</option>
                                                <option value="100">Top 100</option>
                                            </select>

                                            <div id="thongKeButton"
                                                style="display: flex; justify-content: center; align-items: center; width: 50px; height: 3rem; padding: 0.3rem; color: white; font-weight: 700; background-color: white;">
                                                <i style="color: black; font-size: 20px;"
                                                    class="fa-solid fa-magnifying-glass"></i>
                                            </div>
                                            <div id="resetButton"
                                                style="display: flex; justify-content: center; align-items: center; width: 50px; height: 3rem; padding: 0.3rem; color: white; font-weight: 700; background-color: white;">
                                                <i style="color: black; font-size: 20px;"
                                                    class="fa-solid fa-rotate-right"></i>
                                            </div>

                                            <p style="font-size: 1.3rem; margin-left: auto; color: rgb(100, 100, 100); font-weight: 700;">
                                                Mặc định được thống kê từ ngày 01/01/2010
                                            </p>
                                        </div>
                                        <div class="boxTable3">
                                            <h1 id="title">THỐNG KÊ SẢN PHẨM BÁN CHẠY</h1>
                                            <table id="sanPhamBanChayTable">
                                                <thead>
                                                    <tr>
                                                        <th>Mã sản phẩm</th>
                                                        <th>Tên sản phẩm</th>
                                                        <th>Ảnh</th>
                                                        <th>Tổng số lượng</th>
                                                        <th style="border-right: 0px">Tổng giá trị</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<script>
    $(document).ready(function() {
        const resetButton = document.getElementById("resetButton");
        const thongKeButton = document.getElementById("thongKeButton");
        const limit = document.getElementById('topProductsSelect');
        const period = document.getElementById('period');
        const yearSelect = document.getElementById('yearSelect');
        const quarterSelect = document.getElementById('quarterSelect');
        const monthSelect = document.getElementById('monthSelect');

        function populateYearSelect() {
            const currentYear = new Date().getFullYear();
            for (let i = 2010; i <= currentYear; i++) {
                $('#yearSelect').append(`<option value="${i}">${i}</option>`);
            }
        }

        function populateMonthSelect(year) {
            $('#monthSelect').empty();
            const currentYear = new Date().getFullYear();
            const currentMonth = new Date().getMonth() + 1;
            const months = (year == currentYear) ? currentMonth : 12;
            for (let i = 1; i <= months; i++) {
                $('#monthSelect').append(`<option value="${i}">${i}</option>`);
            }
        }

        function populateQuarterSelect(year) {
            $('#quarterSelect').empty();
            const currentYear = new Date().getFullYear();
            const currentMonth = new Date().getMonth() + 1;
            const quarters = (year == currentYear) ? Math.ceil(currentMonth / 3) : 4;
            for (let i = 1; i <= quarters; i++) {
                $('#quarterSelect').append(`<option value="${i}">Quý ${i}</option>`);
            }
        }

        // Ẩn/hiện các select tùy thuộc vào lựa chọn thống kê
        function updateVisibility() {
            yearSelect.style.display = 'none';
            quarterSelect.style.display = 'none';
            monthSelect.style.display = 'none';

            if (period.value === 'year') {
                yearSelect.style.display = 'inline';
                populateYearSelect();
            } else if (period.value === 'month') {
                yearSelect.style.display = 'inline';
                monthSelect.style.display = 'inline';
                populateYearSelect();
                if (yearSelect.value) {
                    populateMonthSelect(yearSelect.value);
                }
            } else if (period.value === 'quarter') {
                yearSelect.style.display = 'inline';
                quarterSelect.style.display = 'inline';
                populateYearSelect();
                if (yearSelect.value) {
                    populateQuarterSelect(yearSelect.value);
                }
            }
        }

        // Xử lý sự kiện khi thay đổi lựa chọn thống kê (ngày, tháng, quý, năm)
        period.addEventListener('change', () => {
            updateVisibility();
        });

        // Xử lý sự kiện khi thay đổi lựa chọn năm
        yearSelect.addEventListener('change', () => {
            if (period.value === 'month') {
                populateMonthSelect(yearSelect.value);
                monthSelect.style.display = 'inline';
            }
            if (period.value === 'quarter') {
                populateQuarterSelect(yearSelect.value);
                quarterSelect.style.display = 'inline';
            }

        });

        thongKeButton.addEventListener("click", () => {
            let topCount = limit.value;
            let periodValue = period.value;
            let selectedYear = yearSelect.value;
            let selectedQuarter = quarterSelect.value;
            let selectedMonth = monthSelect.value;

            let startDate = "2010-01-01";
            let endDate = new Date().toISOString().slice(0, 10);

            if (periodValue === 'quarter' && selectedYear && selectedQuarter) {
                let startMonth, endMonth;
                switch (selectedQuarter) {
                    case '1':
                        startMonth = '01';
                        endMonth = '03';
                        break;
                    case '2':
                        startMonth = '04';
                        endMonth = '06';
                        break;
                    case '3':
                        startMonth = '07';
                        endMonth = '09';
                        break;
                    case '4':
                        startMonth = '10';
                        endMonth = '12';
                        break;
                    default:
                        startMonth = '01';
                        endMonth = '03';
                }
                startDate = `${selectedYear}-${startMonth}-01`;
                endDate = getLastDayOfMonth(selectedYear, endMonth); // Sử dụng hàm để lấy ngày cuối tháng

            } else if (periodValue === 'month' && selectedYear && selectedMonth) {
                const month = String(selectedMonth).padStart(2, '0');
                startDate = `${selectedYear}-${month}-01`;
                endDate = getLastDayOfMonth(selectedYear, selectedMonth); // Sử dụng hàm để lấy ngày cuối tháng
            } else if (periodValue === 'year' && selectedYear) {
                startDate = `${selectedYear}-01-01`;
                endDate = `${selectedYear}-12-31`;
            }

            thongKeSanPhamBanChay(startDate, endDate, topCount);
        });

        function getLastDayOfMonth(year, month) {
            const lastDay = new Date(year, month, 0).getDate(); // Lưu ý: month trong Date() bắt đầu từ 0
            month = String(month).padStart(2, '0'); // Đảm bảo tháng có 2 chữ số
            return `${year}-${month}-${lastDay}`;
        }

        resetButton.addEventListener("click", () => {
            limit.value = '10';
            period.value = 'year';
            updateVisibility();
            thongKeSanPhamBanChay("2010-01-01", new Date().toISOString().slice(0, 10), 10, 'year');
        });

        var currentDate = new Date();
        var year = currentDate.getFullYear();
        var month = (currentDate.getMonth() + 1).toString().padStart(2, '0');
        var day = currentDate.getDate().toString().padStart(2, '0');
        var formattedDate = year + '-' + month + '-' + day;

        // Khởi tạo các select khi trang tải
        updateVisibility();
        //set giá trị mặc định của yearSelect là năm hiện tại
        yearSelect.value = year;
        thongKeSanPhamBanChay("2010-01-01", new Date().toISOString().slice(0, 10), 10, 'year');

        function thongKeSanPhamBanChay(from, to, topCount) {
            $.ajax({
                url: 'http://localhost:8080/api/statistics/inventory',
                type: 'GET',
                dataType: "json",
                data: {
                    startDate: from,
                    endDate: to,
                    limit: topCount,
                },
                success: function(response) {
                    var tableBody = document.querySelector("#sanPhamBanChayTable tbody");
                    tableBody.innerHTML = "";
                    console.log(response)
                    if (response && response.data.length > 0) {
                        response.data.forEach(item => {
                            var formattedValue = formatCurrency(parseFloat(item.totalAmount) || 0);
                            var row = document.createElement("tr");
                            row.innerHTML = `
                                            <td>${item.id}</td>
                                            <td>${item.productName}</td>
                                            <td style="text-align: center; vertical-align: middle;">
                                                <img style="max-width: 100px; height: auto; border-radius: 8px; object-fit: cover;" 
                                                    src="${window.env.CLOUDINARY_API}/${item.image}" 
                                                    alt="Product Image">
                                            </td> 
                                            <td>${item.quantity}</td>
                                            <td>${formattedValue}</td>
                                        `;
                            tableBody.appendChild(row);
                        });

                    } else {
                        var row = document.createElement("tr");
                        row.innerHTML = `<td colspan="4">Không có dữ liệu</td>`;
                        tableBody.appendChild(row);
                    }
                },
                error: function(xhr, status, error) {
                    console.error('Lỗi khi gọi API: ', error);
                }
            });
        }

        function formatCurrency(number) {
            return number.toLocaleString('vi-VN', {
                style: 'currency',
                currency: 'VND'
            });
        }
    });
</script>

</html>