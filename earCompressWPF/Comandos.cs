using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace earCompressWPF.Comandos {
    public class Comandos {

        public static readonly RoutedUICommand AbrirArchivo = new RoutedUICommand(
                 "Abrir archivo a descomprimir",
                 "cmdAbrirArchivo",
                 typeof(Comandos),
                 new InputGestureCollection() {
                        new KeyGesture(Key.O,  ModifierKeys.Control)
                 });

        public static readonly RoutedUICommand SeleccionarCarpetaDestino = new RoutedUICommand(
                 "Seleccionar Carpeta Destino",
                 "cmdSeleccionarCarpetaDestino",
                 typeof(Comandos),
                 new InputGestureCollection() {
                        new KeyGesture(Key.D,  ModifierKeys.Control)
                 });

        public static readonly RoutedUICommand ExtraerSeleccionados = new RoutedUICommand(
                 "Extraer archivos selecionados",
                 "cmdExtraerSeleccionados",
                 typeof(Comandos),
                 new InputGestureCollection() {
                        new KeyGesture(Key.S,  ModifierKeys.Control)
                 });

        public static readonly RoutedUICommand ExtraerTodos = new RoutedUICommand(
                 "Extraer todos archivos",
                 "cmdExtraerTodos",
                 typeof(Comandos),
                 new InputGestureCollection() {
                        new KeyGesture(Key.X,  ModifierKeys.Control)
                 });

    }
}
