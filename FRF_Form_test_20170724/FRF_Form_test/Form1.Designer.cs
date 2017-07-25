namespace FRF_Form_test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_mag = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_phs = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_phs)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_mag
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_mag.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_mag.Legends.Add(legend1);
            this.chart_mag.Location = new System.Drawing.Point(9, 10);
            this.chart_mag.Margin = new System.Windows.Forms.Padding(2);
            this.chart_mag.Name = "chart_mag";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart_mag.Series.Add(series1);
            this.chart_mag.Series.Add(series2);
            this.chart_mag.Size = new System.Drawing.Size(681, 306);
            this.chart_mag.TabIndex = 0;
            this.chart_mag.Text = "chart1";
            this.chart_mag.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.InformationTipEvent);
            // 
            // chart_phs
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_phs.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_phs.Legends.Add(legend2);
            this.chart_phs.Location = new System.Drawing.Point(9, 321);
            this.chart_phs.Margin = new System.Windows.Forms.Padding(2);
            this.chart_phs.Name = "chart_phs";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart_phs.Series.Add(series3);
            this.chart_phs.Series.Add(series4);
            this.chart_phs.Size = new System.Drawing.Size(681, 306);
            this.chart_phs.TabIndex = 1;
            this.chart_phs.Text = "chart_phs";
            this.chart_phs.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.InformationTipEvent);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 650);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Gradient Descent";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 685);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart_phs);
            this.Controls.Add(this.chart_mag);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_mag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_phs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mag;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_phs;
        private System.Windows.Forms.Button button1;
    }
}

