using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public enum ColorEnum
    {
        // Summary:
        //     The color black.
        Black = 0,
        //
        // Summary:
        //     The color dark blue.
        DarkBlue = 1,
        //
        // Summary:
        //     The color dark green.
        DarkGreen = 2,
        //
        // Summary:
        //     The color dark cyan (dark blue-green).
        DarkCyan = 3,
        //
        // Summary:
        //     The color dark red.
        DarkRed = 4,
        //
        // Summary:
        //     The color dark magenta (dark purplish-red).
        DarkMagenta = 5,
        //
        // Summary:
        //     The color dark yellow (ochre).
        DarkYellow = 6,
        //
        // Summary:
        //     The color gray.
        Gray = 7,
        //
        // Summary:
        //     The color dark gray.
        DarkGray = 8,
        //
        // Summary:
        //     The color blue.
        Blue = 9,
        //
        // Summary:
        //     The color green.
        Green = 10,
        //
        // Summary:
        //     The color cyan (blue-green).
        Cyan = 11,
        //
        // Summary:
        //     The color red.
        Red = 12,
        //
        // Summary:
        //     The color magenta (purplish-red).
        Magenta = 13,
        //
        // Summary:
        //     The color yellow.
        Yellow = 14,
        //
        // Summary:
        //     The color white.
        White = 15,

        LightBlue,
        LightGreen,
        LightCyan,
        LightRed,
        LightMagenta,
        LightYellow,
        LightGray

    }
    public class ConsoleRGB
    {
        public static ConsoleRGB White = new ConsoleRGB()
        {
            R = 255,
            G = 255,
            B = 255,
            ColorEnum = ColorEnum.White,
        };
        public static ConsoleRGB Black = new ConsoleRGB()
        {
            R = 0,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.Black,
        };
        public static ConsoleRGB Gray = new ConsoleRGB()
        {
            R = 127,
            G = 127,
            B = 127,
            ColorEnum = ColorEnum.Gray,
        };
        public static ConsoleRGB DarkGray = new ConsoleRGB()
        {
            R = 95,
            G = 95,
            B = 95,
            ColorEnum = ColorEnum.DarkGray,
        };
        public static ConsoleRGB LightGray = new ConsoleRGB()
        {
            R = 250,
            G = 250,
            B = 250,
            //R = 95,
            //G = 95,
            //B = 95,
            ColorEnum = ColorEnum.LightGray,
        };
        public static ConsoleRGB Red = new ConsoleRGB()
        {
            R = 255,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.Red,
        };
        public static ConsoleRGB DarkRed = new ConsoleRGB()
        {
            R = 191,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.DarkRed,
        };

        public static ConsoleRGB Blue = new ConsoleRGB()
        {
            R = 0,
            G = 0,
            B = 255,
            ColorEnum = ColorEnum.Blue,
        };

        public static ConsoleRGB Yellow = new ConsoleRGB()
        {
            R = 255,
            G = 255,
            B = 0,
            ColorEnum = ColorEnum.Yellow,
        };

        public static ConsoleRGB Transparent = new ConsoleRGB()
        {
            R = 255,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.Red,
        };

        public static ConsoleRGB Space = new ConsoleRGB()
        {
            R = 0,
            G = 15,
            B = 19,
        };


        // solorized
        public static ConsoleRGB Base03 = new ConsoleRGB()
        {
            R = 0,
            G = 43,
            B = 54,
        };

        public static ConsoleRGB Base02 = new ConsoleRGB()
        {
            R = 7,
            G = 54,
            B = 66,
        };

        public static ConsoleRGB Base01 = new ConsoleRGB()
        {
            R = 88,
            G = 110,
            B = 117,
        };

        public static ConsoleRGB Base00 = new ConsoleRGB()
        {
            R = 101,
            G = 123,
            B = 131,
        };

        public static ConsoleRGB Base0 = new ConsoleRGB()
        {
            R = 131,
            G = 148,
            B = 150,
        };

        public static ConsoleRGB Base1 = new ConsoleRGB()
        {
            R = 147,
            G = 161,
            B = 161,
        };

        public static ConsoleRGB Base2 = new ConsoleRGB()
        {
            R = 238,
            G = 232,
            B = 213,
        };


        public static ConsoleRGB Base3 = new ConsoleRGB()
        {
            R = 253,
            G = 246,
            B = 227,
        };


        public static ConsoleRGB S_Yellow = new ConsoleRGB()
        {
            R = 181,
            G = 137,
            B = 0,
        };

        /*
        SOLARIZED HEX     16/8 TERMCOL  XTERM/HEX   L*A*B      RGB         HSB
        --------- ------- ---- -------  ----------- ---------- ----------- -----------
        yellow    #b58900  3/3 yellow   136 #af8700 60  10  65 181 137   0  45 100  71
        orange    #cb4b16  9/3 brred    166 #d75f00 50  50  55 203  75  22  18  89  80
        red       #dc322f  1/1 red      160 #d70000 50  65  45 220  50  47   1  79  86
        magenta   #d33682  5/5 magenta  125 #af005f 50  65 -05 211  54 130 331  74  83
        violet    #6c71c4 13/5 brmagenta 61 #5f5faf 50  15 -45 108 113 196 237  45  77
        blue      #268bd2  4/4 blue      33 #0087ff 55 -10 -45  38 139 210 205  82  82
        cyan      #2aa198  6/6 cyan      37 #00afaf 60 -35 -05  42 161 152 175  74  63
        green     #859900  2/2 green     64 #5f8700 60 -20  65 133 153   0  68 100  60
        base03    #002b36  8/4 brblack  234 #1c1c1c 15 -12 -12   0  43  54 193 100  21
        base02    #073642  0/4 black    235 #262626 20 -12 -12   7  54  66 192  90  26
        base01    #586e75 10/7 brgreen  240 #585858 45 -07 -07  88 110 117 194  25  46
        base00    #657b83 11/7 bryellow 241 #626262 50 -07 -07 101 123 131 195  23  51
        base0     #839496 12/6 brblue   244 #808080 60 -06 -03 131 148 150 186  13  59
        base1     #93a1a1 14/4 brcyan   245 #8a8a8a 65 -05 -02 147 161 161 180   9  63
        base2     #eee8d5  7/7 white    254 #e4e4e4 92 -00  10 238 232 213  44  11  93
        base3     #fdf6e3 15/7 brwhite  230 #ffffd7 97  00  10 253 246 227  44  10  99          
        */


        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        ColorEnum? colorEnum = null;

        public ColorEnum? GetColorEnum() { return colorEnum; }

        public ColorEnum ColorEnum { set { colorEnum = (ColorEnum)value; } }

    }
}
