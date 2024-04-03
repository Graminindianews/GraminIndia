<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="GraminIndia.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Gramin India News</title>
    <!-- plugins:css -->
    <link href="~/ConnectPath/vendors/mdi/css/materialdesignicons.min.css" rel="stylesheet" />
    <link href="~/ConnectPath/vendors/css/vendor.bundle.base.css" rel="stylesheet" />
    <link href="~/ConnectPath/css/style.css" rel="stylesheet" />
    <!-- End layout styles -->
    <link rel="shortcut icon" href="~/ConnectPath/images/favicon2.jpeg" />
</head>
<body>
    <div class="container-scroller">
        <div class="container-fluid page-body-wrapper full-page-wrapper">
            <div class="row w-100 m-0">
                <div class="content-wrapper full-page-wrapper d-flex align-items-center auth login-bg">
                    <div class="card col-lg-4 mx-auto">
                        <div class="card-body px-5 py-5">
                            <h3 class="card-title text-left mb-3">Login</h3>
                            <form runat="server">
                                <div class="form-group">
                                    <label>Username or email *</label>
                                    <asp:TextBox runat="server" ID="txtUserName" class="form-control p_input"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Password *</label>
                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" class="form-control p_input"></asp:TextBox>
                                </div>
                                <div class="form-group d-flex align-items-center justify-content-between">
                                    <div class="form-check">
                                        <label class="form-check-label">
                                            <input class="form-check-input" type="checkbox" value="" id="form2Example3" />
                                            Remember me
                                        </label>
                                    </div>
                                    <a href="#" class="forgot-pass">Forgot password</a>
                                </div>
                                <div class="text-center">
                                    <%--<button type="submit" class="btn btn-primary btn-block enter-btn">Login</button>--%>
                                    <asp:Button runat="server" Text="Submit" class="btn btn-primary btn-block enter-btn p-2" ID="btnLogin" OnClick="btnLogin_Click" />
                                </div>
                                <%--<div class="d-flex">
                                    <button class="btn btn-facebook mr-2 col">
                                        <i class="mdi mdi-facebook"></i>Facebook
                                    </button>
                                    <button class="btn btn-google col">
                                        <i class="mdi mdi-google-plus"></i>Google plus
                                    </button>
                                </div>--%>
                                <p class="sign-up">Don't have an Account?<a href="#"> Sign Up</a></p>
                            </form>
                        </div>
                    </div>
                </div>
                <!-- content-wrapper ends -->
            </div>
            <!-- row ends -->
        </div>
        <!-- page-body-wrapper ends -->
    </div>
    <script src="~/ConnectPath/vendors/js/vendor.bundle.base.js"></script>
    <script src="~/ConnectPath/js/todolist.js"></script>
</body>
</html>
