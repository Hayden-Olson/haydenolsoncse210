using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using Raylib_cs;

class GameManager
{
    public static int SCREEN_WIDTH = 800;
    public static int SCREEN_HEIGHT = 600;

    private string _title;
    private List<GameObject> _gameObjects = new List<GameObject>();
    private Player p;
    private Treasure t1;
    private Treasure t2;
    private Treasure t3;
    private Treasure t4;
    private Treasure t5;
    private Bomb b1;
    private Bomb b2;
    private Bomb b3;
    private Bomb b4;
    private Bomb b5;
    private int _points = 0;
    private int _lives = 3;
    

    public GameManager()
    {
        _title = "CSE 210 Game";
    }

    /// <summary>
    /// The overall loop that controls the game. It calls functions to
    /// handle interactions, update game elements, and draw the screen.
    /// </summary>
    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        // If using sound, un-comment the lines to init and close the audio device
        // Raylib.InitAudioDevice();

        InitializeGame();

        while (!Raylib.WindowShouldClose())
        {
            HandleInput();
            ProcessActions();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            DrawElements();

            Raylib.EndDrawing();
        }

        // Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Sets up the initial conditions for the game.
    /// </summary>
    private void InitializeGame()
    {
        p = new Player(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 50);
        t1 = new Treasure(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(1,10), new Random().Next(3,7));
        t2 = new Treasure(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(1,10), new Random().Next(3,7));
        t3 = new Treasure(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(1,10), new Random().Next(3,7));
        t4 = new Treasure(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(1,10), new Random().Next(3,7));
        t5 = new Treasure(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(1,10), new Random().Next(3,7));
        b1 = new Bomb(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(3,7));
        b2 = new Bomb(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(3,7));
        b3 = new Bomb(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(3,7));
        b4 = new Bomb(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(3,7));
        b5 = new Bomb(new Random().Next(0,SCREEN_WIDTH), 0, new Random().Next(3,7));
        
        _gameObjects.Add(p);
        _gameObjects.Add(t1);
        _gameObjects.Add(t2);
        _gameObjects.Add(t3);
        _gameObjects.Add(t4);
        _gameObjects.Add(t5);
        _gameObjects.Add(b1);
        _gameObjects.Add(b2);
        _gameObjects.Add(b3);
        _gameObjects.Add(b4);
        _gameObjects.Add(b5);
    }

    /// <summary>
    /// Responds to any input from the user.
    /// </summary>
    private void HandleInput()
    {
        p.Movement();
    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions.
    /// </summary>
    private void ProcessActions()
    {
        
        b1.Gravity();
        b2.Gravity();
        b3.Gravity();
        b4.Gravity();
        b5.Gravity();
        t1.Gravity();
        t2.Gravity();
        t3.Gravity();
        t4.Gravity();
        t5.Gravity();
    
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            for (int j = i + 1; j < _gameObjects.Count; j++)
            {
                GameObject first = _gameObjects[i];
                GameObject second = _gameObjects[j];

                if (IsCollision(first, second))
                {
                    if (first.GetGameObjectType() == "P")
                    {
                        if (second.GetGameObjectType() == "T")
                        {
                            _points += second.GetValue();
                        }
                        else
                        {
                            _lives--;
                        }
                    }
                   
                    second.SetNewPosition(new Random().Next(0,SCREEN_WIDTH), 0);
                    second.SetSpeed(new Random().Next(3,7));
                    second.SetValue(new Random().Next(1,10));
                }
            }
            if (_gameObjects[i].GetY() > SCREEN_HEIGHT)
            {
                _gameObjects[i].SetNewPosition(new Random().Next(0,SCREEN_WIDTH), 0);
                _gameObjects[i].SetSpeed(new Random().Next(3,7));
                _gameObjects[i].SetValue(new Random().Next(1,10));
            }
        }
       if (_lives == 0)
       {
            _gameObjects.Remove(p);
       }
    }

    private bool IsCollision(GameObject first, GameObject second)
    {
        bool isHit = false;
        if (first.GetRightEdge() >= second.GetLeftEdge() && first.GetLeftEdge() <= second.GetRightEdge() && first.GetBottomEdge() >= second.GetTopEdge() && first.GetTopEdge() <= second.GetBottomEdge())
        {
            if (first == p || second == p)
            {
                isHit = true;
            }
         
        }
        return isHit;
    }

    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements()
    {
        Raylib.DrawText($"Score: {_points}", 10, 10, 25, Color.Black);
        Raylib.DrawText($"Lives: {_lives}", 10, 40, 25, Color.Black);
        // Raylib.DrawText($"Player position: {_gameObjects[0].GetX()}, {_gameObjects[0].GetY}", 10, 80, 25, Color.Black);
        // Raylib.DrawText($"Player edges: {_gameObjects[0].GetLeftEdge()}/{_gameObjects[0].GetRightEdge()}, {_gameObjects[0].GetBottomEdge()}/{_gameObjects[0].GetTopEdge()}", 10, 110, 25, Color.Black);

        foreach (GameObject item in _gameObjects)
        {
            item.Draw();
        }
    }
}