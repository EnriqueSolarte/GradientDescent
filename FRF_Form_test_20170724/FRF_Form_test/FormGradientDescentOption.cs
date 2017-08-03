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
        List<Mode> VLoopModes;
        Range RangeEvaluation;

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
            VLoopModes = new List<Mode>();
            CreateModes(VLoopModes);
            RangeEvaluation = new Range { MinValue = TryToDouble(textBoxEvalRangeMin.Text), MaxValue = TryToDouble(textBoxEvalRangeMax.Text) };
            buttonRunGradientDescent.Enabled = false;       
            GradientDescentOptimization();
            buttonRunGradientDescent.Enabled = true;
        }

        //>>>>Here RUN Gradient Descent
        private void GradientDescentOptimization()
        {
            IsThereDataAvailable = false;
            double[] InitialParameters = new double[(VLoopModes.Count -1)*3];
            InitialParameters = GettingInitialValues();

            double[] LearningRate = new double[InitialParameters.Length];

            for(int i=0; i< InitialParameters.Length/3; i++)
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
            GD.GD_Settings.Error = new Range { MaxValue = 0.0001, MinValue = 0 };
            GD.Solve(CostFucntion);

            #region Writting Results
            textBoxOPFreq.Clear();
            textBoxOPZeta.Clear();
            textBoxOPMass.Clear();
            for (int i=0; i< GD.OPTResult.Parameters.Length/3; i++ )
            {
                textBoxOPFreq.Text = textBoxOPFreq.Text + "   " + GD.OPTResult.Parameters[0 + i * 3].ToString("00.000");
                textBoxOPZeta.Text = textBoxOPZeta.Text + "   " + GD.OPTResult.Parameters[1 + i * 3].ToString("0.000");
                textBoxOPMass.Text = textBoxOPMass.Text + "   " + GD.OPTResult.Parameters[2 + i * 3].ToString("0.000");         
            }
            textBoxOPError.Text = GD.OPTResult.target[0].ToString();
            #endregion

            IsThereDataAvailable = true;
            PlottingGAData();

            newVLoopModes = new List<Mode>();
            newVLoopModes.Add(new Mode
            {
                Freq = VLoopModes[0].Freq,
                Zeta = VLoopModes[0].Zeta,
                Mass = VLoopModes[0].Mass
            });

            for (int i = 0; i < InitialParameters.Length/ 3; i++)
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
        //<<<
        private double[] GettingInitialValues()
        {
            double[] iniValues = new double[(VLoopModes.Count -1)*3];

            for(int i=0; i < VLoopModes.Count-1; i++)
            {
                iniValues[0 + i*3] = VLoopModes[i+1].Freq;
                iniValues[1 + i*3] = VLoopModes[i+1].Zeta;
                iniValues[2 + i*3] = VLoopModes[i+1].Mass;
            }
            return (double[])iniValues.Clone();
        }

        private double CostFucntion(double[] parameters)
        {
            FRF[] Struct_sim = new FRF[FormMain.Struct_ref.Length];

            List<Mode> Modes = new List<Mode>();
            Modes.Add(new Mode {
                Freq = VLoopModes[0].Freq,
                Zeta = VLoopModes[0].Zeta,
                Mass = VLoopModes[0].Mass
            });

            for(int i=0;i< 3; i++)
            {
                Mode mode = new Mode();
                mode.Freq = parameters[0 + i*3];
                mode.Zeta = parameters[1 + i*3];
                mode.Mass = parameters[2 + i*3];
                Modes.Add(mode);
            }

            double errorMag = 0;
            double errorPhs = 0;
            for (int i = 0; i < FormMain.Struct_ref.Length; i++)
            {
                Complex Res = Tool.GetStructureResponse(FormMain.Struct_ref[i].Freq, Modes, "Velocity");
                Struct_sim[i] = new FRF(FormMain.Struct_ref[i].Freq, Res);

                if(Struct_sim[i].Freq > RangeEvaluation.MinValue && Struct_sim[i].Freq < RangeEvaluation.MaxValue)
                {
                    errorMag = Math.Pow(Struct_sim[i].Mag - FormMain.Struct_ref[i].Mag, 2) + errorMag;
                    errorPhs = Math.Pow(Struct_sim[i].Phs - FormMain.Struct_ref[i].Phs, 2) + errorPhs;
                }
               
            }
            return errorMag;
        }

        public static void CreateModes(List<Mode> VLoopModes)
        {

            Mode mode;
            mode = new Mode();
            mode.Freq = 0;
            mode.Zeta = 0;
            mode.Mass = 0.00546 + 0.012;
          
            VLoopModes.Add(mode);

            mode = new Mode();
            // mode.Freq = 55;
            mode.Freq = 40;
            mode.Zeta = 0.05;
            mode.Mass = 0.05;
            VLoopModes.Add(mode);

            mode = new Mode();
            //mode.Freq = 120;
            mode.Freq = 130;
            mode.Zeta = 0.05;
            mode.Mass = 0.05;
            VLoopModes.Add(mode);

            mode = new Mode();
           // mode.Freq = 315;
            mode.Freq = 300;
            mode.Zeta = 0.05;
            mode.Mass = 0.05;
            VLoopModes.Add(mode);

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
                    for (int i = 0; i < GD.OPTResult.Parameters.Length / 3; i++)
                    {
                        DrawLine(GD.GetFeatureHistory(0 + i*3), i, chartParameters);
                    }                  
                }

                
                if (radioButtonZeta.Checked)
                {
                    for (int i = 0; i < GD.OPTResult.Parameters.Length / 3; i++)
                    {
                        DrawLine(GD.GetFeatureHistory(1 + i * 3), i, chartParameters);
                    }
                }
                if (radioButtonMass.Checked)
                {
                    for (int i = 0; i < GD.OPTResult.Parameters.Length / 3; i++)
                    {
                        DrawLine(GD.GetFeatureHistory(2 + i * 3), i, chartParameters);
                    }
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
