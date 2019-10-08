using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramChecker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AnagramChecker.Controllers
{
    [Route("api/checkAnagram")]
    [ApiController]
    public class AnagramCheckerController : ControllerBase
    {
        

        // GET: api/AnagramChecker
        [HttpGet]
        public IActionResult CheckAnagram([FromBody] Words w)
        {
            Boolean anagramCheck = w.check(w.word1,w.word2) ;
            if (anagramCheck)
            {
                return Ok(w);
            }
            return BadRequest(w);
        }

        
        [HttpGet]
        [Route("getKnownAnagrams")]
        public async Task<IEnumerable<string>> GetKnownWords([FromQuery] string w)
        {
            if (string.IsNullOrEmpty(w))
            {
                return null;
            }
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            IDictionaryReader reader = new DictionaryFileReader(config);
            
            string dictionaryText = await reader.ReadDictionary();
            Words word = new Words();
            IEnumerable<string> words= word.getKnownWords(dictionaryText, w);
            return words;
        }

       
    }
}
