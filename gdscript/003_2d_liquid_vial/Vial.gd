extends RigidBody2D

export var fillPercent = 1.0;

export var maxFillShrinkAmount = Vector2(0, 2)
export var minFillShrinkAmount = Vector2(0, 4)

var vialHeight
var vialWidth

func _ready(): 
	vialWidth = $ReferenceRect.rect_size.x
	vialHeight = $ReferenceRect.rect_size.y

func _process(_delta: float) -> void:
	$LiquidSprite.global_rotation = 0

	var rotatedHeight = get_rotated_height()
	rotatedHeight = rotatedHeight.normalized()
	var shrinkPercent = abs(rotatedHeight.x) * abs(rotatedHeight.x)
	var maxHeightOffset = maxFillShrinkAmount * shrinkPercent
	var minHeightOffset = minFillShrinkAmount * shrinkPercent
	var adjustedMaxFill = $MaxFillPosition.position + maxHeightOffset
	var adjustedMinFill = $MinFillPosition.position - minHeightOffset

	$LiquidSprite.global_position = global_position
	$LiquidSprite.global_position += adjustedMaxFill.linear_interpolate(adjustedMinFill, 1 - fillPercent)

func get_rotated_height() -> Vector2:
	return (Vector2.UP * vialHeight).rotated(global_rotation)
