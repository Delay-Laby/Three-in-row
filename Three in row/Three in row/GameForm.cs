using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Three_in_row
{
    public partial class MainForm : Form

    {
        private int NumOfCol = 6;

        // количество клеток
        private  int square = 8;

        //Условие для очистки при 2 новых,   
        private const int ForClear = 2;
        private  int SquareSize = 50;
        private bool isClick = false;
        private Random rnd = new Random();
        private int RowU = 0;
        private int RowD = 0;
        private int horL = 0;
        private int horR = 0;
        private Button prevButton;
        private Button[,] buttons;
        private int Score = 0;
        public MainForm()
        {
            InitializeComponent();
            // CreateMap();
            Restart_button.Enabled = false;
            Clear_button.Enabled = false;


        }

        public void CreateMap(int square, int SquareSize)
        {
            buttons= new Button[square, square];
            label1.Text = Convert.ToString(Score);
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    buttons[i, j] = new Button();

                    Button button = new Button
                    {
                        Size = new Size(SquareSize, SquareSize),
                        Location = new Point(j * SquareSize, i * SquareSize),


                        BackColor = RandC()
                    };


                    button.Click += new EventHandler(onFigurePress);

                    Controls.Add(button);
                    buttons[i, j] = button;
                }

            }
            //убрать, для начала с 0 очков 
            Refresh();
            Thread.Sleep(1000);

            ClearAll();
           // Refresh();
          //  ClearAll();


        }




        public Color RandC()
        {


            switch (rnd.Next(NumOfCol))
            {
                case 0: return Color.Red;
                case 1: return Color.Blue;
                case 2: return Color.Green;
                case 3: return Color.Yellow;
                case 4: return Color.Orange;
                case 5: return Color.Aquamarine;
                case 6: return Color.Brown;
                case 7: return Color.Chocolate;
                case 8: return Color.Aqua;
                case 9: return Color.Black;

            }
            return Color.Black;

        }



        public void onFigurePress(Object sender, EventArgs e)
        {


            Button pressButton = sender as Button;



            if (((pressButton.Location.Y / SquareSize < square && pressButton.Location.X / SquareSize < square) || (pressButton.Location.Y / SquareSize > 0 && pressButton.Location.X / SquareSize > 0)) && !isClick)
            {

                isClick = true;
                prevButton = pressButton;

            }

            else

                if (isClick && (Math.Abs(prevButton.Location.Y / SquareSize - pressButton.Location.Y / SquareSize) == 1 ^ Math.Abs(prevButton.Location.X / SquareSize - pressButton.Location.X / SquareSize) == 1) && (Math.Abs(prevButton.Location.Y / SquareSize - pressButton.Location.Y / SquareSize) == 0 ^ Math.Abs(prevButton.Location.X / SquareSize - pressButton.Location.X / SquareSize) == 0))
            {

                Cswop(buttons[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize], buttons[prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize]);

                isClick = false;
                Refresh();


                if (!(ClB(pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize) || ClB(prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize)))
                {

                    Refresh();
                    Thread.Sleep(500);
                    Cswop(buttons[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize], buttons[prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize]);
                    Refresh();

                    prevButton = pressButton;
                }
                else
                {
                    Clear_1_position(pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize);
                    Refresh();
                    Clear_1_position(prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize);
                    Refresh();
                    Thread.Sleep(500);
                  //  shift();
                    


                }




            }
            else
            {
                isClick = false;
            }

            
            ClearAll();
           // ClearAll();



        }








        public void clear()
        {
            int tempi, tempj;
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)

                {
                    tempi = i;
                    tempj = j;
                    //низ
                    while ((tempj + 1 < square) && (buttons[j, i].BackColor == buttons[tempj + 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        RowD++;
                        tempj++;
                    }
                    //верх
                    tempj = j;
                    while ((tempj - 1 >= 0) && (buttons[j, i].BackColor == buttons[tempj - 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        RowU++;

                        tempj--;
                    }

                    //право 
                    while ((tempi + 1 < square) && (buttons[j, i].BackColor == buttons[j, tempi + 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        horR++;

                        tempi++;
                    }

                    tempi = i;
                    //лево
                    while ((tempi - 1 >= 0) && (buttons[j, i].BackColor == buttons[j, tempi - 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        horL++;
                        tempi--;
                    }

                    Clear_1_position(j, i);
                }
            }

        }


        public void Clear_1_position(int j, int i)
        {
            if (horR + horL >= ForClear)
            {

                for (; horR != 0; horR--)
                {
                    buttons[j, i + horR].BackColor = Color.White;
                    if (buttons[j, i].BackColor != Color.White)
                    {
                        Score = Score + 10;
                    }
                }
                for (; horL != 0; horL--)
                {
                    buttons[j, i - horL].BackColor = Color.White;
                    if (buttons[j, i].BackColor != Color.White)
                    {
                        Score = Score + 10;
                    }
                }
                buttons[j, i].BackColor = Color.White;
                Refresh();
            }
            if (RowD + RowU >= ForClear)
            {
                for (; RowD != 0; RowD--)
                {
                    buttons[j + RowD, i].BackColor = Color.White;
                    if (buttons[j, i].BackColor != Color.White)
                    {
                        Score = Score + 10;
                    }
                }
                for (; RowU != 0; RowU--)
                {
                    buttons[j - RowU, i].BackColor = Color.White;
                    if (buttons[j, i].BackColor != Color.White)
                    {
                        Score = Score + 10;
                    }
                }
                buttons[j, i].BackColor = Color.White;
                Refresh();
            }
            shift();
            //заполнение
            RowU = 0;
            RowD = 0;
            horL = 0;
            horR = 0;
            label1.Text = Convert.ToString(Score);

        }
        private void Restart_click(object sender, EventArgs e)
        {
            Score = 0;
            label1.Text = Convert.ToString(Score);
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    buttons[i, j].BackColor = RandC();
                    //Для поклеточной 
                    //Refresh();
                }
                //Для построчной отрисовки
                //Refresh();
            }
            Refresh();
            Thread.Sleep(1000);
            ClearAll();
          //  ClearAll();

        }

        //Кнопка для очистки всего поля
        private void Clear(object sender, EventArgs e)
        {
           
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {

                    Controls.Remove(buttons[i, j]);
                       
                  

                }

            }
            
            Score = 0;
            Restart_button.Enabled = false;
            Clear_button.Enabled = false;
            Start_button.Enabled = true;
            MapBar.Enabled = true;
            SizeBar.Enabled = true;
        }
        //Проверка на всю карту
        public void ClearAll()
        {
            //Thread.Sleep(700);
            

            // Thread.Sleep(700);
            //shift();
            //Refresh();
            // Thread.Sleep(700);
            clear();
            Refresh();
            //shift();
            //Refresh();
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    if (buttons[i, j].BackColor == Color.White)
                    {
                        buttons[i, j].BackColor = RandC();
                        Refresh();
                        if (ClB(i, j))
                        {
                            Thread.Sleep(500);
                            Clear_1_position(i, j);

                            ClearAll();
                        }
                       
                    }


                }

            }




        }

        // проверка на наличие 3 в ряд
        public bool ClB(int j, int i)
        {

            int tempi = i;
            int tempj = j;
            //нулевый
            while ((tempj + 1 < square) && (buttons[j, i].BackColor == buttons[tempj + 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                RowD++;
                tempj++;
            }

            tempj = j;
            while ((tempj - 1 >= 0) && (buttons[j, i].BackColor == buttons[tempj - 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                RowU++;

                tempj--;
            }

            //право 
            while ((tempi + 1 < square) && (buttons[j, i].BackColor == buttons[j, tempi + 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                horR++;

                tempi++;
            }

            tempi = i;
            //лево
            while ((tempi - 1 >= 0) && (buttons[j, i].BackColor == buttons[j, tempi - 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                horL++;
                tempi--;
            }

            if (horR + horL >= ForClear)
            {
                
                return true;
            }
            if (RowD + RowU >= ForClear)
            {
            
                return true;
            }
            RowU = 0;
            RowD = 0;
            horL = 0;
            horR = 0;
            return false;
        }



        //падение
        public void shift()
        {
            int z = 1;
            for (int i = square - 2; i >= 0; i--)
            {
                for (int j = 0; j < square; j++)
                {
                    while (i + z < square && buttons[i + z, j].BackColor == Color.White)
                    {
                        z++;
                    }

                    if (buttons[i + z - 1, j].BackColor == Color.White)
                    {
                        //buttons[i + z - 1, j].BackColor = buttons[i, j].BackColor;
                        //buttons[i, j].BackColor = Color.White;
                        Cswop(buttons[i + z - 1, j], buttons[i, j]);

                    }
                    z = 1;


                }

            }



        }

        //обмен цветами
        private void Cswop(Button B1, Button B2)
        {

            Color temp = buttons[B1.Location.Y / SquareSize, B1.Location.X / SquareSize].BackColor;


            buttons[B1.Location.Y / SquareSize, B1.Location.X / SquareSize].BackColor = buttons[B2.Location.Y / SquareSize, B2.Location.X / SquareSize].BackColor;

            buttons[B2.Location.Y / SquareSize, B2.Location.X / SquareSize].BackColor = temp;


        }
        
        private void Start_Click(object sender, EventArgs e)
        {
            CreateMap(square, SquareSize);
            Restart_button.Enabled = true;
            Clear_button.Enabled = true;
            Start_button.Enabled = false;
            MapBar.Enabled = false;
            SizeBar.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            NumOfCol = ColorsBar.Value;
            label5.Text = Convert.ToString(NumOfCol);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            square = MapBar.Value;
            Maplabel.Text = Convert.ToString(square);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            SquareSize = SizeBar.Value;
            Sizelabel.Text = Convert.ToString(SquareSize);

        }
    }
}
