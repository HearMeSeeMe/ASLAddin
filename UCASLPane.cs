using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;


namespace SignLanguageAssistant
{
	public partial class UCASLPane : UserControl
	{

        SpeechConfig config = SpeechConfig.FromSubscription("dafa0b166eb24ced8ac4e606336701e1", "southeastasia");

		public UCASLPane()
		{
			InitializeComponent();

        }

        public void Init()
		{
            lvSlide.Items.Clear();
            for (var i = 1; i <= Globals.ThisAddIn.TotalSlideNumber; i++)
            {
                ListViewItem listViewItem = new ListViewItem { Text = $"Slide{i}" };
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = "-" });
                lvSlide.Items.Add(listViewItem);
            }
        }

        public bool CheckVideo
		{
			get { return chkVideo.Checked; }
		}

        public bool CheckAudio
		{
			get { return chkAudio.Checked; }
		}

        public bool SlideStatus(int slideNo)
		{
			if(lvSlide.Items.Count >= slideNo)
			{
                if(lvSlide.Items[slideNo-1].SubItems[1].Text == "completed")
				{
                    return true;
				}
			}
            return false;
		}

     


        private void btnVoiceRec_CheckedChanged(object sender, EventArgs e)
		{
			//if (btnVoiceRec.Checked)
			//{
   //             Task.Run(async () => await RecognitionWithMic());
   //             //RecognitionWithMic().GetAwaiter().GetResult();

   //         }
			//else
			//{
   //             //Task.Run(async () => await  recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false))
			//}
		}

        public void ShowPanel()
		{
            panel1.Invoke(new MethodInvoker(() => panel1.Visible = true));
		}

        public void HidePanel()
		{
            panel1.Invoke(new MethodInvoker(() => panel1.Visible = false));
        }

		private async Task RecognitionWithMic()
		{
            var stopRecognition = new TaskCompletionSource<int>();

            using (var recognizer = new SpeechRecognizer(config))
			{

                //var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                // Subscribes to events.
                recognizer.Recognizing += (s, e) =>
                {
                    if (e.Result.Reason == ResultReason.RecognizingSpeech)
                    {
                        //txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\r\nRECOGNIZING: " + e.Result.Text + "\r\n"));
                        
                        //txtResult.Invoke(new MethodInvoker(() =>
                        //{
                        //    txtResult.SelectionStart = txtResult.Text.Length;
                        //    txtResult.ScrollToCaret();
                        //}));
                        

                        //Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
                        //// Retrieve the detected language
                        //var autoDetectSourceLanguageResult = AutoDetectSourceLanguageResult.FromResult(e.Result);
                        //Console.WriteLine($"DETECTED: Language={autoDetectSourceLanguageResult.Language}");
                    }
                };

                recognizer.Recognized += (s, e) =>
                {
                    if (e.Result.Reason == ResultReason.RecognizedSpeech)
                    {

                        //txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\r\nRECOGNIZED: " + e.Result.Text));
                        //txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\r\n-------------------- "));
                        //txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\n"));
                        //txtResult.Invoke(new MethodInvoker(() =>
                        //{
                        //    txtResult.SelectionStart = txtResult.Text.Length;
                        //    txtResult.ScrollToCaret();
                        //}));

                        //Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                        //// Retrieve the detected language
                        //var autoDetectSourceLanguageResult = AutoDetectSourceLanguageResult.FromResult(e.Result);
                        //Console.WriteLine($"DETECTED: Language={autoDetectSourceLanguageResult.Language}");
                    }
                    else if (e.Result.Reason == ResultReason.NoMatch)
                    {
                        Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                    }
                };

                recognizer.Canceled += (s, e) =>
                {
                    Console.WriteLine($"CANCELED: Reason={e.Reason}");

                    if (e.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }

                    stopRecognition.TrySetResult(0);
                };

                recognizer.SessionStarted += (s, e) =>
                {
                    //txtResult.Invoke(new MethodInvoker(() => txtResult.Text = "\n    Session started event."));

                

                    Console.WriteLine("\n    Session started event.");
                };

                recognizer.SessionStopped += (s, e) =>
                {
                    Console.WriteLine("\n    Session stopped event.");
                    Console.WriteLine("\nStop recognition.");
                    stopRecognition.TrySetResult(0);
                };

               await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                // Waits for completion.
                // Use Task.WaitAny to keep the task rooted.
                Task.WaitAny(new[] { stopRecognition.Task });

                // Stops recognition.
                await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);

            }
		}

	

		private void button2_Click(object sender, EventArgs e)
		{
            PowerPoint.Application app = Globals.ThisAddIn.Application;
            PowerPoint.SlideRange slideRange = app.ActiveWindow.Selection.SlideRange;

            var presentation = app.ActivePresentation;


            var slide = presentation.Slides[slideRange.SlideNumber];
            var with = slide.Application.Width;
            var height = slide.Application.Height;
            //slide.Shapes.AddMediaObject2(@"C:\Project\ASL\ref\Speech-to-ASL\output.mp4", Left:with-530, Top:height-230, Width:300, Height:200);
            slide.Shapes.AddMediaObject2(@"C:\Project\ASL\ref\Speech-to-ASL\output.mp4", LinkToFile: Microsoft.Office.Core.MsoTriState.msoCTrue, SaveWithDocument: Microsoft.Office.Core.MsoTriState.msoFalse, Left: 8.4F * 72, Top: 4.7F * 72, Width: 300, Height: 200);

        }


		private void button3_Click(object sender, EventArgs e)
		{
            config.SpeechSynthesisVoiceName = "en-US-BrandonNeural";
            
            using (var synthesizer = new SpeechSynthesizer(config))
            {
                
                string text = "When most I wink, then do mine eyes best see,  For all the day they view things unrespected";

                using (var result = synthesizer.SpeakTextAsync(text).Result)
                {
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesized to speaker for text [{text}]");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }
        }

        public void SpeakText(int slideNo)
		{
            if (!chkAudio.Checked) return;

            Thread.Sleep(1000);

            PowerPoint.Application app = Globals.ThisAddIn.Application;

            var presentation = app.ActivePresentation;

            var slide = presentation.Slides[slideNo];
            var text = slide.NotesPage.Shapes[2].TextFrame.TextRange.Text;

            config.SpeechSynthesisVoiceName = "en-US-BrandonNeural";

            using (var synthesizer = new SpeechSynthesizer(config))
            {

                using (var result = synthesizer.SpeakTextAsync(text).Result)
                {
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        //Console.WriteLine($"Speech synthesized to speaker for text [{text}]");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        //Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            //Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            //Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            //Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }
        }

		private void button4_Click(object sender, EventArgs e)
		{
            TextToSign tts = new TextToSign();
            tts.ProcessText(0, "good news do work");
            //tts.ProcessText("I had the best day of my life");


        }

		private void lvSlide_SelectedIndexChanged(object sender, EventArgs e)
		{
            PowerPoint.Application app = Globals.ThisAddIn.Application;

            var presentation = app.ActivePresentation;

            if(lvSlide.SelectedItems.Count > 0)
                presentation.Slides[lvSlide.SelectedItems[0].Index+1].Select();
            
            
        }

		private void btnProcessAll_Click(object sender, EventArgs e)
		{
            TextToSign tts = new TextToSign();

            for(int i = 1; i<= Globals.ThisAddIn.TotalSlideNumber; i++)
			{
                PowerPoint.Application app = Globals.ThisAddIn.Application;                
                var presentation = app.ActivePresentation;

                var slide = presentation.Slides[i];

                var note = slide.NotesPage.Shapes[2].TextFrame.TextRange.Text;

                if (string.IsNullOrEmpty(note))
				{
                    lvSlide.Items[i - 1].SubItems[1].Text = "note empty";
				}
				else
				{
                    bool process_result = tts.ProcessText(i, note);

					if (process_result)
					{
                        lvSlide.Items[i - 1].SubItems[1].Text = "completed";

                    }
                    //make
				}

            }
		}

        public void UpdateStatus(int slideNo, string status)
		{
            lvSlide.Items[slideNo - 1].SubItems[1].Text = status;
        }

        public void UpdateListView()
		{
            if(Globals.ThisAddIn.TotalSlideNumber > lvSlide.Items.Count)
			{
                ListViewItem listViewItem = new ListViewItem { Text = $"Slide{Globals.ThisAddIn.TotalSlideNumber}" };
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = "-" });
                lvSlide.Items.Add(listViewItem);
            }

            btnProcessAll_Click(null, null);
		}

		private void btnProcessCurrent_Click(object sender, EventArgs e)
		{
            TextToSign tts = new TextToSign();
            PowerPoint.Application app = Globals.ThisAddIn.Application;
            PowerPoint.SlideRange slideRange = app.ActiveWindow.Selection.SlideRange;

            var presentation = app.ActivePresentation;


            var slide = presentation.Slides[slideRange.SlideNumber];
            

            var note = slide.NotesPage.Shapes[2].TextFrame.TextRange.Text;

            if (string.IsNullOrEmpty(note))
            {
                lvSlide.Items[slideRange.SlideNumber - 1].SubItems[1].Text = "note empty";
            }
            else
            {
                bool process_result = tts.ProcessText(slideRange.SlideNumber, note);

                if (process_result)
                {
                    lvSlide.Items[slideRange.SlideNumber - 1].SubItems[1].Text = "completed";

                }
                //make
            }
        }
	}
}
