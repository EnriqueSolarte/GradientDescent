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

namespace FRF_Form_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //WATCH OUT:
            //Definition of Modes has changed.
            //VLoopModes adds additional 0Hz. mode.
            //0Hz. mode. should be also defined in Mode object.

            //Object name change: Parameter --> ServoPrm

            //Add Motor object. (not important)


            //Create Structure Nature Modes Object
            List<Mode> VLoopModes = new List<Mode>();
            CreateModes(VLoopModes);

            //Set experiment Control Parameters 
            ServoPrm P = SetParameters();
            FANUCMotor Motor = new FANUCMotor(1.2, 0.012); 

            //create Object
            VelocityLoop VR = new VelocityLoop(P, Motor, VLoopModes);

            //read FRF File from csv file, which is created by servoguide
            //this data is considered as referance.
            FRF[] Close_ref =  Tool.Read_ServoGuide_FRFdata("Frequency_Response_Axis-1_1_-_1000Hz.csv");

           
            //set freq interval. it should be identical with ref.
            VR.IsFreqDataSameAsRef = true;
            VR.SetCustomFreqInterval(Close_ref);


            //caculate simulated FRF.
            FRF[] Close_sim = VR.GetCloseLoop();
            FRF[] Open_sim = VR.GetOpenLoop();

            //draw simulated FRF of close loop system
            DrawLine(Close_ref, 0);
            DrawLine(Close_sim, 1);


            //remove controller response from measurement data
            //extract Structure response
            FRF[] Struct_ref = Tool.ExtractStructureResponseFromVLoop(P, Motor, Close_ref);


            //caculate simulated Structure FRF.
            FRF[] Struct_sim = new FRF[Struct_ref.Length];
            for (int i = 0; i < Struct_ref.Length; i++)
            {
                Complex Res = Tool.GetStructureResponse(Struct_ref[i].Freq, VLoopModes, "Velocity");
                Struct_sim[i] = new FRF(Struct_ref[i].Freq, Res);
            }
           
            //draw simulated FRF of structure
            DrawLine(Struct_ref, 0);
            DrawLine(Struct_sim, 1);

        }


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
        void CreateModes(List<Mode> VLoopModes)
        {

            Mode mode;


            mode = new Mode();
            mode.Freq = 0;
            mode.Zeta = 0;
            mode.Mass = 0.00546 + 0.012;

            VLoopModes.Add(mode);

            mode = new Mode();
            mode.Freq = 55;
            mode.Zeta = 0.1;
            mode.Mass = 0.3;
            VLoopModes.Add(mode);

            mode = new Mode();
            mode.Freq = 120;
            mode.Zeta = 0.07;
            mode.Mass = 0.12;
            VLoopModes.Add(mode);

            mode = new Mode();
            mode.Freq = 315;
            mode.Zeta = 0.1;
            mode.Mass = 0.05;
            VLoopModes.Add(mode);


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


    }
}
