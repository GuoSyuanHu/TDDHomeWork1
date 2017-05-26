using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Day1HomeWork
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void Group_3_Item_By_Cost_Sum_Should_Be_6_15_24_21()
        {
            // arrange
            var datas = GetItemList();
            
            var expected = new List<int> { 6, 15, 24, 21 };
            // act
            var actual = new Calculator().SumCost(datas, 3).ToList();
            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Group_4_Item_By_Revenue_Sum_Should_Be_50_66_60()
        {
            // arrange
            var datas = GetItemList();

            var expected = new List<int> { 50, 66, 60 };
            // act
            var actual = new Calculator().SumRevenue(datas, 4).ToList();
            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        // 資料型別
        public class RowData
        {
            public int Id { get; set; }
            public int Cost { get; set; }
            public int Revenue { get; set; }
            public int SellPrice { get; set; }
        }

        // 起始資料
        private List<RowData> GetItemList()
        {
            return new List<RowData>()
            {
                new RowData() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new RowData() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new RowData() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                new RowData() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                new RowData() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new RowData() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                new RowData() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new RowData() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                new RowData() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                new RowData() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new RowData() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 },
            };
        }

        public class Calculator
        {

            public IEnumerable<int> SumCost(IEnumerable<RowData> datas, int groupCount)
            {
                var costsList = datas.Select(r => r.Cost);
                return Compute(costsList, groupCount);
            }

            public IEnumerable<int> SumRevenue(IEnumerable<RowData> datas, int groupCount)
            {
                var revenuesList = datas.Select(r => r.Revenue);
                return Compute(revenuesList, groupCount);
            }

            public IEnumerable<int> SumSellPrice(IEnumerable<RowData> datas, int groupCount)
            {
                var sellPriceList = datas.Select(r => r.SellPrice);
                return Compute(sellPriceList, groupCount);
            }

            private IEnumerable<int> Compute(IEnumerable<int> list, int groupCount)
            {
                var result = new List<int>();
                for (int i = 0; i <= list.Count() / groupCount; i++)
                {
                    result.Add(list.Skip(i * groupCount).Take(groupCount).Sum());
                }
                return result;
            }
        }
    }
}
