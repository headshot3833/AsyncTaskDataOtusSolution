using AsyncTaskDataOtusSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTaskDataOtusSolution.Services
{
    public class UserReadFile : IUserReadFiles
    {
        public async Task<int> ReadFileAsync(string path)
        {
            
            if(path == null)
            {
                throw new ArgumentNullException("нужно ввести путь");
            }
            string content = await File.ReadAllTextAsync(path);
            int spaceCount = content.Count(c => c == ' ');

            return spaceCount;

        }
    }
}
