using System;
using Godot;

public class Demo : Control
{
    private Button _plusButton;
    private Button _minusButton;
    private CheckBox _checkBox;
    private Button _addButton;
    private ItemList _itemList;
    private Label _countLabel;

    public override void _Ready()
    {
        _plusButton = GetNode("VBoxContainer/HBoxContainer/Button") as Button;
        _minusButton = GetNode("VBoxContainer/HBoxContainer/Button2") as Button;
        _countLabel = GetNode("VBoxContainer/HBoxContainer/Label") as Label;
        _checkBox = GetNode("VBoxContainer/HBoxContainer2/CheckBox") as CheckBox;
        _addButton = GetNode("VBoxContainer/Button") as Button;
        _itemList = GetNode("VBoxContainer/ItemList") as ItemList;

        _plusButton.Connect("pressed", this, nameof(OnCountChange), new object[] { 1 });
        _minusButton.Connect("pressed", this, nameof(OnCountChange), new object[] {-1 });
        _addButton.Connect("pressed", this, nameof(OnAddGuid));
        _checkBox.Connect("toggled", this, nameof(OnCheckboxToggled));

        Initialize();
    }

    public override void _Notification(int notification)
    {
        // Save on quit. Note that you can call `DataManager.Save()` whenever you want
        if (notification == MainLoop.NotificationWmQuitRequest)
        {
            DataManager.Save();
            GetTree().Quit();
        }
    }

    private void Initialize()
    {
        UpdateCountLabel();
        UpdateGuidList();
        UpdateChecked();
    }

    private void UpdateCountLabel()
    {
        _countLabel.Text = $"{DataManager.GetCount()}";
    }

    private void UpdateGuidList()
    {
        _itemList.Clear();
        foreach (var guid in DataManager.GetGuids())
        {
            _itemList.AddItem(guid.ToString());
        }
    }

    private void UpdateChecked()
    {
        _checkBox.Pressed = DataManager.GetChecked();
    }

    private void OnCountChange(int change)
    {
        DataManager.AddCount(change);
        UpdateCountLabel();
    }

    private void OnAddGuid()
    {
        DataManager.AddGuid(Guid.NewGuid());
        UpdateGuidList();
    }

    private void OnCheckboxToggled(bool pressed)
    {
        DataManager.SetChecked(pressed);
    }

}