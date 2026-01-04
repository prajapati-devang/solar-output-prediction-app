using Microsoft.ML;
using ModelLibrary;
using RegressionModelTrainingConsole;

var context = new MLContext();

// 1. Mock Data: Input vs Energy Output

Console.WriteLine("Started Model Training on sample Data...");

var data = new[] {
    new SolarInput { Temperature = 25, Luminosity = 800, Humidity = 20, EnergyGenerated = 45.5f },
    new SolarInput { Temperature = 30, Luminosity = 950, Humidity = 15, EnergyGenerated = 55.2f },
    new SolarInput { Temperature = 15, Luminosity = 400, Humidity = 50, EnergyGenerated = 20.1f }
};

Console.WriteLine("Completed Model Training on sample Data...");

var trainingData = context.Data.LoadFromEnumerable(data);

Console.WriteLine("Pipeline Started for SDCA for regression...");
// 2. Pipeline: Concatenate all numeric features into one "Features" vector
var pipeline = context.Transforms.Concatenate("Features", "Temperature", "Luminosity", "Humidity")
    .Append(context.Regression.Trainers.Sdca()); // Use a Regression trainer

Console.WriteLine("Pipeline completed for SDCA for regression...");

// 3. Train and Save
Console.WriteLine("Started Preparation of Model...");
var model = pipeline.Fit(trainingData);
Console.WriteLine("Completed Preparation of Model...");

var modelName = "SolarModel.zip";

context.Model.Save(model, trainingData.Schema, modelName);

ZipFileCopier.CopyZipToBlazorApp(modelName);

Console.WriteLine($"Model saved successfully to {modelName}");