extends CenterContainer


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	if OS.has_feature("steam"):
		$Label.text = "This is Steam"
	elif OS.has_feature("itch"):
		$Label.text = "This is Itch"


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
