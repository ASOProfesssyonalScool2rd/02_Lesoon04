using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class CameraWorkScripts : MonoBehaviour
{
    [Serializable] 
    public class Parametor　　　//パラメータを設定
    {

        public Transform trackTarget;
        public Vector3 position;
        public Vector3 angles = new Vector3(10f, 0f, 0f);
        public float distance = 7f;
        public float fied0fView = 45;
        public Vector3 offsetPosition = new Vector3(0f, 1f, 0f);        
        public Vector3 offsetAngles;
    }

    [SerializeField] private Transform _parent;
    
    [SerializeField] private Transform _child;
    
    [SerializeField] private Camera _camera;
    
    [SerializeField] private Parametor _parametor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 30;
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log("HeloWold!! > "+ mouseWheel);
        //パラメータに設定
        _parametor.distance += mouseWheel * 20f;
        //マウスのX軸・Y軸の移動量を取得
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        //回転
        _parametor.angles.x += mouseY;
        _parametor.angles.x += mouseX;
    }
    private void LateUpdate()
    {
        if(false)return;
        if (_parent == null || _child == null || _camera == null)
        {
            return;
        }

        if (_parametor.trackTarget != null)
        {
            _parametor.position = Vector3.Lerp(_parametor.position, _parametor.trackTarget.position,Time.deltaTime *4f);
        }
          //親の座標と回転を更新
          _parent.position = _parametor.position;
        _parent.eulerAngles = _parametor.angles;
        //子の座標と回転を更新
        var childPos = _child.localPosition;
        childPos.z = -_parametor.distance;
        _child.localPosition = childPos;
        //カメラの座標と回転を更新
        _camera.fieldOfView = _parametor.fied0fView;
        _camera.transform.localPosition = _parametor.offsetPosition;
        _camera.transform.localEulerAngles = _parametor.offsetAngles;
        
    }
}
