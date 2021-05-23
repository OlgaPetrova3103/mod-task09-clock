using System;

//Объявление пакетов:
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Л_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Главный код программы сосредоточен в функции-обработчике события
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Алгоритм работы обработчика можно описать следующим образом:

           // Получение доступа к текущему времени DateTime dt = DateTime.Now;

          //  Создание перьев и кистей для рисования
            DateTime dt = DateTime.Now;
            Pen cir_pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Indigo);
            //Получение графического контекста
            Graphics g = e.Graphics;
            //Объявление объекта для сохранения текущего состояния
            GraphicsState gs;
            //Масштабирование рисунка и перенесение начала координат в центр
            g.TranslateTransform(Width / 2, Height / 2);

            g.ScaleTransform(500 / 200, 500 / 200);
           // Рисование циферблата
            g.DrawEllipse(cir_pen, -120, -120, 240, 240);
            gs = g.Save();



            for (int i = 0; i < 12; i++)
            {
                g.RotateTransform(30 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 6), 0, -120, 0, -100);
            }
            g.RotateTransform(-120);
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 6), 0, -120, 0, -100);
            g.RotateTransform(90);
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 6), 0, -120, 0, -100);
            g.RotateTransform(90);
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 6), 0, -120, 0, -100);
            g.RotateTransform(90);
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 6), 0, -120, 0, -100);
            for (int i = 0; i < 60; i++)
            {
                g.RotateTransform(6 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.Black), 3), 0, -120, 0, -120 + 10);
                g.Restore(gs);
                gs = g.Save();
            }
            gs = g.Save();
            //Рисование стрелок
            g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
            g.DrawLine(new Pen(new SolidBrush(Color.Brown), 3), 0, 0, 0, -75);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(6 * (float)dt.Second);
            g.DrawLine(new Pen(new SolidBrush(Color.Green), 2), 0, 0, 0, -100);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute / 60 + (float)dt.Second / 3600));
            g.DrawLine(new Pen(new SolidBrush(Color.Blue), 4), 0, 0, 0, -50);
            g.Restore(gs);
            gs = g.Save();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DoubleBuffered = true;
            Width = 700;
            Height = 700;
        }

    }
}
