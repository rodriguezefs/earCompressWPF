using earCompressManager;
using earCompressManager.Util;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earCompressWPF {

    public delegate void GetListProgress();
    public static class Compress {

        public static event GetListProgress _getListProgress;  //https://www.dotnetperls.com/event
        public static async Task<List<InfoArchivo>> GetListFiles(string nombreArchivo) {
            List<InfoArchivo> lxLstInfoArchivo = new List<InfoArchivo>();      

            using (Stream stream = File.OpenRead(nombreArchivo)) {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry()) {
                    if (!reader.Entry.IsDirectory) {
                        lxLstInfoArchivo.Add(new InfoArchivo(reader.Entry.Key, reader.Entry.Size));
                        await Task.Delay(1);
                    }
                }
            }
            return lxLstInfoArchivo;
        }

        public static void ExtraerArchivosDe7z(string Archivo, List<string> lstArchivos, string CarpetaDestino) {
            using (var archive = SevenZipArchive.Open(Archivo)) {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory)) {
                    if (lstArchivos.Any(str => str.Contains(entry.Key))) {
                        entry.WriteToDirectory(CarpetaDestino, new ExtractionOptions() {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    };
                }
            }
        }

        public static void ExtraerArchivosDeRAR(string Archivo, List<string> lstArchivos, string CarpetaDestino) {
            using (var archive = RarArchive.Open(Archivo)) {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory)) {
                    if (lstArchivos.Any(str => str.Contains(entry.Key))) {
                        entry.WriteToDirectory(CarpetaDestino, new ExtractionOptions() {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    };
                }
            }
        }

        public static void ExtraerArchivosDeZIP(string Archivo, List<string> lstArchivos, string CarpetaDestino) {
            using (var archive = ZipArchive.Open(Archivo)) {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory)) {
                    if (lstArchivos.Any(str => str.Contains(entry.Key))) {
                        entry.WriteToDirectory(CarpetaDestino, new ExtractionOptions() {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    };
                }
            }
        }

        public static void ExtraerArchivosSeleccionados(string Archivo, string CarpetaDestino, List<string> lstArchivos) {

            switch (Archivo.GetFileExtension()) {
                case ".7z":
                    ExtraerArchivosDe7z(Archivo, lstArchivos, CarpetaDestino);
                    break;
                case ".cbr":
                case ".rar":
                    ExtraerArchivosDeRAR(Archivo, lstArchivos, CarpetaDestino);
                    break;
                case ".tar":
                case ".cbz":
                case ".zip":
                    ExtraerArchivosDeZIP(Archivo, lstArchivos, CarpetaDestino);
                    break;
            }
        }

        public static void ExtraerTodo7ZIP(string Archivo, string CarpetaDestino) {
            using (var archive = SevenZipArchive.Open(Archivo)) {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory)) {
                    entry.WriteToDirectory(CarpetaDestino, new ExtractionOptions() {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }

        public static void ExtraerTodoRAR(string Archivo, string CarpetaDestino) {
            using (var archive = RarArchive.Open(Archivo)) {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory)) {
                    entry.WriteToDirectory(CarpetaDestino, new ExtractionOptions() {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }

        public static void ExtraerTodoZIP(string Archivo, string CarpetaDestino) {
            using (var archive = ZipArchive.Open(Archivo)) {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory)) {
                    entry.WriteToDirectory(CarpetaDestino, new ExtractionOptions() {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }

        public static void ExtraerTodo(string Archivo, string CarpetaDestino) {

            var lxExt = Archivo.GetFileExtension();

            switch (lxExt) {
                case ".7z":
                    ExtraerTodo7ZIP(Archivo, CarpetaDestino);
                    break;
                case ".cbr":
                case ".rar":
                    ExtraerTodoRAR(Archivo, CarpetaDestino);
                    break;
                case ".tar":
                case ".cbz":
                case ".zip":
                    ExtraerTodoZIP(Archivo, CarpetaDestino);
                    break;
                default:
                    break;
            }
        }
    }
}
