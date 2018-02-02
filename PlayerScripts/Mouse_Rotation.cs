	//Mouve the player toward the mouse position.
	public void SetPlayerRotationMouse(){

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90;
        Quaternion RotateQuaternion = Quaternion.Euler(0f, 0f, rotation_z + 0.0F);
        Quaternion FinalLerpedQuaternion = Quaternion.Lerp(transform.rotation, RotateQuaternion, 0.25F);

        transform.rotation = FinalLerpedQuaternion;
    }
  


