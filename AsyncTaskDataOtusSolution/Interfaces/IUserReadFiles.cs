using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTaskDataOtusSolution.Interfaces
{
    public interface IUserReadFiles
    {
         Task<int> ReadFileAsync(string path);
    }
    
}
