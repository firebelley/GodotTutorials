using System.Collections.Generic;
using System.Linq;
using Godot;

public static class InputHelper
{
    public const string ACTION_JUMP = "jump";
    public const string ACTION_ATTACK = "attack";

    private static string[] Actions = {
        ACTION_ATTACK,
        ACTION_JUMP
    };

    private static Dictionary<string, List<InputEvent>> _defaultKeybinds = new Dictionary<string, List<InputEvent>>();

    static InputHelper()
    {
        InitDefaultKeybinds();
    }

    public static void EraseActionEvents(string key)
    {
        var actions = InputMap.GetActionList(key);
        foreach (var obj in actions)
        {
            var ev = obj as InputEvent;
            if (InputMap.HasAction(key))
            {
                InputMap.ActionEraseEvent(key, ev);
            }
        }
    }

    public static string GetKeyText(InputEventKey ev)
    {
        return OS.GetScancodeString(ev.GetScancode());
    }

    public static string GetFirstEventKeyText(string key)
    {
        var actions = InputMap.GetActionList(key);
        var ev = actions[0] as InputEvent;
        if (ev is InputEventKey e)
        {
            return GetKeyText(e);
        }
        return string.Empty;
    }

    public static Dictionary<string, List<int>> GetActionScancodesDictionary()
    {
        var dict = new Dictionary<string, List<int>>();
        foreach (var action in Actions)
        {
            var scancodes = InputMap.GetActionList(action)
                .Where(x => x is InputEventKey)
                .Select(x =>(x as InputEventKey).Scancode)
                .ToList();
            dict.Add(action, scancodes);
        }
        return dict;
    }

    public static void SetActionScancodes(Dictionary<string, List<int>> actionScancodes)
    {
        foreach (var key in actionScancodes.Keys)
        {
            EraseActionEvents(key);
            var scancodes = actionScancodes[key];
            foreach (var scancode in scancodes)
            {
                var keyEvent = new InputEventKey();
                keyEvent.Scancode = scancode;
                InputMap.ActionAddEvent(key, keyEvent);
            }
        }
    }

    public static InputEvent GetDefaultInputEvent(string action)
    {
        return _defaultKeybinds[action].Count > 0 ? _defaultKeybinds[action][0] as InputEvent : null;
    }

    private static void InitDefaultKeybinds()
    {
        foreach (var action in Actions)
        {
            var inputEvents = InputMap.GetActionList(action).Select(x => x as InputEvent).ToList();
            _defaultKeybinds.Add(action, inputEvents);
        }
    }

}