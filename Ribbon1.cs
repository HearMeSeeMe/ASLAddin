using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace SignLanguageAssistant
{
	public partial class Ribbon1
	{
		private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
		{
			//TODO: implement custom tooltip with container(HearMeSeeMe in Action v2.0.pptx, page 15)
			this.btnSL.SuperTip = "Click to Turn on Sign Language Assistant\r\nBe Understood. Make this presentation Accessible";

		}


		private void btnSL_Click(object sender, RibbonControlEventArgs e)
		{
			if (!btnSL.Checked)
			{
				Globals.ThisAddIn.myCustomTaskPane.Visible = false;
				return;
			}

			
			//show taskpane
			Globals.ThisAddIn.myCustomTaskPane.Visible = true;

			Globals.ThisAddIn.myUCASLPane.Init();



			PowerPoint.Application app = Globals.ThisAddIn.Application;
			PowerPoint.SlideRange slideRange = app.ActiveWindow.Selection.SlideRange;

			var presentation = app.ActivePresentation;


			var slide = presentation.Slides[slideRange.SlideNumber];

			// https://www.free-power-point-templates.com/articles/create-powerpoint-ppt-programmatically-using-c/
			// wtf!! note index fixed.
			var note = slide.NotesPage.Shapes[2].TextFrame.TextRange.Text;


			// parse text only ===HearMeSeeMe=== section
			if (string.IsNullOrEmpty(note))
			{
				//System.Windows.Forms.MessageBox.Show("note emply");
			}
			else
			{
				/*
				
				test script in notepage

				===HearMeSeeMe===
				hi, there
				There over are 1 billion people in the world who have disabilities, many of whom need assistive technology. But only 1 in 10 have access to the products needed, and this means many of them can't fully participate in our economies and societies. Accessible technology can allow them to fully participate. 

				===HearMeSeeMe===

				 */

				//split line by line
				var notes = note.Split("\r".ToCharArray());

				const string SECTION = "===HearMeSeeMe===";
				int intSectionCnt = 0;

				var parsedNotes = string.Empty;

				foreach (var line in notes)
				{
					//ignore section
					//if (line.Contains(SECTION))
					//{
					//	intSectionCnt++;
					//	continue;
					//}

					//if (intSectionCnt == 0 || intSectionCnt == 2) continue;

					parsedNotes += line + "\r";
				}
				//System.Windows.Forms.MessageBox.Show(parsedNotes);
			}
		}
	}
}
