using Godot;

public class PlayerMovementController : IPlayerController
{
    // Can also use a concrete implementation like this to make device-specific input checks

    private const string INPUT_MOVE_LEFT = "move_left";
    private const string INPUT_MOVE_RIGHT = "move_right";
    private const string INPUT_MOVE_UP = "move_up";
    private const string INPUT_MOVE_DOWN = "move_down";
    private const string INPUT_JUMP = "jump";

    public Vector2 GetMovementVector()
    {
        var movementVector = new Vector2();
        movementVector.x = Input.GetActionStrength(INPUT_MOVE_RIGHT) - Input.GetActionStrength(INPUT_MOVE_LEFT);
        movementVector.y = Input.GetActionStrength(INPUT_MOVE_DOWN) - Input.GetActionStrength(INPUT_MOVE_UP);
        movementVector = movementVector.Normalized();
        return movementVector;
    }

    public bool IsJumpJustPressed()
    {
        return Input.IsActionJustPressed(INPUT_JUMP);
    }
}