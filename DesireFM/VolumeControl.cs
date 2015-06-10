using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DesireFM
{

    public class VolumeControl : Control
    {
        protected const int BordHeight = 2;

        public VolumeControl()
        {
            this.MinValue = 0;
            this.MaxValue = 100;
            this.Value = 0;
            this.Width = 200;
            this.Height = 10;
            this.DoubleBuffered = true;
        }

        private int minValue, maxValue, currValue;

        [ Description("最小值"),Category("值")]
        public int MinValue
        {
            get { return minValue; }
            set {
                if (value > MaxValue) return;
                minValue = value;
                this.Refresh();
            }
        }

        [Description("最大值"), Category("值")]
        public int MaxValue
        {
            get { return maxValue; }
            set 
            {
                if (value < MinValue) return;
                maxValue = value;
                this.Refresh();
            }
        }

        [Description("当前值"), Category("值")]
        public int Value
        {
            get { return currValue; }
            set 
            {
                int preValue = currValue;
                if (value > MaxValue) currValue = MaxValue;
                else if (value < MinValue) currValue = MinValue;
                else currValue = value;
                this.Refresh();
                if (preValue != currValue) OnScroll();
            }
        }

        private Color fillColor= Color.White;
        [Description("有值部分颜色"), Category("外观")]
        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        private Color emptyColor = Color.FromArgb(135, 124, 124);
        [Description("无值部分颜色"), Category("外观")]
        public Color EmptyColor
        {
            get { return emptyColor; }
            set { emptyColor = value; }
        }

        [Description("滑块形状"), Category("外观")]
        public TrackShape Shape { get; set; }

        protected float ValueX
        {
            get 
            {
                return (Value - MinValue) / (float)(MaxValue - MinValue) * BorderLength;
            }
        }

        protected int BorderLength
        {
            get
            {
                return this.Width - BordHeight*2;
            }
        }

        protected void DrawCircleTrack(Graphics g,SolidBrush brush)
        {
            using (Pen emptyPen = new Pen(EmptyColor))
            {
                g.FillEllipse(brush, ValueX, 2, 2 * BordHeight, 2 * BordHeight);
                g.DrawEllipse(emptyPen, ValueX, 2, 2 * BordHeight, 2 * BordHeight);
            }
        }

        protected void DrawRectangles(Graphics g,SolidBrush brush)
        {
            using (Pen emptyPen = new Pen(EmptyColor))
            {
                g.FillRectangle(brush, ValueX + BordHeight / 2, 2, BordHeight, 2 * BordHeight);
                g.DrawRectangle(emptyPen, ValueX + BordHeight / 2, 2, BordHeight, 2 * BordHeight);
            }
        }

        /// <summary>
        /// 通过鼠标当前位置计算出进度值
        /// </summary>
        /// <param name="x">鼠标当前位置</param>
        /// <returns></returns>
        protected int LocationX2Value(int x)
        {
            return (int)((MaxValue - MinValue) / (float)BorderLength * (x - BordHeight) + MinValue);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Bitmap bit=new Bitmap(this.Width,this.Height))
            {
                using (Graphics g=Graphics.FromImage(bit))
                {
                    using (SolidBrush emptyBrush=new SolidBrush(EmptyColor))
                    {
                        g.FillRectangle(emptyBrush, BordHeight, 2 + BordHeight / 2f, BorderLength, BordHeight);
                    }

                    using (SolidBrush valueBrush=new SolidBrush(FillColor))
                    {
                        g.FillRectangle(valueBrush, BordHeight+1f, 2 + BordHeight / 2f+1f, ValueX-2,BordHeight-2 );
                        switch (Shape)
                        {
                            case TrackShape.Circle: DrawCircleTrack(g, valueBrush); break;
                            case TrackShape.Rectanles: DrawRectangles(g, valueBrush); break;
                        }
                    }
                }
                e.Graphics.DrawImage(bit, 0, 0);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
            int tempValue = LocationX2Value(e.X);
            if (tempValue > MaxValue) Value = MaxValue;
            else if (tempValue < MinValue) Value = MinValue;
            else Value = tempValue;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
            int tempValue = LocationX2Value(e.X);
            if (tempValue > MaxValue) Value = MaxValue;
            else if (tempValue < MinValue) Value = MinValue;
            else Value = tempValue;
        }

        [Description("当值变化后触发的事件"), Category("值")]
        public event EventHandler Scroll = null;
        public virtual void OnScroll()
        {
            if (Scroll != null)
            {
                Scroll(this, new EventArgs());
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Refresh();
        }

        public enum TrackShape
        {
            Circle,
            Rectanles
        }
    }
}
