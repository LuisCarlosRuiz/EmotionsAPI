using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmotionPlatzi.Web.Models
{
	public class Home
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the welcome message.
		/// </summary>
		[MaxLength(50)]
		public string WelcomeMessage { get; set; }

		/// <summary>
		/// Gets or sets the footer message.
		/// </summary>
		[MaxLength(50)]
		public string FooterMessage { get; set; } = "Footer by @LukoRuiz";
	}
}