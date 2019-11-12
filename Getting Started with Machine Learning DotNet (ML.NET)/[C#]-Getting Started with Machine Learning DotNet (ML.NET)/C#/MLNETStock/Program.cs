using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace MLNETStock
{
    class Program
    {
        static readonly string _Traindatapath = Path.Combine(Environment.CurrentDirectory, "Data", "StockTrain.csv");
        static readonly string _Evaluatedatapath = Path.Combine(Environment.CurrentDirectory, "Data", "StockTest.csv");
        static readonly string _modelpath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");


        static async Task Main(string[] args)
        {
            PredictionModel<ItemStock, itemStockQtyPrediction> model = await TrainourModel();

            Evaluate(model);

            Console.WriteLine(" ");
            Console.WriteLine("-------First Prediction Vale : ----------------");
            Console.WriteLine(" ");
            itemStockQtyPrediction prediction = model.Predict(ItemStocks.stock1);
            Console.WriteLine("Item ID  {0}", ItemStocks.stock1.ItemID);

            Console.WriteLine("Predicted Stock: {0}, actual Stock Qty: 90 ", prediction.TotalStockQty);
            //Console.WriteLine("Predicted Stock: {0},actual Stock Qty: 90 - > Round Predicted Value",  Math.Round(prediction.TotalStockQty));
            Console.WriteLine(" ");
            Console.WriteLine("----------Next Prediction : -------------");
            Console.WriteLine(" ");
            prediction = model.Predict(ItemStocks.stock2);
            Console.WriteLine("Item ID  {0}", ItemStocks.stock2.ItemID);

            Console.WriteLine("Predicted Stock: {0}, actual Stock Qty: 4800 ", prediction.TotalStockQty);
            //Console.WriteLine("Predicted Stock: {0}, actual Stock Qty: 4800  - > Round Predicted Value -> ", Math.Round(prediction.TotalStockQty));
            Console.ReadLine();
        }

        public static async Task<PredictionModel<ItemStock, itemStockQtyPrediction>> TrainourModel()
        {
            var pipeline = new LearningPipeline
             {
                new TextLoader(_Traindatapath).CreateFrom<ItemStock>(useHeader: true, separator: ','),
                new ColumnCopier(("TotalStockQty", "Label")),
                new CategoricalOneHotVectorizer(
                    "ItemID",
                   "Loccode",
                  //"InQty",
                  //  "OutQty",
                    "ItemType"),
                new ColumnConcatenator(
                    "Features",
                    "ItemID",
                    "Loccode",
                   "InQty",
                    "OutQty",
                    "ItemType"),
                new FastTreeRegressor()
            };

            PredictionModel<ItemStock, itemStockQtyPrediction> model = pipeline.Train<ItemStock, itemStockQtyPrediction>();

            await model.WriteAsync(_modelpath);
            return model;
        }


        private static void Evaluate(PredictionModel<ItemStock, itemStockQtyPrediction> model)
        {
            var testData = new TextLoader(_Evaluatedatapath).CreateFrom<ItemStock>(useHeader: true, separator: ',');
            var evaluator = new RegressionEvaluator();
            RegressionMetrics metrics = evaluator.Evaluate(model, testData);

            Console.WriteLine($"Rms = {metrics.Rms}");

            Console.WriteLine($"RSquared = {metrics.RSquared}");
          
        }

    }
}
