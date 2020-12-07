using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visualizer.Classes
{
    public sealed class Block : Label
    {
        public Block(int x, int y)
        {
            Coord = new Coord(x, y);
            TextAlign = ContentAlignment.MiddleCenter;
        }

        public Coord Coord { get; set; }
        public BlockType Type { get; set; } = BlockType.Empty;
        public int Cost { get; set; }

        public void Draw()
        {
            Text = "";

            switch (Type)
            {
                case BlockType.Empty:
                    BackColor = Color.White;
                    break;
                case BlockType.Solid:
                    BackColor = Color.Black;  
                    break;
                case BlockType.Path:
                    BackColor = Color.Purple;
                    break;
                case BlockType.Open:
                    BackColor = Color.LightSkyBlue;
                    break;
                case BlockType.Closed:
                    BackColor = Color.LightSeaGreen;
                    break;
                case BlockType.A:
                    Text = "A";
                    BackColor = Color.Green;
                    break;
                case BlockType.B:
                    Text = "B";
                    BackColor = Color.Blue;
                    break;
                case BlockType.Invalid:
                    BackColor = Color.Red;
                    break;
                case BlockType.Current:
                    BackColor = Color.Crimson;
                    break;
                default:
                    throw new Exception($"Unexpected BlockType: '{Type}'");
            }
        }
    }
}
