extends Node

signal health_changed(newValue)
signal health_depleted()

export var health: float = 5

func apply_damage(damage: float):
	health = clamp(health - damage, 0, health)
	emit_signal("health_changed", health)
	if (health <= 0):
		emit_signal("health_depleted")

func heal(heal: float):
	pass
