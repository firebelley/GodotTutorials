extends Node2D

func _ready():
	$HealthComponent.connect("health_changed", self, "on_health_changed")
	$HitboxComponent.connect("hit_with_bullet", self, "on_hit_with_bullet")

func on_health_changed(newVal: float):
	if (newVal <= 0):
		queue_free()

func on_hit_with_bullet(bullet: BulletComponent):
	$HealthComponent.apply_damage(bullet.damage)
