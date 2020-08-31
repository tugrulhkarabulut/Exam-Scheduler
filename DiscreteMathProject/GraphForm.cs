using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscreteMathProject
{
    public partial class GraphForm : Form
    {
        public DataSource DataSource;
        public Graph CourseGraph;
        public int[] CourseColors;
        public int[] UniqueColors;
        public Color[] UniqueRGBColors;
        public DataTable AdjacencyTable;
        public Point[] NodeCoordinates;
        private bool[,] PaintedEdges;

        public GraphForm()
        {
            InitializeComponent();
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {
            DataSource = new DataSource();
            DataSource.ReadCourses();

            CourseGraph = new Graph(DataSource.Courses);
            CourseColors = CourseGraph.GetColors();
            UniqueColors = GetUniqueColors(CourseColors);
            UniqueRGBColors = GenerateColors(UniqueColors.Length);

            GenerateAdjacencyTable();

            totalCourse.Text = $"{CourseGraph.CourseNames.Length}";
            resultText.Text = $"Verilen derslerin sınavları en az {UniqueColors.Length} farklı saatte/oturumda yapılmalıdır";
        }

        private int[] GetUniqueColors(int[] colorArr)
        {
            Dictionary<int, bool> colorsDict = new Dictionary<int, bool>();

            foreach (int color in colorArr)
            {
                if (!colorsDict.ContainsKey(color))
                {
                    colorsDict.Add(color, true);
                }
            }

            return colorsDict.Keys.ToArray();
        }

        private Color[] GenerateColors(int numUniqueColors)
        {
            Random random = new Random();
            Color[] colors = new Color[numUniqueColors];
            for (int i = 0; i < numUniqueColors; i++)
            {
                Color RGBColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                colors[i] = RGBColor;
            }
            return colors;
        }

        private void GenerateAdjacencyTable()
        {
            AdjacencyTable = new DataTable();
            dataGridView1.DataSource = AdjacencyTable;
            

            AdjacencyTable.Columns.Add("#", typeof(string));
            AdjacencyTable.Columns["#"].ReadOnly = true;
            dataGridView1.Columns["#"].Width = 75;
            dataGridView1.Columns["#"].SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (string course in CourseGraph.CourseNames)
            {
                AdjacencyTable.Columns.Add(course, typeof(int));
                AdjacencyTable.Columns[course].ReadOnly = true;
                dataGridView1.Columns[course].Width = 75;
                dataGridView1.Columns[course].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            int numVertices = CourseGraph.AdjacencyMatrix.GetLength(0);
            object[] row = new object[numVertices+1];
            for (int i = 0; i < numVertices; i++)
            {
                row[0] = CourseGraph.CourseNames[i];
                for (int j = 0; j < CourseGraph.AdjacencyMatrix.GetLength(1); j++)
                {
                    row[j+1] = CourseGraph.AdjacencyMatrix[i, j];
                }
                AdjacencyTable.Rows.Add(row);
            }
        }

        private void GenerateCourseGroupLists(Graphics g)
        {
            Dictionary<int, List<string>> colorDict = new Dictionary<int, List<string>>();
            for (int i = 0; i < CourseColors.Length; i++)
            {
                if (!colorDict.ContainsKey(CourseColors[i]))
                {
                    colorDict[CourseColors[i]] = new List<string>();
                }
                colorDict[CourseColors[i]].Add(CourseGraph.CourseNames[i]);
            }

            KeyValuePair<int, List<string>>[] colorDictArr = colorDict.ToArray();
            for (int i = 0; i < colorDictArr.Length; i++)
            {
                int color = colorDictArr[i].Key;
                ListBox box = new ListBox();
                Point location = new Point(500 + (i % 3) * 150, 450 + (i / 3) * 125);
                box.Size = new Size(100, 100);
                SolidBrush brush = new SolidBrush(UniqueRGBColors[color]);
                Rectangle rect = new Rectangle(new Point(500 + (i % 3) * 150, 430 + (i / 3) * 125), new Size(100, 10));
                g.FillRectangle(brush, rect);
                box.Location = location;
                foreach (string course in colorDictArr[i].Value)
                {
                    box.Items.Add(course);
                }
                infoPanel.Controls.Add(box);
            }
        }

        private void showGraphPanel_Click(object sender, EventArgs e)
        {
            graphPanel.Visible = true;
            infoPanel.Visible = false;
        }

        private void showInfoPanel_Click(object sender, EventArgs e)
        {
            graphPanel.Visible = false;
            infoPanel.Visible = true;
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            PaintGraph(graphics);
            e.Dispose();
        }

        private void InfoPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            GenerateCourseGroupLists(graphics);
            e.Dispose();
        }

        private void PaintGraph(Graphics g)
        {
            Queue<int> toBeVisited = new Queue<int>();
            int current;
            bool[] painted = new bool[CourseGraph.AdjacencyMatrix.GetLength(0)];
            NodeCoordinates = new Point[CourseGraph.AdjacencyMatrix.GetLength(0)];
            PaintedEdges = new bool[CourseGraph.AdjacencyMatrix.GetLength(0), CourseGraph.AdjacencyMatrix.GetLength(1)];
            int startX = 20;
            for (int j = 0; j < painted.Length; j++)
            {
                if (!painted[j])
                {
                    toBeVisited.Enqueue(j);

                    int color = CourseColors[j];
                    Color colorRGB = UniqueRGBColors[color];
                    SolidBrush brush = new SolidBrush(colorRGB);
                    NodeCoordinates[j] = new Point(startX, windowHeight / 4);
                    PaintNode(g, brush, NodeCoordinates[j].X, NodeCoordinates[j].Y, 50, CourseGraph.CourseNames[j]);
                    while (toBeVisited.Count != 0)
                    {
                        current = toBeVisited.Dequeue();
                        painted[current] = true;

                        List<int> neighbors = new List<int>();

                        for (int i = 0; i < CourseColors.Length; i++)
                        {
                            if (CourseGraph.AdjacencyMatrix[current, i] == 1)
                            {
                                neighbors.Add(i);
                                
                                if (!painted[i])
                                {
                                    toBeVisited.Enqueue(i);
                                }
                                
                            }
                        }

                        if (neighbors.Count() > 0)
                        {
                            bool anyNodePainted = PaintNeighbors(g, current, startX + 200, neighbors);
                            if (anyNodePainted)
                            {
                                startX += 200;
                            }
                        }
                        
                    }

                    startX += 100;
                }
            }
        }

        private void PaintNode(Graphics g, SolidBrush brush, int X, int Y, int radius, string label)
        {
            Label circleLabel = new Label();
            circleLabel.AutoSize = true;
            circleLabel.Location = new Point(X+3, Y+20);
            circleLabel.Name = $"courseLabel{label}";
            circleLabel.TabIndex = 2;
            circleLabel.Text = label;
            circleLabel.Font = new Font("Microsoft Sans Serif", 5F, FontStyle.Regular, GraphicsUnit.Point);
            graphPanel.Controls.Add(circleLabel);
            g.FillEllipse(brush, X, Y, radius, radius);
        }

        private bool PaintNeighbors(Graphics g, int parentIndex, int startX, List<int> neighbors)
        {
            int stepSize = (int)(windowHeight / neighbors.Count * 0.6);
            bool anyNodePainted = false;
            for (int i = 0; i < neighbors.Count; i++)
            {
                int neighbor = neighbors[i];
                if (NodeCoordinates[neighbor].X == 0 && NodeCoordinates[neighbor].Y == 0)
                {
                    int color = CourseColors[neighbor];
                    Color colorRGB = UniqueRGBColors[color];
                    SolidBrush brush = new SolidBrush(colorRGB);
                    NodeCoordinates[neighbor] = new Point(startX, 30 + i * stepSize);
                    PaintNode(g, brush, NodeCoordinates[neighbor].X, NodeCoordinates[neighbor].Y, 50, CourseGraph.CourseNames[neighbor]);
                    anyNodePainted = true;
                }

                if (!PaintedEdges[neighbor, parentIndex] && !PaintedEdges[parentIndex, neighbor])
                {
                    PaintEdge(g, NodeCoordinates[parentIndex], NodeCoordinates[neighbor]);
                    PaintedEdges[neighbor, parentIndex] = true;
                    PaintedEdges[parentIndex, neighbor] = true;
                }
            }

            return anyNodePainted;
        }

        private void PaintEdge(Graphics g, Point start, Point end)
        {
            Pen pen = new Pen(Color.Black, 2);
            int startX, startY, endX, endY, middleX, middleY;

            if (start.X < end.X)
            {
                startX = start.X + 40;
                endX = end.X + 10;
            } else if (start.X == end.X)
            {
                startX = start.X + 25;
                endX = end.X + 25;
            } else
            {
                startX = start.X + 10;
                endX = end.X + 40;
            }

            if (start.Y <= end.Y)
            {
                startY = start.Y + 40;
                endY = end.Y + 10;
            } else if (start.Y == end.Y)
            {
                startY = start.Y + 25;
                endY = end.Y + 25;
            } else
            {
                startY = start.Y + 10;
                endY = end.Y + 40;
            }


            middleX = (startX + endX) / 2;
            middleY = (startY + endY) / 2;

            if (start.X < end.X)
            {
                if (start.Y <= end.Y)
                {
                    middleY += 50;
                }
                else
                {
                    middleY -= 50;
                }
            } else if (start.X == end.X)
            {
                if (start.Y <= end.Y)
                {
                    middleX += 100;
                }
                else
                {
                    middleX -= 100;
                }
            } else
            { 
                if (start.Y <= end.Y)
                {
                    middleY += 50;
                } else
                {
                    middleY -= 50;
                }
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Point pointStart = new Point(startX, startY);
            Point pointMiddle = new Point(middleX, middleY);
            Point pointEnd = new Point(endX, endY);
            Point[] points = new Point[] { pointStart, pointMiddle, pointEnd };
            g.DrawCurve(pen, points);
        }
    }
}
