// csc.exe /r:NaturalSort.dll /o:testsort.exe testsort.cs
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using com.overset;

public class TestSort {

	static void Main () {
	
		Console.WriteLine("NaturalSort - test sorting values in list:\n");
		// img filenames
		RunTest(@"['img100.jpg','img10.jpg','img2.jpg']");
		// versions
		RunTest(@"['1.0.2','1.0.1','1.0.0','1.0.9']");
		// dates
		RunTest(@"['10/12/2008','10/11/2008','10/11/2007','10/12/2007']");
		// IP addresses
		RunTest(@"['192.168.0.100','192.168.0.1','192.168.1.1','192.168.0.250']");
		// number vs string
		RunTest(@"['asd1.3',2,'asd1.2',1]");
		
		Console.WriteLine("NaturalSort - test sorting by specific column in nested dictionary in list:\n");
		// img filenames
		RunNestedTest(@"[{'col':'img100.jpg'},{'col':'img10.jpg'},{'col':'img2.jpg'}]");
		// versions
		RunNestedTest(@"[{'col':'1.0.2'},{'col':'1.0.1'},{'col':'1.0.0'},{'col':'1.0.9'}]");
		// dates
		RunNestedTest(@"[{'col':'10/12/2008'},{'col':'10/11/2008'},{'col':'10/11/2007'},{'col':'10/12/2007'}]");
		// IP addresses
		RunNestedTest(@"[{'col':'192.168.0.100'},{'col':'192.168.0.1'},{'col':'192.168.1.1'},{'col':'192.168.0.250'}]");
		// number vs string
		RunNestedTest(@"[{'col':'asd1.3'},{'col':2},{'col':'asd1.2'},{'col':1}]");
		
	}
	
	static void RunTest (string jsonString) {
	
		JavaScriptSerializer JSON = new JavaScriptSerializer();
		IComparer<object> sortCompare = new NaturalSort();

		List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
		Console.Write("before: " + JSON.Serialize(lTest) + "\n");
		lTest.Sort(sortCompare);
		Console.Write("after:  " + JSON.Serialize(lTest) + "\n\n");
	
	}

	static void RunNestedTest (string jsonString) {
	
		JavaScriptSerializer JSON = new JavaScriptSerializer();
		IComparer<object> sortCompare = new NaturalSort("col");

		List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
		Console.Write("before: " + JSON.Serialize(lTest) + "\n");
		lTest.Sort(sortCompare);
		Console.Write("after:  " + JSON.Serialize(lTest) + "\n\n");
	
	}
	
}