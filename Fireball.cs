using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector_Motion_and_Angle_Tutorial
{
    public class Fireball
    {
        private Texture2D _texture;
        private Rectangle _rect;
        private Vector2 _location;
        private Vector2 _direction;
        private float _speed;
        private int _size;

        public Fireball(Texture2D texture, Vector2 location, Vector2 target, int size)
        {
            _size = size;
            _texture = texture;
            _location = location;
            _rect = new Rectangle(location.ToPoint(), new Point(_size, _size));
            _direction = target - location;
            _direction.Normalize();
            _speed = 5f;
        }

        // Allows read access to the location Rectangle for collision detection
        public Rectangle Rect
        {
            get { return _rect; }
        }

        public void Update()
        {
            _location += _direction * _speed;
            _rect.Location = _location.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rect, Color.White);
        }
    }
}
