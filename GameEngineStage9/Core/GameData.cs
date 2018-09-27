﻿using GameEngineStage9.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngineStage9.Core
{
    public class GameData
    {
        // Набор значений для определения текущего состояния игры
        public enum GameState
        {
            NotStarted,
            MainMenu,
            Level,
            LevelWin,
            GameWin,
            GameOver
        }

        private static GameData instance;

        public PhysWorld world;

        public Logger log;

        public ResourceManager rm;

        public Image backgroundImage;

        public SpriteSheet ss;

        public HashSet<Keys> PressedKeys = new HashSet<Keys>();

        public Bitmap worldImage;   // Буфер для отображения мира (общая карта, из которой камера будет отображать некоторую часть)


        public Rectangle clientRectangle;

        /////////////////////////////////////////////////////////

        public Scene curScene = null;

        public bool sceneChange = false;

        public Camera camera;


        // Запретить new
        private GameData()
        {
        }

        /// <summary>
        /// Получить единственный экземпляр данного класса
        /// </summary>
        public static GameData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameData();
                }
                return instance;
            }
        }
    }
}
