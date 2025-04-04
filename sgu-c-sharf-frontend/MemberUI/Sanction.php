<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" href="./HomePage.css" />
    <link rel="stylesheet" href="./login.css" />
    <link rel="stylesheet" href="MyOrder.css" />

    <title>Phiếu đặt chỗ</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../HelperUI/formatOutput.js"></script>
    <style>
        .container2 {
            width: 100%;
            display: flex;
            justify-content: center;
        }

        #table-container {
            width: 60%;
            border: 1px solid black;
            border-radius: 15px;
            padding: 50px;
            top: 0;
            margin: 10px;
        }


        a {
            font-size: 16px;
        }
        p {
            font-size: 16px;
        }
    </style>
</head>

<body>
    <?php require_once "./Header.php" ?>

    <div class="container2">

        <div id="table-container">
            <div style="text-align: center;">
                <h3>Thong bao xu phat</h3>
            </div>
            <table class="table table-striped" id="danhsachthietbi">

                <tbody>
                    <tr>
                        <td scope="row"><a href="" onclick="xemChiTietPhieu()">xử phạt ngày 1/1/1111</a></td>
                    </tr>
                </tbody>

            </table>

            <div>
                <form>
                    <div class="form-group">
                        <p>Thành viên</p>
                    </div>
                    <div class="form-group">
                        <p>Mã phiếu xử phạt</p>
                    </div>
                    <div class="form-group">
                        <p>Ngày xử phạt</p>
                    </div>
                    <div class="form-group">
                        <p>Trạng thái</p>
                    </div>
                    <div class="form-group">
                        <p>Thời gian phạt</p>
                    </div>
                    <div class="form-group">
                        <p>Mức phạt</p>
                    </div>
                    <div class="form-group">
                        <p>Mô tả</p>
                    </div>
                    <button type="submit" class="btn btn-primary">Thoát</button>
                </form>
            </div>

        </div>

    </div>

    <?php require_once "./Footer.php" ?>
</body>


<script>
    function xemChiTietPhieu() {
        event.preventDefault();
        var container = document.getElementById("table-container");

        container.innerHTML = "";
    }
</script>

</html>