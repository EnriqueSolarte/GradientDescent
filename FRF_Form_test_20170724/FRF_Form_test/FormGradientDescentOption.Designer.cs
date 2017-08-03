namespace FRF_Form_test
{
    partial class FormGradientDescentOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFitness = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radioButtonMass = new System.Windows.Forms.RadioButton();
            this.radioButtonZeta = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonRunGradientDescent = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDelta = new System.Windows.Forms.TextBox();
            this.textBoxLRateFreq = new System.Windows.Forms.TextBox();
            this.textBoxIterations = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxOPError = new System.Windows.Forms.TextBox();
            this.textBoxOPZeta = new System.Windows.Forms.TextBox();
            this.textBoxOPFreq = new System.Windows.Forms.TextBox();
            this.textBoxOPMass = new System.Windows.Forms.TextBox();
            this.radioButtonFreq = new System.Windows.Forms.RadioButton();
            this.chartParameters = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxLRateZeta = new System.Windows.Forms.TextBox();
            this.textBoxLRateMass = new System.Windows.Forms.TextBox();
            this.textBoxEvalRangeMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxEvalRangeMax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartFitness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFitness
            // 
            chartArea3.Name = "ChartArea1";
            this.chartFitness.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartFitness.Legends.Add(legend3);
            this.chartFitness.Location = new System.Drawing.Point(-1, 0);
            this.chartFitness.Margin = new System.Windows.Forms.Padding(2);
            this.chartFitness.Name = "chartFitness";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Series2";
            this.chartFitness.Series.Add(series7);
            this.chartFitness.Series.Add(series8);
            this.chartFitness.Size = new System.Drawing.Size(742, 306);
            this.chartFitness.TabIndex = 3;
            this.chartFitness.Text = "11";
            this.chartFitness.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_mag_GetToolTipText);
            // 
            // radioButtonMass
            // 
            this.radioButtonMass.AutoSize = true;
            this.radioButtonMass.Location = new System.Drawing.Point(653, 478);
            this.radioButtonMass.Name = "radioButtonMass";
            this.radioButtonMass.Size = new System.Drawing.Size(46, 16);
            this.radioButtonMass.TabIndex = 29;
            this.radioButtonMass.TabStop = true;
            this.radioButtonMass.Text = "Mass";
            this.radioButtonMass.UseVisualStyleBackColor = true;
            this.radioButtonMass.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonZeta
            // 
            this.radioButtonZeta.AutoSize = true;
            this.radioButtonZeta.Location = new System.Drawing.Point(655, 456);
            this.radioButtonZeta.Name = "radioButtonZeta";
            this.radioButtonZeta.Size = new System.Drawing.Size(43, 16);
            this.radioButtonZeta.TabIndex = 30;
            this.radioButtonZeta.TabStop = true;
            this.radioButtonZeta.Text = "Zeta";
            this.radioButtonZeta.UseVisualStyleBackColor = true;
            this.radioButtonZeta.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(642, 627);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 12);
            this.label16.TabIndex = 45;
            this.label16.Text = "Optimal Values";
            // 
            // buttonRunGradientDescent
            // 
            this.buttonRunGradientDescent.Location = new System.Drawing.Point(536, 764);
            this.buttonRunGradientDescent.Name = "buttonRunGradientDescent";
            this.buttonRunGradientDescent.Size = new System.Drawing.Size(145, 23);
            this.buttonRunGradientDescent.TabIndex = 46;
            this.buttonRunGradientDescent.Text = "Run Gradient Descent";
            this.buttonRunGradientDescent.UseVisualStyleBackColor = true;
            this.buttonRunGradientDescent.Click += new System.EventHandler(this.RunGDEvent);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 684);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 12);
            this.label10.TabIndex = 52;
            this.label10.Text = "delta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 627);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 53;
            this.label8.Text = "Learning Rate";
            // 
            // textBoxDelta
            // 
            this.textBoxDelta.Location = new System.Drawing.Point(292, 681);
            this.textBoxDelta.Name = "textBoxDelta";
            this.textBoxDelta.Size = new System.Drawing.Size(51, 22);
            this.textBoxDelta.TabIndex = 51;
            this.textBoxDelta.Text = "0.0001";
            // 
            // textBoxLRateFreq
            // 
            this.textBoxLRateFreq.Location = new System.Drawing.Point(378, 644);
            this.textBoxLRateFreq.Name = "textBoxLRateFreq";
            this.textBoxLRateFreq.Size = new System.Drawing.Size(51, 22);
            this.textBoxLRateFreq.TabIndex = 50;
            this.textBoxLRateFreq.Tag = "";
            this.textBoxLRateFreq.Text = "50";
            // 
            // textBoxIterations
            // 
            this.textBoxIterations.Location = new System.Drawing.Point(292, 719);
            this.textBoxIterations.Name = "textBoxIterations";
            this.textBoxIterations.Size = new System.Drawing.Size(51, 22);
            this.textBoxIterations.TabIndex = 50;
            this.textBoxIterations.Tag = "";
            this.textBoxIterations.Text = "5000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 725);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 12);
            this.label4.TabIndex = 53;
            this.label4.Text = "Iterations";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(448, 729);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 12);
            this.label13.TabIndex = 58;
            this.label13.Text = "Error";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(445, 678);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 12);
            this.label5.TabIndex = 59;
            this.label5.Text = "Zeta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 708);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "Mass";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(448, 647);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 12);
            this.label20.TabIndex = 61;
            this.label20.Text = "Freq";
            // 
            // textBoxOPError
            // 
            this.textBoxOPError.Enabled = false;
            this.textBoxOPError.Location = new System.Drawing.Point(479, 729);
            this.textBoxOPError.Name = "textBoxOPError";
            this.textBoxOPError.Size = new System.Drawing.Size(252, 22);
            this.textBoxOPError.TabIndex = 54;
            // 
            // textBoxOPZeta
            // 
            this.textBoxOPZeta.Enabled = false;
            this.textBoxOPZeta.Location = new System.Drawing.Point(480, 673);
            this.textBoxOPZeta.Name = "textBoxOPZeta";
            this.textBoxOPZeta.Size = new System.Drawing.Size(252, 22);
            this.textBoxOPZeta.TabIndex = 55;
            // 
            // textBoxOPFreq
            // 
            this.textBoxOPFreq.Enabled = false;
            this.textBoxOPFreq.Location = new System.Drawing.Point(480, 647);
            this.textBoxOPFreq.Name = "textBoxOPFreq";
            this.textBoxOPFreq.Size = new System.Drawing.Size(252, 22);
            this.textBoxOPFreq.TabIndex = 56;
            // 
            // textBoxOPMass
            // 
            this.textBoxOPMass.Enabled = false;
            this.textBoxOPMass.Location = new System.Drawing.Point(480, 701);
            this.textBoxOPMass.Name = "textBoxOPMass";
            this.textBoxOPMass.Size = new System.Drawing.Size(252, 22);
            this.textBoxOPMass.TabIndex = 57;
            // 
            // radioButtonFreq
            // 
            this.radioButtonFreq.AutoSize = true;
            this.radioButtonFreq.Location = new System.Drawing.Point(655, 434);
            this.radioButtonFreq.Name = "radioButtonFreq";
            this.radioButtonFreq.Size = new System.Drawing.Size(44, 16);
            this.radioButtonFreq.TabIndex = 63;
            this.radioButtonFreq.TabStop = true;
            this.radioButtonFreq.Text = "Freq";
            this.radioButtonFreq.UseVisualStyleBackColor = true;
            this.radioButtonFreq.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // chartParameters
            // 
            chartArea4.Name = "ChartArea1";
            this.chartParameters.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartParameters.Legends.Add(legend4);
            this.chartParameters.Location = new System.Drawing.Point(-1, 310);
            this.chartParameters.Margin = new System.Windows.Forms.Padding(2);
            this.chartParameters.Name = "chartParameters";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "Series2";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "Series3";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.Fuchsia;
            series12.Legend = "Legend1";
            series12.Name = "Series4";
            this.chartParameters.Series.Add(series9);
            this.chartParameters.Series.Add(series10);
            this.chartParameters.Series.Add(series11);
            this.chartParameters.Series.Add(series12);
            this.chartParameters.Size = new System.Drawing.Size(742, 306);
            this.chartParameters.TabIndex = 64;
            this.chartParameters.Text = "11";
            this.chartParameters.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_mag_GetToolTipText);
            // 
            // textBoxLRateZeta
            // 
            this.textBoxLRateZeta.Location = new System.Drawing.Point(378, 673);
            this.textBoxLRateZeta.Name = "textBoxLRateZeta";
            this.textBoxLRateZeta.Size = new System.Drawing.Size(51, 22);
            this.textBoxLRateZeta.TabIndex = 50;
            this.textBoxLRateZeta.Tag = "";
            this.textBoxLRateZeta.Text = "0.005";
            // 
            // textBoxLRateMass
            // 
            this.textBoxLRateMass.Location = new System.Drawing.Point(378, 701);
            this.textBoxLRateMass.Name = "textBoxLRateMass";
            this.textBoxLRateMass.Size = new System.Drawing.Size(51, 22);
            this.textBoxLRateMass.TabIndex = 50;
            this.textBoxLRateMass.Tag = "";
            this.textBoxLRateMass.Text = "0.005";
            // 
            // textBoxEvalRangeMin
            // 
            this.textBoxEvalRangeMin.Location = new System.Drawing.Point(262, 646);
            this.textBoxEvalRangeMin.Name = "textBoxEvalRangeMin";
            this.textBoxEvalRangeMin.Size = new System.Drawing.Size(38, 22);
            this.textBoxEvalRangeMin.TabIndex = 35;
            this.textBoxEvalRangeMin.Text = "30";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 631);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "Range Evaluation";
            // 
            // textBoxEvalRangeMax
            // 
            this.textBoxEvalRangeMax.Location = new System.Drawing.Point(306, 646);
            this.textBoxEvalRangeMax.Name = "textBoxEvalRangeMax";
            this.textBoxEvalRangeMax.Size = new System.Drawing.Size(38, 22);
            this.textBoxEvalRangeMax.TabIndex = 35;
            this.textBoxEvalRangeMax.Text = "500";
            // 
            // FormGradientDescentOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 807);
            this.Controls.Add(this.radioButtonFreq);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxOPError);
            this.Controls.Add(this.textBoxOPZeta);
            this.Controls.Add(this.textBoxOPFreq);
            this.Controls.Add(this.textBoxOPMass);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxLRateMass);
            this.Controls.Add(this.textBoxDelta);
            this.Controls.Add(this.textBoxLRateZeta);
            this.Controls.Add(this.textBoxIterations);
            this.Controls.Add(this.textBoxLRateFreq);
            this.Controls.Add(this.buttonRunGradientDescent);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxEvalRangeMax);
            this.Controls.Add(this.textBoxEvalRangeMin);
            this.Controls.Add(this.radioButtonMass);
            this.Controls.Add(this.radioButtonZeta);
            this.Controls.Add(this.chartFitness);
            this.Controls.Add(this.chartParameters);
            this.MaximizeBox = false;
            this.Name = "FormGradientDescentOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gradient Descent Optimization";
            ((System.ComponentModel.ISupportInitialize)(this.chartFitness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFitness;
        private System.Windows.Forms.RadioButton radioButtonMass;
        private System.Windows.Forms.RadioButton radioButtonZeta;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonRunGradientDescent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDelta;
        private System.Windows.Forms.TextBox textBoxLRateFreq;
        private System.Windows.Forms.TextBox textBoxIterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxOPError;
        private System.Windows.Forms.TextBox textBoxOPZeta;
        private System.Windows.Forms.TextBox textBoxOPFreq;
        private System.Windows.Forms.TextBox textBoxOPMass;
        private System.Windows.Forms.RadioButton radioButtonFreq;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartParameters;
        private System.Windows.Forms.TextBox textBoxLRateZeta;
        private System.Windows.Forms.TextBox textBoxLRateMass;
        private System.Windows.Forms.TextBox textBoxEvalRangeMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxEvalRangeMax;
    }
}