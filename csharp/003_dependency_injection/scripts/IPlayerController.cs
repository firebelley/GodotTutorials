using Godot;

public interface IPlayerController
{
    Vector2 GetMovementVector();
    bool IsJumpJustPressed();
}