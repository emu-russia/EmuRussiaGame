
using System.Threading;

namespace EmuRussiaGame
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				edgblaSoftControl1.MoveEdgblaLeft();
				edgblaSoftControl1.Invalidate();
			}

			if (e.KeyCode == Keys.Right)
			{
				edgblaSoftControl1.MoveEdgblaRight();
				edgblaSoftControl1.Invalidate();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			edgblaSoftControl1.SpawnEdgbla();
			backgroundWorker1.RunWorkerAsync();
		}

		private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			while (!backgroundWorker1.CancellationPending)
			{
				edgblaSoftControl1.TickGame();
				edgblaSoftControl1.Invalidate();

				if (edgblaSoftControl1.IsCollided())
				{
					break;
				}

				Thread.Sleep(10);
			}

			MessageBox.Show("Не удалось что-то не сделать", "Game OVer!", MessageBoxButtons.OK);
		}
	}
}