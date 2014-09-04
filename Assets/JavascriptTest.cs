using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Jurassic;
using Jurassic.Library;

public class JavascriptTest : MonoBehaviour {

	private static ScriptEngine engine = new Jurassic.ScriptEngine();
	public int vida;
	void Start(){
		TextAsset script = Resources.Load("JavascriptTest") as TextAsset;
		engine.Execute(script.text);
		engine.SetGlobalValue("robotState", new Math2(engine, vida, transform));

	//	Debug.Log(engine.Evaluate<double>("math2.log10(1000)"));




		engine.CallGlobalFunction("start");
		transform.position = RobotSate.trans.position;
	}
	

	void Update(){

	}
		
}


public class RobotSate : ObjectInstance
{
	public static int vidaTotal;
	public static Transform trans;
	public RobotSate(ScriptEngine engine, int vida, Transform t) : base(engine)
	{
		this.PopulateFunctions();
		vidaTotal = vida;
		trans = t;
	}
	
	[JSFunction(Name = "log10")]
	public static double Log10(double num)
	{
		trans.position = new Vector3 (12,0,0);
		return num;
	}
	[JSFunction(Name = "getVida")]
	public static double GetVida()
	{
		
		return vidaTotal;
	}
	[JSFunction(Name = "setVida")]
	public static double SetVida(double num)
	{
		Debug.Log ("retorno "+num);
		return num;
	}
}

