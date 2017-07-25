using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization;

namespace Optimization
{
    public class GradientDescent : IOptimization
    {
        private ObjectiveFunction CostFunction;
        public Settings GD_Settings { get; set; }
      

        public double[] GetFeatureHistory(int index = 0)
        {
            double[] Feature = new double[OPTHistoryResult.Count];
            Parallel.For(0, OPTHistoryResult.Count, i =>
            {
                Feature[i] = OPTHistoryResult[i].Parameters[index];
            });

            return Feature;
        }
        public double[] GetErrorHistory()
        {
            double[] Error = new double[OPTHistoryResult.Count];

            Parallel.For(0, OPTHistoryResult.Count, i =>
            {
                Error[i] = OPTHistoryResult[i].target[0];
            });

            return Error;
        }

        #region Interface Properties
        public List<Result> OPTHistoryResult { get; }
        public Result OPTResult { get; }
        

        public double[] Solve(ObjectiveFunction ObjFun)
        {
            CostFunction = ObjFun;
            double[] ParametersResult = (double[])GD_Settings.InitialParameters.Clone() ;

            int iter = 0;
             while(iter <= GD_Settings.Iteractions)
            {
                double[] auxParameters = new double[GD_Settings.InitialParameters.Length];

                Parallel.For (0, GD_Settings.InitialParameters.Length, i=>
                {
                    auxParameters[i] = ParametersResult[i] - GD_Settings.LearningRate[i] * PartialDerivative((double[])ParametersResult.Clone(), i);
                });

                ParametersResult = new double[auxParameters.Length];
                ParametersResult = (double[])auxParameters.Clone();
                double error = ObjFun(ParametersResult);

                OPTHistoryResult.Add(new Result
                {
                    Parameters = (double[])ParametersResult.Clone(),
                    target = new double[1] { error }
                });

                if (error < GD_Settings.Error.MaxValue && error > GD_Settings.Error.MinValue)
                    break;

                iter++;
            }
          

            OPTResult.Parameters = OPTHistoryResult.Last().Parameters;
            OPTResult.target = OPTHistoryResult.Last().target;

            return ParametersResult;
        }

        #endregion
        

        private double PartialDerivative(double[] parameters, int index)
        {
            double Eval = CostFunction(parameters);
            double[] dParameters = (double[])parameters.Clone();
            dParameters[index] = dParameters[index] + GD_Settings.Delta;
            double dEval = CostFunction(dParameters);

            return (dEval - Eval)/GD_Settings.Delta;
        }

        #region Constructors
        public GradientDescent(double[] initialParameters, double[] learningRate, int iteractions)
        {
            GD_Settings = new Settings();
            GD_Settings.Iteractions = iteractions;
            GD_Settings.LearningRate = learningRate;
            GD_Settings.InitialParameters = (double[])initialParameters.Clone();
            GD_Settings.Delta = 0.00001;
            GD_Settings.Error = new Range { MaxValue = 0.05, MinValue = 0 };

            OPTHistoryResult = new List<Result>();
            OPTResult = new Result();
        }
        public GradientDescent(double[] initialParameters, double[] learningRate, Range error)
        {

            GD_Settings = new Settings();
            GD_Settings.Iteractions = 100;
            GD_Settings.LearningRate = learningRate;
            GD_Settings.InitialParameters = (double[])initialParameters.Clone();
            GD_Settings.Delta = 0.00001;
            GD_Settings.Error = error;

            OPTHistoryResult = new List<Result>();
            OPTResult = new Result();
        }
      

        #endregion

        public class Settings
        {
          
            public double Delta { get; set; }
            public int Iteractions { get; set; }
            public Range Error { get; set; }
            public double[] InitialParameters { get; set; }
            public double[] LearningRate { get; set; }
        }

    }
}
