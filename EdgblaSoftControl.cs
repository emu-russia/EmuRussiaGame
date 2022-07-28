// Кастомный контрол для игры в edgbla.

namespace EmuRussiaGame
{
    public partial class EdgblaSoftControl : Control
    {
        private BufferedGraphics gfx = null;
        private BufferedGraphicsContext context;

        List<VajnoeDelo> dela = new List<VajnoeDelo>();
        Edgbla edgbla = null;

        int moveDelta = 15;

        int tickCounter = 0;
        int lastDeloTick = 0;
        int delNeSdelano = 0;

        public EdgblaSoftControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void ReallocateGraphics()
        {
            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(Width + 1, Height + 1);

            gfx = context.Allocate(CreateGraphics(),
                 new Rectangle(0, 0, Width, Height));
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (gfx != null)
            {
                gfx.Dispose();
                ReallocateGraphics();
            }

            Invalidate();
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (gfx == null)
            {
                ReallocateGraphics();
            }

            long beginTime = DateTime.Now.Ticks;

            DrawScene(gfx.Graphics, Width, Height);

            gfx.Render(e.Graphics);

            long endTime = DateTime.Now.Ticks;
        }

        private void DrawScene(Graphics gr, int width, int height)
        {
            gr.Clear(BackColor);

            DrawEdgbla(gr);
            DrawDela(gr);
            DrawCounter(gr);
        }

        private void DrawDela(Graphics gr)
        {
            foreach (var delo in dela)
            {
                gr.DrawImage(delo.image, delo.pos);
            }
        }

        private void DrawEdgbla(Graphics gr)
        {
            if (edgbla != null)
            {
                gr.DrawImage(edgbla.image, edgbla.pos);
            }
        }

        private void DrawCounter(Graphics gr)
        {
            gr.DrawString("Дел не сделано: " + delNeSdelano.ToString(), Font, new SolidBrush(Color.Orange), new Point(0, 0));
        }

        internal class VajnoeDelo
        {
            public Image image;
            public Point pos;
        }

        internal class Edgbla
        {
            public Image image;
            public Point pos;
        }

        public void MoveEdgblaLeft()
        {
            edgbla.pos.X -= moveDelta;
        }

        public void MoveEdgblaRight()
        {
            edgbla.pos.X += moveDelta;
        }

        public bool IsCollided()
        {
            foreach (var delo in dela)
            {
                https://stackoverflow.com/questions/35349506/how-could-be-done-algorithm-for-rectangle-collisions-in-c-sharp

                Rectangle rect1 = new Rectangle(edgbla.pos.X, edgbla.pos.Y, edgbla.image.Width, edgbla.image.Height);
                Rectangle rect2 = new Rectangle(delo.pos.X, delo.pos.Y, delo.image.Width, delo.image.Height);

                bool intersects = rect1.IntersectsWith(rect2);

                if (intersects)
                    return true;
            }

            return false;
        }

        public void SpawnEdgbla()
        {
            // Разместить edgbla внизу экрана

            edgbla = new Edgbla();

            edgbla.image = Properties.Resources.edgbla;
            edgbla.pos = new Point(Width / 2 - edgbla.image.Width / 2, Height - edgbla.image.Height - 16);
        }

        /// <summary>
        /// Запустить важное дело.
        /// </summary>
        public void SpawnDelo()
        {
            VajnoeDelo delo = new VajnoeDelo();

            Random rd = new Random();

            int rand_pic = rd.Next(1, 5);
            switch (rand_pic)
            {
                case 1:
                    delo.image = Properties.Resources.edgbla_gpu;
                    break;
                case 2:
                    delo.image = Properties.Resources.edgbla_emu;
                    break;
                case 3:
                    delo.image = Properties.Resources.edgbla_cd;
                    break;
                case 4:
                    delo.image = Properties.Resources.edgbla_pad;
                    break;
                case 5:
                    delo.image = Properties.Resources.edgbla_sio;
                    break;
            }

            int rand_pos = rd.Next(10, Width);
            delo.pos = new Point(rand_pos, 0);

            dela.Add(delo);
            lastDeloTick = tickCounter;
        }

        public void TickGame()
        {
            if (dela.Count < 10 && (tickCounter - lastDeloTick) > 32)
            {
                SpawnDelo();
            }

            List<VajnoeDelo> delaNeSdelani = new List<VajnoeDelo>();

            foreach (var delo in dela)
            {
                delo.pos.Y++;

                if (delo.pos.Y > Height)
                {
                    delaNeSdelani.Add(delo);
                }
            }

            if (delaNeSdelani.Count != 0)
            {
                delNeSdelano += delaNeSdelani.Count;
                dela = dela.Except(delaNeSdelani).ToList();
            }

            tickCounter++;
        }
    }
}
