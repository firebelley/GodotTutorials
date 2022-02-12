extends Node2D

export var bulletScene: PackedScene
export var bulletInterval: float

func _ready():
	$Timer.connect("timeout", self, "on_timer_timeout")
	$Timer.wait_time = bulletInterval
	$Timer.start()

func on_timer_timeout():
	var bulletNode = bulletScene.instance() as BulletComponent
	bulletNode.direction = Vector2.UP
	get_parent().add_child(bulletNode)
	$Timer.start()
