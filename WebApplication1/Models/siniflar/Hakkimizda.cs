using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.siniflar
{
	public class Hakkimizda
	{
		[Key]
        public int ID { get; set; }
		public string FotoURL { get; set; }
		public string Aciklama { get; set; }
    }
}