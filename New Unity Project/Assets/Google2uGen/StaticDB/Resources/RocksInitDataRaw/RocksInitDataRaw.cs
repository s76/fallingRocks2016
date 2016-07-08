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
	public class RocksInitDataRawRow : IGoogle2uRow
	{
		public string _CodeName;
		public System.Collections.Generic.List<string> _SkillNames = new System.Collections.Generic.List<string>();
		public float _FallTime;
		public RocksInitDataRawRow(string __ID, string __CodeName, string __SkillNames, string __FallTime) 
		{
			_CodeName = __CodeName.Trim();
			{
				string []result = __SkillNames.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_SkillNames.Add( result[i].Trim() );
				}
			}
			{
			float res;
				if(float.TryParse(__FallTime, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_FallTime = res;
				else
					Debug.LogError("Failed To Convert _FallTime string: "+ __FallTime +" to float");
			}
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
					ret = _SkillNames.ToString();
					break;
				case 2:
					ret = _FallTime.ToString();
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
				case "SkillNames":
					ret = _SkillNames.ToString();
					break;
				case "FallTime":
					ret = _FallTime.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "CodeName" + " : " + _CodeName.ToString() + "} ";
			ret += "{" + "SkillNames" + " : " + _SkillNames.ToString() + "} ";
			ret += "{" + "FallTime" + " : " + _FallTime.ToString() + "} ";
			return ret;
		}
	}
	public sealed class RocksInitDataRaw : IGoogle2uDB
	{
		public enum rowIds {
			CrushRock, FlameRock, ThunderRock
		};
		public string [] rowNames = {
			"CrushRock", "FlameRock", "ThunderRock"
		};
		public System.Collections.Generic.List<RocksInitDataRawRow> Rows = new System.Collections.Generic.List<RocksInitDataRawRow>();

		public static RocksInitDataRaw Instance
		{
			get { return NestedRocksInitDataRaw.instance; }
		}

		private class NestedRocksInitDataRaw
		{
			static NestedRocksInitDataRaw() { }
			internal static readonly RocksInitDataRaw instance = new RocksInitDataRaw();
		}

		private RocksInitDataRaw()
		{
			Rows.Add( new RocksInitDataRawRow("CrushRock", "CN_CrushRock", "", "2"));
			Rows.Add( new RocksInitDataRawRow("FlameRock", "CN_FlameRock", "", "0.5"));
			Rows.Add( new RocksInitDataRawRow("ThunderRock", "CN_ThunderRock", "", "2"));
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
		public RocksInitDataRawRow GetRow(rowIds in_RowID)
		{
			RocksInitDataRawRow ret = null;
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
		public RocksInitDataRawRow GetRow(string in_RowString)
		{
			RocksInitDataRawRow ret = null;
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
