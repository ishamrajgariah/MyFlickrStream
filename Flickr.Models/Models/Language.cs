using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrStream.Models
{
    /// <summary>
    /// Language 
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Gets the language code
        /// </summary>
        public string LanguageCode
        {
            get
            {
                //Get the language code based on name
                switch (Name)
                {
                    case LanguageName.English:
                        return "en-us";
                    case LanguageName.German:
                        return "de-de";
                    case LanguageName.Spanish:
                        return "es-us";
                    case LanguageName.French:
                        return "fr-fr";
                    case LanguageName.Italian:
                        return "it-it";
                    case LanguageName.Korean:
                        return "ko-kr";
                    case LanguageName.Portuguese:
                        return "pt-br";
                    case LanguageName.Chinese:
                        return "zh-hk";
                }

                return "en-US";
            }
        }

        /// <summary>
        /// Gets or sets the Language name
        /// <seealso cref="LanguageName"/>
        /// </summary>
        public LanguageName Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates an instance of <see cref="Language"/>
        /// </summary>
        /// <param name="name"></param>
        public Language(LanguageName name)
        {
            Name = name;
        }

        /// <summary>
        /// Converts the instance to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
