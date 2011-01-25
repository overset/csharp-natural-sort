// csc.exe /r:NaturalSort.dll /o:testsort.exe testsort.cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using com.overset;

public class TestSort {

	static void Main () {
		
		Console.WriteLine("\nNaturalSort - test sorting values in list:\n");
		string tests = File.ReadAllText(Directory.GetCurrentDirectory() + @"\tests.txt");
		foreach (string test in tests.Split('\n')) {
			if (!test.Contains("//"))
				RunTest(test, "");
		}
		
		Console.WriteLine("\nNaturalSort - test sorting by specific column in nested dictionary in list:\n");
		string nestedtests = File.ReadAllText(Directory.GetCurrentDirectory() + @"\nestedtests.txt");
		foreach (string nestedtest in nestedtests.Split('\n')) {
			if (!nestedtest.Contains("//"))
				RunTest(nestedtest, "col");
		}
		
	}
	
	static void RunTest (string jsonString, string col) {
	
		JavaScriptSerializer JSON = new JavaScriptSerializer();
		Stopwatch timer;
		IComparer<object> sortCompare;
		if (col.Length == 0)
			sortCompare = new NaturalSort();
		else 
			sortCompare = new NaturalSort(col);

		Console.WriteLine("before: " + jsonString);
		try {
			List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
			timer = Stopwatch.StartNew();
			lTest.Sort(sortCompare);
			timer.Stop();
			Console.WriteLine("after:  " + JSON.Serialize(lTest) + " (" + timer.ElapsedMilliseconds + "ms)\n");
		} catch (ArgumentException ae) {
			Console.WriteLine("Error parsing JSON string: " + ae.Message + "\n");
		}
	
	}
	
}