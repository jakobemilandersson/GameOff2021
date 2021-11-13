using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKMovement : MonoBehaviour
{

    public Transform[] legTargets;

    public Transform[] bodyTargets;

    public Transform body;
    public Vector3 bodyOffset;

    public float stretch = 0.3f;
    public float smoothness = 0.5f;
    public float timeBetweenLegMovement = 0.1f;

    private Vector3[] defaultLegPositions;
    private Vector3[] lastLegPositions;
    private float[] lastBodyTargetsDistance;
    private bool[] legMoving;
    private int nbLegs;
    private float stepLength = 1f;
    private Vector3 Offset;

    private bool grounded = false;
    void Start()
    {
        Offset = new Vector3(0, stepLength, 0);
        nbLegs = legTargets.Length;
        defaultLegPositions = new Vector3[nbLegs];
        lastLegPositions = new Vector3[nbLegs];
        lastBodyTargetsDistance = new float[nbLegs];
        legMoving = new bool[nbLegs];
        RaycastHit hit;
        for (int i = 0; i < nbLegs; ++i)
        {
            defaultLegPositions[i] = legTargets[i].localPosition;
            lastLegPositions[i] = legTargets[i].position;
            legMoving[i] = false;

            bodyTargets[i].position += Offset;
            Physics.Raycast(bodyTargets[i].position, bodyTargets[i].TransformDirection(Vector3.down), out hit, Mathf.Infinity);
            lastBodyTargetsDistance[i] = hit.distance;
        }
        Offset = new Vector3(0, stepLength, 0);
    }

    void FollowGround() {
        RaycastHit hit;
        for (int i = 0; i < nbLegs; ++i) {
            if (Physics.Raycast(bodyTargets[i].position, bodyTargets[i].TransformDirection(Vector3.down), out hit, Mathf.Infinity)) {
                Debug.DrawRay(bodyTargets[i].position, bodyTargets[i].TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                bodyTargets[i].position = bodyTargets[i].position - new Vector3(0, hit.distance-lastBodyTargetsDistance[i], 0);
            }
        }
    }

    void DrawDistanceLines() {
        for (int i = 0; i < nbLegs; i++) {
            if (Vector3.Distance(legTargets[i].position, bodyTargets[i].position - Offset) < stretch) {
                Debug.DrawLine(legTargets[i].position, bodyTargets[i].position - Offset, Color.green);
            }
            else {
                Debug.DrawLine(legTargets[i].position, bodyTargets[i].position - Offset, Color.red);
            }
        }
    }

    IEnumerator MoveLegs() {
        for (int i = 0; i < nbLegs; i++) {
            if (Vector3.Distance(legTargets[i].position, bodyTargets[i].position - Offset) > stretch) {

                legMoving[i] = true;
                lastLegPositions[i] = Vector3.Lerp(lastLegPositions[i], bodyTargets[i].position - Offset, smoothness);

                yield return new WaitForSeconds(timeBetweenLegMovement);
            }
        }
    }

    private void Update() {
        FollowGround();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        DrawDistanceLines();
        StartCoroutine(MoveLegs());

        for (int i = 0; i < nbLegs; ++i) {
            legTargets[i].position = lastLegPositions[i];
        }

    }
}
