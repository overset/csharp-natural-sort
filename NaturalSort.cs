// csc.exe /t:library /out:NaturalSort.dll NaturalSort.cs
namespace com.overset {

	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using System.Web.Script.Serialization;

	public class NaturalSort : IComparer<object> {

		private string sortColumn;
		private Regex tokenize = new Regex(@"[a-zA-Z]+|[0-9\.-]+", RegexOptions.Compiled);

		public NaturalSort () {
			sortColumn = null;
		}
		public NaturalSort (string newSortColumn) {
			sortColumn = newSortColumn;
		}

		public int Compare (object x, object y) {
			
			string a, b;
			decimal decA, decB;
			DateTime dtA, dtB;
			
			// get the values as strings from the column we want to sort by
			if (sortColumn != null) {
				a = (x as Dictionary<string, object>)[sortColumn].ToString();
				b = (y as Dictionary<string, object>)[sortColumn].ToString();
			} else {
				a = x.ToString();
				b = y.ToString();
			}
			
			// tokenize and sort only if both values are not numeric or valid dates
			if (!decimal.TryParse(a, out decA) &&
				!decimal.TryParse(b, out decB) &&
				!DateTime.TryParse(a, out dtA) &&
				!DateTime.TryParse(b, out dtB)) {
				
				// tokenize on consecutive alphas or valid numbers
				MatchCollection aTok = tokenize.Matches(a);
				MatchCollection bTok = tokenize.Matches(b);

				// attempt to compare each token
				for (int tok = 0; tok < Math.Min(aTok.Count, bTok.Count); tok++) {
					int iTok = CompareToken(aTok[tok].Value, bTok[tok].Value);
					// only retun if find a sortable pair
					if (iTok != 0)
						return iTok;
				}
				
			}
			
			// otherwise compare if a simple value was found
			return CompareToken(a, b);
			
		}
		
		public int CompareToken (string a, string b) {
			
			// attempt numeric comparison assuming decimal
			decimal decA, decB;
			// decimal will take precedence if values are different types 
			bool bDecA = decimal.TryParse(a, out decA), bDecB = decimal.TryParse(b, out decB);
			if (bDecA || bDecB) {
				if ((bDecA && !bDecB) || (bDecA && bDecB && decA < decB))
					return -1;
				else if ((!bDecA && bDecB) || (bDecA && bDecB && decA > decB))
					return 1;
				else
					return 0;
			}

			// attempt DateTime comparison
			DateTime dtA, dtB;
			// datetime will take precedence if values are different types 
			bool bDtA = DateTime.TryParse(a, out dtA), bDtB = DateTime.TryParse(b, out dtB);
			if (bDtA || bDtB) {
				if ((bDtA && !bDtB) || (bDtA && bDtB && dtA < dtB))
					return -1;
				else if ((!bDtA && bDtB) || (bDtA && bDtB && dtA > dtB))
					return 1;
				else
					return 0;
			}
			
			// otherwise, rely on the default string compare
			return(Comparer<object>.Default.Compare(a, b));
			
		}

	}
	
}