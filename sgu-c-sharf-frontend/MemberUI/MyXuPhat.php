<!DOCTYPE html>
<html lang="vi">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lịch sử vi phạm</title>

    <!-- External CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" integrity="sha384-k6RqeWeci5ZR/Lv4MR0sA0FfDOMlI4F/x3Rgx31ZobM4uZ5dI6cuJg6RZ/aXjmD" crossorigin="anonymous">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">

    <!-- Custom CSS -->
    <link rel="stylesheet" href="./HomePage.css">
    <link rel="stylesheet" href="./Profile.css">
    <link rel="stylesheet" href="./login.css">

    <!-- External JS -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../utils/formatOutput.js"></script>

    <!-- Inline CSS -->
    <style>
        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
        }

        body {
            background-color: #f4f4f9;
            line-height: 1.6;
        }

        .main-container {
            display: flex;
            gap: 20px;
        }

        .user-history-nav {
            padding: 20px;
            background-color: #fff3e0;
            border-right: 3px solid #7b181a;
            min-height: 100%;
        }

        .nav-tabs {
            list-style: none;
            padding: 0;
            margin: 0;
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        .nav-tabs li a {
            text-decoration: none;
            padding: 12px 20px;
            display: block;
            color: #7b181a;
            background-color: #fff3e0;
            border-left: 5px solid transparent;
            font-weight: 600;
            border-radius: 4px;
            transition: all 0.3s ease;
        }

        .nav-tabs li a:hover {
            background-color: #ffe0b2;
            color: #b71c1c;
            border-left: 5px solid #f57c00;
        }

        .nav-tabs li a.active {
            background-color: #7b181a;
            color: white !important;
            border-left: 5px solid #fbc02d;
        }

        .content-area {
            flex: 1;
            max-width: 80vw;
        }

        .space-y-6 {
            margin-bottom: 24px;
        }

        .flex {
            display: flex;
        }

        .justify-between {
            justify-content: space-between;
        }

        .items-center {
            align-items: center;
        }

        .text-2xl {
            font-size: 1.5rem;
        }

        .font-bold {
            font-weight: 700;
        }

        .tracking-tight {
            letter-spacing: -0.025em;
        }

        .text-muted-foreground {
            color: #6b7280;
        }

        .button {
            display: inline-flex;
            align-items: center;
            gap: 8px;
            padding: 8px 16px;
            border: 1px solid #d1d5db;
            border-radius: 4px;
            background-color: white;
            color: #374151;
            font-size: 14px;
            cursor: pointer;
            transition: background-color 0.2s;
        }

        .button:hover {
            background-color: #f3f4f6;
        }

        .button svg {
            width: 16px;
            height: 16px;
        }

        .card {
            background-color: white;
            border-radius: 8px;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
            margin-bottom: 24px;
        }

        .card-header {
            padding: 16px;
        }

        .card-title {
            font-size: 1.25rem;
            font-weight: 600;
            margin-bottom: 8px;
        }

        .card-description {
            font-size: 0.875rem;
            color: #6b7280;
        }

        .card-content {
            padding: 16px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
        }

        .table-header {
            background-color: #f9fafb;
        }

        .table-row {
            border-bottom: 1px solid #e5e7eb;
        }

        .table-head,
        .table-cell {
            padding: 12px;
            text-align: left;
            font-size: 0.875rem;
        }

        .table-head {
            font-weight: 600;
            color: #374151;
        }

        .table-cell {
            color: #4b5563;
        }

        .font-medium {
            font-weight: 500;
        }

        .badge {
            display: inline-flex;
            align-items: center;
            padding: 2px 8px;
            border-radius: 12px;
            font-size: 0.75rem;
            font-weight: 500;
        }

        .badge-default {
            background-color: #e5e7eb;
            color: #374151;
        }

        .badge-destructive {
            background-color: #fee2e2;
            color: #dc2626;
        }

        .badge-secondary {
            background-color: #f3f4f6;
            color: #6b7280;
        }

        .badge-outline {
            border: 1px solid #d1d5db;
            color: #374151;
        }

        .grid {
            display: grid;
            gap: 16px;
        }

        .grid-cols-1 {
            grid-template-columns: 1fr;
        }

        .md-grid-cols-3 {
            grid-template-columns: repeat(3, 1fr);
        }

        .stat-box {
            padding: 16px;
            background-color: #f3f4f6;
            border-radius: 8px;
            text-align: center;
        }

        .stat-value {
            font-size: 1.5rem;
            font-weight: 700;
            color: #1f2937;
        }

        .stat-label {
            font-size: 0.875rem;
            color: #6b7280;
        }

        @media (max-width: 768px) {
            .main-container {
                flex-direction: column;
            }

            .user-history-nav {
                width: 100%;
            }

            .content-area {
                max-width: 100%;
            }

            .md-grid-cols-3 {
                grid-template-columns: 1fr;
            }
        }
    </style>
</head>

<body>
    <?php require_once "./Header.php"; ?>

    <div class="main-container">
        <!-- Sidebar Navigation -->
        <section class="user-history-nav" style="width: 20vw; padding: 20px;">
            <ul class="nav-tabs">
                <li><a href="MyOrder.php">Lịch sử phiếu mượn</a></li>
                <li><a href="MyXuPhat.php" class="active">Lịch sử xử phạt</a></li>
                <li><a href="MyCheckIn.php">Lịch sử check in</a></li>
            </ul>
        </section>

        <!-- Main Content -->
        <div class="content-area">
            <div class="space-y-6">
                <!-- Header -->
                <div class="center-text" style="margin-top: 20px;">
                    <div class="title_section">
                        <div class="bar"></div>
                        <h2 class="center-text-share">Lịch sử vi phạm</h2>
                    </div>
                </div>

                <!-- Violations Table -->
                <div class="card">
                    <div class="card-header">
                        <h2 class="card-title">Danh sách vi phạm</h2>
                        <p class="card-description">Tổng cộng: <span id="total-violations">0</span> vi phạm</p>
                    </div>
                    <div class="card-content">
                        <table class="table">
                            <thead class="table-header">
                                <tr class="table-row">
                                    <th class="table-head">ID</th>
                                    <th class="table-head">Ngày vi phạm</th>
                                    <th class="table-head">Số ngày xử phạt</th>
                                    <th class="table-head">Mô tả</th>
                                    <th class="table-head">Mức phạt</th>
                                    <th class="table-head">Trạng thái</th>
                                </tr>
                            </thead>
                            <tbody id="violations-table-body">
                                <!-- Table rows will be populated by JavaScript -->
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- Stats Card -->
                <div class="card">
                    <div class="card-header">
                        <div class="flex items-center justify-between">
                            <div>
                                <h2 class="card-title">Thống kê vi phạm</h2>
                                <p class="card-description">Tổng kết các vi phạm theo thời gian</p>
                            </div>
                            <span class="badge badge-outline">
                                <svg class="h-3 w-3" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M12 22s-8-4-8-10V5l8-3 8 3v7c0 6-8 10-8 10z" />
                                </svg>
                                Cập nhật lúc: <span id="update-time"></span>
                            </span>
                        </div>
                    </div>
                    <div class="card-content">
                        <div class="grid grid-cols-1 md-grid-cols-3">
                            <div class="stat-box">
                                <div class="stat-value" id="pending-violations">0</div>
                                <div class="stat-label">Vi phạm chưa xử lý</div>
                            </div>
                            <div class="stat-box">
                                <div class="stat-value" id="paid-violations">0</div>
                                <div class="stat-label">Vi phạm đã xử lý</div>
                            </div>
                            <div class="stat-box">
                                <div class="stat-value" id="waived-violations">0</div>
                                <div class="stat-label">Vi phạm đã xóa</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <?php require_once "./Footer.php"; ?>

    <script>
        let violations = []; // Array to store API data
        const statusMap = {
            pending: {
                text: "Chưa xử lý",
                class: "badge-destructive"
            },
            paid: {
                text: "Đã xử lý",
                class: "badge-default"
            },
            waived: {
                text: "Đã xóa",
                class: "badge-secondary"
            }
        };

        // Map numeric status to string
        function mapStatus(status) {
            switch (status) {
                case 0:
                    return "pending";
                case 1:
                    return "waived";
                case 2:
                    return "paid";
                default:
                    return "pending";
            }
        }

        // Calculate days between violation date and today (May 07, 2025)
        function calculateDaysSince(dateString) {
            const violationDate = new Date(dateString);
            const today = new Date("2025-05-07");
            const diffTime = Math.abs(today - violationDate);
            const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
            return diffDays;
        }

        // Format date to Vietnamese format
        function formatDate(dateString) {
            const date = new Date(dateString);
            return new Intl.DateTimeFormat('vi-VN', {
                year: 'numeric',
                month: '2-digit',
                day: '2-digit',
                hour: '2-digit',
                minute: '2-digit'
            }).format(date);
        }

        // Format penalty to Vietnamese currency
        function formatPenalty(amount) {
            return new Intl.NumberFormat('vi-VN', {
                style: 'currency',
                currency: 'VND'
            }).format(amount);
        }

        function renderViolations() {
            const tbody = document.getElementById("violations-table-body");
            tbody.innerHTML = "";
            violations.forEach(violation => {
                const daysSince = calculateDaysSince(violation.date);
                const row = document.createElement("tr");
                row.className = "table-row";
                row.innerHTML = `
                    <td class="table-cell font-medium">${violation.id}</td>
                    <td class="table-cell">${formatDate(violation.date)}</td>
                    <td class="table-cell">${daysSince}</td>
                    <td class="table-cell">${violation.description}</td>
                    <td class="table-cell">${violation.penalty}</td>
                    <td class="table-cell">
                        <span class="badge ${statusMap[violation.status].class}">
                            ${statusMap[violation.status].text}
                        </span>
                    </td>
                `;
                tbody.appendChild(row);
            });
        }

        function renderStats() {
            document.getElementById("total-violations").textContent = violations.length;
            document.getElementById("pending-violations").textContent = violations.filter(v => v.status === "pending").length;
            document.getElementById("paid-violations").textContent = violations.filter(v => v.status === "paid").length;
            document.getElementById("waived-violations").textContent = violations.filter(v => v.status === "waived").length;
            document.getElementById("update-time").textContent = new Date().toLocaleTimeString('vi-VN');
        }

        // Fetch data from API
        function fetchViolations() {
            const userId = sessionStorage.getItem('id');
            if (!userId) {
                Swal.fire({
                    icon: 'error',
                    title: 'Lỗi',
                    text: 'Không tìm thấy ID người dùng. Vui lòng đăng nhập lại.',
                });
                return;
            }

            $.ajax({
                url: `http://localhost:5244/api/phieu-xu-phat/user/${userId}`,
                method: 'GET',
                dataType: 'json',
                success: function(response) {
                    if (response.status !== 200 || !response.data) {
                        Swal.fire({
                            icon: 'error',
                            title: 'Lỗi',
                            text: response.message || 'Không tìm thấy dữ liệu vi phạm.',
                        });
                        return;
                    }

                    // Map API response to violations array
                    const data = response.data;
                    violations = [{
                        id: data.id.toString(),
                        date: data.ngayViPham,
                        description: data.moTa,
                        penalty: formatPenalty(data.mucPhat),
                        status: mapStatus(data.trangThai)
                    }];

                    // Render table and stats
                    renderViolations();
                    renderStats();
                },
                error: function(xhr, status, error) {
                    // Swal.fire({
                    //     icon: 'error',
                    //     title: 'Lỗi',
                    //     text: 'Không thể lấy dữ liệu vi phạm: ' + (xhr.responseJSON?.message || error),
                    // });
                }
            });
        }

        // Call fetchViolations on page load
        $(document).ready(function() {
            fetchViolations();
        });
    </script>
</body>

</html>