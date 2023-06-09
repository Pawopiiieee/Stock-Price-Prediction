﻿using Microsoft.ML;
using Microsoft.ML.Data;

namespace Stock_Price_Prediction
{
    public class StockPrice
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }
        [LoadColumn(1)]
        public float Open { get; set; }
        [LoadColumn(2)]
        public float High { get; set; }
        [LoadColumn(3)]
        public float Low { get; set; }
        [LoadColumn(4)]
        public float Close { get; set; }
        [LoadColumn(5)]
        public float AdjustedClose { get; set; }
        [LoadColumn(6)]
        public float Volume { get; set; }
    }
}
