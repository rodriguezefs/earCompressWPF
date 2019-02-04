using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earCompressManager {
    public class InfoArchivo {
        public InfoArchivo(string nombre, long tamaño) {
            Nombre = nombre;
            Tamaño = tamaño;
        }
        public string Nombre { get; set; }
        public long Tamaño { get; set; }
    }
}
