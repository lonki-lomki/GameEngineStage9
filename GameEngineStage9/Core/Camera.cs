﻿using System.Drawing;

namespace GameEngineStage9.Core
{
    /// <summary>
    /// Класс, описывающий камеру, через которую будет отображаться часть игрового мира
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// Геометрия камеры (расположение на экране и размер)
        /// </summary>
        private Rectangle geometry;

        private GameData gd;

        /// <summary>
        /// "Точка зрения камеры" - привязка левым верхним углом к "мировым" координатам
        /// </summary>
        private Point pointOfView;


        public Camera(Rectangle geom)
        {
            Geometry = new Rectangle(geom.Location, geom.Size);
            pointOfView = new Point(0, 0);
            gd = GameData.Instance;
        }

        /// <summary>
        /// Сеттер и геттер для поля geometry
        /// </summary>
        public Rectangle Geometry { get => geometry; set => geometry = value; }

        /// <summary>
        /// Отображение части игрового мира, который попадает в поле зрения камеры
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g)
        {
            // Вывести часть тайловой карты, которая попадает в поле зрения камеры
            //g.DrawImage(gd.tmo.image, new Rectangle(geometry.X, geometry.Y, geometry.Width, geometry.Height), new Rectangle(pointOfView, new Size(CONFIG.VIEWPORT_WIDTH, CONFIG.VIEWPORT_HEIGHT)), GraphicsUnit.Pixel);


            // Лист для отрисовки объектов
            //Graphics gg = Graphics.FromImage(gd.worldImage);
            //gg.CompositingMode = CompositingMode.SourceCopy;
            //gg.CompositingMode = CompositingMode.SourceOver;
            //gg.InterpolationMode = InterpolationMode.NearestNeighbor;
            // Очистить прозрачным цветом
            //gg.Clear(Color.Transparent);

            //...Нарисовать объекты в мировых координатах и вывести часть, попадающую в область видимости камеры

            // Цикл отображения всех объектов на всех уровнях
            // Цикл по уровням (пока 3 уровня)
            //!!!!!!!! ДЛЯ ЭТОЙ ИГРЫ ОТРИСОВАТЬ ДВА КРАЙНИХ УРОВНЯ. СРЕДНИЙ УРОВЕРЬ ОТРИСОВЫВАЕТСЯ В ЛАНДШАФТЕ!!!!!!!
            /*
            for (int i = 0; i < 3; i++)
            {
                foreach (Entity ent in gd.world.objects)
                {
                    if (ent.GetLayer() == i)
                    {
                        ent.Render(g);
                    }
                }
            }
            */
            foreach (Entity ent in gd.world.objects)
            {
                if (ent.GetLayer() == 0)
                {
                    ent.Render(g);
                }
            }

            // Отрисовка ландшафта
            //gd.landshaft.Render(g);

            foreach (Entity ent in gd.world.objects)
            {
                if (ent.GetLayer() == 2)
                {
                    ent.Render(g);
                }
            }


            //gg.Dispose();

            // Вывести часть слоя с объектами, которая попадает в поле зрения камеры
            //g.DrawImage(gd.worldImage, new Rectangle(geometry.X, geometry.Y, geometry.Width, geometry.Height), new Rectangle(pointOfView, new Size(CONFIG.VIEWPORT_WIDTH, CONFIG.VIEWPORT_HEIGHT)), GraphicsUnit.Pixel);
            /////g.DrawImage(gd.worldImage, new Rectangle(geometry.X, geometry.Y, geometry.Width, geometry.Height), new Rectangle(pointOfView, new Size(geometry.Width, geometry.Height)), GraphicsUnit.Pixel);

            // Нарисовать границы области видимости игрового поля
            g.DrawRectangle(Pens.LightGreen, Geometry.X, Geometry.Y, Geometry.Width, Geometry.Height);

        }
    }
}
