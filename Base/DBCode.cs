using System;
using System.Collections.Generic;
using System.Text;

namespace ECard78
{
    public enum DBCode
    {
        DB_000001,        //帐套
        DB_000002,        //系统登录
        DB_000003,        //SYPower
        DB_000004,        //SYDevice
        DB_000005,        //SYAuto
        DB_001001 = 100,  //RSCardType
        DB_001002,        //RSDepart
        DB_001003,        //RSEmp
        DB_001004,        //RSCardOpter
        DB_002001 = 200,  //KQMacInfo
        DB_002002,        //KQTypeSet
        DB_002003,        //KQShift
        DB_002004,        //KQShiftRule
        DB_002005,        //KQEmpShift
        DB_002006,        //KQDepShift
        DB_002007,        //KQShiftAssert
        DB_002008,        //KQEmpDayOff
        DB_002009,        //KQEmpTrip
        DB_002010,        //KQEmpOtSure
        DB_002011,        //KQEmpSignCard
        DB_002012,        //KQDataAssay
        DB_002013,        //KQDataDiagnosis
        DB_002014,        //KQDataExceptions
        DB_002015,        //KQReport
        DB_002016,        //KQHoliday
        DB_002017,        //KQWeekEnd
        DB_002018,        //KQEmpWorkType
        DB_002019,        //KQDepWorkType
        DB_002020,        //KQShiftPackage
        DB_002021,        //KQShiftCountH
        DB_003001 = 300,  //MJMacInfo
        DB_003002,        //MJHoliday
        DB_003003,        //MJMacTime
        DB_003004,        //MJMacPower
        DB_003005,        //MJMacData
        DB_003006,        //MJMacReal
        DB_003007,        //MJMap
        DB_003008,        //MJReport
        DB_003009,        //MJMacTimeOpenDoor
        DB_004001 = 400,  //SFMacAddress
        DB_004002,        //SFMacPrintTitle
        DB_004003,        //SFMacProducts
        DB_004004,        //SFMacInfo
        DB_004005,        //SFMacData
        DB_004006,        //SFAllowance
        DB_004007,        //SFCheckAccount
        DB_004008,        //SFQueryIncomeCount
        DB_004009,        //SFQueryBalance
        DB_004010,        //SFReportOrder
        DB_004011,        //SFReportSF
        DB_004012,        //SFCardCheck
        DB_004013,        //SFDepositType
        DB_004014,        //SFRefundmentType
        DB_005001 = 500,   //SKDeposit
        DB_006001        //SEA海系列
    }
}