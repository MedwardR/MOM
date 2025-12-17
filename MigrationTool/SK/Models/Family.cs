using System.ComponentModel.DataAnnotations;

namespace MigrationTool.SK.Models;

internal class Family
{
	public string? LOC_ID { get; set; }
	public required int REC_ID { get; set; }
	[Key] public required string FAMILY_ID { get; set; }
	public string? FAM_TYPE { get; set; }
	public string? FAM_NAME { get; set; }
	public string? ACTIVE_IND { get; set; }
	public string? SALUTATION { get; set; }
	public string? MAIL_NAME { get; set; }
	public string? MAIL_CD { get; set; }
	public string? ADDR1 { get; set; }
	public string? ADDR2 { get; set; }
	public string? CITY { get; set; }
	public string? STATE { get; set; }
	public string? ZIP { get; set; }
	public string? CARSORT { get; set; }
	public string? COUNTRY { get; set; }
	public string? GEO_CD { get; set; }
	public string? H_PHONE { get; set; }
	public string? H_UNLIST { get; set; }
	public string? DEV_POINT { get; set; }
	public string? EMAIL1 { get; set; }
	public string? EMAIL1_IND { get; set; }
	public string? EMAIL2 { get; set; }
	public string? EMAIL2_IND { get; set; }
	public string? URL { get; set; }
	public string? NO_ALT_IND { get; set; }
	public string? A_EFF_DT { get; set; }
	public string? A_END_DT { get; set; }
	public string? A_ADDR1 { get; set; }
	public string? A_ADDR2 { get; set; }
	public string? A_CITY { get; set; }
	public string? A_STATE { get; set; }
	public string? A_ZIP { get; set; }
	public string? A_CARSORT { get; set; }
	public string? A_COUNTRY { get; set; }
	public string? A_GEO_CD { get; set; }
	public string? A_DEVPOINT { get; set; }
	public string? A_PHONE { get; set; }
	public string? A_UNLIST { get; set; }
	public string? W_EXT { get; set; }
	public string? E_PHONE { get; set; }
	public string? E_UNLIST { get; set; }
	public string? E_CONTACT { get; set; }
	public string? FAM_STATUS { get; set; }
	public string? CHBK { get; set; }
	public string? INCLD_DIR { get; set; }
	public string? GROUP_CD { get; set; }
	public string? GROUP_NAME { get; set; }
	public string? HEAD { get; set; }
	public string? HEAD_ID { get; set; }
	public string? SPOUSE { get; set; }
	public string? SPOUSE_ID { get; set; }
	public string? CHILDREN { get; set; }
	public string? STATUS { get; set; }
	public string? UDF1 { get; set; }
	public string? UDF2 { get; set; }
	public string? UDF3 { get; set; }
	public string? UDF4 { get; set; }
	public string? UDF5 { get; set; }
	public string? UDF6 { get; set; }
	public string? UDF7 { get; set; }
	public string? UDF8 { get; set; }
	public string? UDF_DT1 { get; set; }
	public string? UDF_DT2 { get; set; }
	public string? UDF_DT3 { get; set; }
	public string? UDF_DT4 { get; set; }
	public string? UDF_DT5 { get; set; }
	public string? UNL_ADDR { get; set; }
	public string? UNL_AL_ADDR { get; set; }
	public string? MAIL_ADDR { get; set; }
	public string? OLD_FAM_ID { get; set; }
	public string? CREATE_TS { get; set; }
	public string? CREATE_BY { get; set; }
	public DateTime? UPDATE_TS { get; set; }
	public string? UPDATE_BY { get; set; }
	public string? w_unlist { get; set; }
	public string? PHOTO_IND { get; set; }
	public string? EST_IND { get; set; }
	
	public string GetCombinedStreetAddress()
	{
		throw new NotImplementedException();
	}
}
