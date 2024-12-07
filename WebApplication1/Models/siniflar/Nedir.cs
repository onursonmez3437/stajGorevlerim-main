using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.siniflar
{
	public class Nedir
	{
		[Key]
		public int ID { get; set; }
		public string konu { get; set; }
		public string aciklama { get; set; }
        public string ekAciklama { get; set; }
        public int deger { get; set; }
        public string aciklama2 { get; set; }
        public string aciklama3 { get; set; }
        public string aciklama4 { get; set; }
        public string imageUrl2 { get; set; }
        public string imageUrl3 { get; set; }
        public string imageUrl4 { get; set; }
        public IEnumerable<Nedir> Nedirler { get; set; }

    }
}