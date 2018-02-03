    //--- Shoot Function ---//

    //All PSO.Something are configuration variable stored in a ScriptableObject. 
    //This handle default values in case of the configuration file is missing. 
    private float NextFire; 
    public void Fire(){

        if (Input.GetButton("Fire1") && Time.time > NextFire){
            if (PSO.Projectile_To_Shoot == null){
                Debug.Log("The current GameObject 'ProjectileToShoot' is Empty, please fix that");
            }
            else {
                var bullet = Instantiate(PSO.Projectile_To_Shoot, Rb2d.transform.position, Rb2d.transform.rotation); //Create an instance of the projectile//

                if(bullet.GetComponent<ShootBehavior>()){                                                              //This get the basic shoot behavior that is attached to every projectile.
                    bullet.GetComponent<ShootBehavior>().DestroyAfterSeconds = PSO.Destroy_Projectile_After_Seconds;   //And set his "time of life" to the one given in the config file//
                    bullet.GetComponent<ShootBehavior>().InitializeBullet();                                           //Then initialize the state of the projectile through a function.
                }

                if (!bullet.GetComponent<Rigidbody2D>()){ //If the Rigidbody is missing from the prefab, create one and set his gravity to 0. (Totaly useless for me, should remove that later).
                    bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                }
                bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * PSO.FireSpeed); //Add speed to the projectile//

                if(PSO.FireRate != 0){                   //If the FireRate is set to 0 (default value if the config file is missing). Set a new value to 0.5F. Prevent the 60 shoots in a seconds thing.
                NextFire = Time.time + PSO.FireRate;     //This is a timer, so the player can't launch 60 projectiles per seconds. 
                }
                else if (PSO.FireRate == 0){
                    PSO.FireRate = 0.5F;
                    Debug.Log("The Firerate wasn't set, the default value is applied (0.5F)");
                }
            }
        }
    }
}
  


