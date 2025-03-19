<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./taoPhieuNhapKho.css" />
    <title>Chi tiết đơn xin nghỉ</title>
</head>

<body>
    <div class="StaffLayout_wrapper__CegPk">
        <?php require_once "../ManagerHeader.php" ?>

        <div class="Manager_wrapper__vOYy">
            <?php require_once "../ManagerMenu.php" ?>

            <div style="padding-left: 16%; width: 100%; padding-right: 2rem">
                <div class="wrapper">
                    <div style="display: flex; padding-top: 1rem; padding-bottom: 1rem;">
                        <h2>Đơn xin nghỉ</h2>
                        <div style="margin-left: auto;">
                            <button style="font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; color: rgb(65, 64, 64); border: 1px solid rgb(65, 64, 64); background-color: white; padding: 1rem; border-radius: 0.6rem; cursor: pointer;" onclick="clearSelectedProducts()">
                                <a href="./QLDonNghi.php">
                                    <?php
                                    if (!isset($_GET['MaPhieu'])) echo 'Hủy';
                                    else echo 'Quay lại';
                                    ?>
                                </a>
                            </button>
                        </div>
                    </div>
                
                    <div class="boxTable" style="height: 60rem; overflow-y: inherit;">
                        

                        <div style="
                            width: 25%; 
                            background-color: rgb(236, 233, 233); 
                            padding: 1.5rem; 
                            border-radius: 1rem; 
                            box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
                            font-family: Arial, sans-serif;">
                            
                            <h2 style="
                                text-align: center; 
                                font-size: 1.5rem; 
                                font-weight: 700; 
                                margin-bottom: 1rem; 
                                color: white; 
                                background-color: black; 
                                padding: 0.75rem; 
                                border-radius: 0.5rem;">
                                Thông tin người gửi
                            </h2>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Mã nhân viên</p>
                                <input id="applicantId" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #4CAF50; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Họ tên</p>
                                <input id="applicantFullName" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #FF9800; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Email</p>
                                <input id="applicantEmail" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Số điện thoại</p>
                                <input id="applicantPhone" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid rgb(34, 49, 184); border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Trạng thái</p>
                                <input id="applicantStatus" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #F44336; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>
                        </div>

                        <div style="
                            width: 50%; 
                            background-color: rgb(236, 233, 233); 
                            padding: 1.5rem; 
                            border-radius: 1rem; 
                            box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
                            font-family: Arial, sans-serif;">
                            
                            <h2 style="
                                text-align: center; 
                                font-size: 1.5rem; 
                                font-weight: 700; 
                                margin-bottom: 1rem; 
                                color: white; 
                                background-color: black; 
                                padding: 0.75rem; 
                                border-radius: 0.5rem;">
                                Thông tin phiếu
                            </h2>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Mã phiếu</p>
                                <input id="id" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #4CAF50; border-radius: 0.5rem; text-align: center;"
                                    value="<?php if (isset($_GET['MaPhieu'])) echo $_GET['MaPhieu']; ?>" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày lập phiếu</p>
                                <input id="supplierName" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #FF9800; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày bắt đầu</p>
                                <input id="supplierPhone" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày kết thúc</p>
                                <input id="managerName" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid rgb(34, 49, 184); border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Trạng thái</p>
                                <input id="totalAmount" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #F44336; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <!-- Thời gian duyệt -->
                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Thời gian duyệt</p>
                                <input id="approvalTime" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #2196F3; border-radius: 0.5rem; text-align: center;"
                                    value="Chưa duyệt" 
                                    disabled />
                            </label>

                            <!-- Lý do -->
                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Lý do</p>
                                <textarea id="approvalReason" 
                                    style="height: 6rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #FF5722; border-radius: 0.5rem; text-align: center; resize: none;"
                                    disabled>Chưa có lý do</textarea>
                            </label>

                            <!-- Lý do -->
                            <label style="display: block; margin-bottom: 1rem;" id="actionButtonsContainer">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Chức năng</p>
                                <div style="display: flex; justify-content: center; gap: 1rem;">
                                    <!-- Nút duyệt phiếu -->
                                    <button onclick="updateStatus('APPROVED')" 
                                        style="padding: 0.75rem 1.5rem; background-color: #4CAF50; color: white; font-weight: 700; 
                                            border: none; border-left: 5px solid #388E3C; border-radius: 0.5rem; cursor: pointer;
                                            transition: background-color 0.3s, transform 0.2s;"
                                        onmouseover="this.style.backgroundColor='#388E3C'; this.style.transform='scale(1.05)';"
                                        onmouseout="this.style.backgroundColor='#4CAF50'; this.style.transform='scale(1)';">
                                        Duyệt Phiếu
                                    </button>

                                    <!-- Nút từ chối phiếu -->
                                    <button onclick="updateStatus('REJECTED')" 
                                        style="padding: 0.75rem 1.5rem; background-color: #F44336; color: white; font-weight: 700; 
                                            border: none; border-left: 5px solid #D32F2F; border-radius: 0.5rem; cursor: pointer;
                                            transition: background-color 0.3s, transform 0.2s;"
                                        onmouseover="this.style.backgroundColor='#D32F2F'; this.style.transform='scale(1.05)';"
                                        onmouseout="this.style.backgroundColor='#F44336'; this.style.transform='scale(1)';">
                                        Từ Chối Phiếu
                                    </button>
                                </div>
                            </label>

                            
                        </div>


                        <div style="
                            width: 25%;
                            background-color: rgb(236, 233, 233);
                            padding: 1.5rem;
                            border-radius: 1rem;
                            box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
                            font-family: Arial, sans-serif;">
                            
                            <h2 style="
                                text-align: center;
                                font-size: 1.5rem;
                                font-weight: 700;
                                margin-bottom: 1rem;
                                color: white;
                                background-color: black;
                                padding: 0.75rem;
                                border-radius: 0.5rem;">
                                Thông tin người duyệt
                            </h2>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Mã nhân viên</p>
                                <input id="approverId"
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #4CAF50; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Họ tên</p>
                                <input id="approverFullName"
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #FF9800; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Email</p>
                                <input id="approverEmail"
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Số điện thoại</p>
                                <input id="approverPhone"
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid rgb(34, 49, 184); border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>

                            <label style="display: block;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Trạng thái</p>
                                <input id="approverStatus"
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #F44336; border-radius: 0.5rem; text-align: center;"
                                    value="" 
                                    disabled />
                            </label>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</body>



<script>
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get('MaPhieu');        
    const url = window.env.API_ROOT;
    const approverId = sessionStorage.getItem("id");

    $(document).ready(function() {
        loadLeaveApplication(id);
        hideButtonsIfNotPending();

    });

     function loadLeaveApplication(id) {
        $.ajax({
            url: `${url}/leave-applications/${id}`,
            method: "GET",
            dataType: "json",
            success: function(response) {
                let data = response.data;
                
                // Load dữ liệu vào các input
                $("#id").val(data.id);
                $("#supplierName").val(convertDateTimeFormat(data.createTime));  // Ngày lập phiếu
                $("#supplierPhone").val(formatDateToDDMMYYYY(data.startDate));  // Ngày bắt đầu
                $("#managerName").val(formatDateToDDMMYYYY(data.endDate));      // Ngày kết thúc
                $("#totalAmount").val(data.status);       // Trạng thái
                $("#approvalTime").val(data.decisionTime ? convertDateTimeFormat(data.decisionTime) : "Chưa duyệt");
                $("#approvalReason").val(data.reason ? data.reason : "Chưa có lý do");

                // Gán dữ liệu vào input
                $("#applicantId").val(data.applicant.id);
                $("#applicantFullName").val(data.applicant.fullname);
                $("#applicantEmail").val(data.applicant.email);
                $("#applicantPhone").val(data.applicant.phone);
                $("#applicantStatus").val(data.applicant.status);

                 // Kiểm tra nếu có người duyệt thì gán dữ liệu, nếu không thì hiển thị mặc định
                let approver = data.approver || {
                    id: "Chưa có",
                    fullname: "Chưa có người duyệt",
                    email: "Chưa có email",
                    phone: "Chưa có số điện thoại",
                    status: "Chưa duyệt"
                };

                $("#approverId").val(approver.id);
                $("#approverFullName").val(approver.fullname);
                $("#approverEmail").val(approver.email);
                $("#approverPhone").val(approver.phone);
                $("#approverStatus").val(approver.status);

            },
            error: function(xhr, status, error) {
                console.error("Lỗi API:", error);
                alert("Lỗi khi lấy dữ liệu. Vui lòng thử lại!");
            }
        });
    }

    function updateStatus(status) {
        const currentStatus = document.getElementById("totalAmount").value; // Lấy trạng thái hiện tại
        
        if (currentStatus !== "PENDING") {
            Swal.fire({
                icon: "error",
                title: "Không thể cập nhật",
                text: "Trạng thái phiếu không phải PENDING!",
            });
            return;
        }

        Swal.fire({
            title: "Xác nhận cập nhật?",
            text: `Bạn có chắc muốn cập nhật trạng thái thành "${status}"?`,
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Xác nhận",
            cancelButtonText: "Hủy"
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(`${url}/leave-applications/${id}/status?status=${status}&approverId=${approverId}`, {
                    method: "PATCH",
                    headers: { "Content-Type": "application/json" }
                })
                .then(response => response.json())
                .then(data => {
                    Swal.fire({
                        icon: "success",
                        title: "Cập nhật thành công!",
                        text: `Trạng thái đã được cập nhật thành "${status}".`
                    }).then(() => location.reload()); // Reload trang để cập nhật trạng thái mới
                })
                .catch(error => {
                    Swal.fire({
                        icon: "error",
                        title: "Lỗi!",
                        text: "Có lỗi xảy ra khi cập nhật trạng thái!"
                    });
                });
            }
        });
    }

    function hideButtonsIfNotPending() {
        const status = "PENDING"; // Thay giá trị này bằng trạng thái thực tế
        const actionButtonsContainer = document.getElementById("actionButtonsContainer");

        if (status !== "PENDING") {
            actionButtonsContainer.style.display = "none";
        }
    }

  
</script>