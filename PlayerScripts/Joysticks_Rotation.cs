	//Move the player with the Right Joystick. With a little Smooth effect.
    public void SetPlayerRotationGamepad(){

        float JoystickX = Input.GetAxis("JoystickX");
        float JoystickY = Input.GetAxis("JoystickY");

        if ((JoystickX != 0) || (JoystickY != 0F)) {                   //If Joysticks are used ; Do some complicated things.
        float heading = Mathf.Atan2(JoystickX, JoystickY);              
        Quaternion TowardThatPosition = Quaternion.Euler(0.0F, 0.0F, heading * Mathf.Rad2Deg);
        Quaternion FinalLerpedQuaternion = Quaternion.Lerp(Rb2d.transform.rotation, TowardThatPosition, 0.25F);

        transform.rotation = FinalLerpedQuaternion;
        }
    }
  


