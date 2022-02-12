class_name BulletComponent
extends Node2D

export var speed: float
export var damage: float = 1

var direction = Vector2.ZERO

func _ready():
	$HitboxComponent.connect("hit", self, "on_hit")

func _process(delta):
	global_position += direction.normalized() * speed * delta

func on_hit(_otherArea):
	queue_free()
