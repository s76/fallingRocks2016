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
	public class CharactersInitDataRawRow : IGoogle2uRow
	{
		public string _CodeName;
		public string _SkinName;
		public string _CharacterName;
		public System.Collections.Generic.List<string> _SkillNames = new System.Collections.Generic.List<string>();
		public float _RunSpeed;
		public int _MaxHealth;
		public float _CastTimeMultiplier;
		public float _TurnMoveSpeed;
		public float _TurnAngleSpeed;
		public int _MaxStamina;
		public float _StaminaRegenSpeed;
		public CharactersInitDataRawRow(string __ID, string __CodeName, string __SkinName, string __CharacterName, string __SkillNames, string __RunSpeed, string __MaxHealth, string __CastTimeMultiplier, string __TurnMoveSpeed, string __TurnAngleSpeed, string __MaxStamina, string __StaminaRegenSpeed) 
		{
			_CodeName = __CodeName.Trim();
			_SkinName = __SkinName.Trim();
			_CharacterName = __CharacterName.Trim();
			{
				string []result = __SkillNames.Split("|".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);
				for(int i = 0; i < result.Length; i++)
				{
					_SkillNames.Add( result[i].Trim() );
				}
			}
			{
			float res;
				if(float.TryParse(__RunSpeed, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_RunSpeed = res;
				else
					Debug.LogError("Failed To Convert _RunSpeed string: "+ __RunSpeed +" to float");
			}
			{
			int res;
				if(int.TryParse(__MaxHealth, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_MaxHealth = res;
				else
					Debug.LogError("Failed To Convert _MaxHealth string: "+ __MaxHealth +" to int");
			}
			{
			float res;
				if(float.TryParse(__CastTimeMultiplier, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_CastTimeMultiplier = res;
				else
					Debug.LogError("Failed To Convert _CastTimeMultiplier string: "+ __CastTimeMultiplier +" to float");
			}
			{
			float res;
				if(float.TryParse(__TurnMoveSpeed, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_TurnMoveSpeed = res;
				else
					Debug.LogError("Failed To Convert _TurnMoveSpeed string: "+ __TurnMoveSpeed +" to float");
			}
			{
			float res;
				if(float.TryParse(__TurnAngleSpeed, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_TurnAngleSpeed = res;
				else
					Debug.LogError("Failed To Convert _TurnAngleSpeed string: "+ __TurnAngleSpeed +" to float");
			}
			{
			int res;
				if(int.TryParse(__MaxStamina, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_MaxStamina = res;
				else
					Debug.LogError("Failed To Convert _MaxStamina string: "+ __MaxStamina +" to int");
			}
			{
			float res;
				if(float.TryParse(__StaminaRegenSpeed, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_StaminaRegenSpeed = res;
				else
					Debug.LogError("Failed To Convert _StaminaRegenSpeed string: "+ __StaminaRegenSpeed +" to float");
			}
		}

		public int Length { get { return 11; } }

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
					ret = _SkinName.ToString();
					break;
				case 2:
					ret = _CharacterName.ToString();
					break;
				case 3:
					ret = _SkillNames.ToString();
					break;
				case 4:
					ret = _RunSpeed.ToString();
					break;
				case 5:
					ret = _MaxHealth.ToString();
					break;
				case 6:
					ret = _CastTimeMultiplier.ToString();
					break;
				case 7:
					ret = _TurnMoveSpeed.ToString();
					break;
				case 8:
					ret = _TurnAngleSpeed.ToString();
					break;
				case 9:
					ret = _MaxStamina.ToString();
					break;
				case 10:
					ret = _StaminaRegenSpeed.ToString();
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
				case "SkinName":
					ret = _SkinName.ToString();
					break;
				case "CharacterName":
					ret = _CharacterName.ToString();
					break;
				case "SkillNames":
					ret = _SkillNames.ToString();
					break;
				case "RunSpeed":
					ret = _RunSpeed.ToString();
					break;
				case "MaxHealth":
					ret = _MaxHealth.ToString();
					break;
				case "CastTimeMultiplier":
					ret = _CastTimeMultiplier.ToString();
					break;
				case "TurnMoveSpeed":
					ret = _TurnMoveSpeed.ToString();
					break;
				case "TurnAngleSpeed":
					ret = _TurnAngleSpeed.ToString();
					break;
				case "MaxStamina":
					ret = _MaxStamina.ToString();
					break;
				case "StaminaRegenSpeed":
					ret = _StaminaRegenSpeed.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "CodeName" + " : " + _CodeName.ToString() + "} ";
			ret += "{" + "SkinName" + " : " + _SkinName.ToString() + "} ";
			ret += "{" + "CharacterName" + " : " + _CharacterName.ToString() + "} ";
			ret += "{" + "SkillNames" + " : " + _SkillNames.ToString() + "} ";
			ret += "{" + "RunSpeed" + " : " + _RunSpeed.ToString() + "} ";
			ret += "{" + "MaxHealth" + " : " + _MaxHealth.ToString() + "} ";
			ret += "{" + "CastTimeMultiplier" + " : " + _CastTimeMultiplier.ToString() + "} ";
			ret += "{" + "TurnMoveSpeed" + " : " + _TurnMoveSpeed.ToString() + "} ";
			ret += "{" + "TurnAngleSpeed" + " : " + _TurnAngleSpeed.ToString() + "} ";
			ret += "{" + "MaxStamina" + " : " + _MaxStamina.ToString() + "} ";
			ret += "{" + "StaminaRegenSpeed" + " : " + _StaminaRegenSpeed.ToString() + "} ";
			return ret;
		}
	}
	public sealed class CharactersInitDataRaw : IGoogle2uDB
	{
		public enum rowIds {
			David, Laura, Clark
		};
		public string [] rowNames = {
			"David", "Laura", "Clark"
		};
		public System.Collections.Generic.List<CharactersInitDataRawRow> Rows = new System.Collections.Generic.List<CharactersInitDataRawRow>();

		public static CharactersInitDataRaw Instance
		{
			get { return NestedCharactersInitDataRaw.instance; }
		}

		private class NestedCharactersInitDataRaw
		{
			static NestedCharactersInitDataRaw() { }
			internal static readonly CharactersInitDataRaw instance = new CharactersInitDataRaw();
		}

		private CharactersInitDataRaw()
		{
			Rows.Add( new CharactersInitDataRawRow("David", "CN_David", "David_Skin", "David", "", "1", "100", "1", "2", "90", "40", "5"));
			Rows.Add( new CharactersInitDataRawRow("Laura", "CN_Laura", "Laura_Skin", "Laura", "", "1", "100", "1", "2", "180", "40", "5"));
			Rows.Add( new CharactersInitDataRawRow("Clark", "CN_Clark", "Clark_Skin", "Clark", "", "1", "100", "1", "2", "180", "40", "5"));
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
		public CharactersInitDataRawRow GetRow(rowIds in_RowID)
		{
			CharactersInitDataRawRow ret = null;
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
		public CharactersInitDataRawRow GetRow(string in_RowString)
		{
			CharactersInitDataRawRow ret = null;
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
