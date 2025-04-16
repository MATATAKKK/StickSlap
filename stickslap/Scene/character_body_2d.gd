extends CharacterBody2D

const SPEED = 200.0
const SPEED_JUMP = -500.0

func  _physics_process(delta):
	if not is_on_floor():
		velocity.y += 1000 * delta
	elif Input.is_action_just_pressed("ui_accept"):
		velocity.y = SPEED_JUMP
	
	var direction = Input.get_axis("ui_left", "ui_right")
	velocity.x = direction * SPEED
	
	
	move_and_slide()
