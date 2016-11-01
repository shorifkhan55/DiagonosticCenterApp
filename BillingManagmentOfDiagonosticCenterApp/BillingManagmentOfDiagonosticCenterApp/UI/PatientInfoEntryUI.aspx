<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientInfoEntryUI.aspx.cs" Inherits="BillingManagmentOfDiagonosticCenterApp.UI.PatientInfoEntryUI" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Billing System Of Diagosusting Center</title>

    <!-- Bootstrap and Customize Css add section -->
    <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet">
      <link href="../Bootstrap/css/Customize.css" rel="stylesheet" />

    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
<body>
    <form id="form1" runat="server">
            <!--Nav Section-->
            <nav class="navbar navbar-default">
              <div class="container-fluid">
    
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                  <a class="navbar-brand" href="#">Diagonasting Center</a>
                </div>

                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                  <ul class="nav navbar-nav">
                    <li><a href="TestTypeEntryUI.aspx">Type Entry<span class="sr-only">(current)</span></a></li>
                    <li><a href="TestEntryUI.aspx">Test Entry</a></li>
                    <li class="active"><a href="PatientInfoEntryUI.aspx">Patient Request</a></li>
                    <li><a href="AmountInfoUI.aspx">Payment Info</a></li>
                    <li><a href="TestWiseReportUI.aspx">Test Wise Report</a></li>
                    <li><a href="TypeWiseReportUI.aspx">Type Wise Report</a></li>
                    <li><a href="DueBillReportUI.aspx">Due Bill Info</a></li>
                  </ul>
                </div>
              </div>
            </nav>
        <!--End Of Nav Section-->

        <div class="container responsive-container">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 col-md-offset-3">
                    
                    <!--Alart Text Sectio-->
                    <div id="testTypeDangerDiv" runat="server" visible="false">
                        <div class="alert alert-danger" role="alert">
                            <asp:Label ID="testTypeDangerAlartLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    
                    <div id="testTypeSuccessfullDiv" runat="server" visible="false">
                        <div class="alert alert-success" role="alert">
                            <asp:Label ID="testTypeSuccessfullAlartLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <!--End of Alart Section-->
                    
                    <!--Patent Information Section-->
                     <div class="panel panel-primary">
                         <div class="panel-heading">
                            <h2>Test Request Entry</h2>
                         </div>
                         <div class="panel-body">
                            <div class="col-lg-12">
                                <div class="col-lg-5">
                                    <label>Name Of the Patient</label>
                                </div>
                                <div class="col-lg-7">
                                    <input type="text" id="nameTextBox" value=" " runat="server" class="form-control"/>
                                </div>
                            </div>
                            <div class="col-lg-12 space">
                                <div class="col-lg-5">
                                    <label>Date Of Barth</label>
                                </div>
                                <div class="col-lg-7">
                                    <input type="date" id="dateOfBirthTextBox" class="form-control" runat="server"/>
                                </div>
                            </div>
                            <div class="col-lg-12 space">
                                <div class="col-lg-5">
                                    <label>Mobile Number</label>
                                </div>
                                <div class="col-lg-7">
                                    <input type="number" id="mobileTextBox" value=" " runat="server" class="form-control"/>
                                </div>
                            </div>
                            <div class="col-lg-12 space">
                                <div class="col-lg-5">
                                    <label>Select Test</label>
                                </div>
                                <div class="col-lg-7">
                                    <asp:DropDownList runat="server" ID="testSelectDropDownList" CssClass="btn btn-default " Width="258px" AutoPostBack="True" OnSelectedIndexChanged="testSelectDropDownList_SelectedIndexChanged"/>
                                </div>
                            </div>
                            <div class=" col-lg-6 col-lg-offset-7 space">
                                <div class="col-lg-4">
                                    <label>Fee</label>
                                </div>
                                <div class="col-lg-6 ">
                                    <input type="text" id="feeTextBox" value=" " runat="server" class="form-control"/>
                                </div>
                            </div>
                      
                            <div class="col-lg-2 pull-right space">
                                <asp:Button runat="server" ID="addGridviewButton" CssClass="btn btn-primary" Text="Add" OnClick="addGridviewButton_Click" />
                            </div>
                             
                            <!--Start of GrideView Section Section-->                
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 space" id="gridViewControl">
                                <asp:GridView ID="testShowGridView" runat="server" AutoGenerateColumns="False" 
                                    CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 table table-bordered" HeaderStyle="#CDDAD7;">
                                    <headerstyle backcolor="#337ab7" forecolor="white"/>
                                    <Columns>
                                        <asp:TemplateField  HeaderText="SL NO">
                                            <ItemTemplate>
                                                <asp:Label runat="server"><%#Container.DataItemIndex+1 %></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Test">
                                            <ItemTemplate>
                                                <asp:Label runat="server"><%#Eval("Name") %></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fee">
                                            <ItemTemplate>
                                                <asp:Label runat="server"><%#Eval("Fee") %></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!--End of GrideView Section Section-->   
                            <div class=" col-lg-6 col-lg-offset-7 space">
                                <div class="col-lg-4">
                                    <label>Total</label>
                                </div>
                                <div class="col-lg-6 ">
                                    <input type="text" id="totalTextBox" value=" " runat="server" class="form-control"/>
                                </div>
                            </div>
                             <div class=" col-lg-6 col-lg-offset-7 space">
                                <div class="col-lg-4"> </div>
                                <div class="col-lg-6 pull-right">
                                    <asp:Button runat="server" ID="saveButton" CssClass="btn btn-primary" Text="Save" OnClick="saveButton_Click" />
                                </div>
                            
                            </div>
                                   </div>
                    </div>
                    
                    <!--Patent Information Section-->
                </div>
            </div>
        </div>
    </form>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.js"></script>
    <script src="../Bootstrap/js/Customize.js"></script>

</body>
</html>
