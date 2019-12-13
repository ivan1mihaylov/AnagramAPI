using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Entities.Anagram
{
	/// <summary>
	/// Entity for storing words in database
	/// </summary>
    public class Word : Entity
    {
		private string encodedString;

		public Word()
		{
		}

		public Word(string encodedString)
		{
			EncodedString = encodedString;
		}

		public string EncodedString
		{
			get
			{
				return encodedString;
			}
			set
			{
				encodedString = value;
			}
		}

		[NotMapped]
		public string DecodedString
		{
			get 
				{ 
					return Encoding.UTF8.GetString(Convert.FromBase64String(encodedString)); 
				}
		}

		public ICollection<WordCheckResult> WordCheckResults { get; set; }
	}
}
