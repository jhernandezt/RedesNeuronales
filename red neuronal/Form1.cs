using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Neural_Networks
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button TrainingButton;
		private System.Windows.Forms.Button TestButton;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button SinglePrimeButton;
		private System.Windows.Forms.TextBox primeEntryTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblFalseResults;
		private System.Windows.Forms.Label lblMissedPrimes;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitializeNetwork();

			Invalidate();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		Nnetwork Network = null;

		// XOR Data
//		double[,] inputs = {{0,0}, {0,1}, {1, 0}, {1,1}}; 
//		double[,] outputs = {{0}, {1}, {1}, {0}}; 

		int[] primes = new int[]{2,      3,      5,      7,     11,     13,     17,     19,     23,     29, 
										  31,     37,     41,     43,     47,     53,     59,     61,     67,     71, 
										  73,     79,     83,    89,     97,      101,    103,    107,    109,    113, 
										  127,    131,    137,    139,    149,    151,    157,    163,    167,    173, 
										  179,    181,    191,    193,    197,    199,    211,    223,    227,    229, 
										  233,    239,    241,    251,    257,    263,    269,    271,    277,    281, 
										  283,    293,    307,    311,    313,    317,    331,    337,    347,    349, 
										  353,    359,    367,    373,    379,    383,    389,    397,    401,    409, 
										  419,    421,    431,    433,    439,    443,    449,    457,    461,    463, 
										  467,    479,    487,    491,    499,    503,    509,    521,    523,    541, 
										  547,    557,    563,    569,    571,    577,    587,    593,    599,    601, 
										  607,    613,    617,    619,    631 ,   641 ,   643 ,   647,    653,    659, 
										  661,    673,    677,    683,    691,    701,    709,    719,    727,    733, 
										  739,    743,    751,    757,    761,    769,    773,    787,    797,    809, 
										  811,    821,    823,    827,    829,    839,    853,    857,    859,    863, 
										  877,    881,    883,    887,    907,    911,    919,    929,    937,    941, 
										  947,    953,    967,    971,    977,    983,    991,    997};
       double[,] inputs = new double[1000, 10];
	   double[,] outputs = new double[1000,1];
        

		void InitializeNetwork()
		{
			// fill arrays with prime and non prime
			for (int i = 0; i < inputs.GetLength(0); i++)
			{
				// form a binary number for the input
				int num = i;
				int mask = 0x200;
				for (int j = 0; j < 10; j++)
				{
					 if ((num & mask) > 0)
						inputs[i, j] = 1;
					else
						 inputs[i, j] = 0;

					mask = mask >> 1;
				}

				if (Array.BinarySearch(primes, i) >= 0)
				{
					// we found a prime
					outputs[i,0] = 1;
				}
				else
				{
					outputs[i,0] = 0;
				}
			}
		}

		private void DoStats(int num, int outputValue)
		{
			if (Array.BinarySearch(primes, num) >= 0)
			{
				// we found a prime
				if (outputValue == 0)
				{
					// missed the prime
					int val = Convert.ToInt32(lblMissedPrimes.Text);
					lblMissedPrimes.Text = (val + 1).ToString();
				}
			}
			else
			{
				// not a prime
				// we found a prime
				if (outputValue == 1)
				{
					// false prime
					int val = Convert.ToInt32(lblFalseResults.Text);
					lblFalseResults.Text = (val + 1).ToString();
				}
			}

		}

		void TrainNetwork()
		{
			// construct a network based on the input
			Network = new Nnetwork(inputs.GetLength(1), (int)numericUpDown1.Value, (int)outputs.GetLength(1));

			// randomize weights
			Network.FirstTimeSettings();

			// set up inputs and outputs

			Network.TrainNetwork(inputs, outputs, (int)numericUpDown2.Value, progressBar1);
			
		}

		private void StartTimedSimulation()
		{
			count = 0;
			lblMissedPrimes.Text = "0";
			lblFalseResults.Text = "0";
			timer1.Interval = trackBar1.Value;
			// now see if the results of training in a timed loop
			timer1.Start();
			SimulationStarted = true;
		}

		// counts iterations in the timer
		int count = 0;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TrainingButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SinglePrimeButton = new System.Windows.Forms.Button();
            this.primeEntryTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFalseResults = new System.Windows.Forms.Label();
            this.lblMissedPrimes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(106, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "number of training interations";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(106, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "number of  hidden nodes";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TrainingButton
            // 
            this.TrainingButton.Location = new System.Drawing.Point(595, 166);
            this.TrainingButton.Name = "TrainingButton";
            this.TrainingButton.Size = new System.Drawing.Size(125, 27);
            this.TrainingButton.TabIndex = 6;
            this.TrainingButton.Text = "Train";
            this.TrainingButton.Click += new System.EventHandler(this.TrainingButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.Enabled = false;
            this.TestButton.Location = new System.Drawing.Point(614, 240);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(96, 28);
            this.TestButton.TabIndex = 7;
            this.TestButton.Text = "Test All";
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 419);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(909, 25);
            this.statusBar1.TabIndex = 8;
            this.statusBar1.Text = "statusBar1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(29, 231);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            this.numericUpDown1.Leave += new System.EventHandler(this.numericUpDown1_Leave);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(29, 277);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown2.TabIndex = 10;
            this.numericUpDown2.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(346, 240);
            this.trackBar1.Maximum = 2000;
            this.trackBar1.Minimum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBar1.Size = new System.Drawing.Size(124, 53);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Value = 1000;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(298, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "slow";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(490, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 27);
            this.label4.TabIndex = 13;
            this.label4.Text = "fast";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(355, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "simulation speed";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(595, 203);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(125, 27);
            this.progressBar1.TabIndex = 15;
            // 
            // SinglePrimeButton
            // 
            this.SinglePrimeButton.Enabled = false;
            this.SinglePrimeButton.Location = new System.Drawing.Point(586, 277);
            this.SinglePrimeButton.Name = "SinglePrimeButton";
            this.SinglePrimeButton.Size = new System.Drawing.Size(124, 37);
            this.SinglePrimeButton.TabIndex = 16;
            this.SinglePrimeButton.Text = "Test Single Number";
            this.SinglePrimeButton.Click += new System.EventHandler(this.SinglePrimeButton_Click);
            // 
            // primeEntryTextBox
            // 
            this.primeEntryTextBox.Location = new System.Drawing.Point(720, 286);
            this.primeEntryTextBox.Name = "primeEntryTextBox";
            this.primeEntryTextBox.Size = new System.Drawing.Size(86, 22);
            this.primeEntryTextBox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(634, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "False Results";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(614, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 19);
            this.label8.TabIndex = 21;
            this.label8.Text = "Missed Primes";
            // 
            // lblFalseResults
            // 
            this.lblFalseResults.BackColor = System.Drawing.Color.White;
            this.lblFalseResults.ForeColor = System.Drawing.Color.Red;
            this.lblFalseResults.Location = new System.Drawing.Point(739, 342);
            this.lblFalseResults.Name = "lblFalseResults";
            this.lblFalseResults.Size = new System.Drawing.Size(48, 18);
            this.lblFalseResults.TabIndex = 22;
            this.lblFalseResults.Text = "0";
            // 
            // lblMissedPrimes
            // 
            this.lblMissedPrimes.BackColor = System.Drawing.Color.White;
            this.lblMissedPrimes.ForeColor = System.Drawing.Color.Maroon;
            this.lblMissedPrimes.Location = new System.Drawing.Point(739, 369);
            this.lblMissedPrimes.Name = "lblMissedPrimes";
            this.lblMissedPrimes.Size = new System.Drawing.Size(48, 19);
            this.lblMissedPrimes.TabIndex = 23;
            this.lblMissedPrimes.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(909, 444);
            this.Controls.Add(this.lblMissedPrimes);
            this.Controls.Add(this.lblFalseResults);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.primeEntryTextBox);
            this.Controls.Add(this.SinglePrimeButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.TrainingButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Neural Network Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		  // Draw the neural network
			int input =   inputs.GetLength(1);
			int hidden = (int)numericUpDown1.Value;
			int output =  outputs.GetLength(1);

			Graphics g = e.Graphics;

			// draw input values
			for (int i = 0; i < input; i++)
			{
				g.DrawString(inputs[CurrentCount, i].ToString(), Font, Brushes.Navy, 
				(ClientRectangle.Width - input * 50)/2 + i * 50 + 15, 5, new StringFormat());
			}

			g.DrawString(CurrentCount.ToString(), Font, Brushes.Green, 
				ClientRectangle.Width - 20, 5, new StringFormat());

			// draw input layer
			for (int i = 0; i < input; i++)
			{
				// center around client
				g.DrawEllipse(Pens.Black, (ClientRectangle.Width - input * 50)/2 + i * 50, 20, 30, 30);
				g.DrawString("S", SymbolFont, Brushes.Green, 
					(ClientRectangle.Width - input * 50)/2 + i * 50 + 5, 20 + 5);
			}

			// draw hidden layer
			for (int i = 0; i < hidden; i++)
			{
				g.DrawEllipse(Pens.Black, 
					(ClientRectangle.Width - hidden * 50)/2 + i * 50, 70, 30, 30);
				g.DrawString("S", SymbolFont, Brushes.Green, 
					(ClientRectangle.Width - hidden * 50 + 5)/2 + i * 50, 70 + 5);
			}

			// draw output layer
			for (int i = 0; i < output; i++)
			{
				g.DrawEllipse(Pens.Black, 
					(ClientRectangle.Width - output * 50)/2 + i * 50, 120, 30, 30);
				g.DrawString("S", SymbolFont, Brushes.Green, 
					(ClientRectangle.Width - output * 50)/2 + i * 50 + 10, 120 + 5);
			}

			// draw output values
			for (int i = 0; i < output; i++)
			{
				if (SimulationStarted)
				{
					g.DrawString(CurrentOutputValue[i], Font, Brushes.Purple, 
						(ClientRectangle.Width - output * 50)/2 + i * 50 + 15, 160, new StringFormat());
				}
				else
				{
					g.DrawString(outputs[CurrentCount, i].ToString(), Font, Brushes.Navy, 
						(ClientRectangle.Width - output * 50)/2 + i * 50 + 15, 160, new StringFormat());
				}
			}


			// now connect each input layer to the hidden layer
			for (int i = 0; i < input; i++)
			{
				for (int j = 0; j < hidden; j++)
					// center around client
				{
				   g.DrawLine(Pens.Red,   
					   (ClientRectangle.Width - input * 50)/2 + i*50 + 15, 50,
					   (ClientRectangle.Width - hidden * 50)/2 + j*50 + 15, 70);
				}
			}

			// now connect each hidden layer to the output layer
			for (int i = 0; i < hidden; i++)
			{
				for (int j = 0; j < output; j++)
					// center around client
				{
					g.DrawLine(Pens.Red,   
						(ClientRectangle.Width - hidden * 50)/2 + i*50 + 15, 100,
						(ClientRectangle.Width - output * 50)/2 + j*50 + 15, 120);
				}
			}




		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			Invalidate();
		}



		string[] CurrentOutputValue;
		int CurrentCount = 0;

		Font SymbolFont = new Font("Symbol", 14, FontStyle.Bold);

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			CurrentCount = count;
			CurrentOutputValue = Network.Test_Drive(CurrentCount, inputs).Split(new char[]{' '});

			DoStats(CurrentCount, Convert.ToInt32(CurrentOutputValue[0]));

			count++;
			if (CurrentCount >= inputs.GetUpperBound(0))
			{
				Invalidate();
				Update();
				SimulationStarted = false; // stop simulation drawing
				timer1.Stop();
			}
			else
			{
				Invalidate();
			}
		}

		private void TrainingButton_Click(object sender, System.EventArgs e)
		{
			statusBar1.Text = "Training...";
			TrainNetwork();
			TestButton.Enabled = true;
			this.SinglePrimeButton.Enabled = true;
			statusBar1.Text = "Ready";
		}

		bool SimulationStarted = false;
		private void TestButton_Click(object sender, System.EventArgs e)
		{
			StartTimedSimulation();
		}

		private void numericUpDown1_ValueChanged_1(object sender, System.EventArgs e)
		{
			Invalidate();
		}

		private void numericUpDown1_Leave(object sender, System.EventArgs e)
		{
			Invalidate();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			timer1.Interval = trackBar1.Value;
		}

		private void SinglePrimeButton_Click(object sender, System.EventArgs e)
		{
			CurrentCount = Convert.ToInt32(this.primeEntryTextBox.Text);
			CurrentOutputValue = Network.Test_Drive(CurrentCount, inputs).Split(new char[]{' '});
			Invalidate();
			Update();
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			Invalidate();
		}
	}
}
