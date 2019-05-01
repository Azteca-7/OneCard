using System;
using System.Collections.Generic;
using System.Text;

namespace Cards.Model
{
    public class Data
    {
        public double Balance { get; set; }
    }

    public class Balance
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }
}
