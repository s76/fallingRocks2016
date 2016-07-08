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
	public class MapsInitDataRawRow : IGoogle2uRow
	{
		public string _CodeName;
		public string _PlaneCodeName;
		public string _Description;
		public MapsInitDataRawRow(string __ID, string __CodeName, string __PlaneCodeName, string __Description) 
		{
			_CodeName = __CodeName.Trim();
			_PlaneCodeName = __PlaneCodeName.Trim();
			_Description = __Description.Trim();
		}

		public int Length { get { return 3; } }

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
					ret = _PlaneCodeName.ToString();
					break;
				case 2:
					ret = _Description.ToString();
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
				case "PlaneCodeName":
					ret = _PlaneCodeName.ToString();
					break;
				case "Description":
					ret = _Description.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "CodeName" + " : " + _CodeName.ToString() + "} ";
			ret += "{" + "PlaneCodeName" + " : " + _PlaneCodeName.ToString() + "} ";
			ret += "{" + "Description" + " : " + _Description.ToString() + "} ";
			return ret;
		}
	}
	public sealed class MapsInitDataRaw : IGoogle2uDB
	{
		public enum rowIds {
			MapCosmos, MapVolcano, MapJugle
		};
		public string [] rowNames = {
			"MapCosmos", "MapVolcano", "MapJugle"
		};
		public System.Collections.Generic.List<MapsInitDataRawRow> Rows = new System.Collections.Generic.List<MapsInitDataRawRow>();

		public static MapsInitDataRaw Instance
		{
			get { return NestedMapsInitDataRaw.instance; }
		}

		private class NestedMapsInitDataRaw
		{
			static NestedMapsInitDataRaw() { }
			internal static readonly MapsInitDataRaw instance = new MapsInitDataRaw();
		}

		private MapsInitDataRaw()
		{
			Rows.Add( new MapsInitDataRawRow("MapCosmos", "CN_MapCosmos", "CN_Plane01", "Map cosmos"));
			Rows.Add( new MapsInitDataRawRow("MapVolcano", "CN_MapVolcano", "CN_Plane01", "Map volcano"));
			Rows.Add( new MapsInitDataRawRow("MapJugle", "CN_MapJugle", "CN_Plane01", "Map jugle"));
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
		public MapsInitDataRawRow GetRow(rowIds in_RowID)
		{
			MapsInitDataRawRow ret = null;
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
		public MapsInitDataRawRow GetRow(string in_RowString)
		{
			MapsInitDataRawRow ret = null;
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
