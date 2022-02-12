class_name HitboxComponent
extends Area2D

signal hit_with_bullet(bullet)
signal hit(otherArea)

func _ready():
	connect("area_entered", self, "on_area_entered")

func on_area_entered(otherArea: Area2D):
	if otherArea.owner is BulletComponent:
		emit_signal("hit_with_bullet", otherArea.owner)
	else:
		emit_signal("hit", otherArea)
