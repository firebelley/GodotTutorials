extends Camera2D

export var clearColor: Color

func _ready():
	VisualServer.set_default_clear_color(clearColor)
