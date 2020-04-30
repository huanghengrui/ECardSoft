IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='SEA_MacInfoFace')
  CREATE TABLE SEA_MacInfoFace
  (
    MacSysID varchar(36) NOT NULL,
    MacSN varchar(10) NOT NULL,
    MacIpAddress varchar(50) NULL,
    MacPort varchar(10) NOT NULL,
    MacConnName varchar(50) NULL,
    MacConnPWD varchar(50) NULL,
    MacInOut tinyint NOT NULL,
    MacDesc varchar(100) NULL,
    CONSTRAINT PK_SEA_MacInfoFace PRIMARY KEY(MacSysID),
    CONSTRAINT AK_SEA_MacInfoFace UNIQUE(MacSN)
  )
GO