using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace IA_proiect_saptamana_3
{
    public partial class Form1 : Form
    {
        public class LabButton : Button
        {
            public bool wall { get; set; }
            public int level { get; set; }
            public Point par { get; set; }
        }
        Point start = new Point(-1,-1), finish = new Point(-1, -1),dim=new Point(-1,-1),rad=new Point(-1,-1);
        LabButton[,] labirint;
        int step = 0;
        Point[] directions = new Point[] { new Point { X=-1, Y=0 },new Point { X=0, Y=1 },new Point { X=1, Y=0 },new Point { X=0, Y=-1} };

        

        private void reset_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    this.panel1.Controls.Remove(labirint[i, j]);
                }
            }
            comboBoxX.SelectedItem= null;
            comboBoxY.SelectedItem = null;
            comboBox_metoda.SelectedItem = null;
            textBox_x_start.Text = "x";
            textBox_y_start.Text = "y";
            textBox_x_finish.Text = "x";
            textBox_y_finish.Text = "y";
            start = new Point(-1, -1);
            finish = new Point(-1, -1);
            dim = new Point(-1, -1);
            step = 0;
        }

        private int code(Point a)
        {
            return a.X * 20 + a.Y;
        }

        public Form1()
        {
            InitializeComponent();

        }

        public class DuplicateKeyComparer<TKey>
                :
             IComparer<TKey> where TKey : IComparable
        {

            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return 1;
                else
                    return result;
            }

        }
        private int manhattan_dist(Point a)
        {
            int rez = 0;

            rez = Math.Abs(finish.X - a.X) + Math.Abs(finish.Y - a.Y);

            return rez;
        }
        private void redo_path(Point expand)
        {
            while (labirint[expand.X, expand.Y].par != rad)
            {
                expand = labirint[expand.X, expand.Y].par;
                labirint[expand.X, expand.Y].BackColor = Color.Yellow;
            }
        }
        private Queue<Point> getChildrens(Point expand, Dictionary<int, Point> visited)
        {
            Queue<Point> childs = new Queue<Point>();
            for (int i = 0; i < 4; i++)
            {
                Point expanded = new Point(expand.X + directions[i].X, expand.Y + directions[i].Y);
                if (expanded.X < 0 || expanded.X >= dim.X || expanded.Y >= dim.Y || expanded.Y < 0)
                    continue;
                if (labirint[expanded.X, expanded.Y].wall == true || visited.ContainsKey(code(expanded)))
                    continue;
                labirint[expanded.X, expanded.Y].BackColor = Color.Green;
                labirint[expanded.X, expanded.Y].par = expand;
                labirint[expanded.X, expanded.Y].level = labirint[expand.X, expand.Y].level+1;
                childs.Enqueue(new Point(expanded.X, expanded.Y));
            }
            return childs;
        }
        private void BFS()
        {
            Dictionary<int, Point> visited = new Dictionary<int, Point>();
            Queue<Point> toExpand = new Queue<Point>();
            labirint[start.X, start.Y].level = 0;
            step = 0;
            toExpand.Enqueue(start);
            visited.Add(code(start),start);
            while (toExpand.Count!=0)
            {
                Point expand = toExpand.Dequeue();
                step++;
                labirint[expand.X, expand.Y].Text = step.ToString();
                labirint[expand.X, expand.Y].BackColor = Color.Blue;
                if (expand == finish)
                {
                    MessageBox.Show("Am ajuns la destinatie!");
                    step++;
                    labirint[expand.X, expand.Y].Text = step.ToString();
                    labirint[finish.X, finish.Y].BackColor = Color.Red;
                    redo_path(expand);
                    return;
                }
                Queue<Point> childs = getChildrens(expand,visited);
                while (childs.Count != 0)
                {
                    Point temp = childs.Dequeue();
                    visited.Add(code(temp), temp);
                    toExpand.Enqueue(temp);
                }

                this.Refresh();
                System.Threading.Thread.Sleep(100);
            }
        }
        
        private void DFS()
        {
            Dictionary<int, Point> visited = new Dictionary<int, Point>();
            Stack<Point> toExpand = new Stack<Point>();

            labirint[start.X, start.Y].level = 0;
            step = 0;
            toExpand.Push(start);
            visited.Add(code(start), start);
            while (toExpand.Count != 0)
            {
                Point expand = toExpand.Pop();
                step++;
                labirint[expand.X, expand.Y].Text = step.ToString();
                labirint[expand.X, expand.Y].BackColor = Color.Blue;
                if (expand == finish)
                {
                    MessageBox.Show("Am ajuns la destinatie!");
                    step++;
                    labirint[expand.X, expand.Y].Text = step.ToString();
                    labirint[finish.X, finish.Y].BackColor = Color.Red;
                    redo_path(expand);
                    return;
                }
                Queue<Point> childs = getChildrens(expand, visited);
                while (childs.Count != 0)
                {

                    Point temp = childs.Dequeue();
                    visited.Add(code(temp), temp);
                    toExpand.Push(temp);
                }
                this.Refresh();
                System.Threading.Thread.Sleep(25);
            }
        }
        private Point DLS(int limit)
        {
            Dictionary<int, Point> visited = new Dictionary<int, Point>();
            Stack<Point> toExpand = new Stack<Point>();
            toExpand.Push(start);
            labirint[start.X, start.Y].level = 0;
            visited.Add(code(start), start);

            while (toExpand.Count!=0)
            {
                Point expand = toExpand.Pop();
                if (labirint[expand.X,expand.Y].level <= limit)
                {
                    if (expand == finish)
                    {
                        step++;
                        labirint[expand.X, expand.Y].Text = step.ToString();
                        labirint[finish.X, finish.Y].BackColor = Color.Red;
                        return expand;
                    }
                    else
                    {
                        step++;
                        labirint[expand.X, expand.Y].Text = step.ToString();
                        labirint[expand.X, expand.Y].BackColor = Color.Blue;
                        
                        Queue<Point> childs = getChildrens(expand, visited);
                        while (childs.Count != 0)
                        {

                            Point temp = childs.Dequeue();
                            visited.Add(code(temp), temp);
                            toExpand.Push(temp);
                        }
                        this.Refresh();
                        System.Threading.Thread.Sleep(25);
                    }

                }
            }
            return rad;
        }
        private Point IDS()
        {
            for(int depth=0;depth<2000;depth++)
            {
                Point rez = DLS(depth);
                if (rez != rad)
                    return rez;

                this.Refresh();
                System.Threading.Thread.Sleep(50);
            }
            return rad;
        }
        private void GBFS()
        {
            Dictionary<int, Point> visited = new Dictionary<int, Point>();
            SortedList<int, Point> toExpand=new SortedList<int, Point>(new DuplicateKeyComparer<int>()), t = new SortedList<int, Point>(new DuplicateKeyComparer<int>());
            labirint[start.X, start.Y].level = 0;
            step = 0;
            toExpand.Add(manhattan_dist(start),start);
            visited.Add(code(start), start);
            while (toExpand.Count != 0)
            {
                Point expand = toExpand.First().Value;
                toExpand.RemoveAt(0);
                step++;
                labirint[expand.X, expand.Y].Text = step.ToString();
                labirint[expand.X, expand.Y].BackColor = Color.Blue;
                if (expand == finish)
                {
                    MessageBox.Show("Am ajuns la destinatie!");
                    step++;
                    labirint[expand.X, expand.Y].Text = step.ToString();
                    labirint[finish.X, finish.Y].BackColor = Color.Red;
                    redo_path(expand);
                    return;
                }
                Queue<Point> childs = getChildrens(expand, visited);
                while (childs.Count != 0)
                {
                    Point temp = childs.Dequeue();
                    visited.Add(code(temp), temp);
                    toExpand.Add(manhattan_dist(temp),temp);
                }

                this.Refresh();
                System.Threading.Thread.Sleep(100);
            }
        }
        private void A_Star()
        {
            Dictionary<int, Point> visited = new Dictionary<int, Point>();
            SortedList<int, Point> toExpand = new SortedList<int, Point>(new DuplicateKeyComparer<int>()), t = new SortedList<int, Point>(new DuplicateKeyComparer<int>());
            labirint[start.X, start.Y].level = 0;
            step = 0;
            toExpand.Add(0+manhattan_dist(start), start);
            visited.Add(code(start), start);
            while (toExpand.Count != 0)
            {
                Point expand = toExpand.First().Value;
                toExpand.RemoveAt(0);
                step++;
                labirint[expand.X, expand.Y].Text = step.ToString();
                labirint[expand.X, expand.Y].BackColor = Color.Blue;
                if (expand == finish)
                {
                    MessageBox.Show("Am ajuns la destinatie!");
                    step++;
                    labirint[expand.X, expand.Y].Text = step.ToString();
                    labirint[finish.X, finish.Y].BackColor = Color.Red;
                    redo_path(expand);
                    return;
                }
                Queue<Point> childs = getChildrens(expand, visited);
                while (childs.Count != 0)
                {
                    Point temp = childs.Dequeue();
                    visited.Add(code(temp), temp);
                    toExpand.Add(labirint[temp.X,temp.Y].level+manhattan_dist(temp), temp);
                }

                this.Refresh();
                System.Threading.Thread.Sleep(100);
            }
        }
        private void IDA_Star()
        {
            int limit = manhattan_dist(start);
            while(true)
            {
                int temp = search_IDA(start, 0, limit);
                if(temp==-1)
                {
                    MessageBox.Show("Am ajuns la destinatie!");
                    return;
                }
                if(temp==int.MaxValue)
                {
                    return;
                }
                limit = temp; this.Refresh();
                System.Threading.Thread.Sleep(100);
            }
        }

        private int search_IDA(Point nod, int g, int limit)
        {
            Dictionary<int, Point> visited = new Dictionary<int, Point>();
            int f = g + manhattan_dist(nod);
            if(f>limit)
                return f;
            if (nod == finish)
            {
                MessageBox.Show("Am ajuns la destinatie!");
                //redo_path(nod);
                return -1;
            }
            int min = int.MaxValue;
            foreach(Point i in getChildrens(nod,visited))
            {
                step++;
                labirint[i.X, i.Y].Text = step.ToString();
                labirint[i.X, i.Y].BackColor = Color.Blue;
                this.Refresh();
                System.Threading.Thread.Sleep(100);
                int temp = search_IDA(i, g + 1, limit);
                if(temp==-1)
                {
                    //MessageBox.Show("Am ajuns la destinatie!");
                    redo_path(nod);
                    return -1;
                }
                if(temp<min)
                {
                    min = temp;
                }

            }
            return min;
        }

        private void sol_button_Click(object sender, EventArgs e)
        {

            //validari
            if(dim.X==-1 || dim.Y==-1)
            {
                MessageBox.Show("Labirint negenerat!");
                return;

            }
            if(!(Int32.Parse(textBox_x_start.Text)<=dim.X && Int32.Parse(textBox_x_start.Text) >0) || textBox_x_start.Text == "x")
            {
                MessageBox.Show("X start incorect!");
                return;
            }
            if (!(Int32.Parse(textBox_y_start.Text) <= dim.Y && Int32.Parse(textBox_y_start.Text) > 0) || textBox_y_start.Text == "y")
            {
                MessageBox.Show("Y start neprecizat!");
                return;
            }
            if (!(Int32.Parse(textBox_x_finish.Text) <= dim.X && Int32.Parse(textBox_x_finish.Text) > 0) || textBox_x_finish.Text == "x")
            {
                MessageBox.Show("X finish neprecizat!");
                return;

            }
            if (!(Int32.Parse(textBox_y_finish.Text) <= dim.Y && Int32.Parse(textBox_y_finish.Text) > 0) || textBox_y_finish.Text=="y")
            {
                MessageBox.Show("Y finish neprecizat!");
                return;
            }
            if (comboBox_metoda.SelectedItem== null)
            {
                MessageBox.Show("Metoda neprecizata!");
                return;
            }
            start = new Point(Int32.Parse(textBox_x_start.Text)-1, Int32.Parse(textBox_y_start.Text)-1);
            finish = new Point(Int32.Parse(textBox_x_finish.Text)-1, Int32.Parse(textBox_y_finish.Text)-1);
            labirint[start.X, start.Y].BackColor = Color.Green;
            labirint[start.X,start.Y].wall = false;
            labirint[finish.X, finish.Y].BackColor = Color.Red;
            labirint[finish.X, finish.Y].wall = false;
            labirint[start.X, start.Y].par = rad;
            int aleg = comboBox_metoda.SelectedIndex;
            switch(aleg)
            {
                case 0:
                    {
                        BFS();
                    }break;
                case 1:
                    {
                        DFS();
                    }break;
                case 2:
                    {
                        int dl = dim.X+1;
                        Point rez = DLS(dl);
                        if (rez != rad)
                        {
                            MessageBox.Show("Am ajuns la destinatie!");
                            redo_path(rez);
                        }
                        else
                            MessageBox.Show("Imposibil!");
                    }break;
                case 3:
                    {
                        Point rez = IDS();
                        if (rez != rad)
                        {
                            MessageBox.Show("Am ajuns la destinatie!");
                            redo_path(rez);
                        }
                        else
                            MessageBox.Show("Imposibil!");
                    }
                    break;
                case 4:
                    {
                        GBFS();
                    }break;
                case 5:
                    {
                        A_Star();
                    }break;
                case 6:
                    {
                        IDA_Star();
                    }break;
            };
            
        }

        private void stare_init_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    labirint[i, j].PerformClick();
                    labirint[i, j].PerformClick();
                    labirint[i, j].par = rad;
                    labirint[i, j].Text = null;
                    if (i == start.X && j == start.Y)
                        labirint[i, j].BackColor = Color.Green;
                    if (i == finish.X && j == finish.Y)
                        labirint[i, j].BackColor = Color.Red;
                }
            }

            step = 0;
        }

        private void edit_wall(object sender, EventArgs e)
        {
            LabButton sel = (LabButton)sender;
            if (sel.BackColor == Color.Gray)
            {
                sel.BackColor = Color.White;
                sel.wall = false;

            }
            else
            {
                sel.BackColor = Color.Gray;
                sel.wall = true;

            }

        }

        private void gen_button_Click(object sender, EventArgs e)
        {
            
            //validari
            if (comboBoxX.SelectedItem==null)
            {
                MessageBox.Show("Numar de randuri neselectat!");
                return;
            }
            if(comboBoxY.SelectedItem == null)
            {
                MessageBox.Show("Numar de coloane neselectat!");
                return;
            }

            for (int i = 0; i < dim.X; i++)
            {
                for (int j = 0; j < dim.Y; j++)
                {
                    this.panel1.Controls.Remove(labirint[i, j]);
                }
            }

            dim.X=Int32.Parse(comboBoxX.Text);
            dim.Y = Int32.Parse(comboBoxY.Text);
            labirint = new LabButton[dim.X,dim.Y];

            int init_w=Size.Width,init_h=Size.Height;
            for(int i=0;i<dim.X;i++)
            {
                for(int j=0;j<dim.Y;j++)
                {
                    labirint[i, j] = new LabButton()
                    {
                        Width = 50,
                        Height = 50,
                        Parent = panel1,
                        Text = null,
                        Location = new Point(j * 50, i * 50),
                        BackColor = Color.White,
                        Tag = i.ToString() + '_' + j.ToString(),
                        wall = false,
                        par = rad
                        
                    };
                    labirint[i, j].Click += edit_wall;
                }
            }
            Size = new Size(init_w,init_h);
        }
    }
}
