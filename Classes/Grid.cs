using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizer.Classes
{
    public class Grid
    {
        public Grid() { }

        public List<Block> Blocks { get; } = new List<Block>();

        public void Reset()
        {
            foreach(var block in Blocks)
            {
                block.Type = BlockType.Empty;
                block.Draw();
            }        
        }

        public void CleanToRun(Coord coordA, Coord coordB)
        {
            var wallsCoords = new List<Coord>();

            for (int i = 0; i < Blocks.Count; i++)
            {
                var block = Blocks[i];

                if (block.Type == BlockType.Solid)
                    wallsCoords.Add(block.Coord);
            }

            Reset();

            SetBlock(coordA, BlockType.A);
            SetBlock(coordB, BlockType.B);

            foreach (var coord in wallsCoords)
                SetBlock(coord, BlockType.Solid);
        }
        
        public Block GetBlock(int x, int y)
        {
            foreach (var block in Blocks)
                if (block.Coord.X == x && block.Coord.Y == y)
                    return block;

            return new Block(-1, -1)
            {
                Type = BlockType.Invalid,
            };
        }

        public Block GetStart()
        {
            return Blocks.Cast<Block>().FirstOrDefault(block => block.Type == BlockType.A);
        }

        public Block GetEnd()
        {
            return Blocks.Cast<Block>().FirstOrDefault(block => block.Type == BlockType.B);
        }

        public void SetBlock(int x, int y, BlockType type)
        {
            var block = GetBlock(x, y);
            var index = Blocks.IndexOf(block);

            Blocks[index].Type = type;
            Blocks[index].Draw();
        }

        public void SetBlock(Coord coord, BlockType type)
        {
            SetBlock(coord.X, coord.Y, type);
        }

        public int GetCountOfType(BlockType type)
        {
            var total = 0;

            foreach (var block in Blocks)
                total += block.Type == type ? 1 : 0;

            return total;
        }

        public int GetTraversableCells()
        {
            return GetCountOfType(BlockType.Open) + 
                GetCountOfType(BlockType.A) + 
                GetCountOfType(BlockType.B);
        }

        public bool HaveFreeBlock()
        {
            return GetCountOfType(BlockType.Empty) > 0;
        }
    }
}
