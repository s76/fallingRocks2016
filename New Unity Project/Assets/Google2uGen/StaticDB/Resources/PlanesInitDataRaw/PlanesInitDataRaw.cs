//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class PlanesInitDataRawRow : IGoogle2uRow
	{
		public string _CodeName;
		public Vector3 _Size;
		public System.Collections.Generic.List<string> _Rocks = new System.Collections.Generic.List<string>();
		public bool _RandomDistribution;
		public System.Collections.Generic.List<string> _TestField = new System.Collections.Generic.List<string>();
		public PlanesInitDataRawRow(string __ID, string __CodeName, string __Size, string __Rocks, string __RandomDistribution, string __TestField) 
		{
			_CodeName = __CodeName.Trim();
			{
				string [] splitpath = __Size.Split(",".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				if(splitpath.Length != 3)
					Debug.LogError("Incorrect number of parameters for Vector3 in " + __Size );
				float []results = new float[splitpath.Length];
				for(int i = 0; i < 3; i++)
				{
					float res;
					if(float.TryParse(splitpath[i], NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					{
						results[i] = res;
					}
					else 
					{
						Debug.LogError("Error parsing " + __Size + " Component: " + splitpath[i] + " parameter " + i + " of variable _Size");
					}
				}
				_Size.x = results[0];
				_Size.y = results[1];
				_Size.z = results[2];
			}
			{
				string []result = __Rocks.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_Rocks.Add( result[i].Trim() );
				}
			}
			{
			bool res;
				if(bool.TryParse(__RandomDistribution, out res))
					_RandomDistribution = res;
				else
					Debug.LogError("Failed To Convert _RandomDistribution string: "+ __RandomDistribution +" to bool");
			}
			{
				string []result = __TestField.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_TestField.Add( result[i].Trim() );
				}
			}
		}

		public int Length { get { return 5; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _CodeName.ToString();
					break;
				case 1:
					ret = _Size.ToString();
					break;
				case 2:
					ret = _Rocks.ToString();
					break;
				case 3:
					ret = _RandomDistribution.ToString();
					break;
				case 4:
					ret = _TestField.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "CodeName":
					ret = _CodeName.ToString();
					break;
				case "Size":
					ret = _Size.ToString();
					break;
				case "Rocks":
					ret = _Rocks.ToString();
					break;
				case "RandomDistribution":
					ret = _RandomDistribution.ToString();
					break;
				case "TestField":
					ret = _TestField.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "CodeName" + " : " + _CodeName.ToString() + "} ";
			ret += "{" + "Size" + " : " + _Size.ToString() + "} ";
			ret += "{" + "Rocks" + " : " + _Rocks.ToString() + "} ";
			ret += "{" + "RandomDistribution" + " : " + _RandomDistribution.ToString() + "} ";
			ret += "{" + "TestField" + " : " + _TestField.ToString() + "} ";
			return ret;
		}
	}
	public sealed class PlanesInitDataRaw : IGoogle2uDB
	{
		public enum rowIds {
			Plane01, Plane02
		};
		public string [] rowNames = {
			"Plane01", "Plane02"
		};
		public System.Collections.Generic.List<PlanesInitDataRawRow> Rows = new System.Collections.Generic.List<PlanesInitDataRawRow>();

		public static PlanesInitDataRaw Instance
		{
			get { return NestedPlanesInitDataRaw.instance; }
		}

		private class NestedPlanesInitDataRaw
		{
			static NestedPlanesInitDataRaw() { }
			internal static readonly PlanesInitDataRaw instance = new PlanesInitDataRaw();
		}

		private PlanesInitDataRaw()
		{
			Rows.Add( new PlanesInitDataRawRow("Plane01", "CN_Plane01", "3,3,20", "CN_CrushRock*9", "FALSE", "test01|test02"));
			Rows.Add( new PlanesInitDataRawRow("Plane02", "CN_Plane02", "4,4,20", "CN_CrushRock*10|CN_FlameRock*6", "FALSE", "test04|test05"));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public PlanesInitDataRawRow GetRow(rowIds in_RowID)
		{
			PlanesInitDataRawRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public PlanesInitDataRawRow GetRow(string in_RowString)
		{
			PlanesInitDataRawRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
