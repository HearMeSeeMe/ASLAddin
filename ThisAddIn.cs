using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.ComponentModel;
using System.Windows.Forms;

namespace SignLanguageAssistant
{
    
    public partial class ThisAddIn
    {
        public UCASLPane myUCASLPane;
        public Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;

        
        private int _slideNumber = 1;

        private BackgroundWorker worker;

        public int TotalSlideNumber { get; set; }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			while (true)
			{
                


                Thread.Sleep(100);
			}
		}

	    private void ThisAddIn_EndInit(object sender, System.EventArgs e)
		{
            MessageBox.Show("endinit");
		}

		private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            myUCASLPane = new UCASLPane();
            myCustomTaskPane = this.CustomTaskPanes.Add(myUCASLPane, "Sign Language Assistant");
            myCustomTaskPane.Visible = false;



            //
            PowerPoint.Application app = Globals.ThisAddIn.Application;
            app.SlideShowBegin += App_SlideShowBegin;
			app.SlideShowEnd += App_SlideShowEnd;
			app.SlideSelectionChanged += App_SlideSelectionChanged;

            
            

            //TODO: research how to add control to powerpoint status bar.
        }

		private void App_SlideSelectionChanged(PowerPoint.SlideRange SldRange)
		{
            //get total slide number
            PowerPoint.Application app = Globals.ThisAddIn.Application;
            TotalSlideNumber = app.ActivePresentation.Slides.Count;
        }


        private void App_SlideShowEnd(PowerPoint.Presentation Pres)
		{
            //TODO: remove all video
            MessageBox.Show("App_SlideShowEnd");
        }

		private void App_SlideShowBegin(PowerPoint.SlideShowWindow Wn)
		{

            //TODO: add video to every slide.
            PowerPoint.Application app = Globals.ThisAddIn.Application;           

            var presentation = app.ActivePresentation;

            var slide = presentation.Slides[_slideNumber];
            slide.Shapes.AddMediaObject2(@"C:\Project\ASL\ref\Speech-to-ASL\output.mp4", LinkToFile: Microsoft.Office.Core.MsoTriState.msoCTrue, SaveWithDocument: Microsoft.Office.Core.MsoTriState.msoFalse, Left: 8.4F * 72, Top: 4.7F * 72, Width: 300, Height: 200);
            
            //MessageBox.Show("App_SlideShowBegin");
        }

		private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
