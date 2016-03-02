using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ShellShock
{ 
    //is a custom editor for whatever object has a polygoncollider2d attached
    [CustomEditor(typeof(PolygonCollider2D))]
    public class PolygonColliderMan :  Editor
    {
	
	    private bool PolygonColliderManual;
	    private bool[] NewColliders = new bool[0];
	    private Vector2[][] Polygons;
	
	    public override void OnInspectorGUI()
	    {
		    PolygonCollider2D collider = (PolygonCollider2D)target;
		
		    DrawDefaultInspector();
		    //modify the layout with a new polygoncollidermanual section	
		    PolygonColliderManual = EditorGUILayout.Foldout(PolygonColliderManual, "PolygonColliderManual");
		
		    if (PolygonColliderManual)
		    {
			    Polygons = new Vector2[collider.pathCount][];
			    for (int i = 0; i < collider.pathCount; i++)
			    {
				    Vector2[] path = collider.GetPath(i);
				    Polygons[i] = path;
			    }
			
			    int size = EditorGUILayout.IntField("Size", Polygons.Length);
			
			
			    if (NewColliders.Length != Polygons.Length)
			    {
				    bool[] ArrNewColliders = new bool[Polygons.Length];
				
				    for (int i = 0; i < ArrNewColliders.Length; i++)
				    {
					    if (NewColliders.Length > i)
						    ArrNewColliders[i] = NewColliders[i];
					    else
						    ArrNewColliders[i] = false;
				    }
				
				    NewColliders = ArrNewColliders;
			    }
			
			    if (size != Polygons.Length)
			    {
				    Vector2[][] newPaths = new Vector2[size][];
				    for (int i = 0; i < size; i++)
				    {
					    if (Polygons.Length > i)
					    {
						    newPaths[i] = Polygons[i];
					    }
					    else
					    {
						    newPaths[i] = new Vector2[0];
					    }
				    }
				    Polygons = newPaths;
			    }
			
			    EditorGUI.indentLevel++;
			    for (int i = 0; i < size; i++)
			    {
				    NewColliders[i] = EditorGUILayout.Foldout(NewColliders[i], string.Concat("Path ", i));
				
				    if (NewColliders[i])
				    {
					    Vector2[] path = Polygons[i];
					    int pathSize = EditorGUILayout.IntField("Size", path.Length);
					    if (pathSize != path.Length)
					    {
						    Vector2[] newPath = new Vector2[pathSize];
						    for (int j = 0; j < pathSize; j++)
						    {
							    if (path.Length > j)
							    {
								    newPath[j] = path[j];
							    }
							    else
							    {
								    newPath[j] = new Vector2();
							    }
						    }
						    Polygons[i] = newPath;
					    }
					
					    for (int j = 0; j < pathSize; j++)
					    {
						    Polygons[i][j] = EditorGUILayout.Vector2Field(string.Concat("Point ", j), Polygons[i][j]);
					    }
				    }
			    }
			    EditorGUI.indentLevel--;
			
			    collider.pathCount = Polygons.Length;
			    for (int i = 0; i < Polygons.Length; i++)
			    {
				    collider.SetPath(i, Polygons[i]);
			    }
		    }
	    }
    }
}
