<%@ Page Language="C#" %>

<%@ Import Namespace = "System.Collections.Generic" %>
<%@ Import Namespace = "System.Web.Script.Serialization" %>

<%@ Import Namespace = "com.overset" %>

<script runat="server">

	protected void Page_Load (object sender, System.EventArgs e) {

		Response.Write("NaturalSort - test sorting values in list:<br>");
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
		
		Response.Write("NaturalSort - test sorting by specific column in nested dictionary in list:<br>");
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
	
	public void RunTest (string jsonString) {
	
		JavaScriptSerializer JSON = new JavaScriptSerializer();
		IComparer<object> sortCompare = new NaturalSort();

		List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
		Response.Write("before: " + JSON.Serialize(lTest) + "<br>");
		lTest.Sort(sortCompare);
		Response.Write("after:  " + JSON.Serialize(lTest) + "<br><br>");
	
	}

	public void RunNestedTest (string jsonString) {
	
		JavaScriptSerializer JSON = new JavaScriptSerializer();
		IComparer<object> sortCompare = new NaturalSort("col");

		List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
		Response.Write("before: " + JSON.Serialize(lTest) + "<br>");
		lTest.Sort(sortCompare);
		Response.Write("after:  " + JSON.Serialize(lTest) + "<br><br>");
	
	}
	
</script>