using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionPlatzi.Web.Models
{
	public class EmoPicture
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[MaxLength(55)]
		[Display(Name = "Nombre")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		[Required]
		[Display(Name = "Ruta")]
		[MaxLength(20, ErrorMessage = "20 es el maximo de caracteres permitido")]
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets the faces.
		/// </summary>
		public virtual ObservableCollection<EmoFace> Faces { get; set; }
	}
}
