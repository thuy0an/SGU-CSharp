<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./NghiPhep.css" />
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
                
                    <div class="boxTable" style="height: 35rem; overflow-y: inherit; display: flex; justify-content: center">                      
                        <div style="
                            width: 70%; 
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
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày bắt đầu</p>
                                <input id="supplierPhone" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                    value=""
                                    type="date"/>
                            </label>

                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày kết thúc</p>
                                <input id="managerName" 
                                    style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid rgb(34, 49, 184); border-radius: 0.5rem; text-align: center;"
                                    value=""
                                    type="date"/>
                            </label>

                            <!-- Lý do -->
                            <label style="display: block; margin-bottom: 1rem;">
                                <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Lý do</p>
                                <textarea id="approvalReason" 
                                    style="height: 6rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                        border: none; border-left: 5px solid #FF5722; border-radius: 0.5rem; text-align: center; resize: none;"
                                    ></textarea>
                            </label>

                            <!-- Lý do -->
                            <label style="display: block; margin-bottom: 1rem;" id="actionButtonsContainer">
                                <div style="display: flex; justify-content: center; gap: 1rem;">
                                    <!-- Nút duyệt phiếu -->
                                    <button onclick="create()" 
                                        style="padding: 0.75rem 1.5rem; background-color: #4CAF50; color: white; font-weight: 700; 
                                            border: none; border-left: 5px solid #388E3C; border-radius: 0.5rem; cursor: pointer;
                                            transition: background-color 0.3s, transform 0.2s;"
                                        onmouseover="this.style.backgroundColor='#388E3C'; this.style.transform='scale(1.05)';"
                                        onmouseout="this.style.backgroundColor='#4CAF50'; this.style.transform='scale(1)';">
                                        Gửi đơn xin phép
                                    </button>
                                </div>
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
    const url = window.env.API_ROOT;
    const token = sessionStorage.getItem("token");
    const id = sessionStorage.getItem("id");

    function create() {
        const reason = $("#approvalReason").val();
        const startDate = $("#supplierPhone").val();
        const endDate = $("#managerName").val();

        $.ajax({
            url: `${url}/leave-applications`,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({
                applicantId: id,
                reason: reason,
                startDate: startDate,
                endDate: endDate
            }),
            success: function (response) {
                Swal.fire({
                    icon: "success",
                    title: "Thành công!",
                    text: "Gửi đơn xin phép thành công!",
                    confirmButtonColor: "#3085d6",
                });
                console.log(response);
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: "error",
                    title: "Lỗi!",
                    text: "Gửi đơn thất bại! " + xhr.responseText,
                    confirmButtonColor: "#d33",
                });
                console.error(error);
            }
        });
    }


   



  
</script>