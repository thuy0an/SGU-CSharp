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

        /* Main layout with sidebar and content */
        .main-container {
            display: flex;
            padding: 20px;
            gap: 20px;
        }

        .user-history-nav {
            margin: 30px 0;
            padding: 20px;
            background-color: #fff3e0;
            /* vàng nhạt */
            border-right: 3px solid #7b181a;
            /* đỏ viền */
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
            /* cam đậm khi hover */
        }

        .nav-tabs li a.active {
            background-color: #7b181a;
            color: white !important;
            border-left: 5px solid #fbc02d;
            /* vàng nổi bật */
        }

        /* Main content area */
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

        .pagination {
            display: flex;
            justify-content: center;
            margin-top: 16px;
        }

        .pagination-content {
            display: flex;
            gap: 8px;
        }

        .pagination-item {
            display: inline-block;
        }

        .pagination-link {
            padding: 4px 12px;
            border: 1px solid #d1d5db;
            border-radius: 4px;
            color: #374151;
            text-decoration: none;
            font-size: 14px;
        }

        .pagination-link:hover {
            background-color: #f3f4f6;
        }

        .pagination-link.active {
            background-color: #2563eb;
            color: white;
            border-color: #2563eb;
        }

        .pagination-previous,
        .pagination-next {
            padding: 4px 12px;
            border: 1px solid #d1d5db;
            border-radius: 4px;
            color: #374151;
            text-decoration: none;
            font-size: 14px;
        }

        .pagination-previous:hover,
        .pagination-next:hover {
            background-color: #f3f4f6;
        }

        .pagination-previous.disabled,
        .pagination-next.disabled {
            pointer-events: none;
            opacity: 0.5;
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
                <div class="flex justify-between items-center">
                    <div>
                        <h1 class="text-2xl font-bold tracking-tight">Lịch sử vi phạm</h1>
                        <p class="text-muted-foreground">Xem thông tin các vi phạm và phiếu xử phạt của bạn</p>
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
                                    <th class="table-head">Thiết bị</th>
                                    <th class="table-head">Ngày vi phạm</th>
                                    <th class="table-head">Thời gian xử phạt (ngày)</th>
                                    <th class="table-head">Mô tả</th>
                                    <th class="table-head">Mức phạt</th>
                                    <th class="table-head">Trạng thái</th>
                                </tr>
                            </thead>
                            <tbody id="violations-table-body">
                                <!-- Table rows will be populated by JavaScript -->
                            </tbody>
                        </table>

                        <!-- Pagination -->
                        <div class="pagination" id="pagination">
                            <div class="pagination-content" id="pagination-content">
                                <!-- Pagination links will be populated by JavaScript -->
                            </div>
                        </div>
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
        const violations = [{
                id: "V001",
                equipmentName: "Máy chiếu",
                date: "2023-10-01T14:30:00",
                description: "Trễ hạn trả 3 ngày",
                penalty: "500,000 VNĐ",
                status: "pending"
            },
            {
                id: "V002",
                equipmentName: "Laptop",
                date: "2023-09-15T09:00:00",
                description: "Màn hình bị nứt",
                penalty: "2,000,000 VNĐ",
                status: "paid"
            },
            {
                id: "V003",
                equipmentName: "Máy in",
                date: "2023-08-20T16:00:00",
                description: "Không tìm thấy thiết bị",
                penalty: "5,000,000 VNĐ",
                status: "waived"
            },
            {
                id: "V004",
                equipmentName: "Bàn phím",
                date: "2023-07-10T11:00:00",
                description: "Trễ hạn trả 1 ngày",
                penalty: "100,000 VNĐ",
                status: "pending"
            },
            {
                id: "V005",
                equipmentName: "Chuột",
                date: "2023-06-05T13:30:00",
                description: "Sử dụng sai mục đích",
                penalty: "200,000 VNĐ",
                status: "paid"
            },
            {
                id: "V006",
                equipmentName: "Micro",
                date: "2023-05-01T15:00:00",
                description: "Trễ hạn trả 2 ngày",
                penalty: "300,000 VNĐ",
                status: "pending"
            },
        ];
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
            },
        };
        const itemsPerPage = 5;
        let currentPage = 1;
        const totalPages = Math.ceil(violations.length / itemsPerPage);

        // Calculate days between violation date and today (May 06, 2025)
        function calculateDaysSince(dateString) {
            const violationDate = new Date(dateString);
            const today = new Date("2025-05-06");
            const diffTime = Math.abs(today - violationDate);
            const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
            return diffDays;
        }

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

        function renderViolations(page) {
            const start = (page - 1) * itemsPerPage;
            const end = page * itemsPerPage;
            const currentViolations = violations.slice(start, end);
            const tbody = document.getElementById("violations-table-body");
            tbody.innerHTML = "";
            currentViolations.forEach(violation => {
                const daysSince = calculateDaysSince(violation.date);
                const row = document.createElement("tr");
                row.className = "table-row";
                row.innerHTML = `
                    <td class="table-cell font-medium">${violation.id}</td>
                    <td class="table-cell">${violation.equipmentName}</td>
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

            renderPagination(page);
        }

        function renderPagination(page) {
            const paginationContent = document.getElementById("pagination-content");
            paginationContent.innerHTML = "";
            const prevLink = document.createElement("a");
            prevLink.className = `pagination-previous ${page === 1 ? "disabled" : ""}`;
            prevLink.textContent = "Trước";
            prevLink.onclick = () => {
                if (page > 1) {
                    currentPage--;
                    renderViolations(currentPage);
                }
            };
            paginationContent.appendChild(prevLink);
            for (let i = 1; i <= totalPages; i++) {
                const pageLink = document.createElement("a");
                pageLink.className = `pagination-link ${i === page ? "active" : ""}`;
                pageLink.textContent = i;
                pageLink.onclick = () => {
                    currentPage = i;
                    renderViolations(currentPage);
                };
                paginationContent.appendChild(pageLink);
            }

            const nextLink = document.createElement("a");
            nextLink.className = `pagination-next ${page === totalPages ? "disabled" : ""}`;
            nextLink.textContent = "Sau";
            nextLink.onclick = () => {
                if (page < totalPages) {
                    currentPage++;
                    renderViolations(currentPage);
                }
            };
            paginationContent.appendChild(nextLink);
        }

        function renderStats() {
            document.getElementById("total-violations").textContent = violations.length;
            document.getElementById("pending-violations").textContent = violations.filter(v => v.status === "pending").length;
            document.getElementById("paid-violations").textContent = violations.filter(v => v.status === "paid").length;
            document.getElementById("waived-violations").textContent = violations.filter(v => v.status === "waived").length;
            document.getElementById("update-time").textContent = new Date().toLocaleTimeString('vi-VN');
        }

        renderViolations(currentPage);
        renderStats();
    </script>
</body>

</html>