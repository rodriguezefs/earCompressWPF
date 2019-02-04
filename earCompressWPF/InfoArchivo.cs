using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earCompressManager {
    public class InfoArchivo {
        public InfoArchivo(string nombreFull, long tamaño) {
            NombreFull = nombreFull;
            Nombre = Path.GetFileName(nombreFull);
            Carpeta = Path.GetDirectoryName(nombreFull);
            Tamaño = tamaño;
        }
        public string Carpeta { get; set; }
        public string Nombre { get; set; }
        public string NombreFull { get; set; }
        public long Tamaño { get; set; }
    }
}
