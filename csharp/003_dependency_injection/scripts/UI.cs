using Godot;

public class UI : Control
{
    public override void _Ready()
    {
        GetNode<Button>("HBoxContainer/NormalMovementButton").Connect("pressed", this, nameof(OnEnableButtonPressed));
        GetNode<Button>("HBoxContainer/DisableMovementButton").Connect("pressed", this, nameof(OnDisableButtonPressed));
        GetNode<Button>("HBoxContainer/ReverseMovementButton").Connect("pressed", this, nameof(OnReverseButtonPressed));
    }

    private void SetPlayerController(IPlayerController controller)
    {
        var players = GetTree().GetNodesInGroup("player");
        if (players.Count > 0 && players[0] is Player p)
        {
            p.SetController(controller);
        }
    }

    private void OnDisableButtonPressed()
    {
        SetPlayerController(new PlayerPlaceholderController());
    }

    private void OnEnableButtonPressed()
    {
        SetPlayerController(new PlayerMovementController());
    }

    private void OnReverseButtonPressed()
    {
        SetPlayerController(new PlayerReverseController());
    }
}