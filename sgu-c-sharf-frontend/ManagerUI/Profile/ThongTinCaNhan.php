<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../AdminHome.css" />
    <link rel="stylesheet" href="./ThongTinCaNhan.css" />

    <title>Thông tin nhân sự</title>
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
                            />
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
                            />
                        </label>

                        <!-- <label style="display: block;">
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
                        </label> -->



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
                            <p style="font-size: 1.1rem; font-weight: 700; color: #555;">Chức năng</p>
                            <button id="update" 
                                style="height: 3rem; padding: 0.5rem; width: 100%; background-color: #3498db; color: white; font-weight: 700; 
                                    border: none; border-radius: 0.5rem; text-align: center; cursor: pointer; transition: background-color 0.3s;">
                                Cập nhật
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
    const profileId = sessionStorage.getItem("id");

    $(document).ready(function () {
        // Lấy ID từ URL
        if (!profileId) {
            alert("Không tìm thấy mã nhân viên");
            return;
        }
        getObject();
        updateObject();
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
                    // $("#status").val(data.status);
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

    function updateObject(){
        $(document).ready(function () {
            $("#update").click(function () {
                let fullname = $("#fullname").val();
                let phone = $("#phone").val();
                let gender = $("#gender").val() === "true"; 
                let birthday = $("#birthday").val();

                if (!fullname || !phone || !birthday) {
                    Swal.fire("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "error");
                    return;
                }

                if (!token) {
                    Swal.fire("Lỗi", "Bạn chưa đăng nhập!", "error");
                    return;
                }

                Swal.fire({
                    title: "Xác nhận",
                    text: "Bạn có chắc chắn muốn cập nhật thông tin không?",
                    icon: "warning",
                    showCancelButton: true,
                    confirmButtonText: "Có, cập nhật!",
                    cancelButtonText: "Hủy"
                }).then((result) => {
                    if (result.isConfirmed) {
                        $.ajax({
                            url: `${url}/profiles/me`,
                            type: "PATCH",
                            contentType: "application/json",
                            data: JSON.stringify({
                                fullname: fullname,
                                phone: phone,
                                gender: gender,
                                birthday: birthday
                            }),
                            headers: {
                                "Authorization": `Bearer ${token}` // Truyền token vào header
                            },
                            success: function () {
                                Swal.fire("Thành công!", "Cập nhật thông tin thành công!", "success");
                            },
                            error: function (xhr) {
                                Swal.fire("Lỗi", "Cập nhật thất bại: " + xhr.responseText, "error");
                            }
                        });
                    }
                });
            });
        });
    }

</script>
