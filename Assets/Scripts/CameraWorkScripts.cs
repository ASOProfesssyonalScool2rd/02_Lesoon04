using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraWorkScripts : MonoBehaviour
{
    [Serializable] 
    public class Parametor
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
        
    }

    private void LateUpdate()
    {
        if (_parent == null || _child == null || _camera == null)
        {
            return;
        }

        if (_parametor.trackTarget != null)
        {
            _parametor.position = Vector3.Lerp(_parametor.position, _parametor.trackTarget.position,Time.deltaTime *4f);
        }

        _parent.position = _parametor.position;
    }
}
