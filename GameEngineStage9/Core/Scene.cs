﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngineStage9.Core
{
    /// <summary>
    /// Базовый класс для описания игровой сцены
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// Уникальный идентификатор сцены
        /// </summary>
		public GameData.GameState ID;

        /// <summary>
		/// Список объектов на сцене
		/// </summary>
		public List<Entity> objects = new List<Entity>();

        public GameData gd;

        public Scene(GameData.GameState ID, GameData gd)
        {
            this.ID = ID;
            this.gd = gd;
        }

        virtual public void Init()
        {

        }

        virtual public void Render(Graphics g)
        {

        }

        virtual public void Update(int delta)
        {

        }

        virtual public void KeyDown(object sender, KeyEventArgs e)
        {
            // Добавить код клавиши в список нажатых клавиш
            gd.PressedKeys.Add(e.KeyCode);
        }

        virtual public void KeyUp(object sender, KeyEventArgs e)
        {
            // Удалить код клавиши из списка нажатых клавиш
            gd.PressedKeys.Remove(e.KeyCode);
        }

        virtual public void MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
