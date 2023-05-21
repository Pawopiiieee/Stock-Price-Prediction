using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace Stock_Price_Prediction
{
   class DataView
    {
        public static void GetData() 
        {
            MLContext context = new MLContext();

            var data = context.Data.LoadFromTextFile<StockPrice>("data.csv",',', true);

            var pipeline = context.Forecasting.ForecastBySsa(
                outputColumnName: nameof(ResultModel.PredictedPrice),
                inputColumnName: nameof(StockPrice.Close),
                confidenceLevel: 0.95F,
                confidenceLowerBoundColumn: nameof(ResultModel.ConfidenceLowerBound),
                confidenceUpperBoundColumn: nameof(ResultModel.ConfidenceUpperBound),
                windowSize: 365,
                seriesLength: 365 * 5,
                trainSize: 365 * 5,
                horizon: 7
                );

            var model = pipeline.Fit(data);   //model 

            var prediction = model.CreateTimeSeriesEngine<StockPrice, ResultModel>(context);  //forcasting the price

            var result = prediction.Predict();  //predicted value

            System.Console.WriteLine($"Price Prediction for next 7 days: [{string.Join("; ",result.PredictedPrice)}]");

            prediction.CheckPoint(context, "TimeSeriesModel.zip");  //store model
        }
    }
}
