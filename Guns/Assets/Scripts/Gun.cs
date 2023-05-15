    using System;
    using System.Collections;
    using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
    using UnityEngine.UI;

public class Gun : MonoBehaviour {

        [Header("References")]
        [SerializeField] private GunData gunData;
        [SerializeField] private Transform cam;
        public ParticleSystem muzzleFlash;
        float timeSinceLastShot;
        private AudioManager audioManager;
        public Text bullets;

        private void Awake() {
            PlayerShoot.shootInput += Shoot;
            PlayerShoot.reloadInput += StartReload;
            audioManager = FindObjectOfType<AudioManager>();
        }
        

        private void OnDisable() => gunData.reloading = false;

        public void StartReload() {
            if (!gunData.reloading && this.gameObject.activeSelf)
                StartCoroutine(Reload());
        }

        private IEnumerator Reload() {
            gunData.reloading = true;

            yield return new WaitForSeconds(gunData.reloadTime);

            gunData.currentAmmo = gunData.magSize;

            gunData.reloading = false;
        }

        private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

        private void Shoot() {
            if (gunData.currentAmmo > 0) {
                if (CanShoot()) {

                    if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance)){
                        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
                        Debug.Log(hitInfo.transform.gameObject.name);
                        Debug.Log(hitInfo.collider);

                    damageable?.TakeDamage(gunData.damage);
                    
                    }
                        muzzleFlash.Play();
                        if (!audioManager.IsPlaying("fight"))
                        {
                            audioManager.Play("fight");
                        }
                    gunData.currentAmmo--;
                    timeSinceLastShot = 0;
                    OnGunShot();
                }
            }
        }

        private void Update() {
            timeSinceLastShot += Time.deltaTime;
            Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);
            bullets.text="Bullet: "+ gunData.currentAmmo;
        }

        private void OnGunShot() {  }
    }
