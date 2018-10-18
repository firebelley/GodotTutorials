using Godot;

public class KeybindInput : HBoxContainer
{
    [Export]
    private string _labelText;
    [Export]
    private string _inputMapKey;

    private Label _labelNode;
    private LineEdit _lineEditNode;
    private Button _resetButtonNode;

    public override void _Ready()
    {
        _labelNode = GetNode("Label") as Label;
        _lineEditNode = GetNode("LineEdit") as LineEdit;
        _resetButtonNode = GetNode("ResetButton") as Button;

        _lineEditNode.Text = InputHelper.GetFirstEventKeyText(_inputMapKey);

        _labelNode.Text = _labelText;

        _lineEditNode.Connect("gui_input", this, nameof(OnGuiInput));
        _resetButtonNode.Connect("pressed", this, nameof(OnResetButtonPressed));
    }

    private void OnGuiInput(InputEvent ev)
    {
        if (ev is InputEventKey e)
        {
            InputHelper.EraseActionEvents(_inputMapKey);
            InputMap.ActionAddEvent(_inputMapKey, ev);
            _lineEditNode.Text = InputHelper.GetKeyText(e);
            AcceptEvent();
        }
    }

    private void OnResetButtonPressed()
    {
        InputHelper.EraseActionEvents(_inputMapKey);
        var ev = InputHelper.GetDefaultInputEvent(_inputMapKey);
        InputMap.ActionAddEvent(_inputMapKey, ev);
        _lineEditNode.Text = InputHelper.GetKeyText(ev as InputEventKey);
    }

}