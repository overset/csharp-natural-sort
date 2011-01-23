// csc.exe /r:NaturalSort.dll /o:testsort.exe testsort.cs
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using com.overset;

public class TestSort {

	static void Main () {
		
		Console.WriteLine("NaturalSort test");
		
		// img filenames
		RunTest(@"[{'col':'img100.jpg'},{'col':'img10.jpg'},{'col':'img2.jpg'}]");

		// img filenames
		RunTest(@"[{'col':'1.0.2'},{'col':'1.0.1'},{'col':'1.0.0'},{'col':'1.0.9'}]");
		
		// dates
		RunTest(@"[{'col':'10/12/2008'},{'col':'10/11/2008'},{'col':'10/11/2007'},{'col':'10/12/2007'}]");

		// IP addresses
		RunTest(@"[{'col':'192.168.0.100'},{'col':'192.168.0.1'},{'col':'192.168.1.1'},{'col':'192.168.0.250'}]");
		
		// number vs string
		RunTest(@"[{'col':'asd1.3'},{'col':2},{'col':'asd1.2'},{'col':1}]");
		
	}
	
	static void RunTest (string jsonString) {
	
		JavaScriptSerializer JSON = new JavaScriptSerializer();
		IComparer<object> sortCompare = new NaturalSort("col");

		List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
		Console.Write("before: " + JSON.Serialize(lTest) + "\n");
		lTest.Sort(sortCompare);
		Console.Write("after:  " + JSON.Serialize(lTest) + "\n\n");
	
	}
	
}