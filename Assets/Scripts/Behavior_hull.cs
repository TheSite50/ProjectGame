using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_hull : MonoBehaviour
{
    [SerializeField] PlayerMovementScript player;
    [SerializeField] private so_hull HullParams;
    [SerializeField]public float hullRotationSpeed = 5;
    private Transform cameraTransform;

    [Header("Weapon")]
    bool raycast;

    #region Unity Functions
    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }
    private void LateUpdate()
    {
        //LookDirection();
        WhereLookLocation();
        HandleTurretRotation();
        
    }
    #endregion
    #region Turret Aiming
    public Vector3 WhereLookLocation()//yellow raycast z kamery który nakierowuje mecha gdzie ma patrzeæ
    {
        raycast = Physics.Raycast(transform.position, transform.forward, out RaycastHit cameraLookAtPoint, 500);
        Debug.DrawRay(transform.position, transform.forward * 500, Color.red);
        if (raycast)
        {
            return cameraLookAtPoint.point;
        }
        return transform.forward * 500;
    }
    private void HandleTurretRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        //Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x, cameraTransform.eulerAngles.y, 0);//odjêcie i dodanie pozycji zwiêksza odleg³oœæi celownika od œrodka ekranu
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, hullRotationSpeed * Time.deltaTime);
    }
    #endregion

    #region Additional Functions
    public bool GetRaycast => raycast;
    #endregion


}
