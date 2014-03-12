using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class FichierCacher
    {
        private string _chemin;
        public string chemin { get { return _chemin; } set; }
        
        public FichierCacher(string Path)
        {
            chemin = Path;
        }

        public void FindFichierCacher()
        {
            List<String> ListeDossier=Directory.EnumerateDirectories(this.chemin).ToList();
        }
    }
}
