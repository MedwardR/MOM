using System.ComponentModel.DataAnnotations;

namespace MigrationTool.SK.Models;

public class Reference
{
    public required string TBL_NAME { get; set; }
    [Key] public required string TBL_ID { get; set; }
    public string? DESCS { get; set; }
    public int? SYSTEM_IND { get; set; }
    public string? UDF1 { get; set; }
    public DateTime? CREATE_TS { get; set; }
    public string? CREATE_BY { get; set; }
    public DateTime? UPDATE_TS { get; set; }
    public string? UPDATE_BY { get; set; }
    public string? OLD_TBL_ID { get; set; }
    public string? ACTIVE_FLAG { get; set; }
    public string? UDF2 { get; set; }
}
