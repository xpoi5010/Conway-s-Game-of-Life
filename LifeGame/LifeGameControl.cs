using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace LifeGame
{
    public enum GameStatus
    {
        Running,Stopped,AllDie, Stable
    }
    public partial class LifeGameControl : UserControl
    {
        public int GridWidth { get; private set; } = 2;

        public int GridHeight { get; private set; } = 2;

        public GameStatus NowStatus { get; set; } = GameStatus.Stopped;

        private bool[,] Status = new bool[2, 2];

        public bool[,] CurrentGrid => Status;

        public int Duration { get; set; } = 1300;

        public Task BackgroundWorker;

        public int Period { get; set; } = 0;

        public int CellCount { get; set; } = 0;
        public delegate void GameStoppedHandle(GameStatus NewStatus);
        public event GameStoppedHandle Stopped;
        private int offsetX = 0;
        private int offsetY = 0;
        private string outputString = "";

        public LifeGameControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void SetGrid(int Width,int Height)
        {
            int CopyWidth = GridWidth > Width ? Width : GridWidth;
            int CopyHeight = GridHeight > Height ? Height : GridHeight;
            this.GridHeight = Height;
            this.GridWidth = Width;
            bool[,] OriginalArr = Status;
            Status = new bool[Height, Width];
            NowStatus = GameStatus.Stopped;
            Period = 0;
            CellCount = 0;
            offsetX = 0;
            offsetY = 0;
            for (int i = 0; i < CopyHeight; i++)
            {
                for (int j = 0; j < CopyWidth; j++)
                {
                    Status[i, j] = OriginalArr[i, j];
                    if (Status[i, j])
                        CellCount++;
                }
            }
            this.Refresh();
        }

        public void SetGrid(bool[,] Grid,int Width, int Height)
        {
            this.GridHeight = Height;
            this.GridWidth = Width;
            if (Grid.GetLength(0) != this.GridHeight || Grid.GetLength(1) != this.GridWidth)
                throw new Exception("Error! the grid is not compatible to the Width of Grid and the Height of Grid.");
            Status = Grid;
            NowStatus = GameStatus.Stopped;
            Period = 0;
            CellCount = 0;
            offsetX = 0;
            offsetY = 0;
            for(int i =0;i< GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    if (Status[i, j])
                        CellCount++;
                }
            }
            this.Refresh();
        }

        private void LifeGameControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.None;
            Rectangle bg = new Rectangle();
            bg.X = -offsetX;
            bg.Y = 16 - offsetY;
            bg.Width = 5 + 25 * GridWidth;
            bg.Height = 5 + 25 * GridHeight;
            graphics.FillRectangle(Brushes.LightGray, bg);
            for(int i =0;i< GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.X = 5 + 25 * j - offsetX;
                    rect.Y = 21 + 25 * i - offsetY;
                    rect.Width = 20;
                    rect.Height = 20;
                    graphics.FillRectangle(Status[i,j] ? Brushes.Black : Brushes.White, rect);
                }
            }
            switch (NowStatus)
            {
                case GameStatus.Running:
                    outputString = $"Running. Current life cell count: {CellCount}, Life game period: {Period}";
                    break;
                case GameStatus.AllDie:
                    outputString = $"All Cells died, Finial Life game period: {Period}";
                    break;
                case GameStatus.Stopped:
                    outputString = $"Stopped. Current life cell count: {CellCount}, Life game period: {Period}";
                    break;
                case GameStatus.Stable:
                    outputString = $"All Cells are in stable state when period {Period}. Current life cell count: {CellCount}.";
                    break;
            }
            graphics.DrawString(outputString, this.Font, Brushes.Black, new PointF(3.0f,3.0f));
        }

        public void UpdateWork() 
        {
            DateTime dta = DateTime.Now;
            TimeSpan ts = DateTime.Now - dta;
            while (NowStatus == GameStatus.Running)
            {
                Period++;
                if(Period >= 2)
                    UpdateGrid();
                this.Invoke(new Action(() =>
                {
                    this.Refresh();
                }));
                while(ts.TotalMilliseconds < Duration && NowStatus == GameStatus.Running)
                {
                    Task.Delay(5).Wait();
                    ts = DateTime.Now - dta;
                }
                dta = DateTime.Now;
                ts = DateTime.Now - dta;
            }
            this.Invoke(new Action(() =>
            {
               Stopped?.Invoke(NowStatus);
                this.Refresh();
            }));
        }

        public void Start()
        {
            NowStatus = GameStatus.Running;
            Period = 0;
            BackgroundWorker = new Task(UpdateWork);
            BackgroundWorker.Start();
        }
        private int StartMoveX = 0;
        private int StartMoveY = 0;
        private int originalOffsetX = 0;
        private int originalOffsetY = 0;
        private bool startMoveMode = false;
        public void Stop()
        {
            NowStatus = GameStatus.Stopped;
        }
        private void LifeGameControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                StartMoveX = e.X;
                StartMoveY = e.Y;
                originalOffsetX = offsetX;
                originalOffsetY = offsetY;
                startMoveMode = true;
                this.Cursor = Cursors.Hand;
                return;
            }
            if (NowStatus == GameStatus.Running)
                return;
            int Ox = (e.X + offsetX) - 5;
            int Oy = (e.Y + offsetY) - 21;
            int Sx = Ox % 25;
            int Sy = Oy % 25;
            int Mx = Ox / 25;
            int My = Oy / 25;
            if (Oy < 0 || Ox < 0 || Sx >=20 || Sy >= 20 || Mx >=GridWidth || My >= GridHeight)
                return;
            if (NowStatus != GameStatus.Stopped)
            {
                NowStatus = GameStatus.Stopped;
                Period = 0;
            }
            Status[My, Mx] ^= true;
            CellCount++;
            this.Refresh();
        }

        private void UpdateGrid()
        {
            bool[,] NewGrid = new bool[GridHeight,GridWidth];
            bool IsAllCellDie = true;
            bool IsStableState = true;
            CellCount = 0;
            for (int i = 0; i < GridHeight; i++)
            {
                for(int j = 0; j < GridWidth; j++)
                {
                    int Neighborhood = 0;
                    for(int di = -1; di <= 1; di++)
                    {
                        int ni = i + di;
                        if (ni < 0 || ni >= GridHeight)
                            continue;
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            int nj = j + dj;
                            if (nj < 0 || nj >= GridWidth || (di == dj && di == 0))
                                continue;
                            if (Status[ni, nj])
                                Neighborhood++;
                        }
                    }
                    if(Status[i, j])
                    {
                        IsAllCellDie = false;
                        if (Neighborhood == 2 || Neighborhood == 3)
                            NewGrid[i, j] = true;
                        else
                            NewGrid[i, j] = false;
                    }
                    else
                    {
                        if (Neighborhood ==3)
                            NewGrid[i, j] = true;
                        else
                            NewGrid[i, j] = false;
                    }
                    if (NewGrid[i, j])
                        CellCount++;
                    if (NewGrid[i, j] != Status[i, j])
                        IsStableState = false;
                }
            }
            if (IsAllCellDie)
            {
                NowStatus = GameStatus.AllDie;
                Period--;
            }
            else if (IsStableState)
            {
                NowStatus = GameStatus.Stable;
                Period--;
            }
            Status = NewGrid;
        }

        public bool IsEmpty()
        {
            return CellCount == 0;
            /*
            for(int i = 0; i < GridHeight; i++)
            {
                for(int j = 0; j < GridWidth; j++)
                {
                    if (Status[i, j])
                        return false;
                }
            }
            return true;
            */
        }

        public void Clear()
        {
            if (NowStatus == GameStatus.Running)
                return;
            Status = new bool[Height, Width];
            NowStatus = GameStatus.Stopped;
            Period = 0;
            CellCount = 0;
            this.Refresh();
        }

        private void SaveToComputerWork()
        {

        }

        private void LifeGameControl_Resize(object sender, EventArgs e)
        {
            int ViewportWidth = 5 + 25 * GridWidth;
            int ViewportHeight = 21 + 25 * GridHeight;
            int moveRangeX = ViewportWidth - this.Width;
            int moveRangeY = ViewportHeight - this.Height;
            if (offsetX > moveRangeX && moveRangeX > 0)
                offsetX = moveRangeX;
            if (offsetY > moveRangeY && moveRangeY > 0)
                offsetY = moveRangeY;
            if (offsetX < 0 || moveRangeX < 0)
                offsetX = 0;
            if (offsetY < 0 || moveRangeY < 0)
                offsetY = 0;
            this.Refresh();
        }

        private void LifeGameControl_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void LifeGameControl_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                startMoveMode = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void LifeGameControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (startMoveMode)
            {
                offsetX = originalOffsetX - (e.X - StartMoveX);
                offsetY = originalOffsetY - (e.Y - StartMoveY);
                int ViewportWidth = 5 + 25 * GridWidth;
                int ViewportHeight = 21 + 25 * GridHeight;
                int moveRangeX = ViewportWidth - this.Width;
                int moveRangeY = ViewportHeight - this.Height;
                if (offsetX > moveRangeX && moveRangeX >0)
                    offsetX = moveRangeX;
                if (offsetY > moveRangeY && moveRangeY > 0)
                    offsetY = moveRangeY;
                if (offsetX < 0 || moveRangeX < 0)
                    offsetX = 0;
                if (offsetY < 0 || moveRangeY < 0)
                    offsetY = 0;
                this.Refresh();
            }
        }
    }
}
