using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingManagmentOfDiagonosticCenterApp.DAL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.BLL
{
    public class OrderManager
    {
        OrderGateway _orderGateway=new OrderGateway();

        public int Save(Order order)
        {
            return _orderGateway.Save(order);
        }
    }
}