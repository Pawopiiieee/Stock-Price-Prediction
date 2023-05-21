
namespace ING_Price_Prediction
{
    class ResultModel
    {
        public float[] PredictedPrice { get; set; }

        public float[] ConfidenceLowerBound { get; set; }
        public float[] ConfidenceUpperBound { get; set; }
    }
}
