using System;
using System.Collections.Generic;
using System.Text;

namespace ECard78
{
    public class MSSQL
    {
        private string GetEmpInfoSQL(string TagInfo, string EmpInfo)
        {
            string ret = "";
            if (EmpInfo == "") return ret;
            int index = EmpInfo.IndexOf("EmpNo");

            if(index>0)
            {
                EmpInfo = EmpInfo.Substring(0, EmpInfo.Length - 6);
                if (EmpInfo == "") return ret;
                string[] tmp = EmpInfo.Split(',');
                
                ret = " AND (EmpNo='" + tmp[0] + "'";
                if (tmp.Length>1)
                {
                    for (int i = 1; i < tmp.Length; i++)
                    {
                        if (tmp[i] != "")
                            ret += " OR EmpNo='" + tmp[i] + "'";
                    }
                }
                ret += ")";
            }
            else
            {
                if (TagInfo == "1")
                    ret = " AND EmpNo='" + EmpInfo + "'";
                else
                {
                    string[] tmp = EmpInfo.Split(',');

                    ret = " AND (EmpNo='" + tmp[0] + "' OR EmpName LIKE '" + tmp[0] + "%'";
                    if (tmp.Length > 1)
                    {
                        for (int i = 1; i < tmp.Length; i++)
                        {
                            if(tmp[i]!="")
                                ret += " OR EmpNo='" + tmp[i] + "' OR EmpName LIKE '" + tmp[i] + "%'";
                        }
                    }
                    ret += ")";
                    //ret = " AND (EmpNo='" + EmpInfo + "' OR EmpName LIKE '" + EmpInfo + "%')";
                }
                   
            }
           
            return ret;
        }

        private string GetCardNoInfoSQL(string CardNoInfo)
        {
            string ret = "";
            if (CardNoInfo == "") return ret;

            ret = " AND (CardNo='" + CardNoInfo + "' OR CardNo LIKE '" + CardNoInfo + "%')";
            return ret;
        }
        private string GetCardSectorNoInfoSQL(string CardNoInfo)
        {
            string ret = "";
            if (CardNoInfo == "") return ret;

            ret = " AND (CardSectorNo='" + CardNoInfo + "' OR CardSectorNo LIKE '" + CardNoInfo + "%')";
            return ret;
        }
        private string GetCategoryInfoSQL(string TagInfo, string CategoryInfo)
        {
            string ret = "";
            if (CategoryInfo == "") return ret;
            if (TagInfo == "1")
                ret = " AND CategoryID='" + CategoryInfo + "'";
            else
                ret = " AND (CategoryID='" + CategoryInfo + "' OR CategoryID LIKE '" + CategoryInfo + "%')";
            return ret;
        }

        private string GetDepartInfoSQL(string TagInfo, string DepartInfo, string DepartList)
        {
            string ret = "";
            int index = 0;
            if (DepartInfo == "") return ret;
            index = DepartInfo.IndexOf("DepartID");
            if(index>0)
            {
                DepartInfo = DepartInfo.Substring(0, DepartInfo.Length - 9);
                if (DepartInfo == "") return ret;
                string[] tmp = DepartInfo.Split(',');

                ret = " AND (DepartID='" + tmp[0] + "'";
                if (tmp.Length > 1)
                {
                    for (int i = 1; i < tmp.Length; i++)
                    {
                        if (tmp[i] != "")
                            ret += " OR DepartID='" + tmp[i] + "'";
                    }
                }
                ret += ")";
            }
            else
            {
                if (TagInfo == "1")
                {
                    ret = " AND (DepartID='" + DepartInfo + "'";
                    if (DepartList == "" || DepartList == "''")
                        ret += ") ";
                    else
                        ret += " OR DepartID IN (" + DepartList + ")) ";
                }
                else
                {
                    string[] tmp = DepartInfo.Split(',');

                    ret = " AND (DepartID='" + tmp[0] + "' OR  DepartName LIKE '" + tmp[0] + "%'";
                    if (tmp.Length > 1)
                    {
                        for (int i = 1; i < tmp.Length; i++)
                        {
                            if(tmp[i]!="")
                                ret += " OR DepartID='" + tmp[i] + "' OR  DepartName LIKE '" + tmp[i] + "%'";
                        }
                    }
                    ret += ")";
                   // ret = " AND (DepartID='" + DepartInfo + "' OR  DepartName LIKE '" + DepartInfo + "%')";
                }
                    
            }
           
            return ret;
        }
        private string GetAddressInfoSQL(string TagInfo, string AddressInfo, string AddressList)
        {
            string ret = "";
            if (AddressInfo == "") return ret;
            if (TagInfo == "1")
            {
                ret = " AND (AddressNO='" + AddressInfo + "'";
                if (AddressList == "" || AddressList == "''")
                    ret += ") ";
                else
                    ret += " OR AddressNO IN (" + AddressList + ")) ";
            }
            else
                ret = " AND (AddressNO='" + AddressInfo + "' OR  AddressName LIKE '" + AddressInfo + "%')";
            return ret;
        }
        private string GetCardTypeInfoSQL(string CardTypeList)
        {
            string ret = "";
            if (CardTypeList == "") return ret;
            ret = " AND CardTypeID IN(" + CardTypeList + ")";
            return ret;
        }
        private string GetSFTypeInfoSQL(string SFTypeList)
        {
            string ret = "";
            if (SFTypeList == "") return ret;
            ret = " AND SFTypeID IN(" + SFTypeList + ")";
            return ret;
        }
        private string GetMealTypeInfoSQL(string MealTypeList)
        {
            string ret = "";
            if (MealTypeList == "") return ret;
            ret = " AND MealTypeID IN(" + MealTypeList + ")";
            return ret;
        }
        private string GetMacSNInfoSQL(string MacSNList)
        {
            string ret = "";
            if (MacSNList == "") return ret;
            ret = " AND SFMacSN IN(" + MacSNList + ")";
            return ret;
        }

        private string GetKQMacSNInfoSQL(string MacSNList)
        {
            string ret = "";
            if (MacSNList == "") return ret;
            ret = " AND MacSN IN(" + MacSNList + ")";
            return ret;
        }

        public string GetSQL(DBCode code, string[] Param)
        {
            string ret = "";
            int I = 0;
            int pos = 0;
            string s = "";
            string s1 = "";
            string s2 = "";
            DateTime d = new DateTime();
            switch (code)
            {
                case DBCode.DB_000001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM Hs_Manage";
                            break;
                        case 1:
                            ret = "IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='Hs_Account')\r\n" +
                              "BEGIN\r\n" +
                              "  CREATE TABLE [Hs_Account] (\r\n" +
                              "    [GUID] [varchar] (36) NOT NULL DEFAULT (newid()),\r\n" +
                              "    [AccName] [varchar] (50) NOT NULL ,\r\n" +
                              "    [DBName] [varchar] (50) NULL ,\r\n" +
                              "    [CrtdDay] [datetime] NULL DEFAULT (getdate()),\r\n" +
                              "    [BackupDay] [datetime] NULL ,\r\n" +
                              "    [IsForward] [varchar] (1) NULL DEFAULT ('N'),\r\n" +
                              "    [ForwardNote] [text] NULL ,\r\n" +
                              "    CONSTRAINT [PK_Hs_Account] PRIMARY KEY  CLUSTERED \r\n" +
                              "    (\r\n" +
                              "      [GUID]\r\n" +
                              "    )  ON [PRIMARY] ,\r\n" +
                              "    CONSTRAINT [AK_Hs_Account_AccName] UNIQUE  NONCLUSTERED \r\n" +
                              "    (\r\n" +
                              "      [AccName]\r\n" +
                              "    )  ON [PRIMARY] ,\r\n" +
                              "    CONSTRAINT [AK_Hs_Account_DBName] UNIQUE  NONCLUSTERED \r\n" +
                              "    (\r\n" +
                              "      [DBName]\r\n" +
                              "    )  ON [PRIMARY] \r\n" +
                              "  ) ON [PRIMARY]\r\n" +
                              "END\r\n";
                            break;
                        case 2:
                            ret = "IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='Hs_Manage')\r\n" +
                              "BEGIN\r\n" +
                              "  CREATE TABLE [Hs_Manage] (\r\n" +
                              "    [Password] [varchar] (50) NULL \r\n" +
                              "  ) ON [PRIMARY]\r\n" +
                              "END\r\n";
                            break;
                        case 3:
                            ret = "IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='Hs_WorkLog')\r\n" +
                              "BEGIN\r\n" +
                              "  CREATE TABLE [Hs_WorkLog] (\r\n" +
                              "    [GUID] [varchar] (36) NOT NULL DEFAULT (newid()),\r\n" +
                              "    [WorkDay] [datetime] NULL DEFAULT (getdate()),\r\n" +
                              "    [WorkDetail] [text] NULL ,\r\n" +
                              "    [WorkComputer] [varchar] (50) NULL ,\r\n" +
                              "    [WorkUser] [varchar] (50) NULL ,\r\n" +
                              "    CONSTRAINT [PK_Hs_WorkLog] PRIMARY KEY  CLUSTERED \r\n" +
                              "    (\r\n" +
                              "      [GUID]\r\n" +
                              "    )  ON [PRIMARY] \r\n" +
                              "  ) ON [PRIMARY]\r\n" +
                              "END\r\n";
                            break;
                        case 4:
                            ret = "INSERT INTO Hs_Manage([Password]) VALUES('123')";
                            break;
                        case 5:
                            ret = "ALTER TABLE Hs_Account ADD IsForward varchar(1) null default 'N'";
                            break;
                        case 6:
                            ret = "ALTER TABLE Hs_Account ADD ForwardNote text null";
                            break;
                        case 7:
                            ret = "ALTER TABLE Hs_Account ADD DBPath text null";
                            break;
                        case 8:
                            ret = "ALTER TABLE Hs_Account ADD RestoreDay datetime null";
                            break;
                        case 9:
                            ret = "UPDATE Hs_Account SET IsForward='N' WHERE IsForward IS NULL";
                            break;
                        case 10:
                            ret = "UPDATE Hs_Account SET ForwardNote='' WHERE ForwardNote IS NULL";
                            break;
                        case 11:
                            ret = "UPDATE Hs_Account SET DBPath='' WHERE DBPath IS NULL";
                            break;
                        case 100:
                            ret = "SELECT * FROM master..Hs_Account ORDER BY AccName";
                            break;
                        case 101:
                            ret = "SELECT * FROM master..sysdatabases WHERE name='" + Param[1] + "'";
                            break;
                        case 102:
                            ret = "UPDATE Hs_Account SET DBPath='" + Param[1] + "' WHERE DBName='" + Param[2] + "'";
                            break;
                        case 103:
                            ret = "SELECT * FROM DbVersion";
                            break;
                        case 104:
                            ret = "UPDATE Hs_Manage SET [Password]='" + Param[1] + "'";
                            break;
                        case 105:
                            ret = "SELECT * FROM master..Hs_Account WHERE AccName='" + Param[1] + "'";
                            break;
                        case 106:
                            ret = "SELECT * FROM master..sysdatabases WHERE name='" + Param[1] + "'";
                            break;
                        case 107:
                            ret = "DELETE FROM Hs_Account WHERE AccName='" + Param[1] + "'";
                            break;
                        case 108:
                            ret = "UPDATE Hs_Account SET RestoreDay=getdate() WHERE DBName='" + Param[1] + "'";
                            break;
                        case 109:
                            ret = "ALTER TABLE Hs_Account ADD PlanPath text NULL";
                            break;
                        case 110:
                            ret = "ALTER TABLE Hs_Account ADD PlanTime varchar(50)";
                            break;
                        case 111:
                            ret = "UPDATE Hs_Account SET PlanPath='" + Param[1] + "',PlanTime='" + Param[2] +
                              "' WHERE DBName='" + Param[3] + "'";
                            break;
                        case 112:
                            ret = "SELECT [Value] FROM SY_Config WHERE ID='" + Param[1] + "' AND [Key]='" + Param[2] + "'";
                            break;
                        case 113:
                            ret = "INSERT INTO SY_Config(ID,[Key],[Value]) VALUES('" + Param[1] + "','" + Param[2] + "','" +
                              Param[3] + "')";
                            break;
                        case 114:
                            ret = "UPDATE SY_Config SET [Value]='" + Param[3] + "' WHERE ID='" + Param[1] + "' AND [Key]='" +
                              Param[2] + "'";
                            break;
                        case 115:
                            ret = "DELETE FROM SY_Config WHERE ID='" + Param[1] + "' AND [Key]='" + Param[2] + "'";
                            break;
                        case 116:
                            ret = "SELECT COUNT(1) AS RecCount FROM RS_EmpCard WHERE CardStatusID<>'10'";
                            break;
                        case 117:
                            ret = "SELECT COUNT(1) AS RecCount FROM RS_Emp";
                            break;
                        case 118:
                            ret = "INSERT INTO SY_Log(GUID,OprtTime,OprtModule,OprtTool,OprtDetail,OprtNoName,OprtComputerName) " +
                              "VALUES(newid(),getdate(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "')";
                            break;
                        case 119:
                            ret = "SELECT * FROM master..Hs_Account WHERE IsForward<>'Y' ORDER BY AccName";
                            break;
                        case 201:
                            ret = "SELECT getdate() as ServerDate";
                            break;
                        case 202:
                            ret = "SELECT ID,Name FROM SY_ID2Name WHERE Class='SFMacType' ORDER BY ID";
                            break;
                        case 203:
                            ret = "SELECT * FROM RS_CardType ORDER BY CardTypeID";
                            break;
                        case 204:
                            ret = "SELECT * FROM KQ_Parameters";
                            break;
                        case 205:
                            ret = "INSERT INTO KQ_Parameters(RecordInterval,LeastWorkMin,LeastOtMin,ResultDecimalPlaces," +
                              "IsNeedOtSure," + "NormalShow,OtShow) VALUES(" + Param[1] + "," + Param[2] + "," +
                              Param[3] + "," + Param[4] + ",'" + Param[5] + "'," + Param[6] + "," + Param[7];
                            break;
                        case 206:
                            ret = "UPDATE KQ_Parameters SET RecordInterval=" + Param[1] + ",LeastWorkMin=" + Param[2] +
                              ",LeastOtMin=" + Param[3] + ",ResultDecimalPlaces=" + Param[4] + ",IsNeedOtSure='" +
                              Param[5] + "',NormalShow=" + Param[6] + ",OtShow=" + Param[7];
                            break;
                        case 207:
                            ret = "SELECT newid() AS SysID";
                            break;
                        case 301:
                            ret = "CONVERT(varchar(10),getdate(),120)";
                            break;
                        case 302:
                            ret = "SELECT * FROM " + Param[1] + " WHERE ReportName='" + Param[2] + "'";
                            break;
                        case 303:
                            ret = "UPDATE " + Param[1] + " SET ReportData=@ReportData WHERE ReportName='" + Param[2] + "'";
                            break;
                        case 401:
                            if ((Param[1] == "6") || (Param[1] == "7"))
                                ret = "'%" + Param[2] + "%'";
                            else
                                ret = "'" + Param[2] + "'";
                            break;
                        case 402:
                            ret = "=";
                            switch (Param[1])
                            {
                                case "0":
                                    ret = "=";
                                    break;
                                case "1":
                                    ret = "<>";
                                    break;
                                case "2":
                                    ret = ">";
                                    break;
                                case "3":
                                    ret = ">=";
                                    break;
                                case "4":
                                    ret = "<";
                                    break;
                                case "5":
                                    ret = "<=";
                                    break;
                                case "6":
                                    ret = " LIKE ";
                                    break;
                                case "7":
                                    ret = " NOT LIKE ";
                                    break;
                            }
                            break;
                        case 403:
                            ret = " (" + Param[1] + Param[2] + Param[3] + " OR DepartID IN (" + Param[4] + ")) ";
                            break;
                        case 404:
                            ret = Param[4] + Param[1] + Param[2] + Param[3] + Param[5];
                            break;
                        case 405:
                            ret = Param[2] + ",";
                            if (Param[1] == "1") ret = Param[2] + " DESC,";
                            break;
                        case 406:
                            ret = " ORDER BY " + Param[1];
                            ret = ret.Substring(0, ret.Length - 1);
                            break;
                        case 407:
                            ret = "CONVERT(varchar(10)," + Param[1] + ",120)";
                            break;
                        case 501:
                            ret = "SELECT ID AS SFTypeID,Name AS SFTypeName FROM Sy_ID2Name WHERE Class='SFType' ORDER BY ID";
                            break;
                        case 502:
                            ret = "SELECT ID AS SFMealTypeID,Name AS SFMealTypeName FROM Sy_ID2Name " +
                              "WHERE Class='MealTypeName' ORDER BY ID";
                            break;
                        case 503:
                            ret = "SELECT * FROM VRS_EmpCardStatus ORDER BY CardStatusID";
                            break;
                        case 504:
                            ret = "SELECT ID AS SYOpterID,Name AS SYOpterName FROM Sy_ID2Name " +
                              "WHERE Class='SYCardOpter' ORDER BY ID";
                            ret = "Select *From Sy_ID2Name Where Class='SYCardOpter' Order by ID";
                            break;
                        case 601:
                            ret = "SELECT GUID,ReportName,ReportView,CAST(CASE IsSys WHEN 'Y' THEN 1 ELSE 0 END AS bit) AS IsSys," +
                              "OrderField,DateFlag,DateField FROM " + Param[1] + " ORDER BY IsSys";
                            break;
                        case 602:
                            ret = "SELECT GUID FROM " + Param[1] + " WHERE ReportName='" + Param[2] + "'";
                            break;
                        case 603:
                            ret = "INSERT INTO " + Param[1] + "(GUID,ReportName,ReportView,IsSys,OrderField,DateFlag,DateField) " +
                              "VALUES(newid(),'" + Param[2] + "','" + Param[3] + "','N','" + Param[4] + "'," + Param[5] + ",'" +
                              Param[6] + "')";
                            break;
                        case 604:
                            ret = "SELECT ReportData FROM " + Param[1] + " WHERE ReportName='" + Param[2] + "'";
                            break;
                        case 605:
                            ret = "SELECT * FROM " + Param[1] + " WHERE 1=1";
                            if (Param[2] != "")
                            {
                                if (Param[12] == "3")
                                    ret += " AND " + Param[2] + "='" + Param[6] + "'";
                                else if (Param[12] != "0")
                                    ret += " AND " + Param[2] + ">='" + Param[6] + "' AND " + Param[2] + "<='" + Param[7] + "'";
                            }
                            if (Param[3] != "")
                            {
                                s = Param[10] == "1" ? "EmpName" : "EmpNo";
                                if (Param[13] == "1")
                                    ret += " AND " + s + "='" + Param[3] + "'";
                                else
                                    ret += " AND (EmpNo='" + Param[3] + "' OR EmpName LIKE '" + Param[3] + "%')";
                            }
                            if (Param[4] != "")
                            {
                                if (Param[14] == "1")
                                {
                                    if (Param[11] == "1")
                                        ret += " AND DepartName='" + Param[4] + "') ";
                                    else
                                        ret += " AND (DepartID='" + Param[4] + "' OR DepartID IN (" + Param[5] + ")) ";
                                }
                                else
                                    ret += " AND (DepartID='" + Param[4] + "' OR DepartName LIKE '" + Param[4] + "%') ";
                            }
                            ret += Param[8];
                            if (Param[9] != "") ret += " ORDER BY " + Param[9];
                            break;
                        case 606:
                            ret = "SELECT * FROM " + Param[1] + " WHERE 1=2";
                            break;
                        case 607:
                            ret = "DELETE FROM " + Param[1] + " WHERE ReportName='" + Param[2] + "'";
                            break;
                        case 701:
                            ret = "SELECT '" + Param[1] + "' AS Title,'" + Param[2] + "' AS MoneyTitle,EmpNo,EmpName," +
                              "CardTypeName,CardSectorNo," + Param[3] + " AS CardBalance," + Param[4] + " AS AddMoney," +
                              Param[5] + " AS ReceivablesAmount " + "FROM VRS_Emp WHERE CardSectorNo='" + Param[6] + "'";
                            if (Param[7] == "1") ret += " UNION ALL ";
                            break;
                        case 702:
                            ret = "SELECT '" + Param[1] + "' AS Title,'" + Param[2] + "' AS MoneyTitle,EmpNo,EmpName," +
                              "CardTypeName,CardSectorNo," + Param[3] + " AS CardBalance," + Param[4] + " AS AddMoney," +
                              Param[5] + " AS ReceivablesAmount " + "FROM VRS_Emp WHERE EmpSysID='" + Param[6] + "'";
                            if (Param[7] == "1") ret += " UNION ALL ";
                            break;
                        case 801:
                            ret = "INSERT INTO master..Hs_Account([GUID],[AccName],[DBName],[CrtdDay],[BackupDay],[IsForward]," +
                              "[ForwardNote],[DBPath]) SELECT newid(),'" + Param[1] + "','" + Param[2] +
                              "',crdate,NULL,'N','',filename FROM master..sysdatabases WHERE name='" + Param[2] + "'";
                            break;
                        case 1001:
                            ret = "SELECT COUNT(1) AS FingerCount FROM RS_EmpFingerInfo";
                            break;
                        case 2001:
                            ret = "SELECT COUNT(1) AS SFDataCount FROM SF_SFData";
                            break;
                        case 3001:
                            ret = "EXEC PRS_InsertCardTAG '" + Param[1] + "'";
                            break;
                        case 3002:
                            ret = "SELECT CardTAG FROM RS_CardTAG ORDER BY CardTAG";
                            break;
                        case 4000:
                            ret = "SELECT OprtModule FROM SY_Log GROUP BY OprtModule";
                            break;
                        case 4001:
                            ret = "SELECT * FROM SY_Log WHERE OprtTime>='" + Param[1] + "' AND OprtTime<='" +
                              Param[2] + "'";
                            if (Param[3] != "") ret += " AND OprtModule='" + Param[3] + "'";
                            ret += " ORDER BY OprtTime";
                            break;
                        case 5001:
                            ret = "INSERT INTO SY_MobileCancelOrd([GUID],[CardID],[CancelTime],[CancelDetail]) VALUES(newid(),'" + Param[1] + "',getdate(),'" + Param[2] + "')";
                            break;
                        case 5002:
                            ret = "TRUNCATE TABLE SY_ID2Name";
                            break;
                        case 5003:
                            ret = "UPDATE DbVersion SET DbDate='2000-01-01'";
                            break;
                    }
                    break;
                case DBCode.DB_000002:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT [Value] FROM SY_Config WHERE ID='DataForward' AND [Key]='IsForward'";
                            break;
                        case 1:
                            ret = "SELECT OprtNo,OprtName FROM SY_Oprt ORDER BY OprtNo";
                            break;
                        case 2:
                            ret = "SELECT * FROM DbVersion";
                            break;
                        case 3:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "UPDATE SY_Oprt SET OprtLastLoginTime=getdate() WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT DepartName FROM RS_Depart WHERE DepartUpSysId='' OR DepartUpSysId IS NULL";
                            break;
                        case 6:
                            ret = "UPDATE RS_EmpCardHistory SET CardIsValid=1 WHERE CardIsValid<>1";
                            if (Param[1] != "0") ret += " AND DATEADD(dd," + Param[1] + ",CardOprtDate)<=getdate()";
                            break;
                        case 7:
                            ret = "UPDATE DbVersion SET AppVer='" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "SELECT * FROM SY_Config WHERE ID='SFSoft' AND [Key]='ParamInfo'";
                            break;
                        case 9:
                            ret = "UPDATE SY_Config SET [Value]='" + Param[1] + "' WHERE ID='SFSoft' AND [Key]='ParamInfo'";
                            break;
                        case 10:
                            ret = "INSERT INTO SY_Config(ID,[Key],[Value]) VALUES('SFSoft','ParamInfo','" + Param[1] + "')";
                            break;
                        case 101:
                            ret = "SELECT DepartSysID,DepartID,DepartName FROM RS_Depart " +
                              "WHERE DepartUpSysId='' OR DepartUpSysId IS NULL";
                            break;
                        case 102:
                            ret = "SELECT DepartSysID,DepartID,DepartName FROM RS_Depart WHERE DepartUpSysId='" +
                              Param[1] + "' ORDER BY DepartID";
                            break;
                        case 201:
                            ret = "UPDATE SY_Oprt SET OprtPWD='" + Param[1] + "' Where OprtNo='" + Param[2] + "'";
                            break;
                        case 301:
                            ret = "SELECT * FROM SY_Wizard WHERE OprtSysID='" + Param[1] + "' AND ModuleType=" +
                              Param[2] + " ORDER BY [No]";
                            break;
                        case 302:
                            ret = "DELETE FROM SY_Wizard WHERE OprtSysID='" + Param[1] + "' AND ModuleType=" + Param[2];
                            break;
                        case 303:
                            ret = "INSERT INTO SY_Wizard(GUID,OprtSysID,ModuleType,ModuleID,SubID,PosX,PosY,[No],vis) " +
                              "VALUES(newid(),'" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "','" +
                              Param[4] + "',0,0," + Param[5] + "," + Param[6] + ")";
                            break;
                        case 401:
                            ret = "SELECT name FROM sysobjects WHERE CHARINDEX('" + Param[1] + "',name)>0 AND " +
                              "(xtype='U' OR xtype='V') AND name<>'KQ_Report' AND name<>'MJ_Report' AND " +
                              "name<>'RS_Report' AND name<>'SF_Report' ORDER BY name";
                            break;
                        case 402:
                            ret = "SELECT * FROM  " + Param[1] + " WHERE ReportName=' " + Param[2] + "'";
                            break;
                        case 403:
                            ret = "SELECT * FROM " + Param[1] + " WHERE 1=2";
                            break;
                        case 404:
                            ret = "SELECT name FROM sysobjects WHERE xtype='U' AND name<>'dtproperties' ORDER BY name";
                            break;
                    }
                    break;
                case DBCode.DB_000003:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSY_Oprt ORDER BY RoleIsSys,OprtNo";
                            break;
                        case 1:
                            ret = "INSERT INTO SY_Oprt(OprtSysID,OprtNo,OprtName,OprtPWD,OprtStartDay,OprtEndDay,OprtDesc," +
                                "OprtIsActive,RoleIsSys) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" +
                                Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','N')";
                            break;
                        case 2:
                            ret = "UPDATE SY_Oprt SET OprtNo='" + Param[1] + "',OprtName='" + Param[2] + "',OprtPWD='" + Param[3] +
                              "',OprtStartDay='" + Param[4] + "',OprtEndDay='" + Param[5] + "',OprtDesc='" + Param[6] +
                              "',OprtIsActive='" + Param[7] + "' WHERE OprtSysID='" + Param[8] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SY_Oprt WHERE OprtSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtNo='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM SY_Oprt WHERE OprtSysID<>'" + Param[1] + "' AND OprtNo='" + Param[2] + "'";
                            break;
                        case 101:
                            ret = "DELETE FROM SY_OprtPower WHERE OprtSysID='" + Param[1] + "' AND ItemType='FUN'";
                            break;
                        case 102:
                            ret = "INSERT INTO SY_OprtPower(GUID,OprtSysID,ItemType,ModuleID,SubID,Power_E,Power_A,Power_M," +
                              "Power_D,Power_C,Power_U,ItemSysID) VALUES(newid(),'" + Param[1] + "','FUN','" + Param[2] + "','" +
                              Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" +
                              Param[8] + "','Y','" + Param[2] + Param[3] + "')";
                            break;
                        case 103:
                            ret = "SELECT Power_E,Power_A,Power_M,Power_D,Power_C,Power_U FROM SY_OprtPower WHERE OprtSysID='" +
                                Param[1] + "' AND ModuleID='" + Param[2] + "' AND SubID='" + Param[3] + "' AND ItemType='FUN'";
                            break;
                        case 104:
                            ret = "DELETE FROM SY_OprtPower WHERE OprtSysID='" + Param[1] + "' AND ItemType='DPT'";
                            break;
                        case 105:
                            ret = "INSERT INTO SY_OprtPower(GUID,OprtSysID,ItemSysID,ItemType,Power_E,Power_A,Power_M,Power_D," +
                                "Power_C,Power_U) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','DPT','Y','Y','Y','Y','Y','Y')";
                            break;
                        case 106:
                            ret = "SELECT Power_E,Power_A,Power_M,Power_D,Power_C,Power_U FROM SY_OprtPower WHERE OprtSysID='" +
                              Param[1] + "' AND ItemSysID='" + Param[2] + "' AND ItemType='DPT'";
                            break;
                        case 107:
                            ret = "SELECT Power_E,Power_A,Power_M,Power_D,Power_C,Power_U FROM SY_OprtPower WHERE OprtSysID='" +
                                Param[1] + "' AND SubID='" + Param[2] + "' AND ItemType='FUN'";
                            break;
                        case 108:
                            ret = "SELECT b.DepartID,b.DepartSysID FROM SY_OprtPower a " +
                              "INNER JOIN RS_Depart b ON b.DepartSysID=ItemSysID WHERE OprtSysID='" +
                              Param[1] + "' AND ItemType='DPT' ORDER BY DepartID";
                            break;
                    }
                    break;
                case DBCode.DB_000004:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSF_MacOpter ORDER BY MacOpterID";
                            break;
                        case 1:
                            ret = "INSERT INTO SF_MacOpter(GUID,MacOpterID,MacOpterName,MacOpterPWD) VALUES(newid()," +
                              Param[1] + ",'" + Param[2] + "'," + Param[3] + ")";
                            break;
                        case 2:
                            ret = "UPDATE SF_MacOpter SET MacOpterID=" + Param[1] + ",MacOpterName='" + Param[2] +
                              "',MacOpterPWD=" + Param[3] + " WHERE GUID='" + Param[4] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SF_MacOpter WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SF_MacOpter WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM SF_MacOpter WHERE MacOpterID=" + Param[1];
                            break;
                        case 6:
                            ret = "SELECT * FROM SF_MacOpter WHERE GUID<>'" + Param[1] + "' AND MacOpterID=" + Param[2];
                            break;
                        case 101:
                            ret = "EXEC PGetMaxIDFromTable 'MacOpterID','SF_MacOpter'";
                            break;
                    }
                    break;
                case DBCode.DB_000005:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSY_Automatism ORDER BY [No]";
                            break;
                        case 1:
                            ret = "INSERT INTO SY_Automatism(GUID,[No],AutoTime,AutoType,AutoName) SELECT newid()," +
                              "ISNULL(MAX([No]),0)+1,'" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "' FROM SY_Automatism";
                            break;
                        case 2:
                            ret = "UPDATE SY_Automatism SET AutoTime='" + Param[1] + "',AutoType=" + Param[2] + ",AutoName='" +
                              Param[3] + "' WHERE GUID='" + Param[4] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SY_Automatism WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SY_Automatism WHERE GUID='" + Param[1] + "'";
                            break;
                    }
                    break;

                case DBCode.DB_001001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM RS_CardType WHERE CardTypeSysID='" + Param[1] + "'";
                            break;
                        case 1:
                            ret = "UPDATE RS_CardType SET CardTypeName='" + Param[1] + "',CardFee=" + Param[2] + ",CardStored=" +
                              Param[3] + ",CardCheckOrder=" + Param[4] + ",CardRetirement=" + Param[5] + ",CardRefundment=" +
                              Param[6] + ",CardRefundmentDev=" + Param[7] + ",DepositDiscount=" + Param[8] + ",CardRefundmentDiscount=" +
                              Param[9] + ",CardDepositLimit=" + Param[10] + ",CardDepositTimes=" + Param[11] + ",CardDescription='" +
                              Param[12] + "' Where CardTypeSysID='" + Param[13] + "'";
                            break;
                        case 101:
                            ret = "SELECT * FROM VRS_DepositDiscount ORDER BY CardTypeID,DiscStart,DiscDiscount";
                            break;
                        case 102:
                            ret = "SELECT * FROM VRS_DepositDiscount WHERE GUID='" + Param[1] + "'";
                            break;
                        case 103:
                            ret = "INSERT INTO RS_DepositDiscount(GUID,CardTypeSysID,DiscStart,DiscDiscount) " +
                              "VALUES(newid(),'" + Param[1] + "'," + Param[2] + "," + Param[3] + ")";
                            break;
                        case 104:
                            ret = "UPDATE RS_DepositDiscount SET CardTypeSysID='" + Param[1] + "',DiscStart=" + Param[2] +
                              ",DiscDiscount=" + Param[3] + " WHERE GUID='" + Param[4] + "'";
                            break;
                        case 105:
                            ret = "DELETE FROM RS_DepositDiscount WHERE GUID='" + Param[1] + "'";
                            break;
                        case 106:
                            ret = "SELECT DiscDiscount FROM VRS_DepositDiscount WHERE CardTypeID=" + Param[1] + " AND DiscStart=" + Param[2];
                            break;
                        ////case 107:
                        ////  ret = "SELECT DiscDiscount FROM VRS_DepositDiscount WHERE CardTypeID=" + Param[1] +
                        ////    " AND DiscStart<" + Param[2] + " AND DiscEnd>=" + Param[2];
                        ////  break;
                        //case 108:
                        //    ret = "SELECT DiscDiscount FROM VRS_DepositDiscount WHERE CardTypeID=" + Param[1] +
                        //      " AND DiscStart<" + Param[2] + " AND DiscEnd=0";
                        //    break;
                        case 109:
                            ret = "SELECT top 5 * FROM VRS_DepositDiscount WHERE CardTypeName='" + Param[1] + "'";
                            break;
                        case 110:
                            ret = "SELECT * FROM RS_CardType WHERE CardTypeName='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_001002:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT ISNULL(MAX(DepartID),0)+1 AS MaxID FROM RS_Depart WHERE DepartUpSysId='" +
                              Param[1] + "' AND ISNUMERIC(DepartID)=1";
                            break;
                        case 1:
                            ret = "SELECT * FROM RS_Depart WHERE DepartSysID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM RS_Depart WHERE DepartID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM RS_Depart WHERE DepartUpSysID='" + Param[1] + "' ORDER BY DepartID";
                            break;
                        case 4:
                            ret = "SELECT * FROM RS_Depart WHERE DepartSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM RS_Depart WHERE DepartSysID<>'" + Param[1] + "' AND DepartID='" + Param[2] + "'";
                            break;
                        case 6:
                            ret = "INSERT INTO RS_Depart(DepartSysID,DepartPrcID,DepartID,DepartName,DepartUpSysId,DepartMemo) " +
                              "VALUES(newid(),'" + Param[1] + "','" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "')";
                            break;
                        case 7:
                            ret = "UPDATE RS_Depart SET DepartPrcID='" + Param[1] + "',DepartID='" + Param[1] + "',DepartName='" +
                              Param[2] + "',DepartUpSysId='" + Param[3] + "',DepartMemo='" +
                              Param[4] + "' WHERE DepartSysID='" + Param[5] + "'";
                            break;
                        case 8:
                            ret = "SELECT * FROM VRS_Emp WHERE IsDimission=0 AND DepartSysID='" + Param[1] + "'";
                            if (Param.Length > 3) ret += Param[2] + Param[3];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 9:
                            ret = "DELETE FROM RS_Depart WHERE DepartSysID='" + Param[1] + "'";
                            break;
                        case 10:
                            ret = "SELECT * FROM VRS_Emp WHERE (CardStatusName LIKE '60%' OR CardStatusName LIKE '10%') AND IsDimission=0 AND DepartSysID='" + Param[1] + "'";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 20:
                            ret = "SELECT * FROM VRS_Emp WHERE IsDimission=1 AND DepartSysID='" + Param[1] + "'";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 100:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 101:
                            ret = "SELECT * FROM VRS_EmpDimission WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 102:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_001003:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VRS_Emp WHERE 1=1 " + Param[1] + " ORDER BY EmpNo";
                            break;
                        case 1:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID='" + Param[1] + "'";
                            if (Param.Length > 3) ret += Param[2] + Param[3];
                            break;
                        case 2:
                            ret = "SELECT * FROM RS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM RS_Emp WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM RS_Emp WHERE EmpSysID<>'" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM RS_EmpCard WHERE CardFingerNo=" + Param[1];
                            break;
                        case 6:
                            ret = "SELECT * FROM RS_EmpCard WHERE EmpSysID<>'" + Param[1] + "' AND CardSectorNo='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "SELECT * FROM RS_EmpCard WHERE EmpSysID<>'" + Param[1] + "' AND CardFingerNo=" + Param[2];
                            break;
                        case 8:
                            ret = "INSERT INTO RS_Emp(EmpSysID,EmpNo,EmpName,EmpSexSysID,CardTypeSysID,DepartSysID,EmpHireDate," +
                              "EmpCertNo,EmpAddress,EmpZipNo,EmpPhoneNo,EmpEmail,EmpStatusID,IsAttend,OtherCardNo," +
                              "FingerPrivilege,IsDimission) VALUES('" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" +
                              Param[9] + "','" + Param[10] + "','" + Param[11] + "','" + Param[12] + "',20,'" +
                              Param[13] + "','" + Param[14] + "'," + Param[15] + ",0)";
                            break;
                        case 9:
                            ret = "UPDATE RS_Emp SET EmpNo='" + Param[1] + "',EmpName='" + Param[2] + "',EmpSexSysID='" +
                              Param[3] + "',CardTypeSysID='" + Param[4] + "',DepartSysID='" + Param[5] + "',EmpHireDate='" +
                              Param[6] + "',EmpCertNo='" + Param[7] + "',EmpAddress='" + Param[8] + "',EmpZipNo='" +
                              Param[9] + "',EmpPhoneNo='" + Param[10] + "',EmpEmail='" + Param[11] + "',IsAttend='" +
                              Param[12] + "',OtherCardNo='" + Param[13] + "',FingerPrivilege=" +
                              Param[14] + " WHERE EmpSysID='" + Param[15] + "'";
                            break;
                        case 10:
                            ret = "UPDATE RS_EmpPhoto SET EmpPhotoImage=@EmpPhotoImage WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 11:
                            ret = "UPDATE RS_Emp SET EmpLeaveStatus=1,EmpLeaveDate=getdate() WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "DELETE RS_EmpPhoto WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 13:
                            ret = "DELETE RS_EmpCard WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 14:
                            ret = "DELETE RS_Emp WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 15:
                            ret = "SELECT * FROM RS_EmpCard WHERE CardSectorNo='" + Param[1] + "'";
                            break;
                        case 16:
                            ret = "DELETE RS_EmpFingerInfo WHERE FingerNo=(SELECT CardFingerNo FROM RS_EmpCard WHERE EmpSysID='" +
                              Param[1] + "')";
                            break;
                        case 17:
                            ret = "DELETE RS_EmpFingerInfo WHERE FingerNo=(SELECT CardFingerNo FROM RS_EmpCard WHERE EmpSysID='" +
                              Param[1] + "') AND FingerBkNo=" + Param[2];
                            break;
                        case 18:
                            ret = "DELETE RS_EmpFaceInfo WHERE FaceNo=(SELECT CardFingerNo FROM RS_EmpCard WHERE EmpSysID='" +
                              Param[1] + "') AND FaceBkNo=" + Param[2];
                            break;
                        case 19:
                            ret = "DELETE RS_EmpFaceInfo WHERE FaceNo=(SELECT CardFingerNo FROM RS_EmpCard WHERE EmpSysID='" +
                              Param[1] + "')";
                            break;
                        case 20:
                            ret = "UPDATE RS_Emp SET DepartSysID='" + Param[1] + "' WHERE EmpSysID='" + Param[2] + "'";
                            break;
                        case 21:
                            ret = "UPDATE RS_Emp SET OldCardNo='" + Param[2] + "' WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 22:
                            ret = "SELECT * FROM VRS_EmpDimission  WHERE 1=1 " + Param[2] + "";
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE'" + Param[1] + "%' OR CardSectorNo LIKE'%" + Param[1] + "')";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 23:
                            ret = "UPDATE RS_Emp SET IsDimission=1, DimissionOprt='" + Param[2] + "',DimissionReason='" + Param[3] + "'," +
                                              "DimissionDate='" + Param[4] + "'  WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 24:
                            ret = "UPDATE RS_Emp SET IsDimission=0, DimissionOprt='',DimissionReason=''," +
                                              "DimissionDate=''  WHERE EmpNo='" + Param[1] + "'";
                            break;

                        case 28:
                            ret = "UPDATE RS_Emp SET EmpName='" + Param[1] + "',EmpAddress='" + Param[2] + "',EmpPhoneNo='" + Param[3] + "'" +
                                ",OtherCardNo='" + Param[4] + "',EmpCertNo='" + Param[5] + "' WHERE EmpSysID='" + Param[6] + "'";
                            break;
                        case 29:
                            ret = "UPDATE RS_EmpDTPhoto SET EmpPhotoImage=@EmpPhotoImage WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 30:
                            ret = "INSERT INTO RS_EmpFaceInfo(FaceFlag,FaceNo,FaceBkNo,EnableFlag,FacePWD,FacePrivilege) VALUES(" +
                              Param[1] + "," + Param[2] + "," + Param[3] + "," + Param[4] + "," + Param[5] + ",0)";
                            break;
                        case 31:
                            ret = "UPDATE RS_EmpFaceInfo SET EnableFlag=" + Param[4] + ",FacePWD=" +
                              Param[5] + " WHERE FaceNo=" + Param[1] + " AND FaceNo=" + Param[2] + " AND FaceBkNo=" + Param[3];
                            break;
                        case 32:
                            ret = "SELECT FaceNo FROM RS_EmpFaceInfo WHERE FaceFlag=" + Param[1] + " AND FaceNo=" + Param[2] +
                              " AND FaceBkNo=" + Param[3];
                            break;
                        case 33:
                            ret = "SELECT * FROM RS_EmpDTPhoto WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 34:
                            ret = "SELECT EmpSysID FROM RS_EmpDTPhoto WHERE EmpSysID = '" + Param[1] + "'";
                            break;
                        case 35:
                            ret = "INSERT INTO RS_EmpDTPhoto(GUID, EmpSysID) VALUES(newid(), '" + Param[1] + "')";
                            break;
                        case 36:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID IN(" + Param[1] + ") ORDER BY EmpNo";
                            break;
                        case 101:
                            pos = Param[1].Length + 1;
                            ret = "SELECT MAX(CAST(SUBSTRING(EmpNo," + pos.ToString() + ",20-" + Param[1].Length.ToString() +
                              ") AS bigint)) AS MaxEmpNo FROM RS_Emp WHERE LEFT(EmpNo," + Param[1].Length.ToString() + ")='" +
                              Param[1] + "' AND ISNUMERIC(SUBSTRING(EmpNo," + pos.ToString() + ",20-" +
                              Param[1].Length.ToString() + "))=1";
                            break;
                        case 102:
                            ret = "SELECT * FROM VRS_EmpSex ORDER BY EmpSexID";
                            break;
                        case 103:
                            ret = "EXEC PGetMaxIDFromTable 'CardFingerNo','RS_EmpCard'";
                            break;
                        case 104:
                            ret = "SELECT * FROM RS_EmpPhoto WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 105:
                            ret = "SELECT CardSectorNo,CardStatusName,CardTypeName,EmpNo,EmpName,DepartName,CardStartDate," +
                              "CardEndDate,CardValudDate,CardFee,CardStored,EmpSysID,CardTypeID,CardPWD,CardUseTimes," +
                              "CardStatusID,DepositDiscount,CardCheckOrder FROM VRS_Emp " +
                              "WHERE (CardStatusID=10 OR CardStatusID=60)" + Param[1];
                            break;
                        case 106:
                            ret += Param[1] + " ORDER BY EmpNo";
                            break;
                        case 107:
                            ret = GetSQL(code, new string[] { "105", Param[2] });
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE'" + Param[1] + "%')";
                            break;
                        case 108:
                            ret = "SELECT CardStatusName FROM VRS_EmpCardStatus WHERE CardStatusID=20";
                            break;
                        case 109:
                            ret = "SELECT * FROM RS_Emp WHERE OtherCardNo='" + Param[1] + "'";
                            break;
                        case 110:
                            ret = "SELECT * FROM RS_Emp WHERE EmpSysID<>'" + Param[1] + "' AND OtherCardNo='" + Param[2] + "'";
                            break;
                        case 111:
                            ret = "SELECT EmpNo FROM RS_Emp WHERE EmpNo='" + Param[1] + "' OR EmpName='" + Param[1] + "'";
                            break;
                        case 112:
                            ret = "SELECT DepartID FROM RS_Depart WHERE DepartID='" + Param[1] + "' OR DepartName='" + Param[1] + "'";
                            break;
                        case 113:
                            ret += Param[1] + " ORDER BY CardStatusID,EmpNo";
                            break;
                        case 114:
                            ret = "SELECT * FROM RS_EmpFingerInfo WHERE FingerNo=" + Param[1];
                            break;
                        case 115:
                            ret = "SELECT * FROM RS_EmpFaceInfo WHERE FaceNo=" + Param[1];
                            break;
                        case 116:
                            ret = "EXEC PGetMaxIDFromTable 'CardSectorNo','VRS_EmpCardSectorNoList'";
                            break;
                        case 201:
                            ret = "SELECT * FROM VRS_EmpSex WHERE EmpSexName='" + Param[1] + "'";
                            break;
                        case 202:
                            ret = "SELECT * FROM RS_Depart WHERE DepartName='" + Param[1] + "'";
                            break;
                        case 203:
                            ret = "SELECT MAX(DepartID) AS DepartID FROM RS_Depart";
                            break;
                        case 204:
                            ret = "SELECT * FROM RS_CardType WHERE CardTypeID=" + Param[1];
                            break;
                        case 205:
                            ret = "INSERT INTO RS_Emp(EmpSysID,EmpNo,EmpName,EmpSexSysID,CardTypeSysID,DepartSysID,EmpHireDate," +
                              "EmpCertNo,EmpAddress,EmpZipNo,EmpPhoneNo,EmpEmail,IsAttend,OtherCardNo,IsDimission) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "'," +
                              Param[6] + ",'" + Param[7] + "','" + Param[8] + "','" + Param[9] + "','" + Param[10] + "','" +
                              Param[11] + "','Y', '" + Param[12] + "',0)";
                            break;
                        case 206:
                            ret = "SELECT * FROM VRS_EmpCardSectorNoList WHERE CardSectorNo='" + Param[1] + "'";
                            break;
                        case 207:
                            ret = "UPDATE RS_EmpCard SET CardSectorNo='" + Param[1] + "',CardStatusID='10',CardPWD='" + Param[2] + "'";
                            if ((Param[3] != "") && (Param[4] != ""))
                            {
                                ret += ",CardStartDate=" + Param[3] + ",CardEndDate=" + Param[4];
                            }
                            if ((Param.Length >= 7) && (Param[6] != "")) ret += ",CardFingerNo=" + Param[6];
                            ret += " WHERE EmpSysID='" + Param[5] + "'";
                            break;
                        case 208:
                            ret = "EXEC PGetMaxIDFromTable 'CardSectorNo','VRS_EmpCardSectorNoList'";
                            //ret = "SELECT ISNULL(MAX(CardSectorNo),0)+1 AS MaxID FROM VRS_EmpCardSectorNoList WHERE ISNUMERIC(CardSectorNo)=1";
                            break;
                        case 209:
                            ret = "SELECT CardSectorNo,EmpNo FROM VRS_Emp WHERE CardSectorNo='" + Param[1] + "' AND EmpSysID<>'" +
                              Param[2] + "'";
                            break;
                        case 210:
                            ret = "SELECT CardSectorNo FROM SY_BlackCard WHERE CardSectorNo='" + Param[1] + "'";
                            break;
                        case 211:
                            ret = "SELECT CardSectorNo,DATEADD(dd," + Param[1] + ",CardOprtDate) AS CardOprtDate " +
                              "FROM RS_EmpCardHistory WHERE CardSectorNo='" + Param[2] + "' AND CardIsValid=0";
                            break;
                        case 212:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID<>'" + Param[1] + "' AND CardPhysicsNo10='" +
                              Param[2] + "' AND CardStatusID<>10 AND CardStatusID<>60";
                            break;
                        case 213:
                            ret = "EXEC PRS_EmpCardFa '" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "'," + Param[5] + ",'" + Param[6] + "'," + Param[7] + "," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "'," + Param[11] + "," + Param[12] + ",'" +
                              Param[13] + "','" + Param[14] + "'";
                            break;
                        case 214:
                            ret = "UPDATE RS_EmpCard SET CardSectorNo='" + Param[1] + "'";
                            if (Param[2] == "1") ret += ",CardEndDate='" + Param[3] + "'";
                            ret += " WHERE EmpSysID='" + Param[4] + "'";
                            break;
                        case 215:
                            ret = "SELECT * FROM VRS_Emp WHERE CardSectorNo='" + Param[1] + "'";
                            if (Param.Length >= 3) ret += " AND CardPhysicsNo10='" + Param[2] + "'";
                            break;
                        case 216:
                            ret = "EXEC PRS_EmpCardRelieve '" + Param[1] + "','" + Param[2] + "'";
                            break;
                        case 217:
                            ret = Param[1];
                            pos = ret.ToLower().IndexOf("from");
                            ret = ret.Substring(0, pos - 1) + ",EmpPhotoImage " + ret.Substring(pos);
                            pos = ret.ToLower().IndexOf("vrs_emp");
                            ret = ret.Substring(0, pos + 7) + " a INNER JOIN RS_EmpPhoto b ON b.EmpSysID=a.EmpSysID " +
                              ret.Substring(pos + 8);
                            break;
                        case 218:
                            ret = " AND CardStatusID=20 ";
                            break;
                        case 219:
                            ret = "SELECT * FROM VRS_Emp WHERE IsDimission=0 AND CardTypeID=" + Param[1];
                            if (Param.Length > 3) ret += Param[2] + Param[3];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 220:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpHireDate='" + Param[1] + "'";
                            if (Param.Length > 3) ret += Param[2] + Param[3];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 221:
                            ret = "EXEC PRS_EmpCardLoss '" + Param[1] + "','" + Param[2] + "'";
                            break;
                        case 222:
                            ret = "EXEC PRS_EmpCardModify '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" + Param[9] + "'";
                            break;
                        case 223:
                            ret = " AND CardStatusID=40 ";
                            break;
                        case 224:
                            ret = "SELECT * FROM VRS_Emp WHERE 1=1 " + Param[1] + " AND CardStatusID=40 AND EmpNo='" + Param[2] + "'";
                            break;
                        case 225:
                            ret = "EXEC PRS_EmpCardChange '" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "'," + Param[5] + "," + Param[6] + ",'" + Param[7] + "','" + Param[8] + "','" + Param[9] + "'";
                            break;
                        case 226:
                            ret = "EXEC PRS_EmpCardRetirement '" + Param[1] + "'," + Param[2] + "," + Param[3] + "," +
                              Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + ",'" + Param[8] + "'," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'";
                            break;
                        case 227:
                            ret = "SELECT a.SFCardBalance,a.BTBalance FROM VSF_SFData a " +
                              "INNER JOIN(SELECT EmpSysID,MAX(CarduseTimes) AS CarduseTimes FROM VSF_SFData WHERE EmpSysID='" +
                              Param[1] + "' GROUP BY EmpSysID) b ON a.EmpSysID=b.EmpSysID AND a.CarduseTimes=b.CarduseTimes";
                            break;
                        case 228:
                            ret = "SELECT * FROM VRS_Emp WHERE CardPhysicsNo10='" + Param[1] + "'";
                            break;
                        case 229:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 230:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID='" + Param[1] + "' AND CardStatusID=20";
                            break;
                        case 231:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpNo='" + Param[1] + "'";
                            break;
                        case 232:
                            ret = "UPDATE RS_EmpCard SET CardSectorNo='" + Param[1] + "',CardPWD='" + Param[2] + "'";
                            if ((Param[3] != "") && (Param[4] != ""))
                            {
                                ret += ",CardStartDate=" + Param[3] + ",CardEndDate=" + Param[4];
                            }
                            if ((Param.Length >= 7) && (Param[6] != "")) ret += ",CardFingerNo=" + Param[6];
                            ret += " WHERE EmpSysID='" + Param[5] + "'";
                            break;
                        case 233:
                            ret = "UPDATE RS_EmpCard SET CardSectorNo='" + Param[1] + "' WHERE EmpSysID='" + Param[2] + "'";
                            break;
                        case 234:
                            ret = "UPDATE Rs_EmpCard SET CardSectorNo='" + Param[1] + "',CardStatusID=20,CardUseDate='" +
                              Param[2] + "',CardUseTimes=" + Param[3] + ",CardBalance=" + Param[4] + " WHERE EmpSysID='" +
                              Param[5] + "'";
                            break;
                        case 235:
                            ret = "INSERT INTO SY_CardOpter(GUID,EmpSysID,CardNo,OpterType,OpterDate,OprtSysID) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "'," + Param[3] + ",CONVERT(varchar(10),getdate(),120),'" +
                              Param[4] + "')";
                            break;
                        case 236:
                            ret = "UPDATE RS_EmpCard SET LockCard=1,LockOprtSysID='" + Param[1] + "',LockComputerName='" +
                              Param[2] + "' WHERE EmpSysID='" + Param[3] + "'";
                            break;
                        case 237:
                            ret = " AND (CardStatusID=20 OR CardStatusID=70) ";
                            break;
                        case 238:
                            ret = " AND (EmpSysID IN(SELECT EmpSysID FROM VRS_EmpFaceInfo)) ";
                            break;
                        case 239:
                            ret = " AND ((CardStatusID=10 AND ISNUMERIC(OtherCardNo)=1) OR CardStatusID=20) ";
                            break;
                        case 240:
                            ret = "SELECT * FROM VRS_Emp WHERE CardFingerNo=" + Param[1];
                            break;
                        case 241:
                            ret = "UPDATE RS_EmpCard SET LockCard=NULL,LockOprtSysID=NULL,LockComputerName=NULL " +
                              "WHERE LockComputerName='" + Param[1] + "'";
                            break;
                        case 242:
                            ret = "UPDATE RS_EmpCard SET CardFingerNo=" + Param[1] + " WHERE EmpSysID='" + Param[2] + "'";
                            break;
                        case 243:
                            ret = "UPDATE RS_EmpCard SET EmpFingerCount=0,EmpFaceCount=0,EmpPWCount=0,EmpCardCount=0,EmpPalmVeinCount=0";
                            break;
                        case 244:
                            ret = "SELECT * FROM VRS_Emp WHERE (CardStatusName LIKE '60%' OR CardStatusName LIKE '10%') AND CardTypeID=" + Param[1];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 245:
                            ret = "SELECT * FROM VRS_Emp WHERE IsDimission=1 AND CardTypeID=" + Param[1];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 246:
                            ret = " INSERT INTO RS_EmpHistoryCard(GUID,EmpSysID,EmpNo,EmpName,DepartSysID,DepartID,DepartName,CardSectorNo," +
                                    "OpterStartType,OpterStartDate,CardTypeID,CardTypeName,EmpCertNo,EmpPhoneNo,OpterEndType,OpterEndDate)" +
                                    "VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "'," +
                                    "'" + Param[6] + "','" + Param[7] + "'," +
                                    "'" + Param[8] + "','" + Param[9] + "'," + Param[10] + ",'" + Param[11] + "','" + Param[12] + "','" + Param[13] + "'";
                            if (Param.Length > 14)
                                ret += ",'" + Param[14] + "','" + Param[15] + "')";
                            else
                                ret += ",null,null)";
                            break;
                        case 247:
                            ret = "SELECT * FROM VRS_EmpHistoryCard WHERE EmpSysID='" + Param[1] + "' AND CardSectorNo='" + Param[2] + "'";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 248:
                            ret = "UPDATE RS_EmpHistoryCard SET OpterEndType='" + Param[1] + "',OpterEndDate='" + Param[2] + "' WHERE" +
                                   " EmpSysID='" + Param[3] + "' AND CardSectorNo='" + Param[4] + "' AND OpterEndType is null";
                            break;
                        case 249:
                            ret = "SELECT * FROM VRS_EmpHistoryCard  ORDER BY EmpNo";
                            break;
                        case 250:
                            ret = "SELECT * FROM VRS_Emp WHERE CardStatusName LIKE '20%'  OR CardStatusName LIKE '40%'";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 251:
                            ret = "SELECT * FROM VRS_EmpHistoryCard WHERE CardSectorNo='" + Param[1] + "'";
                            break;
                        case 252:
                            ret = "SELECT * FROM VRS_Emp WHERE CardStatusName LIKE '60%'";
                            ret += " ORDER BY EmpNo";
                            break;
                        case 253:
                            ret = "SELECT TOP 2 * FROM VSY_CardOpter WHERE EmpNo='" + Param[1] + "'";
                            ret += " ORDER BY OpterDate desc";
                            break;
                        case 254:
                            ret = "SELECT * FROM VRS_Emp WHERE DepartID='" + Param[1] + "'";
                            if (Param.Length > 2) ret += Param[2];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 255:
                            ret = "SELECT DepartSysID,DepartUpSysId,DepartID,DepartName FROM RS_Depart WHERE DepartUpSysId='' OR DepartUpSysId IS NULL";
                            break;
                        case 256:
                            ret = "SELECT DepartSysID,DepartUpSysId,DepartID,DepartName FROM RS_Depart WHERE DepartUpSysId='" + Param[1] + "' ORDER BY DepartID";
                            break;
                        case 257:
                            ret = Param[1];
                            if (Param[3] != "") ret += " AND (DepartSysID='" + Param[3] + "' OR DepartSysID IN (" + Param[4] + ")) ";
                            ret += Param[2];
                            break;
                        case 301:
                            ret = "SELECT * FROM VRS_Emp WHERE 1=1 " + Param[1];
                            break;
                        case 302:
                            ret = " ORDER BY EmpNo";
                            break;
                        case 303:
                            ret = GetSQL(code, new string[] { "301", Param[2] });
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE'" + Param[1] + "%' OR CardSectorNo LIKE'%" + Param[1] + "')";
                            break;
                        case 304:
                            ret = "SELECT * FROM SF_Allowance WHERE EmpSysID='" + Param[1] + "' AND AllowanceStatus=0";
                            break;
                        case 401:
                            ret = "SELECT '['+CAST(EmpSexID AS varchar(10))+']'+EmpSexName AS EmpSexName,COUNT(1) AS RecCount " +
                              "FROM VRS_Emp WHERE 1=1 " + Param[1] + " GROUP BY EmpSexID,EmpSexName";
                            break;
                        case 402:
                            ret = "SELECT '['+DepartID+']'+DepartName AS DepartName,COUNT(1) AS RecCount " +
                              "FROM VRS_Emp WHERE 1=1 " + Param[1] + " GROUP BY DepartID,DepartName";
                            break;
                        case 403:
                            ret = "SELECT '['+CAST(CardTypeID AS varchar(10))+']'+CardTypeName AS CardTypeName," +
                              "COUNT(1) AS RecCount FROM VRS_Emp WHERE 1=1 " + Param[1] + " GROUP BY CardTypeID,CardTypeName";
                            break;
                        case 404:
                            ret = "SELECT CardStatusName AS CardTypeName,COUNT(1) AS RecCount FROM VRS_Emp WHERE 1=1 " +
                              Param[1] + " GROUP BY CardStatusName";
                            break;
                        case 501:
                            ret = "SELECT * FROM VSY_BlackCard ORDER BY BlackDate DESC";
                            break;
                        case 502:
                            ret = "SELECT * FROM VSY_BlackCard WHERE BlackDate<='" + Param[1] + "' ORDER BY BlackDate DESC";
                            break;
                        case 503:
                            ret = "DELETE FROM SY_BlackCard WHERE CardSectorNo='" + Param[1] + "'";
                            break;
                        case 601:
                            ret = "SELECT CardPhysicsNo10,CardPhysicsNo8,CardTypeName,EmpNo,EmpName,DepartName,CardStartDate," +
                              "CardEndDate,CardValudDate,EmpSysID,CardTypeID,CardPWD FROM VRS_Emp WHERE CardStatusID=10" + Param[1];
                            break;
                        case 602:
                            ret += Param[1] + " ORDER BY CardStatusID,EmpNo";
                            break;
                        case 603:
                            ret = "SELECT CardPhysicsNo10,EmpNo FROM VRS_Emp WHERE CardPhysicsNo10='" +
                              Param[1] + "' AND EmpSysID<>'" + Param[2] + "'";
                            break;
                        case 604:
                            ret = "SELECT CardPhysicsNo10 FROM SY_BlackCard WHERE CardPhysicsNo10='" + Param[1] + "'";
                            break;
                        case 605:
                            ret = "UPDATE RS_EmpCard SET CardPhysicsNo10='" + Param[1] + "',CardPhysicsNo8='" +
                              Param[2] + "' WHERE EmpSysID='" + Param[3] + "'";
                            break;
                        case 606:
                            ret = " AND ISNUMERIC(CardPhysicsNo10)=1 ";
                            break;
                        case 607:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID='" + Param[1] + "' AND ISNUMERIC(CardPhysicsNo10)=1";
                            break;
                        case 608:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 701:
                            ret = "SELECT * FROM VRS_EmpDelete WHERE 1=1 " + Param[1] + " ORDER BY EmpNo";
                            break;
                        case 702:
                            ret = "SELECT * FROM VRS_EmpDelete WHERE 1=1 " + Param[1];
                            break;
                        case 703:
                            ret = " ORDER BY EmpNo";
                            break;
                        case 704:
                            ret = "UPDATE RS_Emp SET EmpLeaveStatus=0,EmpLeaveDate=NULL WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 705:
                            ret = GetSQL(code, new string[] { "702", Param[2] });
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE'" + Param[1] + "%' OR CardSectorNo LIKE'%" + Param[1] + "')";
                            break;
                        case 706:
                            ret = "UPDATE RS_Emp SET EmpName='" + Param[2] +
                              "' WHERE EmpSysID=(SELECT EmpSysID FROM RS_EmpCard WHERE CardFingerNo=" + Param[1] + ")";
                            break;
                        case 800:
                            if (Param[1] == "0")
                                ret = "EmpFingerCount";
                            else if (Param[1] == "1")
                                ret = "EmpFaceCount";
                            else if (Param[1] == "2")
                                ret = "EmpPWCount";
                            else if (Param[1] == "3")
                                ret = "EmpCardCount";
                            else
                                ret = "EmpPalmVeinCount";
                            ret = "UPDATE RS_EmpCard SET " + ret + "=" + Param[2] + " WHERE CardFingerNo=" + Param[3];
                            break;
                        case 801:
                            ret = "SELECT FaceNo,COUNT(1) AS RecCount FROM RS_EmpFaceInfo WHERE FaceBkNo>=0 AND FaceBkNo<=9 GROUP BY FaceNo";
                            break;
                        case 802:
                            ret = "SELECT FaceNo,COUNT(1) AS RecCount FROM RS_EmpFaceInfo WHERE FaceBkNo=12 GROUP BY FaceNo";
                            break;
                        case 803:
                            ret = "SELECT FaceNo,COUNT(1) AS RecCount FROM RS_EmpFaceInfo WHERE FaceBkNo=10 GROUP BY FaceNo";
                            break;
                        case 804:
                            ret = "SELECT FaceNo,COUNT(1) AS RecCount FROM RS_EmpFaceInfo WHERE FaceBkNo=11 GROUP BY FaceNo";
                            break;
                        case 805:
                            ret = "SELECT FaceNo,COUNT(1) AS RecCount FROM RS_EmpFaceInfo WHERE FaceBkNo>=13 AND FaceBkNo<=16 GROUP BY FaceNo";
                            break;
                        case 900:
                            ret = "SELECT CardFingerNo FROM RS_EmpCard WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 901:
                            ret = "DELETE FROM RS_EmpFaceInfo WHERE FaceNo=" + Param[1] + " AND FaceBkNo=" + Param[2];
                            break;
                        case 902:
                            ret = "UPDATE RS_EmpCard SET EmpPWCount=" + Param[1] + " WHERE EmpSysID='" + Param[2] + "'";
                            break;
                        case 903:
                            ret = "UPDATE RS_EmpCard SET EmpCardCount=" + Param[1] + " WHERE EmpSysID='" + Param[2] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_001004:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSY_OpterType ORDER BY OpterTypeID";
                            break;
                        case 1:
                            ret = "SELECT * FROM VSY_CardOpter WHERE OpterDate>='" + Param[7] + "' AND OpterDate<='" + Param[8] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[6] != "") ret += " AND OpterType IN(" + Param[6] + ")";
                            ret += Param[9] + " ORDER BY OpterDate,OpterTypeID,EmpNo";
                            break;
                        case 2:
                            ret = "SELECT OpterType,COUNT(1) AS OpterCount FROM VSY_CardOpter WHERE OpterDate>='" +
                              Param[1] + "' AND OpterDate<='" + Param[2] + "'" + Param[3] + " GROUP BY OpterType ORDER BY OpterType";
                            break;
                        case 3:
                            ret = "SELECT * FROM VRS_EmpHistoryCard WHERE OpterStartDate>='" + Param[7] + "' AND OpterStartDate<='" + Param[8] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardSectorNoInfoSQL(Param[10]);
                            if (Param[6] != "") ret += " AND CardTypeID IN(" + Param[6] + ")";
                            ret += Param[9] + " ORDER BY OpterStartDate, EmpNo";
                            break;
                    }
                    break;

                case DBCode.DB_002001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_MacInfo WHERE 1=1";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN";
                            break;
                        case 1:
                            ret = "INSERT INTO KQ_MacInfo(MacSysID,MacSN,MacType,MacConnType,MacIpAddress,MacPort,MacConnPWD," +
                              "MacDesc,MacPhysicsAddress,IsBigMac) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" +
                              Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" +
                              Param[8] + "'," + Param[9] + ")";
                            break;
                        case 2:
                            ret = "UPDATE KQ_MacInfo SET MacSN='" + Param[1] + "',MacType='" + Param[2] + "',MacConnType='" +
                              Param[3] + "',MacIpAddress='" + Param[4] + "',MacPort='" + Param[5] + "',MacConnPWD='" +
                              Param[6] + "',MacDesc='" + Param[7] + "',MacPhysicsAddress='" + Param[8] + "',IsBigMac=" +
                              Param[9] + " WHERE MacSysID='" + Param[10] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_MacInfo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM KQ_MacInfo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM KQ_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_MacInfo WHERE MacSysID<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 101:
                            ret = "EXEC PGetMaxIDFromTable 'MacSN','KQ_MacInfo'";
                            break;
                        case 102:
                            ret = "UPDATE KQ_MacInfo SET ParamInfo='" + Param[1] + "',AttendTime='" + Param[2] + "',BellTime='" +
                              Param[3] + "' WHERE MacSN='" + Param[4] + "'";
                            break;
                        case 103:
                            ret = " AND (MacConnType='LAN' OR MacConnType='GPRS')";
                            break;
                        case 104:
                            ret = "SELECT * FROM VRS_Emp WHERE CardStatusID=20 AND (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2];
                            break;
                        case 105:
                            ret = "EXEC PKQ_KQDataSave " + Param[1] + ",'" + Param[2] + "','" + Param[3] + "'," + Param[4] + "," +
                              Param[5] + "," + Param[6] + ",'" + Param[7] + "','" + Param[8] + "'," + Param[9]+"";
                            break;
                        case 106:
                            ret = "EXEC PKQ_KQDataFormat " + Param[1] + ",'" + Param[2] + "'";
                            break;
                        case 107:
                            ret = " AND (1=2)";
                            break;
                        case 108:
                            ret = "SELECT * FROM VRS_Emp WHERE (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2];
                            if (Param.Length > 3) ret += Param[3];
                            break;
                        case 109:
                            ret = "SELECT * FROM VRS_Emp WHERE (CardStatusID=20 OR CardStatusID=70) AND (EmpNo='" +
                              Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2];
                            break;
                        case 110:
                            ret = "SELECT * FROM VRS_Emp WHERE ((CardStatusID=10 AND ISNUMERIC(OtherCardNo)=1) OR CardStatusID=20) " +
                              "AND (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2];
                            break;
                        case 111:
                            ret = "INSERT INTO KQ_KQDataPhoto(GUID,Photo) VALUES('" + Param[1] + "',@Photo)";
                            break;
                        case 112:
                            ret = "SELECT * FROM KQ_KQDataPhoto WHERE GUID='" + Param[1] + "'";
                            break;
                        case 113:
                            ret = "INSERT INTO KQ_SuperData(GUID,DevID,SEnrollNo,GEnrollNo,ManID,ManName,BakNo,BakName,STime,OprtSysID," +
                              "OprtDate) VALUES(newid()," + Param[1] + "," + Param[2] + "," + Param[3] + "," + Param[4] + ",'" +
                             Param[5] + "'," + Param[6] + ",'" + Param[7] + "','" + Param[8] + "','" + Param[9] + "',getdate())";
                            break;
                        case 201:
                            ret = "SELECT * FROM VRS_Emp WHERE ISNUMERIC(CardPhysicsNo10)=1 AND (EmpNo='" +
                              Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2];
                            break;
                        case 202:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID IN(SELECT EmpSysID FROM VRS_EmpFaceInfo) AND (EmpNo='" +
                              Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2];
                            break;
                        case 203:
                            ret = "EXEC PKQ_OrderDataInsert '" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" +
                              Param[4] + "'," + Param[5] + "," + Param[6];
                            break;
                        case 204:
                            ret = "SELECT EmpSysID,EmpName,DepartID,DepartName,COUNT(1) AS EnrollCount FROM VRS_EmpFaceInfo " +
                              "WHERE (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2] +
                              " GROUP BY EmpSysID,EmpName,DepartID,DepartName";
                            break;
                        case 205:
                            ret = " AND EmpSysID IN(SELECT EmpSysID FROM VRS_EmpFaceInfo)";
                            break;
                        case 1000:
                            ret = "SELECT * FROM VKQ_MacInfoFinger WHERE 1=1";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN";
                            break;
                        case 1001:
                            ret = "DELETE FROM KQ_MacInfoFinger WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 1002:
                            ret = "EXEC PGetMaxIDFromTable 'MacSN','KQ_MacInfoFinger'";
                            break;
                        case 1003:
                            ret = "SELECT * FROM KQ_MacInfoFinger WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 1004:
                            ret = "SELECT * FROM KQ_MacInfoFinger WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 1005:
                            ret = "INSERT INTO KQ_MacInfoFinger(MacSysID,MacSN,MacType,MacConnType,MacIpAddress,MacPort," +
                              "MacConnPWD,MacDesc,MacPhysicsAddress) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" +
                              Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" +
                              Param[8] + "')";
                            break;
                        case 1006:
                            ret = "SELECT * FROM KQ_MacInfoFinger WHERE MacSysID<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 1007:
                            ret = "UPDATE KQ_MacInfoFinger SET MacSN='" + Param[1] + "',MacType='" + Param[2] + "',MacConnType='" +
                              Param[3] + "',MacIpAddress='" + Param[4] + "',MacPort='" + Param[5] + "',MacConnPWD='" +
                              Param[6] + "',MacDesc='" + Param[7] + "',MacPhysicsAddress='" + Param[8] + "' WHERE MacSysID='" +
                              Param[9] + "'";
                            break;
                        case 1008:
                            ret = "SELECT FingerNo FROM RS_EmpFingerInfo WHERE FingerNo=" + Param[1] + " AND FingerBkNo=" + Param[2];
                            break;
                        case 1009:
                            ret = "UPDATE RS_Emp SET FingerPrivilege=" + Param[1] + " WHERE EmpSysID='" + Param[2] + "'";
                            break;
                        case 1010:
                            ret = "INSERT INTO RS_EmpFingerInfo(FingerNo,FingerBkNo,EnableFlag,FingerPrivilege,FingerPWD) VALUES(" +
                              Param[1] + "," + Param[2] + "," + Param[3] + "," + Param[4] + "," + Param[5] + ")";
                            break;
                        case 1011:
                            ret = "UPDATE RS_EmpFingerInfo SET EnableFlag=" + Param[3] + ",FingerPrivilege=" +
                              Param[4] + ",FingerPWD=" + Param[5] + " WHERE FingerNo=" + Param[1] + " AND FingerBkNo=" + Param[2];
                            break;
                        case 1012:
                            ret = "UPDATE RS_EmpFingerInfo SET FingerTemplate=@FingerTemplate WHERE FingerNo=" +
                              Param[1] + " AND FingerBkNo=" + Param[2];
                            break;
                        case 1013:
                            ret = "SELECT * FROM VRS_EmpFingerInfo ORDER BY FingerNo,FingerBkNo";
                            break;
                        case 1014:
                            ret = "SELECT * FROM VRS_EmpFingerInfo WHERE EmpSysID='" + Param[1] + "' ORDER BY FingerNo,FingerBkNo";
                            break;
                        case 1015:
                            ret = "TRUNCATE TABLE RS_EmpFingerInfo";
                            break;
                        case 2000:
                            ret = "SELECT * FROM VKQ_MacInfoFace WHERE 1=1";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN";
                            break;
                        case 2001:
                            ret = "DELETE FROM KQ_MacInfoFace WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 2002:
                            ret = "EXEC PGetMaxIDFromTable 'MacSN','KQ_MacInfoFace'";
                            break;
                        case 2003:
                            ret = "SELECT * FROM KQ_MacInfoFace WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 2004:
                            ret = "SELECT * FROM KQ_MacInfoFace WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 2005:
                            ret = "INSERT INTO KQ_MacInfoFace(MacSysID,MacSN,MacTypeID,MacTypeName,MacConnType,MacIpAddress," +
                              "MacPort,MacConnPWD,MacDesc,MacPhysicsAddress,IsGPRS) VALUES(newid(),'" + Param[1] + "'," + Param[2] +
                              ",'" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" +
                              Param[8] + "','" + Param[9] + "'," + Param[10] + ")";
                            break;
                        case 2006:
                            ret = "SELECT * FROM KQ_MacInfoFace WHERE MacSysID<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 2007:
                            ret = "UPDATE KQ_MacInfoFace SET MacSN='" + Param[1] + "',MacTypeID=" + Param[2] + ",MacTypeName='" +
                              Param[3] + "',MacConnType='" + Param[4] + "',MacIpAddress='" + Param[5] + "',MacPort='" + Param[6] +
                              "',MacConnPWD='" + Param[7] + "',MacDesc='" + Param[8] + "',MacPhysicsAddress='" + Param[9] +
                              "',IsGPRS=" + Param[10] + " WHERE MacSysID='" + Param[11] + "'";
                            break;
                        case 2008:
                            ret = "SELECT FaceNo FROM RS_EmpFaceInfo WHERE FaceFlag=" + Param[1] + " AND FaceNo=" + Param[2] +
                              " AND FaceBkNo=" + Param[3];
                            break;
                        case 2009:
                            ret = "UPDATE RS_Emp SET FingerPrivilege=" + Param[1] + " WHERE EmpSysID='" + Param[2] + "'";
                            break;
                        case 2010:
                            ret = "INSERT INTO RS_EmpFaceInfo(FaceFlag,FaceNo,FaceBkNo,EnableFlag,FacePrivilege,FacePWD) VALUES(" +
                              Param[1] + "," + Param[2] + "," + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + ")";
                            break;
                        case 2011:
                            ret = "UPDATE RS_EmpFaceInfo SET EnableFlag=" + Param[4] + ",FacePrivilege=" + Param[5] + ",FacePWD=" +
                              Param[6] + " WHERE FaceNo=" + Param[1] + " AND FaceNo=" + Param[2] + " AND FaceBkNo=" + Param[3];
                            break;
                        case 2012:
                            ret = "UPDATE RS_EmpFaceInfo SET FaceTemplate=@FaceTemplate WHERE FaceFlag=" + Param[1] + " AND FaceNo=" +
                              Param[2] + " AND FaceBkNo=" + Param[3];
                            break;
                        case 2013:
                            ret = "SELECT * FROM VRS_EmpFaceInfo ORDER BY FaceNo,FaceBkNo";
                            break;
                        case 2014:
                            ret = "SELECT * FROM VRS_EmpFaceInfo WHERE FaceFlag=" + Param[1] + " AND EmpSysID='" +
                              Param[2] + "' ORDER BY FaceNo,FaceBkNo";
                            break;
                        case 2015:
                            ret = "TRUNCATE TABLE RS_EmpFaceInfo";
                            break;
                        case 2016:
                            ret = "SELECT * FROM VRS_EmpFaceInfo WHERE FaceFlag=" + Param[1] + " AND EmpSysID IN(" + Param[2] + ") ORDER BY FaceNo,FaceBkNo";
                            break;
                        case 3000:
                            ret = "SELECT * FROM KQ_PsssTime ORDER BY PassTimeID";
                            break;
                        case 3001:
                            ret = "DELETE FROM KQ_PsssTime WHERE PassTimeID=" + Param[1];
                            break;
                        case 3002:
                            ret = "EXEC PGetMaxIDFromTable 'PassTimeID','KQ_PsssTime'";
                            break;
                        case 3003:
                            ret = "SELECT * FROM KQ_PsssTime WHERE PassTimeID=" + Param[1];
                            break;
                        case 3004:
                            ret = "INSERT INTO KQ_PsssTime(PassTimeID,PassTimeName,T1S,T1E,T2S,T2E,T3S,T3E,T4S,T4E,T5S,T5E," +
                              "T6S,T6E,OprtNo,OprtDate) VALUES(" + Param[1] + ",'" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" +
                              Param[9] + "','" + Param[10] + "','" + Param[11] + "','" + Param[12] + "','" + Param[13] + "','" +
                              Param[14] + "','" + Param[15] + "',getdate())";
                            break;
                        case 3005:
                            ret = "UPDATE KQ_PsssTime SET PassTimeName='" + Param[2] + "',T1S='" + Param[3] + "',T1E='" +
                              Param[4] + "',T2S='" + Param[5] + "',T2E='" + Param[6] + "',T3S='" + Param[7] + "',T3E='" +
                              Param[8] + "',T4S='" + Param[9] + "',T4E='" + Param[10] + "',T5S='" + Param[11] + "',T5E='" +
                              Param[12] + "',T6S='" + Param[13] + "',T6E='" + Param[14] + "',OprtNo='" + Param[15] +
                              "',OprtDate=getdate() WHERE PassTimeID=" + Param[1];
                            break;
                        case 4000:
                            ret = "SELECT * FROM VKQ_EmpPsssTime WHERE EmpSysID is not null ";
                            if(Param.Length>1)
                            {
                                ret += GetEmpInfoSQL(Param[1], Param[2]) + GetKQMacSNInfoSQL(Param[3]);
                            }
                            ret += " ORDER BY EmpNo";
                            break;
                        case 4001:
                            ret = "SELECT * FROM VKQ_EmpPsssTime WHERE MacSN='" + Param[1] + "' ORDER BY EmpNo";
                            break;
                        case 4002:
                            ret = "DELETE FROM KQ_EmpPsssTime WHERE MacSN='" + Param[1] + "' AND EmpSysID='" + Param[2] + "'";
                            break;
                        case 4003:
                            ret = "SELECT * FROM KQ_EmpPsssTime WHERE MacSN='" + Param[1] + "' AND EmpSysID='" + Param[2] + "'";
                            break;
                        case 4004:
                            ret = "INSERT INTO KQ_EmpPsssTime(MacSN,EmpSysID,SunID,MonID,TueID,WedID,ThuID,FriID,SatID,OprtNo," +
                              "OprtDate,StartDate,EndDate) VALUES(" + Param[1] + ",'" + Param[2] + "'," + Param[3] + "," +
                              Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + "," + Param[8] + "," + Param[9] + ",'" +
                              Param[10] + "',getdate()," + Param[11] + "," + Param[12] + ")";
                            break;
                        case 4005:
                            ret = "UPDATE KQ_EmpPsssTime SET SunID=" + Param[3] + ",MonID=" + Param[4] + ",TueID=" + Param[5] + ",WedID=" +
                              Param[6] + ",ThuID=" + Param[7] + ",FriID=" + Param[8] + ",SatID=" + Param[9] + ",OprtNo='" +
                              Param[10] + "',OprtDate=getdate(),StartDate=" + Param[11] + ",EndDate=" + Param[12] + " WHERE MacSN='" +
                              Param[1] + "' AND EmpSysID='" + Param[2] + "'";
                            break;
                        case 4006:
                            ret = "DELETE FROM KQ_EmpPsssTime WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 4007:
                            ret = "DELETE FROM KQ_EmpPsssTime WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 4008:
                            ret = "SELECT CardFingerNo FROM VRS_Emp ORDER BY CardFingerNo";
                            break;
                        case 4009:
                            ret = "SELECT * FROM VKQ_EmpPsssTime WHERE EmpSysID='" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002002:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_OTType ORDER BY OtTypeNo";
                            break;
                        case 1:
                            ret = "INSERT INTO KQ_OTType(OtTypeSysID,OtTypeNo,OtTypeName,OtIsDefault) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 2:
                            ret = "UPDATE KQ_OTType SET OtTypeNo='" + Param[1] + "',OtTypeName='" + Param[2] +
                              "',OtIsDefault='" + Param[3] + "' WHERE OtTypeSysID='" + Param[4] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_OTType WHERE OtTypeSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM KQ_OTType WHERE OtTypeSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM KQ_OTType WHERE OtTypeNo='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_OTType WHERE OtTypeSysID<>'" + Param[1] + "' AND OtTypeNo='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "UPDATE KQ_OTType SET OtIsDefault='N' WHERE OtTypeNo<>'" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpOtSure WHERE (OtTypeSysID1='" + Param[1] +
                              "' OR OtTypeSysID2='" + Param[1] + "' OR OtTypeSysID3='" + Param[1] + "')";
                            break;
                        case 100:
                            ret = "SELECT * FROM VKQ_DayoffType ORDER BY DayOffTypeNo";
                            break;
                        case 101:
                            ret = "INSERT INTO KQ_DayoffType(DayOffTypeSysID,DayOffTypeNo,DayOffTypeName,DayOffIsGS) " +
                              "VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 102:
                            ret = "UPDATE KQ_DayoffType SET DayOffTypeNo='" + Param[1] + "',DayOffTypeName='" + Param[2] +
                              "',DayOffIsGS='" + Param[3] + "' WHERE DayOffTypeSysID='" + Param[4] + "'";
                            break;
                        case 103:
                            ret = "DELETE FROM KQ_DayoffType WHERE DayOffTypeSysID='" + Param[1] + "'";
                            break;
                        case 104:
                            ret = "SELECT * FROM KQ_DayoffType WHERE DayOffTypeSysID='" + Param[1] + "'";
                            break;
                        case 105:
                            ret = "SELECT * FROM KQ_DayoffType WHERE DayOffTypeNo='" + Param[1] + "'";
                            break;
                        case 106:
                            ret = "SELECT * FROM KQ_DayoffType WHERE DayOffTypeSysID<>'" + Param[1] + "' AND DayOffTypeNo='" +
                              Param[2] + "'";
                            break;
                        case 107:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpDayoff WHERE DayoffTypeSysID='" + Param[1] + "'";
                            break;
                        case 200:
                            ret = "SELECT * FROM VKQ_TripType ORDER BY TripTypeNo";
                            break;
                        case 201:
                            ret = "INSERT INTO KQ_TripType(TripTypeSysID,TripTypeNo,TripTypeName) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "')";
                            break;
                        case 202:
                            ret = "UPDATE KQ_TripType SET TripTypeNo='" + Param[1] + "',TripTypeName='" + Param[2] +
                              "' WHERE TripTypeSysID='" + Param[3] + "'";
                            break;
                        case 203:
                            ret = "DELETE FROM KQ_TripType WHERE TripTypeSysID='" + Param[1] + "'";
                            break;
                        case 204:
                            ret = "SELECT * FROM KQ_TripType WHERE TripTypeSysID='" + Param[1] + "'";
                            break;
                        case 205:
                            ret = "SELECT * FROM KQ_TripType WHERE TripTypeNo='" + Param[1] + "'";
                            break;
                        case 206:
                            ret = "SELECT * FROM KQ_TripType WHERE TripTypeSysID<>'" + Param[1] + "' AND TripTypeNo='" +
                              Param[2] + "'";
                            break;
                        case 207:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpTrip WHERE TripTypeSysID='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002003:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_WorkShifts ORDER BY ShiftNo";
                            break;
                        case 1:
                            ret = "INSERT INTO KQ_WorkShifts(GUID,ShiftNo,ShiftName,ShiftNormalHrs,ShiftNormalMin,ShiftOTMin," +
                              "InTime1,OutTime1,InIsPressed1,OutIsPressed1,InBefore1,OutAfter1,InLater1,InMaxLater1," +
                              "OutLeaveEarly1,OutMaxLeaveEarly1,OtTypeSysID1,InTime2,OutTime2,InIsPressed2,OutIsPressed2," +
                              "InBefore2,OutAfter2,InLater2,InMaxLater2,OutLeaveEarly2,OutMaxLeaveEarly2,OtTypeSysID2,InTime3," +
                              "OutTime3,InIsPressed3,OutIsPressed3,InBefore3,OutAfter3,InLater3,InMaxLater3,OutLeaveEarly3," +
                              "OutMaxLeaveEarly3,OtTypeSysID3,InTime4,OutTime4,InIsPressed4,OutIsPressed4,InBefore4,OutAfter4," +
                              "InLater4,InMaxLater4,OutLeaveEarly4,OutMaxLeaveEarly4,OtTypeSysID4,InTime5,OutTime5,InIsPressed5," +
                              "OutIsPressed5,InBefore5,OutAfter5,InLater5,InMaxLater5,OutLeaveEarly5,OutMaxLeaveEarly5," +
                              "OtTypeSysID5,AddRestMin1,AddRestMin2,AddRestMin3,AddRestMin4,AddInGetTime,AddOutGetTime," +
                              "AddISNormalGetInt,AddISOtGetInt,AddGetInt,AddIsAutoInBeforeOt,AddInBeforeOtMin," +
                              "AddIsAutoOutAfterOt,AddOutAfterOtMin,AddISFu1,AddISFu2,AddISFu3,AddISFu4,AddISFu5,ShiftType," +
                              "AddIsZL1,AddIsZL2,AddIsZL3,AddIsZL4) VALUES(newid()," + Param[1] + "," + Param[2] + "," +
                              Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + "," + Param[8] + "," +
                              Param[9] + "," + Param[10] + "," + Param[11] + "," + Param[12] + "," + Param[13] + "," +
                              Param[14] + "," + Param[15] + "," + Param[16] + "," + Param[17] + "," + Param[18] + "," +
                              Param[19] + "," + Param[20] + "," + Param[21] + "," + Param[22] + "," + Param[23] + "," +
                              Param[24] + "," + Param[25] + "," + Param[26] + "," + Param[27] + "," + Param[28] + "," +
                              Param[29] + "," + Param[30] + "," + Param[31] + "," + Param[32] + "," + Param[33] + "," +
                              Param[34] + "," + Param[35] + "," + Param[36] + "," + Param[37] + "," + Param[38] + "," +
                              Param[39] + "," + Param[40] + "," + Param[41] + "," + Param[42] + "," + Param[43] + "," +
                              Param[44] + "," + Param[45] + "," + Param[46] + "," + Param[47] + "," + Param[48] + "," +
                              Param[49] + "," + Param[50] + "," + Param[51] + "," + Param[52] + "," + Param[53] + "," +
                              Param[54] + "," + Param[55] + "," + Param[56] + "," + Param[57] + "," + Param[58] + "," +
                              Param[59] + "," + Param[60] + "," + Param[61] + "," + Param[62] + "," + Param[63] + "," +
                              Param[64] + "," + Param[65] + "," + Param[66] + "," + Param[67] + "," + Param[68] + "," +
                              Param[69] + "," + Param[70] + "," + Param[71] + "," + Param[72] + "," + Param[73] + "," +
                              Param[74] + "," + Param[75] + "," + Param[76] + "," + Param[77] + "," + Param[78] + "," +
                              Param[79] + "," + Param[80] + "," + Param[81] + "," + Param[82] + "," + Param[83] + ")";
                            break;
                        case 2:
                            ret = "UPDATE KQ_WorkShifts SET ShiftNo=" + Param[1] + ",ShiftName=" + Param[2] + ",ShiftNormalHrs=" +
                              Param[3] + ",ShiftNormalMin=" + Param[4] + ",ShiftOTMin=" + Param[5] + ",InTime1=" +
                              Param[6] + ",OutTime1=" + Param[7] + ",InIsPressed1=" + Param[8] + ",OutIsPressed1=" +
                              Param[9] + ",InBefore1=" + Param[10] + ",OutAfter1=" + Param[11] + ",InLater1=" +
                              Param[12] + ",InMaxLater1=" + Param[13] + ",OutLeaveEarly1=" + Param[14] + ",OutMaxLeaveEarly1=" +
                              Param[15] + ",OtTypeSysID1=" + Param[16] + ",InTime2=" + Param[17] + ",OutTime2=" +
                              Param[18] + ",InIsPressed2=" + Param[19] + ",OutIsPressed2=" + Param[20] + ",InBefore2=" +
                              Param[21] + ",OutAfter2=" + Param[22] + ",InLater2=" + Param[23] + ",InMaxLater2=" +
                              Param[24] + ",OutLeaveEarly2=" + Param[25] + ",OutMaxLeaveEarly2=" + Param[26] + ",OtTypeSysID2=" +
                              Param[27] + ",InTime3=" + Param[28] + ",OutTime3=" + Param[29] + ",InIsPressed3=" +
                              Param[30] + ",OutIsPressed3=" + Param[31] + ",InBefore3=" + Param[32] + ",OutAfter3=" +
                              Param[33] + ",InLater3=" + Param[34] + ",InMaxLater3=" + Param[35] + ",OutLeaveEarly3=" +
                              Param[36] + ",OutMaxLeaveEarly3=" + Param[37] + ",OtTypeSysID3=" + Param[38] + ",InTime4=" +
                              Param[39] + ",OutTime4=" + Param[40] + ",InIsPressed4=" + Param[41] + ",OutIsPressed4=" +
                              Param[42] + ",InBefore4=" + Param[43] + ",OutAfter4=" + Param[44] + ",InLater4=" +
                              Param[45] + ",InMaxLater4=" + Param[46] + ",OutLeaveEarly4=" + Param[47] + ",OutMaxLeaveEarly4=" +
                              Param[48] + ",OtTypeSysID4=" + Param[49] + ",InTime5=" + Param[50] + ",OutTime5=" +
                              Param[51] + ",InIsPressed5=" + Param[52] + ",OutIsPressed5=" + Param[53] + ",InBefore5=" +
                              Param[54] + ",OutAfter5=" + Param[55] + ",InLater5=" + Param[56] + ",InMaxLater5=" +
                              Param[57] + ",OutLeaveEarly5=" + Param[58] + ",OutMaxLeaveEarly5=" + Param[59] + ",OtTypeSysID5=" +
                              Param[60] + ",AddRestMin1=" + Param[61] + ",AddRestMin2=" + Param[62] + ",AddRestMin3=" +
                              Param[63] + ",AddRestMin4=" + Param[64] + ",AddInGetTime=" + Param[65] + ",AddOutGetTime=" +
                              Param[66] + ",AddISNormalGetInt=" + Param[67] + ",AddISOtGetInt=" + Param[68] + ",AddGetInt=" +
                              Param[69] + ",AddIsAutoInBeforeOt=" + Param[70] + ",AddInBeforeOtMin=" +
                              Param[71] + ",AddIsAutoOutAfterOt=" + Param[72] + ",AddOutAfterOtMin=" + Param[73] + ",AddISFu1=" +
                              Param[74] + ",AddISFu2=" + Param[75] + ",AddISFu3=" + Param[76] + ",AddISFu4=" +
                              Param[77] + ",AddISFu5=" + Param[78] + ",AddIsZL1=" + Param[80] + ",AddIsZL2=" +
                              Param[81] + ",AddIsZL3=" + Param[82] + ",AddIsZL4=" + Param[83] + " WHERE GUID=" + Param[79];
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_WorkShifts WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM VKQ_WorkShifts WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM KQ_WorkShifts WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_WorkShifts WHERE GUID<>'" + Param[1] + "' AND ShiftNo='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_ShiftRuleBody WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_ShiftPackage WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 9:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpWorkType WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 10:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_DepWorkType WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 11:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpShift WHERE ShiftNo='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_DepShift WHERE ShiftNo='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002004:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT *,CASE Flag WHEN 1 THEN '" + Param[2] + "' WHEN 2 THEN '" + Param[3] + "' ELSE '" +
                              Param[1] + "' END AS ShiftRuleFlagName FROM KQ_ShiftRuleHead ORDER BY ShiftRuleName";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_ShiftRuleHead WHERE ShiftRuleSysID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "DELETE FROM KQ_ShiftRuleBody WHERE ShiftRuleSysID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM KQ_WorkShifts ORDER BY ShiftNo";
                            break;
                        case 4:
                            ret = "SELECT * FROM KQ_ShiftRuleHead WHERE ShiftRuleSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM KQ_ShiftRuleHead WHERE ShiftRuleName='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_ShiftRuleHead WHERE ShiftRuleSysID<>'" + Param[1] + "' AND ShiftRuleName='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "INSERT INTO KQ_ShiftRuleHead(ShiftRuleSysID,ShiftRuleName,Flag,CycDays) VALUES(newid(),'" +
                              Param[1] + "'," + Param[2] + "," + Param[3] + ")";
                            break;
                        case 8:
                            ret = "UPDATE KQ_ShiftRuleHead SET ShiftRuleName='" + Param[1] + "',Flag=" + Param[2] + ",CycDays=" +
                              Param[3] + " WHERE ShiftRuleSysID='" + Param[4] + "'";
                            break;
                        case 9:
                            ret = "INSERT INTO KQ_ShiftRuleBody(GUID,ShiftRuleSysID,ShiftRuleRow,ShiftNo) SELECT newid()," +
                              "ShiftRuleSysID," + Param[1] + ",'" + Param[2] + "' FROM KQ_ShiftRuleHead WHERE ShiftRuleName='" +
                              Param[3] + "'";
                            break;
                        case 10:
                            ret = "SELECT * FROM KQ_ShiftRuleBody WHERE ShiftRuleSysID='" + Param[1] + "' ORDER BY ShiftRuleRow";
                            break;
                    }
                    break;
                case DBCode.DB_002005:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM KQ_EmpShift WHERE EmpSysID='" + Param[1] + "' AND YEAR(EmpShiftDate)=" +
                              Param[2] + " AND MONTH(EmpShiftDate)=" + Param[3];
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_EmpShift WHERE EmpSysID='" + Param[1] + "' AND YEAR(EmpShiftDate)=" +
                              Param[2] + " AND MONTH(EmpShiftDate)=" + Param[3];
                            break;
                        case 2:
                            ret = "INSERT INTO KQ_EmpShift(GUID,EmpSysID,EmpShiftDate,ShiftNo) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_EmpShift WHERE EmpSysID='" + Param[1] + "' AND EmpShiftDate>='" +
                              Param[2] + "' AND EmpShiftDate<='" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002006:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM KQ_DepShift WHERE DepartSysID='" + Param[1] + "' AND YEAR(DepShiftDate)=" +
                              Param[2] + " AND MONTH(DepShiftDate)=" + Param[3];
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_DepShift WHERE DepartSysID='" + Param[1] + "' AND YEAR(DepShiftDate)=" +
                              Param[2] + " AND MONTH(DepShiftDate)=" + Param[3];
                            break;
                        case 2:
                            ret = "INSERT INTO KQ_DepShift(GUID,DepartSysID,DepShiftDate,ShiftNo) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_DepShift WHERE DepartSysID='" + Param[1] + "' AND DepShiftDate>='" +
                              Param[2] + "' AND DepShiftDate<='" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002007:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VRS_Emp WHERE IsAttend='Y' " + Param[1];
                            ret += GetEmpInfoSQL(Param[2], Param[3]) + GetDepartInfoSQL(Param[4], Param[5], Param[6]);
                            ret += " ORDER BY EmpNo";
                            break;
                        case 1:
                            ret = "EXEC PKQ_CalcEmpShiftsTotal '" + Param[1] + "','" + Param[2] + "','" + Param[3] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_EmpShiftsTotal WHERE KQDate>='" + Param[1] + "' AND KQDate<='" + Param[2] + "'";
                            ret += GetEmpInfoSQL(Param[3], Param[4]) + GetDepartInfoSQL(Param[5], Param[6], Param[7]);
                            ret += Param[8] + " ORDER BY EmpNo,KQDate";
                            break;
                        case 3:
                            ret = "SELECT * FROM VKQ_EmpShift WHERE EmpShiftDate>='" + Param[1] + "' AND EmpShiftDate<='" + Param[2] + "'";
                            ret += GetEmpInfoSQL(Param[3], Param[4]) + GetDepartInfoSQL(Param[5], Param[6], Param[7]);
                            ret += Param[8] + " ORDER BY EmpNo,EmpShiftDate";
                            break;
                        case 4:
                            ret = "SELECT * FROM VKQ_DepShift WHERE DepShiftDate>='" + Param[1] + "' AND DepShiftDate<='" + Param[2] + "'";
                            ret += GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[6] + " ORDER BY DepartID,DepShiftDate";
                            break;
                        case 5:
                            ret = "SELECT *,CASE EmpRest WHEN 1 THEN '" + Param[1] + "' WHEN 2 THEN '" + Param[2] +
                              "' END AS EmpRest FROM VKQ_EmpWorkType WHERE 1=1";
                            ret += GetEmpInfoSQL(Param[3], Param[4]) + GetDepartInfoSQL(Param[5], Param[6], Param[7]);
                            ret += Param[8] + " ORDER BY EmpNo";
                            break;
                        case 6:
                            ret = "SELECT *,CASE DepRest WHEN 1 THEN '" + Param[1] + "' WHEN 2 THEN '" + Param[2] +
                              "' END AS DepRest FROM VKQ_DepWorkType WHERE 1=1";
                            ret += GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[6] + " ORDER BY DepartID";
                            break;
                        case 7:
                            ret = "SELECT * FROM VKQ_EmpShiftView WHERE EmpSysID='" + Param[1] + "' AND SihftKQDate>='" +
                              Param[2] + "' AND SihftKQDate<='" + Param[3] + "'";
                            break;
                        case 8:
                            ret = "SELECT * FROM VKQ_EmpShift WHERE GUID='" + Param[1] + "'";
                            break;
                        case 9:
                            ret = "UPDATE KQ_EmpShift SET ShiftNo='" + Param[1] + "' WHERE GUID='" + Param[2] + "'";
                            break;
                        case 10:
                            ret = "SELECT * FROM VKQ_DepShift WHERE GUID='" + Param[1] + "'";
                            break;
                        case 11:
                            ret = "UPDATE KQ_DepShift SET ShiftNo='" + Param[1] + "' WHERE GUID='" + Param[2] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002008:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_EmpDayOff WHERE 1=1" + Param[1] + " ORDER BY EmpNo,DayoffStartDate";
                            break;
                        case 1:
                            ret = "SELECT * FROM VKQ_EmpDayOff WHERE 1=1" + Param[1] + "";
                            break;
                        case 2:
                            ret = " ORDER BY EmpNo,DayoffStartDate";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_EmpDayOffEasy WHERE EmpSysID='" + Param[1] + "' AND DayOffBillNo='" +
                              Param[2] + "'";
                            break;
                        case 4:
                            ret = "SELECT ISNULL(MAX(SUBSTRING(DayOffBillNo,11,3)),0)+1 AS MaxNo FROM KQ_EmpDayOffEasy " +
                              "WHERE SUBSTRING(DayOffBillNo,1,10)='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM VKQ_EmpDayOff WHERE GUID='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_EmpDayoffEasy WHERE DayoffBillNo='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "INSERT INTO KQ_EmpDayoffEasy(GUID,DayoffBillNo,EmpSysID,DayoffStartDate,DayoffStartTime," +
                              "DayoffEndDate,DayoffEndTime,DayoffTypeSysID,DayoffReason,OprtSysID,OprtDate) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" +
                              Param[6] + "','" + Param[7] + "','" + Param[8] + "','" + Param[9] + "',getdate())";
                            break;
                        case 8:
                            ret = "UPDATE KQ_EmpDayoffEasy SET DayoffStartDate='" + Param[1] + "',DayoffStartTime='" +
                              Param[2] + "',DayoffEndDate='" + Param[3] + "',DayoffEndTime='" + Param[4] + "',DayoffTypeSysID='" +
                              Param[5] + "',DayoffReason='" + Param[6] + "',OprtSysID='" +
                              Param[7] + "',OprtDate=getdate() WHERE GUID='" + Param[8] + "'";
                            break;
                        case 101:
                            ret = GetSQL(code, new string[] { "1", Param[2] });
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')";
                            break;
                    }
                    break;
                case DBCode.DB_002009:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_EmpTrip WHERE 1=1" + Param[1] + " ORDER BY EmpNo,TripStartDate";
                            break;
                        case 1:
                            ret = "SELECT * FROM VKQ_EmpTrip WHERE 1=1" + Param[1] + "";
                            break;
                        case 2:
                            ret = " ORDER BY EmpNo,TripStartDate";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_EmpTripEasy WHERE EmpSysID='" + Param[1] + "' AND TripBillNo='" + Param[2] + "'";
                            break;
                        case 4:
                            ret = "SELECT ISNULL(MAX(SUBSTRING(TripBillNo,11,3)),0)+1 AS MaxNo FROM KQ_EmpTripEasy " +
                              "WHERE SUBSTRING(TripBillNo,1,10)='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM VKQ_EmpTrip WHERE GUID='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_EmpTripEasy WHERE TripBillNo='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "INSERT INTO KQ_EmpTripEasy(GUID,TripBillNo,EmpSysID,TripStartDate,TripStartTime,TripEndDate," +
                              "TripEndTime,TripTypeSysID,TripReason,OprtSysID,OprtDate) VALUES(newid(),'" + Param[1] + "','" +
                              Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" +
                              Param[7] + "','" + Param[8] + "','" + Param[9] + "',getdate())";
                            break;
                        case 8:
                            ret = "UPDATE KQ_EmpTripEasy SET TripStartDate='" + Param[1] + "',TripStartTime='" +
                              Param[2] + "',TripEndDate='" + Param[3] + "',TripEndTime='" + Param[4] + "',TripTypeSysID='" +
                              Param[5] + "',TripReason='" + Param[6] + "',OprtSysID='" +
                              Param[7] + "',OprtDate=getdate() WHERE GUID='" + Param[8] + "'";
                            break;
                        case 101:
                            ret = GetSQL(code, new string[] { "1", Param[2] });
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')";
                            break;
                    }
                    break;
                case DBCode.DB_002010:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_EmpOtSure WHERE 1=1" + Param[1] + " ORDER BY EmpNo,OtDate";
                            break;
                        case 1:
                            ret = "SELECT * FROM VKQ_EmpOtSure WHERE 1=1" + Param[1] + "";
                            break;
                        case 2:
                            ret = " ORDER BY EmpNo,OtDate";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_EmpOtSure WHERE EmpSysID='" + Param[1] + "' AND OtBillNo='" + Param[2] + "'";
                            break;
                        case 4:
                            ret = "SELECT ISNULL(MAX(SUBSTRING(OtBillNo,11,3)),0)+1 AS MaxNo FROM KQ_EmpOtSure " +
                              "WHERE SUBSTRING(OtBillNo,1,10)='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM VKQ_EmpOtSure WHERE GUID='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_EmpOtSure WHERE OtBillNo='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "INSERT INTO KQ_EmpOtSure(GUID,OtBillNo,EmpSysID,OtDate,OtTypeSysID1,Ot1Before,Ot1StartTime," +
                              "Ot1EndTime,Ot1After,OtTypeSysID2,Ot2Before,Ot2StartTime,Ot2EndTime,Ot2After,OtTypeSysID3," +
                              "Ot3Before,Ot3StartTime,Ot3EndTime,Ot3After,OtIsDirectResult,OtReason,OprtSysID,OprtDate) " +
                              "VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "'," +
                              Param[5] + "," + Param[6] + "," + Param[7] + "," + Param[8] + ",'" + Param[9] + "'," +
                              Param[10] + "," + Param[11] + "," + Param[12] + "," + Param[13] + ",'" + Param[14] + "'," +
                              Param[15] + "," + Param[16] + "," + Param[17] + "," + Param[18] + ",'" + Param[19] + "','" +
                              Param[20] + "','" + Param[21] + "',getdate())";
                            break;
                        case 101:
                            ret = GetSQL(code, new string[] { "1", Param[2] });
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')";
                            break;
                    }
                    break;
                case DBCode.DB_002011:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_EmpSignCard WHERE 1=1" + Param[1] + " ORDER BY EmpNo,KQDate,KQTime";
                            break;
                        case 1:
                            ret = "SELECT * FROM VKQ_EmpSignCard WHERE 1=1" + Param[1] + "";
                            break;
                        case 2:
                            ret = " ORDER BY EmpNo,KQDate,KQTime";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_KQData WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "EXEC PKQ_SignCardSave '" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" +
                              Param[4] + "','" + Param[5] + "'";
                            break;
                        case 101:
                            ret = GetSQL(code, new string[] { "1", Param[2] });
                            if (Param[1] != "") ret += " AND (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')";
                            break;
                    }
                    break;
                case DBCode.DB_002012:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "EXEC PKQ_Calc '" + Param[1] + "','" + Param[2] + "','" + Param[3] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002014:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_ReportResultDay WHERE ResultDate>='" + Param[6] + "' AND ResultDate<='" + Param[7] + "' AND ResultIsNormal<>'Y'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[8] + " ORDER BY EmpNo,ResultDate";
                            break;
                    }
                    break;
                case DBCode.DB_002015:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_KQData WHERE KQDate>='" + Param[6] + "' AND KQDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[8] + " ORDER BY EmpNo,KQDate,KQTime";
                            break;
                        case 1:
                            ret = "SELECT * FROM VKQ_KQDataFilterMark WHERE KQDate>='" + Param[6] + "' AND KQDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[8] + " ORDER BY EmpNo,KQDate";
                            break;
                        case 2:
                            ret = "SELECT * FROM VKQ_ReportResultDay WHERE ResultDate>='" + Param[6] + "' AND ResultDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[9] == "1")
                                ret += " AND (ResultIsNormal='Y')";
                            else
                            {
                                s = Param[10] == "1" ? "CAST(ResultAbsentDays AS real)>0" : "";
                                s1 = Param[11] == "1" ? "ResultLaterMinute>0" : "";
                                s2 = Param[12] == "1" ? "ResultLeaveEarlyMinute>0" : "";
                                if ((s != "") && (s1 != "") && (s2 != ""))
                                    ret += " AND (" + s + " OR " + s1 + " OR " + s2 + ")";
                                else if ((s != "") && (s1 != "") && (s2 == ""))
                                    ret += " AND (" + s + " OR " + s1 + ")";
                                else if ((s != "") && (s1 == "") && (s2 != ""))
                                    ret += " AND (" + s + " OR " + s2 + ")";
                                else if ((s == "") && (s1 != "") && (s2 != ""))
                                    ret += " AND (" + s1 + " OR " + s2 + ")";
                                else if ((s != "") && (s1 == "") && (s2 == ""))
                                    ret += " AND (" + s + ")";
                                else if ((s == "") && (s1 != "") && (s2 == ""))
                                    ret += " AND (" + s1 + ")";
                                else if ((s == "") && (s1 == "") && (s2 != ""))
                                    ret += " AND (" + s2 + ")";
                            }
                            ret += Param[8] + " ORDER BY EmpNo,ResultDate";
                            break;
                        case 3:
                            ret = "SELECT * FROM VKQ_ReportResultMonth WHERE ResultYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[7] + " ORDER BY EmpNo";
                            break;
                        case 4:
                            ret = "SELECT * FROM VKQ_ReportResultTotal WHERE ResultYM='" + Param[6] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[7] + " ORDER BY EmpNo";
                            break;
                        case 5:
                            ret = "SELECT * FROM VKQ_OrderData WHERE OrderDate>='" + Param[6] + "' AND OrderDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[8] + " ORDER BY DepartID,EmpNo,OrderDate";
                            break;
                        case 101:
                            ret = "SELECT * FROM VKQ_KQData WHERE EmpNo='" + Param[1] + "' AND KQDate='" + Param[2] + "' ORDER BY KQTime";
                            break;
                    }
                    break;
                case DBCode.DB_002016:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM KQ_HolidaySch ORDER BY HolidayNo";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_Holiday WHERE HolidaySysID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "DELETE FROM KQ_HolidaySch WHERE HolidaySysID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpWorkType WHERE HolidaySysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_DepWorkType WHERE HolidaySysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM VKQ_HolidayTimeSeg ORDER BY HolidayTimeSegID";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_HolidaySch WHERE HolidaySysID='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "SELECT * FROM VKQ_Holiday WHERE HolidaySysID='" + Param[1] + "' ORDER BY HolidayDate";
                            break;
                        case 8:
                            ret = "SELECT * FROM KQ_HolidaySch WHERE HolidayNo='" + Param[1] + "'";
                            break;
                        case 9:
                            ret = "SELECT * FROM KQ_HolidaySch WHERE HolidaySysID<>'" + Param[1] + "' AND HolidayNo='" + Param[2] + "'";
                            break;
                        case 10:
                            ret = "INSERT INTO KQ_HolidaySch(HolidaySysID,HolidayNo,HolidayName) VALUES(newid(),'" + Param[1] + "','" +
                              Param[2] + "')";
                            break;
                        case 11:
                            ret = "UPDATE KQ_HolidaySch SET HolidayNo='" + Param[1] + "',HolidayName='" + Param[2] +
                              "' WHERE HolidaySysID='" + Param[3] + "'";
                            break;
                        case 12:
                            ret = "DELETE FROM KQ_Holiday WHERE HolidaySysID='" + Param[1] + "'";
                            break;
                        case 13:
                            ret = "INSERT INTO KQ_Holiday(GUID,HolidaySysID,HolidayDate,HolidayName,HolidayTimeSeg,HolidayOtTypeSysID) " +
                              "SELECT newid(),HolidaySysID,'" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" + Param[4] + "' " +
                              "FROM KQ_HolidaySch WHERE HolidayNo='" + Param[5] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002017:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT *,WeekEndName AS WeekEndNameA FROM KQ_WeekEndSch ORDER BY WeekEndNo";
                            break;
                        case 1:
                            ret = "DELETE FROM KQ_WeekEnd WHERE WeekEndSysID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "DELETE FROM KQ_WeekEndSch WHERE WeekEndSysID='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_EmpWorkType WHERE WeekEndSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT COUNT(1) AS RecCount FROM KQ_DepWorkType WHERE WeekEndSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM KQ_WeekEndSch WHERE WeekEndSysID='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM KQ_WeekEnd WHERE WeekEndSysID='" + Param[1] + "' ORDER BY WeekIndex";
                            break;
                        case 7:
                            ret = "SELECT * FROM KQ_WeekEndSch WHERE WeekEndNo='" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "SELECT * FROM KQ_WeekEndSch WHERE WeekEndSysID<>'" + Param[1] + "' AND WeekEndNo='" + Param[2] + "'";
                            break;
                        case 9:
                            ret = "INSERT INTO KQ_WeekEndSch(WeekEndSysID,WeekEndNo,WeekEndName) VALUES(newid(),'" + Param[1] + "','" +
                              Param[2] + "')";
                            break;
                        case 10:
                            ret = "UPDATE KQ_WeekEndSch SET WeekEndNo='" + Param[1] + "',WeekEndName='" + Param[2] +
                              "' WHERE WeekEndSysID='" + Param[3] + "'";
                            break;
                        case 11:
                            ret = "DELETE FROM KQ_WeekEnd WHERE WeekEndSysID='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "INSERT INTO KQ_WeekEnd(GUID,WeekEndSysID,WeekIndex,WeekTimeSeg,WeekOtTypeSysID) SELECT newid()," +
                              "WeekEndSysID," + Param[1] + "," + Param[2] + ",'" + Param[3] + "' FROM KQ_WeekEndSch WHERE WeekEndNo='" +
                              Param[4] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002018:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT *,CASE EmpRest WHEN 1 THEN '" + Param[1] + "' WHEN 2 THEN '" + Param[2] + "' ELSE '' END AS " +
                              "EmpRestName FROM VKQ_EmpWorkType ORDER BY EmpNo";
                            break;
                        case 1:
                            ret = "INSERT INTO KQ_EmpWorkType(GUID,EmpSysID,ShiftNo,EmpOtIsHaveBar,EmpIsPressed,EmpRest,WeekEndSysID," +
                              "HolidaySysID,EmpTimeWorkUnit,EmpRestDays) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" +
                              Param[3] + "','" + Param[4] + "'," + Param[5] + "," + Param[6] + "," + Param[7] + "," +
                              Param[8] + "," + Param[9] + ")";
                            break;
                        case 2:
                            ret = "UPDATE KQ_EmpWorkType SET ShiftNo='" + Param[1] + "',EmpOtIsHaveBar='" + Param[2] + "',EmpIsPressed='" +
                              Param[3] + "',EmpRest=" + Param[4] + ",WeekEndSysID=" + Param[5] + ",HolidaySysID=" +
                              Param[6] + ",EmpTimeWorkUnit=" + Param[7] + ",EmpRestDays=" + Param[8] + " WHERE GUID='" + Param[9] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_EmpWorkType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM VKQ_EmpWorkType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "DELETE FROM KQ_EmpWorkType WHERE EmpSysID='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002019:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT *,CASE DepRest WHEN 1 THEN '" + Param[1] + "' WHEN 2 THEN '" + Param[2] + "' ELSE '' END AS " +
                              "DepRestName FROM VKQ_DepWorkType ORDER BY DepartID";
                            break;
                        case 1:
                            ret = "INSERT INTO KQ_DepWorkType(GUID,DepartSysID,ShiftNo,DepOtIsHaveBar,DepIsPressed,DepRest,WeekEndSysID," +
                              "HolidaySysID,DepTimeWorkUnit,DepRestDays) VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" +
                              Param[3] + "','" + Param[4] + "'," + Param[5] + "," + Param[6] + "," + Param[7] + "," +
                              Param[8] + "," + Param[9] + ")";
                            break;
                        case 2:
                            ret = "UPDATE KQ_DepWorkType SET ShiftNo='" + Param[1] + "',DepOtIsHaveBar='" + Param[2] + "',DepIsPressed='" +
                              Param[3] + "',DepRest=" + Param[4] + ",WeekEndSysID=" + Param[5] + ",HolidaySysID=" +
                              Param[6] + ",DepTimeWorkUnit=" + Param[7] + ",DepRestDays=" + Param[8] + " WHERE GUID='" + Param[9] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_DepWorkType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM VKQ_DepWorkType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "DELETE FROM KQ_DepWorkType WHERE DepartSysID='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_002020:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_ShiftPackage ORDER BY ShiftPackNo";
                            break;
                        case 1:
                            ret = "INSERT INTO KQ_WorkShifts(GUID,ShiftNo,ShiftName,ShiftType) VALUES(newid(),'" + Param[1] + "','" +
                              Param[2] + "',1)";
                            break;
                        case 2:
                            ret = "UPDATE KQ_WorkShifts SET ShiftNo='" + Param[1] + "',ShiftName='" +
                              Param[2] + "' WHERE GUID='" + Param[3] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_ShiftPackage WHERE ShiftPackNo=(SELECT ShiftNo FROM KQ_WorkShifts " +
                              "WHERE GUID='" + Param[1] + "')";
                            break;
                        case 4:
                            ret = "SELECT * FROM VKQ_ShiftPackage WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM KQ_ShiftPackage WHERE ShiftPackNo='" + Param[1] + "' ORDER BY PrioritySeq";
                            break;
                        case 6:
                            ret = "INSERT INTO KQ_ShiftPackage(GUID,ShiftPackNo,ShiftNo,IsBackUp,BackUpShiftNo,IsPrevious,PrioritySeq) " +
                              "VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "','" +
                              Param[5] + "'," + Param[6] + ")";
                            break;
                        case 101:
                            ret = "SELECT * FROM VKQ_WorkShiftsA WHERE (ShiftType=0 OR ShiftType=2) AND ShiftNo<>'REST' " +
                              "AND ShiftNo<>'NULL' ORDER BY ShiftNo";
                            break;
                    }
                    break;
                case DBCode.DB_002021:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VKQ_ShiftCountH ORDER BY ShiftCountHNo";
                            break;
                        case 1:
                            ret = "INSERT INTO KQ_WorkShifts(GUID,ShiftNo,ShiftName,ShiftType) VALUES(newid(),'" + Param[1] + "','" +
                              Param[2] + "',2)";
                            break;
                        case 2:
                            ret = "UPDATE KQ_WorkShifts SET ShiftNo='" + Param[1] + "',ShiftName='" +
                              Param[2] + "' WHERE GUID='" + Param[3] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM KQ_ShiftCountH WHERE ShiftCountHNo=(SELECT ShiftNo FROM KQ_WorkShifts " +
                              "WHERE GUID='" + Param[1] + "')";
                            break;
                        case 4:
                            ret = "SELECT * FROM VKQ_ShiftCountH WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "INSERT INTO KQ_ShiftCountH(GUID,ShiftCountHNo,InTime,OutTime,AddISGetInt,AddGetInt) VALUES(newid(),'" +
                              Param[1] + "'," + Param[2] + "," + Param[3] + ",'" + Param[4] + "','" + Param[5] + "')";
                            break;
                        case 6:
                            ret = "UPDATE KQ_ShiftCountH SET InTime=" + Param[1] + ",OutTime=" + Param[2] + ",AddISGetInt='" +
                              Param[3] + "',AddGetInt='" + Param[4] + "' WHERE ShiftCountHNo='" + Param[5] + "'";
                            break;
                    }
                    break;

                case DBCode.DB_003001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VMJ_MacInfo WHERE 1=1";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN";
                            break;
                        case 1:
                            ret = "INSERT INTO MJ_MacInfo(MacSysID,MacSN,MacDoorType,MacConnType,MacIpAddress,MacPort,MacConnPWD," +
                              "MacDesc,CardProtocol) VALUES(newid(),'" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "'," + Param[8] + ")";
                            break;
                        case 2:
                            ret = "UPDATE MJ_MacInfo SET MacSN='" + Param[1] + "',MacDoorType=" + Param[2] + ",MacConnType='" +
                              Param[3] + "',MacIpAddress='" + Param[4] + "',MacPort='" + Param[5] + "',MacConnPWD='" +
                              Param[6] + "',MacDesc='" + Param[7] + "',CardProtocol=" + Param[8] + " WHERE MacSysID='" + Param[9] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM MJ_MacInfo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM VMJ_MacInfo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM VMJ_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM VMJ_MacInfo WHERE MacSysID<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "SELECT MacDoorSysID,MacDoorID,MacDoorName,MacDoorDelay,MacDoorInterval,MacDoorCommandWay,MacDoorPassword " +
                              "FROM MJ_MacDoorInfo WHERE MacSysID='" + Param[1] + "' ORDER BY MacDoorID";
                            break;
                        case 8:
                            ret = "SELECT MacReadSysID,MacReadID,MacReadImpact,IsApplyWork,IsAndPassword " +
                              "FROM MJ_MacReadInfo WHERE MacSysID='" + Param[1] + "' ORDER BY MacReadID";
                            break;
                        case 9:
                            ret = "UPDATE MJ_MacDoorInfo SET MacDoorName='" + Param[1] + "',MacDoorDelay=" +
                              Param[2] + " WHERE MacDoorSysID='" + Param[3] + "'";
                            break;
                        case 10:
                            ret = "UPDATE MJ_MacReadInfo SET MacReadImpact='" + Param[1] + "',IsApplyWork='" +
                              Param[2] + "',IsAndPassword='" + Param[3] + "' WHERE MacReadSysID='" + Param[4] + "'";
                            break;
                        case 11:
                            ret = "SELECT a.IsAndPassword FROM MJ_MacReadInfo a " +
                              "INNER JOIN MJ_MacDoorInfo b ON b.MacDoorSysID=a.MacDoorSysID AND b.MacDoorID='" + Param[1] + "' " +
                              "INNER JOIN MJ_MacInfo c ON c.MacSysID=b.MacSysID " +
                              "ORDER BY a.MacReadID";
                            break;
                        case 101:
                            ret = "SELECT * FROM VMJ_MacDoorInfo ORDER BY MacSN,MacDoorID";
                            break;
                        case 102:
                            ret = "SELECT * FROM VMJ_MacDoorInfo WHERE MacDoorSysID='" + Param[1] + "'";
                            break;
                        case 103:
                            ret = "UPDATE MJ_MacDoorInfo SET MacDoorPassword='" + Param[1] + "' WHERE MacDoorSysID='" + Param[2] + "'";
                            break;
                        case 104:
                            ret = "SELECT * FROM VMJ_MacDoorInfo WHERE MacSN='" + Param[1] + "' ORDER BY MacDoorID";
                            break;
                        case 105:
                            ret = "UPDATE MJ_MacInfo SET MacLocks='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 106:
                            ret = "UPDATE MJ_MacInfo SET IsReturn='" + Param[1] + "',MacReturns='" + Param[2] +
                              "' WHERE MacSysID='" + Param[3] + "'";
                            break;
                        case 107:
                            ret = "UPDATE MJ_MacDoorInfo SET IsMoreCard='" + Param[1] + "',MacMoreCard='" + Param[2] +
                              "' WHERE MacDoorSysID='" + Param[3] + "'";
                            break;
                        case 108:
                            ret = "SELECT * FROM VRS_Emp WHERE CardStatusID=20 AND EmpSysID IN(" + Param[1] + ")";
                            break;
                        case 109:
                            ret = "UPDATE MJ_MacDoorInfo SET IsFirstCard='" + Param[1] + "',MacFirstCard='" + Param[2] +
                              "' WHERE MacDoorSysID='" + Param[3] + "'";
                            break;
                        case 110:
                            ret = "SELECT * FROM VMJ_MacDoorCommandWay ORDER BY MacDoorCommandWayID";
                            break;
                        case 111:
                            ret = "UPDATE MJ_MacDoorInfo SET IsInoutCard='" + Param[1] + "',MacInoutCard='" + Param[2] +
                              "' WHERE MacDoorSysID='" + Param[3] + "'";
                            break;
                        case 112:
                            ret = "UPDATE MJ_MacInfo SET MacExtensionBoard='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 201:
                            ret = " AND (LEFT(MacSN,2)='02' OR LEFT(MacSN,2)='04')";
                            break;
                        case 202:
                            ret = " AND (LEFT(MacSN,2)='01' OR LEFT(MacSN,2)='02')";
                            break;
                        case 301:
                            ret = "SELECT * FROM VRS_Emp WHERE ISNUMERIC(CardPhysicsNo10)=1 AND EmpSysID IN(" + Param[1] + ")";
                            break;
                        case 1000:
                            ret = "SELECT * FROM VMJ_MacInfoNew WHERE 1=1";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN";
                            break;
                        case 1001:
                            ret = " AND (LEFT(MacSN,2)='22' OR LEFT(MacSN,2)='24')";
                            break;
                        case 1002:
                            ret = " AND (LEFT(MacSN,2)='21' OR LEFT(MacSN,2)='22')";
                            break;
                        case 1003:
                            ret = "SELECT * FROM VMJ_MacInfoNew WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 1004:
                            ret = "SELECT * FROM VMJ_MacInfoNew WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 1005:
                            ret = "SELECT * FROM VMJ_MacInfoNew WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 1006:
                            ret = "SELECT * FROM VMJ_MacInfoNew WHERE MacSysID<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 1007:
                            ret = "SELECT * FROM VMJ_MacDoorInfoNew ORDER BY MacSN,MacDoorID";
                            break;
                        case 1008:
                            ret = "SELECT * FROM VMJ_MacDoorInfoNew WHERE MacDoorSysID='" + Param[1] + "'";
                            break;
                        case 1009:
                            ret = "SELECT * FROM VMJ_MacDoorInfoNew WHERE MacSN='" + Param[1] + "' ORDER BY MacDoorID";
                            break;
                        case 1010:
                            ret = "UPDATE MJ_MacDoorInfo SET MacDoorName='" + Param[1] + "',MacDoorDelay=" +
                              Param[2] + ",MacDoorInterval=" + Param[3] + " WHERE MacDoorSysID='" + Param[4] + "'";
                            break;
                        case 1011:
                            ret = " AND (MacConnType='LAN')";
                            break;
                    }
                    break;
                case DBCode.DB_003002:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VMJ_Holiday ORDER BY MJHoliID";
                            break;
                        case 1:
                            ret = "SELECT * FROM MJ_Holiday WHERE MJHoliID=";
                            if (Param[1] == "")
                                ret += "0";
                            else
                                ret += Param[1];
                            break;
                        case 2:
                            ret = "UPDATE MJ_Holiday SET MJHoliIsApply=" + Param[1] + ",MJHoliBeginDate=" + Param[2] +
                              ",MJHoliEndDate=" + Param[3] + ",MJHoliMemo='" + Param[4] + "' WHERE MJHoliID=" + Param[5];
                            break;
                        case 3:
                            ret = "UPDATE MJ_Holiday SET MJHoliIsApply=" + Param[1] + ",MJHoliBeginDate=" + Param[2] +
                              ",MJHoliEndDate=" + Param[3] + ",MacTimeNo=" + Param[4] + ",MJHoliMemo='" + Param[5] +
                              "' WHERE MJHoliID=" + Param[6];
                            break;
                    }
                    break;
                case DBCode.DB_003003:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VMJ_MacTime ORDER BY MacTimeNo";
                            break;
                        case 1:
                            ret = "INSERT INTO MJ_MacTime(MacTimeSysID,MacTimeNo,MacTimeName,MacTimeBeginTime1,MacTimeEndTime1," +
                              "MacTimeBeginTime2,MacTimeEndTime2,MacTimeBeginTime3,MacTimeEndTime3,MacTimeInType1,MacTimeBeginTime4," +
                              "MacTimeEndTime4,MacTimeBeginTime5,MacTimeEndTime5,MacTimeBeginTime6,MacTimeEndTime6,MacTimeInType2," +
                              "MacTimeWeekIndex,MacTimeLimit) VALUES(newid()," + Param[1] + ",'" + Param[2] + "','" + Param[3] + "','" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "'," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "','" + Param[12] + "','" + Param[13] + "','" +
                              Param[14] + "','" + Param[15] + "'," + Param[16] + "," + Param[17] + "," + Param[18] + ")";
                            break;
                        case 2:
                            ret = "UPDATE MJ_MacTime SET MacTimeNo=" + Param[1] + ",MacTimeName='" + Param[2] + "',MacTimeBeginTime1='" +
                              Param[3] + "',MacTimeEndTime1='" + Param[4] + "',MacTimeBeginTime2='" + Param[5] + "',MacTimeEndTime2='" +
                              Param[6] + "',MacTimeBeginTime3='" + Param[7] + "',MacTimeEndTime3='" + Param[8] + "',MacTimeInType1=" +
                              Param[9] + ",MacTimeBeginTime4='" + Param[10] + "',MacTimeEndTime4='" + Param[11] + "',MacTimeBeginTime5='" +
                              Param[12] + "',MacTimeEndTime5='" + Param[13] + "',MacTimeBeginTime6='" + Param[14] + "',MacTimeEndTime6='" +
                              Param[15] + "',MacTimeInType2=" + Param[16] + ",MacTimeWeekIndex=" + Param[17] + ",MacTimeLimit=" +
                              Param[18] + " WHERE MacTimeSysID='" + Param[19] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM MJ_MacTime WHERE MacTimeSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM MJ_MacTime WHERE MacTimeNo=" + Param[1];
                            break;
                        case 5:
                            ret = "SELECT * FROM MJ_MacTime WHERE MacTimeSysID<>'" + Param[1] + "' AND MacTimeNo=" + Param[2];
                            break;
                        case 6:
                            ret = "SELECT * FROM MJ_MacTime WHERE MacTimeSysID='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "SELECT * FROM VMJ_MacTimeNew ORDER BY MacTimeNo";
                            break;
                        case 101:
                            ret = "EXEC PGetMaxIDFromTable 'MacTimeNo','MJ_MacTime'";
                            break;
                        case 102:
                            ret = "SELECT * FROM VMJ_TimeInType ORDER BY TimeInTypeID";
                            break;
                        case 103:
                            ret = "SELECT * FROM VMJ_TimeInTypeNew ORDER BY TimeInTypeID";
                            break;
                        case 1000:
                            ret = "SELECT * FROM VMJ_MacTimeHeader ORDER BY MacTimeHeaderTimeNo";
                            break;
                        case 1001:
                            ret = "INSERT INTO MJ_MacTimeHeader(MacTimeHeaderSysID,MacTimeHeaderTimeNo,MacTimeHeaderName," +
                              "MacTimeHeaderSunday,MacTimeHeaderMonday,MacTimeHeaderTuesday,MacTimeHeaderWednesday," +
                              "MacTimeHeaderThursday,MacTimeHeaderFriday,MacTimeHeaderSaturday) VALUES(newid()," + Param[1] + ",'" +
                              Param[2] + "'," + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + "," +
                              Param[8] + "," + Param[9] + ")";
                            break;
                        case 1002:
                            ret = "UPDATE MJ_MacTimeHeader SET MacTimeHeaderTimeNo=" + Param[1] + ",MacTimeHeaderName='" +
                              Param[2] + "',MacTimeHeaderSunday=" + Param[3] + ",MacTimeHeaderMonday=" + Param[4] +
                              ",MacTimeHeaderTuesday=" + Param[5] + ",MacTimeHeaderWednesday=" + Param[6] + "," +
                              "MacTimeHeaderThursday=" + Param[7] + ",MacTimeHeaderFriday=" + Param[8] +
                              ",MacTimeHeaderSaturday=" + Param[9] + " WHERE MacTimeHeaderSysID='" + Param[10] + "'";
                            break;
                        case 1003:
                            ret = "DELETE FROM MJ_MacTimeHeader WHERE MacTimeHeaderSysID='" + Param[1] + "'";
                            break;
                        case 1004:
                            ret = "SELECT * FROM MJ_MacTimeHeader WHERE MacTimeHeaderTimeNo=" + Param[1];
                            break;
                        case 1005:
                            ret = "SELECT * FROM MJ_MacTimeHeader WHERE MacTimeHeaderSysID<>'" + Param[1] +
                              "' AND MacTimeHeaderTimeNo=" + Param[2];
                            break;
                        case 1006:
                            ret = "SELECT * FROM MJ_MacTimeHeader WHERE MacTimeHeaderSysID='" + Param[1] + "'";
                            break;
                        case 1010:
                            ret = "EXEC PGetMaxIDFromTable 'MacTimeHeaderTimeNo','MJ_MacTimeHeader'";
                            break;
                        case 1011:
                            ret = "INSERT INTO MJ_MacTimeHeader(MacTimeHeaderSysID,MacTimeHeaderTimeNo,MacTimeHeaderName," +
                              "MacTimeHeaderSunday,MacTimeHeaderMonday,MacTimeHeaderTuesday,MacTimeHeaderWednesday," +
                              "MacTimeHeaderThursday,MacTimeHeaderFriday,MacTimeHeaderSaturday,MacTimeHeaderHoliday) VALUES(newid()," +
                              Param[1] + ",'" + Param[2] + "'," + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," +
                              Param[7] + "," + Param[8] + "," + Param[9] + "," + Param[10] + ")";
                            break;
                        case 1012:
                            ret = "UPDATE MJ_MacTimeHeader SET MacTimeHeaderTimeNo=" + Param[1] + ",MacTimeHeaderName='" +
                              Param[2] + "',MacTimeHeaderSunday=" + Param[3] + ",MacTimeHeaderMonday=" + Param[4] +
                              ",MacTimeHeaderTuesday=" + Param[5] + ",MacTimeHeaderWednesday=" + Param[6] + "," +
                              "MacTimeHeaderThursday=" + Param[7] + ",MacTimeHeaderFriday=" + Param[8] +
                              ",MacTimeHeaderSaturday=" + Param[9] + ",MacTimeHeaderHoliday=" + Param[10] +
                              " WHERE MacTimeHeaderSysID='" + Param[11] + "'";
                            break;
                        case 2000:
                            ret = "INSERT INTO MJ_MacTime(MacTimeSysID,MacTimeNo,MacTimeName,MacTimeTimes1,MacTimeBeginTime1,MacTimeEndTime1," +
                              "MacTimeMode1,MacTimeTimes2,MacTimeBeginTime2,MacTimeEndTime2,MacTimeMode2,MacTimeTimes3,MacTimeBeginTime3," +
                              "MacTimeEndTime3,MacTimeMode3,MacTimeTimes4,MacTimeBeginTime4,MacTimeEndTime4,MacTimeMode4,MacTimeTimes5," +
                              "MacTimeBeginTime5,MacTimeEndTime5,MacTimeMode5,MacTimeTimes6,MacTimeBeginTime6,MacTimeEndTime6,MacTimeMode6," +
                              "MacTimeInType1,MacTimeInType2) VALUES(newid()," + Param[1] + ",'" + Param[2] + "'," + Param[3] + ",'" +
                              Param[4] + "','" + Param[5] + "'," + Param[6] + "," + Param[7] + ",'" + Param[8] + "','" + Param[9] + "'," +
                              Param[10] + "," + Param[11] + ",'" + Param[12] + "','" + Param[13] + "'," + Param[14] + "," + Param[15] + ",'" +
                              Param[16] + "','" + Param[17] + "'," + Param[18] + "," + Param[19] + ",'" + Param[20] + "','" + Param[21] + "'," +
                              Param[22] + "," + Param[23] + ",'" + Param[24] + "','" + Param[25] + "'," + Param[26] + ",1,1)";
                            break;
                        case 2001:
                            ret = "UPDATE MJ_MacTime SET MacTimeNo=" + Param[1] + ",MacTimeName='" + Param[2] + "',MacTimeTimes1=" + Param[3] +
                              ",MacTimeBeginTime1='" + Param[4] + "',MacTimeEndTime1='" + Param[5] + "',MacTimeMode1=" + Param[6] +
                              ",MacTimeTimes2=" + Param[7] + ",MacTimeBeginTime2='" + Param[8] + "',MacTimeEndTime2='" + Param[9] +
                              "',MacTimeMode2=" + Param[10] + ",MacTimeTimes3=" + Param[11] + ",MacTimeBeginTime3='" + Param[12] +
                              "',MacTimeEndTime3='" + Param[13] + "',MacTimeMode3=" + Param[14] + ",MacTimeTimes4=" + Param[15] +
                              ",MacTimeBeginTime4='" + Param[16] + "',MacTimeEndTime4='" + Param[17] + "',MacTimeMode4=" + Param[18] +
                              ",MacTimeTimes5=" + Param[19] + ",MacTimeBeginTime5='" + Param[20] + "',MacTimeEndTime5='" + Param[21] +
                              "',MacTimeMode5=" + Param[22] + ",MacTimeTimes6=" + Param[23] + ",MacTimeBeginTime6='" + Param[24] +
                              "',MacTimeEndTime6='" + Param[25] + "',MacTimeMode6=" + Param[26] + " WHERE MacTimeSysID='" + Param[27] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_003004:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VMJ_MacPower WHERE 1=1 " + Param[1] + " ORDER BY EmpNo,MacSN,MacDoorID";
                            break;
                        case 1:
                            ret = "SELECT * FROM MJ_MacPower WHERE CardPhysicsNo='" + Param[1] + "' AND MacSysID='" +
                              Param[2] + "' AND MacDoorSysID='" + Param[3] + "'";
                            break;
                        case 2:
                            ret = "INSERT INTO MJ_MacPower(CardPhysicsNo,MacSysID,MacDoorSysID,MacTimeNo,IsEnable,GUID) VALUES('" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "'," + Param[4] + ",'Y',newid())";
                            break;
                        case 3:
                            ret = "UPDATE MJ_MacPower SET MacTimeNo= " + Param[4] + " WHERE CardPhysicsNo='" + Param[1] +
                              "' AND MacSysID='" + Param[2] + "' AND MacDoorSysID='" + Param[3] + "'";
                            break;
                        case 4:
                            ret = "DELETE FROM MJ_MacPower WHERE CardPhysicsNo='" + Param[1] + "' AND MacSysID='" +
                              Param[2] + "' AND MacDoorSysID='" + Param[3] + "'";
                            break;
                        case 101:
                            ret = "SELECT * FROM VMJ_MacPower WHERE 1=1 " + Param[1];
                            break;
                        case 102:
                            ret = " ORDER BY EmpNo,MacSN,MacDoorID";
                            break;
                        case 103:
                            ret = Param[1] + GetEmpInfoSQL(Param[3], Param[4]) + GetDepartInfoSQL(Param[5], Param[6], Param[7]);
                            if (Param[8] != "") ret += " AND MacDoorName IN(" + Param[8] + ")";
                            ret += Param[2];
                            break;
                        case 1000:
                            ret = "SELECT * FROM VMJ_MacPowerNew WHERE 1=1 " + Param[1] + " ORDER BY EmpNo,MacSN,MacDoorID";
                            break;
                        case 1001:
                            ret = "SELECT * FROM VMJ_MacPowerNew WHERE 1=1 " + Param[1];
                            break;
                        case 1002:
                            ret = " ORDER BY EmpNo,MacSN,MacDoorID";
                            break;
                        case 1003:
                            ret = Param[1] + GetEmpInfoSQL(Param[3], Param[4]) + GetDepartInfoSQL(Param[5], Param[6], Param[7]);
                            if (Param[8] != "") ret += " AND MacDoorName IN(" + Param[8] + ")";
                            ret += Param[2];
                            break;
                    }
                    break;
                case DBCode.DB_003005:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "EXEC PMJ_MJDataSave " + Param[1] + ",'" + Param[2] + "','" + Param[3] + "'," + Param[4] + ",'" +
                              Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" + Param[9] + "'";
                            break;
                        case 1:
                            ret = "EXEC PMJ_OtherDataSave '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," + Param[4] + "," +
                              Param[5] + ",'" + Param[6] + "','" + Param[7] + "'";
                            break;
                        case 100:
                            ret = "EXEC PMJ_MJDataSaveNew " + Param[1] + ",'" + Param[2] + "','" + Param[3] + "'," + Param[4] + ",'" +
                              Param[5] + "','" + Param[6] + "','" + Param[7] + "','" + Param[8] + "','" + Param[9] + "'," + Param[10];
                            break;
                        case 101:
                            ret = "EXEC PMJ_OtherDataSaveNew '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," + Param[4] + "," +
                              Param[5] + ",'" + Param[6] + "','" + Param[7] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_003006:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VRS_Emp WHERE CardPhysicsNo8='" + Param[1] + "' OR OtherCardNo='" + Param[1] + "'";
                            break;
                        case 1:
                            ret = "SELECT * FROM VRS_Emp WHERE CardPhysicsNo10='" + Param[1] + "' OR OtherCardNo='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM VMJ_MacReadInfo WHERE MacSN='" + Param[1] + "' AND MacReadID='" + Param[2] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM VMJ_MacReadInfoNew WHERE MacSN='" + Param[1] + "' AND MacReadID='" + Param[2] + "'";
                            break;

                    }
                    break;
                case DBCode.DB_003007:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM MJ_MacMap ORDER BY MapName";
                            break;
                        case 1:
                            ret = "SELECT * FROM MJ_MacMap WHERE MapSysID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM MJ_MacMap WHERE MapName='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM MJ_MacMap WHERE MapSysID<>'" + Param[1] + "' AND MapName='" + Param[2] + "'";
                            break;
                        case 4:
                            ret = "INSERT INTO MJ_MacMap(MapSysID,MapName) VALUES('" + Param[1] + "','" + Param[2] + "')";
                            break;
                        case 5:
                            ret = "UPDATE MJ_MacMap SET MapName='" + Param[2] + "' WHERE MapSysID='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "UPDATE MJ_MacMap SET mapPic=@mapPic WHERE MapSysID='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "DELETE FROM MJ_MacMap WHERE MapSysID='" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "SELECT * FROM VMJ_MacMapDoor WHERE MapSysID='" + Param[1] + "' ORDER BY MacDoorID";
                            break;
                        case 9:
                            ret = "DELETE FROM MJ_MacMapDoor WHERE MapSysID='" + Param[1] + "'";
                            break;
                        case 10:
                            ret = "INSERT INTO MJ_MacMapDoor(MapSysID,MacDoorSysID,LocationX,LocationY) VALUES('" + Param[1] + "','" +
                              Param[2] + "'," + Param[3] + "," + Param[4] + ")";
                            break;
                    }
                    break;
                case DBCode.DB_003008:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VMJ_MJData WHERE MJDateTime>='" + Param[7] + "' AND MJDateTime<='" + Param[8] + "'" + Param[9];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[6] != "") ret += " AND MacSN IN(" + Param[6] + ")";
                            ret += " ORDER BY EmpNo,MacSN,MJDateTime";
                            break;
                        case 1:
                            ret = "SELECT * FROM VMJ_MJOtherData WHERE MJDateTime>='" + Param[2] + "' AND MJDateTime<='" + Param[3] + "'";
                            if (Param[1] != "") ret += " AND MacSN='" + Param[1] + "'";
                            ret += " ORDER BY MacSN,MJDateTime";
                            break;
                        case 3:
                            ret = "SELECT * FROM VMJ_MJDataNew WHERE MJDateTime>='" + Param[7] + "' AND MJDateTime<='" + Param[8] + "'" + Param[9];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[6] != "") ret += " AND MacSN IN(" + Param[6] + ")";
                            ret += " ORDER BY EmpNo,MacSN,MJDateTime";
                            break;
                        case 4:
                            ret = "SELECT * FROM VMJ_MJOtherDataNew WHERE MJDateTime>='" + Param[2] + "' AND MJDateTime<='" + Param[3] + "'";
                            if (Param[1] != "") ret += " AND MacSN='" + Param[1] + "'";
                            ret += " ORDER BY MacSN,MJDateTime";
                            break;
                    }
                    break;
                case DBCode.DB_003009:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VMJ_MacTimeOpenDoor ORDER BY WeekID";
                            break;
                        case 1:
                            ret = "SELECT * FROM MJ_MacTimeOpenDoor WHERE WeekID=" + Param[1];
                            break;
                        case 2:
                            ret = "UPDATE MJ_MacTimeOpenDoor SET BeginTime1='" + Param[1] + "',EndTime1='" + Param[2] +
                              "',BeginTime2='" + Param[3] + "',EndTime2='" + Param[4] + "',BeginTime3='" + Param[5] +
                              "',EndTime3='" + Param[6] + "' WHERE WeekID=" + Param[7];
                            break;
                        case 100:
                            ret = "SELECT * FROM VMJ_MacTimeOpenDoorNew ORDER BY WeekID";
                            break;
                        case 101:
                            ret = "UPDATE MJ_MacTimeOpenDoor SET BeginTime1='" + Param[1] + "',EndTime1='" + Param[2] +
                              "',Mode1=" + Param[3] + ",BeginTime2='" + Param[4] + "',EndTime2='" + Param[5] +
                              "',Mode2=" + Param[6] + ",BeginTime3='" + Param[7] + "',EndTime3='" + Param[8] +
                              "',Mode3=" + Param[9] + ",BeginTime4='" + Param[10] + "',EndTime4='" + Param[11] +
                              "',Mode4=" + Param[12] + " WHERE WeekID=" + Param[13];
                            break;
                    }
                    break;

                case DBCode.DB_004001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT ISNULL(MAX(AddressNO),0)+1 AS MaxID FROM SF_MacAddress WHERE UpGUID='" +
                              Param[1] + "' AND ISNUMERIC(AddressNO)=1";
                            break;
                        case 1:
                            ret = "SELECT * FROM SF_MacAddress WHERE GUID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "SELECT * FROM SF_MacAddress WHERE AddressNO='" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT * FROM SF_MacAddress WHERE UpGUID='" + Param[1] + "' ORDER BY AddressNO";
                            break;
                        case 4:
                            ret = "SELECT * FROM SF_MacAddress WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM SF_MacAddress WHERE GUID<>'" + Param[1] + "' AND AddressNO='" + Param[2] + "'";
                            break;
                        case 6:
                            ret = "INSERT INTO SF_MacAddress(GUID,AddressNO,AddressName,UpGUID) " +
                              "VALUES(newid(),'" + Param[1] + "','" + Param[2] + "','" + Param[3] + "')";
                            break;
                        case 7:
                            ret = "UPDATE SF_MacAddress SET AddressNO='" + Param[1] + "',AddressName='" + Param[2] + "',UpGUID='" +
                              Param[3] + "' WHERE GUID='" + Param[4] + "'";
                            break;
                        case 8:
                            ret = "DELETE FROM SF_MacAddress WHERE GUID='" + Param[1] + "'";
                            break;
                        case 101:
                            ret = "SELECT GUID,AddressNO,AddressName FROM SF_MacAddress WHERE UpGUID='' OR UpGUID IS NULL ORDER BY AddressNO";
                            break;
                        case 102:
                            ret = "SELECT GUID,AddressNO,AddressName FROM SF_MacAddress WHERE UpGUID='" +
                              Param[1] + "' ORDER BY AddressNO";
                            break;
                        case 103:
                            ret = "SELECT AddressNO FROM SF_MacAddress WHERE AddressNO='" + Param[1] + "' OR AddressName='" + Param[1] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_004002:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM SF_MacPrintTitle";
                            break;
                        case 1:
                            ret = "INSERT INTO SF_MacPrintTitle(PrintTitle1,PrintTitle2,PrintTitle3,PrintTitle4,PrintTitle5," +
                              "PrintOption1,PrintOption2,PrintOption3,PrintOption4,PrintOption5,PrintLine) VALUES('" +
                              Param[1] + "','" + Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "'," +
                              Param[6] + "," + Param[7] + "," + Param[8] + "," + Param[9] + "," + Param[10] + "," + Param[11] + ")";
                            break;
                        case 2:
                            ret = "UPDATE SF_MacPrintTitle SET PrintTitle1='" + Param[1] + "',PrintTitle2='" +
                              Param[2] + "',PrintTitle3='" + Param[3] + "',PrintTitle4='" + Param[4] + "',PrintTitle5='" +
                              Param[5] + "',PrintOption1=" + Param[6] + ",PrintOption2=" + Param[7] + ",PrintOption3=" +
                              Param[8] + ",PrintOption4=" + Param[9] + ",PrintOption5=" + Param[10] + ",PrintLine=" + Param[11];
                            break;
                        case 3:
                            ret = "UPDATE SF_MacPrintTitle SET PrintLogo=@PrintLogo";
                            break;
                        case 100:
                            ret = "SELECT * FROM SF_MobileInfo";
                            break;
                        case 101:
                            ret = "INSERT INTO SF_MobileInfo(MobileIP,MobilePort,MobileKeyID,MobileMercID,MobileTrmNo," +
                              "MobilePWD,MobileRate11,MobileRate12,MobileRate21,MobileRate22,MobTyp,XJLName,XJLPWD) VALUES('" + Param[1] + "'," +
                              Param[2] + ",'" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "'," + Param[7] + "," +
                              Param[8] + "," + Param[9] + "," + Param[10] + "," + Param[11] + ",'" + Param[12] + "','" + Param[13] + "')";
                            break;
                        case 102:
                            ret = "UPDATE SF_MobileInfo SET MobileIP='" + Param[1] + "',MobilePort=" + Param[2] + ",MobileKeyID='" +
                              Param[3] + "',MobileMercID='" + Param[4] + "',MobileTrmNo='" + Param[5] + "',MobilePWD='" + Param[6] +
                              "',MobileRate11=" + Param[7] + ",MobileRate12=" + Param[8] + ",MobileRate21=" + Param[9] + ",MobileRate22=" +
                              Param[10] + ",MobTyp=" + Param[11] + ",XJLName='" + Param[12] + "',XJLPWD='" + Param[13] + "'";
                            break;
                        case 103:
                            ret = "UPDATE SF_MobileInfo SET ScanWeiXin=@ScanWeiXin";
                            break;
                        case 104:
                            ret = "UPDATE SF_MobileInfo SET ScanAliPay=@ScanAliPay";
                            break;
                    }
                    break;
                case DBCode.DB_004003:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSF_MacProducts ORDER BY CategoryID,ProductsID";
                            break;
                        case 1:
                            ret = "INSERT INTO SF_MacProducts(GUID,ProductsID,ProductsName,ProductsPrice,CategoryID,CategoryName) VALUES(newid()," +
                              Param[1] + ",'" + Param[2] + "'," + Param[3] + "," + Param[4] + ",'" + Param[5] + "')";
                            break;
                        case 2:
                            ret = "UPDATE SF_MacProducts SET ProductsID=" + Param[1] + ",ProductsName='" + Param[2] +
                              "',ProductsPrice=" + Param[3] + ",CategoryID=" + Param[4] + ",CategoryName='" + Param[5] + "' WHERE GUID='" + Param[6] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SF_MacProducts WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SF_MacProducts WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM SF_MacProducts WHERE ProductsID=" + Param[1] + " AND CategoryID=" + Param[2];
                            break;
                        case 6:
                            ret = "SELECT * FROM SF_MacProducts WHERE GUID<>'" + Param[1] + "' AND ProductsID=" + Param[2] + " AND CategoryID=" + Param[3];
                            break;
                        case 101:
                            ret = "EXEC PGetMaxIDFromTable 'ProductsID','SF_MacProducts'";
                            break;
                        case 102:
                            ret = "SELECT * FROM SF_DishCategorys ORDER BY CategoryID";
                            break;
                        case 103:
                            ret = "INSERT INTO SF_DishCategorys(GUID,CategoryID,CategoryName) VALUES(newid()," +
                              Param[1] + ",'" + Param[2] + "')";
                            break;
                        case 104:
                            ret = "UPDATE SF_DishCategorys SET CategoryID=" + Param[1] + ",CategoryName='" + Param[2] +
                              "' WHERE GUID='" + Param[3] + "'";
                            break;
                        case 105:
                            ret = "DELETE FROM SF_DishCategorys WHERE GUID='" + Param[1] + "'";
                            break;
                        case 106:
                            ret = "SELECT * FROM SF_DishCategorys WHERE GUID='" + Param[1] + "'";
                            break;
                        case 107:
                            ret = "SELECT * FROM SF_DishCategorys WHERE CategoryID=" + Param[1];
                            break;
                        case 108:
                            ret = "SELECT * FROM SF_DishCategorys WHERE GUID<>'" + Param[1] + "' AND CategoryID=" + Param[2];
                            break;
                        case 109:
                            ret = "EXEC PGetMaxIDFromTable 'CategoryID','SF_DishCategorys'";
                            break;
                        case 110:
                            ret = "SELECT * FROM SF_MacProducts WHERE CategoryID=" + Param[1] + " ORDER BY ProductsID";
                            break;
                      
                        case 120:
                            ret = "UPDATE SF_MacProducts SET CategoryID=" + Param[1] + ",CategoryName='" + Param[2] +
                              "' WHERE CategoryID=" + Param[3] + "";
                            break;
                    }
                    break;
                case DBCode.DB_004004:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSF_MacInfo WHERE 1=1";
                            if (Param.Length > 1) ret += Param[1];
                            ret += " ORDER BY MacSN";
                            break;
                        case 1:
                            ret = "INSERT INTO SF_MacInfo(MacSysID,MacSN,MacType,MacConnType,MacIpAddress,MacPort,MacConnPWD," +
                              "MacDesc,MacPhysicsAddress,MacAddressNo,Opter,IsBigMac) VALUES(newid(),'" + Param[1] + "','" +
                              Param[2] + "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "','" +
                              Param[7] + "','" + Param[8] + "','" + Param[9] + "','1'," + Param[10] + ")";
                            break;
                        case 2:
                            ret = "UPDATE SF_MacInfo SET MacSN='" + Param[1] + "',MacType='" + Param[2] + "',MacConnType='" +
                              Param[3] + "',MacIpAddress='" + Param[4] + "',MacPort='" + Param[5] + "',MacConnPWD='" +
                              Param[6] + "',MacDesc='" + Param[7] + "',MacPhysicsAddress='" + Param[8] + "',MacAddressNo='" +
                              Param[9] + "',IsBigMac=" + Param[10] + " WHERE MacSysID='" + Param[11] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SF_MacInfo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM VSF_MacInfo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM VSF_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT * FROM VSF_MacInfo WHERE MacSysID<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "SELECT * FROM SF_MacInfo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 8:
                            ret = "SELECT * FROM SF_MacInfo WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 9:
                            ret = "UPDATE SF_MacInfo SET IsSupportAirCZ=" + Param[1] + " WHERE MacSN='" + Param[2] + "'";
                            break;
                        case 10:
                            ret = "UPDATE SF_MacInfo SET MacPhysicsAddress='" + Param[1] + "' WHERE MacSN='" + Param[2] + "'";
                            break;
                        case 11:
                            ret = "SELECT * FROM SF_MacInfo WHERE MacPhysicsAddress='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "INSERT INTO SF_SendBackCard(GUID,MacPhysicsAddress,CardNo) VALUES(newid(),'" + Param[1] + "','" +
                              Param[2] + "')";
                            break;
                        case 13:
                            ret = "SELECT * FROM SF_SendBackCard WHERE 1=1";
                            break;
                        case 14:
                            ret = "DELETE SF_SendBackCard WHERE MacPhysicsAddress='" + Param[1] + "' AND CardNo='" + Param[2] + "'";
                            break;
                        case 101:
                            ret = "EXEC PGetMaxIDFromTable 'MacSN','SF_MacInfo'";
                            break;
                        case 102:
                            ret = " AND (MacConnType='LAN' OR MacConnType='GPRS') AND " +
                              "(MacTypeID=32 OR MacTypeID=33 OR MacTypeID=34 OR MacTypeID=35)";
                            break;
                        case 103:
                            ret = "SELECT * FROM VSF_MacType ORDER BY MacTypeID";
                            break;
                        case 104:
                            ret = "UPDATE SF_MacInfo SET MealInfo='" + Param[1] + "',ParamInfo='" + Param[2] + "',BellTime='" +
                              Param[3] + "',SFLimitConsumption='" + Param[4] + "',Opter='" + Param[5] + "',Products='" +
                              Param[6] + "',ConsumptionWay='" + Param[7] + "',WithinDiscount='" + Param[8] + "',Timing='" +
                              Param[9] + "',Ordering='" + Param[10] + "',PrintTitle='" + Param[11] + "',CardLowBalance='" +
                              Param[12] + "',MobileInfo='" + Param[13] + "' WHERE MacSysID='" + Param[14] + "'";
                            break;
                        case 105:
                            ret = "SELECT * FROM SF_MacOpter WHERE ";
                            if (Param[1] == "")
                                ret += "1=2";
                            else
                                ret += "MacOpterID IN(" + Param[1] + ") ORDER BY MacOpterID";
                            break;
                        case 106:
                            ret = "SELECT * FROM SF_MacProducts WHERE ";
                            if (Param[1] == "")
                                ret += "1=2";
                            else
                                ret += "ProductsID IN(" + Param[1] + ") AND CategoryID=" + Param[2] + " ORDER BY ProductsID";
                            break;
                        case 107:
                            ret = "UPDATE SF_MacInfo SET SFLimitConsumption='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        //case 108:
                        //  ret = "SELECT * FROM  VSF_SFType WHERE (SFTypeID=2 OR SFTypeID=7 OR SFTypeID=130) ORDER BY SFTypeID";//²Í´Î²¹Ìù
                        //  break;
                        case 108:
                            ret = "SELECT * FROM  VSF_SFType WHERE (SFTypeID=2 OR SFTypeID=7) ORDER BY SFTypeID";
                            break;
                        case 109:
                            ret = "UPDATE SF_MacInfo SET ConsumptionWay='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 110:
                            ret = "UPDATE SF_MacInfo SET WithinDiscount='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 111:
                            ret = "UPDATE SF_MacInfo SET CardLowBalance='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 112:
                            ret = "SELECT CAST(CASE WHEN ProductsID IN(" + Param[1] + ") AND CategoryID=" + Param[2] + " THEN 1 ELSE 0 END AS bit) AS SelectCheck," +
                              "ProductsID,ProductsName,ProductsPrice,GUID FROM SF_MacProducts where CategoryID=" + Param[2] + " ORDER BY ProductsID";
                            break;
                        case 113:
                            ret = "UPDATE SF_MacInfo SET Products='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 114:
                            ret = "SELECT CAST(CASE WHEN MacOpterID IN(" + Param[1] + ") THEN 1 ELSE 0 END AS bit) AS SelectCheck," +
                              "MacOpterID,MacOpterName,GUID,MacOpterPWD FROM SF_MacOpter ORDER BY MacOpterID";
                            break;
                        case 115:
                            ret = "UPDATE SF_MacInfo SET Opter='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 116:
                            ret = "UPDATE SF_MacInfo SET Timing='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 117:
                            ret = "UPDATE SF_MacInfo SET Ordering='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 118:
                            ret = " AND (MacTypeID=32 OR MacTypeID=33 OR MacTypeID=34 OR MacTypeID=35)";
                            break;
                        case 119:
                            ret = " AND MacTypeID=34";
                            break;
                        case 120:
                            ret = "UPDATE SF_MacInfo SET PrintTitle='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 121:
                            ret = "UPDATE SF_MacInfo SET MobileInfo='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                        case 122:
                            ret = "UPDATE SF_MacInfo SET PrintLogo=@PrintLogo WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 123:
                            ret = "UPDATE SF_MacInfo SET ScanWeiXin=@ScanWeiXin WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 124:
                            ret = "UPDATE SF_MacInfo SET ScanAliPay=@ScanAliPay WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 125:
                            ret = "UPDATE SF_MacInfo SET TFeeRechargeGift='" + Param[1] + "' WHERE MacSysID='" + Param[2] + "'";
                            break;
                    }
                    break;
                case DBCode.DB_004005:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[13], out d)) s = ",'" + Param[13] + "'";
                            ret = "EXEC PSF_SFDataInsert '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'," + Param[12] + s + ",'" +
                              Param[14] + "','" + Param[15] + "','" + Param[16] + "'," + Param[17] + "," +
                              "" + Param[18] + "," + Param[19] + ",'" + Param[20] + "','" + Param[21] + "'";
                            if (Param.Length >= 25)
                            {
                                if (DateTime.TryParse(Param[22], out d) && DateTime.TryParse(Param[23], out d))
                                {
                                    s = ",'" + Param[22] + "','" + Param[23] + "'," + Param[24];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 1:
                            ret = "EXEC PSF_OrderDataInsert '" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" +
                              Param[4] + "'," + Param[5] + "," + Param[6];
                            break;
                        case 2:
                            ret = "SELECT * FROM VSF_MealType ORDER BY MealTypeID";
                            break;
                        case 3:
                            ret = "SELECT * FROM  VSF_SFType WHERE (SFTypeID=1 OR SFTypeID=2 OR SFTypeID=60) ORDER BY SFTypeID";
                            break;
                        case 4:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[12], out d)) s = ",'" + Param[12] + "'";
                            ret = "EXEC PSF_SFErrorDataInsert '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'" + s + ",'" +
                              Param[13] + "','" + Param[14] + "','" + Param[15] + "'";
                            if (Param.Length >= 19)
                            {
                                if (DateTime.TryParse(Param[16], out d) && DateTime.TryParse(Param[17], out d))
                                {
                                    s = ",'" + Param[16] + "','" + Param[17] + "'," + Param[18];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 5:
                            ret = "SELECT * FROM VSF_SFType WHERE SFTypeID=" + Param[1];
                            break;
                        case 6:
                            ret = "SELECT * FROM VSF_MealType WHERE MealTypeID=" + Param[1];
                            break;
                        case 7:
                            ret = "EXEC PSF_SFDataInsertDM '" + Param[1] + "','" + Param[2] + "'," + Param[3] + ",'" +
                              Param[4] + "'," + Param[5] + "," + Param[6] + "," + Param[7] + ",'" + Param[8] + "'," +
                              Param[9] + "," + Param[10] + ",'" + Param[11] + "','" + Param[12] + "'," + Param[13] + "," + Param[14] + "";
                            break;
                        case 8:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[12], out d)) s = ",'" + Param[12] + "'";
                            ret = "EXEC PSF_SFReturnDataInsert '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'" + s + ",'" +
                              Param[13] + "','" + Param[14] + "','" + Param[15] + "'";
                            if (Param.Length >= 19)
                            {
                                if (DateTime.TryParse(Param[16], out d) && DateTime.TryParse(Param[17], out d))
                                {
                                    s = ",'" + Param[16] + "','" + Param[17] + "'," + Param[18];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 9:
                            ret = "EXEC PSF_SFDataOrderInsert '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "','" + Param[12] + "'," + Param[13] + "," +
                              Param[14] + "," + Param[15] + "," + Param[16] + ",'" + Param[17] + "','" + Param[18] + "'";
                            break;
                        case 10:
                            ret = "EXEC PSF_SFDataMobileInsert " + Param[1] + ",'" + Param[2] + "'," + Param[3] + ",'" +
                              Param[4] + "','" + Param[5] + "','" + Param[6] + "'," + Param[7] + "," + Param[8] + ",'" + Param[9] + "'";
                            break;
                        case 11:
                            ret = "SELECT * FROM VSF_SFTypeMobile WHERE SFTypeID=" + Param[1];
                            break;
                        case 12:
                            ret = "DELETE FROM SF_SFDataMobileProduct WHERE GUID IN(SELECT GUID FROM SF_SFDataMobile WHERE SFDate>='" +
                              Param[1] + "' AND SFDate<='" + Param[2] + "')";
                            break;
                        case 13:
                            ret = "DELETE FROM SF_SFDataMobile WHERE SFDate>='" + Param[1] + "' AND SFDate<='" + Param[2] + "'";
                            break;
                        case 14:
                            ret = "DELETE FROM SF_SFData WHERE (SFType=90 OR SFType=91) AND SFDate>='" + Param[1] + "' AND SFDate<='" + Param[2] + "'";
                            break;
                        case 15:
                            ret = "EXEC PSF_MobileErrorDataInsert '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," + Param[4] + "," +
                              Param[5] + ",'" + Param[6] + "'," + Param[7] + "," + Param[8] + ",'" + Param[9] + "'," + Param[10] + "," +
                              Param[11] + "','" + Param[12] + "','" + Param[13] + "','" + Param[14] + "','" + Param[15] + "','" +
                              Param[16] + "," + Param[17] + ",'" + Param[18] + "','" + Param[19] + "'";
                            break;
                        case 16:
                            ret = "DELETE FROM SF_SFDataMobile WHERE  SFDate>='" +
                              Param[1] + "' AND SFDate<='" + Param[2] + "'";
                            break;
                        case 100:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[13], out d)) s = ",'" + Param[13] + "'";
                            ret = "EXEC PSF_SFDataInsertOld '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'," + Param[12] + s + ",'" +
                              Param[14] + "','" + Param[15] + "','" + Param[16] + "'," + Param[17] + "," +
                              Param[18] + "," + Param[19] + ",'" + Param[20] + "','" + Param[21] + "'";
                            if (Param.Length >= 25)
                            {
                                if (DateTime.TryParse(Param[22], out d) && DateTime.TryParse(Param[23], out d))
                                {
                                    s = ",'" + Param[22] + "','" + Param[23] + "'," + Param[24];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 101:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[12], out d)) s = ",'" + Param[12] + "'";
                            ret = "EXEC PSF_SFErrorDataInsertOld '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'" + s + ",'" +
                              Param[13] + "','" + Param[14] + "','" + Param[15] + "'," + Param[16] + "," + Param[17] + "," + Param[18] + ",'" + Param[19] + "','" + Param[20] + "'";
                            if (Param.Length >= 24)
                            {
                                if (DateTime.TryParse(Param[21], out d) && DateTime.TryParse(Param[22], out d))
                                {
                                    s = ",'" + Param[21] + "','" + Param[22] + "'," + Param[23];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 102:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[12], out d)) s = ",'" + Param[12] + "'";
                            ret = "EXEC PSF_SFReturnDataInsertOld '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'" + s + ",'" +
                              Param[13] + "','" + Param[14] + "','" + Param[15] + "'," + Param[16] + "," + Param[17] + "," + Param[18] + ",'" + Param[19] + "','" + Param[20] + "'";
                            if (Param.Length >= 24)
                            {
                                if (DateTime.TryParse(Param[21], out d) && DateTime.TryParse(Param[22], out d))
                                {
                                    s = ",'" + Param[21] + "','" + Param[22] + "'," + Param[23];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 200:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[13], out d)) s = ",'" + Param[13] + "'";
                            ret = "EXEC PSF_SFDataInsertNew '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'," + Param[12] + s + ",'" +
                              Param[14] + "','" + Param[15] + "','" + Param[16] + "'," + Param[17] + "," +
                              Param[18] + "," + Param[19] + ",'" + Param[20] + "','" + Param[21] + "'";
                            if (Param.Length >= 25)
                            {
                                if (DateTime.TryParse(Param[22], out d) && DateTime.TryParse(Param[23], out d))
                                {
                                    s = ",'" + Param[22] + "','" + Param[23] + "'," + Param[24];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 201:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[12], out d)) s = ",'" + Param[12] + "'";
                            ret = "EXEC PSF_SFErrorDataInsertNew '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'" + s + ",'" +
                              Param[13] + "','" + Param[14] + "','" + Param[15] + "'," + Param[16] + "," + Param[17] + "," + Param[18] + ",'" + Param[19] + "','" + Param[20] + "'";
                            if (Param.Length >= 24)
                            {
                                if (DateTime.TryParse(Param[21], out d) && DateTime.TryParse(Param[22], out d))
                                {
                                    s = ",'" + Param[21] + "','" + Param[22] + "'," + Param[23];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                        case 202:
                            s = ",NULL";
                            if (DateTime.TryParse(Param[12], out d)) s = ",'" + Param[12] + "'";
                            ret = "EXEC PSF_SFReturnDataInsertNew '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," +
                              Param[4] + "," + Param[5] + "," + Param[6] + ",'" + Param[7] + "'," + Param[8] + "," +
                              Param[9] + ",'" + Param[10] + "','" + Param[11] + "'" + s + ",'" +
                             Param[13] + "','" + Param[14] + "','" + Param[15] + "'," + Param[16] + "," + Param[17] + "," + Param[18] + ",'" + Param[19] + "','" + Param[20] + "'";
                            if (Param.Length >= 24)
                            {
                                if (DateTime.TryParse(Param[21], out d) && DateTime.TryParse(Param[22], out d))
                                {
                                    s = ",'" + Param[21] + "','" + Param[22] + "'," + Param[23];
                                }
                                else
                                {
                                    s = ",NULL,NULL,NULL";
                                }
                            }
                            else
                            {
                                s = ",NULL,NULL,NULL";
                            }
                            ret += s;
                            break;
                    }
                    break;
                case DBCode.DB_004006:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSF_Allowance WHERE 1=1 " + Param[1] + " ORDER BY AllowanceFlag,EmpNo";
                            break;
                        case 1:
                            ret = "SELECT * FROM VSF_AllowanceHistory WHERE 1=1 " + Param[1] + " ORDER BY AllowanceFlag,EmpNo";
                            break;
                        case 2:
                            ret = "SELECT * FROM VSF_Allowance WHERE 1=1 " + Param[1];
                            break;
                        case 3:
                            ret = "SELECT * FROM VSF_AllowanceHistory WHERE 1=1 " + Param[1];
                            break;
                        case 4:
                            ret = " ORDER BY AllowanceFlag,EmpNo";
                            break;
                        case 5:
                            ret = "SELECT MAX(AllowanceFlag) AS Flag FROM SF_AllowanceHistory WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 6:
                            ret = "SELECT MAX(AllowanceFlag) AS Flag FROM SF_Allowance WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 7:
                            ret = "INSERT INTO SF_AllowanceDataInLog(EmpNo,AllowanceFlag,AllowanceWay,AllowanceAmount,DataInTime) " +
                              "VALUES('" + Param[1] + "','" + Param[2] + "'," + Param[3] + "," + Param[4] + ",getdate())";
                            break;
                        case 8:
                            ret = "SELECT * FROM SF_Allowance WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 9:
                            ret = "DELETE FROM SF_AllowanceHistory WHERE EmpSysID='" + Param[1] + "' AND AllowanceFlag='" + Param[2] + "'";
                            break;
                        case 10:
                            ret = "INSERT INTO SF_AllowanceHistory(GUID,EmpSysID,AllowanceFlag,AllowanceAmount,AllowanceWay,AllowanceStatus," +
                              "OprtSysID,OprtDate,AllowanceAmountUp,AllowanceAmountSum,AllowanceWayUp,RecvTime,RecvMacSN) SELECT newid()," +
                              "EmpSysID,AllowanceFlag,AllowanceAmount,AllowanceWay,AllowanceStatus,'" + Param[1] + "',OprtDate,AllowanceAmountUp," +
                              "AllowanceAmountSum,AllowanceWayUp,RecvTime,RecvMacSN FROM SF_Allowance WHERE GUID='" + Param[2] + "'";
                            break;
                        case 11:
                            ret = "DELETE FROM SF_Allowance WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 12:
                            ret = "UPDATE SF_Allowance SET AllowanceAmount=" + Param[1] + ",AllowanceAmountUp=" + Param[2] +
                              ",AllowanceAmountSum=" + Param[3] + ",AllowanceWay=" + Param[4] + ",OprtSysID='" + Param[5] +
                              "',OprtDate=getdate() WHERE EmpSysID='" + Param[6] + "'";
                            break;
                        case 13:
                            ret = "INSERT INTO SF_Allowance(GUID,EmpSysID,AllowanceFlag,AllowanceAmount,AllowanceAmountUp," +
                              "AllowanceAmountSum,AllowanceWay,AllowanceStatus,OprtSysID,OprtDate,AllowanceWayUp) VALUES(newid(),'" +
                              Param[1] + "','" + Param[2] + "'," + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + ",0,'" +
                              Param[7] + "',getdate()," + Param[8] + ")";
                            break;
                        case 14:
                            ret = "UPDATE RS_Emp SET CardTypeSysID='" + Param[1] + "' WHERE EmpSysID='" + Param[2] + "'";
                            break;
                        case 15:
                            ret = "SELECT * FROM VSF_Allowance WHERE GUID='" + Param[1] + "'";
                            break;
                        case 16:
                            ret = "DELETE FROM SF_Allowance WHERE GUID='" + Param[1] + "'";
                            break;
                        case 17:
                            ret = "SELECT * FROM SF_Allowance WHERE AllowanceStatus=0";
                            break;
                        case 18:
                            ret = "SELECT * FROM VSF_AllowanceWay ORDER BY AllowanceWayID";
                            break;
                        case 19:
                            ret = "UPDATE SF_Allowance SET AllowanceAmount=" + Param[1] + ",AllowanceAmountUp=" + Param[2] +
                              ",AllowanceAmountSum=" + Param[3] + ",OprtSysID='" + Param[4] +
                              "',OprtDate=getdate() WHERE GUID='" + Param[5] + "'";
                            break;
                        case 20:
                            ret = "SELECT * FROM VSF_Allowance WHERE AllowanceStatus=0 " + Param[1] + " ORDER BY AllowanceFlag,EmpNo";
                            break;
                        case 21:
                            ret = "SELECT * FROM VSF_AllowanceStatus ORDER BY AllowanceStatusID";
                            break;
                        case 22:
                            ret = "SELECT * FROM VSF_AllowanceHistory WHERE AllowanceFlag>='" + Param[7] + "' AND AllowanceFlag<='" + Param[8] + "'" + Param[9];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[6] != "") ret += " AND AllowanceStatusName IN(" + Param[6] + ")";
                            ret += " ORDER BY AllowanceFlag,EmpNo";
                            break;
                        case 23:
                            ret = "SELECT * FROM VSF_Allowance WHERE AllowanceFlag>='" + Param[7] + "' AND AllowanceFlag<='" + Param[8] + "'" + Param[9];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[6] != "") ret += " AND AllowanceStatusName IN(" + Param[6] + ")";
                            ret += " ORDER BY AllowanceFlag,EmpNo";
                            break;
                        case 24:
                            ret = "SELECT EmpSysID,count(EmpSysID) FROM SF_Allowance WHERE EmpSysID='" + Param[1] + "'" +
                                " AND MONTH(AllowanceFlag)='" + Param[2] + "' group by EmpSysID";
                            break;
                        case 25:
                            ret = "SELECT EmpSysID,count(EmpSysID) FROM SF_AllowanceHistory WHERE EmpSysID='" + Param[1] + "'" +
                                " AND MONTH(AllowanceFlag)='" + Param[2] + "' group by EmpSysID";
                            break;
                        case 100:
                            ret = "SELECT * FROM VSF_Allowance WHERE AllowanceStatus=0 AND (EmpNo='" + Param[1] + "' OR EmpName LIKE '" + Param[1] + "%')" + Param[2];
                            break;
                        case 101:
                            ret = "SELECT * FROM VSF_Allowance WHERE DepartSysID='" + Param[1] + "'";
                            if (Param.Length > 3) ret += Param[2] + Param[3];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 102:
                            ret = "SELECT * FROM VSF_Allowance WHERE CardTypeID=" + Param[1];
                            if (Param.Length > 3) ret += Param[2] + Param[3];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 103:
                            ret = "SELECT * FROM VSF_Allowance WHERE EmpHireDate='" + Param[1] + "'";
                            if (Param.Length > 3) ret += Param[2] + Param[3];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 104:
                            ret = "SELECT * FROM VSF_Allowance WHERE EmpSysID='" + Param[1] + "'";
                            break;
                        case 105:
                            ret = "SELECT MAX(AllowanceFlag) AS Flag FROM SF_AllowanceHistory";
                            break;
                        case 106:
                            ret = "SELECT MAX(AllowanceFlag) AS Flag FROM SF_Allowance";
                            break;
                        case 107:
                            ret = "SELECT * FROM VSF_Allowance WHERE (CardStatusName LIKE '60%' OR CardStatusName LIKE '10% ') AND CardTypeID=" + Param[1];
                            ret += " ORDER BY EmpNo";
                            break;
                        case 108:
                            ret = "SELECT * FROM VSF_Allowance WHERE IsDimission=1 AND CardTypeID=" + Param[1];
                            ret += " ORDER BY EmpNo";
                            break;
                    }
                    break;
                case DBCode.DB_004007:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT TOP 1 CheckOutDate,CardSum,DepositSum,DepositDiscount,GiftCount,RefundmentSum,EliminateSum," +
                              "BTSum,ZeroSum,NormalDZSum,NormalJZSum,InCardFee,ToCardFee,AbnormalDZSum,LossCount,ForwardName " +
                              "FROM SF_Check ORDER BY CheckOutDate DESC";
                            break;
                        case 1:
                            ret = "SELECT COUNT(1) FROM KQ_Result WHERE YEAR(ResultDate)=" + Param[1] + " AND MONTH(ResultDate)=" + Param[2];
                            break;
                        case 2:
                            ret = "SELECT COUNT(1) FROM VSF_SFData WHERE SFDate<'" + Param[1] + "'";
                            break;
                        case 3:
                            ret = "SELECT COUNT(1) AS CountTimes,ISNULL(SUM(ABS(SFAmount+BTAmount)),0) AS SumSFAmount,SFTypeID " +
                              "FROM VSF_SFData WHERE IsAlarm=0";
                            if (Param.Length >= 2) ret += " AND SFDate<'" + Param[1] + "'";
                            ret += " GROUP BY SFTypeID";
                            break;
                        case 4:
                            ret = "SELECT SUM(ISNULL(CardBalance,0)) AS CardBalance,SUM(ISNULL(CardBTMoney,0)) AS CardBTMoney " +
                              "FROM VRS_Emp WHERE CardStatusID<>10 AND ISNUMERIC(CardSectorNo)=1";
                            break;
                        case 5:
                            ret = "EXEC PSF_CheckGetCardSumAll";
                            break;
                        case 6:
                            ret = "SELECT SUM(SFCardBalance+BTBalance) FROM(SELECT DISTINCT a.EmpSysID,a.CardUseTimes,a.SFCardBalance,a.BTBalance " +
                              "FROM VSF_SFData a INNER JOIN (SELECT MAX(CardUseTimes) AS CardUseTimes,EmpSysID FROM VSF_SFData " +
                              "WHERE IsAlarm=0 AND SFDate<'" + Param[1] + "' GROUP BY EmpSysID) b ON a.EmpSysID = b.EmpSysID And " +
                              "a.CardUseTimes = b.CardUseTimes WHERE a.SFTypeID<>40 AND a.SFTypeID<>50 AND a.SFTypeID<>255 AND " +
                              "SFDate<'" + Param[1] + "')c";
                            break;
                        case 7:
                            ret = "SELECT CardSum,DepositDiscount,GiftCount FROM SF_Check ORDER BY CheckOutDate DESC";
                            break;
                        case 8:
                            ret = "SELECT COUNT(1) AS CountTimes,ISNULL(SUM(ABS(SFAmount+BTAmount)),0) AS SumSFAmount,SFTypeID " +
                              "FROM VSF_SFLossData WHERE SFDate";
                            if (Param[1] == "0")
                                ret += "<";
                            else
                                ret += ">=";
                            ret += "'" + Param[2] + "' GROUP BY SFTypeID";
                            break;
                        case 9:
                            ret = "SELECT SUM(InCardFee) AS InCardFee,SUM(ToCardFee) AS ToCardFee,SUM(LossCount) AS LossCount," +
                              "SUM(AbnormalDZSum) AS AbnormalDZSum,SUM(DepositDiscount) AS DepositDiscount," +
                              "SUM(GiftCount) AS GiftCount FROM SF_Check";
                            break;
                        case 10:
                            ret = "EXEC PSF_CheckGetCardSum '" + Param[1] + "'";
                            break;
                        case 20:
                            ret = "SELECT COUNT(1) AS CountTimes,ISNULL(SUM(ABS(BTWay)),0) AS SumSFAmount,SFTypeID " +
                              "FROM VSF_SFData WHERE IsAlarm=0";
                            if (Param.Length >= 2) ret += " AND SFDate<'" + Param[1] + "'";
                            ret += " GROUP BY SFTypeID";
                            break;
                    }
                    break;
                case DBCode.DB_004008:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    s = "SUM(iDSum) AS iDSum,SUM(iDSum0) AS iDSum0,SUM(iDSum1) AS iDSum1,SUM(iDSum2) AS iDSum2," +
                      "SUM(iDSum3) AS iDSum3,SUM(iDSum4) AS iDSum4,SUM(iDSum5) AS iDSum5,SUM(iDSum6) AS iDSum6," +
                      "SUM(iDSum7) AS iDSum7,SUM(iDSum8) AS iDSum8,SUM(iDSum9) AS iDSum9,SUM(iMDSum) AS iMDSum," +
                      "SUM(iMDSum0) AS iMDSum0,SUM(iMDSum1) AS iMDSum1,SUM(iMDSum2) AS iMDSum2,SUM(iMDSum3) AS iMDSum3," +
                      "SUM(iMDSum4) AS iMDSum4,SUM(iMDSum5) AS iMDSum5,SUM(iMDSum6) AS iMDSum6,SUM(iMDSum7) AS iMDSum7," +
                      "SUM(iMDSum8) AS iMDSum8,SUM(iMDSum9) AS iMDSum9,SUM(iICInSum) AS iICInSum," +
                      "SUM(iRSum) AS iRSum,SUM(iMRSum) AS iMRSum,SUM(iESum) AS iESum,SUM(iICOutSum) AS iICOutSum," +
                      "SUM(iInSum) AS iInSum,SUM(iOutSum) AS iOutSum,SUM(iNSum) AS iNSum";
                    s2 = "VSF_QueryIncome";
                    switch (I)
                    {
                        case 0:
                            s1 = "DepartID,DepartName";
                            break;
                        case 1:
                            s1 = "SFOprtNo";
                            s2 = "VSF_QueryIncomeByMacOpter";
                            break;
                        case 2:
                            s1 = "OprtNo";
                            s2 = "VSF_QueryIncomeByOpter";
                            break;
                        case 3:
                            s1 = "CardTypeName";
                            break;
                    }
                    s2 = " FROM " + s2 + " WHERE SFDate>='" + Param[6] + "' AND SFDate<='" + Param[7] + "'" + Param[8];
                    s2 += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                    ret = "SELECT " + s1 + "," + s + s2 + " GROUP BY " + s1;
                    break;
                case DBCode.DB_004009:
                    ret = "SELECT * FROM VRS_EmpSf WHERE CardStatusID<>10" + GetEmpInfoSQL(Param[0], Param[1]) +
                      GetDepartInfoSQL(Param[2], Param[3], Param[4]) + GetCardTypeInfoSQL(Param[5]) + Param[6] + " ORDER BY EmpNo";
                    break;
                case DBCode.DB_004010:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            ret = "VSF_OrderData";
                            if (I > 0) ret += Param[0];
                            ret = "SELECT EmpNo,EmpName,CardNo,DepartID,DepartName,OrderDate," +
                              "SUM(OrderCount1) AS OrderMealTypeIDCount1,SUM(OrderCount2) AS OrderMealTypeIDCount2," +
                              "SUM(OrderCount3) AS OrderMealTypeIDCount3,SUM(OrderCount4) AS OrderMealTypeIDCount4," +
                              "SUM(ConsCount1) AS SFOrderMealTypeIDCount1,SUM(ConsCount2) AS SFOrderMealTypeIDCount2," +
                              "SUM(ConsCount3) AS SFOrderMealTypeIDCount3,SUM(ConsCount4) AS SFOrderMealTypeIDCount4 FROM " +
                              ret + " WHERE OrderDate>='" + Param[6] + "' AND OrderDate<='" + Param[7] + "'" + Param[8];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += " GROUP BY DepartID,DepartName,EmpNo,EmpName,CardNo,OrderDate ORDER BY OrderDate,EmpNo";
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            string S = "";
                            if (I == 4)
                                S = "DepartID,DepartName,EmpNo,EmpName";
                            else if (I == 5)
                                S = "DepartID,DepartName";
                            else if (I == 6)
                                S = "OrderDate";
                            else if (I == 7)
                                S = "CardTypeID,CardTypeName";
                            else
                                S = "MacSN";
                            ret = "SELECT " + S + ",SUM(OrderCount1) AS OrderMealTypeIDCount1," +
                              "SUM(OrderCount2) AS OrderMealTypeIDCount2,SUM(OrderCount3) AS OrderMealTypeIDCount3," +
                              "SUM(OrderCount4) AS OrderMealTypeIDCount4,SUM(ConsCount1) AS SFOrderMealTypeIDCount1," +
                              "SUM(ConsCount2) AS SFOrderMealTypeIDCount2,SUM(ConsCount3) AS SFOrderMealTypeIDCount3," +
                              "SUM(ConsCount4) AS SFOrderMealTypeIDCount4 FROM VSF_OrderDataTotal WHERE OrderDate>='" +
                              Param[6] + "' AND OrderDate<='" + Param[7] + "'" + Param[8];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (I == 8)
                            {
                                ret += " AND (OrderCount1>0 OR OrderCount2>0 OR OrderCount3>0 OR OrderCount4>0)";
                            }
                            else
                            {
                                ret += " AND (OrderCount1>0 OR OrderCount2>0 OR OrderCount3>0 OR OrderCount4>0 OR " +
                                  "ConsCount1>0 OR ConsCount2>0 OR ConsCount3>0 OR ConsCount4>0)";
                            }
                            ret += " GROUP BY " + S + " ORDER BY " + S;
                            break;
                    }
                    break;
                case DBCode.DB_004011:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSF_SFType ORDER BY SFTypeID";
                            break;
                        case 1:
                            ret = "SELECT *, SFAmount+BTAmount AS SFBTAmounts,SFCardBalance+BTBalance AS SFBTBalances FROM VSF_SFData WHERE SFDate>='" + Param[10] + "' AND SFDate<='" + Param[11] + "'" + Param[12];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetSFTypeInfoSQL(Param[7]) + GetMealTypeInfoSQL(Param[8]) + GetMacSNInfoSQL(Param[9]);
                            ret += GetAddressInfoSQL(Param[13], Param[14], Param[15]);
                            ret += GetCardNoInfoSQL(Param[17]);
                            if (Param[16] == "0") ret += " AND IsAlarm=0";
                            ret += " ORDER BY EmpNo,CardUseTimes,SFDate";
                            break;
                        case 2:
                            ret = "SELECT EmpNo,EmpName,EmpCertNo,EmpPhoneNo,DepartID,DepartName,SFTypeName," +
                              "SUM(SFAmount) AS SFAmount,SUM(BTAmount) AS BTAmount,SUM(SFAmount)+SUM(BTAmount) AS SFBTAmounts,SUM(BTWay) AS BTWay " +
                              "FROM VSF_SFData WHERE IsAlarm=0 AND SFDate>='" + Param[10] + "' AND SFDate<='" + Param[11] + "'" + Param[12];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetSFTypeInfoSQL(Param[7]) + GetMealTypeInfoSQL(Param[8]) + GetMacSNInfoSQL(Param[9]);
                            ret += GetAddressInfoSQL(Param[13], Param[14], Param[15]);
                            ret += " GROUP BY EmpNo,EmpName,EmpCertNo,EmpPhoneNo,DepartID,DepartName,SFTypeName " +
                              "ORDER BY EmpNo,EmpName,DepartID,DepartName,SFTypeName";
                            break;
                        case 3:
                            ret = "SELECT * FROM VSF_SFTypeMobile ORDER BY SFTypeID";
                            break;
                        case 4:
                            ret = "SELECT * FROM VSF_SFDataMobile WHERE SFDate>='" + Param[3] + "' AND SFDate<='" + Param[4] + "'";
                            ret += GetSFTypeInfoSQL(Param[1]) + GetMacSNInfoSQL(Param[2]) + GetAddressInfoSQL(Param[5], Param[6], Param[7]);
                            ret += " ORDER BY SFDate";
                            break;
                        case 5:
                            ret = "SELECT * FROM VSF_SFDataMobileProduct WHERE SFDate>='" + Param[3] + "' AND SFDate<='" + Param[4] + "'";
                            ret += GetSFTypeInfoSQL(Param[1]) + GetMacSNInfoSQL(Param[2]) + GetAddressInfoSQL(Param[5], Param[6], Param[7]);
                            ret += " ORDER BY SFDate";
                            break;
                        case 6:
                            ret = "SELECT SFTypeName,ProductsName,SUM(ProductNum) AS ProductNum,SUM(ProductsMoney) AS ProductsMoney " +
                              "FROM VSF_SFDataMobileProduct WHERE SFDate>='" + Param[3] + "' AND SFDate<='" + Param[4] + "'";
                            ret += GetSFTypeInfoSQL(Param[1]) + GetMacSNInfoSQL(Param[2]) + GetAddressInfoSQL(Param[5], Param[6], Param[7]);
                            ret += " GROUP BY SFTypeName,ProductsName ORDER BY SFTypeName,ProductsName";
                            break;
                        case 7:
                            ret = "SELECT * FROM VSF_MobileErrorData WHERE SFDate>='" + Param[2] + "' AND SFDate<='" + Param[3] + "'";
                            ret += GetMacSNInfoSQL(Param[1]);
                            ret += " ORDER BY SFDate";
                            break;
                        case 10:
                            ret = "SELECT * FROM VSF_SFDataProduct WHERE SFDate>='" + Param[9] + "' AND SFDate<='" + Param[10] + "'" + Param[11];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetMealTypeInfoSQL(Param[7]) + GetMacSNInfoSQL(Param[8]) + GetAddressInfoSQL(Param[12], Param[13], Param[14]) + GetCategoryInfoSQL(Param[15], Param[16]);
                            ret += " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 11:
                            ret = "SELECT CategoryID,CategoryName,ProductsName,SUM(ProductNum) AS ProductNum,SUM(ProductsMoney) AS ProductsMoney " +
                              "FROM VSF_SFDataProduct WHERE SFDate>='" + Param[9] + "' AND SFDate<='" + Param[10] + "'" + Param[11];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetMealTypeInfoSQL(Param[7]) + GetMacSNInfoSQL(Param[8]) + GetAddressInfoSQL(Param[12], Param[13], Param[14]) + GetCategoryInfoSQL(Param[15], Param[16]);
                            ret += " GROUP BY CategoryID, CategoryName, ProductsName ORDER BY CategoryID, ProductsName";
                            break;
                        case 20:
                            ret = "SELECT * FROM VSF_SFDataDeposit WHERE SFDate>='" + Param[8] + "' AND SFDate<='" + Param[9] + "'" + Param[10];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            if (Param[7] != "") ret += " AND OprtNo IN(" + Param[7] + ")";
                            ret += " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 21:
                            s1 = "";
                            if (Param[1] == "0")
                            {
                                s = "DepartID,DepartName,EmpNo,EmpName,EmpCertNo,EmpPhoneNo";
                                s2 = "DepartID,EmpNo";
                            }
                            else if (Param[1] == "1")
                            {
                                s = "DepartID,DepartName";
                                s2 = "DepartID";
                            }
                            else if (Param[1] == "2")
                            {
                                s = "SFOprtNo";
                                s2 = "SFOprtNo";
                            }
                            else if (Param[1] == "3")
                            {
                                s = "OprtNo,OprtName";
                                s2 = "OprtNo";
                            }
                            else
                            {
                                s = "CONVERT(varchar(10),SFDate,120) AS SFDate";
                                s1 = "CONVERT(varchar(10),SFDate,120)";
                                s2 = "SFDate";
                            }
                            if (s1 == "") s1 = s;
                            ret = "SELECT " + s + ",SUM(iCZCount1) AS iCZCount1,SUM(iCZCountSum1) AS iCZCountSum1," +
                              "SUM(iCZCount10) AS iCZCount10,SUM(iCZCountSum10) AS iCZCountSum10," +
                              "SUM(iCZCount11) AS iCZCount11,SUM(iCZCountSum11) AS iCZCountSum11," +
                              "SUM(iCZCount12) AS iCZCount12,SUM(iCZCountSum12) AS iCZCountSum12," +
                              "SUM(iCZCount13) AS iCZCount13,SUM(iCZCountSum13) AS iCZCountSum13," +
                              "SUM(iCZCount14) AS iCZCount14,SUM(iCZCountSum14) AS iCZCountSum14," +
                              "SUM(iCZCount15) AS iCZCount15,SUM(iCZCountSum15) AS iCZCountSum15," +
                              "SUM(iCZCount16) AS iCZCount16,SUM(iCZCountSum16) AS iCZCountSum16," +
                              "SUM(iCZCount17) AS iCZCount17,SUM(iCZCountSum17) AS iCZCountSum17," +
                              "SUM(iCZCount18) AS iCZCount18,SUM(iCZCountSum18) AS iCZCountSum18," +
                              "SUM(iCZCount19) AS iCZCount19,SUM(iCZCountSum19) AS iCZCountSum19," +
                              "SUM(iCZCount2) AS iCZCount2,SUM(iCZCountSum2) AS iCZCountSum2," +
                              "SUM(iCZCount20) AS iCZCount20,SUM(iCZCountSum20) AS iCZCountSum20," +
                              "SUM(iCZCount21) AS iCZCount21,SUM(iCZCountSum21) AS iCZCountSum21," +
                              "SUM(iCZCount22) AS iCZCount22,SUM(iCZCountSum22) AS iCZCountSum22," +
                              "SUM(iCZCount23) AS iCZCount23,SUM(iCZCountSum23) AS iCZCountSum23," +
                              "SUM(iCZCount24) AS iCZCount24,SUM(iCZCountSum24) AS iCZCountSum24," +
                              "SUM(iCZCount25) AS iCZCount25,SUM(iCZCountSum25) AS iCZCountSum25," +
                              "SUM(iCZCount26) AS iCZCount26,SUM(iCZCountSum26) AS iCZCountSum26," +
                              "SUM(iCZCount27) AS iCZCount27,SUM(iCZCountSum27) AS iCZCountSum27," +
                              "SUM(iCZCount28) AS iCZCount28,SUM(iCZCountSum28) AS iCZCountSum28," +
                              "SUM(iCZCount29) AS iCZCount29,SUM(iCZCountSum29) AS iCZCountSum29," +
                              "SUM(iCZCountSum) AS iCZCountSum,SUM(iCZCount3) AS iCZCount3," +
                              "SUM(iCZCountSum3) AS iCZCountSum3 FROM ";
                            if (Param[1] == "2")
                                ret += "VSF_SFDataDepositTotalByMacOpter";
                            else if (Param[1] == "3")
                                ret += "VSF_SFDataDepositTotalByOpter";
                            else
                                ret += "VSF_SFDataDepositTotal";
                            ret += " WHERE SFDate>='" + Param[7] + "' AND SFDate<='" + Param[8] + "'" + Param[9];
                            ret += GetEmpInfoSQL(Param[2], Param[3]) + GetDepartInfoSQL(Param[4], Param[5], Param[6]);
                            ret += " GROUP BY " + s1 + " ORDER BY " + s2;
                            break;
                        case 30:
                            ret = "SELECT * FROM VSF_SFDataRefundment WHERE SFDate>='" + Param[8] + "' AND SFDate<='" + Param[9] + "'" + Param[10];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            if (Param[7] != "") ret += " AND OprtNo IN(" + Param[7] + ")";
                            ret += " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 31:
                            s1 = "";
                            if (Param[1] == "0")
                            {
                                s = "DepartID,DepartName,EmpNo,EmpName,EmpCertNo,EmpPhoneNo";
                                s2 = "DepartID,EmpNo";
                            }
                            else if (Param[1] == "1")
                            {
                                s = "DepartID,DepartName";
                                s2 = "DepartID";
                            }
                            else if (Param[1] == "2")
                            {
                                s = "SFOprtNo";
                                s2 = "SFOprtNo";
                            }
                            else if (Param[1] == "3")
                            {
                                s = "OprtNo,OprtName";
                                s2 = "OprtNo";
                            }
                            else
                            {
                                s = "CONVERT(varchar(10),SFDate,120) AS SFDate";
                                s1 = "CONVERT(varchar(10),SFDate,120)";
                                s2 = "SFDate";
                            }
                            if (s1 == "") s1 = s;
                            ret = "SELECT " + s + ",SUM(iCZCount1) AS iCZCount1,SUM(iCZCountSum1) AS iCZCountSum1," +
                              "SUM(iCZCount2) AS iCZCount2,SUM(iCZCountSum2) AS iCZCountSum2,SUM(iCZCountSum) AS iCZCountSum," +
                              "SUM(iCZCount3) AS iCZCount3,SUM(iCZCountSum3) AS iCZCountSum3," +
                              "SUM(BTiCZCount1) AS BTiCZCount1,SUM(BTiCZCountSum1) AS BTiCZCountSum1," +
                              "SUM(BTiCZCount2) AS BTiCZCount2,SUM(BTiCZCountSum2) AS BTiCZCountSum2" +
                              " FROM ";
                            if (Param[1] == "2")
                                ret += "VSF_SFDataRefundmentTotalByMacOpter";
                            else if (Param[1] == "3")
                                ret += "VSF_SFDataRefundmentTotalByOpter";
                            else
                                ret += "VSF_SFDataRefundmentTotal";
                            ret += " WHERE SFDate>='" + Param[7] + "' AND SFDate<='" + Param[8] + "'" + Param[9];
                            ret += GetEmpInfoSQL(Param[2], Param[3]) + GetDepartInfoSQL(Param[4], Param[5], Param[6]);
                            ret += " GROUP BY " + s1 + " ORDER BY " + s2;
                            break;
                        case 40:
                            s1 = "";
                            if (Param[1] == "0")
                            {
                                s = "DepartID,DepartName,EmpNo,EmpName,EmpCertNo,EmpPhoneNo";
                                s2 = "DepartID,EmpNo";
                            }
                            else if (Param[1] == "1")
                            {
                                s = "DepartID,DepartName";
                                s2 = "DepartID";
                            }
                            else if (Param[1] == "2")
                            {
                                s = "SFMacSn";
                                s2 = "SFMacSn";
                            }
                            else if (Param[1] == "3")
                            {
                                s = "AddressNo,AddressName";
                                s2 = "AddressNo";
                            }
                            else if (Param[1] == "4")
                            {
                                s = "CONVERT(varchar(10),SFDate,120) AS SFDate";
                                s1 = "CONVERT(varchar(10),SFDate,120)";
                                s2 = "SFDate";
                            }
                            else
                            {
                                s = "CardTypeName";
                                s2 = "CardTypeName";
                            }
                            if (s1 == "") s1 = s;
                            ret = "SELECT " + s + ",SUM(iCount) AS iCount,SUM(iCountSum) AS iCountSum," +
                              "SUM(iCount+iCountBT) AS iCountSFBT,SUM(iCountSum+iCountBTSum) AS iCountSFBTSum," +
                              "SUM(iCountBT) AS iCountBT,SUM(iCountBTSum) AS iCountBTSum," +
                              "SUM(iCountBTW) AS iCountBTW,SUM(iCountBTWSum) AS iCountBTWSum," +
                              "SUM(iCountMeal1) AS iCountMeal1,SUM(iCountSumMeal1) AS iCountSumMeal1,SUM(iCountMeal1+iCountBTMeal1) AS iCountSFBTMeal1," +
                              "SUM(iCountMeal2) AS iCountMeal2,SUM(iCountSumMeal2) AS iCountSumMeal2,SUM(iCountMeal2+iCountBTMeal2) AS iCountSFBTMeal2," +
                              "SUM(iCountMeal3) AS iCountMeal3,SUM(iCountSumMeal3) AS iCountSumMeal3,SUM(iCountMeal3+iCountBTMeal3) AS iCountSFBTMeal3," +
                              "SUM(iCountMeal4) AS iCountMeal4,SUM(iCountSumMeal4) AS iCountSumMeal4,SUM(iCountMeal4+iCountBTMeal4) AS iCountSFBTMeal4," +
                              "SUM(iCountSumMeal1+iCountBTSumMeal1) AS iCountSFBTSumMeal1," +
                              "SUM(iCountSumMeal2+iCountBTSumMeal2) AS iCountSFBTSumMeal2," +
                              "SUM(iCountSumMeal3+iCountBTSumMeal3) AS iCountSFBTSumMeal3," +
                              "SUM(iCountSumMeal4+iCountBTSumMeal4) AS iCountSFBTSumMeal4," +

                              "SUM(iCountBTMeal1) AS iCountBTMeal1,SUM(iCountBTSumMeal1) AS iCountBTSumMeal1," +
                              "SUM(iCountBTMeal2) AS iCountBTMeal2,SUM(iCountBTSumMeal2) AS iCountBTSumMeal2," +
                              "SUM(iCountBTMeal3) AS iCountBTMeal3,SUM(iCountBTSumMeal3) AS iCountBTSumMeal3," +
                              "SUM(iCountBTMeal4) AS iCountBTMeal4,SUM(iCountBTSumMeal4) AS iCountBTSumMeal4," +
                              "SUM(iCountBTWMeal1) AS iCountBTWMeal1,SUM(iCountBTWSumMeal1) AS iCountBTWSumMeal1," +
                              "SUM(iCountBTWMeal2) AS iCountBTWMeal2,SUM(iCountBTWSumMeal2) AS iCountBTWSumMeal2," +
                              "SUM(iCountBTWMeal3) AS iCountBTWMeal3,SUM(iCountBTWSumMeal3) AS iCountBTWSumMeal3," +
                              "SUM(iCountBTWMeal4) AS iCountBTWMeal4,SUM(iCountBTWSumMeal4) AS iCountBTWSumMeal4 " +
                              "FROM VSF_SFReportMealCount WHERE SFDate>='" + Param[8] + "' AND SFDate<='" + Param[9] + "'" + Param[10];
                            ret += GetEmpInfoSQL(Param[2], Param[3]) + GetDepartInfoSQL(Param[4], Param[5], Param[6]) + GetMacSNInfoSQL(Param[7]);
                            ret += GetAddressInfoSQL(Param[11], Param[12], Param[13]);
                            ret += " GROUP BY " + s1 + " ORDER BY " + s2;
                            break;
                        case 50:
                            s1 = "";
                            if (Param[1] == "0")
                            {
                                s = "DepartID,DepartName,EmpNo,EmpName,EmpCertNo,EmpPhoneNo";
                                s2 = "DepartID,EmpNo";
                            }
                            else if (Param[1] == "1")
                            {
                                s = "DepartID,DepartName";
                                s2 = "DepartID";
                            }
                            else if (Param[1] == "2")
                            {
                                s = "SFMacSn";
                                s2 = "SFMacSn";
                            }
                            else if (Param[1] == "3")
                            {
                                s = "AddressNo,AddressName";
                                s2 = "AddressNo";
                            }
                            else if (Param[1] == "4")
                            {
                                s = "CONVERT(varchar(10),SFDate,120) AS SFDate";
                                s1 = "CONVERT(varchar(10),SFDate,120)";
                                s2 = "SFDate";
                            }
                            else
                            {
                                s = "CardTypeName";
                                s2 = "CardTypeName";
                            }
                            if (s1 == "") s1 = s;
                            ret = "SELECT " + s + ",SUM(iCountDZ) AS iCountDZ,SUM(iCountDZSum) AS iCountDZSum," +
                              "SUM(iCountBTDZ) AS iCountBTDZ,SUM(iCountBTDZSum) AS iCountBTDZSum," +
                              "SUM(iCountDZ+iCountBTDZ) AS iCountSFBTDZ,SUM(iCountDZSum+iCountBTDZSum) AS iCountSFBTDZSum," +
                              "SUM(iCountBTWay) AS iCountBTWay,SUM(iCountBTWaySum) AS iCountBTWaySum," +
                              "SUM(iCountJZ) AS iCountJZ,SUM(iCountJZSum) AS iCountJZSum," +
                              "SUM(WeiXinCnt) AS WeiXinCnt,SUM(WeiXinSum) AS WeiXinSum," +
                              "SUM(AliPayCnt) AS AliPayCnt,SUM(AliPaySum) AS AliPaySum " +
                              "FROM VSF_SFReportConsumeCount WHERE SFDate>='" + Param[8] + "' AND SFDate<='" + Param[9] + "'" + Param[10];
                            ret += GetEmpInfoSQL(Param[2], Param[3]) + GetDepartInfoSQL(Param[4], Param[5], Param[6]) + GetMacSNInfoSQL(Param[7]);
                            ret += GetAddressInfoSQL(Param[11], Param[12], Param[13]);
                            ret += " GROUP BY " + s1 + " ORDER BY " + s2;
                            break;
                        case 60:
                            ret = "SELECT CheckOutDate FROM SF_Check ORDER BY CheckOutDate DESC";
                            break;
                        case 61:
                            if (Param[1] == "0")
                                ret = "EXEC PSF_SFCheckReport 0,'" + Param[2] + "','" + Param[3] + "'";
                            else
                                ret = "EXEC PSF_SFCheckReport 1,'" + Param[4] + "','" + Param[3] + "'";
                            break;
                        case 62:
                            ret = "SELECT TOP 1 * FROM SF_CheckReport";
                            break;
                        case 70:
                            ret = "SELECT * FROM VSF_SFLossData WHERE SFDate>='" + Param[10] + "' AND SFDate<='" + Param[11] + "'" + Param[12];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetSFTypeInfoSQL(Param[7]) + GetMealTypeInfoSQL(Param[8]) + GetMacSNInfoSQL(Param[9]);
                            ret += GetAddressInfoSQL(Param[13], Param[14], Param[15]) + " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 71:
                            ret = "SELECT * FROM VSF_SFAlarmData WHERE SFDate>='" + Param[10] + "' AND SFDate<='" + Param[11] + "'" + Param[12];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetSFTypeInfoSQL(Param[7]) + GetMealTypeInfoSQL(Param[8]) + GetMacSNInfoSQL(Param[9]);
                            ret += GetAddressInfoSQL(Param[13], Param[14], Param[15]) + " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 72:
                            ret = "SELECT * FROM VSF_SFErrorData WHERE SFDate>='" + Param[10] + "' AND SFDate<='" + Param[11] + "'" + Param[12];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetSFTypeInfoSQL(Param[7]) + GetMealTypeInfoSQL(Param[8]) + GetMacSNInfoSQL(Param[9]);
                            ret += GetAddressInfoSQL(Param[13], Param[14], Param[15]) + " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 73:
                            ret = "SELECT * FROM VSF_SFReturnData WHERE SFDate>='" + Param[10] + "' AND SFDate<='" + Param[11] + "'" + Param[12];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetSFTypeInfoSQL(Param[7]) + GetMealTypeInfoSQL(Param[8]) + GetMacSNInfoSQL(Param[9]);
                            ret += GetAddressInfoSQL(Param[13], Param[14], Param[15]) + " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 74:
                            ret = "SELECT * FROM VSF_SFDataOrder WHERE SFDate>='" + Param[9] + "' AND SFDate<='" + Param[10] + "'" + Param[11];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetMealTypeInfoSQL(Param[7]) + GetMacSNInfoSQL(Param[8]);
                            ret += GetAddressInfoSQL(Param[12], Param[13], Param[14]) + " ORDER BY EmpNo,CardUseTimes";
                            break;
                        case 80:
                            s1 = "";
                            if (Param[1] == "0")
                            {
                                s = "DepartID,DepartName,EmpNo,EmpName,EmpCertNo,EmpPhoneNo";
                                s2 = "DepartID,EmpNo";
                            }
                            else if (Param[1] == "1")
                            {
                                s = "DepartID,DepartName";
                                s2 = "DepartID";
                            }
                            else if (Param[1] == "2")
                            {
                                s = "SFMacSn";
                                s2 = "SFMacSn";
                            }
                            else if (Param[1] == "3")
                            {
                                s = "AddressNo,AddressName";
                                s2 = "AddressNo";
                            }
                            else if (Param[1] == "4")
                            {
                                s = "CONVERT(varchar(10),SFDate,120) AS SFDate";
                                s1 = "CONVERT(varchar(10),SFDate,120)";
                                s2 = "SFDate";
                            }
                            else
                            {
                                s = "CardTypeName";
                                s2 = "CardTypeName";
                            }
                            if (s1 == "") s1 = s;
                            ret = "SELECT " + s + ",SUM(XFCount1) AS XFCount1,SUM(XFSum1) AS XFSum1,SUM(XFCount2) AS XFCount2,SUM(XFCount1+BTXFCount1) AS SFBTXFCount1," +
                              "SUM(XFCount2+BTXFCount1) AS SFBTXFCount2,SUM(XFSum1+BTXFSum1) AS SFBTXFSum1,SUM(XFSum2+BTXFSum2) AS SFBTXFSum2," +
                              "SUM(BTXFCount1) AS BTXFCount1,SUM(BTXFSum1) AS BTXFSum1,SUM(BTXFCount2) AS BTXFCount2,SUM(BTWXFCount1) AS BTWXFCount1,SUM(BTWXFSum1) AS BTWXFSum1," +
                              "SUM(XFSum2) AS XFSum2,SUM(XFCount3) AS XFCount3,SUM(XFSum3) AS XFSum3,SUM(XFCount4) AS XFCount4," +
                              "SUM(XFCount4+BTXFCount4) AS SFBTXFCount4,SUM(XFSum4+BTXFSum4) AS SFBTXFSum4," +
                              "SUM(BTXFSum2) AS BTXFSum2,SUM(BTXFCount3) AS BTXFCount3,SUM(BTXFSum3) AS BTXFSum3,SUM(BTXFCount4) AS BTXFCount4," +
                              "SUM(XFSum4) AS XFSum4,SUM(BTXFSum4) AS BTXFSum4,SUM(XFCount5) AS XFCount5,SUM(XFSum5) AS XFSum5,SUM(XFCount6) AS XFCount6," +
                              "SUM(XFSum6) AS XFSum6,SUM(XFCount7) AS XFCount7,SUM(XFSum7) AS XFSum7,SUM(XFCount8) AS XFCount8," +
                              "SUM(XFSum8) AS XFSum8,SUM(XFCount9) AS XFCount9,SUM(XFSum9) AS XFSum9,SUM(BTXFCount10+XFCount10) AS BTXFCount10," +
                              "SUM(BTXFSum10+XFSum10) AS BTXFSum10,SUM(XFCount11) AS XFCount11,SUM(XFSum11) AS XFSum11," +
                              "SUM(XFCount12) AS XFCount12,SUM(XFSum12) AS XFSum12,SUM(XFCount13) AS XFCount13," +
                              "SUM(BTXFCount11) AS BTXFCount11,SUM(BTXFSum11) AS BTXFSum11,SUM(BTXFCount12) AS BTXFCount12," +
                              "SUM(BTXFSum12) AS BTXFSum12,SUM(BTXFCount13) AS BTXFCount13," +
                              "SUM(XFSum13) AS XFSum13,SUM(XFCount14) AS XFCount14,SUM(XFSum14) AS XFSum14," +
                              "SUM(BTXFSum13) AS BTXFSum13,SUM(BTXFCount14) AS BTXFCount14,SUM(BTXFSum14) AS BTXFSum14," +
                              "SUM(XFCount15) AS XFCount15,SUM(XFSum15) AS XFSum15,SUM(XFCount16) AS XFCount16," +
                              "SUM(XFCount11+ BTXFCount11) AS SFBTXFCount11,SUM(XFSum11+BTXFSum11) AS SFBTXFSum11," +
                              "SUM(XFCount12+ BTXFCount12) AS SFBTXFCount12,SUM(XFSum12+BTXFSum12) AS SFBTXFSum12," +
                              "SUM(XFCount13+ BTXFCount13) AS SFBTXFCount13,SUM(XFSum13+BTXFSum13) AS SFBTXFSum13," +
                              "SUM(XFCount14+ BTXFCount14) AS SFBTXFCount14,SUM(XFSum14+BTXFSum14) AS SFBTXFSum14," +
                              "SUM(XFCount18) AS XFCount18,SUM(XFSum18) AS XFSum18," +
                              "SUM(XFSum16) AS XFSum16 FROM ";
                            if (Param[1] == "2" || Param[1] == "3")
                                ret += "VSF_SFReportCompositeCountByMac";
                            else
                                ret += "VSF_SFReportCompositeCount";
                            ret += " WHERE SFDate>='" + Param[8] + "' AND SFDate<='" + Param[9] + "'" + Param[10];
                            ret += GetEmpInfoSQL(Param[2], Param[3]) + GetDepartInfoSQL(Param[4], Param[5], Param[6]) + GetMacSNInfoSQL(Param[7]);
                            ret += GetAddressInfoSQL(Param[11], Param[12], Param[13]);
                            ret += " GROUP BY " + s1 + " ORDER BY " + s2;
                            break;
                        case 100:
                            ret = "SELECT * FROM VSF_AirCZData WHERE SFDate>='" + Param[8] + "' AND SFDate<='" + Param[9] + "'" + Param[10];
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]) + GetCardTypeInfoSQL(Param[6]);
                            ret += GetMacSNInfoSQL(Param[7]);
                            ret += " ORDER BY EmpNo,SFDate";
                            break;
                    }
                    break;
                case DBCode.DB_004012:
                    ret = "SELECT a.*,b.FaDate,b.CardTypeID FROM VSF_SfData a INNER JOIN VRS_Emp b ON b.EmpSysID=a.EmpSysID WHERE a.EmpSysID='" +
                      Param[0] + "' AND a.IsAlarm=0 AND a.CardUseTimes=" + Param[1] + " ORDER BY a.SFDate";
                    break;
                case DBCode.DB_004013:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSF_DepositType ORDER BY DepositTypeID";
                            break;
                        case 1:
                            ret = "INSERT INTO SF_DepositType(GUID,DepositTypeID,DepositTypeName) VALUES(newid()," + Param[1] + ",'" + Param[2] + "')";
                            break;
                        case 2:
                            ret = "UPDATE SF_DepositType SET DepositTypeID=" + Param[1] + ",DepositTypeName='" + Param[2] + "' WHERE GUID='" + Param[3] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SF_DepositType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SF_DepositType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM SF_DepositType WHERE DepositTypeID=" + Param[1];
                            break;
                        case 6:
                            ret = "SELECT * FROM SF_DepositType WHERE GUID<>'" + Param[1] + "' AND DepositTypeID=" + Param[2];
                            break;
                        case 101:
                            ret = "SELECT ISNULL(MAX(DepositTypeID),0)+1 AS DepositTypeID FROM SF_DepositType";
                            break;
                        case 102:
                            ret = "SELECT * FROM VSF_SFType WHERE SFTypeID=10";
                            break;
                        case 103:
                            ret = "SELECT * FROM VSF_SFType WHERE SFTypeID>=90 AND SFTypeID<=99 ORDER BY SFTypeID";
                            break;
                        case 200:
                            ret = "SELECT COUNT(1) AS Times,ISNULL(SUM(SFAmount),0) AS SFAmount FROM RS_DepositInfo WHERE EmpSysID='" +
                              Param[1] + "' AND SFDate>=CAST(CONVERT(varchar(8),getdate(),120)+'01 00:00:00' AS datetime) AND " +
                              "SFDate<DATEADD(mm,1,CAST(CONVERT(varchar(8),getdate(),120)+'01 00:00:00' AS datetime))";
                            break;
                    }
                    break;
                case DBCode.DB_004014:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSF_RefundmentType ORDER BY RefundmentTypeID";
                            break;
                        case 1:
                            ret = "INSERT INTO SF_RefundmentType(GUID,RefundmentTypeID,RefundmentTypeName) VALUES(newid()," + Param[1] + ",'" + Param[2] + "')";
                            break;
                        case 2:
                            ret = "UPDATE SF_RefundmentType SET RefundmentTypeID=" + Param[1] + ",RefundmentTypeName='" + Param[2] + "' WHERE GUID='" + Param[3] + "'";
                            break;
                        case 3:
                            ret = "DELETE FROM SF_RefundmentType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SF_RefundmentType WHERE GUID='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "SELECT * FROM SF_RefundmentType WHERE RefundmentTypeID=" + Param[1];
                            break;
                        case 6:
                            ret = "SELECT * FROM SF_RefundmentType WHERE GUID<>'" + Param[1] + "' AND RefundmentTypeID=" + Param[2];
                            break;
                        case 101:
                            ret = "SELECT ISNULL(MAX(RefundmentTypeID),0)+1 AS RefundmentTypeID FROM SF_RefundmentType";
                            break;
                        case 102:
                            ret = "SELECT * FROM VSF_SFType WHERE SFTypeID=20";
                            break;
                    }
                    break;

                case DBCode.DB_005001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "EXEC PSK_SKDataInsert '" + Param[1] + "'," + Param[2] + ",'" + Param[3] + "'," + Param[4] + "," +
                              Param[5] + ",'" + Param[6] + "'";
                            break;
                        case 1:
                            ret = "SELECT * FROM VSK_SKType ORDER BY SKTypeID";
                            break;
                        case 2:
                            ret = "SELECT * FROM VSK_Data WHERE SKDate>='" + Param[7] + "' AND SKDate<='" + Param[8] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[6] != "") ret += " AND SKTypeName IN(" + Param[6] + ")";
                            ret += Param[9] + " ORDER BY EmpNo,SKDate,SKTypeName";
                            break;
                        case 3:
                            ret = "SELECT EmpNo,EmpName,DepartID,DepartName,SKTypeName,SUM(SKAmount) AS SKAmount FROM VSK_Data " +
                              "WHERE SKDate>='" + Param[7] + "' AND SKDate<='" + Param[8] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            if (Param[6] != "") ret += " AND SKTypeName IN(" + Param[6] + ")";
                            ret += Param[9] + " GROUP BY EmpNo,EmpName,DepartID,DepartName,SKTypeName " +
                              "ORDER BY EmpNo,EmpName,DepartID,DepartName,SKTypeName";
                            break;
                    }
                    break;

                case DBCode.DB_006001:
                    if (Param.Length > 0) I = Convert.ToInt32(Param[0]);
                    switch (I)
                    {
                        case 0:
                            ret = "SELECT * FROM VSEA_MacInfoFace ORDER BY MacSN";
                            break;
                        case 1:
                            ret = "DELETE FROM SEA_MacInfoFace WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 2:
                            ret = "EXEC PGetMaxIDFromTable 'MacSN','SEA_MacInfoFace'";
                            break;
                        case 3:
                            ret = "SELECT * FROM SEA_MacInfoFace WHERE MacSysID='" + Param[1] + "'";
                            break;
                        case 4:
                            ret = "SELECT * FROM SEA_MacInfoFace WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 5:
                            ret = "INSERT INTO SEA_MacInfoFace(MacSysID,MacSN,MacIpAddress," +
                              "MacPort,MacName,MacPWD,MacInOut,MacInOutName,MacDesc) VALUES(newid(),'" + Param[1] + "','" + Param[2] +
                              "','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "'," + Param[6] + ",'" + Param[7] + "','" + Param[8] + "' )";
                            break;
                        case 6:
                            ret = "SELECT * FROM SEA_MacInfoFace WHERE MacSysID<>'" + Param[1] + "' AND MacSN='" + Param[2] + "'";
                            break;
                        case 7:
                            ret = "UPDATE SEA_MacInfoFace SET MacSN='" + Param[1] + "',MacIpAddress='" + Param[2] + "'," +
                                "MacPort='" + Param[3] + "',MacName='" + Param[4] + "',MacPWD='" + Param[5] + "'," +
                                "MacInOut=" + Param[6] + ",MacInOutName='" + Param[7] + "',MacDesc='" + Param[8] + "'  WHERE MacSysID='" + Param[9] + "'";
                            break;
                        case 8:
                            ret = "INSERT INTO Sea_MJData([GUID],EmpSysID,MacSN,KQDate,KQTime,DoorStauts,VerifyModeID," +
                                "VerifyModeName,InOutModeID,InOutModeName,OprtNo,OprtDate,Remark,IsAlarm,Temperature,TemperatureAlarm) " +
                                "VALUES('" + Param[1] + "','" + Param[2] +"','" + Param[3] + "','" + Param[4] + "','" + Param[5] + "'," +
                                "'" + Param[6] + "'," + Param[7] + ",'" + Param[8] + "'," + Param[9] + ",'" + Param[10] + "'," +
                                "'" + Param[11] + "','" + Param[12] + "','" + Param[13] + "'," + Param[14] + ",'" + Param[15] + "'" +
                                "," + Param[16] + ")";
                            break;
                        case 9:
                            ret = "SELECT EmpSysID FROM RS_EmpCard WHERE CardFingerNo=" + Param[1] + "";
                            break;
                        case 10:
                            ret = "INSERT INTO SEA_MJDataPhoto([GUID],Photo) VALUES('" + Param[1] + "',@Photo)";
                            break;
                        case 11:
                            ret = "SELECT * FROM VSEA_MJData WHERE MacSN='" + Param[1] + "' AND VerifyModeID=" + Param[2] + " AND KQDate='" + Param[3] + "' AND KQTime='" + Param[4] + "'";
                            break;
                        case 12:
                            ret = "UPDATE SEA_MJDataPhoto SET Photo=@Photo WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 13:
                            ret = "SELECT * FROM SEA_MJDataPhoto WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 14:
                            ret = "SELECT * FROM VSEA_MJData WHERE KQDate>='" + Param[6] + "' AND KQDate<='" + Param[7] + "'";
                            ret += GetEmpInfoSQL(Param[1], Param[2]) + GetDepartInfoSQL(Param[3], Param[4], Param[5]);
                            ret += Param[8] + " ORDER BY EmpNo,KQDate,KQTime";
                            break;
                        case 15:
                            ret = "SELECT * FROM SEA_MJDataPhoto WHERE GUID='" + Param[1] + "'";
                            break;
                        case 16:
                            ret = "SELECT * FROM VSEA_SnapShots WHERE OprtDate>='" + Param[1] + "' AND OprtDate<='" + Param[2] + "'";
                            ret += " ORDER BY OprtDate";
                            break;
                        case 17:
                            ret = "SELECT Photo FROM SEA_SnapShotsPhoto WHERE GUID='" + Param[1] + "'";

                            break;
                        case 18:
                            ret = "DELETE FROM SEA_SnapShots WHERE [GUID]='" + Param[1] + "'";
                            break;

                        case 19:
                            ret = "SELECT * FROM VSEA_SeaPower WHERE EmpSysID is not null ";
                            if (Param.Length > 1)
                            {
                                ret += GetEmpInfoSQL(Param[1], Param[2]) + GetKQMacSNInfoSQL(Param[3]);
                            }
                            ret += " ORDER BY EmpNo";
                            break;

                        case 20:
                            ret = "DELETE FROM SEA_SeaPower WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 21:
                            ret = "SELECT * FROM SEA_SeaPower WHERE MacSN='" + Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 22:
                            ret = "INSERT INTO SEA_SeaPower(GUID,MacSN,EmpNo,OprtNo," +
                              "OprtDate,StartDate,EndDate) VALUES(newid()," + Param[1] + ",'" + Param[2] + "','" + Param[3] + "',getdate()," + Param[4] + "," + Param[5] + ")";
                            break;
                        case 23:
                            ret = "UPDATE SEA_SeaPower SET OprtNo='" +
                              Param[3] + "',OprtDate=getdate(),StartDate=" + Param[4] + ",EndDate=" + Param[5] + " WHERE MacSN='" +
                              Param[1] + "' AND EmpNo='" + Param[2] + "'";
                            break;
                        case 24:
                            ret = "SELECT * FROM VSEA_SeaPower WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 25:
                            ret = "UPDATE SEA_SeaPower SET OprtNo='" + Param[2] +
                              "',OprtDate=getdate(),StartDate=" + Param[3] + ",EndDate=" + Param[4] + " WHERE [GUID]='" + Param[1] + "'";
                            break;
                        case 26:
                            ret = "DELETE FROM SEA_SeaPower WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 27:
                            ret = "SELECT [GUID],MacSN,EmpNo,OprtNo,OprtDate,StartDate,EndDate FROM SEA_SeaPower WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 28:
                            ret = "SELECT [GUID],MacSN,EmpNo,OprtNo,OprtDate,StartDate,EndDate FROM SEA_SeaPower WHERE 1=2";
                            break;
                        case 29:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID IN(SELECT EmpSysID FROM VRS_EmpFaceInfo)";
                            break;
                        case 30:
                            ret = "SELECT * FROM VSEA_SeaPower WHERE MacSN='" + Param[1] + "'";
                            break;
                        case 31:
                            ret = "UPDATE SEA_MacInfoFace SET MacName='" + Param[1] + "',MacPWD='" + Param[2] + "'  WHERE MacSN='" + Param[3] + "'";
                            break;
                        case 32:
                            ret = "SELECT * FROM VSEA_SeaPower WHERE GUID IN(" + Param[1] + ")";
                            break;
                        case 33:
                            ret = "SELECT * FROM VRS_EmpDimission";
                            break;
                        case 34:
                            ret = "INSERT INTO SEA_SeaSound([MacSN],VerifyFailAudio,VerifySuccAudio,RemoteCtrlAudio,VerifySuccGuiTip,UnregisteredGuiTip," +
                                "VerifyFailGuiTip,Volume,IPHide,IsShowName,IsShowTitle,IsShowVersion,IsShowDate,IDCardNumHide,ICCardNumHide) VALUES('" + Param[1] + "'," + Param[2] + "," +
                                 "" + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + "," + Param[8] + "," + Param[9] + "," + Param[10] + "" +
                                 "," + Param[11] + "," + Param[12] + "," + Param[13] + "," + Param[14] + "," + Param[15] + ")";
                            break;
                        case 35:
                            ret = "UPDATE SEA_SeaSound SET VerifyFailAudio=" + Param[2] + ",VerifySuccAudio=" + Param[3] + ",RemoteCtrlAudio=" + Param[4] + ",VerifySuccGuiTip=" + Param[5] + ",UnregisteredGuiTip=" + Param[6] + "," +
                                "VerifyFailGuiTip=" + Param[7] + ",Volume=" + Param[8] + ",IPHide=" + Param[9] + ",IsShowName=" + Param[10] + ",IsShowTitle=" + Param[11] + ",IsShowVersion=" + Param[12] + "," +
                                "IsShowDate=" + Param[13] + ",IDCardNumHide=" + Param[14] + ",ICCardNumHide=" + Param[15] + " WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 36:
                            ret = "SELECT * FROM SEA_SeaSound";
                            break;
                        case 37:
                            ret = "INSERT INTO SEA_SeaDoorCondition([MacSN],FaceThreshold,IDCardThreshold,OpendoorWay,VerifyMode,Wiegand," +
                                "ControlType,PublicMjCardNo,AutoMjCardBgnNo,AutoMjCardEndNo,IOStayTime) VALUES('" + Param[1] + "'," + Param[2] + "," +
                                 "" + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + ",'" + Param[8] + "','" + Param[9] + "','" + Param[10] + "'" +
                                 ",'" + Param[11] + "')";
                            break;
                        case 38:
                            ret = "UPDATE SEA_SeaDoorCondition SET FaceThreshold=" + Param[2] + ",IDCardThreshold=" + Param[3] + ",OpendoorWay=" + Param[4] + ",VerifyMode=" + Param[5] + ",Wiegand=" + Param[6] + "," +
                                "ControlType=" + Param[7] + ",PublicMjCardNo='" + Param[8] + "',AutoMjCardBgnNo='" + Param[9] + "',AutoMjCardEndNo='" + Param[10] + "',IOStayTime='" + Param[11] + "' WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 39:
                            ret = "SELECT * FROM SEA_SeaDoorCondition";
                            break;
                        case 40:
                            ret = "INSERT INTO SEA_SeaNetParam([MacSN],IPAddr,Submask,Gateway,ListenPort,WebPort) VALUES('" + Param[1] + "','" + Param[2] + "'," +
                                 "'" + Param[3] + "','" + Param[4] + "','" + Param[5] + "','" + Param[6] + "')";
                            break;
                        case 41:
                            ret = "UPDATE SEA_SeaNetParam SET IPAddr='" + Param[2] + "',Submask='" + Param[3] + "',Gateway='" + Param[4] + "',ListenPort='" + Param[5] + "',WebPort='" + Param[6] + "' WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 42:
                            ret = "SELECT * FROM SEA_SeaNetParam";
                            break;
                        case 43:
                            ret = "INSERT INTO SEA_SeaTemperature([MacSN],FaceMaskTPTMode,TemperatureCheck,TemperatureHigh,EnvTemperature,EnvTemperatureCheck," +
                                "OpenLaser) VALUES('" + Param[1] + "'," + Param[2] + "," +
                                 "" + Param[3] + "," + Param[4] + "," + Param[5] + "," + Param[6] + "," + Param[7] + ")";
                            break;
                        case 44:
                            ret = "UPDATE SEA_SeaTemperature SET FaceMaskTPTMode=" + Param[2] + ",TemperatureCheck=" + Param[3] + ",TemperatureHigh=" + Param[4] + ",EnvTemperature=" + Param[5] + ",EnvTemperatureCheck=" + Param[6] + "," +
                                "OpenLaser=" + Param[7] + " WHERE [MacSN]='" + Param[1] + "'";
                            break;
                        case 45:
                            ret = "SELECT * FROM SEA_SeaTemperature";
                            break;
                        case 46:
                            ret = "SELECT * FROM VRS_Emp WHERE EmpSysID IN(" + Param[1] + ") AND EmpSysID IN(SELECT EmpSysID FROM VRS_EmpFaceInfo)";
                            break;
                        case 47:
                            ret = "SELECT * FROM VRS_EmpFaceInfo where EmpSysID='" + Param[1] + "' AND FaceBkNo=" + Param[2] + "";
                            break;
                        case 48:
                            ret = "SELECT * FROM VRS_Emp WHERE CardFingerNo IN(" + Param[1] + ")";
                            break;
                        case 49:
                            ret = "INSERT INTO RS_EmpFingerInfo(EnableFlag,FingerNo,FingerBkNo,FingerPWD) VALUES(" +
                              Param[1] + "," + Param[2] + "," + Param[3] + "," + Param[4] + ")";
                            break;
                        case 50:
                            ret = "UPDATE RS_EmpFingerInfo SET FingerPWD=" + Param[3] + " WHERE EnableFlag=" +
                              Param[1] + " AND FingerNo=" + Param[2] + " AND FingerBkNo=" + Param[3];
                            break;
                        case 51:
                            ret = "UPDATE RS_EmpFingerInfo SET FingerTemplate=@FingerTemplate WHERE EnableFlag=" + Param[1] +
                              " AND FingerNo=" + Param[2] + " AND FingerBkNo=" + Param[3];
                            break;
                    }
                    break;
            }
            return ret;
        }
    }
}