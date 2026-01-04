using Microsoft.ML.Data;

namespace ModelLibrary
{
    public class SolarInput
    {
        [LoadColumn(0)] public float Temperature;       // Celsius
        [LoadColumn(1)] public float Luminosity;        // Lux/Intensity
        [LoadColumn(2)] public float Humidity;          // Percentage
        [LoadColumn(3), ColumnName("Label")] public float EnergyGenerated; // The value to predict
    }

    public class SolarPrediction
    {
        [ColumnName("Score")] // For regression, the output is always in the "Score" column
        public float PredictedEnergy;

    }
}
