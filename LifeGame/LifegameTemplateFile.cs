using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LifeGame
{
    public class LifegameTemplateFile
    {
        public TemplateFileMode ProcessFileMode { get; set; }
        public string FileName { get; set; }
        private bool[,] TempGrid { get; set; }
        public int GridHeight { get; set; }
        public int GridWidth { get; set; }
        private const int Header = 0x6C676365;
        public int Duration { get; set; }
        public LifegameTemplateFile(string FileName, TemplateFileMode templateFileMode)
        {
            ProcessFileMode = templateFileMode;
            this.FileName = FileName;
            if(templateFileMode == TemplateFileMode.OpenFile)
            {
                if (!File.Exists(FileName))
                    throw new FileNotFoundException("The requested File is not found.", FileName);
            }
        }
        public void SetGrid(bool[,] GridContent,int GridHeight,int GridWidth,int Duration)
        {
            TempGrid = GridContent;
            this.GridHeight = GridHeight;
            this.GridWidth = GridWidth;
            this.Duration = Duration;
        }
        public void Save()
        {
            int gridWidth_bytes = (GridWidth >> 3) + ((GridWidth & 7) != 0 ? 1 : 0);
            byte[] gridData = new byte[GridHeight * gridWidth_bytes];
            for(int i = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    int shift = j & 7;
                    int tempIndex = j >> 3;
                    gridData[i * gridWidth_bytes + tempIndex] |= (byte)((TempGrid[i, j] ? 1 : 0) << shift);
                }
            }
            int FileSize = 20 + gridData.Length;
            using(FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Header);
                bw.Write(FileSize);
                bw.Write(GridHeight);
                bw.Write(GridWidth);
                bw.Write(Duration);
                bw.Write(gridData);
            }
        }

        public bool[,] Open()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                int Header = br.ReadInt32();
                if (Header != LifegameTemplateFile.Header)
                    throw new Exception("Unsupport File. [0x01]");
                int FileSize = br.ReadInt32();
                if(FileSize != fs.Length)
                    throw new Exception("Unsupport File. [0x02]");
                this.GridHeight = br.ReadInt32();
                this.GridWidth = br.ReadInt32();
                this.Duration = br.ReadInt32();
                int gridWidth_bytes = (GridWidth >> 3) + ((GridWidth & 7) != 0 ? 1 : 0);
                byte[] gridData = br.ReadBytes(GridHeight * gridWidth_bytes);
                bool[,] outputData = new bool[this.GridHeight, this.GridWidth];
                for (int i = 0; i < GridHeight; i++)
                {
                    for (int j = 0; j < GridWidth; j++)
                    {
                        int shift = j & 7;
                        int tempIndex = j >> 3;
                        outputData[i, j] = ((gridData[i * gridWidth_bytes + tempIndex] >> shift) & 1) == 1;
                    }
                }
                return outputData;
            }
        }
    }
    public enum TemplateFileMode
    {
        OpenFile,SaveFile
    }
}
