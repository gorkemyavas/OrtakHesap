using System;
using System.Collections.Generic;
using System.Linq;

namespace OrtakHesap.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public List<ExpenseType> ExpenseTypes { get; set; }
        public ExpenseType Type { get; set; }
        public string Image { get; set; }

        public ExpenseModel()
        {
            ExpenseTypes = Enum.GetValues(typeof(ExpenseType))
                .Cast<ExpenseType>()
                .ToList();

        }
    }
    public enum ExpenseType
    {
        Market = 0,
        Fatura = 1,
        Diğer = 2,

    }
}
