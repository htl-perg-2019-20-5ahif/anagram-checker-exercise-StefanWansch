using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramChecker.Services
{
    internal class DictionaryFileReader : IDictionaryReader
    {
        private readonly IConfiguration config;

        public DictionaryFileReader(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Reads the dictionary file
        /// </summary>
        /// <returns>Content of the dictionary file</returns>
        public async Task<string> ReadDictionary()
        {
            var dictFile = config["dictionaryFileName"];
            var dictionaryText = await System.IO.File.ReadAllTextAsync(dictFile);
            return dictionaryText;
        }
    }
}
