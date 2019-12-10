using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Entities.Anagram
{
	/// <summary>
	/// Entity for storing anagrams in database
	/// </summary>
    public class Anagram : Entity
    {
		private string word;

		[NotMapped]
		public string Word
		{
			get 
				{ 
					return word; 
				}
			set 
				{ 
					word = value;
					EncodedString = Convert.ToBase64String(Encoding.Unicode.GetBytes(word));
				}
		}


		public string EncodedString { get; set; }

    }
}
