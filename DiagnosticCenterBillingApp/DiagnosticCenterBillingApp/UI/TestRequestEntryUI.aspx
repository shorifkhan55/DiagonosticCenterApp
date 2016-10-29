<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DiagnosticCenterBillingApp.UI.TestRequestEntryUI" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Billing System Of Diagosusting Center</title>

    <!-- Bootstrap -->
    <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet">
      <link href="../Bootstrap/css/Customize.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
<body>
    <form id="form1" runat="server">
        <div class="container responsive-container">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 col-md-offset-3">
                    <div id="myDiv" runat="server" visible="false">
                        <div class="alert alert-danger" role="alert" >
                            <asp:Label ID="alartLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                      <div class="panel-heading">
                          <h2>Test Request Entry</h2>
                      </div>
                      <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <label>Name Of the Patient</label>
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="patientNameTextBox" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12 space">
                            <div class="col-lg-4">
                                <label>Date Of Barth</label>
                            </div>
                            <div class="col-lg-8">
                                <input type="date" name="dateTimeTextBox" class="form-control"/>
                            </div>
                        </div>
                        <div class="col-lg-12 space">
                            <div class="col-lg-4">
                                <label>Mobile Number</label>
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="mobileNumberTestBox" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12 space">
                            <div class="col-lg-4">
                                <label>Select Test</label>
                            </div>
                            <div class="col-lg-8">
                                <asp:DropDownList runat="server" ID="testSelectDropDownList" CssClass="btn btn-default " OnSelectedIndexChanged="testSelectDropDownList_SelectedIndexChanged" AutoPostBack="True"/>
                            </div>
                        </div>
                        <div class=" col-lg-6 col-lg-offset-7 space">
                            <div class="col-lg-4">
                                <label>Fee</label>
                            </div>
                            <div class="col-lg-6 ">
                                <asp:TextBox runat="server" ID="testFeeTextBox" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                      
                        <div class="col-lg-2 pull-right space">
                            <asp:Button runat="server" ID="addGridviewButton" CssClass="btn btn-primary" Text="Add" OnClick="addGridviewButton_Click"/>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
            
        </div>  
    </form>
    
     <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="../Bootstrap/js/Customize.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
