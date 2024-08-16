using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Helpers
{
    public static class ColorsHelper
    {
        public static Dictionary<string, Color> GetLoudColors()
        {
            return new Dictionary<string, Color>
            {
                { "Cyan", Color.FromArgb(0, 255, 255) },
                { "Magenta", Color.FromArgb(255, 0, 255) },
                { "Lime", Color.FromArgb(0, 255, 0) },
                { "Yellow", Color.FromArgb(255, 255, 0) },
                { "Red", Color.FromArgb(255, 0, 0) },
                { "Green", Color.FromArgb(0, 128, 0) },
                { "Blue", Color.FromArgb(0, 0, 255) },
                { "Orange", Color.FromArgb(255, 165, 0) },
                { "Pink", Color.FromArgb(255, 192, 203) },
                { "Purple", Color.FromArgb(128, 0, 128) },
                { "Turquoise", Color.FromArgb(64, 224, 208) },
                { "Indigo", Color.FromArgb(75, 0, 130) },
                { "Gold", Color.FromArgb(255, 215, 0) },
                { "Silver", Color.FromArgb(192, 192, 192) },
                { "Teal", Color.FromArgb(0, 128, 128) },
                { "Coral", Color.FromArgb(255, 127, 80) },
                { "Salmon", Color.FromArgb(250, 128, 114) },
                { "Tomato", Color.FromArgb(255, 99, 71) },
                { "Violet", Color.FromArgb(238, 130, 238) },
                { "Chartreuse", Color.FromArgb(127, 255, 0) },
                { "Azure", Color.FromArgb(240, 255, 255) }
            };
        }
          // Función para obtener un color por su nombre
        public static Color GetColorByName(string colorName)
        {
            if (GetLoudColors().TryGetValue(colorName, out Color color))
            {
                return color;
            }
            else
            {
                throw new ArgumentException($"El color '{colorName}' no se encuentra en la lista.");
            }
        }
        public static List<string> GetColorNames()
        {
            var colors = GetLoudColors();
            return new List<string>(colors.Keys);
        }
        public static (int R, int G, int B) GetRGB(string colorName)
        {
            Color color = GetColorByName(colorName);
            return (color.R, color.G, color.B);
        }
    }

}
