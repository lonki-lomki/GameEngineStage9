﻿using GameEngineStage9.Core;
using GameEngineStage9.Utils;
using System;
using System.Windows.Forms;

namespace GameEngineStage9
{
    public partial class Form1 : Form
    {

        private string old_title;	// Оригинальный текст в заголовке окна
        private Timer timer = new Timer();

        // Счётчик количества тиков
        private long tickCount = 0;
        // Для определения длины интервала времени в тиках
        private long saveTickCount = 0;

        /// <summary>
        /// Игровые данные
        /// </summary>
        private GameData gd;

        public Form1()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Обработка событий таймера
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="ea">Ea.</param>
        ///////////////////////////////////////////////////////////////////////
        private void OnTimer(object obj, EventArgs ea)
        {
            int delta;

            // Новое значение времени
            tickCount = Environment.TickCount;

            delta = (int)(tickCount - saveTickCount);

            if (delta == 0)
            {
                // А вдруг!
                return;
            }

            // Вычислить FPS
            float fps = 1000 / delta;

            // Вывести сообщение в заголовке окна
            this.Text = old_title + " : " + fps + " FPS"; // + (string)luaVersion;
            /*
            // Проверить флаг смены сцены
            if (gd.sceneChange == true)
            {
                // Удалить все объекты из физ. мира
                gd.world.objects.Clear();

                // Перенести "живые" объекты из текущей сцены в физический мир
                foreach (Entity ent in gd.curScene.objects)
                {
                    if (ent.IsDestroyed() == false)
                    {
                        gd.world.Add(ent);
                    }
                }
                // Сбросить флаг
                gd.sceneChange = false;
            }

            // Обновить мир
            gd.world.Update(delta);

            // Обновить игровую сцену
            gd.curScene.Update(delta);

            // Проверить актуальность объектов (убрать со сцены уничтоженные объекты)
            for (int i = gd.world.objects.Count - 1; i >= 0; i--)
            {
                if (gd.world.objects[i].IsDestroyed())
                {
                    // Удалить из "мира"
                    gd.world.objects.RemoveAt(i);
                }
            }
            */
            saveTickCount = tickCount;

            Invalidate(false);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Размер окна программы
            Width = CONFIG.WIND_WIDTH;
            Height = CONFIG.WIND_HEIGHT;
            //this.BackColor = Color.Magenta;

            // Запретить изменение размера окна
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            //MinimizeBox = false;

            // Настройки окна программы
            KeyPreview = true;
            DoubleBuffered = true;

            Logger log = new Logger("Log.txt");

            gd = GameData.Instance;
            gd.log = log;

            // Получить доступ к ресурсам, встроенным в проект
            //gd.myAssembly = Assembly.GetExecutingAssembly();

            // Начальные параметры для обработки интервалов по таймеру
            tickCount = Environment.TickCount; //GetTickCount();
            saveTickCount = tickCount;

            // Настройки таймера
            timer.Enabled = true;
            timer.Tick += new EventHandler(OnTimer);
            timer.Interval = 20;
            timer.Start();

            // Создать физический мир
            //gd.world = new PhysWorld(log);

            old_title = this.Text;

            // Получить геометрию области рисования
            gd.clientRectangle = ClientRectangle;

            // Инициализация менеджера ресурсов
            gd.rm = ResourceManager.Instance;

            //gd.rm.AddElementAsImage("background", Gradient.GetImage(Color.Black, Color.Black, ClientRectangle.Width, ClientRectangle.Height, 0));
            //gd.backgroundImage = gd.rm.GetImage("background");

            // Создание и настройка камеры
            //gd.camera = new Camera(new Rectangle(CONFIG.START_X, CONFIG.START_Y, ClientRectangle.Width - CONFIG.START_X * 2, ClientRectangle.Height - CONFIG.PANEL_HEIGHT - CONFIG.START_X * 2));

            // Создать стартовую сцену игры
            //GameScene gs = new GameScene(GameData.GameState.Level, gd);
            //MainMenuScene scene = new MainMenuScene(GameData.GameState.MainMenu, gd);
            //gd.curScene = gs;

            //gd.curScene.Init();

            //gd.sceneChange = true;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
