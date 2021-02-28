using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Services.Extensions
{
    public static class FormFileExtensions
    {
        public static List<string> ReadAsList(this IFormFile file)
        {
            List<string> lines = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    lines.Add(reader.ReadLine());
            }
            return lines;
        }
    }
}
