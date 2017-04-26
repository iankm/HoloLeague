using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeBoundary : MonoBehaviour {

    private GameObject red;
    private GameObject blue;
    private GameObject topwall;
    private GameObject bottomwall;
    private GameObject leftwall;
    private GameObject rightwall;
    private GameObject topborder;
    private GameObject bottomborder;
    private GameObject leftborder;
    private GameObject rightborder;
    private GameObject field;
    public float fieldWidthRatio;
    public float leeway;

    [HideInInspector]
    public Vector3 centerPos;
    [HideInInspector]
    public float fieldLength;
    [HideInInspector]
    public float fieldWidth;

    // Use this for initialization
    void Start () {
        red = GameObject.FindWithTag("redgate");
        blue = GameObject.FindWithTag("bluegate");

        topwall = GameObject.FindWithTag("topwall");
        bottomwall = GameObject.FindWithTag("bottomwall");
        leftwall = GameObject.FindWithTag("leftwall");
        rightwall = GameObject.FindWithTag("rightwall");

        topborder = GameObject.FindWithTag("topborder");
        bottomborder = GameObject.FindWithTag("bottomborder");
        leftborder = GameObject.FindWithTag("leftborder");
        rightborder = GameObject.FindWithTag("rightborder");

        field = GameObject.FindWithTag("field");
    }
	
	// Update is called once per frame
	void Update () {
        var bluepos = blue.transform.position;
        var redpos = red.transform.position;
        centerPos = 0.5f * blue.transform.position + 0.5f * red.transform.position;
        fieldLength = Vector3.Distance(bluepos, redpos) + leeway;
        fieldWidth = fieldLength * fieldWidthRatio;

        //Rescale
        topborder.transform.localScale = new Vector3(0.025f, 0.1f, fieldWidth);
        bottomborder.transform.localScale = new Vector3(0.025f, 0.1f, fieldWidth);
        leftborder.transform.localScale = new Vector3(fieldLength, 0.1f, 0.025f);
        rightborder.transform.localScale = new Vector3(fieldLength, 0.1f, 0.025f);

        topwall.transform.localScale = new Vector3(0.0f, 6, fieldWidth);
        bottomwall.transform.localScale = new Vector3(0.0f, 6, fieldWidth);
        leftwall.transform.localScale = new Vector3(fieldLength, 6, 0.0f);
        rightwall.transform.localScale = new Vector3(fieldLength, 6, 0.0f);

        field.transform.localScale = new Vector3(fieldLength, 0.0001f, fieldWidth);

        //Transform Position
        topborder.transform.position = new Vector3(centerPos.x + 0.5f * fieldLength, centerPos.y, centerPos.z);
        bottomborder.transform.position = new Vector3(centerPos.x - 0.5f * fieldLength, centerPos.y, centerPos.z);
        rightborder.transform.position = new Vector3(centerPos.x, centerPos.y, centerPos.z + 0.5f * fieldWidth);
        leftborder.transform.position = new Vector3(centerPos.x, centerPos.y, centerPos.z - 0.5f * fieldWidth);

        topwall.transform.position = new Vector3(centerPos.x + 0.5f * fieldLength, centerPos.y, centerPos.z);
        bottomwall.transform.position = new Vector3(centerPos.x - 0.5f * fieldLength, centerPos.y, centerPos.z);
        rightwall.transform.position = new Vector3(centerPos.x, centerPos.y, centerPos.z + 0.5f * fieldWidth);
        leftwall.transform.position = new Vector3(centerPos.x, centerPos.y, centerPos.z - 0.5f * fieldWidth);

        field.transform.position = centerPos;

        Debug.Log("Length: " + fieldLength);
        Debug.Log("Width: " + fieldWidth);
        Debug.Log("Scale: " + field.transform.localScale);
    }
}