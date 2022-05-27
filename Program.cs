/*\
 * Created by SharpDevelop.
 * User: Wesley
 * Date: 4/19/2022
 * Time: 6:13 AM
\*/
using System;
using System.Windows.Forms;

namespace texswap
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(args));
		}
		
	}
}
