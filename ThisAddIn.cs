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
using System.Threading.Tasks;

namespace SignLanguageAssistant
{
    
    public partial class ThisAddIn
    {
        public UCASLPane myUCASLPane;
        public Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;

        
        private int _slideNumber = 1;

        private int slideChangedCount = 0;

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
			app.SlideShowNextSlide += App_SlideShowNextSlide;
			app.SlideShowEnd += App_SlideShowEnd;
			app.SlideSelectionChanged += App_SlideSelectionChanged;

            
            

            //TODO: research how to add control to powerpoint status bar.
        }

		private void App_SlideShowNextSlide(PowerPoint.SlideShowWindow Wn)
		{
            if (myUCASLPane.SlideStatus(Wn.View.Slide.SlideNumber))
			{
                Task.Run(() => myUCASLPane.SpeakText(Wn.View.Slide.SlideNumber));

                //find video and play

                if (!myUCASLPane.CheckVideo) return;

    //            for(int i = 1; i<= Wn.View.Slide.Shapes.Count; i++)
				//{
    //                if(Wn.View.Slide.Shapes[i].Type == Office.MsoShapeType.msoMedia)
				//	{
    //                    Wn.View.Slide.Shapes[i].Select();

    //                }
				//}
            }
               

		}

		private void App_SlideSelectionChanged(PowerPoint.SlideRange SldRange)
		{
            //get total slide number
            PowerPoint.Application app = Globals.ThisAddIn.Application;

            //update listview when slide add/remove
            int prevTotalSlideNumber = TotalSlideNumber;

            TotalSlideNumber = app.ActivePresentation.Slides.Count;



            if (slideChangedCount > 0 && prevTotalSlideNumber != TotalSlideNumber)
                myUCASLPane.UpdateListView();

            slideChangedCount++;

        }

        // delete injected media
        private void App_SlideShowEnd(PowerPoint.Presentation Pres)
		{
            //TODO: remove all video
            //MessageBox.Show("App_SlideShowEnd");

            PowerPoint.Application app = Globals.ThisAddIn.Application;

            var presentation = app.ActivePresentation;

            for (int i = 1; i <= TotalSlideNumber; i++)
            {
                //completed (merged ASL)
                if (myUCASLPane.SlideStatus(i))
                {
                    var slide = presentation.Slides[i];

                    
                    var shapescnt = slide.Shapes.Count;

                    for(int s=1; s<= slide.Shapes.Count; s++)
					{
                        //var ttt = slide.Shapes[s].Type;
                        //var width = slide.Shapes[s].Width;
                        //var height = slide.Shapes[s].Height;

                        //delete injected media only
                        if(slide.Shapes[s].Type == Office.MsoShapeType.msoMedia && slide.Shapes[s].Height >= 150 && slide.Shapes[s].Height <= 250)
						{
                            slide.Shapes[s].Delete();
                            break;
                        }
					}
                }
            }
        }

		private void App_SlideShowBegin(PowerPoint.SlideShowWindow Wn)
		{

            //TODO: add video to every slide.
            PowerPoint.Application app = Globals.ThisAddIn.Application;           

            var presentation = app.ActivePresentation;

            //var slide = presentation.Slides[_slideNumber];
            //slide.Shapes.AddMediaObject2(@"C:\Project\ASL\ref\Speech-to-ASL\output.mp4", LinkToFile: Microsoft.Office.Core.MsoTriState.msoCTrue, SaveWithDocument: Microsoft.Office.Core.MsoTriState.msoFalse, Left: 8.4F * 72, Top: 4.7F * 72, Width: 300, Height: 200);

            TextToSign tts = new TextToSign();
        
            for(int i=1; i<= TotalSlideNumber; i++)
			{
                //completed (merged ASL)
				if (myUCASLPane.SlideStatus(i))
				{
                    var slide = presentation.Slides[i];
                    var videopath = $"{tts.TempFolder}\\output_{i}.mp4";
                    slide.Shapes.AddMediaObject2(videopath, LinkToFile: Microsoft.Office.Core.MsoTriState.msoCTrue, SaveWithDocument: Microsoft.Office.Core.MsoTriState.msoFalse, Left: 8.4F * 72, Top: 4.7F * 72, Width: 300, Height: 200);

                    //Task.Run(() => myUCASLPane.SpeakText(i));
                    
                }
			}
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
