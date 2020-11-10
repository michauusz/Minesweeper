using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
	public partial class Mines10x10 : Form
	{
		Button[,] buttonsArr = new Button[10, 10];
		int[,] valuesArr = new int[10, 10];
		public Mines10x10()
		{
			InitializeComponent();
			//////////////////////////////////////////////////////////generate board
			
			int xPos = 70, yPos = 70;
			for (int i = 0; i < 10; ++i)
			{
				xPos = 70;
				for (int j = 0; j < 10; ++j)
				{
					Button newButton = new Button();
					newButton.Location = new Point(xPos + j * 20, yPos + i * 20);
					newButton.Size = new Size(20, 20);
					newButton.Click += new EventHandler(newButton_Click);
					this.Controls.Add(newButton);
					buttonsArr[i, j] = newButton;
					valuesArr[i, j] = 0;
				}
			}
			generateMines();
			generateNumbers();
			//////////////////////////////////////////////////////////////////////////////////

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}
		private void newButton_Click(object sender, System.EventArgs e)
		{
			var button = (Button)sender;
			int newx = button.Location.X;
			int newy = button.Location.Y;
			int x, y;
			x = (newx / 10 - 7)/2;
			y = (newy / 10 - 7)/2;
			if (valuesArr[x, y] == 10)
			{
				((Button)sender).Text = "9";
			}
			else
			{
				((Button)sender).Text = valuesArr[x, y].ToString();
				((Button)sender).Enabled = false;
			}

			
		}
		private void generateMines()
		{
			int x, y;
			Random rand = new Random();
			for (int i = 0; i < 10; i++)
			{
				x = rand.Next(10);
				y = rand.Next(10);
				valuesArr[x, y] = 10;
			}
		}
		private void generateNumbers()
		{
			
				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < 10; j++)
					{
						if (valuesArr[i, j] == 10)
						{
                        try
						{
							valuesArr[i - 1, j]++;
							valuesArr[i + 1, j]++;
							valuesArr[i, j + 1]++;
							valuesArr[i, j - 1]++;
							valuesArr[i - 1, j - 1]++;
							valuesArr[i - 1, j + 1]++;
							valuesArr[i + 1, j - 1]++;
							valuesArr[i + 1, j + 1]++;
						}
						catch (Exception e){ }
					}
					}
				}
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (valuesArr[i, j] > 10)
					{
						valuesArr[i, j] = 10;
						}
				}
			}


		}
	}
}
