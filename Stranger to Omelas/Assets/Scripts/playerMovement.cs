using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class playerMovement : MonoBehaviour {
	
	public int speed = 256;

	//facing
	private bool facingRight;
	private float h;

	private Vector3 targetPosition = Vector3.zero;

	protected Animator animator;

	protected AStar astar;
	protected Graph graph;
	public TextAsset graphFile;
	public List<Vector3> path;


	protected float timeSinceConversation = 0;
	protected float timebetweenConversation = .1f;
	

	void Start () 
	{
		graph = GraphImport.ReadGraphFromFile(graphFile);
		astar = new AStar(graph);

		transform.position = Globals.position;
		facingRight = Globals.isFacingRight;

		//accounts for starting left instead of right
		if (facingRight == false)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}

		animator = GetComponent<Animator>();
		animator.SetBool("Walking", false);
	}

	void Update () {
		if(!Globals.inConversation && !Globals.inPause)
		{
			timeSinceConversation += Time.deltaTime;

			followPath();

			if(Input.GetMouseButtonDown(0) && timeSinceConversation > timebetweenConversation)
			{
				//get mouse point
				Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//factor in target offset
				targetPosition = new Vector3(mp.x+ 62, mp.y + 250, mp.z);

				
				h = targetPosition.x - transform.position.x;

				//Check to see if graph is populated
				//foreach(Node n in graph.Nodes)
				//{
					//string s = "x:" + n.X.ToString() + " " + "y:"+ n.Y.ToString()+ " " + "z:"+ n.Z.ToString();
					//Debug.Log(s);
				//}


				createPath();

				animator.SetBool("Walking", true);
			}

			//if path is empty set walking to false
			if(path == null || path.Count == 0)
				animator.SetBool("Walking", false);

		}else{
			timeSinceConversation = 0;
			animator.SetBool("Walking", false);
			path = null;
		}
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void createPath()
	{
		Vector3 playerPos = transform.position;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Node startNode = new Node(0,0,0);
		Node endNode = new Node(0,0,0);
		
		double d;
		
		//converted to nodes
		if(h < 0)
		{
			startNode = graph.ClosestNode((double)mousePos.x, (double)mousePos.y, (double)mousePos.z,out d,true); 
			endNode = graph.ClosestNode((double)playerPos.x, (double)playerPos.y, (double)playerPos.z,out d,true);
		}
		else if(h > 0)
		{
			startNode = graph.ClosestNode((double)playerPos.x, (double)playerPos.y, (double)playerPos.z,out d,true);
			endNode = graph.ClosestNode((double)mousePos.x, (double)mousePos.y, (double)mousePos.z,out d,true);
		}
		
		if(astar.SearchPath(startNode,endNode))
		{
			path = null;
			path = astar.PathByVectors;
			RemoveUnrequiredNodes();
		}
	}
	
	void RemoveUnrequiredNodes()
	{
		if(h>0)
		{
			if(facingRight)
			{
				if(transform.position.x - path[0].x > 0)
					path.RemoveAt(0);
			}
			else
			{
				if(transform.position.x - path[0].x < 0)
					path.RemoveAt(0);
			}
		}
		else if(h < 0)
		{
			if(facingRight)
			{
				if(transform.position.x - path[path.Count-1].x > 0)
					path.RemoveAt(path.Count-1);
			}
			else
			{
				if(transform.position.x - path[path.Count-1].x < 0)
					path.RemoveAt(path.Count-1);
			}
		}
	}

	void followPath()
	{	
		float facingCalc = 0;

		animator.SetBool("Walking", true);

		//If a path with points exists
		if(path != null && path.Count > 0)
		{
			//if going right
			if(h > 0)
			{
				//Move character
				transform.position = Vector3.MoveTowards(transform.position,path[0],speed * Time.deltaTime);

				//If you arent moving
				if(path[0].x -.5 < transform.position.x && transform.position.x < path[0].x +.5 )
				{
					path.RemoveAt(0);
				}

				if(path != null && path.Count != 0)
					facingCalc = path[0].x - transform.position.x;
			}
			//if going left
			else if(h < 0)
			{
				//Move character
				transform.position = Vector3.MoveTowards(transform.position,path[path.Count-1],speed * Time.deltaTime);

				//If you arent moving
				if(path[path.Count-1].x -.5 < transform.position.x && transform.position.x < path[path.Count-1].x +.5 )
				{
					path.RemoveAt(path.Count-1);
				}

				if(path != null && path.Count != 0){
					if(path.Count > 1){
						facingCalc = path[path.Count-1].x - transform.position.x;
					}else if(path.Count == 1){
						facingCalc = path[0].x - transform.position.x;}
				}
			}

			if(facingCalc < 0 && facingRight)
			{
				Flip();
			}
			else if(facingCalc > 0 && !facingRight)
			{
				Flip();
			}
		}
	}




}
