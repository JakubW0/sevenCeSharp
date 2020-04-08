using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

/*
 * 
 * Author: Jakub Wójcik
 * 
 */

namespace SevenSegment.CustomControls
{
   public class SevenSegment : UserControl
    {
        private int height = 80;
        private int width = 48;
        private int margin = 5;
        private Color background = Color.Black;
        private Color segmentON = Color.Red;
        private Color segmentOFF = Color.White;
        private Color segmentA = Color.Red;
        private Color segmentB = Color.Red;
        private Color segmentC = Color.Red;
        private Color segmentD = Color.Red;
        private Color segmentE = Color.Red;
        private Color segmentF = Color.Red;
        private Color segmentG = Color.Red;
        private Point[][] segmentPoint;
  //      private ushort zero = 0x3F;
  //      private ushort one = 0x6;
 //       private ushort two = 0x5B;
  //      private ushort three = 0x4F;
 //       private ushort four = 0x66;
  //      private ushort five = 0x6E;
 //       private ushort six = 0x7D;
  //      private ushort seven = 0x7;
  //      private ushort eight = 0x7F;
  //      private ushort nine = 0x6F;
        private int value=9;

        public SevenSegment()
        {
            SuspendLayout();
            Name = "SevenSegmentDisplay";
            Size = new Size(32,64);
            Paint += new PaintEventHandler(SevenSegment_Paint);
            Resize += new EventHandler(SevenSegment_Resize);
            ResumeLayout(false);

            TabStop = false;
            Padding = new Padding(4,4, 4, 4);
            DoubleBuffered = true;

            segmentPoint = new Point[7][];
            segmentPoint[0] = new Point[6];
            segmentPoint[1] = new Point[6];
            segmentPoint[2] = new Point[6];
            segmentPoint[3] = new Point[6];
            segmentPoint[4] = new Point[6];
            segmentPoint[5] = new Point[6];
            segmentPoint[6] = new Point[6];
            DrawSegment();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SevenSegment
            // 
            this.Name = "SevenSegment";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Drawing points.
        /// </summary>
        private void DrawSegment()
        {
            int halfHeight = height / 2;
            int halfMargin = margin / 2;

            //A
            segmentPoint[0][0].X = margin + 1;
            segmentPoint[0][0].Y = 0;
            segmentPoint[0][1].X = width - margin - 1;
            segmentPoint[0][1].Y = 0;
            segmentPoint[0][2].X = width - margin - 1;
            segmentPoint[0][2].Y = margin;
            segmentPoint[0][3].X = margin + 1;
            segmentPoint[0][3].Y = margin;
            segmentPoint[0][4].X = margin + 1;
            segmentPoint[0][4].Y = 0;

            //B
            segmentPoint[1][0].X = width - margin;
            segmentPoint[1][0].Y = margin + 1;
            segmentPoint[1][1].X = width;
            segmentPoint[1][1].Y = margin + 1;
            segmentPoint[1][2].X = width;
            segmentPoint[1][2].Y = halfHeight - 1;
            segmentPoint[1][3].X = width - margin;
            segmentPoint[1][3].Y = halfHeight - 1;
            segmentPoint[1][4].X = width - margin;
            segmentPoint[1][4].Y = margin + 1;

            //C
            segmentPoint[2][0].X = width - margin;
            segmentPoint[2][0].Y = halfHeight + 1;
            segmentPoint[2][1].X = width;
            segmentPoint[2][1].Y = halfHeight + 1;
            segmentPoint[2][2].X = width;
            segmentPoint[2][2].Y = height - margin - 1;
            segmentPoint[2][3].X = width - margin;
            segmentPoint[2][3].Y = height - margin - 1;
            segmentPoint[2][4].X = width - margin;
            segmentPoint[2][4].Y = halfHeight + 1;

            // D
            segmentPoint[3][0].X = margin + 1;
            segmentPoint[3][0].Y = height - margin;
            segmentPoint[3][1].X = width - margin - 1;
            segmentPoint[3][1].Y = height - margin;
            segmentPoint[3][2].X = width - margin - 1;
            segmentPoint[3][2].Y = height;
            segmentPoint[3][3].X = margin + 1;
            segmentPoint[3][3].Y = height;
            segmentPoint[3][4].X = margin + 1;
            segmentPoint[3][4].Y = height - margin;

            //E
            segmentPoint[4][0].X = 0;
            segmentPoint[4][0].Y = halfHeight + 1;
            segmentPoint[4][1].X = margin;
            segmentPoint[4][1].Y = halfHeight + 1;
            segmentPoint[4][2].X = margin;
            segmentPoint[4][2].Y = height - margin - 1;
            segmentPoint[4][3].X = 0;
            segmentPoint[4][3].Y = height - margin - 1;
            segmentPoint[4][4].X = 0;
            segmentPoint[4][4].Y = halfHeight + 1;

            //F
            segmentPoint[5][0].X = 0;
            segmentPoint[5][0].Y = margin + 1;
            segmentPoint[5][1].X = margin;
            segmentPoint[5][1].Y = margin + 1;
            segmentPoint[5][2].X = margin;
            segmentPoint[5][2].Y = halfHeight - halfMargin - 1;
            segmentPoint[5][3].X = 0;
            segmentPoint[5][3].Y = halfHeight - 1;
            segmentPoint[5][4].X = 0;
            segmentPoint[5][4].Y = margin + 1;

            // G 
            segmentPoint[6][0].X = margin + 1;
            segmentPoint[6][0].Y = halfHeight - halfMargin;
            segmentPoint[6][1].X = width - margin - 1;
            segmentPoint[6][1].Y = halfHeight - halfMargin;
            segmentPoint[6][2].X = width - margin - 1;
            segmentPoint[6][2].Y = halfHeight + halfMargin;
            segmentPoint[6][3].X = margin + 1;
            segmentPoint[6][3].Y = halfHeight + halfMargin;
            segmentPoint[6][4].X = margin + 1;
            segmentPoint[6][4].Y = halfHeight - halfMargin;

        }
        /// <summary>
        /// Switch points
        /// </summary>
        public int Value
        {

            get { return value; }
            set
            {
                this.value = value;
                if (value > 0 && value < 10)
                {
                    if ((value & 0x1) == 0x1)
                    {
                        segmentA = segmentON;
                    }
                    else
                    {
                        segmentA = segmentOFF;
                    }

                    if ((value & 0x2) == 0x2)
                    {
                        segmentB = segmentON;
                    }
                    else
                    {
                        segmentB = segmentOFF;
                    }

                    if ((value & 0x4) == 0x4)
                    {
                        segmentC = segmentON;
                    }
                    else
                    {
                        segmentC = segmentOFF;
                    }

                    if ((value & 0x8) == 0x8)
                    {
                        segmentD = segmentON;
                    }
                    else
                    {
                        segmentD = segmentOFF;
                    }

                    if ((value & 0x10) == 0x10)
                    {
                        segmentE = segmentON;
                    }
                    else
                    {
                        segmentE = segmentOFF;
                    }

                    if ((value & 0x20) == 0x20)
                    {
                        segmentF = segmentON;
                    }
                    else
                    {
                        segmentF = segmentOFF;
                    }

                    if ((value & 0x40) == 0x40)
                    {
                        segmentG = segmentON;
                    }
                    else
                    {
                        segmentG = segmentOFF;
                    }


                }


            }
        }

        public int Margin
        {
            get { return margin; }
            set { margin = value; Invalidate(); }
        }
        /// <summary>
        /// Color Background 
        /// </summary>
        public Color Background
        {
            get { return background; }
            set { background = value; Invalidate(); }
        }
        /// <summary>
        /// Switch On segment
        /// </summary>
        public Color SegmentON
        {
            get { return segmentON; }
            set { segmentON = value; Invalidate(); }
        }
        /// <summary>
        /// Switch OFF segment
        /// </summary>
        public Color SegmentOFF
        {
            get { return segmentOFF; }
            set { segmentOFF = value; Invalidate(); }
        }
        private void SevenSegment_Resize(object sender, EventArgs e) { Invalidate(); }
        protected override void OnPaddingChanged(EventArgs e) { base.OnPaddingChanged(e); Invalidate(); }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            e.Graphics.Clear(background);

        }

        private void SevenSegment_Paint(object sender, PaintEventArgs e)
        {
            // Define transformation for our container...
            RectangleF srcRect;
            srcRect = new RectangleF(0.0F, 0.0F, width, height);
            RectangleF destRect = new RectangleF(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);

            // Begin graphics container that remaps coordinates for our convenience
            GraphicsContainer containerState = e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel);
       
            // Draw elements based on whether the corresponding bit is high
            Brush a = new SolidBrush(segmentA);
            Brush b = new SolidBrush(segmentB);
            Brush c = new SolidBrush(segmentC);
            Brush d = new SolidBrush(segmentD);
            Brush ee = new SolidBrush(segmentE);
            Brush f = new SolidBrush(segmentF);
            Brush g = new SolidBrush(segmentG);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;

            e.Graphics.FillPolygon(a, segmentPoint[0]);
            e.Graphics.FillPolygon(b, segmentPoint[1]);
            e.Graphics.FillPolygon(c, segmentPoint[2]);
            e.Graphics.FillPolygon(d, segmentPoint[3]);
            e.Graphics.FillPolygon(ee, segmentPoint[4]);
            e.Graphics.FillPolygon(f, segmentPoint[5]);
            e.Graphics.FillPolygon(g, segmentPoint[6]);

            e.Graphics.EndContainer(containerState);
        }

    }
}
