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
	
	var diagonal = get_diagonal()
	diagonal = diagonal.normalized()
	var shrinkPercent = abs(diagonal.x) * abs(diagonal.x)
	var maxHeightOffset = maxFillShrinkAmount * shrinkPercent
	var minHeightOffset = minFillShrinkAmount * shrinkPercent
	var adjustedMaxFill = $MaxFillPosition.position + maxHeightOffset
	var adjustedMinFill = $MinFillPosition.position - minHeightOffset
	
#	$MaxFillPosition/Sprite.global_position = global_position + adjustedMaxFill
#	$MaxFillPosition/Sprite.global_rotation = 0
#
#	$MinFillPosition/Sprite.global_position = global_position + adjustedMinFill
#	$MinFillPosition/Sprite.global_rotation = 0
	
	$LiquidSprite.global_position = global_position
	$LiquidSprite.global_position += adjustedMaxFill.linear_interpolate(adjustedMinFill, 1 - fillPercent)

func get_diagonal() -> Vector2:
	var right = (Vector2.RIGHT * vialWidth).rotated(global_rotation)
	var up = (Vector2.UP * vialHeight).rotated(global_rotation)
	
	return right + up
