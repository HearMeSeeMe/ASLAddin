using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNLP;
using OpenNLP.Tools.Tokenize;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using OpenNLP.Tools.SentenceDetect;

namespace SignLanguageAssistant
{
	public class TextToSign
	{


		string[] useless_words = { "is", "the", "are", "am", "a", "it", "was", "were", "an", "as", ",", ".", "?", "\"", "by", "at", "unlock" };

        //string[] sample_signs = { };

        //sample signs
        string[] sample_signs = {
            "accessible",
            "overcoming",
            "disabilities",
            "diversity",
            "employee",
            "full",
            "hearing",
            "help",
            "employees",
            "learning",
            "mental",
            "needed",
            "potential",
            "such",
            "technologies",
            "unlock",
            "visual",
            "able",
            "and",
            "another",
            "apply",
            "as",
            "ask",
            "attributes",
            "bad",
            "better",
            "break",
            "call",
            "carefully",
            "company",
            "cultural",
            "culture",
            "customers",
            "diverse",
            "do",
            "equal",
            "equitable",
            "equity",
            "everybody",
            "everyone",
            "fair",
            "from",
            "good",
            "growth",
            "hear",
            "hello",
            "hey",
            "hi",
            "how",
            "i",
            "in",
            "include",
            "inclusive",
            "it",
            "journey",
            "justice",
            "listen",
            "make",
            "me",
            "microsoft",
            "mindset",
            "morning",
            "my",
            "needs",
            "new",
            "one",
            "our",
            "out",
            "perspective",
            "phrase",
            "products",
            "project",
            "see",
            "seeking",
            "session",
            "shall",
            "share",
            "silos",
            "so",
            "sorry",
            "speech",
            "support",
            "supporting",
            "team",
            "technology",
            "technologies",
            "test",
            "that",
            "their",
            "them",
            "these",
            "they",
            "This",
            "tie",
            "to",
            "today",
            "together",
            "understand",
            "us",
            "we",
            "what",
            "when",
            "will",
            "with",
            "word",
            "work",
            "workplace",
            "you"
        };

        const string GITHUB_BASEURL = "https://github.com/HearMeSeeMe/DatasetProcessor/raw/main";

		const double SIMILIARITY_RATIO = 0.7;


		const string ENDPOINT = "https://textanalyticsasl.cognitiveservices.azure.com/";
		const string APIKEY = "cafcce289fa745d8b73271743819fa63";

		public string TempFolder
		{
			get
			{
				string basePath = Path.Combine(Path.GetTempPath() + "TextToSign");
				if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);
				return basePath;
			}
		}

		//TODO: change to async
		public TextToSign()
		{
			//check nbin files

			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.ServerCertificateValidationCallback += ServerCertificateValidationCallback;

			// https://github.com/AlexPoint/OpenNlp
			//sentence splitter
			if (!File.Exists(Path.Combine(TempFolder, "EnglishSD.nbin")))
			{
				Globals.ThisAddIn.myUCASLPane.ShowPanel();



				using (var client = new WebClient())
				{
					client.DownloadFile(GITHUB_BASEURL + "/EnglishSD.nbin", Path.Combine(TempFolder, "EnglishSD.nbin"));
				}

				//tokenizer dict
				if (!File.Exists(Path.Combine(TempFolder, "EnglishTok.nbin")))
				{

					using (var client = new WebClient())
					{
						client.DownloadFile(GITHUB_BASEURL + "/EnglishTok.nbin", Path.Combine(TempFolder, "EnglishTok.nbin"));
					}
				}

				//ffmpeg.exe
				if (!File.Exists(Path.Combine(TempFolder, "ffmpeg.exe")))
				{

					using (var client = new WebClient())
					{
						client.DownloadFile(GITHUB_BASEURL + "/ffmpeg.exe", Path.Combine(TempFolder, "ffmpeg.exe"));
					}
				}

				//Sign glossary
				//if (!File.Exists(Path.Combine(TempFolder, "signs_glossary.txt")))
				//{

					
				//}

				//using (var client = new WebClient())
				//{
				//	client.DownloadFile(GITHUB_BASEURL + "/signs_glossary.txt", Path.Combine(TempFolder, "signs_glossary.txt"));
				//}
				//sample_signs = System.IO.File.ReadAllLines(TempFolder + "\\signs_glossary.txt");

				//download signs
				Parallel.ForEach(sample_signs, (file) =>
				{
					file += ".mp4";

					string github_url = GITHUB_BASEURL + "/Signs/" + file;

					using (var client = new WebClient())
					{
                        client.DownloadFile(github_url, Path.Combine(TempFolder, file));
                        //client.DownloadFileAsync(new Uri(github_url), Path.Combine(TempFolder, file));
                    }
				});
			}

			Globals.ThisAddIn.myUCASLPane.HidePanel();


		}

		private bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if (sslPolicyErrors == SslPolicyErrors.None)
			{
				return true;
			}

			return false;
		}



		public bool ProcessText(int slideNo, string text)
		{
			//split sentence
			//var paragraph = text; //"Mr. & Mrs. Smith is a 2005 American romantic comedy action film. The film stars Brad Pitt and Angelina Jolie as a bored upper-middle class married couple. They are surprised to learn that they are both assassins hired by competing agencies to kill each other.";
			//var modelPath = Path.Combine(TempFolder, "EnglishSD.nbin");
			//var sentenceDetector = new EnglishMaximumEntropySentenceDetector(modelPath);
			//var sentences = sentenceDetector.SentenceDetect(paragraph);


			//extract tokens
			var modelPath = Path.Combine(TempFolder, "EnglishTok.nbin");
			var sentence = text; // "- Sorry Mrs. Hudson, I'll skip the tea.";
			var tokenizer = new EnglishMaximumEntropyTokenizer(modelPath);
			var tokens = tokenizer.Tokenize(sentence);


			List<string> words = new List<string>();

			// remove unused words
			useless_words.ToList().ForEach(x =>
			{
				tokens = tokens.Where(el => el != x).ToArray();
			});


			//find files
			List<string> found_words = new List<string>();
			tokens.ToList().ForEach(x =>
			{
				var found_file = Find_in_db(x);
				if (!string.IsNullOrEmpty(found_file))
				{
					found_words.Add(found_file);
				}
			});

			if (found_words.Count > 0)
			{
				return Merge_signs(slideNo, found_words);
			}

			return false;
		}

		// merge to mp4
		private bool Merge_signs(int slideNo, List<string> words)
		{
			bool result = false;

			string strVidList = string.Empty;

			try
			{
				words.ForEach(x =>
					{
						strVidList += $"file '{TempFolder}\\{x}.mp4'\r\n";
					});

				File.WriteAllText($"{TempFolder}\\vidlist.txt", strVidList);

				//update ui
				Globals.ThisAddIn.myUCASLPane.UpdateStatus(slideNo, "in progress");

				//execute command
				Process process = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				startInfo.FileName = "cmd.exe";
				//startInfo.Arguments = $"/C {TempFolder}\\ffmpeg.exe -f concat -safe 0 -i {TempFolder}\\vidlist.txt -c copy {TempFolder}\\output_{slideNo}.mp4 -y";

				//startInfo.Arguments = $"/C {TempFolder}\\ffmpeg.exe -f -safe 0 -f concat -segment_time_metadata 1 -i {TempFolder}\\vidlist.txt -vf select=concatdec_select -af aselect=concatdec_select,aresample=async=1 -c copy {TempFolder}\\output_{slideNo}.mp4 -y";
				startInfo.Arguments = $"/C {TempFolder}\\ffmpeg.exe -safe 0 -f concat -segment_time_metadata 1 -i {TempFolder}\\vidlist.txt -vf select=concatdec_select -af aselect=concatdec_select,aresample=async=1 {TempFolder}\\output_{slideNo}.mp4";


				//startInfo.Arguments = $"/C {TempFolder}\\ffmpeg.exe -f concat -i {TempFolder}\\vidlist.txt -c copy {TempFolder}\\output_{slideNo}.mp4 -y";
				process.StartInfo = startInfo;
				process.Start();

				process.WaitForExit();

				//update ui
				Globals.ThisAddIn.myUCASLPane.UpdateStatus(slideNo, "completed");

				return true;
			}
			catch (Exception ex)
			{
				//update ui
				Globals.ThisAddIn.myUCASLPane.UpdateStatus(slideNo, "failed");
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

			return result;
		}


		private double Similar(string a, string b)
		{
			return DiceCoefficient(a, b);
		}

		private string[] Get_words_in_database()
		{
			return sample_signs;
		}

		private string Find_in_db(string word)
		{
			double best_score = -1.0;
			string best_vid_name = string.Empty;

			sample_signs.ToList().ForEach(x =>
			{
				var similarity = Similar(x.ToLower(), word.ToLower());

				if (best_score < similarity)
				{
					best_score = similarity;
					best_vid_name = x;

				}
			});

			return best_score > SIMILIARITY_RATIO ? best_vid_name : null;

		}

		// https://en.wikibooks.org/wiki/Algorithm_Implementation/Strings/Dice%27s_coefficient
		public static double DiceCoefficient(string strA, string strB)
		{

			HashSet<string> setA = new HashSet<string>();
			HashSet<string> setB = new HashSet<string>();

			if (strA == strB) return 1.0;

			for (int i = 0; i < strA.Length - 1; ++i)
				setA.Add(strA.Substring(i, 2));

			for (int i = 0; i < strB.Length - 1; ++i)
				setB.Add(strB.Substring(i, 2));

			HashSet<string> intersection = new HashSet<string>(setA);
			intersection.IntersectWith(setB);

			return (2.0 * intersection.Count) / (setA.Count + setB.Count);
		}
	}
}
