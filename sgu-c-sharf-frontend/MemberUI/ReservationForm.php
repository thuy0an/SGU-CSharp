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

        .formdatcho {
            width: 40%;
            border: 1px solid black;
            border-radius: 15px;
            padding: 50px;
            top: 0;
            margin: 10px;
        }

        .form-group {
            margin: 15px 5px;
        }

        #formdatcho2 {
            display: none;
        }
    </style>
</head>

<body>
    <?php require_once "./Header.php" ?>

    <div class="container2">

        <form id="formdatcho1" class="formdatcho">
            <div style="text-align: center;">
                <h3>Phiếu đặt chỗ</h3>
            </div>
            <div class="form-group">
                <label for="ngaydatcho">Ngày đặt chỗ:</label>
                <input type="datetime-local" class="form-control" id="ngaydatcho">
            </div>
            <button type="button" class="btn btn-primary" id="next">Tiếp tục</button>
        </form>
        <form id="formdatcho2" class="formdatcho">
            <div style="text-align: center;">
                <h3>Danh sách thiết bị</h3>
            </div>
            <div class="form-group">
                <label for="dauthietbi">Chọn loại thiết bị:</label>
                <select class="form-control">
                    <option>Default select</option>
                </select>
            </div>
            <div class="form-group">
                <table class="table table-striped" id="danhsachthietbi">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">First</th>
                            <th scope="col">Last</th>
                            <th scope="col">Handle</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Mark</td>
                            <td>Otto</td>
                            <td>@mdo</td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Jacob</td>
                            <td>Thornton</td>
                            <td>@fat</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Larry</td>
                            <td>the Bird</td>
                            <td>@twitter</td>
                        </tr>
                    </tbody>
                </table>


                <div style="text-align: center;">
                    <h3>Danh sách đặt chỗ</h3>
                </div>
                <table class="table table-striped" id="danhsachdatcho">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">First</th>
                            <th scope="col">Last</th>
                            <th scope="col">Handle</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Mark</td>
                            <td>Otto</td>
                            <td>@mdo</td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Jacob</td>
                            <td>Thornton</td>
                            <td>@fat</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Larry</td>
                            <td>the Bird</td>
                            <td>@twitter</td>
                        </tr>
                    </tbody>
                </table>

            </div>
            <button type="button" class="btn btn-primary" id="previous">Quay lại</button>
            <button type="button" class="btn btn-primary" id="datcho">Đặt chỗ</button>
        </form>

    </div>

    <?php require_once "./Footer.php" ?>
</body>


<script>
    document.getElementById("next").addEventListener("click", function() {
        document.getElementById("formdatcho1").style.display = "none";
        document.getElementById("formdatcho2").style.display = "block";
        console.log("next");
    });

    document.getElementById("previous").addEventListener("click", function() {
        document.getElementById("formdatcho1").style.display = "block";
        document.getElementById("formdatcho2").style.display = "none";
        console.log("previous");
    });
</script>

</html>