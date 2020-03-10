using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Three_in_row
{
    public partial class MainForm : Form

    {
       
        
        // количество клеток
        const int square = 8;
        //Условие для очистки при 2 новых
        const int ForClear = 2;
        const int SquareSize = 50;
        bool isClick = false;
        Random rnd = new Random();
        int RowU = 0;
        int RowD = 0;
        int horL = 0;
        int horR = 0;
        public bool isMove = false;
        public Button prevButton;
        public Button[,] butts = new Button[square, square];
        int Score = 0;
        public MainForm()
        {
            InitializeComponent();
            // CreateMap();
            button1.Enabled = false;
            button2.Enabled = false;


        }

        public void CreateMap()
        {
            label1.Text = Convert.ToString(Score);
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    butts[i, j] = new Button();

                    Button butt = new Button();
                    butt.Size = new Size(SquareSize, SquareSize);
                    butt.Location = new Point(j * SquareSize, i * SquareSize);


                    butt.BackColor = RandC();


                    butt.Click += new EventHandler(onFigurePress);

                    this.Controls.Add(butt);
                    butts[i, j] = butt;
                }

            }
            Refresh();
            Thread.Sleep(1000);
            
            ClearAll();
            Refresh();
            ClearAll();


        }




        public Color RandC()
        {


            switch (rnd.Next(6))
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
                //if (isClick)
                //{

                //    isClick = false;
                //    prevButton = pressButton;

                //}
                //else
                //{
                    isClick = true;
                    prevButton = pressButton;
                //}
            }

            else
            //добавить радиус для обмена
                if (isClick && (Math.Abs(prevButton.Location.Y / SquareSize - pressButton.Location.Y / SquareSize) == 1 ^ Math.Abs(prevButton.Location.X / SquareSize - pressButton.Location.X / SquareSize) == 1) && (Math.Abs(prevButton.Location.Y / SquareSize - pressButton.Location.Y / SquareSize) == 0 ^ Math.Abs(prevButton.Location.X / SquareSize - pressButton.Location.X / SquareSize) == 0))
            {
            //    Color temp = butts[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize].BackColor;
             
                Cswop(butts[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize], butts[prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize]);
                //butts[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize].BackColor = butts[prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize].BackColor;
                //butts[prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize].BackColor=temp;
                isClick = false;
                Refresh();
               // Thread.Sleep(500);

                if (!(Cl(pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize) || Cl(prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize)))
                {
                    //нужна пауза
                    Refresh();
                    Thread.Sleep(500);
                    Cswop(butts[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize], butts[prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize]);
                    //butts[prevButton.Location.Y / SquareSize, prevButton.Location.X / SquareSize].BackColor = butts[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize].BackColor;
                    //butts[pressButton.Location.Y / SquareSize, pressButton.Location.X / SquareSize].BackColor = temp;

                    prevButton = pressButton;
                }
                else
                {
                    Refresh();
                    Thread.Sleep(500);
                    shift();
                    //  Thread.Sleep(1000);
                    //clearAll();
                }
               



            }
            else
                isClick = false;

            //Thread thread1 = new Thread(ClearAll);
            //thread1.Start();

            // System.Threading.Thread.Sleep(5000);
            Refresh();
            ClearAll();
            ClearAll();
            


        }



        //public void svop(int j1,int i1,int j2,int i2)
        //{
        //    Color temp = butts[j1, i1].BackColor;
        //    butts[j1, i1].BackColor = butts[j2, i2].BackColor;
        //    butts[j2, i2].BackColor = temp;
        //}





        public void clear()
        {
            int tempi, tempj;
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)

                {
                    tempi = i;
                    tempj = j;
                    while ((tempj + 1 < square) && (butts[j, i].BackColor == butts[tempj + 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        RowD++;
                        tempj++;
                    }

                    tempj = j;
                    while ((tempj - 1 >= 0) && (butts[j, i].BackColor == butts[tempj - 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        RowU++;

                        tempj--;
                    }

                    //право 
                    while ((tempi + 1 < square) && (butts[j, i].BackColor == butts[j, tempi + 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        horR++;

                        tempi++;
                    }

                    tempi = i;
                    //лево
                    while ((tempi - 1 >= 0) && (butts[j, i].BackColor == butts[j, tempi - 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
                    {
                        horL++;
                        tempi--;
                    }

                    Clear1(j, i);
                    //if (horR + horL >= ForClear)
                    //{
                    //    for (; horR != 0; horR--)
                    //        butts[j, i + horR].BackColor = Color.White;
                    //    for (; horL != 0; horL--)
                    //        butts[j, i - horL].BackColor = Color.White;
                    //    butts[j, i].BackColor = Color.White;
                    //}
                    //if (RowD + RowU >= ForClear)
                    //{
                    //    for (; RowD != 0; RowD--)
                    //        butts[j + RowD, i].BackColor = Color.White;
                    //    for (; RowU != 0; RowU--)
                    //        butts[j - RowU, i].BackColor = Color.White;
                    //    butts[j, i].BackColor = Color.White;
                    //}

                    ////заполнение
                    //RowU = 0;
                    //RowD = 0;
                    //horL = 0;
                    //horR = 0;
                }
            }

        }


        public bool Cl1(int y, int x)
        {

            int tempi = x;
            int tempj = y;
            while ((tempi + 1 < square) && (butts[x, y].BackColor == butts[tempi + 1, y].BackColor) && ((x < square && y < square) || (y > 0 && x > 0)))
            {
                horR++;
                tempi++;
            }

            tempi = x;
            while ((tempi - 1 >= 0) && (butts[x, y].BackColor == butts[tempi - 1, y].BackColor) && ((x < square && y < square) || (y > 0 && x > 0)))
            {
                horL++;
                tempi--;
            }

            while ((tempj + 1 < square) && (butts[x, y].BackColor == butts[x, tempj + 1].BackColor) && ((x < square && y < square) || (y > 0 && x > 0)))
            {
                RowD++;
                tempj++;
            }

            tempj = y;

            while ((tempj - 1 >= 0) && (butts[x, y].BackColor == butts[x, tempj - 1].BackColor) && ((x < square && y < square) || (y > 0 && x > 0)))
            {
                RowU++;
                tempj--;
            }

            if (horR + horL >= ForClear)
            {
                Clear1(y, x);
                return true;
            }
            if (RowD + RowU >= ForClear)
            {
                Clear1(y, x);
                return true;
            }
            Clear1(y, x);
            return false;
        }
        public void Clear1(int j, int i)
        {
            if (horR + horL >= ForClear)
            {

                for (; horR != 0; horR--)
                {
                    butts[j, i + horR].BackColor = Color.White;
                    if(butts[j, i].BackColor!= Color.White)
                    Score = Score + 10;
                }
                for (; horL != 0; horL--)
                {
                    butts[j, i - horL].BackColor = Color.White;
                    if (butts[j, i].BackColor != Color.White)
                        Score = Score + 10;
                }
                butts[j, i].BackColor = Color.White;
            }
            if (RowD + RowU >= ForClear)
            {
                for (; RowD != 0; RowD--)
                {
                    butts[j + RowD, i].BackColor = Color.White;
                    if (butts[j, i].BackColor != Color.White)
                        Score = Score + 10;
                }
                for (; RowU != 0; RowU--)
                {
                    butts[j - RowU, i].BackColor = Color.White;
                    if (butts[j, i].BackColor != Color.White)
                        Score = Score + 10;
                }
                butts[j, i].BackColor = Color.White;
            }
            //shift();
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
                    butts[i, j].BackColor = RandC();
                    // Refresh();
                }
                // Refresh();
            }
            Refresh();
            Thread.Sleep(1000);
            ClearAll();
            ClearAll();

        }

        private void Clear(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            //Thread.Sleep(700);
            clear();
            Refresh();

          // Thread.Sleep(700);
            shift();
            Refresh();
           // Thread.Sleep(700);


            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    if (butts[i, j].BackColor == Color.White)
                    {
                        butts[i, j].BackColor = RandC();
                        Refresh();
                        if (Cl(i, j))
                            ClearAll();
                       
                    }
                    

                }

            }

           
            
           
        }






        //public bool Cl(int i, int j, Color bc)
        //{

        //    int tempi = i;
        //    int tempj = j;
        //    while ((tempi + 1 < square) && (butts[i, j].BackColor == butts[++tempi, j].BackColor) && (i < square && j < square) || (j > 0 && i > 0))
        //        horR++;
        //    tempi = i;
        //    while ((tempi - 1 > 0) && (butts[i, j].BackColor == butts[--tempi, j].BackColor) && (i < square && j < square) || (j > 0 && i > 0))
        //        horL++;

        //    while ((tempj + 1 < square) && (butts[i, j].BackColor == butts[i, ++tempj].BackColor) && (i < square && j < square) || (j > 0 && i > 0))
        //        RowD++;
        //    tempj = j;

        //    while ((tempj - 1 > 0) && (butts[i, j].BackColor == butts[i, --tempj].BackColor) && (i < square && j < square) || (j > 0 && i > 0))
        //        RowU++;

        //    if (horR + horL >= ForClear)
        //    {
        //        return true;
        //    }
        //    if (RowD + RowU >= ForClear)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public bool Cl(int j, int i)
        {

            int tempi = i;
            int tempj = j;
            //нулевый
            while ((tempj + 1 < square) && (butts[j, i].BackColor == butts[tempj + 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                RowD++;
                tempj++;
            }

            tempj = j;
            while ((tempj - 1 >= 0) && (butts[j, i].BackColor == butts[tempj - 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                RowU++;

                tempj--;
            }

            //право 
            while ((tempi + 1 < square) && (butts[j, i].BackColor == butts[j, tempi + 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                horR++;

                tempi++;
            }

            tempi = i;
            //лево
            while ((tempi - 1 >= 0) && (butts[j, i].BackColor == butts[j, tempi - 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                horL++;
                tempi--;
            }

            if (horR + horL >= ForClear)
            {
                Clear1(j, i);
                return true;
            }
            if (RowD + RowU >= ForClear)
            {
                Clear1(j, i);
                return true;
            }
            Clear1(j, i);
            return false;
        }



        public bool ClB(int j, int i)
        {

            int tempi = i;
            int tempj = j;
            //нулевый
            while ((tempj + 1 < square) && (butts[j, i].BackColor == butts[tempj + 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                RowD++;
                tempj++;
            }

            tempj = j;
            while ((tempj - 1 >= 0) && (butts[j, i].BackColor == butts[tempj - 1, i].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                RowU++;

                tempj--;
            }

            //право 
            while ((tempi + 1 < square) && (butts[j, i].BackColor == butts[j, tempi + 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                horR++;

                tempi++;
            }

            tempi = i;
            //лево
            while ((tempi - 1 >= 0) && (butts[j, i].BackColor == butts[j, tempi - 1].BackColor) && ((i < square && j < square) || (j > 0 && i > 0)))
            {
                horL++;
                tempi--;
            }

            if (horR + horL >= ForClear)
            {
                RowU = 0;
                RowD = 0;
                horL = 0;
                horR = 0;
                return true;
            }
            if (RowD + RowU >= ForClear)
            {
                RowU = 0;
                RowD = 0;
                horL = 0;
                horR = 0;
                return true;
            }
            RowU = 0;
            RowD = 0;
            horL = 0;
            horR = 0;
            return false;
        }


        public void shift()
        {
            int z = 1;
            for (int i = square - 2; i >= 0; i--)
            {
                for (int j = 0; j < square; j++)
                {
                    while (i + z < square && butts[i + z, j].BackColor == Color.White)
                        z++;
                    if (butts[i + z - 1, j].BackColor == Color.White)
                    {
                        butts[i + z - 1, j].BackColor = butts[i, j].BackColor;
                        butts[i, j].BackColor = Color.White;


                        //for (int z = 0; i - z >= 0 && i + z < square; z++)
                        //{
                        //    butts[i - z, j].BackColor = butts[i, j].BackColor;
                        //    butts[i, j].BackColor = Color.White;
                        //}
                    }
                    z = 1;


                }

            }


            //поднятие на 1 
            //for (int i = 0; i < square - 1; i++)
            //{
            //    for (int j = 0; j < square; j++)
            //    {
            //        if (butts[i + 1, j].BackColor == Color.White)
            //        {
            //            butts[i + 1, j].BackColor = butts[i, j].BackColor;
            //            butts[i, j].BackColor = Color.White;

            //            //for (int z = 0; i - z >= 0 && i + z < square; z++)
            //            //{
            //            //    butts[i - z, j].BackColor = butts[i, j].BackColor;
            //            //    butts[i, j].BackColor = Color.White;
            //            //}
            //        }


            //    }

            //}




        }
        //Нажатая B1 Прошлая B2
        private void Cswop(Button B1, Button B2)
        {
            
            Color temp = butts[B1.Location.Y / SquareSize, B1.Location.X / SquareSize].BackColor;
            
            
            butts[B1.Location.Y / SquareSize, B1.Location.X / SquareSize].BackColor = butts[B2.Location.Y / SquareSize, B2.Location.X / SquareSize].BackColor;
            
            butts[B2.Location.Y / SquareSize, B2.Location.X / SquareSize].BackColor = temp;
                  

        }

        private void Start_Click(object sender, EventArgs e)
        {
            CreateMap();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;

        }

        
    }
}
