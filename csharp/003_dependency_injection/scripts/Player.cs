using Godot;

public class Player : KinematicBody2D
{
    private const float SPEED = 100f;

    private IPlayerController _controller;

    public override void _Ready()
    {
        _controller = new PlayerMovementController();
    }

    public override void _Process(float delta)
    {
        var velocity = _controller.GetMovementVector();
        MoveAndSlide(velocity * SPEED);

        if (_controller.IsJumpJustPressed())
        {
            GlobalPosition += Vector2.Up * 25f;
        }
    }

    public void SetController(IPlayerController controller)
    {
        _controller = controller;
    }
}