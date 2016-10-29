<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeEntryUI.aspx.cs" Inherits="DiagnosticCenterBillingApp.UI.TestTypeEntryUI" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
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
                    
                    <div class="panel panel-primary">
                      <div class="panel-heading">
                        <h3 class="panel-title">Test Type Setup</h3>
                      </div>
                      <div class="panel-body">
                        <div class="col-lg-3">
                            <label >Type Name</label>
                        </div>
                        <div class="col-lg-9">
                            <input placeholder="Type Name" type="text" id="testTypeNameTextBox" value=" " runat="server" class="form-control"/>
                        </div>
                        <div class="col-lg-2 pull-right space">
                            <asp:Button runat="server" ID="testTypeSaveButton" CssClass="btn btn-primary" Text="Save" OnClick="testTypeSaveButton_Click"/>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 col-md-offset-3">
                    <asp:GridView ID="testTypeShowGridView" runat="server" AutoGenerateColumns="False"
                         CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 table table-bordered">
                        <headerstyle backcolor="#337ab7" forecolor="white"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No">
                                <ItemTemplate>
                                    <asp:Label runat="server"><%#Eval("serialNo") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type Name">
                                <ItemTemplate>
                                    <asp:Label runat="server"><%#Eval("TypeName") %></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>  
    </form>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../Scripts/jquery-1.4.4.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Bootstrap/js/Customize.js"></script>
   <script type="text/javascript">
       $(document).ready(function () {
           $("#form1").click(function () {
               alert("Alert using jQuery");
           });
       });
</script>

</body>
</html>