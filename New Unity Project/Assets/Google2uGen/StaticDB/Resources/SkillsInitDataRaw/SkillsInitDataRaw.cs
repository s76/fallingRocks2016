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
	public class SkillsInitDataRawRow : IGoogle2uRow
	{
		public string _CodeName;
		public string _Description;
		public System.Collections.Generic.List<string> _SkillInput = new System.Collections.Generic.List<string>();
		public SkillsInitDataRawRow(string __ID, string __CodeName, string __Description, string __SkillInput) 
		{
			_CodeName = __CodeName.Trim();
			_Description = __Description.Trim();
			{
				string []result = __SkillInput.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_SkillInput.Add( result[i].Trim() );
				}
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
					ret = _Description.ToString();
					break;
				case 2:
					ret = _SkillInput.ToString();
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
				case "Description":
					ret = _Description.ToString();
					break;
				case "SkillInput":
					ret = _SkillInput.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "CodeName" + " : " + _CodeName.ToString() + "} ";
			ret += "{" + "Description" + " : " + _Description.ToString() + "} ";
			ret += "{" + "SkillInput" + " : " + _SkillInput.ToString() + "} ";
			return ret;
		}
	}
	public sealed class SkillsInitDataRaw : IGoogle2uDB
	{
		public enum rowIds {
			MeteorCrash
		};
		public string [] rowNames = {
			"MeteorCrash"
		};
		public System.Collections.Generic.List<SkillsInitDataRawRow> Rows = new System.Collections.Generic.List<SkillsInitDataRawRow>();

		public static SkillsInitDataRaw Instance
		{
			get { return NestedSkillsInitDataRaw.instance; }
		}

		private class NestedSkillsInitDataRaw
		{
			static NestedSkillsInitDataRaw() { }
			internal static readonly SkillsInitDataRaw instance = new SkillsInitDataRaw();
		}

		private SkillsInitDataRaw()
		{
			Rows.Add( new SkillsInitDataRawRow("MeteorCrash", "CN_MeteorCrash", "Meteor crash skill ", "Damage#150"));
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
		public SkillsInitDataRawRow GetRow(rowIds in_RowID)
		{
			SkillsInitDataRawRow ret = null;
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
		public SkillsInitDataRawRow GetRow(string in_RowString)
		{
			SkillsInitDataRawRow ret = null;
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
