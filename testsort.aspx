<%@ Page Language="C#" %>

<%@ Import Namespace = "System.Collections.Generic" %>
<%@ Import Namespace = "System.Diagnostics" %>
<%@ Import Namespace = "System.IO" %>
<%@ Import Namespace = "System.Web.Script.Serialization" %>

<%@ Import Namespace = "com.overset" %>

<script runat="server">

	protected void Page_Load (object sender, System.EventArgs e) {

		Response.Write("<BR>NaturalSort - test sorting values in list:<BR>");
		string tests = File.ReadAllText(Server.MapPath("tests.txt"));
		foreach (string test in tests.Split('\n')) {
			if (!test.Contains("//"))
				RunTest(test, "");
		}
		
		Response.Write("\nNaturalSort - test sorting by specific column in nested dictionary in list:<BR>");
		string nestedtests = File.ReadAllText(Server.MapPath("nestedtests.txt"));
		foreach (string nestedtest in nestedtests.Split('\n')) {
			if (!nestedtest.Contains("//"))
				RunTest(nestedtest, "col");
		}

	}
	
	public void RunTest (string jsonString, string col) {

		JavaScriptSerializer JSON = new JavaScriptSerializer();
		Stopwatch timer;
		IComparer<object> sortCompare;
		if (col.Length == 0)
			sortCompare = new NaturalSort();
		else 
			sortCompare = new NaturalSort(col);

		Response.Write("before: " + jsonString + "<br>");
		try {
			List<object> lTest = JSON.Deserialize<List<object>>(jsonString);
			timer = Stopwatch.StartNew();
			lTest.Sort(sortCompare);
			timer.Stop();
			Response.Write("after: " + JSON.Serialize(lTest) + " (" + timer.ElapsedMilliseconds + "ms)<br><br>");
		} catch (ArgumentException ae) {
			Response.Write("Error parsing JSON string: " + ae.Message + "<br><br>");
		}
		
	}
	
</script>