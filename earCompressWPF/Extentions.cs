using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earCompressManager.Util {
    public static class Extentions {

        public static string GetFileExtension(this string nombreArchivo) {
            var pos = nombreArchivo.LastIndexOf(".");
            if(pos > 0) {
                return nombreArchivo.Substring(pos).ToLower();
            }
            return "";
        }
    }
}
