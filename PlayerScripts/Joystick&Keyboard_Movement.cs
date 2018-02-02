	//Move the player in the X and Y axis. for Keyboard and Gamepad.
    public void SetPlayerDirection(){
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        Rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                           Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
  


