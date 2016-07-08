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
		public Vector2 _PlaneSize;
		public System.Collections.Generic.List<string> _Rocks = new System.Collections.Generic.List<string>();
		public bool _RandomDistribution;
		public float _RockSize;
		public int _RockFallHeight;
		public PlanesInitDataRawRow(string __ID, string __CodeName, string __PlaneSize, string __Rocks, string __RandomDistribution, string __RockSize, string __RockFallHeight) 
		{
			_CodeName = __CodeName.Trim();
			{
				string [] splitpath = __PlaneSize.Split(",".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				if(splitpath.Length != 2)
					Debug.LogError("Incorrect number of parameters for Vector2 in " + __PlaneSize );
				float []results = new float[splitpath.Length];
				for(int i = 0; i < 2; i++)
				{
					float res;
					if(float.TryParse(splitpath[i], NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					{
						results[i] = res;
					}
					else 
					{
						Debug.LogError("Error parsing " + __PlaneSize + " Component: " + splitpath[i] + " parameter " + i + " of variable _PlaneSize");
					}
				}
				_PlaneSize.x = results[0];
				_PlaneSize.y = results[1];
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
			float res;
				if(float.TryParse(__RockSize, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_RockSize = res;
				else
					Debug.LogError("Failed To Convert _RockSize string: "+ __RockSize +" to float");
			}
			{
			int res;
				if(int.TryParse(__RockFallHeight, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_RockFallHeight = res;
				else
					Debug.LogError("Failed To Convert _RockFallHeight string: "+ __RockFallHeight +" to int");
			}
		}

		public int Length { get { return 6; } }

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
					ret = _PlaneSize.ToString();
					break;
				case 2:
					ret = _Rocks.ToString();
					break;
				case 3:
					ret = _RandomDistribution.ToString();
					break;
				case 4:
					ret = _RockSize.ToString();
					break;
				case 5:
					ret = _RockFallHeight.ToString();
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
				case "PlaneSize":
					ret = _PlaneSize.ToString();
					break;
				case "Rocks":
					ret = _Rocks.ToString();
					break;
				case "RandomDistribution":
					ret = _RandomDistribution.ToString();
					break;
				case "RockSize":
					ret = _RockSize.ToString();
					break;
				case "RockFallHeight":
					ret = _RockFallHeight.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "CodeName" + " : " + _CodeName.ToString() + "} ";
			ret += "{" + "PlaneSize" + " : " + _PlaneSize.ToString() + "} ";
			ret += "{" + "Rocks" + " : " + _Rocks.ToString() + "} ";
			ret += "{" + "RandomDistribution" + " : " + _RandomDistribution.ToString() + "} ";
			ret += "{" + "RockSize" + " : " + _RockSize.ToString() + "} ";
			ret += "{" + "RockFallHeight" + " : " + _RockFallHeight.ToString() + "} ";
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
			Rows.Add( new PlanesInitDataRawRow("Plane01", "CN_Plane01", "3,3", "CN_CrushRock", "FALSE", "2", "5"));
			Rows.Add( new PlanesInitDataRawRow("Plane02", "CN_Plane02", "4,4", "CN_CrushRock*10|CN_FlameRock*6", "FALSE", "2", "5"));
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
