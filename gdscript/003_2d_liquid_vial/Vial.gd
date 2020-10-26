extends RigidBody2D

export var fillPercent = .5;

var vialWidth;
var vialHeight;
var fillHeightDifference;

func _ready() -> void:
	vialWidth = $ReferenceRect.rect_size.x
	vialHeight = $ReferenceRect.rect_size.y
	fillHeightDifference = ($MaxFillPosition.position - $MinFillPosition.position).abs().y

func _process(delta: float) -> void:
	$LiquidSprite.global_rotation = 0
	
	var maxFillPosition = global_position + $MaxFillPosition.position;
	var newGlobalPos = maxFillPosition + Vector2(0, fillHeightDifference * (1 - fillPercent))
	$LiquidSprite.global_position = newGlobalPos

func get_real_height():
	var newXVect = (Vector2.RIGHT * vialWidth).rotated(global_rotation)
	var newYVect = (Vector2.UP * vialHeight).rotated(global_rotation)
	
	return abs(newXVect.y) + abs(newYVect.y)
