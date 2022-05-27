namespace WeatherWindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxWeather = new System.Windows.Forms.GroupBox();
            this.regression = new System.Windows.Forms.Label();
            this.regressionResult = new System.Windows.Forms.Label();
            this.currTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mainWeather = new System.Windows.Forms.Label();
            this.groupBoxWind = new System.Windows.Forms.GroupBox();
            this.windSpeed = new System.Windows.Forms.Label();
            this.windDirection = new System.Windows.Forms.Label();
            this.averageTemp = new System.Windows.Forms.Label();
            this.weatherDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.temperatureChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.errorLabel = new System.Windows.Forms.Label();
            this.groupBoxWeather.SuspendLayout();
            this.groupBoxWind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureChart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxWeather
            // 
            this.groupBoxWeather.Controls.Add(this.errorLabel);
            this.groupBoxWeather.Controls.Add(this.regression);
            this.groupBoxWeather.Controls.Add(this.regressionResult);
            this.groupBoxWeather.Controls.Add(this.currTime);
            this.groupBoxWeather.Controls.Add(this.label7);
            this.groupBoxWeather.Controls.Add(this.mainWeather);
            this.groupBoxWeather.Controls.Add(this.groupBoxWind);
            this.groupBoxWeather.Controls.Add(this.averageTemp);
            this.groupBoxWeather.Controls.Add(this.weatherDescription);
            this.groupBoxWeather.Controls.Add(this.label1);
            this.groupBoxWeather.Controls.Add(this.panel1);
            this.groupBoxWeather.Location = new System.Drawing.Point(12, 12);
            this.groupBoxWeather.Name = "groupBoxWeather";
            this.groupBoxWeather.Size = new System.Drawing.Size(654, 274);
            this.groupBoxWeather.TabIndex = 1;
            this.groupBoxWeather.TabStop = false;
            this.groupBoxWeather.Text = "Weather";
            // 
            // regression
            // 
            this.regression.AutoSize = true;
            this.regression.Location = new System.Drawing.Point(162, 200);
            this.regression.Name = "regression";
            this.regression.Size = new System.Drawing.Size(60, 13);
            this.regression.TabIndex = 8;
            this.regression.Text = "Regression";
            // 
            // regressionResult
            // 
            this.regressionResult.AutoSize = true;
            this.regressionResult.Location = new System.Drawing.Point(159, 181);
            this.regressionResult.Name = "regressionResult";
            this.regressionResult.Size = new System.Drawing.Size(91, 13);
            this.regressionResult.TabIndex = 7;
            this.regressionResult.Text = "Regression result:";
            // 
            // currTime
            // 
            this.currTime.AutoSize = true;
            this.currTime.Location = new System.Drawing.Point(128, 42);
            this.currTime.Name = "currTime";
            this.currTime.Size = new System.Drawing.Size(64, 13);
            this.currTime.TabIndex = 6;
            this.currTime.Text = "CurrentTime";
            this.currTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Last update:";
            // 
            // mainWeather
            // 
            this.mainWeather.AutoSize = true;
            this.mainWeather.Location = new System.Drawing.Point(128, 83);
            this.mainWeather.Name = "mainWeather";
            this.mainWeather.Size = new System.Drawing.Size(71, 13);
            this.mainWeather.TabIndex = 4;
            this.mainWeather.Text = "MainWeather";
            // 
            // groupBoxWind
            // 
            this.groupBoxWind.Controls.Add(this.windSpeed);
            this.groupBoxWind.Controls.Add(this.windDirection);
            this.groupBoxWind.Location = new System.Drawing.Point(6, 161);
            this.groupBoxWind.Name = "groupBoxWind";
            this.groupBoxWind.Size = new System.Drawing.Size(149, 100);
            this.groupBoxWind.TabIndex = 0;
            this.groupBoxWind.TabStop = false;
            this.groupBoxWind.Text = "Wind";
            // 
            // windSpeed
            // 
            this.windSpeed.AutoSize = true;
            this.windSpeed.Location = new System.Drawing.Point(9, 73);
            this.windSpeed.Name = "windSpeed";
            this.windSpeed.Size = new System.Drawing.Size(63, 13);
            this.windSpeed.TabIndex = 4;
            this.windSpeed.Text = "WindSpeed";
            // 
            // windDirection
            // 
            this.windDirection.AutoSize = true;
            this.windDirection.Location = new System.Drawing.Point(9, 39);
            this.windDirection.Name = "windDirection";
            this.windDirection.Size = new System.Drawing.Size(74, 13);
            this.windDirection.TabIndex = 0;
            this.windDirection.Text = "WindDirection";
            // 
            // averageTemp
            // 
            this.averageTemp.AutoSize = true;
            this.averageTemp.Location = new System.Drawing.Point(6, 132);
            this.averageTemp.Name = "averageTemp";
            this.averageTemp.Size = new System.Drawing.Size(107, 13);
            this.averageTemp.TabIndex = 3;
            this.averageTemp.Text = "AverageTemperature";
            // 
            // weatherDescription
            // 
            this.weatherDescription.AutoSize = true;
            this.weatherDescription.Location = new System.Drawing.Point(128, 106);
            this.weatherDescription.Name = "weatherDescription";
            this.weatherDescription.Size = new System.Drawing.Size(101, 13);
            this.weatherDescription.TabIndex = 2;
            this.weatherDescription.Text = "WeatherDescription";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // temperatureChart
            // 
            chartArea1.Name = "ChartArea1";
            this.temperatureChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.temperatureChart.Legends.Add(legend1);
            this.temperatureChart.Location = new System.Drawing.Point(287, 26);
            this.temperatureChart.Name = "temperatureChart";
            this.temperatureChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Temperature";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Regression";
            this.temperatureChart.Series.Add(series1);
            this.temperatureChart.Series.Add(series2);
            this.temperatureChart.Size = new System.Drawing.Size(373, 224);
            this.temperatureChart.TabIndex = 2;
            this.temperatureChart.Text = "chart1";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(162, 247);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 294);
            this.Controls.Add(this.temperatureChart);
            this.Controls.Add(this.groupBoxWeather);
            this.Name = "Form1";
            this.Text = "Weather";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxWeather.ResumeLayout(false);
            this.groupBoxWeather.PerformLayout();
            this.groupBoxWind.ResumeLayout(false);
            this.groupBoxWind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxWeather;
        private System.Windows.Forms.GroupBox groupBoxWind;
        private System.Windows.Forms.Label windSpeed;
        private System.Windows.Forms.Label averageTemp;
        private System.Windows.Forms.Label weatherDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label windDirection;
        private System.Windows.Forms.Label mainWeather;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label currTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart temperatureChart;
        private System.Windows.Forms.Label regressionResult;
        private System.Windows.Forms.Label regression;
        private System.Windows.Forms.Label errorLabel;
    }
}

