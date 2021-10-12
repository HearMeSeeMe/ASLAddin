using System;
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

     


        private void btnVoiceRec_CheckedChanged(object sender, EventArgs e)
		{
			if (btnVoiceRec.Checked)
			{
                Task.Run(async () => await RecognitionWithMic());
                //RecognitionWithMic().GetAwaiter().GetResult();

            }
			else
			{
                //Task.Run(async () => await  recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false))
			}
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
                        txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\r\nRECOGNIZING: " + e.Result.Text + "\r\n"));
                        
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

                        txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\r\nRECOGNIZED: " + e.Result.Text));
                        txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\r\n-------------------- "));
                        txtResult.Invoke(new MethodInvoker(() => txtResult.Text += "\n"));
                        txtResult.Invoke(new MethodInvoker(() =>
                        {
                            txtResult.SelectionStart = txtResult.Text.Length;
                            txtResult.ScrollToCaret();
                        }));

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
                    txtResult.Invoke(new MethodInvoker(() => txtResult.Text = "\n    Session started event."));

                

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
            slide.Shapes.AddMediaObject2(@"C:\Project\ASL\ref\Speech-to-ASL\output.mp4", Left:with-530, Top:height-230, Width:300, Height:200);
            
        }

		private void button1_Click(object sender, EventArgs e)
		{

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
	}
}
