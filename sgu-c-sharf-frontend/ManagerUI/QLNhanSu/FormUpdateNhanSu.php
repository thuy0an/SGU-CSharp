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
                    <h2>Thông tin nhân sự</h2>
                    <div style="margin-left: auto;">
                        <a href="./QLNhanSu.php">
                            <button style="font-family: Arial; font-size: 1.5rem; font-weight: 700; color: white; color: rgb(65, 64, 64); border: 1px solid rgb(65, 64, 64); background-color: white; padding: 1rem; border-radius: 0.6rem; cursor: pointer;">
                                Quay về
                            </button>
                        </a>
                    </div>
                </div>


                <div class="boxTable">
                   

                    <div style="background-color: rgb(236, 233, 233); width: 75%; padding: 1rem; border-radius: 1rem;">
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
                            Thông tin nhân sự
                        </h2>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Mã nhân viên</p>
                            <input id="profileId" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #4CAF50; border-radius: 0.5rem; text-align: center;"
                                value="" 
                                disabled />
                        </label>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Tên nhân sự</p>
                            <input id="fullname" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #FF9800; border-radius: 0.5rem; text-align: center;"
                                value="" 
                                disabled />
                        </label>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Email</p>
                            <input id="email" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #2196F3; border-radius: 0.5rem; text-align: center;"
                                value="" 
                                disabled />
                        </label>

                        <label style="display: block; margin-bottom: 1rem;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Số điện thoại</p>
                            <input id="phone" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid #9C27B0; border-radius: 0.5rem; text-align: center;"
                                value="" 
                                disabled />
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
                            <select id="gender" disabled
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid rgb(54, 244, 244); border-radius: 0.5rem; text-align: center;">
                                <option value="true">Nam</option>
                                <option value="false">Nữ</option>
                            </select>
                        </label>



                        <label style="display: block;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Ngày sinh</p>
                            <input id="birthday" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: white; font-weight: 700; 
                                    border: none; border-left: 5px solid rgb(52, 136, 84); border-radius: 0.5rem; text-align: center;"
                                value="" 
                                disabled />
                        </label>

                        <label style="display: block;">
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Chức năng</p>
                            <button id="changePositionBtn" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: #3498db; color: white; font-weight: 700; 
                                    border: none; border-radius: 0.5rem; text-align: center; cursor: pointer; transition: background-color 0.3s;">
                                Đổi vị trí
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
    const profileId = urlParams.get('id');

    $(document).ready(function () {
        // Lấy ID từ URL
        

        if (!profileId) {
            alert("Không tìm thấy mã nhân viên");
            return;
        }
        getObject();
        updateStatus();
        updateProfilePosition();
        // // Xử lý cập nhật thông tin khi bấm "Cập nhật"
        // $("#staffForm").submit(function (event) {
        //     event.preventDefault(); // Ngăn chặn reload trang

        //     const updatedData = {
        //         fullname: $("#fullname").val(),
        //         email: $("#email").val(),
        //         phone: $("#phone").val(),
        //         gender: $("#gender").val(),
        //         birthday: $("#birthday").val(),
        //         isFingerprintVerified: $("#isFingerprintVerified").is(":checked"),
        //     };

        //     $.ajax({
        //         url: `/profile/${profileId}`,
        //         type: "PUT",
        //         contentType: "application/json",
        //         data: JSON.stringify(updatedData),
        //         success: function (response) {
        //             alert("Cập nhật thành công!");
        //         },
        //         error: function (xhr, status, error) {
        //             alert("Lỗi khi cập nhật nhân sự: " + error);
        //         }
        //     });
        // });
    });

    function getObject(){
        // Gọi API để lấy thông tin nhân sự
        $.ajax({
            url: `${url}/profiles/${profileId}`,
            type: "GET",
            dataType: "json",
            headers: 
            {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token 
            },
            success: function (result) {
                    const data = result.data;
                    $("#profileId").val(data.id);
                    $("#fullname").val(data.fullname);
                    $("#email").val(data.email);
                    $("#phone").val(data.phone);
                    $("#status").val(data.status);
                    $("#gender").val(data.gender.toString());
                    $("#birthday").val(data.birthday);
                    $("#isFingerprintVerified").prop("checked", data.isFingerprintVerified);

                    const positionList = data.profilePositions;

                    var positionBody = document.getElementById("tableBodyProfilePosition"); // Sửa lỗi

                    positionList.forEach(position => {
                        const row = document.createElement("tr");
                        row.innerHTML = `
                            <td style="padding: 0.5rem; text-align: center; font-weight: 600; border-bottom: 1px solid #ddd;">
                                ${position.positionId}
                            </td>
                            <td style="padding: 0.5rem; text-align: center; font-weight: 600; border-bottom: 1px solid #ddd;">
                                ${position.positionName}
                            </td>
                            <td style="padding: 0.5rem; text-align: center; font-weight: 600; border-bottom: 1px solid #ddd;">
                                ${position.salaryCoefficient}
                            </td>
                            <td style="padding: 0.5rem; text-align: center; font-weight: 600; border-bottom: 1px solid #ddd;">
                                ${position.startDate}
                            </td>
                            <td style="padding: 0.5rem; text-align: center; font-weight: 600; border-bottom: 1px solid #ddd;">
                                ${position.endDate ? position.endDate : "Hiện tại"}
                            </td>
                        `;
                        positionBody.appendChild(row);
                    });
        
            },
            error: function (xhr, status, error) {
                console.error("Lỗi kết nối:", error);
                alert("Lỗi khi tải dữ liệu nhân sự.");
            }
        });
    }

    function updateStatus() {
        $("#status").change(function () {
            let newStatus = $(this).val();

            if (newStatus) {
                Swal.fire({
                    title: "Xác nhận thay đổi",
                    text: `Bạn có chắc chắn muốn thay đổi trạng thái thành "${newStatus}" không?`,
                    icon: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#3085d6",
                    cancelButtonColor: "#d33",
                    confirmButtonText: "Đồng ý",
                    cancelButtonText: "Hủy",
                }).then((result) => {
                    if (result.isConfirmed) {
                        $.ajax({
                            url: `${url}/profiles/${profileId}/status`,
                            type: "PATCH",
                            contentType: "application/json",
                            data: JSON.stringify({ status: newStatus }),
                            success: function (response) {
                                Swal.fire(
                                    "Thành công!",
                                    "Cập nhật trạng thái thành công.",
                                    "success"
                                );
                            },
                            error: function (xhr, status, error) {
                                Swal.fire(
                                    "Thất bại!",
                                    "Cập nhật trạng thái thất bại.",
                                    "error"
                                );
                            },
                        });
                    } else {
                        $("#status").val(""); // Nếu hủy, reset về mặc định
                    }
                });
            }
        });
    }

    function updateProfilePosition(){
        $("#changePositionBtn").click(function () {
            Swal.fire({
                title: "Nhập thông tin vị trí mới",
                html: `
                    <label style="display: block; text-align: left; margin-bottom: 5px;">Mã vị trí</label>
                    <input id="positionId" class="swal2-input" placeholder="Nhập mã vị trí">

                    <label style="display: block; text-align: left; margin-bottom: 5px;">Ngày bắt đầu</label>
                    <input id="startDate" type="date" class="swal2-input">

                    <label style="display: block; text-align: left; margin-bottom: 5px;">Ngày kết thúc</label>
                    <input id="endDate" type="date" class="swal2-input">

                    <label style="display: block; text-align: left; margin-bottom: 5px;">Hệ số lương</label>
                    <input id="salaryCoefficient" type="number" step="0.1" class="swal2-input" placeholder="Nhập hệ số lương">
                `,
                showCancelButton: true,
                confirmButtonText: "Xác nhận",
                cancelButtonText: "Hủy",
                preConfirm: () => {
                    return {
                        positionId: $("#positionId").val(),
                        startDate: $("#startDate").val(),
                        endDate: $("#endDate").val() || null,
                        salaryCoefficient: parseFloat($("#salaryCoefficient").val())
                    };
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    let formData = result.value;
                    
                    if (!formData.positionId || !formData.startDate || isNaN(formData.salaryCoefficient)) {
                        Swal.fire("Lỗi!", "Vui lòng nhập đầy đủ thông tin!", "error");
                        return;
                    }

                    $.ajax({
                        url: `http://localhost:8080/api/profiles/P002/position`,
                        type: "PATCH",
                        contentType: "application/json",
                        data: JSON.stringify(formData),
                        success: function (response) {
                            Swal.fire("Thành công!", "Cập nhật vị trí thành công!", "success");
                        },
                        error: function (xhr, status, error) {
                            Swal.fire("Lỗi!", "Cập nhật vị trí thất bại!", "error");
                        }
                    });
                }
            });
        });
    }

</script>
