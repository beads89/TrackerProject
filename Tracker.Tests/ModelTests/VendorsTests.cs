using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tracker.Models;
using System;

namespace Tracker.Tests
{
  [TestClass]
  public class VendorsTests : IDisposable
  {
    public void Dispose()
    {
      Vendors.ClearAll();
    }

    [TestMethod]

    public void VendorConstructor_CreatesNewVendor_Vendors()
    {
      Vendors newVendor = new Vendors("Taylor's Swift Bakes");
      Assert.AreEqual(typeof(Vendors), newVendor.GetType());
    }

    [TestMethod]
    public  void Name_ReturnsNameOfVendor_String()
    {
      string vendorName = "Taylor's Swift Bakes";
      Vendors newVendor = new Vendors(vendorName);

      string result = newVendor.Name;

      Assert.AreEqual(vendorName, result);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      string vendorName = "Taylor's Swift Bakes";
      Vendors newVendor = new Vendors(vendorName);

      int result = newVendor.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorNames_VendorsList()
    {
      string vendor1 = "Taylor's Swift Bakes";
      string vendor2 = "Vitas' Vital Varenyky";
      Vendors newVendor1 = new Vendors(vendor1);
      Vendors newVendor2 = new Vendors(vendor2);
      List<Vendors> newList = new List<Vendors> {newVendor1, newVendor2};

      List<Vendors> result = Vendors.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsSpecifiedVendorName_Vendor()
    {
      string vendor1 = "Taylor's Swift Bakes";
      string vendor2 = "Vitas' Vital Varenyky";
      Vendors newVendor1 = new Vendors(vendor1);
      Vendors newVendor2 = new Vendors(vendor2);

      Vendors result = Vendors.Find(2);

      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddOrder_PlaceOrderWithCorrectVendor_OrderList()
    {
      string order = "5 fab funnel cakes";
      Orders newOrder = new Orders(order);
      List<Orders> newList = new List<Orders> {newOrder};
      string vendor = "Cakemart's Tarts";
      Vendors newVendor = new Vendors(vendor);
      newVendor.AddOrder(newOrder);

      List<Orders> result = newVendor.Orders;

      CollectionAssert.AreEqual(newList, result);
    }
  }
}