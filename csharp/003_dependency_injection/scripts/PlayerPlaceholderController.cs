using Godot;

public class PlayerPlaceholderController : IPlayerController
{
    public Vector2 GetMovementVector()
    {
        return Vector2.Zero;
    }

    public bool IsJumpJustPressed()
    {
        return false;
    }
}