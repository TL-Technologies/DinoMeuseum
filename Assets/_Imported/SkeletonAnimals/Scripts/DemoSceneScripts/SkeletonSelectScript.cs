using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkeletonSelectScript : MonoBehaviour {
	public string[] descriptionStr;
	public Text descriptionText;
	public GameObject[] cameraTargets;
	public SkeletonCameraScript skeletonCamera;
	
	void Start () {
		descriptionStr [0] = "Allosaurus"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"space:jump"+System.Environment.NewLine+"T:tail";
		descriptionStr [1] = "Diplodocus"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"T:tail";
		descriptionStr [2] = "Elephant"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"N:sit down"+System.Environment.NewLine+"U:stand up";
		descriptionStr [3] = "Frog"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"space:jump";
		descriptionStr [4] = "Gallimimus"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"space:jump"+System.Environment.NewLine+"N:sit down"+System.Environment.NewLine+"U:stand up"+System.Environment.NewLine+"T:tail";
		descriptionStr [5] = "Lion"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"space:jump"+System.Environment.NewLine+"P:punch";
		descriptionStr [6] = "Stegosaurus"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"N:sit down"+System.Environment.NewLine+"U:stand up"+System.Environment.NewLine+"E:eat";
		descriptionStr [7] = "Triceratops"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"N:sit down"+System.Environment.NewLine+"U:stand up"+System.Environment.NewLine+"E:eat"+System.Environment.NewLine+"L:LeftAttack"+System.Environment.NewLine+"R:RightAttack";
		descriptionStr [8] = "Whale"+System.Environment.NewLine+"slider:speed change"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"mouse click:attack";
		descriptionStr [9] = "Owl"+System.Environment.NewLine+"wasd or arrow:move"+System.Environment.NewLine+"space:soar"+System.Environment.NewLine+"L:landing"+System.Environment.NewLine+"mouse click:attack"+System.Environment.NewLine+"H:hit";

		SelectSkeleton(7);
	}

	
	public void SelectSkeleton(int skeletonNum){
		skeletonCamera.target = cameraTargets [skeletonNum];
		descriptionText.text = descriptionStr [skeletonNum];
	}



}
