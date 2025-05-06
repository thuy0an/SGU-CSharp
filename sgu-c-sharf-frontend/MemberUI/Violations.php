<!DOCTYPE html>
<html lang="vi">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="./Profile.css">
    <title>Thông tin cá nhân</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <!-- <link rel="stylesheet" href="./login.css" /> -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../utils/formatOutput.js"></script>
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"
        integrity="sha384-k6RqeWeci5ZR/Lv4MR0sA0FfDOMlI4F/x3Rgx31ZobM4uZ5dI6cuJg6RZ/aXjmD"
        crossorigin="anonymous">
</head>
<?php require_once "./Header.php" ?>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lịch sử vi phạm</title>
    <style>
        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
        }

        body {
            background-color: #f4f4f9;
            padding: 20px;
            line-height: 1.6;
        }

        /* Container */
        .space-y-6 {
            margin-bottom: 24px;
        }

        /* Flex layout for header */
        .flex {
            display: flex;
        }

        .justify-between {
            justify-content: space-between;
        }

        .items-center {
            align-items: center;
        }

        /* Typography */
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

        /* Button */
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

        /* Card */
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

        /* Table */
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

        /* Badge */
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

        /* Pagination */
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

        /* Stats Grid */
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
            .md-grid-cols-3 {
                grid-template-columns: 1fr;
            }
        }
    </style>
</head>

<body>
    <div class="space-y-6">
        <!-- Header -->
        <div class="flex justify-between items-center">
            <div>
                <h1 class="text-2xl font-bold tracking-tight">Lịch sử vi phạm</h1>
                <p class="text-muted-foreground">Xem thông tin các vi phạm và phiếu xử phạt của bạn</p>
            </div>
            <div>
                <button class="button" onclick="alert('Chức năng xuất báo cáo chưa được triển khai!')">
                    <svg class="h-4 w-4" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <path d="M13 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V9z" />
                        <path d="M13 2v7h7" />
                    </svg>
                    Xuất báo cáo
                </button>
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
                            <th class="table-head">Loại vi phạm</th>
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
                        <div class="stat-value" id="late-violations">0</div>
                        <div class="stat-label">Vi phạm trễ hạn</div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        const violations = [{
                id: "V001",
                equipmentName: "Máy chiếu",
                date: "2023-10-01T14:30:00",
                violationType: "late",
                description: "Trễ hạn trả 3 ngày",
                penalty: "500,000 VNĐ",
                status: "pending"
            },
            {
                id: "V002",
                equipmentName: "Laptop",
                date: "2023-09-15T09:00:00",
                violationType: "damaged",
                description: "Màn hình bị nứt",
                penalty: "2,000,000 VNĐ",
                status: "paid"
            },
            {
                id: "V003",
                equipmentName: "Máy in",
                date: "2023-08-20T16:00:00",
                violationType: "lost",
                description: "Không tìm thấy thiết bị",
                penalty: "5,000,000 VNĐ",
                status: "waived"
            },
            {
                id: "V004",
                equipmentName: "Bàn phím",
                date: "2023-07-10T11:00:00",
                violationType: "late",
                description: "Trễ hạn trả 1 ngày",
                penalty: "100,000 VNĐ",
                status: "pending"
            },
            {
                id: "V005",
                equipmentName: "Chuột",
                date: "2023-06-05T13:30:00",
                violationType: "misuse",
                description: "Sử dụng sai mục đích",
                penalty: "200,000 VNĐ",
                status: "paid"
            },
            {
                id: "V006",
                equipmentName: "Micro",
                date: "2023-05-01T15:00:00",
                violationType: "late",
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
        const violationTypeMap = {
            late: {
                text: "Trễ hạn",
                class: "badge-outline"
            },
            damaged: {
                text: "Hư hỏng",
                class: "badge-destructive"
            },
            lost: {
                text: "Mất thiết bị",
                class: "badge-destructive"
            },
            misuse: {
                text: "Sử dụng sai",
                class: "badge-secondary"
            },
        };
        const itemsPerPage = 5;
        let currentPage = 1;
        const totalPages = Math.ceil(violations.length / itemsPerPage);

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
                const row = document.createElement("tr");
                row.className = "table-row";
                row.innerHTML = `
                    <td class="table-cell font-medium">${violation.id}</td>
                    <td class="table-cell">${violation.equipmentName}</td>
                    <td class="table-cell">${formatDate(violation.date)}</td>
                    <td class="table-cell">
                        <span class="badge ${violationTypeMap[violation.violationType].class}">
                            ${violationTypeMap[violation.violationType].text}
                        </span>
                    </td>
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
            document.getElementById("late-violations").textContent = violations.filter(v => v.violationType === "late").length;
            document.getElementById("update-time").textContent = new Date().toLocaleTimeString('vi-VN');
        }
        renderViolations(currentPage);
        renderStats();
    </script>
</body>

</html>
<?php require_once "./Footer.php" ?>