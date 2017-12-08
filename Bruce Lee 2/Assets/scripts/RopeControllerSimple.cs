using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//If we have a stiff rope, such as a metal wire, then we need a simplified solution
//this is also an accurate solution because a metal wire is not swinging as much as a rope made of a lighter material
public class RopeControllerSimple : MonoBehaviour
{
    //Objects that will interact with the rope
    public Transform whatTheRopeIsConnectedTo;
    public Transform whatIsHangingFromTheRope;

    public float RopeWidht;

    //Line renderer used to display the rope
    private LineRenderer lineRenderer;

    //A list with all rope sections
    public List<Vector3> allRopeSections = new List<Vector3>();

    //Rope data
    private float ropeLength = 1f;
    private float minRopeLength = 1f;
    private float maxRopeLength = 20f;
    //Mass of what the rope is carrying
    private float loadMass = 100f;

    private bool started = false;
    private bool closed = false;
    //How fast we can add more/less rope
    float winchSpeed = 2f;

    //The joint we use to approximate the rope
    SpringJoint springJoint;

    void Start()
    {
        RopeWidht = 0.02f;

        springJoint = whatTheRopeIsConnectedTo.GetComponent<SpringJoint>();

        //Init the line renderer we use to display the rope
        lineRenderer = GetComponent<LineRenderer>();


        //Init the spring we use to approximate the rope from point a to b
        UpdateSpring();

        //Add the weight to what the rope is carrying
        whatIsHangingFromTheRope.GetComponent<Rigidbody>().mass = loadMass;
    }



    void Update()
    {
        //Add more/less rope
        UpdateWinch();

        //Display the rope with a line renderer
        DisplayRope();

    }

    //Update the spring constant and the length of the spring
    private void UpdateSpring()
    {
        //Someone said you could set this to infinity to avoid bounce, but it doesnt work
        //kRope = float.inf

        //
        //The mass of the rope
        //
        //Density of the wire (stainless steel) kg/m3
        float density = 7750f;
        //The radius of the wire
        float radius = 0.02f;

        float volume = Mathf.PI * radius * radius * ropeLength;

        float ropeMass = volume * density;

        //Add what the rope is carrying
        ropeMass += loadMass;


        //
        //The spring constant (has to recalculate if the rope length is changing)
        //
        //The force from the rope F = rope_mass * g, which is how much the top rope segment will carry
        float ropeForce = ropeMass * 9.81f;

        //Use the spring equation to calculate F = k * x should balance this force, 
        //where x is how much the top rope segment should stretch, such as 0.01m

        //Is about 146000
        float kRope = ropeForce / 0.01f;

        //print(ropeMass);

        //Add the value to the spring
        springJoint.spring = kRope * 1.0f;
        springJoint.damper = kRope * 0.8f;

        //Update length of the rope
        springJoint.maxDistance = ropeLength;

        
    }

    //Display the rope with a line renderer
    private void DisplayRope()
    {
        //This is not the actual width, but the width use so we can see the rope
        

        lineRenderer.startWidth = RopeWidht;
        lineRenderer.endWidth = RopeWidht;


        //Update the list with rope sections by approximating the rope with a bezier curve
        //A Bezier curve needs 4 control points
        Vector3 A = whatTheRopeIsConnectedTo.position;
        Vector3 D = whatIsHangingFromTheRope.position;

        //Upper control point
        //To get a little curve at the top than at the bottom
        Vector3 B = A + whatTheRopeIsConnectedTo.up * (-(A - D).magnitude * 0.1f);
        //B = A;

        //Lower control point
        Vector3 C = D + whatIsHangingFromTheRope.up * ((A - D).magnitude * 0.5f);

        //Get the positions
        BezierCurve.GetBezierCurve(A, B, C, D, allRopeSections);


        //An array with all rope section positions
        Vector3[] positions = new Vector3[allRopeSections.Count];

        BoxCollider[] coliders = lineRenderer.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider box in coliders)
        {
            if (box.CompareTag("RopeCollider"))
            {
                GameObject.Destroy(box.gameObject);
                started = closed = false;
            }
        }


        for (int i = 0; i < allRopeSections.Count; i++)
        {
            positions[i] = allRopeSections[i];
            if (!closed && started && (i + 1) < allRopeSections.Count)
            //if ((i + 1) < allRopeSections.Count)
            {
                addColliderToLine(allRopeSections[i], allRopeSections[i + 1]);
            }
        }
        if (started)
            closed = true;
        //Just add a line between the start and end position for testing purposes
        //Vector3[] positions = new Vector3[2];

        //positions[0] = whatTheRopeIsConnectedTo.position;
        //positions[1] = whatIsHangingFromTheRope.position;


        //Add the positions to the line renderer
        lineRenderer.positionCount = positions.Length;

        lineRenderer.SetPositions(positions);

        started = true;

        
    }

    //Add more/less rope
    private void UpdateWinch()
    {
        bool hasChangedRope = false;

        //More rope
        if (Input.GetKey(KeyCode.O) && ropeLength < maxRopeLength)
        {
            ropeLength += winchSpeed * Time.deltaTime;

            hasChangedRope = true;
        }
        else if (Input.GetKey(KeyCode.I) && ropeLength > minRopeLength)
        {
            ropeLength -= winchSpeed * Time.deltaTime;

            hasChangedRope = true;
        }


        if (hasChangedRope)
        {
            ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);

            //Need to recalculate the k-value because it depends on the length of the rope
            UpdateSpring();
        }
    }

    private void addColliderToLine(Vector3 startPos, Vector3 endPos)
    {
        //Vector3 startPos = whatTheRopeIsConnectedTo.position;
        //Vector3 endPos = whatIsHangingFromTheRope.position;

        BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();

        col.tag = "RopeCollider";
        col.isTrigger = true;
        col.transform.parent = lineRenderer.transform; // Collider is added as child object of line
        //float lineLength = Vector3.Distance(startPos, endPos); // length of line
        col.size = new Vector3(0.05f, 0.05f, 0.05f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        col.transform.Rotate(0, 0, angle);
    }
}