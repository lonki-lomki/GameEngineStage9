using GameEngineStage9.Utils;
using System.Drawing;

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

        //public PhysWorld world;

        public Logger log;

        public Rectangle clientRectangle;

        /////////////////////////////////////////////////////////


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
