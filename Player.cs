using Raylib_cs;

public class Player : GameObject
{
    public Player(int x, int y) : base(x, y, 50, 10, "P", 0) {}

    public void Movement()
    {
        if(Raylib.IsKeyDown(KeyboardKey.Left) && _x > 0) _x -= 10;
        if(Raylib.IsKeyDown(KeyboardKey.Right) && _x < GameManager.SCREEN_WIDTH - _width) _x += 10;
    }

    public override void Draw()
    {
        if (_showObject == true)
        {
            Raylib.DrawRectangle(_x,_y, 50, 10, Color.Blue);
        }
    }

}