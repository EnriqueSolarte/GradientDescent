using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


using Mechatronics.MathToolBox;
using Mechatronics.SimCore.FrequencyResponse;
using Mechatronics.SimCore.Object;
using Mechatronics.FANUC;
using System.Windows.Forms.DataVisualization.Charting;

using Optimization;

namespace FRF_Form_test
{
    public partial class Form1 : Form
    {
        public FRF[] Struct_ref;
      

        public Form1()
        {
            InitializeComponent();

            //WATCH OUT:
            //Definition of Modes has changed.
            //VLoopModes adds additional 0Hz. mode.
            //0Hz. mode. should be also defined in Mode object.

            //Object name change: Parameter --> ServoPrm

            //Add Motor object. (not important)


           
           
            //Set experiment Control Parameters
            ServoPrm P = SetParameters();
            FANUCMotor Motor = new FANUCMotor(1.2, 0.012);

            ////create Object
            // VR = new VelocityLoop(P, Motor, VLoopModes);
         

            //read FRF File from csv file, which is created by servoguide
            //this data is considered as referance.
            FRF[] Close_ref =  Tool.Read_ServoGuide_FRFdata("Frequency_Response_Axis-1_1_-_1000Hz_edited.csv");
            //set freq interval. it should be identical with ref.
            //VR.IsFreqDataSameAsRef = true;
            //VR.SetCustomFreqInterval(Close_ref);



            //remove controller response from measurement data
            //extract Structure response
             Struct_ref = Tool.ExtractStructureResponseFromVLoop(P, Motor, Close_ref);
            //OPTIMIZATION TARGET 



            ////caculate simulated FRF.
            //FRF[] Close_sim = VR.GetCloseLoop(); //////////// HERE
            //FRF[] Open_sim = VR.GetOpenLoop(); //////////// HERE

            //draw simulated FRF of close loop system
            //DrawLine(Close_ref, 0);
            //DrawLine(Close_sim, 1);


            //caculate simulated Structure FRF.
            //FRF[] Struct_sim = new FRF[Struct_ref.Length];
            //for (int i = 0; i < Struct_ref.Length; i++)
            //{
            //    Complex Res = Tool.GetStructureResponse(Struct_ref[i].Freq, VLoopModes, "Velocity");
            //    Struct_sim[i] = new FRF(Struct_ref[i].Freq, Res);
            //}



            //draw simulated FRF of structure

            DrawLine(Struct_ref, 0);
            //DrawLine(Struct_sim, 1);
        }

        #region fix
        ServoPrm SetParameters()
        {//value is from *.prm file (ServoGuide Parameter file)

            ServoPrm P = new ServoPrm();
            //P.FANUCs.HRVGain = 300;
            //P.FANUCs.VelocityLoopGain = 100;
            //P.JL = 0.00546;

            P.KVI = 740.2203300818m;
            P.KVP = 6.6915923521467m;

            P.dTzoh = 0.001m;
            P.Tc = 0.0003m;
            P.IsHighCycle = true;
            P.IsFullCloseLoop = true;

            return P;
        }
        
        void DrawLine(FRF[] FRFData, int Channel)
        {
            //X AXIS in log scale
            chart_mag.ChartAreas[0].AxisX.IsLogarithmic = true;
            chart_phs.ChartAreas[0].AxisX.IsLogarithmic = true;

            //reset
            chart_mag.Series[Channel].Points.Clear();
            chart_phs.Series[Channel].Points.Clear();

            for (int i = 0; i < FRFData.Length; i++)
            {
                chart_mag.Series[Channel].Points.AddXY(FRFData[i].Freq, Mechatronics.MathToolBox.TL.DB(FRFData[i].Mag));
                chart_phs.Series[Channel].Points.AddXY(FRFData[i].Freq, FRFData[i].Phs);

            }

        }
        internal static void DrawLine(FRF[] FRFData, int Channel, Chart Chart_mag, Chart Chart_phs)
        {
            //X AXIS in log scale
            Chart_mag.ChartAreas[0].AxisX.IsLogarithmic = true;
            Chart_phs.ChartAreas[0].AxisX.IsLogarithmic = true;

            //reset
            Chart_mag.Series[Channel].Points.Clear();
            Chart_phs.Series[Channel].Points.Clear();

            for (int i = 0; i < FRFData.Length; i++)
            {
                Chart_mag.Series[Channel].Points.AddXY(FRFData[i].Freq, Mechatronics.MathToolBox.TL.DB(FRFData[i].Mag));
                Chart_phs.Series[Channel].Points.AddXY(FRFData[i].Freq, FRFData[i].Phs);
            }
        }
        internal void DrawResult(FRF[] resultOPT)
        {
            DrawLine(resultOPT, 1, chart_mag, chart_phs);
        }
        #endregion

        #region Enrique Solarte
        private void InformationTipEvent(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint myPoint = (DataPoint)(e.HitTestResult.Object);
                e.Text = "X value: " + myPoint.XValue + Environment.NewLine;
                e.Text += "Y value: " + myPoint.YValues[0] + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormGradientDescentOption GDFrom = new FormGradientDescentOption(this);
            GDFrom.Show();
        }
        #endregion
    }
}
