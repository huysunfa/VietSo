SQLite format 3   @                                                                     .O|� 
� ��m
�                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              �x�SviewChuSoChuSoCREATE VIEW ChuSo AS
    SELECT *
      FROM Person AS ps
     WHERE ps.id = (
                       SELECT ID
                         FROM Person ps1
                        WHERE ps.SoNo = ps1.SoNo AND 
                              ps.PagodaID = ps1.PagodaID AND 
                              (Status <> 'Deleted' OR 
                               Status IS NULL) AND 
                              (NgayMat = '' OR 
                               NgayMat IS NULL) 
                        ORDER BY Orders,
                                 NamSinh ASC
                        LIMIT 1
                   )�S�tablePersonPersonCREATE TABLE Person (
    ID       INTEGER  PRIMARY KEY,
    FullName TEXT,
    NamSinh  INTEGER,
    GioiTinh BOOLEAN  DEFAULT (0),
    Address  TEXT,
    PagodaID VARCHAR,
    SoNo     INTEGER,
    Orders   INTEGER  DEFAULT (0),
    Status   VARCHAR,
    UpdateDT DATETIME,
    NgayMat  TEXT,
    DanhXung TEXT
)��etablePagodaPagodaCREATE TABLE Pagoda (
    ID       VARCHAR  PRIMARY KEY,
    Name     TEXT,
    Address  TEXT,
    Leader   TEXT,
    Phone    VARCHAR,
    KeySoft  VARCHAR,
    Status   VARCHAR,
    UpdateDT DATETIME,
    IsPrint  BOOLEAN  DEFAULT 0
)+? indexsqlite_autoindex_Pagoda_1Pagoda          � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
+     1Tên Nơi Cúngsync
   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 	1   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 1��{ ? 	   Nguyễn Ngọc Trường�True1Sync