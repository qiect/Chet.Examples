
using System.IO;

List<(int start, int length)> DetectFields(string line)
{
    var fields = new List<(int, int)>();

    int i = 0;
    while (i < line.Length)
    {
        // 找字段开始
        while (i < line.Length && char.IsWhiteSpace(line[i]))
            i++;

        if (i >= line.Length)
            break;

        int start = i;

        // 找字段结束
        while (i < line.Length && !char.IsWhiteSpace(line[i]))
            i++;

        int end = i;

        fields.Add((start, end - start));
    }

    return fields;
}


var fieldIndexLengthData = new List<(int start, int length)>
{
    (0, 8),
    (9, 8),
    (18, 4),
    (25, 4),
    (37, 4),
    (48, 3),
    (59, 6),
    (74, 5),
    (80, 5),
    (88, 4),
    (94, 5),
    (101, 7),
    (114, 2),
    (119, 4),
    (126, 7),
    (135, 5),
    (144, 5),
    (153, 4),
    (160, 4),
    (165, 4),
    (170, 4),
    (177, 3),
    (183, 3),
    (189, 4),
    (196, 4),
    (203, 4)
};

string path = @"E:\CastcZhy.Projects\SAFI\server_dotnet_qar_data\QARDataIntegration\B-320J-50174373.txt";
var lines = File.ReadAllLines(path);
var originAPMList = new List<OriginAPMEntity>();
for (int i = 2; i < lines.Length; i += 3)
{
    var entity = new OriginAPMEntity
    {
        FileName = Path.GetFileName(path),
        DATE_FLT = lines[i].Substring(fieldIndexLengthData[0].start, fieldIndexLengthData[0].length),
        TIME = lines[i].Substring(fieldIndexLengthData[1].start, fieldIndexLengthData[1].length),
        CITY_FROM_R = lines[i].Substring(fieldIndexLengthData[2].start, fieldIndexLengthData[2].length),
        CITY_TO_R = lines[i].Substring(fieldIndexLengthData[3].start, fieldIndexLengthData[3].length),
        FLIGHT_NO1 = lines[i].Substring(fieldIndexLengthData[4].start, fieldIndexLengthData[4].length),
        FLIGHT_NO2 = lines[i].Substring(fieldIndexLengthData[5].start, fieldIndexLengthData[5].length),
        FLIGHT_PHASE = lines[i].Substring(fieldIndexLengthData[6].start, fieldIndexLengthData[6].length),
        ALT_STD = double.Parse(lines[i].Substring(fieldIndexLengthData[7].start, fieldIndexLengthData[7].length)),
        MACH_REC = double.Parse(lines[i].Substring(fieldIndexLengthData[8].start, fieldIndexLengthData[8].length)),
        TAT = double.Parse(lines[i].Substring(fieldIndexLengthData[9].start, fieldIndexLengthData[9].length)),
        GW = double.Parse(lines[i].Substring(fieldIndexLengthData[10].start, fieldIndexLengthData[10].length)),
        FPAC = double.Parse(lines[i].Substring(fieldIndexLengthData[11].start, fieldIndexLengthData[11].length)),
        IVVR = double.Parse(lines[i].Substring(fieldIndexLengthData[12].start, fieldIndexLengthData[12].length)),
        HEAD_T = double.Parse(lines[i].Substring(fieldIndexLengthData[13].start, fieldIndexLengthData[13].length)),
        LATPC = lines[i].Substring(fieldIndexLengthData[14].start, fieldIndexLengthData[14].length),
        WIN_SPD = double.Parse(lines[i].Substring(fieldIndexLengthData[15].start, fieldIndexLengthData[15].length)),
        WIN_DIR = double.Parse(lines[i].Substring(fieldIndexLengthData[16].start, fieldIndexLengthData[16].length)),
        N11 = double.Parse(lines[i].Substring(fieldIndexLengthData[17].start, fieldIndexLengthData[17].length)),
        N12 = double.Parse(lines[i].Substring(fieldIndexLengthData[18].start, fieldIndexLengthData[18].length)),
        FF1 = double.Parse(lines[i].Substring(fieldIndexLengthData[19].start, fieldIndexLengthData[19].length)),
        FF2 = double.Parse(lines[i].Substring(fieldIndexLengthData[20].start, fieldIndexLengthData[20].length)),
        EGT1C = double.Parse(lines[i].Substring(fieldIndexLengthData[21].start, fieldIndexLengthData[21].length)),
        EGT2C = double.Parse(lines[i].Substring(fieldIndexLengthData[22].start, fieldIndexLengthData[22].length)),
        IsOut = lines[i].Substring(fieldIndexLengthData[23].start, fieldIndexLengthData[23].length) == "0" ? false : true,
        EPR1 = double.Parse(lines[i].Substring(fieldIndexLengthData[24].start, fieldIndexLengthData[24].length)),
        EPR2 = double.Parse(lines[i].Substring(fieldIndexLengthData[25].start, fieldIndexLengthData[25].length)),

    };
    originAPMList.Add(entity);
}


/// <summary>
/// APM源
/// </summary>
public class OriginAPMEntity
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// 机尾号
    /// </summary>
    public string AcTail { get; set; }
    /// <summary>
    /// 文件编号
    /// </summary>
    public string FileNo { get; set; }
    /// <summary>
    /// 文件创建时间
    /// </summary>
    public DateTime FileCreateTime { get; set; }
    /// <summary>
    /// APM时间
    /// </summary>
    public DateTime APMTime { get; set; }
    /// <summary>
    /// 日期
    /// </summary>
    public string DATE_FLT { get; set; }
    /// <summary>
    /// 时间
    /// </summary>
    public string TIME { get; set; }
    /// <summary>
    /// 起飞城市
    /// </summary>
    public string CITY_FROM_R { get; set; }
    /// <summary>
    /// 落地城市
    /// </summary>
    public string CITY_TO_R { get; set; }
    /// <summary>
    /// 航班号1
    /// </summary>
    public string FLIGHT_NO1 { get; set; }
    /// <summary>
    /// 航班号2
    /// </summary>
    public string FLIGHT_NO2 { get; set; }
    /// <summary>
    /// 航班类型
    /// </summary>
    public string FLIGHT_PHASE { get; set; }
    /// <summary>
    /// 高度
    /// </summary>
    public double ALT_STD { get; set; }
    /// <summary>
    /// 马赫数
    /// </summary>
    public double MACH_REC { get; set; }
    /// <summary>
    /// 总温
    /// </summary>
    public double TAT { get; set; }
    /// <summary>
    /// 总重
    /// </summary>
    public double GW { get; set; }
    /// <summary>
    /// 飞行轨迹加速度
    /// </summary>
    public double FPAC { get; set; }
    /// <summary>
    /// 垂直速度
    /// </summary>
    public double IVVR { get; set; }
    /// <summary>
    /// 机头朝向
    /// </summary>
    public double HEAD_T { get; set; }
    /// <summary>
    /// 维度
    /// </summary>
    public string LATPC { get; set; }
    /// <summary>
    /// 风速
    /// </summary>
    public double WIN_SPD { get; set; }
    /// <summary>
    /// 风向
    /// </summary>
    public double WIN_DIR { get; set; }
    /// <summary>
    /// N1转速-N11
    /// </summary>
    public double N11 { get; set; }
    /// <summary>
    /// N1转速-N12
    /// </summary>
    public double N12 { get; set; }
    /// <summary>
    /// 燃油流量-FF1
    /// </summary>
    public double FF1 { get; set; }
    /// <summary>
    /// 燃油流量-FF2
    /// </summary>
    public double FF2 { get; set; }
    /// <summary>
    /// 发动机温度
    /// </summary>
    public double EGT1C { get; set; }
    /// <summary>
    /// 发动机温度
    /// </summary>
    public double EGT2C { get; set; }
    /// <summary>
    /// 是否计算
    /// </summary>
    public bool IsOut { get; set; }
    /// <summary>
    /// EPR1
    /// </summary>
    public double EPR1 { get; set; }
    /// <summary>
    /// EPR2
    /// </summary>
    public double EPR2 { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;
}

