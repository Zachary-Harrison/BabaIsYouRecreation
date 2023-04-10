﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBlue
{
    public class Level
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // The following definitions depend on if you want to parse out the levels into char[] immediately from the file or do it in the WorldCreator
        // List<char[]> could also just be a char[,] (2D char array)
        //public List<char[]> layout1;
        //public List<char[]> layout2;
        //
        //OR
        //
        //public string layout1;
        //public string layout2;

        public Level(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }

    }
}
