# ☀️ Solar Energy Predictor (Regression AI)

### 🛠️ Requirements
1. .NET 10 SDK
2. Microsoft.ML v3.0+
3. Microsoft.Extensions.ML (for Blazor integration)

This project implements a **Regression Model** using **ML.NET** and **.NET 10**. Unlike classification, this model predicts a continuous numerical value—specifically, the **Energy Output (kWh)** of a solar installation based on environmental factors.

## 🚀 Key Features
- **Regression Logic:** Predicts exact numbers rather than categories.
- **Performance Optimized:** Includes `AppendCacheCheckpoint` and optimized trainers to speed up the `.Fit()` process.
- **Blazor Server Integration:** Real-time estimation UI powered by SignalR and `PredictionEnginePool`.

---

## 📂 Project Structure

- **`RegressionModelTrainingConsole/`**: Console app to train and export the `SolarModel.zip`.
- **`SolarEnergyPredictorApp/`**: Blazor Server web interface for user interaction.
- **`Data/`**: (Optional) Folder for CSV training data. if you want to load data from csv.

---

## ⚙️ Performance Tuning for `.Fit()`
If the training process is taking too long, this project uses the following optimizations:
1. **Memory Caching:** Uses `.AppendCacheCheckpoint()` to prevent multiple disk reads. (Optional)
2. **Fast Trainers:** Uses `AveragedPerceptron` or `Lbfgs` for quicker convergence on large datasets.
3. **Iteration Limits:** Configured to prevent infinite mathematical "hunting" for the global minimum.

---

## 🏗️ Setup and Run

### 1. Training the Model
1. Open the `RegressionModelTrainingConsole` directory.
2. Run the trainer:
   ```bash
   dotnet run -c Release

### 2. Deployment to Blazor
1. Copy the generated SolarModel.zip into the root of the SolarEnergyPredictorApp.
2. Register the service in Program.cs:
    ```bash
   builder.Services.AddPredictionEnginePool<SolarInput, SolarPrediction>()
    .FromFile("SolarModel.zip");
3. Run the web app
    ```bash
   cd SolarEnergyPredictorApp
   dotnet run

### 3. Screenshots
<img width="1917" height="425" alt="Screenshot 2026-01-04 142606" src="https://github.com/user-attachments/assets/a4a67519-df75-4f54-8f0f-78dcf3978ff4" />

<img width="1918" height="547" alt="Screenshot 2026-01-04 142535" src="https://github.com/user-attachments/assets/4709b0de-42ba-49cc-9b53-b822ff8f3819" />
