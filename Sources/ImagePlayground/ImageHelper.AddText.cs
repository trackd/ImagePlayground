using System.IO;
using SixLabors.ImageSharp;

namespace ImagePlayground {
    public partial class ImageHelper {
        public static void AddText(string filePath, string outFilePath, float x, float y, string text, Color color, float fontSize = 16f, string fontFamilyName = "Arial", Color? shadowColor = null, float shadowOffsetX = 0f, float shadowOffsetY = 0f, Color? outlineColor = null, float outlineWidth = 0f) {
            string fullPath = Helpers.ResolvePath(filePath);
            string outFullPath = Helpers.ResolvePath(outFilePath);

            using var img = Image.Load(fullPath);
            img.AddText(x, y, text, color, fontSize, fontFamilyName, shadowColor, shadowOffsetX, shadowOffsetY, outlineColor, outlineWidth);
            img.Save(outFullPath);
        }
    }
}
