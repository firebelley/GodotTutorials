extends Node2D

export var bulletScene : PackedScene

func _ready():
	pass # Replace with function body.

func _unhandled_input(event):
	if (event.is_action_pressed("fire")):
		var bullet = bulletScene.instance() as Node2D
		get_parent().add_child(bullet)
		bullet.global_position = self.global_position
		bullet.direction = (get_global_mouse_position() - global_position).normalized()
		bullet.rotation = bullet.direction.angle()
