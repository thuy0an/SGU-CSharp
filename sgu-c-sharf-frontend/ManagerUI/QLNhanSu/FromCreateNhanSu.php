<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./QLNhanSu.css" />

    <title>Cập nhật nhân sự</title>
</head>
<style>

    #staffForm {
    max-width: 500px;
    background: #f9f9f9;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    margin-top: 20px;
}

#staffForm label {
    display: block;
    font-weight: bold;
    margin: 10px 0 5px;
}

#staffForm input,
#staffForm select {
    width: 100%;
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
}

#staffForm input[readonly] {
    background: #e9ecef;
}

#staffForm input[type="checkbox"] {
    width: auto;
    margin-left: 10px;
}

#staffForm button {
    background: #007bff;
    color: white;
    padding: 10px;
    font-size: 16px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    width: 100%;
    margin-top: 15px;
}

#staffForm button:hover {
    background: #0056b3;
}

</style>
<body>
    <div class="StaffLayout_wrapper__CegPk">
        <?php require_once "../ManagerHeader.php" ?>
        <div class="Manager_wrapper__vOYy">
            <?php require_once "../ManagerMenu.php" ?>

            <div style="padding-left: 16%; width: 100%; padding-right: 2rem">
                
                <div style="display: flex; padding-top: 1rem; padding-bottom: 1rem;">
                    <h2>Thêm nhân sự</h2>
                    <div style="margin-left: auto;">
                        <a href="./QLNhanSu.php">
                            <button style="font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; color: rgb(65, 64, 64); border: 1px solid rgb(65, 64, 64); background-color: white; padding: 1rem; border-radius: 0.6rem; cursor: pointer;">
                                Quay về
                            </button>
                        </a>
                    </div>
                </div>


                <div class="boxTable" style="overflow-y:inherit; margin-top: 110px; display: flex; justify-content: center; align-items:center">
                   

                    <!-- <div style="background-color: rgb(236, 233, 233); width: 75%; padding: 1rem; border-radius: 1rem;">
                        <div style="max-height: 100%; overflow-y: auto; border-radius: 1rem; border: 1px solid #ccc;">
                            <table style="border-collapse: collapse; width: 100%;">
                                <thead>
                                    <tr style="background-color: rgb(40, 40, 40); color: white; position: sticky; top: 0; z-index: 2;">
                                        <th style="padding: 0.5rem; width: 20%;">Số thứ tự</th>
                                        <th style="padding: 0.5rem;">Vị trí</th>
                                        <th style="padding: 0.5rem;">Hệ số lương</th>
                                        <th style="padding: 0.5rem;">Ngày bắt đầu</th>
                                        <th style="padding: 0.5rem;">Ngày kết thúc</th>
                                    </tr>
                                </thead>
                                <tbody id="tableBodyProfilePosition">
                                </tbody>
                            </table>
                        </div>
                    </div> -->

                    <div style="
                        width: 35%; 
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
                            Thông tin nhân sự
                        </h2>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Tên nhân sự</p>
                            <input id="fullname" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #FF9800; border-radius: 0.5rem; text-align: center;"
                                value="" 
                            />
                        </label>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Email</p>
                            <input id="email" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #2196F3; border-radius: 0.5rem; text-align: center;"
                                value="" 
                            />
                        </label>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Số điện thoại</p>
                            <input id="phone" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                value="" 
                            />
                        </label>

                        <label style="display: block;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Trạng thái</p>
                            <select id="status" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #F44336; border-radius: 0.5rem; text-align: center;">
                                <option value="">Chọn trạng thái</option>
                                <option value="ACTIVE">Active</option>
                                <option value="INACTIVE">Inactive</option>
                                <option value="SUSPENDED">Suspended</option>
                                <option value="TERMINATED">Terminated</option>
                                <option value="ON_LEAVE">On Leave</option>
                            </select>
                        </label>



                        <label style="display: block;">
                            <p style="font-size: 1.1rem; font-weight: 700;">Giới tính</p>
                            <select id="gender" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid rgb(54, 244, 244); border-radius: 0.5rem; text-align: center;">
                                <option value="true">Nam</option>
                                <option value="false">Nữ</option>
                            </select>
                        </label>


                        <label style="display: block;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày sinh</p>
                            <input id="birthday" type="date"
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid rgb(52, 136, 84); border-radius: 0.5rem; text-align: center; cursor: pointer;"
                            />
                        </label>


                        <label style="display: block;">
                            <p style="font-size: 1.1rem; font-weight: 700;">Vị trí</p>
                            <select id="position" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid rgb(54, 244, 244); border-radius: 0.5rem; text-align: center;">
                                <option value="POS001">HR</option>
                                <option value="POS002">Inventory manager</option>
                                <option value="POS003">Business manager</option>
                            </select>
                        </label>


                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Hệ số lương</p>
                            <input id="heSoLuong" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                value="" 
                            />
                        </label>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày bắt đầu</p>
                            <input id="startDate" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                value="" 
                                type="date"
                            />
                        </label>


                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày kết thúc</p>
                            <input id="endDate" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                value="" 
                                type="date"

                            />
                        </label>

                        <label style="display: block;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Chức năng</p>
                            <button id="create" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: #3498db; color: white; font-weight: 700; 
                                    border: none; border-radius: 0.5rem; text-align: center; cursor: pointer; transition: background-color 0.3s;">
                                Lưu
                            </button>
                        </label>

                    </div>
                </div>
            </div>

        </div>
    </div>
</body>

</html>

<script>
    const url = window.env.API_ROOT;
    const token = sessionStorage.getItem("token");
    const urlParams = new URLSearchParams(window.location.search);

    $(document).ready(function () {
        // Lấy ID từ URL
        
    $("#create").click(function (event) {
        event.preventDefault(); // Ngăn chặn hành vi mặc định của button

        const updatedData = {
            fullname: $("#fullname").val().trim(),
            email: $("#email").val().trim(),
            phone: $("#phone").val().trim(),
            gender: $("#gender").val() === "true", // Chuyển đổi thành boolean
            birthday: $("#birthday").val(),
            status: $("#status").val(),
            profilePositionCreateForm: {
                positionId: $("#position").val(),
                startDate: $("#startDate").val(),
                endDate: $("#endDate").val() || null, // Nếu không nhập, gửi null
                salaryCoefficient: parseFloat($("#heSoLuong").val()) || 0 // Chuyển đổi thành số
            }
        };

        console.log(updatedData.profilePositionCreateForm.positionId);

        $.ajax({
            url: `${url}/profiles`,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(updatedData),
            success: function (response) {
                Swal.fire({
                    icon: "success",
                    title: "Thành công!",
                    text: "Thêm nhân sự thành công!",
                    confirmButtonColor: "#3085d6"
                });
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: "error",
                    title: "Lỗi!",
                    text: "Thêm nhân sự thất bại: " + error,
                    confirmButtonColor: "#d33"
                });
            }
        });
});


    });


</script>
