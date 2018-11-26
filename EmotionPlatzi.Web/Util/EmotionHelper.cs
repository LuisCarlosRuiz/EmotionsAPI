using EmotionPlatzi.Web.Models;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace EmotionPlatzi.Web.Util
{
	public class EmotionHelper
	{
		public EmotionServiceClient emoClient;

		public EmotionHelper(string key)
		{
			emoClient = new EmotionServiceClient(key);
		}

		public async Task<EmoPicture> DetectAndExtractFacesAsync(Stream imageStream)
		{
			Emotion[] emotions = await emoClient.RecognizeAsync(imageStream);
			var emoPicture = new EmoPicture();
			emoPicture.Faces = ExtractFaces(emotions, emoPicture);
			return emoPicture;
		}

		private ObservableCollection<EmoFace> ExtractFaces(Emotion[] emotions, EmoPicture emoPicture)
		{
			var listFaces = new ObservableCollection<EmoFace>();
			foreach (var emotion in emotions)
			{
				var emoface = new EmoFace()
				{
					X = emotion.FaceRectangle.Left,
					Y = emotion.FaceRectangle.Top,
					Width = emotion.FaceRectangle.Width,
					Height = emotion.FaceRectangle.Height,
					Picture = emoPicture
				};
				emoface.Emotions = ProcessEmotions(emotion.Scores, emoface);
				listFaces.Add(emoface);
			}
			return listFaces;
		}

		private ObservableCollection<EmoEmotion> ProcessEmotions(Scores scores, EmoFace emoface)
		{
			var emotionList = new ObservableCollection<EmoEmotion>();
			var properties = scores.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var filterProperties = properties.Where(p => p.PropertyType == typeof(float));

			var emoType = EmoEmotionEnum.Undetermined;
			foreach (var prop in filterProperties)
			{
				if(!Enum.TryParse<EmoEmotionEnum>(prop.Name, out emoType))
					emoType = EmoEmotionEnum.Undetermined;

				var emoEmotion = new EmoEmotion();
				emoEmotion.Score = (float)prop.GetValue(scores);
				emoEmotion.EmotionType = emoType;
				emoEmotion.Face = emoface;

				emotionList.Add(emoEmotion);
			}
			return emotionList;
		}
	}
}