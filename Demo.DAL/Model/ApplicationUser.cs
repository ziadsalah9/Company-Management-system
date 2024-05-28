using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Model
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string Fname { get; set; }

		[Required]
		public string LName { get; set; }

		[Required]
		public bool IsAgree { get; set; }


	}
}
