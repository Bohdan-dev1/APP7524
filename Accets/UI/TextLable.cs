using App75241305.Engine;
using Silk.NET.Maths;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace App75241305.Accets.UI
{
    internal unsafe class TextLable : Engine.Engine
    {
        private Vector4D<ushort> color;
        private Brush brush;
        private Vector4D<ushort> BGcolor;
        private String PathFonts = ".\\Assets\\Textures\\fonts\\";
        private String ExtendFile = ".ttf";
        private PrivateFontCollection fontCollection = new PrivateFontCollection();
        private FontFamily fontFamily;
        private Font font; 
        private FontStyle fontStyle;
        private int textureWidth;
        private int textureHeight;
        private Bitmap RenderedTexture;
        private byte[] Texture;


        public TextLable(Engine.Engine engine, Vector4D<ushort> color, Vector4D<ushort> BGcolor, string text, int size = 24, string type = "Regular", string NameFont = "Roboto-", bool SaveCopyFile = false)
        {
            fontCollection.AddFontFile(PathFonts + NameFont + type + ExtendFile);
            fontFamily = fontCollection.Families[0];
            brush = new SolidBrush(Color.FromArgb(color.W, color.X, color.Y, color.Z));

            switch (type)
            {
                case "Regular":
                    fontStyle = FontStyle.Regular;
                    break;
            }

            font = new Font(fontFamily, size, fontStyle, GraphicsUnit.Pixel);

            try
            {
                using (Bitmap tempBitmap = new Bitmap(1, 1))
                {
                    using (Graphics graphics = Graphics.FromImage(tempBitmap))
                    {
                        SizeF textSize = graphics.MeasureString(text, font);

                        textureWidth = (int)Math.Ceiling(textSize.Width);
                        textureHeight = (int)Math.Ceiling(textSize.Height);

                        Console.WriteLine("Texture Width: " + textureWidth);
                        Console.WriteLine("Texture Height: " + textureHeight);
                    }

                    using (RenderedTexture = new Bitmap(textureWidth, textureHeight))
                    {
                        using (Graphics graphics = Graphics.FromImage(RenderedTexture))
                        {
                            graphics.Clear(Color.FromArgb(BGcolor.W, BGcolor.X, BGcolor.Y, BGcolor.Z));
                            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                            graphics.DrawString(text, font, brush, PointF.Empty);
                        }

                        MemoryStream memoryStream = new MemoryStream();
                        RenderedTexture.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        engine.AddTexture(memoryStream.ToArray());
                        memoryStream.Close();
                        if (SaveCopyFile) RenderedTexture.Save("rendered_text_texture_debug.png", ImageFormat.Png);
                    } 
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error rendering text to texture: " + ex.Message);
            }




        }

        
    }
}
