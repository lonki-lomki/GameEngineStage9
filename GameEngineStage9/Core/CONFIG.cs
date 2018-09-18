﻿namespace GameEngineStage9.Core
{
    class CONFIG
    {
        // Размер окна программы
        public static readonly int WIND_WIDTH = 1024;
        public static readonly int WIND_HEIGHT = 600;

        // Размер тайла
        public static readonly int TILE_SIZE = 48;

        public static readonly int PANEL_HEIGHT = 30; // Высота верхней панели

        // Координата начала игрового поля
        public static readonly int START_X = 2;
        public static readonly int START_Y = PANEL_HEIGHT + 2;

        //public static readonly int VIEWPORT_WIDTH = 1010;
        //public static readonly int VIEWPORT_HEIGHT = 534;

        public static readonly float PHYS_GRAVITY = 500.0f; //1000.0f;//1.1f; //5.0f; // Гравитация для физ. движка

        public static readonly float MAX_ENG_POWER = 5.0f;  // Максимальная мощность двигателя

    }
}
