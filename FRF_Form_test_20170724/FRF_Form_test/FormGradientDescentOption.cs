using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Optimization;
using Mechatronics.MathToolBox;
using Mechatronics.SimCore.FrequencyResponse;

namespace FRF_Form_test
{
    public partial class FormGradientDescentOption : Form
    {
        private Form1 FormMain;
        

        public bool IsThereDataAvailable { get; private set; }

        private GradientDescent GD;
        private List<Mode> newVLoopModes;

        public FormGradientDescentOption(Form1 formMain)
        {
            InitializeComponent();
            FormMain = formMain;
            
            
        }

        private void RunGDEvent(object sender, EventArgs e)
        {
            buttonRunGradientDescent.Enabled = false;
        
            GradientDescentOptimization();
            buttonRunGradientDescent.Enabled = true;
        }

        private void GradientDescentOptimization()
        {
            IsThereDataAvailable = false;
            double[] InitialParameters = new double[9];

            InitialParameters = GettingInitialValues();

            double[] LearningRate = new double[InitialParameters.Length];
            for(int i=0; i< 3; i++)
            {
                LearningRate[0 + i * 3] = TryToDouble(textBoxLRateFreq.Text);
                LearningRate[1 + i * 3] = TryToDouble(textBoxLRateZeta.Text);
                LearningRate[2 + i * 3] = TryToDouble(textBoxLRateMass.Text);
            }

            GD = new GradientDescent(
                InitialParameters,
                LearningRate,
                (int)TryToDouble(textBoxIterations.Text)         
                );

            GD.GD_Settings.Delta = TryToDouble(textBoxDelta.Text);

            GD.Solve(CostFucntion);

            #region Writting Results
            textBoxOPFreq.Text = GD.OPTResult.Parameters[0].ToString("00.000") + "-" + GD.OPTResult.Parameters[3].ToString("00.000") + "-" + GD.OPTResult.Parameters[6].ToString("00.000");
            textBoxOPZeta.Text = GD.OPTResult.Parameters[1].ToString("0.000") + "-" + GD.OPTResult.Parameters[4].ToString("0.000") + "-" + GD.OPTResult.Parameters[7].ToString("0.000");
            textBoxOPMass.Text = GD.OPTResult.Parameters[2].ToString("0.000") + "-" + GD.OPTResult.Parameters[5].ToString("0.000") + "-" + GD.OPTResult.Parameters[8].ToString("0.000");
            textBoxOPError.Text = GD.OPTResult.target[0].ToString();
            #endregion

            IsThereDataAvailable = true;
            PlottingGAData();

            newVLoopModes = new List<Mode>();
            newVLoopModes.Add(new Mode
            {
                Freq = FormMain.VLoopModes[0].Freq,
                Zeta = FormMain.VLoopModes[0].Zeta,
                Mass = FormMain.VLoopModes[0].Mass
            });

            for (int i = 0; i < 3; i++)
            {
                Mode mode = new Mode();
                mode.Freq = GD.OPTResult.Parameters[0 + i * 3];
                mode.Zeta = GD.OPTResult.Parameters[1 + i * 3];
                mode.Mass = GD.OPTResult.Parameters[2 + i * 3];
                newVLoopModes.Add(mode);
            }


            FRF[] Struct_sim = new FRF[FormMain.Struct_ref.Length];
            for (int i = 0; i < FormMain.Struct_ref.Length; i++)
            {
                Complex Res = Tool.GetStructureResponse(FormMain.Struct_ref[i].Freq, newVLoopModes, "Velocity");
                Struct_sim[i] = new FRF(FormMain.Struct_ref[i].Freq, Res);
            }

            FormMain.DrawResult(Struct_sim);
        }

        private double[] GettingInitialValues()
        {
            double[] iniValues = new double[9];

            for(int i=0; i < 3; i++)
            {
                iniValues[0 + i*3] = FormMain.VLoopModes[i+1].Freq;
                iniValues[1 + i*3] = FormMain.VLoopModes[i+1].Zeta;
                iniValues[2 + i*3] = FormMain.VLoopModes[i+1].Mass;
            }
            return (double[])iniValues.Clone();
        }

        private double CostFucntion(double[] parameters)
        {
            FRF[] Struct_sim = new FRF[FormMain.Struct_ref.Length];

            List<Mode> Modes = new List<Mode>();
            Modes.Add(new Mode {
                Freq = FormMain.VLoopModes[0].Freq,
                Zeta = FormMain.VLoopModes[0].Zeta,
                Mass = FormMain.VLoopModes[0].Mass
            });

            for(int i=0;i< 3; i++)
            {
                Mode mode = new Mode();
                mode.Freq = parameters[0 + i*3];
                mode.Zeta = parameters[1 + i*3];
                mode.Mass = parameters[2 + i*3];
                Modes.Add(mode);
            }

            double error = 0;
            for (int i = 0; i < FormMain.Struct_ref.Length; i++)
            {
                Complex Res = Tool.GetStructureResponse(FormMain.Struct_ref[i].Freq, Modes, "Velocity");
                Struct_sim[i] = new FRF(FormMain.Struct_ref[i].Freq, Res);

                error = Math.Pow(Struct_sim[i].Mag - FormMain.Struct_ref[i].Mag, 2) + error;

            }
            return error;
        }



        #region Fix Code
        private void chart_mag_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint myPoint = (DataPoint)(e.HitTestResult.Object);
                e.Text = "X value: " + myPoint.XValue + Environment.NewLine;
                e.Text += "Y value: " + myPoint.YValues[0] + Environment.NewLine;
            }
        }

        void DrawLine(double[] Data, int Channel, Chart chart)
        {

            //reset
            chart.Series[Channel].Points.Clear();

            for (int i = 0; i < Data.Length; i++)
            {
                chart.Series[Channel].Points.AddXY(i, Data[i]);
            }

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            PlottingGAData();
        }

        private void PlottingGAData()
        {
            if (IsThereDataAvailable)
            {
                DrawLine(GD.GetErrorHistory(), 0, chartFitness);

                if (radioButtonFreq.Checked)
                {
                    DrawLine(GD.GetFeatureHistory(0), 0, chartParameters);
                    DrawLine(GD.GetFeatureHistory(3), 1, chartParameters);
                    DrawLine(GD.GetFeatureHistory(6), 2, chartParameters);
                }
                if (radioButtonZeta.Checked)
                {
                    DrawLine(GD.GetFeatureHistory(1), 0, chartParameters);
                    DrawLine(GD.GetFeatureHistory(4), 1, chartParameters);
                    DrawLine(GD.GetFeatureHistory(7), 2, chartParameters);
                }
                if (radioButtonMass.Checked)
                {
                    DrawLine(GD.GetFeatureHistory(2), 0, chartParameters);
                    DrawLine(GD.GetFeatureHistory(5), 1, chartParameters);
                    DrawLine(GD.GetFeatureHistory(8), 2, chartParameters);
                }
            }
        }

        public static double TryToDouble(string stringValue)
        {
            double auxOut;
            double.TryParse(stringValue, out auxOut);
            return auxOut;
        }

        #endregion


    }
}
